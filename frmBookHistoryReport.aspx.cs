using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmBookHistoryReport : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getStudents();
            getTeachers();
        }
    }

    protected void getStudents()
    {
        try
        {
            strQry = "[usp_ReportBookHistory] @command='getStudent',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlStudent, strQry, "StudentName", "intStudent_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }

    protected void getTeachers()
    {
        try
        {
            strQry = "[usp_ReportBookHistory] @command='getTeacher',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlTeacher, strQry, "TeacherName", "intTeacher_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }

    protected void fGrid()
    {
        try
        {
            strQry = "usp_ReportBookHistory @command='getResult',@intStudentId='" + ddlStudent.SelectedValue.Trim()
                + "',@intTeacherId='" + ddlTeacher.SelectedValue.ToString()
                + "',@intSchool_id='" + Convert.ToString(Session["School_id"])
                + "',@vchAccenssionNo='" + txtSearchAccession.Text.ToString() + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                Session["BookHistoryDetailsTableDummy"] = dsObj;
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                Session["BookHistoryDetailsTableDummy"] = dsObj;
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }

    protected void grvDetail_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvDetail.PageIndex = e.NewPageIndex;
        fGrid();
    }

    protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlStudent.ClearSelection();
        fGrid();
    }

    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTeacher.ClearSelection();
        fGrid();
    }

    protected void txtSearchAccession_TextChanged(object sender, EventArgs e)
    {
        fGrid();
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetSearchAccession(string prefixText)
    {
        List<string> GetSearchAccession = new List<string>();
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["esmsCentralModel"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select vchAccessionNo from tblBookAssign where vchAccessionNo like @Name+'%' and intBookDetails_id IS NOT NULL and intSchool_id='" + Convert.ToString(HttpContext.Current.Session["School_id"])
                + "' union select vchAccessionNo from tblTeacherBookAssign where vchAccessionNo like @Name+'%' and intBookDetails_id IS NOT NULL and intSchool_id='" + Convert.ToString(HttpContext.Current.Session["School_id"])
                + "'", con);
            cmd.Parameters.AddWithValue("@Name", prefixText);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GetSearchAccession.Add(dt.Rows[i][0].ToString());
            }
            return GetSearchAccession;
        }
        catch (Exception ex)
        {
            LogException(ex);
            return GetSearchAccession;
        }

    }

    protected void ExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Session["BookHistoryDetailsTable"] = Session["BookHistoryDetailsTableDummy"];
            if (grvDetail.Rows.Count > 0)
                Response.Redirect("frmExcel.aspx");
            else
                MessageBox("No Records found!");
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }

    }
}
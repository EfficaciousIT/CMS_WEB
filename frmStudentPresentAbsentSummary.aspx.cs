using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.IO;

public partial class frmStudentPresentAbsentSummary : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strDate = string.Empty;
    string strToDate = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillSTD();
            //Teacher_Students();
        }


    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        string std = Convert.ToString(ddlSTD.SelectedValue);
        FillDIV();

    }
    protected void ddlDIV_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStudent();
    }
    public void FillStudent()
    {
        try
        {

            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + ddlSTD.SelectedValue + "',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

            sBindDropDownList(ddlStudent, strQry, "Name", "intStudent_id");

            if (ddlStudent.Items.Count > 1)
                ddlStudent.Items.Add(new ListItem("All", "-1"));
            else
                ddlStudent.DataSource = null;
        }
        catch
        {

        }
    }
    public void FillSTD()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "3")
            {
                strQry = "exec [usp_getAttendance] @type='FillStd',@TeacherId='" + Convert.ToString(Session["User_id"]) + "',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
                FillDIV();
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
                FillDIV();
            }

        }
        catch
        {

        }
    }
    public void FillDIV()
    {
        try
        {
            strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSTD.SelectedItem.Value) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlDIV, strQry, "vchDivisionName", "intDivision_id");
            FillStudent();
        }
        catch
        {

        }
    }

    public void ShowAbsent()
    {
        strDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strToDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strQry = "usp_Attendacesummary  @command='Studentabsentcount',@fromDate='" + strDate.Trim() + "',@ToDate='" + strToDate.Trim() + "',@intSchool_id='" + Session["School_id"] + "',@intStudent_id='" + ddlStudent.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdAbsent.DataSource = dsObj;
            grdAbsent.DataBind();
        }
    }
    public void ShowPresent()
    {
        strDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strToDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strQry = "usp_Attendacesummary @command='Studentpresentcount',@fromDate='" + strDate.Trim() + "',@ToDate='" + strToDate.Trim() + "',@intSchool_id='" + Session["School_id"] + "',@intStudent_id='" + ddlStudent.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);

        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdAbsent.DataSource = dsObj;
            grdAbsent.DataBind();
        }
    }
  
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        if (ddlFilter.SelectedValue == "1")
        {
            ShowAbsent();
        }
        if (ddlFilter.SelectedValue == "2")
        {
            ShowPresent();
        }
    }
   
    protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtFromDate.Text = "";
        txtDate.Text = "";
    }


    protected void grdAbsent_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

    
    protected void ImgDoc_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Clear();
        //Response.Buffer = true;
        //Response.ClearContent();
        //Response.ClearHeaders();
        //Response.Charset = "";
        //string FileName = "Vithal" + DateTime.Now + ".xls";
        //StringWriter strwritter = new StringWriter();
        //HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //Response.ContentType = "application/vnd.ms-excel";
        //Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        //grdAbsent.GridLines = GridLines.Both;
        //grdAbsent.HeaderStyle.Font.Bold = true;
        //grdAbsent.RenderControl(htmltextwrtter);
        //Response.Write(strwritter.ToString());
        //HttpContext.Current.Response.Flush();
        //HttpContext.Current.Response.SuppressContent = true;
        //HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
}
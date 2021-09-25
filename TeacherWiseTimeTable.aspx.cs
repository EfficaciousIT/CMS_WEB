using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.UI;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class TeacherWiseTimeTable : DBUtility
{

    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            FillTeacher();

        }
    }

    public void FillTeacher()
    {
        try
        {
            strQry = "exec [usp_LectureAssign] @command='LectureTeacher',@intTeacher_id='" + Convert.ToString(Session["User_id"]) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlTEACHER, strQry, "Name", "intTeacher_id");

        }
        catch
        {

        }
    }
   

    public void FillGrid()
    {
        try
        {
            strQry = "exec usp_TEACHERTIMETABLE @command='SELECT',@intTeacher_id='" + Convert.ToString(ddlTEACHER.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intYear_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            // strQry = "exec usp_TEACHERTIMETABLE @command='SELECT',@intschool_id='" + Convert.ToString(Session["School_id"])+'",@Dept='" + Convert.ToString(ddlDept.SelectedValue) + "',
            dsObj = sGetDataset(strQry);
            grdTeach.DataSource = dsObj;
            grdTeach.DataBind();

        }
        catch
        {

        }
    }


    protected void btnExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        grdTeach.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    protected void ddlTEACHER_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            strQry = "exec usp_TEACHERTIMETABLE @command='SELECT',@intTeacher_id='" + Convert.ToString(ddlTEACHER.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intYear_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            // strQry = "exec usp_TEACHERTIMETABLE @command='SELECT',@intschool_id='" + Convert.ToString(Session["School_id"])+'",@Dept='" + Convert.ToString(ddlDept.SelectedValue) + "',
            dsObj = sGetDataset(strQry);
            grdTeach.DataSource = dsObj;
            grdTeach.DataBind();

        }
        catch
        {

        }

    }

    protected void grdTeach_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label lblRecess = (Label)e.Row.FindControl("lblRecess");
            //    Label lblTime = (Label)e.Row.FindControl("lblPeriod");
            //    Label lblSrNo = (Label)e.Row.FindControl("lblSrno");


            //    if (lblRecess.Text == "1" || lblRecess.Text == "True")
            //    {
            //        e.Row.BackColor = System.Drawing.Color.Silver;
            //        e.Row.Font.Bold = true;
            //        e.Row.ForeColor = System.Drawing.Color.Red;
            //        e.Row.Cells[2].Text = "R";
            //        e.Row.Cells[3].Text = "E";
            //        e.Row.Cells[4].Text = "C";
            //        e.Row.Cells[5].Text = "E";
            //        e.Row.Cells[6].Text = "S";
            //        e.Row.Cells[7].Text = "S";

            //    }
            //}
        }
        catch
        {

        }
    }
}
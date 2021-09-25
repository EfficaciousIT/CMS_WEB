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

public partial class StudentWiseTimeTable : DBUtility
{

    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillSTD();
            
        }
    }

    public void FillGrid()
    {
        try
        {
            strQry = "exec usp_CLASSWISETABLE @command='SELECT',@intStandard_id ='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intDivision_id ='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intYear_id='" + Convert.ToString(Session["AcademicID"]) + "'";
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

    
    public void FillSTD()
    {
        try
        {

            strQry = "exec [usp_Profile] @command='RemarkStandard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlSTD, strQry, "Standard_Name", "intStandard_id");

        }
        catch
        {

        }
    }

    public void FillDIV()
    {
        try
        {
            string query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
            bool st2 = sBindDropDownList(ddlDIV, query2, "vchDivisionName", "intDivision_id");
            
        }
        catch
        {

        }
    }

    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDIV();
    }

    protected void ddlDIV_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();

    }
  

    protected void grdTeach_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            
        }
        catch
        {

        }
    }
}
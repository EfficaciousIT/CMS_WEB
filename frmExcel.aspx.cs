using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class frmExcel : DBUtility
{
    DataSet ds = null;
    DataSet ds2 = null;
    DataSet ds3 = null;
    DataTable dstemp;

    DataSet dsFeeReport = null;

    protected void Page_Load(object sender, EventArgs e)
    {

        ds = (DataSet)Session["BookDetailsTable"];
        ds2 = (DataSet)Session["BookHistoryDetailsTable"];
        ds3 = (DataSet)Session["BookDetailsReportTable"];
        dstemp = (DataTable)Session["Temp"];

        dsFeeReport = (DataSet)Session["FeeReport"];

        if (ds == null && ds2 == null && ds3 == null && dstemp == null && dsFeeReport == null)
        {
            ds = (DataSet)Session["Table"];
            ExportToExcel1();
        }
        else if (ds2 != null)
            ExportToExcelForBookHistory();
        else if (ds3 != null)
            ExportToExcelForBookDetailsReport();
        else if (dstemp != null)
            ExportToExcelMarks();
        else if (dsFeeReport != null)
            ExportToExcelReport();
        else
            ExportToExcel();


    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    public void ExportToExcel()
    {
        try
        {
            Session["BookDetailsTableDummy"] = Session["BookDetailsTable"];
            Session["BookDetailsTable"] = null;
            grvDetail.DataSource = ds;
            grvDetail.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();

            string FileName = "BookDetails" + DateTime.Now + ".xls";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter strwritter;
            strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            // GridView.GridLines = GridLines.Both;
            // GridView.HeaderStyle.Font.Bold = true;
            grvDetail.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            //Response.Output.Write(strwritter.ToString());
            HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
            // HttpContext.Current.ApplicationInstance.CompleteRequest();    
        }
        catch (Exception ex)
        {
            LogException(ex);
            HttpContext.Current.RewritePath("frmBookDetails.aspx");
        }
    }

    public void ExportToExcel1()
    {
        try
        {
            GridViewliststud.DataSource = Session["Table"];
            GridViewliststud.DataBind();


            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();

            string FileName = "Student" + DateTime.Now + ".xls";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter strwritter;
            strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            // GridView.GridLines = GridLines.Both;
            // GridView.HeaderStyle.Font.Bold = true;
            GridViewliststud.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            //Response.Output.Write(strwritter.ToString());
            HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
            // HttpContext.Current.ApplicationInstance.CompleteRequest();


        }
        catch (Exception ex)
        {
            LogException(ex);
            HttpContext.Current.RewritePath("frmAdmListStudentDetails.aspx");
        }
    }
    public void ExportToExcelMarks()
    {
        if (dstemp != null)
        {
            try
            {
                string std = Convert.ToString(Session["standard"]);
                string div = Convert.ToString(Session["division"]);
                string examination = Convert.ToString(Session["examination"]);

                grdtemp.Visible = true;

                grdtemp.DataSource = dstemp;
                grdtemp.DataBind();


                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();

                string FileName = "Std " + std + " Div " + div + "Exam " + examination + ".xls";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter strwritter;
                strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                // GridView.GridLines = GridLines.Both;
                // GridView.HeaderStyle.Font.Bold = true;
                grdtemp.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                //Response.Output.Write(strwritter.ToString());
                HttpContext.Current.Response.Flush();
                System.Web.HttpContext.Current.Response.End();
                // HttpContext.Current.ApplicationInstance.CompleteRequest();
                dstemp.Clear();
                HttpContext.Current.RewritePath("AdminDB.aspx");
            }
            catch (Exception ex)
            {
                //HttpContext.Current.RewritePath("admindb.aspx");
                HttpContext.Current.RewritePath("AdminDB.aspx");
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("frmAdmListStudentDetails.aspx");
    }

    protected void GridViewliststud_RowEditing(object sender, GridViewEditEventArgs e)
    {


    }
    protected void GridViewliststud_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridViewliststud_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{

        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {

        //        intforumid = Convert.ToInt32(GridViewliststud.DataKeys[e.Row.RowIndex].Value);
        //        Image img = (Image)e.Row.FindControl("btnDetails");
        //        img.Attributes.Add("onclick", "window.open('frmLiStudentProfile.aspx?successMessage=" + intforumid + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=1000,top=100,left=200');return false");

        //        intforumid1 = Convert.ToInt32(GridViewliststud.DataKeys[e.Row.RowIndex].Value);
        //        Image img1 = (Image)e.Row.FindControl("btnpareDetails");
        //        img1.Attributes.Add("onclick", "window.open('frmAdmPareProDetai1.aspx?successMessage=" + intforumid + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=900,top=100,left=200');return false");

        //        intfor3 = Convert.ToInt32(GridViewliststud.DataKeys[e.Row.RowIndex].Value);
        //        Image img3 = (Image)e.Row.FindControl("ImgEdit");
        //        img3.Attributes.Add("onclick", "window.open('frmAdmLiStudentProfile.aspx?successMessage3=" + intfor3 + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=900,top=100,left=200');return false");

        //    }
        //}
        //catch
        //{
        //}

    }
    protected void GridViewliststud_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }


    public void ExportToExcelForBookHistory()
    {
        try
        {
            Session["BookHistoryDetailsTableDummy"] = Session["BookHistoryDetailsTable"];
            Session["BookHistoryDetailsTable"] = null;
            grdBookHistory.DataSource = ds2;
            grdBookHistory.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();

            string FileName = "BookHistory" + DateTime.Now + ".xls";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter strwritter;
            strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            // GridView.GridLines = GridLines.Both;
            // GridView.HeaderStyle.Font.Bold = true;
            grdBookHistory.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            //Response.Output.Write(strwritter.ToString());
            HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
            // HttpContext.Current.ApplicationInstance.CompleteRequest();    
        }
        catch (Exception ex)
        {
            LogException(ex);
            HttpContext.Current.RewritePath("frmBookHistoryReport.aspx");
        }
    }

    public void ExportToExcelForBookDetailsReport()
    {
        try
        {
            Session["BookDetailsReportTableDummy"] = Session["BookDetailsReportTable"];
            Session["BookDetailsReportTable"] = null;
            grdBookDetailsReport.DataSource = ds3;
            grdBookDetailsReport.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();

            string FileName = "BookDetailsReport" + DateTime.Now + ".xls";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter strwritter;
            strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            // GridView.GridLines = GridLines.Both;
            // GridView.HeaderStyle.Font.Bold = true;
            grdBookDetailsReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            //Response.Output.Write(strwritter.ToString());
            HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
            // HttpContext.Current.ApplicationInstance.CompleteRequest();    
        }
        catch (Exception ex)
        {
            LogException(ex);
            HttpContext.Current.RewritePath("frmBookHistoryReport.aspx");
        }
    }

    public void ExportToExcelReport()
    {
        try
        {
            //GridView2.DataSource = Session["FeeReport"];
            //GridView2.DataBind();


            //Response.Clear();
            //Response.Buffer = true;
            //Response.ClearContent();
            //Response.ClearHeaders();

            //string FileName = "Fee_Report" + DateTime.Now + ".xls";
            //Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //StringWriter strwritter;
            //strwritter = new StringWriter();
            //HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);

            //GridView2.RenderControl(htmltextwrtter);
            //Response.Write(strwritter.ToString());

            //HttpContext.Current.Response.Flush();
            //System.Web.HttpContext.Current.Response.End();


            ////////////////////////
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Report.xls"));
            Response.ContentType = "application/ms-excel";
            DataTable dt = dsFeeReport.Tables[0];
            string str = string.Empty;

            //GridView2.DataSource = Session["FeeReport"];
            //GridView2.DataBind();

            //GridView excel = new GridView();
            GridView2.DataSource = dsFeeReport.Tables[0];
            GridView2.DataBind();
            GridView2.RenderControl(new HtmlTextWriter(Response.Output));

            Response.End();


        }
        catch (Exception ex)
        {
            LogException(ex);
            HttpContext.Current.RewritePath("frmstudfeecollection.aspx");
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;
public partial class AttendanceSummary : DBUtility
{
    string strDate = string.Empty;   
    DataSet dsObj = new DataSet();
    string strQry = string.Empty;
    string strFilter = string.Empty;
    string strType = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        strDate = Convert.ToDateTime(Request.QueryString["date"]).ToString("MM/dd/yyyy").Replace("-","/");
        strFilter = Convert.ToString(Request.QueryString["filter"]);
        strType = Convert.ToString(Request.QueryString["Type"]);
        if (strType == "3")
        {
            if (strFilter == "1")
            {
                ShowAbsentTeacher();
            }
            if (strFilter == "2")
            {
                ShowPresentTeacher();
            }
        }
        if (strType == "4")
        {
            if (strFilter == "1")
            {
                ShowAbsentStaff();
            }
            if (strFilter == "2")
            {
                ShowPresentStaff();
            }
        }
        if (strType == "5")
        {
            if (strFilter == "1")
            {
                ShowAbsentAdmin();
            }
            if (strFilter == "2")
            {
                ShowPresentAdmin();
            }
        }
    }
    public void ShowAbsentTeacher()
    {
        try
        {

            if (strDate != "")
            {
                strQry = "usp_UserAttendacesummary  @command='AbsentTeacher',@fromDate='" + strDate.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    grdDet.DataSource = dsObj;
                    grdDet.DataBind();
                }
            }
        }
        catch
        {
        }

    }
    public void ShowPresentTeacher()
    {
        try
        {

            if (strDate != "")
            {
                strQry = "usp_UserAttendacesummary  @command='PresentTeacher',@fromDate='" + strDate.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    grdDet.DataSource = dsObj;
                    grdDet.DataBind();
                }
            }
        }
        catch
        {
        }
    }

    //staff
    public void ShowAbsentStaff()
    {
        try
        {

            if (strDate != "")
            {
                strQry = "usp_UserAttendacesummary  @command='AbsentStaff',@fromDate='" + strDate.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    grdDet.DataSource = dsObj;
                    grdDet.DataBind();
                }
            }
        }
        catch
        {
        }

    }
    public void ShowPresentStaff()
    {
        try
        {

            if (strDate != "")
            {
                strQry = "usp_UserAttendacesummary  @command='PresentStaff',@fromDate='" + strDate.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    grdDet.DataSource = dsObj;
                    grdDet.DataBind();
                }
            }
        }
        catch
        {
        }

    }
    //admin
    public void ShowAbsentAdmin()
    {
        try
        {

            if (strDate != "")
            {
                strQry = "usp_UserAttendacesummary  @command='AbsentAdmin',@fromDate='" + strDate.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    grdDet.DataSource = dsObj;
                    grdDet.DataBind();
                }
            }
        }
        catch
        {
        }

    }
    public void ShowPresentAdmin()
    {
        try
        {
            if (strDate != "")
            {
                strQry = "usp_UserAttendacesummary  @command='PresentAdmin',@fromDate='" + strDate.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    grdDet.DataSource = dsObj;
                    grdDet.DataBind();
                }
            }
        }
        catch
        { 
        }
        
    }
    protected void ImgXls_Click(object sender, ImageClickEventArgs e)
    {
        //excel Working
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=AttendenceDet.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        grdDet.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
}
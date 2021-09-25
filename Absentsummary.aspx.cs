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
public partial class Absentsummary : DBUtility
{
    string strDate = string.Empty;   
    DataSet dsObj = new DataSet();
    string strQry = string.Empty;
    string strFilter = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        strDate = Convert.ToDateTime(Request.QueryString["date"]).ToString("MM/dd/yyyy").Replace("-","/");
        strFilter = Convert.ToString(Request.QueryString["filter"]);
        if (strFilter == "1")
        {
            ShowAbsent();
        }
        if (strFilter == "2")
        {
            ShowPresent();
        }         
    }
    public void ShowAbsent()
    {
        if (strDate != "")
        {
            strQry = "usp_Attendacesummary  @command='Absent',@fromDate='" + strDate.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grdDet.DataSource = dsObj;
                grdDet.DataBind();
            }
        }
    }
    public void ShowPresent()
    {
        if (strDate != "")
        {
            strQry = "usp_Attendacesummary  @command='Present',@fromDate='" + strDate.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grdDet.DataSource = dsObj;
                grdDet.DataBind();
            }
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
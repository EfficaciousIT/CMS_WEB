using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using itext = iTextSharp.text;
using System.Web;
using System.Data.SqlClient;
using System.Diagnostics;

/// <summary>
/// Summary description for ClsExportExcel
/// </summary>
public class ClsExportExcel : DBUtility
{
    public void ExportGrid(GridView gvDetails, string FileName, int Roll, string Name, string STD, string DIV, string UserType, string HeaderName)
    {
        FileName = FileName.Replace("/", "");
        FileName = FileName.Replace(" ", "");
        FileName = FileName.Replace(":", "");
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", FileName + ".xls"));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        
        htw.Write("<table width='100%'><tr><td colspan='2'><img src='~\\images\\pdflogo.jpg' alt='' /></td><td></td><td colspan='4' ><h2>Central Model School</h2></td></tr>");
        htw.Write("<table><tr><td></td><td></td><td></td><td colspan='2' align='center'>Barrakpore</td><td colspan='2' align='center'> </td></tr><tr><td><br/></td></tr></table>");

        //if (Convert.ToString(Session["UserType_id"]) == "5")
        //{
        if (UserType == "1" || UserType == "2")
            {
                htw.Write("<table width='100%'><tr><td><b>Student Name</b></td><td colspan='3'>" + Name + "</td><td><b>Date</b></td><td>" + Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy") + "</td></tr>");
                htw.Write("<table width='100%'><tr><td><b>STD</b></td><td colspan='3' align='left'>" + STD + "</td><td><b>Time</b></td><td align='left'>" + Convert.ToDateTime(DateTime.Now).ToString("hh:mm \tt") + "</td></tr>");
                htw.Write("<table width='100%'><tr><td><b>DIV</b></td><td colspan='3' align='left'>" + DIV + "</td></tr>");
            }
            else
            {
                htw.Write("<table width='100%'><tr><td><b>Staff Name</b></td><td colspan='3'>" + Name + "</td><td><b>Date</b></td><td>" + Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy") + "</td></tr>");
                htw.Write("<table width='100%'><tr><td><b>Emp No</b></td><td colspan='3' align='left'>" + Roll + "</td><td><b>Time</b></td><td align='left'>" + Convert.ToDateTime(DateTime.Now).ToString("hh:mm \tt") + "</td></tr>");
                htw.Write("<table width='100%'><tr><td><b>Department</b></td><td colspan='3' align='left'>" + STD + "</td></tr>");
            }
        //}

        //else
        //{
        //    htw.Write("<table width='100%'><tr><td><b>Date</b></td><td>" + Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy") + "</td></tr>");
        //    htw.Write("<table width='100%'><tr><td><b>Time</b></td><td>" + Convert.ToDateTime(DateTime.Now).ToString("hh:mm \tt") + "</td></tr>");
        // //   htw.Write("<table width='100%'><tr><td><b>DIV</b></td><td colspan='3' align='left'>" + DIV + "</td></tr>");
        //}
      
            htw.Write("<table width='100%'><tr><td colspan='5' align='center'><b>" + HeaderName + "</b></td></tr>");
            htw.Write("<table width='100%'><tr><td colspan='5' align='center'></td></tr>");
            gvDetails.AllowPaging = false;
            //Change the Header Row back to white color
           // gvDetails.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Applying stlye to gridview header cells
            for (int i = 0; i < gvDetails.HeaderRow.Cells.Count; i++)
            {
                gvDetails.HeaderRow.Cells[i].Style.Add("background-color", "#037403");
            }
            int j = 1;
            //Set alternate row color
            foreach (GridViewRow gvrow in gvDetails.Rows)
            {
                gvrow.BackColor = System.Drawing.Color.White;
                if (j <= gvDetails.Rows.Count)
                {
                    if (j % 2 != 0)
                    {
                        for (int k = 0; k < gvrow.Cells.Count; k++)
                        {
                            gvrow.Cells[k].Style.Add("background-color", "#C1E8C1");
                        }
                    }
                }
                j++;
            }
        
        gvDetails.RenderControl(htw);
        HttpContext.Current.Response.Write(sw.ToString());
        HttpContext.Current.Response.Flush();
        System.Web.HttpContext.Current.Response.End();

    }
}
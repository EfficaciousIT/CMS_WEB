using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

public partial class rptcharcertificate : DBUtility
{
    ReportDocument crystalReport = new ReportDocument();
    Stream stream1;
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    string strQry = "";
    DataSet dsObj;
    DataSet dsObjgrade;
    string exam = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string reportPath = Server.MapPath("RptCharacterCertificate.rpt");
            crystalReport.Load(reportPath);

           
            TextObject vchStudent_name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text9"];
            TextObject vchFatherName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text15"];
            TextObject vchMotherName= (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text50"];

            TextObject vchclass = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text16"];
            TextObject vchSec = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text18"];
            //TextObject vchStream = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text49"];
            TextObject intRollno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text21"];
            TextObject vchYear = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text23"];
            TextObject vchappclass = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text26"];
            
            //TextObject vchappStream = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text49"];
            TextObject intAISSCERollno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text30"];
            TextObject vchappYear = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text33"];
            TextObject dtDOB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text37"];

            TextObject dtDOBday = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text39"];
            TextObject dtDOBmonth = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text41"];
            TextObject dtDOByear = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text43"];
            
            //TextObject vchPreparedby = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text49"];

            if (Session["rptStudentdetail"] != null)
            {
                if (Session["rptUPStudentdetail"] == null)
                {
                    dsObj = (DataSet)Session["rptStudentdetail"];
                }
                else if (Session["rptUPStudentdetail"] != null)
                {
                    dsObj = (DataSet)Session["rptUPStudentdetail"];
                }
                
            }
            else
            {
                strQry = "Execute dbo.usp_CharCertificate @command='Selectrecord',@intAcademic_id='" + Session["AcademicID"] + "'";
                //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);

            }
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                try
                {
                    vchStudent_name.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudent_name"]);
                    vchStudent_name.Text = Convert.ToString(vchStudent_name.Text).ToUpper();
                }
                catch
                { 
                }
                try
                {
                    vchFatherName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                    vchFatherName.Text = Convert.ToString(vchFatherName.Text).ToUpper();
                }
                catch
                { 
                }
                try
                {
                vchMotherName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMontherName"]);
                vchMotherName.Text = Convert.ToString(vchMotherName.Text).ToUpper();
                     }
                catch
                { 
                }
                try
                {
                vchclass.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchclass"]);
                vchclass.Text = Convert.ToString(vchclass.Text).ToUpper();
                     }
                catch
                { 
                }
                try
                {
                vchSec.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchSec"]);
                vchSec.Text = Convert.ToString(vchSec.Text).ToUpper();
                     }
                catch
                { 
                }
                try
                {
               //vchStream.Text = Convert.ToString(ddlstream.Text);
                intRollno.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollno"]);
                //vchStudent_name.Text = Convert.ToString(vchStudent_name.Text).ToUpper();
                     }
                catch
                { 
                }
                try
                {
                vchYear.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchYear"]);
                //vchStudent_name.Text = Convert.ToString(vchStudent_name.Text).ToUpper();
                     }
                catch
                { 
                }
                try
                {
                vchappclass.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchappclass"]);
                vchappclass.Text = Convert.ToString(vchappclass.Text).ToUpper();
                     }
                catch
                { 
                }
                try
                {
                //string vchappSec = Convert.ToString(txtmothername.Text);
               //vchappStream.Text = Convert.ToString(ddlappstream.Text);
                intAISSCERollno.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intAISSCERollno"]);
                     }
                catch
                { 
                }
                try
                {
                vchappYear.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchappYear"]);
                     }
                catch
                { 
                }
                try
                {
                dtDOB.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtDOB"]).ToString("dd/MM/yyyy"); //Convert.ToString(txtDOBword.Text);
                     }
                catch
                { 
                }
                try
                {

                    dtDOBday.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtDOB"]).ToString("dd"); //Convert.ToString(txtDOBword.Text);

                    int day = int.Parse(dtDOBday.Text);

                    dtDOBday.Text = ConvertNumbertoWords(day);

                    dtDOBmonth.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtDOB"]).ToString("MMMM");
                    dtDOBmonth.Text = dtDOBmonth.Text.ToUpper();

                    dtDOByear.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtDOB"]).ToString("yyyy");
                    int year = int.Parse(dtDOByear.Text);
                    dtDOByear.Text = ConvertNumbertoWords(year);


                }
                catch 
                { }
            
                //string vchDOBword = Convert.ToString(txtcharacter.Text);
               //vchPreparedby.Text = Convert.ToString(txtpreparedby.Text);

            }
 
            crystalReport.Load(Server.MapPath(string.Format("RptCharacterCertificate.rpt")));
            //AdmissionReport.ReportSource = crystalReport;
            crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, string.Empty);
        }
        catch
        { 
        
        }

    }

    public static string ConvertNumbertoWords(int number)
    {
        if (number == 0)
            return "ZERO";
        if (number < 0)
            return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";
        if ((number / 1000000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000000) + " MILLION ";
            number %= 1000000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
            number %= 100;
        }
        if (number > 0)
        {
            //if (words != "")
                //words += "AND ";
            var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
            var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }
        return words;
    }
}
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

public partial class CharacterCertificate2 : DBUtility
{
    ReportDocument crystalReport = new ReportDocument();
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    string strQry = "";
    DataSet dsObj;
    DataSet dsObjgrade;
    string exam = "";

	protected void Page_Load(object sender, EventArgs e)
	{
        if (Session["UserType_id"] != null && Session["User_id"] != null || Session["Student_id"] != null)
        {
            if (!IsPostBack)
            {

                //btnSubmit.Visible = true;
                FillSTD();
                //GetAutoSRNO();
                //txtsrno.Text = Convert.ToString(ViewState["sesSRNo"]);

            }
        }

	}
    public void FillSTD()
    {
        try
        {
            try
            {
                strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
                sBindDropDownList(ddlappclass, strQry, "vchStandard_name", "intstandard_id");
                //sBindDropDownList(drpSTD, strQry, "vchStandard_name", "intstandard_id");
                // FillDIV();
                //FillExaminationType();
            }
            catch (Exception)
            {

                throw;
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
            //ddlGender.ClearSelection();
            strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlDIV, strQry, "vchDivisionName", "intDivision_id");
            FillStudent();
            //FillExam();
            //FillSubject();
        }
        catch
        {

        }
    }

    public void FillStudent()
    {
        try
        {

            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            //strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
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

    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDIV();

    }

    protected void ddlDIV_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStudent();
    }

    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {

        string SRNO = Convert.ToString(ViewState["sesSRNo"]);

        strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intStudent_id='" + ddlStudent.SelectedValue + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + ddlSTD.SelectedValue + "'";
        //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            txtnameofpupil.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
            txtfathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
            txtmothername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
            txtclass.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStandard_name"]);
            txtSec.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
            txtRollno.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);
            txtDOB.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtDOB"]).ToString("dd/MMMM/yyyy");

            string strQry1="select AcademicYear from tblAcademicYear where intAcademic_id='"+Convert.ToString(Session["AcademicID"])+"' ";
            dsObj = sGetDataset(strQry1);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtyear.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["AcademicYear"]);
            }
            //Convert.ToDateTime(txtDOBfig.Text).ToString("dd/MMMM/yyyy");
        }

        
        

    }

    protected void view_Click(object sender, EventArgs e)
    {
        string vchStudent_name = "";
        string vchFatherName = "";
        string vchMotherName = "";
        string vchclass = "";
        string vchSec = "";
        string vchStream = "";
        string intRollno = "";
        string vchYear = "";
        string vchappclass = "";
        //string vchappSec = Convert.ToString(txtmothername.Text);
        string vchappStream = "";
        string intAISSCERollno = "";
        string vchappYear = "";
        string dtDOB = ""; //Convert.ToString(txtDOBword.Text);
        //string vchDOBword = Convert.ToString(txtcharacter.Text);
        string vchPreparedby = "";
        try
        {
             vchStudent_name = Convert.ToString(txtnameofpupil.Text).ToUpper();
            
        }
        catch 
        { 
        }
        try
        {
             vchFatherName = Convert.ToString(txtfathername.Text).ToUpper();
            }
        catch 
        { 
        }
        try
        {
             vchMotherName = Convert.ToString(txtmothername.Text).ToUpper();
            }
        catch 
        { 
        }
        try
        {
             vchclass = Convert.ToString(txtclass.Text).ToUpper();
            }
        catch 
        { 
        }
        try
        {
             vchSec = Convert.ToString(txtSec.Text).ToUpper();
            }
        catch 
        { 
        }
        try
        {
             vchStream = Convert.ToString(ddlstream.Text).ToUpper();
            }
        catch 
        { 
        }
        try
        {
      intRollno = Convert.ToString(txtRollno.Text);
            }
        catch 
        { 
        }
        try
        {
       vchYear = Convert.ToString(txtyear.Text);
            }
        catch 
        { 
        }
        try
        {
        vchappclass = Convert.ToString(ddlappclass.SelectedItem);
            }
        catch 
        { 
        }
        try
        {
        //string vchappSec = Convert.ToString(txtmothername.Text);
     vchappStream = Convert.ToString(ddlappstream.Text);
            }
        catch 
        { 
        }
        try
        {
         intAISSCERollno = Convert.ToString(txtAISSCERollno.Text);
            }
        catch 
        { 
        }
        try
        {
         vchappYear = Convert.ToString(txtappyear.Text);
            }
        catch 
        { 
        }
        try
        {
         dtDOB = Convert.ToDateTime(txtDOB.Text).ToString("dd/MMMM/yyyy"); //Convert.ToString(txtDOBword.Text);
            }
        catch 
        { 
        }
        try
        {
            //string vchDOBword = Convert.ToString(txtcharacter.Text);
           vchPreparedby = Convert.ToString(txtpreparedby.Text);
        }
        catch { }

        string reportPath = Server.MapPath("RptCharacterCertificate.rpt");
        crystalReport.Load(reportPath);

        TextObject CRvchStudent_name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text9"];
        TextObject CRvchFatherName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text15"];
        TextObject CRvchMotherName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text50"];

        TextObject CRvchclass = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text16"];
        TextObject CRvchSec = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text18"];
        //TextObject vchStream = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text49"];
        TextObject CRintRollno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text21"];
        TextObject CRvchYear = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text23"];
        TextObject CRvchappclass = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text26"];

        //TextObject vchappStream = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text49"];
        TextObject CRintAISSCERollno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text30"];
        TextObject CRvchappYear = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text33"];
        TextObject CRdtDOB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text37"];

        TextObject CRdtDOBday = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text39"];
        TextObject CRdtDOBmonth = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text41"];
        TextObject CRdtDOByear = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text43"];


        CRvchStudent_name.Text =vchStudent_name; 
        CRvchFatherName.Text = vchFatherName;
        CRvchMotherName.Text = vchMotherName;

        CRvchclass.Text = vchclass;
        CRvchSec.Text = vchSec;
        //TextObject vchStream = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text49"];
        CRintRollno.Text = intRollno;
        CRvchYear.Text = vchYear;
        CRvchappclass.Text = vchappclass;

        //TextObject vchappStream = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text49"];
        CRintAISSCERollno.Text = intAISSCERollno;
        CRvchappYear.Text = vchappYear;
        CRdtDOB.Text = dtDOB;
        CRdtDOBday.Text = Convert.ToDateTime(txtDOB.Text).ToString("dd");

        int day = int.Parse(CRdtDOBday.Text);

                    CRdtDOBday.Text = ConvertNumbertoWords(day);

                    CRdtDOBmonth.Text = Convert.ToDateTime(txtDOB.Text).ToString("MMMM");

                    CRdtDOByear.Text = Convert.ToDateTime(txtDOB.Text).ToString("yyyy");
                    int year = int.Parse(CRdtDOByear.Text);
                    CRdtDOByear.Text = ConvertNumbertoWords(year);

                    crystalReport.Load(Server.MapPath(string.Format("RptCharacterCertificate.rpt")));
                    AdmissionReport.ReportSource = crystalReport;

        


        //Response.Redirect("rptcharcertificate.aspx", true);
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

    protected void show_Click(object sender, EventArgs e)
    {
    }

    protected void Update_Click(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {

        try
        {
            
            string vchStudent_name = Convert.ToString(txtnameofpupil.Text);
            string vchFatherName = Convert.ToString(txtfathername.Text);
            string vchMotherName = Convert.ToString(txtmothername.Text);
            string vchclass = Convert.ToString(txtclass.Text);
	        string vchSec = Convert.ToString(txtSec.Text);
	        string vchStream = Convert.ToString(ddlstream.Text);
	        string intRollno = Convert.ToString(txtRollno.Text);
	        string vchYear = Convert.ToString(txtyear.Text);
	        string vchappclass = Convert.ToString(ddlappclass.SelectedItem);
	        //string vchappSec = Convert.ToString(txtmothername.Text);
	        string vchappStream = Convert.ToString(ddlappstream.Text);
	        string intAISSCERollno = Convert.ToString(txtAISSCERollno.Text);
	        string vchappYear = Convert.ToString(txtappyear.Text);
	        string dtDOB = Convert.ToDateTime(txtDOB.Text).ToString("dd/MMMM/yyyy"); //Convert.ToString(txtDOBword.Text);
            //string vchDOBword = Convert.ToString(txtcharacter.Text);
            string vchPreparedby = Convert.ToString(txtpreparedby.Text);





            string instrquery1 = "Execute dbo.usp_CharCertificate @command='Insertcharcertificate',@intStudent_id='" + ddlStudent.SelectedValue + "',@vchStudent_name='" + vchStudent_name + "',@vchFatherName='" + vchFatherName + "',@dtDOB='" + dtDOB + "'," +
                                  "@vchMotherName='" + vchMotherName + "',@vchclass='" + vchclass + "',@vchSec='" + vchSec + "',@vchStream='" + vchStream + "',@intRollno='" + intRollno + "',@vchYear='" + vchYear + "',@vchappclass='" + vchappclass + "'," +
                                  "@vchappStream='" + vchappStream + "',@intAISSCERollno='" + intAISSCERollno + "',@vchappYear='" + vchappYear + "',@vchPreparedby='" + vchPreparedby + "'," +
                                  "@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "',@intAcademic_id='" + Session["AcademicID"] + "'";



            int str = sExecuteQuery(instrquery1);

            if (str != -1)
            {
                string display = "Submit Successfuly!";
                MessageBox(display);
                btnSubmit.Text = "Submit";
                //ButN6.Visible = false;
                // Clear();
                //fGrid();

                Response.Redirect("rptcharcertificate.aspx", true);

            }
            else
            {
                MessageBox("ooopppsss!TC certificate submission Failed");

            }


        }
        catch
        {
            MessageBox("ooopppsss!TC certificate submission Failed");
        }
    }

    public void GetAutoSRNO()
    {
        strQry = "exec usp_TCcertificate @command='GetAutoSRNO',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            ViewState["sesSRNo"] = Convert.ToString(dsObj.Tables[0].Rows[0]["SRNo"]).ToString().Trim();
        }
        else
        {
            ViewState["sesSRNo"] = "";
        }
    }
}
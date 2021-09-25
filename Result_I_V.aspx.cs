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

public partial class Result_I_V : DBUtility
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



                GetData();
                //FillSTD();

                //submitdata.Visible = false;

                Teacher_Students();

                geturl();


                if ((Convert.ToString(Session["strUserType"]) == "3"))
                {
                    FillSTD();
                    ddlSTD.SelectedValue = Convert.ToString(Session["Standard_id"]);
                    FillDIV();

                    ddlDIV.SelectedValue = Convert.ToString(Session["Division_id"]);
                    //ddlGender.SelectedValue = Convert.ToString(Session["Gender"]);

                    ddlSTD.Enabled = false;
                    //ddlGender.Enabled = false;

                    ddlDIV.Enabled = false;
                    FillStudent();
                    FillExam();
                }

            }
        }
        else
        {
            Response.Redirect("Index.aspx", false);
        }
    }

    public DataSet GetData()
    {
        try
        {
            if (ddlStudent.SelectedValue != "")
            {
                strQry = "exec usp_getAttendance @type='getStudentCalenderAtt',@intStudentId=" + Convert.ToString(ddlStudent.SelectedValue) + ",@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                Session["Table"] = dsObj;

            }
            return dsObj;
        }
        catch (Exception)
        {
            return dsObj;
        }

    }

    public DataSet GetDataEnglishActivity()
    {
        try
        {
            if (ddlStudent.SelectedValue != "")
            {
                //strQry = "exec usp_getAttendance @type='getStudentCalenderAtt',@intStudentId=" + Convert.ToString(ddlStudent.SelectedValue) + ",@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                strQry = "exec usp_ExamMarks @type='EnglishActivityMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "'";
                dsObj = sGetDataset(strQry);

                Session["Table"] = dsObj;

            }
            return dsObj;
        }
        catch (Exception)
        {
            return dsObj;
        }

    }

    protected void Linkbtndepositamt_Click(object sender, EventArgs e)
    {
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
                FillExam();


            }
            else if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
                FillDIV();
                FillExam();
                // SetInitialRow();
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
            FillExam();
            //FillSubject();
        }
        catch
        {

        }
    }
    public void FillExam()
    {
        try
        {

            strQry = "exec usp_ExamMarks @type='FillExaminationTypePrimary',@intSchool_id='" + Session["School_id"] + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
            sBindDropDownList(ddlExam, strQry, "ExamTypeName", "intExamType_id");
        }
        catch
        {

        }

    }


    public void Teacher_Students()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "3")
            {

                strQry = "exec usp_TimeTable @type='GetSTD_DIV',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intTeacher_id='" + Convert.ToString(Session["User_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    ddlSTD.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
                    // ddlSTD_SelectedIndexChanged(null, null);
                    FillDIV();
                    ddlDIV.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                    ddlSTD.Enabled = false;
                    ddlDIV.Enabled = false;
                    FillStudent();
                }
            }
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
       // ddlGender.ClearSelection();
        ddlExam.ClearSelection();
        FillDIV();
    }
    protected void ddlDIV_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlGender.ClearSelection();
        ddlExam.ClearSelection();
        FillStudent();
    }


    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlExam.ClearSelection();
        GridView3.DataSource = null;
        GridView3.DataBind();
        GridView4.DataSource = null;
        GridView4.DataBind();
    }

    protected void show_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlStudent.Text == "-1")
            {
                try
                {
                    DataSet dsObj = new DataSet();
                    string strQry = "";
                    strQry = "exec usp_FillDropDown @type='GetStudentsresult',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                    //strQry = "exec usp_ExamMarks @type='ExamMark_Halfall',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
                    //        dsObjgrade = sGetDataset(strQry);
                    dsObj = sGetDataset(strQry);
                    Session["rptAllStudentMark"] = dsObj;
                    Session["Exam_id"] = ddlExam.SelectedItem.ToString();
                    Session["Exam_idnum"] = ddlExam.SelectedValue.ToString();
                    Session["standard_id"] = ddlSTD.SelectedItem.ToString();
                    Session["standard_idnum"] = ddlSTD.SelectedValue.ToString();
                    Response.Redirect("rptResult_I_V.aspx", true);
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                strQry = "exec usp_FillDropDown @type='GetStudentresult',@StudentId='" + ddlStudent.SelectedValue.ToString() + "',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                //strQry = "exec usp_ExamMarks @type='ExamMark_PrimaryHalf',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
                //        dsObjgrade = sGetDataset(strQry);
                dsObj = sGetDataset(strQry);
                Session["rptAllStudentMark"] = dsObj;
                Session["Exam_id"] = ddlExam.SelectedItem.ToString();
                Session["Exam_idnum"] = ddlExam.SelectedValue.ToString();
                Session["standard_id"] = ddlSTD.SelectedItem.ToString();
                Session["standard_idnum"] = ddlSTD.SelectedValue.ToString();
                Response.Redirect("rptResult_I_V.aspx", true);

        }

        }
        catch
        {
            CrystalReportViewer1.ReportSource = crystalReport;
            CrystalReportViewer1.DataBind();
            CrystalReportViewer1.RefreshReport();

        }

    }

    protected void Img1_Click(object sender, EventArgs e)
    {
        string reportPath = Server.MapPath("Result_I_V.rpt");
        crystalReport.Load(reportPath);

        TextObject name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text130"];
        TextObject class1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text2"];
        TextObject sec = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text131"];
        TextObject rollno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text128"];
        TextObject mothername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text133"];
        TextObject fathername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text134"];
        TextObject birthdate = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text132"];
        TextObject Address = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text135"];
        TextObject PhoneNo = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text136"];
        TextObject session = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text259"];
        TextObject ExamName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text257"];

        TextObject reportname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text8"];
        session.Text = Convert.ToString(Session["YearName"]);
        ExamName.Text = ddlExam.SelectedItem.ToString().ToUpper();
        //reportname.Text = "REPORT CARD FOR " + ddlSTD.SelectedItem.ToString().ToUpper();
        class1.Text = ddlSTD.SelectedItem.ToString().ToUpper();
        TextObject SUBEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text33"];
        TextObject SUBHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text34"];
        TextObject SUBmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text35"];
        TextObject SUBsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text36"];
        TextObject SUBSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text37"];
        TextObject SUBEvs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text38"];
        TextObject SUBLHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text10"];
        TextObject SUBComp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text261"];
        TextObject SUBEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text262"];

        TextObject Eng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text139"];
        TextObject HindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text140"];
        TextObject math = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text141"];
        TextObject sci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text142"];
        TextObject Sosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text143"];
        TextObject Evs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text144"];
        TextObject LHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text145"];
        TextObject Comp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text263"];
        TextObject EVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text264"];

        TextObject NBEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text146"];
        TextObject NBHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text147"];
        TextObject NBmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text148"];
        TextObject NBsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text149"];
        TextObject NBSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text150"];
        TextObject NBEvs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text151"];
        TextObject NBLHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text152"];
        TextObject NBComp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text265"];
        TextObject NBEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text266"];

        TextObject SEEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text153"];
        TextObject SEHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text154"];
        TextObject SEmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text155"];
        TextObject SEsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text156"];
        TextObject SESosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text157"];
        TextObject SEEvs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text158"];
        TextObject SELHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text159"];
        TextObject SEComp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text267"];
        TextObject SEEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text268"];

        TextObject HYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text160"];
        TextObject HYHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text161"];
        TextObject HYmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text162"];
        TextObject HYsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text163"];
        TextObject HYSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text164"];
        TextObject HYEvs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text165"];
        TextObject HYLHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text166"];
        TextObject HYComp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text269"];
        TextObject HYEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text270"];

        TextObject MOEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text167"];
        TextObject MOHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text168"];
        TextObject MOmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text169"];
        TextObject MOsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text170"];
        TextObject MOSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text171"];
        TextObject MOEvs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text172"];
        TextObject MOLHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text173"];
        TextObject MOComp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text271"];
        TextObject MOEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text272"];

        TextObject GREng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text174"];
        TextObject GRHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text175"];
        TextObject GRmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text176"];
        TextObject GRsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text177"];
        TextObject GRSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text178"];
        TextObject GREvs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text179"];
        TextObject GRLHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text180"];
        TextObject GRComp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text273"];
        TextObject GREVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text274"];

        TextObject SUBWEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text78"];
        TextObject SUBAEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text79"];
        TextObject SUBHPEEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text80"];
        TextObject SUBLSActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text82"];
        TextObject SUBDHActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text7"];
        TextObject SUBMUActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text29"];
        TextObject SUBPTActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text30"];

        TextObject WEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text223"];
        TextObject AEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text224"];
        TextObject HPEEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text225"];
        TextObject LSActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text226"];
        TextObject DHActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text227"];
        TextObject MUActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text228"];
        TextObject PTActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text229"];

        TextObject SUBRPElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text87"];
        TextObject SUBSIElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text88"];
        TextObject SUBBVElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text89"];
        TextObject SUBRRRElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text90"];
        TextObject SUBATElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text91"];
        TextObject SUBATSElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text92"];
        TextObject SUBASElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text95"];
        TextObject SUBATNElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text94"];

        TextObject RPElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text237"];
        TextObject SIElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text238"];
        TextObject BVElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text239"];
        TextObject RRRElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text240"];
        TextObject ATElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text241"];
        TextObject ATSElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text242"];
        TextObject ASElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text243"];
        TextObject ATNElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text244"];

        TextObject Suggestion = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text254"];
        TextObject AreaofStrength = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text5"];

        TextObject totaldays = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text138"];
        TextObject PresentDay = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text137"];
        TextObject StudentId = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text129"];

        strQry = "Execute dbo.usp_Profile @command='attendance' ,@intStudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            //totaldays.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalDay"]);
            PresentDay.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
        }


        strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intStudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
        //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            name.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
            mothername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
            fathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
            fathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
            birthdate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
            rollno.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);
            Address.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpresentAddress"]);
            PhoneNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intHomePhoneNo1"]);
            //class1.Text = ddlSTD.SelectedItem.ToString();
            sec.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
            StudentId.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudentID_Number"]);
        }

        strQry = "exec usp_ExamMarks @type='ExamMark_Half',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
        dsObjgrade = sGetDataset(strQry);
        if (dsObjgrade.Tables[0].Rows.Count > 0)
        {
            try
            {
                SUBEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["vchsubjectname"]);
            }
            catch
            {

            }
            try
            {
                SUBHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["vchsubjectname"]);
            }
            catch
            {

            }
            try
            {
                SUBmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["vchsubjectname"]);
            }
            catch
            {

            }
            try
            {
                SUBsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["vchsubjectname"]);
            }
            catch
            {

            }
            try
            {
                SUBSosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["vchsubjectname"]);
            }
            catch
            {

            }
            try
            {
                SUBEvs.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["vchsubjectname"]);
            }
            catch
            {

            }
            try
            {
                SUBLHLB.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["vchsubjectname"]);
            }
            catch
            {

            }
            try
            {
                SUBComp.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["vchsubjectname"]);
            }
            catch
            {

            }
            try
            {
                SUBEVS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["vchsubjectname"]);
            }
            catch
            {

            }
            try
            {

                Eng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["UTI"]);
            }
            catch
            {

            }
            try
            {
                HindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["UTI"]);
            }
            catch
            {

            }
            try
            {
                math.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["UTI"]);
            }
            catch
            {

            }
            try
            {
                sci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["UTI"]);
            }
            catch
            {

            }
            try
            {
                Sosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["UTI"]);
            }
            catch
            {

            }
            try
            {
                Evs.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["UTI"]);
            }
            catch
            {

            }
            try
            {
                LHLB.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["UTI"]);
            }
            catch
            {

            }
            try
            {
                Comp.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["UTI"]);
            }
            catch
            {

            }
            try
            {
                EVS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["UTI"]);
            }
            catch
            {

            }
            try
            {





                NBEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Note Book"]);
            }
            catch
            {

            }
            try
            {
                NBHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Note Book"]);
            }
            catch
            {

            }
            try
            {
                NBmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Note Book"]);
            }
            catch
            {

            }
            try
            {
                NBsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Note Book"]);
            }
            catch
            {

            }
            try
            {
                NBSosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Note Book"]);
            }
            catch
            {

            }
            try
            {
                NBEvs.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Note Book"]);
            }
            catch
            {

            }
            try
            {
                NBLHLB.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["Note Book"]);
            }
            catch
            {

            }
            try
            {
                NBComp.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["Note Book"]);
            }
            catch
            {

            }
            try
            {
                NBEVS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["Note Book"]);
            }
            catch
            {

            }
            try
            {



                SEEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Sub Enrichment"]);
            }
            catch
            {

            }
            try
            {
                SEHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Sub Enrichment"]);
            }
            catch
            {

            }
            try
            {
                SEmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Sub Enrichment"]);
            }
            catch
            {

            }
            try
            {
                SEsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Sub Enrichment"]);
            }
            catch
            {

            }
            try
            {
                SESosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Sub Enrichment"]);
            }
            catch
            {

            }
            try
            {
                SEEvs.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Sub Enrichment"]);
            }
            catch
            {

            }
            try
            {
                SELHLB.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["Sub Enrichment"]);
            }
            catch
            {

            }
            try
            {
                SEComp.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["Sub Enrichment"]);
            }
            catch
            {

            }
            try
            {
                SEEVS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["Sub Enrichment"]);
            }
            catch
            {

            }
            try
            {



                HYEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Half Yearly Exam"]);
            }
            catch
            {

            }
            try
            {
                HYHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Half Yearly Exam"]);
            }
            catch
            {

            }
            try
            {
                HYmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Half Yearly Exam"]);
            }
            catch
            {

            }
            try
            {
                HYsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Half Yearly Exam"]);
            }
            catch
            {

            }
            try
            {
                HYSosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Half Yearly Exam"]);
            }
            catch
            {

            }
            try
            {
                HYEvs.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Half Yearly Exam"]);
            }
            catch
            {

            }
            try
            {
                HYLHLB.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["Half Yearly Exam"]);
            }
            catch
            {

            }
            try
            {
                HYComp.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["Half Yearly Exam"]);
            }
            catch
            {

            }
            try
            {
                HYEVS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["Half Yearly Exam"]);
            }
            catch
            {

            }
            try
            {



                MOEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Total"]);
            }
            catch
            {

            }
            try
            {
                MOHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Total"]);
            }
            catch
            {

            }
            try
            {
                MOmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Total"]);
            }
            catch
            {

            }
            try
            {
                MOsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Total"]);
            }
            catch
            {

            }
            try
            {
                MOSosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Total"]);
            }
            catch
            {

            }
            try
            {
                MOEvs.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Total"]);
            }
            catch
            {

            }
            try
            {
                MOLHLB.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["Total"]);
            }
            catch
            {

            }
            try
            {
                MOComp.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["Total"]);
            }
            catch
            {

            }
            try
            {
                MOEVS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["Total"]);
            }
            catch
            {

            }
            try
            {


                GREng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Grade"]);
            }
            catch
            {

            }
            try
            {
                GRHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Grade"]);
            }
            catch
            {

            }
            try
            {
                GRmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Grade"]);
            }
            catch
            {

            }
            try
            {
                GRsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Grade"]);
            }
            catch
            {

            }
            try
            {
                GRSosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Grade"]);
            }
            catch
            {

            }
            try
            {
                GREvs.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Grade"]);
            }
            catch
            {

            }
            try
            {
                GRLHLB.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["Grade"]);
            }
            catch
            {

            }
            try
            {
                GRComp.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["Grade"]);
            }
            catch
            {

            }
            try
            {
                GREVS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["Grade"]);
            }
            catch { }
        }

        strQry = "exec usp_ExamMarks @type='ActivityGrade',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            try
            {
                WEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
            }
            catch
            {

            }
            try
            {
                AEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
            }
            catch
            {

            }
            try
            {
                HPEEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
            }
            catch
            {

            }
            try
            {
                LSActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
            }
            catch
            {

            }
            try
            {
                DHActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);
            }
            catch
            {

            }
            try
            {
                MUActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["GRADE"]);
            }
            catch
            {

            }
            try
            {
                PTActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["GRADE"]);
            }
            catch
            { 
            
            }
            try
            {
            SUBWEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchName"]);
                }
            catch
            { 
            
            }
            try
            {
            SUBAEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["VchName"]);
                }
            catch
            { 
            
            }
            try
            {
            SUBHPEEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["VchName"]);
                }
            catch
            { 
            
            }
            try
            {
            SUBLSActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["VchName"]);
                }
            catch
            { 
            
            }
            try
            {
            SUBDHActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["VchName"]);
                }
            catch
            { 
            
            }
            try
            {
            SUBMUActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["VchName"]);
                }
            catch
            { 
            
            }
            try
            {
                SUBPTActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["VchName"]);
            }
            catch { }
        }

        strQry = "exec usp_ExamMarks @type='ElementGrade',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            try
            {
                RPElements.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
            }
            catch
            {

            }
            try
            {
                SIElements.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
            }
            catch
            {

            }
            try
            {
                BVElements.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
            }
            catch
            {

            }
            try
            {
                RRRElements.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
            }
            catch
            {

            }
            try
            {
                ATElements.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);
            }
            catch
            {

            }
            try
            {
                ATSElements.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["GRADE"]);
            }
            catch
            {

            }
            try
            {
                ASElements.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["GRADE"]);
            }
            catch
            {

            }
            try
            {
                ATNElements.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["GRADE"]);
            }
            catch { }
            try
            {
                SUBRPElements.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchName"]);
            }
            catch
            {

            }
            try
            {
                SUBSIElements.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["VchName"]);
            }
            catch
            {

            }
            try
            {
                SUBBVElements.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["VchName"]);
            }
            catch
            {

            }
            try
            {
                SUBRRRElements.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["VchName"]);
            }
            catch
            {

            }
            try
            {
                SUBATElements.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["VchName"]);
            }
            catch
            {

            }
            try
            {
                SUBATSElements.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["VchName"]);
            }
            catch
            {

            }
            try
            {
                SUBASElements.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["VchName"]);
            }
            catch
            {

            }
            try
            {
                SUBATNElements.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["VchName"]);
            }
            catch { }
        }

        try
        {
            //strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "'";
            strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "' and intAttendance=2 and intExam_id in(select intExam_id from tblExaminationDet where vchExamination_name like 'half%') "; 
            string remark = sExecuteReader(strQry);
            Suggestion.Text = remark;
        }
        catch {
            //crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "'" + ddlStudent.SelectedItem + "'");
            //Response.End();
        }

        try
        {
            //strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "'";
            strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "' and intAttendance=1 and intExam_id in(select intExam_id from tblExaminationDet where vchExamination_name like 'half%') ";
            string area = sExecuteReader(strQry);
            AreaofStrength.Text = area;
        }
        catch
        {
            //crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "'" + ddlStudent.SelectedItem + "'");
            //Response.End();
        }

        crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "'" + ddlStudent.SelectedItem + "'");
        Response.End();
    }
}
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

public partial class Result_VI_VIII : DBUtility
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
       // ddlGender.ClearSelection();
        ddlExam.ClearSelection();
        FillStudent();
    }
    //protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ddlExam.ClearSelection();
    //    FillStudent();
    //}

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
                    Response.Redirect("rptResult_VI-VIII.aspx", true);
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
                Response.Redirect("rptResult_VI-VIII.aspx", true);


        }

        }
        catch
        {

        }

    }

    protected void Img1_Click(object sender, EventArgs e)
    {
        string reportPath = Server.MapPath("Result_VI-VIII.rpt");
        crystalReport.Load(reportPath);

        TextObject name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text99"];
        //TextObject class1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text54"];
        TextObject sec = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text103"];
        TextObject rollno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text98"];
        TextObject mothername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text101"];
        TextObject fathername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text102"];
        TextObject birthdate = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text100"];
        TextObject session = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text73"];
        TextObject ExamName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text235"];
        TextObject reportname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text8"];


        session.Text = Convert.ToString(Session["YearName"]);
        ExamName.Text = ddlExam.SelectedItem.ToString().ToUpper();
        reportname.Text = "REPORT CARD FOR " + ddlSTD.SelectedItem.ToString().ToUpper();

        TextObject SUBlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text24"];
        TextObject SUBlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text25"];
        TextObject SUBlang3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text26"];
        TextObject SUBmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text27"];
        TextObject SUBsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text28"];
        TextObject SUBSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text29"];
        TextObject SUBgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text74"];
        TextObject SUBEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text30"];
        TextObject SUBLS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text75"];
        TextObject SUBVPA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text77"];

        TextObject lang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text104"];
        TextObject lang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text105"];
        TextObject lang3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text106"];
        TextObject math = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text107"];
        TextObject sci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text108"];
        TextObject Sosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text109"];
        TextObject general = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text110"];
        TextObject EVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text79"];
        TextObject LS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text80"];
        TextObject VPA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];



        TextObject NBlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text111"];
        TextObject NBlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text112"];
        TextObject NBlang3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text113"];
        TextObject NBmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text114"];
        TextObject NBsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text115"];
        TextObject NBSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text116"];
        TextObject NBgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text117"];
        TextObject NBEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text87"];
        TextObject NBLS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text200"];
        TextObject NBVPA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text204"];


        TextObject SElang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text118"];
        TextObject SElang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text119"];
        TextObject SElang3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text120"];
        TextObject SEmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text121"];
        TextObject SEsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text122"];
        TextObject SESosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text123"];
        TextObject SEgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text124"];
        TextObject SEEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text205"];
        TextObject SELS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text206"];
        TextObject SEVPA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text207"];


        TextObject HYlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text125"];
        TextObject HYlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text126"];
        TextObject HYlang3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text127"];
        TextObject HYmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text128"];
        TextObject HYsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text129"];
        TextObject HYSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text130"];
        TextObject HYgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text131"];
        TextObject HYEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text208"];
        TextObject HYLS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text209"];
        TextObject HYVPA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text210"];

        TextObject totlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text132"];
        TextObject totlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text133"];
        TextObject totlang3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text134"];
        TextObject totmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text135"];
        TextObject totsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text136"];
        TextObject totSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text137"];
        TextObject totgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text138"];
        TextObject totEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text211"];
        TextObject totLS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text212"];
        TextObject totVPA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text213"];

        TextObject grlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text139"];
        TextObject grlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text140"];
        TextObject grlang3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text141"];
        TextObject grmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text142"];
        TextObject grsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text143"];
        TextObject grSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text144"];
        TextObject grgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text145"];
        TextObject grEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text214"];
        TextObject grLS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text215"];
        TextObject grVPA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text216"];

        //TextObject WECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text188"];
        TextObject AECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text190"];
        TextObject HPECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text192"];
        
        TextObject SUBAECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text40"];
        TextObject SUBHPECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text41"];
        
        TextObject DisciplineTerm1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text194"];
        TextObject Suggestion = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text196"];

        TextObject totaldays = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text138"];
        TextObject PresentDay = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text202"];

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

            //class1.Text = ddlSTD.SelectedItem.ToString();
            sec.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
        }

        strQry = "exec usp_ExamMarks @type='ExamMark_Half',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
        dsObjgrade = sGetDataset(strQry);
        if (dsObjgrade.Tables[0].Rows.Count > 0)
        {
            try
            {
                SUBlang1.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["vchsubjectname"]);
            }
            catch
            { }
            try
            {
                SUBlang2.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["vchsubjectname"]);
            }
            catch
            { }
            try
            {
                SUBlang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["vchsubjectname"]);
            }
            catch
            { }
            try
            {
                SUBmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["vchsubjectname"]);
            }
            catch
            { }
            try
            {
                SUBsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["vchsubjectname"]);
            }
            catch
            { }
            try
            {
                SUBSosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["vchsubjectname"]);
            }
            catch
            { }
            try
            {
                SUBEVS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["vchsubjectname"]);
            }
            catch
            { }
            try
            {
                SUBgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["vchsubjectname"]);
            }
            catch
            { }
            try
            {
                SUBLS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["vchsubjectname"]);
            }
            catch
            { }
            try
            {
                SUBVPA.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[9]["vchsubjectname"]);
            }
            catch
            { }
            try
            {

                lang1.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["UTI"]);
            }
            catch
            { }
            try
            {
                lang2.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["UTI"]);
            }
            catch
            { }
            try
            {
                lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["UTI"]);
            }
            catch
            { }
            try
            {
                math.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["UTI"]);
            }
            catch
            { }
            try
            {
                sci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["UTI"]);
            }
            catch
            { }
            try
            {
                Sosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["UTI"]);
            }
            catch
            { }
            try
            {
                EVS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["UTI"]);
            }
            catch
            { }
            try
            {
                general.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["UTI"]);
            }
            catch
            { }
            try
            {
                LS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["UTI"]);
            }
            catch
            { }
            try
            {
                VPA.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[9]["UTI"]);
            }
            catch
            { }
            try
            {




                NBlang1.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Note Book"]);
            }
            catch
            { }
            try
            {
                NBlang2.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Note Book"]);
            }
            catch
            { }
            try
            {
                NBlang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Note Book"]);
            }
            catch
            { }
            try
            {
                NBmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Note Book"]);
            }
            catch
            { }
            try
            {
                NBsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Note Book"]);
            }
            catch
            { }
            try
            {
                NBSosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Note Book"]);
            }
            catch
            { }
            try
            {
                NBEVS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["Note Book"]);
            }
            catch
            { }
            try
            {
                NBgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["Note Book"]);
            }
            catch
            { }
            try
            {
                NBLS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["Note Book"]);
            }
            catch
            { }
            try
            {
                NBVPA.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[9]["Note Book"]);
            }
            catch
            { }
            try
            {

                SElang1.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Sub Enrichment"]);
            }
            catch
            { }
            try
            {
                SElang2.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Sub Enrichment"]);
            }
            catch
            { }
            try
            {
                SElang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Sub Enrichment"]);
            }
            catch
            { }
            try
            {
                SEmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Sub Enrichment"]);
            }
            catch
            { }
            try
            {
                SEsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Sub Enrichment"]);
            }
            catch
            { }
            try
            {
                SESosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Sub Enrichment"]);
            }
            catch
            { }
            try
            {
                SEEVS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["Sub Enrichment"]);
            }
            catch
            { }
            try
            {
                SEgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["Sub Enrichment"]);
            }
            catch
            { }
            try
            {
                SELS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["Sub Enrichment"]);
            }
            catch
            { }
            try
            {
                SEVPA.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[9]["Sub Enrichment"]);
            }
            catch
            { }
            try
            {

                HYlang1.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Half Yearly Exam"]);
            }
            catch
            { }
            try
            {
                HYlang2.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Half Yearly Exam"]);
            }
            catch
            { }
            try
            {
                HYlang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Half Yearly Exam"]);
            }
            catch
            { }
            try
            {
                HYmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Half Yearly Exam"]);
            }
            catch
            { }
            try
            {
                HYsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Half Yearly Exam"]);
            }
            catch
            { }
            try
            {
                HYSosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Half Yearly Exam"]);
            }
            catch
            { }
            try
            {
                HYEVS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["Half Yearly Exam"]);
            }
            catch
            { }
            try
            {
                HYgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["Half Yearly Exam"]);
            }
            catch
            { }
            try
            {
                HYLS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["Half Yearly Exam"]);
            }
            catch
            { }
            try
            {
                HYVPA.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[9]["Half Yearly Exam"]);
            }
            catch
            { }
            try
            {

                totlang1.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Total"]);
            }
            catch
            { }
            try
            {
                totlang2.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Total"]);
            }
            catch
            { }
            try
            {
                totlang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Total"]);
            }
            catch
            { }
            try
            {
                totmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Total"]);
            }
            catch
            { }
            try
            {
                totsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Total"]);
            }
            catch
            { }
            try
            {
                totSosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Total"]);
            }
            catch
            { }
            try
            {
                totEVS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["Total"]);
            }
            catch
            { }
            try
            {
                totgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["Total"]);
            }
            catch
            { }
            try
            {
                totLS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["Total"]);
            }
            catch
            { }
            try
            {
                totVPA.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[9]["Total"]);
            }
            catch
            { }
            try
            {

                grlang1.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Grade"]);
            }
            catch
            { }
            try
            {
                grlang2.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Grade"]);
            }
            catch
            { }
            try
            {
                grlang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Grade"]);
            }
            catch
            { }
            try
            {
                grmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Grade"]);
            }
            catch
            { }
            try
            {
                grsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Grade"]);
            }
            catch
            { }
            try
            {
                grSosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Grade"]);
            }
            catch
            { }
            try
            {
                grEVS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["Grade"]);
            }
            catch
            { }
            try
            {
                grgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["Grade"]);
            }
            catch
            { }
            try
            {
                grLS.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["Grade"]);
            }
            catch
            { }
            try
            {
                grVPA.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[9]["Grade"]);
            }
            catch { }

        }

        try
        {
            strQry = "exec usp_ExamMarks @type='CoscholasticGrade',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                SUBAECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchName"]);
                SUBHPECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["VchName"]);
                //WECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                AECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                HPECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);

            }
        }
        catch
        { }

        try
        {

            strQry = "exec usp_ExamMarks @type='DisciplineGrade',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                DisciplineTerm1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);

            }
        }
        catch { }

        try
        {

            strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "'";
            string remark = sExecuteReader(strQry);
            Suggestion.Text = remark;
        }
        catch
        { }

        crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "'" + ddlStudent.SelectedItem + "'");
        Response.End();
    }
}
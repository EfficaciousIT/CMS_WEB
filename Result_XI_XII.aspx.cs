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

public partial class Result_XI_XII : DBUtility
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

    protected void show_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlStudent.Text == "-1")
            {
                if (ddlExam.SelectedItem.Text == "Term-1")
                {
                    try
                    {
                        DataSet dsObj = new DataSet();
                        string strQry = "";
                        //strQry = "Execute dbo.usp_Profile @command='EnquiryStudents1',@intStudent_id='" + Convert.ToString(Session["intForm_id"]) + "'";// ,@intStudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
                        //strQry = "exec usp_SchoolFeeCollection @type='FillStandardWiseGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
                        //strQry = "exec usp_ExamMarks @type='ResultXIall',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";

                        strQry = "exec usp_FillDropDown @type='GetStudentsresult',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";

                        dsObjgrade = sGetDataset(strQry);
                        //dsObj = sGetDataset(strQry);
                        Session["rptAllStudentMark"] = dsObjgrade;
                        Session["Exam_id"] = ddlExam.SelectedItem.ToString();
                        Session["Exam_idnum"] = ddlExam.SelectedValue.ToString();
                        Session["standard_id"] = ddlSTD.SelectedItem.ToString();
                        Session["standard_idnum"] = ddlSTD.SelectedValue.ToString();
                        //Response.Redirect("rptResult_XI_XII.aspx", true);
                        if (Convert.ToInt32(Session["AcademicID"]) <= 3)
                        {
                            Response.Redirect("rptResult_XI_XII.aspx", true);
                        }
                        else
                        {
                            Response.Redirect("rptResult_XI_XIINew.aspx", true);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {

                    DataSet dsObj = new DataSet();
                    string strQry = "";
                    //strQry = "Execute dbo.usp_Profile @command='EnquiryStudents1',@intStudent_id='" + Convert.ToString(Session["intForm_id"]) + "'";// ,@intStudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
                    //strQry = "exec usp_SchoolFeeCollection @type='FillStandardWiseGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
                    //strQry = "exec usp_ExamMarks @type='ResultXIall',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";

                    strQry = "exec usp_FillDropDown @type='GetStudentsresult',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";

                    dsObjgrade = sGetDataset(strQry);
                    //dsObj = sGetDataset(strQry);
                    Session["rptAllStudentMark"] = dsObjgrade;
                    Session["Exam_id"] = ddlExam.SelectedItem.ToString();
                    Session["Exam_idnum"] = ddlExam.SelectedValue.ToString();
                    Session["standard_id"] = ddlSTD.SelectedItem.ToString();
                    Session["standard_idnum"] = ddlSTD.SelectedValue.ToString();
                    //Response.Redirect("rptResult_XI_XII_annual.aspx", true);
                    if (Convert.ToInt32(Session["AcademicID"]) <= 3)
                    {
                        //Response.Redirect("rptResult_XI_XII.aspx", true);
                        Response.Redirect("rptResult_XI_XII_annual.aspx", true);
                    }
                    else
                    {
                        //Response.Redirect("rptResult_XI_XIINew.aspx", true);
                        Response.Redirect("rptResult_XI_XII_annual.aspx", true);
                    }
                }

            }
            else
            {
                if (ddlExam.SelectedItem.Text == "Term-1")
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
                   // Response.Redirect("rptResult_XI_XII.aspx", true);
                    if (Convert.ToInt32(Session["AcademicID"]) <= 3)
                    {
                        Response.Redirect("rptResult_XI_XII.aspx", true);
                    }
                    else
                    {
                        Response.Redirect("rptResult_XI_XIINew.aspx", true);
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
                  //  Response.Redirect("rptResult_XI_XII_annual.aspx", true);
                    if (Convert.ToInt32(Session["AcademicID"]) <= 3)
                    {
                       // Response.Redirect("rptResult_XI_XII.aspx", true);
                        Response.Redirect("rptResult_XI_XII_annual.aspx", true);
                    }
                    else
                    {
                        //Response.Redirect("rptResult_XI_XIINew.aspx", true);
                        Response.Redirect("rptResult_XI_XII_annual.aspx", true);
                    }

                }

        }

        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

    }

   protected void Img1_Click(object sender, EventArgs e)
    {
        try
        {

             if (ddlExam.SelectedItem.Text == "Term-1")
            {

                if (ddlSTD.SelectedItem.Text == "XI Sc"  || ddlSTD.SelectedItem.Text == "XI Com"  || ddlSTD.SelectedItem.Text == "XI Arts" )
                {
                string reportPath = Server.MapPath("Result_XI_XII_FirstTerm.rpt");
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
                TextObject totaldays = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text72"];
                TextObject PresentDay = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text202"];

                strQry = "Execute dbo.usp_Profile @command='attendance' ,@intStudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    //totaldays.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalDay"]);
                    PresentDay.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
                }

                session.Text = Convert.ToString(Session["YearName"]);
                ExamName.Text = ddlExam.SelectedItem.ToString().ToUpper();
                reportname.Text = "REPORT CARD FOR " + ddlSTD.SelectedItem.ToString().ToUpper();

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

                TextObject SUBEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text20"];
                TextObject SUBHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text21"];
                TextObject SUBPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text22"];
                TextObject SUBChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text23"];
                TextObject SUBBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text24"];
                TextObject SUBCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text25"];
                TextObject SUBMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text26"];
                TextObject SUBPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text27"];
                TextObject SUBCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text28"];


                //TextObject UTEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text104"];
                //TextObject UTHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text106"];
                //TextObject UTPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text107"];
               // TextObject UTChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text109"];
               // TextObject UTBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text111"];
               // TextObject UTCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text113"];
               // TextObject UTMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text115"];
              //  TextObject UTPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text116"];
               // TextObject UTCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text118"];

                TextObject HYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text121"];
                TextObject HYHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text123"];
                TextObject HYPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text124"];
                TextObject HYChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text126"];
                TextObject HYBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text129"];
                TextObject HYCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text131"];
                TextObject HYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text133"];
                TextObject HYPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text134"];
                TextObject HYCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text136"];

                TextObject PRHYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text122"];
                //TextObject PRHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text123"];
                TextObject PRHYPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text125"];
                TextObject PRHYChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text127"];
                TextObject PRHYBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text130"];
                TextObject PRHYCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text132"];
                //TextObject PRMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text133"];
                TextObject PRHYPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text135"];
                TextObject PRHYCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text137"];

                //TextObject UTITOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text120"];
                TextObject HYTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];

                string HYEngstring = "";
                string HYHindiBengalistring = "";
                string HYPhysicsstring = "";
                string HYChemistrystring = "";
                string HYBiologystring = "";
                string HYCompScistring = "";
                string HYMathstring = "";
                string HYPhysicalEdustring = "";
                string HYCommercialArtstring = "";

                string PRHYEngstring = "";
                string PRHYPhysicsstring = "";
                string PRHYChemistrystring = "";
                string PRHYBiologystring = "";
                string PRHYCompScistring = "";
                string PRHYPhysicalEdustring = "";
                string PRHYCommercialArtstring = "";

                strQry = "exec usp_ExamMarks @type='ResultXI',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
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
                        SUBPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["vchsubjectname"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        SUBChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["vchsubjectname"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        SUBBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["vchsubjectname"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        SUBCompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["vchsubjectname"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        SUBMath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["vchsubjectname"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        SUBPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["vchsubjectname"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        SUBCommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["vchsubjectname"]);
                    }
                    catch
                    {
                    }

                    //try
                    //{
                    //    UTEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["UTI"]);
                    //}
                    //catch
                    //{
                    //}
                    //try
                    //{
                    //    UTHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["UTI"]);
                    //}
                    //catch
                    //{
                    //}
                    //try
                    //{
                    //    UTPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["UTI"]);
                    //}
                    //catch
                    //{
                    //}
                    //try
                    //{
                    //    UTChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["UTI"]);
                    //}
                    //catch
                    //{
                    //}
                    //try
                    //{
                    //    UTBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["UTI"]);
                    //}
                    //catch
                    //{
                    //}
                    //try
                    //{
                    //    UTCompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["UTI"]);
                    //}
                    //catch
                    //{
                    //}
                    //try
                    //{
                    //    UTMath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["UTI"]);
                    //}
                    //catch
                    //{
                    //}
                    //try
                    //{
                    //    UTPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["UTI"]);
                    //}
                    //catch
                    //{
                    //}
                    //try
                    //{
                    //    UTCommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["UTI"]);
                    //}
                    //catch
                    //{
                    //}
                    try
                    {
                        HYEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Half Yearly"]);
                        if (HYEng.Text == "NA")
                        {
                            HYEngstring = "0";
                        }
                        else
                        {
                            HYEngstring = HYEng.Text;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        HYHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Half Yearly"]);
                        if (HYHindiBengali.Text == "NA")
                        {
                            HYHindiBengalistring = "0";
                        }
                        else
                        {
                            HYHindiBengalistring = HYHindiBengali.Text;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        HYPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Half Yearly"]);
                        if (HYPhysics.Text == "NA")
                        {
                            HYPhysicsstring = "0";
                        }
                        else
                        {
                            HYPhysicsstring = HYPhysics.Text;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        HYChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Half Yearly"]);
                        if (HYChemistry.Text == "NA")
                        {
                            HYChemistrystring = "0";
                        }
                        else
                        {
                            HYChemistrystring = HYChemistry.Text;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        HYBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Half Yearly"]);
                        if (HYBiology.Text == "NA")
                        {
                            HYBiologystring = "0";
                        }
                        else
                        {
                            HYBiologystring = HYBiology.Text;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        HYCompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Half Yearly"]);
                        if (HYCompSci.Text == "NA")
                        {
                            HYCompScistring = "0";
                        }
                        else
                        {
                            HYCompScistring = HYCompSci.Text;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        HYMath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["Half Yearly"]);
                        if (HYMath.Text == "NA")
                        {
                            HYMathstring = "0";

                        }
                        else
                        {
                            HYMathstring = HYMath.Text;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        HYPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["Half Yearly"]);
                        if (HYPhysicalEdu.Text == "NA")
                        {
                            HYPhysicalEdustring = "0";
                        }
                        else
                        {
                            HYPhysicalEdustring = HYPhysicalEdu.Text;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        HYCommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["Half Yearly"]);
                        if (HYCommercialArt.Text == "NA")
                        {
                            HYCommercialArtstring = "0";
                        }
                        else
                        {
                            HYCommercialArtstring = HYCommercialArt.Text;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {

                        PRHYEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["HYPractical"]);
                        if (PRHYEng.Text == "NA")
                        {
                            PRHYEngstring = "0";
                        }
                        else
                        {
                            PRHYEngstring = PRHYEng.Text;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        PRHYPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["HYPractical"]);
                        if (PRHYPhysics.Text == "NA")
                        {
                            PRHYPhysicsstring = "0";
                        }
                        else
                        {
                            PRHYPhysicsstring = PRHYPhysics.Text;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        PRHYChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["HYPractical"]);
                        if (PRHYChemistry.Text == "NA")
                        {
                            PRHYChemistrystring = "0";
                        }
                        else
                        {
                            PRHYChemistrystring = PRHYChemistry.Text;

                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        PRHYBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["HYPractical"]);
                        if (PRHYBiology.Text == "NA")
                        {
                            PRHYBiologystring = "0";
                        }
                        else
                        {
                            PRHYBiologystring = PRHYBiology.Text;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        PRHYCompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["HYPractical"]);
                        if (PRHYCompSci.Text == "NA")
                        {
                            PRHYCompScistring = "0";
                        }
                        else
                        {
                            PRHYCompScistring = PRHYCompSci.Text;

                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        PRHYPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["HYPractical"]);
                        if (PRHYPhysicalEdu.Text == "NA")
                        {
                            PRHYPhysicalEdustring = "0";
                        }
                        else
                        {

                            PRHYPhysicalEdustring = PRHYPhysicalEdu.Text;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        PRHYCommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["HYPractical"]);
                        if (PRHYCommercialArt.Text == "NA")
                        {
                            PRHYCommercialArtstring = "0";

                        }
                        else
                        {
                            PRHYCommercialArtstring = PRHYCommercialArt.Text;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        //UTITOT.Text = Convert.ToString(Convert.ToInt32(UTEng.Text) + Convert.ToInt32(UTHindiBengali.Text) + Convert.ToInt32(UTPhysics.Text) + Convert.ToInt32(UTChemistry.Text) + Convert.ToInt32(UTBiology.Text) + Convert.ToInt32(UTCompSci.Text) + Convert.ToInt32(UTMath.Text) + Convert.ToInt32(UTPhysicalEdu.Text) + Convert.ToInt32(UTCommercialArt.Text));
                        HYTOT.Text = Convert.ToString(Convert.ToInt32(HYEngstring) + Convert.ToInt32(HYPhysicsstring) + Convert.ToInt32(HYChemistrystring) + Convert.ToInt32(HYBiologystring) + Convert.ToInt32(HYCompScistring) + Convert.ToInt32(HYMathstring) + Convert.ToInt32(HYPhysicalEdustring) + Convert.ToInt32(HYCommercialArtstring) + Convert.ToInt32(PRHYEngstring) + Convert.ToInt32(HYHindiBengalistring) + Convert.ToInt32(PRHYPhysicsstring) + Convert.ToInt32(PRHYChemistrystring) + Convert.ToInt32(PRHYBiologystring) + Convert.ToInt32(PRHYCompScistring) + Convert.ToInt32(PRHYPhysicalEdustring) + Convert.ToInt32(PRHYCommercialArtstring));
                    }
                    catch
                    {
                    }


                }
                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "'" + ddlStudent.SelectedItem + "'");
                Response.End();
            }

            }
             if (ddlSTD.SelectedItem.Text == "XII Sc" || ddlSTD.SelectedItem.Text == "XII Com" || ddlSTD.SelectedItem.Text == "XII Arts")
             {

                 string reportPath = Server.MapPath("Result12th.rpt");
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

                 TextObject SUBEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text20"];
                 TextObject SUBHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text21"];
                 TextObject SUBPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text22"];
                 TextObject SUBChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text23"];
                 TextObject SUBBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text24"];
                 TextObject SUBCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text25"];
                 TextObject SUBMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text26"];
                 TextObject SUBPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text27"];
                 TextObject SUBCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text28"];

                 //TextObject AESUBEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text44"];
                 //TextObject AESUBHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text45"];
                 //TextObject AESUBPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text46"];
                 //TextObject AESUBChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text47"];
                 //TextObject AESUBBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text48"];
                 //TextObject AESUBCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text49"];
                 //TextObject AESUBMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text50"];
                 //TextObject AESUBPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text51"];
                 //TextObject AESUBCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text52"];


                 TextObject UTEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text104"];
                 TextObject UTHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text106"];
                 TextObject UTPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text107"];
                 TextObject UTChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text109"];
                 TextObject UTBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text111"];
                 TextObject UTCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text113"];
                 TextObject UTMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text115"];
                 TextObject UTPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text116"];
                 TextObject UTCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text118"];

                 //TextObject UTIIEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text139"];
                 //TextObject UTIIHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text142"];
                 //TextObject UTIIPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text141"];
                 //TextObject UTIIChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text144"];
                 //TextObject UTIIBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text146"];
                 //TextObject UTIICompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text148"];
                 //TextObject UTIIMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text150"];
                 //TextObject UTIIPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text151"];
                 //TextObject UTIICommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text153"];



                 //TextObject TPUTEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text155"];
                 //TextObject TPUTHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text157"];
                 //TextObject TPUTPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text158"];
                 //TextObject TPUTChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text160"];
                 //TextObject TPUTBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text162"];
                 //TextObject TPUTCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text164"];
                 //TextObject TPUTMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text166"];
                 //TextObject TPUTPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text167"];
                 //TextObject TPUTCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text169"];

                 TextObject HYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text121"];
                 TextObject HYHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text123"];
                 TextObject HYPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text124"];
                 TextObject HYChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text126"];
                 TextObject HYBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text129"];
                 TextObject HYCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text131"];
                 TextObject HYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text133"];
                 TextObject HYPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text134"];
                 TextObject HYCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text136"];

                 //TextObject TPHYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text171"];
                 //TextObject TPHYHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text173"];
                 //TextObject TPHYPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text174"];
                 //TextObject TPHYChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text176"];
                 //TextObject TPHYBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text178"];
                 //TextObject TPHYCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text180"];
                 //TextObject TPHYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text182"];
                 //TextObject TPHYPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text183"];
                 //TextObject TPHYCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text185"];

                 //TextObject AEEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text187"];
                 //TextObject AEHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text189"];
                 //TextObject AEPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text190"];
                 //TextObject AEChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text192"];
                 //TextObject AEBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text194"];
                 //TextObject AECompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text196"];
                 //TextObject AEMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text198"];
                 //TextObject AEPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text199"];
                 //TextObject AECommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text204"];

                 //TextObject FPAEEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text206"];
                 //TextObject FPAEHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text208"];
                 //TextObject FPAEPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text209"];
                 //TextObject FPAEChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text211"];
                 //TextObject FPAEBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text213"];
                 //TextObject FPAECompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text215"];
                 //TextObject FPAEMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text217"];
                 //TextObject FPAEPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text218"];
                 //TextObject FPAECommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text220"];


                 TextObject PRHYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text122"];
                 //TextObject PRHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text123"];
                 TextObject PRHYPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text125"];
                 TextObject PRHYChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text127"];
                 TextObject PRHYBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text130"];
                 TextObject PRHYCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text132"];
                 //TextObject PRMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text133"];
                 TextObject PRHYPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text135"];
                 TextObject PRHYCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text137"];


                 //TextObject PRAEEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text188"];
                 ////TextObject PRHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text123"];
                 //TextObject PRAEPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text191"];
                 //TextObject PRAEChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text193"];
                 //TextObject PRAEBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text195"];
                 //TextObject PRAECompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text197"];
                 ////TextObject PRMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text133"];
                 //TextObject PRAEPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text200"];
                 //TextObject PRAECommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text205"];

                 //TextObject FTOTEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text222"];
                 //TextObject FTOTHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text224"];
                 //TextObject FTOTPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text225"];
                 //TextObject FTOTChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text227"];
                 //TextObject FTOTBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text229"];
                 //TextObject FTOTCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text231"];
                 //TextObject FTOTMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text233"];
                 //TextObject FTOTPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text234"];
                 //TextObject FTOTCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text238"];

                 //TextObject UTITOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text120"];
                 //TextObject HYTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];
                 //TextObject UTIITOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text240"];
                 //TextObject TPUTTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text241"];
                 //TextObject TPHYTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text242"];
                 //TextObject AETOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text243"];
                 //TextObject FPAETOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text244"];
                 //TextObject FTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text245"];

                 TextObject UTITOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text120"];
                 TextObject HYTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];

                 string HYEngstring = "";
                 string HYHindiBengalistring = "";
                 string HYPhysicsstring = "";
                 string HYChemistrystring = "";
                 string HYBiologystring = "";
                 string HYCompScistring = "";
                 string HYMathstring = "";
                 string HYPhysicalEdustring = "";
                 string HYCommercialArtstring = "";

                 string UTEngstring = "";
                 string UTHindiBengalistring = "";
                 string UTPhysicsstring = "";
                 string UTChemistrystring = "";
                 string UTBiologystring = "";
                 string UTCompScistring = "";
                 string UTMathstring = "";
                 string UTPhysicalEdustring = "";
                 string UTCommercialArtstring = "";

                 string PRHYEngstring = "";
                 string PRHYPhysicsstring = "";
                 string PRHYChemistrystring = "";
                 string PRHYBiologystring = "";
                 string PRHYCompScistring = "";
                 string PRHYPhysicalEdustring = "";
                 string PRHYCommercialArtstring = "";


                 strQry = "exec usp_ExamMarks @type='ResultXI',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
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
                         SUBPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["vchsubjectname"]);
                     }
                     catch
                     {
                     }
                     try
                     {
                         SUBChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["vchsubjectname"]);
                     }
                     catch
                     {
                     }
                     try
                     {
                         SUBBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["vchsubjectname"]);
                     }
                     catch
                     {
                     }
                     try
                     {
                         SUBCompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["vchsubjectname"]);
                     }
                     catch
                     {
                     }
                     try
                     {
                         SUBMath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["vchsubjectname"]);
                     }
                     catch
                     {
                     }
                     try
                     {
                         SUBPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["vchsubjectname"]);
                     }
                     catch
                     {
                     }
                     try
                     {
                         SUBCommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["vchsubjectname"]);
                     }
                     catch { }

                     //AESUBEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["vchsubjectname"]);
                     //AESUBHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["vchsubjectname"]);
                     //AESUBPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["vchsubjectname"]);
                     //AESUBChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["vchsubjectname"]);
                     //AESUBBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["vchsubjectname"]);
                     //AESUBCompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["vchsubjectname"]);
                     //AESUBMath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["vchsubjectname"]);
                     //AESUBPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["vchsubjectname"]);
                     //AESUBCommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["vchsubjectname"]);
                     try
                     {
                         UTEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["UTI"]);
                         if (UTEng.Text == "NA")
                         {
                             UTEngstring = "0";

                         }
                         else
                         {
                             UTEngstring = UTEng.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         UTHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["UTI"]);
                         if (UTHindiBengali.Text == "NA")
                         {
                             UTHindiBengalistring = "0";

                         }
                         else
                         {
                             UTHindiBengalistring = UTHindiBengali.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         UTPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["UTI"]);
                         if (UTPhysics.Text == "NA")
                         {
                             UTPhysicsstring = "0";

                         }
                         else
                         {
                             UTPhysicsstring = UTPhysics.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         UTChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["UTI"]);
                         if (UTChemistry.Text == "NA")
                         {
                             UTChemistrystring = "0";

                         }
                         else
                         {
                             UTChemistrystring = UTChemistry.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         UTBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["UTI"]);
                         if (UTBiology.Text == "NA")
                         {
                             UTBiologystring = "0";

                         }
                         else
                         {
                             UTBiologystring = UTBiology.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         UTCompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["UTI"]);
                         if (UTCompSci.Text == "NA")
                         {
                             UTCompScistring = "0";

                         }
                         else
                         {
                             UTCompScistring = UTCompSci.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         UTMath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["UTI"]);
                         if (UTMath.Text == "NA")
                         {
                             UTMathstring = "0";

                         }
                         else
                         {
                             UTMathstring = UTMath.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         UTPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["UTI"]);
                         if (UTPhysicalEdu.Text == "NA")
                         {
                             UTPhysicalEdustring = "0";

                         }
                         else
                         {
                             UTPhysicalEdustring = UTPhysicalEdu.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         UTCommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["UTI"]);
                         if (UTCommercialArt.Text == "NA")
                         {
                             UTCommercialArtstring = "0";

                         }
                         else
                         {
                             UTCommercialArtstring = UTCommercialArt.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {

                         //PRUTEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["UT1Practical"]);
                         //PRUTPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["UT1Practical"]);
                         //PRUTChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["UT1Practical"]);
                         //PRUTBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["UT1Practical"]);
                         //PRUTCompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["UT1Practical"]);
                         //PRUTPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["UT1Practical"]);
                         //PRUTCommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["UT1Practical"]);

                         HYEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Half Yearly"]);
                         if (HYEng.Text == "NA")
                         {
                             HYEngstring = "0";

                         }
                         else
                         {
                             HYEngstring = HYEng.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         HYHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Half Yearly"]);
                         if (HYHindiBengali.Text == "NA")
                         {
                             HYHindiBengalistring = "0";

                         }
                         else
                         {
                             HYHindiBengalistring = HYHindiBengali.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         HYPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Half Yearly"]);
                         if (HYPhysics.Text == "NA")
                         {
                             HYPhysicsstring = "0";

                         }
                         else
                         {
                             HYPhysicsstring = HYPhysics.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         HYChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Half Yearly"]);
                         if (HYChemistry.Text == "NA")
                         {
                             HYChemistrystring = "0";

                         }
                         else
                         {
                             HYChemistrystring = HYChemistry.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         HYBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Half Yearly"]);
                         if (HYBiology.Text == "NA")
                         {
                             HYBiologystring = "0";

                         }
                         else
                         {
                             HYBiologystring = HYBiology.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         HYCompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Half Yearly"]);
                         if (HYCompSci.Text == "NA")
                         {
                             HYCompScistring = "0";

                         }
                         else
                         {
                             HYCompScistring = HYCompSci.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         HYMath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["Half Yearly"]);
                         if (HYMath.Text == "NA")
                         {
                             HYMathstring = "0";

                         }
                         else
                         {
                             HYMathstring = HYMath.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         HYPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["Half Yearly"]);
                         if (HYPhysicalEdu.Text == "NA")
                         {
                             HYPhysicalEdustring = "0";

                         }
                         else
                         {
                             HYPhysicalEdustring = HYPhysicalEdu.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         HYCommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["Half Yearly"]);
                         if (HYCommercialArt.Text == "NA")
                         {
                             HYCommercialArtstring = "0";

                         }
                         else
                         {
                             HYCommercialArtstring = HYCommercialArt.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {

                         PRHYEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["HYPractical"]);
                         if (PRHYEng.Text == "NA")
                         {
                             PRHYEngstring = "0";

                         }
                         else
                         {
                             PRHYEngstring = PRHYEng.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         PRHYPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["HYPractical"]);
                         if (PRHYPhysics.Text == "NA")
                         {
                             PRHYPhysicsstring = "0";

                         }
                         else
                         {
                             PRHYPhysicsstring = PRHYPhysics.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         PRHYChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["HYPractical"]);
                         if (PRHYChemistry.Text == "NA")
                         {
                             PRHYChemistrystring = "0";

                         }
                         else
                         {
                             PRHYChemistrystring = PRHYChemistry.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         PRHYBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["HYPractical"]);
                         if (PRHYBiology.Text == "NA")
                         {
                             PRHYBiologystring = "0";

                         }
                         else
                         {
                             PRHYBiologystring = PRHYBiology.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         PRHYCompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["HYPractical"]);
                         if (PRHYCompSci.Text == "NA")
                         {
                             PRHYCompScistring = "0";

                         }
                         else
                         {
                             PRHYCompScistring = PRHYCompSci.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         PRHYPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["HYPractical"]);
                         if (PRHYPhysicalEdu.Text == "NA")
                         {
                             PRHYPhysicalEdustring = "0";

                         }
                         else
                         {
                             PRHYPhysicalEdustring = PRHYPhysicalEdu.Text;
                         }
                     }
                     catch
                     {
                     }
                     try
                     {
                         PRHYCommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["HYPractical"]);
                         if (PRHYCommercialArt.Text == "NA")
                         {
                             PRHYCommercialArtstring = "0";

                         }
                         else
                         {
                             PRHYCommercialArtstring = PRHYCommercialArt.Text;
                         }
                     }
                     catch
                     {
                     }


                     //UTIIEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["UTII"]);
                     //UTIIHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["UTII"]);
                     //UTIIPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["UTII"]);
                     //UTIIChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["UTII"]);
                     //UTIIBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["UTII"]);
                     //UTIICompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["UTII"]);
                     //UTIIMath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["UTII"]);
                     //UTIIPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["UTII"]);
                     //UTIICommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["UTII"]);

                     //PRUTIIEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["UT2Practical"]);
                     //PRUTIIPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["UT2Practical"]);
                     //PRUTIIChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["UT2Practical"]);
                     //PRUTIIBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["UT2Practical"]);
                     //PRUTIICompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["UT2Practical"]);
                     //PRUTIIPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["UT2Practical"]);
                     //PRUTIICommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["UT2Practical"]);

                     //AEEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Annual Exam"]);
                     //AEHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Annual Exam"]);
                     //AEPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Annual Exam"]);
                     //AEChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Annual Exam"]);
                     //AEBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Annual Exam"]);
                     //AECompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Annual Exam"]);
                     //AEMath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["Annual Exam"]);
                     //AEPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["Annual Exam"]);
                     //AECommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["Annual Exam"]);

                     //PRAEEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Annual Practical"]);
                     //PRAEPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Annual Practical"]);
                     //PRAEChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Annual Practical"]);
                     //PRAEBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Annual Practical"]);
                     //PRAECompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Annual Practical"]);
                     //PRAEPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["Annual Practical"]);
                     //PRAECommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["Annual Practical"]);

                     //TPUTEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["20%_OF_UT"]);
                     //TPUTHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["20%_OF_UT"]);
                     //TPUTPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["20%_OF_UT"]);
                     //TPUTChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["20%_OF_UT"]);
                     //TPUTBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["20%_OF_UT"]);
                     //TPUTCompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["20%_OF_UT"]);
                     //TPUTMath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["20%_OF_UT"]);
                     //TPUTPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["20%_OF_UT"]);
                     //TPUTCommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["20%_OF_UT"]);

                     //TPHYEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["30%_OF_HALFYEARLY"]);
                     //TPHYHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["30%_OF_HALFYEARLY"]);
                     //TPHYPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["30%_OF_HALFYEARLY"]);
                     //TPHYChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["30%_OF_HALFYEARLY"]);
                     //TPHYBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["30%_OF_HALFYEARLY"]);
                     //TPHYCompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["30%_OF_HALFYEARLY"]);
                     //TPHYMath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["30%_OF_HALFYEARLY"]);
                     //TPHYPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["30%_OF_HALFYEARLY"]);
                     //TPHYCommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["30%_OF_HALFYEARLY"]);

                     //FPAEEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["50%_OF_ANNUAL"]);
                     //FPAEHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["50%_OF_ANNUAL"]);
                     //FPAEPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["50%_OF_ANNUAL"]);
                     //FPAEChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["50%_OF_ANNUAL"]);
                     //FPAEBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["50%_OF_ANNUAL"]);
                     //FPAECompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["50%_OF_ANNUAL"]);
                     //FPAEMath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["50%_OF_ANNUAL"]);
                     //FPAEPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["50%_OF_ANNUAL"]);
                     //FPAECommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["50%_OF_ANNUAL"]);

                     //FTOTEng.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["FINAL TOTAL"]);
                     //FTOTHindiBengali.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["FINAL TOTAL"]);
                     //FTOTPhysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["FINAL TOTAL"]);
                     //FTOTChemistry.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["FINAL TOTAL"]);
                     //FTOTBiology.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["FINAL TOTAL"]);
                     //FTOTCompSci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["FINAL TOTAL"]);
                     //FTOTMath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["FINAL TOTAL"]);
                     //FTOTPhysicalEdu.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[7]["FINAL TOTAL"]);
                     //FTOTCommercialArt.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[8]["FINAL TOTAL"]);


                     //UTITOT.Text = Convert.ToString(Convert.ToInt32(UTEng.Text) + Convert.ToInt32(UTHindiBengali.Text) + Convert.ToInt32(UTPhysics.Text) + Convert.ToInt32(UTChemistry.Text) + Convert.ToInt32(UTBiology.Text) + Convert.ToInt32(UTCompSci.Text) + Convert.ToInt32(UTMath.Text) + Convert.ToInt32(UTPhysicalEdu.Text) + Convert.ToInt32(UTCommercialArt.Text));
                     //HYTOT.Text = Convert.ToString(Convert.ToInt32(HYEng.Text) + Convert.ToInt32(HYPhysics.Text) + Convert.ToInt32(HYChemistry.Text) + Convert.ToInt32(HYBiology.Text) + Convert.ToInt32(HYCompSci.Text) + Convert.ToInt32(HYMath.Text) + Convert.ToInt32(HYPhysicalEdu.Text) + Convert.ToInt32(HYCommercialArt.Text) + Convert.ToInt32(PRHYEng.Text) + Convert.ToInt32(HYHindiBengali.Text) + Convert.ToInt32(PRHYPhysics.Text) + Convert.ToInt32(PRHYChemistry.Text) + Convert.ToInt32(PRHYBiology.Text) + Convert.ToInt32(PRHYCompSci.Text) + Convert.ToInt32(PRHYPhysicalEdu.Text) + Convert.ToInt32(PRHYCommercialArt.Text));
                     //UTIITOT.Text = Convert.ToString(Convert.ToInt32(UTIIEng.Text) + Convert.ToInt32(UTIIHindiBengali.Text) + Convert.ToInt32(UTIIPhysics.Text) + Convert.ToInt32(UTIIChemistry.Text) + Convert.ToInt32(UTIIBiology.Text) + Convert.ToInt32(UTIICompSci.Text) + Convert.ToInt32(UTIIMath.Text) + Convert.ToInt32(UTIIPhysicalEdu.Text) + Convert.ToInt32(UTIICommercialArt.Text));
                     //TPUTTOT.Text = Convert.ToString(Convert.ToInt32(TPUTEng.Text) + Convert.ToInt32(TPUTHindiBengali.Text) + Convert.ToInt32(TPUTPhysics.Text) + Convert.ToInt32(TPUTChemistry.Text) + Convert.ToInt32(TPUTBiology.Text) + Convert.ToInt32(TPUTCompSci.Text) + Convert.ToInt32(TPUTMath.Text) + Convert.ToInt32(TPUTPhysicalEdu.Text) + Convert.ToInt32(TPUTCommercialArt.Text));
                     //TPHYTOT.Text = Convert.ToString(Convert.ToInt32(TPHYEng.Text) + Convert.ToInt32(TPHYHindiBengali.Text) + Convert.ToInt32(TPHYPhysics.Text) + Convert.ToInt32(TPHYChemistry.Text) + Convert.ToInt32(TPHYBiology.Text) + Convert.ToInt32(TPHYCompSci.Text) + Convert.ToInt32(TPHYMath.Text) + Convert.ToInt32(TPHYPhysicalEdu.Text) + Convert.ToInt32(TPHYCommercialArt.Text));
                     //AETOT.Text = Convert.ToString(Convert.ToInt32(AEEng.Text) + Convert.ToInt32(AEHindiBengali.Text) + Convert.ToInt32(AEPhysics.Text) + Convert.ToInt32(AEChemistry.Text) + Convert.ToInt32(AEBiology.Text) + Convert.ToInt32(AECompSci.Text) + Convert.ToInt32(AEMath.Text) + Convert.ToInt32(AEPhysicalEdu.Text) + Convert.ToInt32(AECommercialArt.Text) + Convert.ToInt32(PRAEEng.Text) + Convert.ToInt32(PRAEPhysics.Text) + Convert.ToInt32(PRAEChemistry.Text) + Convert.ToInt32(PRAEBiology.Text) + Convert.ToInt32(AECompSci.Text) + Convert.ToInt32(PRAEPhysicalEdu.Text) + Convert.ToInt32(PRAECommercialArt.Text));
                     //FPAETOT.Text = Convert.ToString(Convert.ToInt32(FPAEEng.Text) + Convert.ToInt32(FPAEHindiBengali.Text) + Convert.ToInt32(FPAEPhysics.Text) + Convert.ToInt32(FPAEChemistry.Text) + Convert.ToInt32(FPAEBiology.Text) + Convert.ToInt32(FPAECompSci.Text) + Convert.ToInt32(FPAEMath.Text) + Convert.ToInt32(FPAEPhysicalEdu.Text) + Convert.ToInt32(FPAECommercialArt.Text));
                     //FTOT.Text = Convert.ToString(Convert.ToInt32(FTOTEng.Text) + Convert.ToInt32(FTOTHindiBengali.Text) + Convert.ToInt32(FTOTPhysics.Text) + Convert.ToInt32(FTOTChemistry.Text) + Convert.ToInt32(FTOTBiology.Text) + Convert.ToInt32(FTOTCompSci.Text) + Convert.ToInt32(FTOTMath.Text) + Convert.ToInt32(FTOTPhysicalEdu.Text) + Convert.ToInt32(FTOTCommercialArt.Text));

                     UTITOT.Text = Convert.ToString(Convert.ToInt32(UTEngstring) + Convert.ToInt32(UTHindiBengalistring) + Convert.ToInt32(UTPhysicsstring) + Convert.ToInt32(UTChemistrystring) + Convert.ToInt32(UTBiologystring) + Convert.ToInt32(UTCompScistring) + Convert.ToInt32(UTMathstring) + Convert.ToInt32(UTPhysicalEdustring) + Convert.ToInt32(UTCommercialArtstring));
                     HYTOT.Text = Convert.ToString(Convert.ToInt32(HYEngstring) + Convert.ToInt32(HYPhysicsstring) + Convert.ToInt32(HYChemistrystring) + Convert.ToInt32(HYBiologystring) + Convert.ToInt32(HYCompScistring) + Convert.ToInt32(HYMathstring) + Convert.ToInt32(HYPhysicalEdustring) + Convert.ToInt32(HYCommercialArtstring) + Convert.ToInt32(PRHYEngstring) + Convert.ToInt32(HYHindiBengalistring) + Convert.ToInt32(PRHYPhysicsstring) + Convert.ToInt32(PRHYChemistrystring) + Convert.ToInt32(PRHYBiologystring) + Convert.ToInt32(PRHYCompScistring) + Convert.ToInt32(PRHYPhysicalEdustring) + Convert.ToInt32(PRHYCommercialArtstring));

                 }


                 crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "'" + ddlStudent.SelectedItem + "'");
                 Response.End();

             }

        }
        catch
        {

        }

    }

   protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
   {
       ddlExam.ClearSelection();
       FillExam();

   }

  



}
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


public partial class ResultPrimary : DBUtility
{
    ReportDocument crystalReport = new ReportDocument();
    Stream stream1;
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    string strQry = "";
    DataSet dsObj;
    DataSet dsObjgrade;
    string exam = "";
    //protected void Page_Init(object sender, EventArgs e)
    //{

    //    if (Context.Session != null)
    //    {

    //        if (Session.IsNewSession)
    //        {

    //            HttpCookie newSessionIdCookie = Request.Cookies["ASP.NET_SessionId"];

    //            if (newSessionIdCookie != null)
    //            {

    //                string newSessionIdCookieValue = newSessionIdCookie.Value;

    //                if (newSessionIdCookieValue != string.Empty)
    //                {

    //                    // This means Session was timed Out and New Session was started

    //                    Response.Redirect("index.aspx");

    //                }

    //            }

    //        }

    //    }

    //}
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
                   // ddlGender.SelectedValue = Convert.ToString(Session["Gender"]);

                    ddlSTD.Enabled = false;
                   // ddlGender.Enabled = false;

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
           // ddlGender.ClearSelection();
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
        //ddlGender.ClearSelection();
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
    protected void ddlExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        

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
                    //strQry = "exec usp_ExamMarks @type='ExamMark_PrimaryHalfAll',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
                    //        dsObjgrade = sGetDataset(strQry);
                    dsObj = sGetDataset(strQry);
                    Session["rptStdWiseStuFee"] = dsObj;
                    Session["Exam_id"] = ddlExam.SelectedItem.ToString();
                    Session["Exam_idnum"] = ddlExam.SelectedValue.ToString();
                    Session["standard_id"] = ddlSTD.SelectedItem.ToString();
                    Session["standard_idnum"] = ddlSTD.SelectedValue.ToString();
                    Response.Redirect("rptResultPrimary.aspx", true);
                    //Response.Redirect("<script>window.open ('rptResultPrimary.aspx','_blank');</script>");

                }
                catch(Exception ex)
                {

                }

            }
            else
            {
                strQry = "exec usp_FillDropDown @type='GetStudentresult',@StudentId='" + ddlStudent.SelectedValue.ToString() + "',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                //strQry = "exec usp_ExamMarks @type='ExamMark_PrimaryHalf',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
                //        dsObjgrade = sGetDataset(strQry);
                dsObj = sGetDataset(strQry);
                Session["rptStdWiseStuFee"] = dsObj;
                Session["Exam_id"] = ddlExam.SelectedItem.ToString();
                Session["Exam_idnum"] = ddlExam.SelectedValue.ToString();
                Session["standard_id"] = ddlSTD.SelectedItem.ToString();
                Session["standard_idnum"] = ddlSTD.SelectedValue.ToString();
                Response.Redirect("rptResultPrimary.aspx", true);


        }

        }
        catch(Exception ex)
        {
            ex.Message.ToString();
        
        }
        
    }

    protected void Img1_Click(object sender, EventArgs e)
    {
        string reportPath = Server.MapPath("NursaryResult.rpt");
        crystalReport.Load(reportPath);
        TextObject name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text53"];
        TextObject class1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text54"];
        TextObject sec = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text55"];
        TextObject rollno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text56"];

        TextObject SUBenglish = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text5"];
        TextObject SUBphysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text6"];
        TextObject SUBconversation = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text7"];
        TextObject SUBmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text8"];
        TextObject SUBhindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text9"];
        TextObject SUBsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text10"];
        TextObject SUBgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text11"];

        TextObject english = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text57"];
        TextObject physics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text58"];
        TextObject conversation = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text59"];
        TextObject math = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text60"];
        TextObject hindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text61"];
        TextObject sci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text62"];
        TextObject general = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text63"];
        //TextObject reportname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text18"];
        

        TextObject HYenglishgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text12"];
        TextObject HYphysicsgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text14"];
        TextObject HYconversationgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text20"];
        TextObject HYmathgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text22"];
        TextObject HYhindigrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text32"];
        TextObject HYscigrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text33"];
        TextObject HYgeneralgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text94"];

        TextObject englishgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text64"];
        TextObject physicsgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text65"];
        TextObject conversationgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text66"];
        TextObject mathgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text67"];
        TextObject hindigrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text68"];
        TextObject scigrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text69"];
        TextObject generalgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text70"];

        TextObject art1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text74"];
        TextObject art2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text75"];
        TextObject art3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text76"];

        TextObject subart1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text34"];
        TextObject subart2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text35"];
        TextObject subart3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text36"];

        TextObject sochb1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];
        TextObject sochb2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text82"];
        TextObject sochb3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text83"];
        TextObject sochb4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text84"];

        TextObject SUBsochb1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text38"];
        TextObject SUBsochb2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text39"];
        TextObject SUBsochb3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text41"];
        TextObject SUBsochb4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text40"];

        TextObject sochbmrk1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text77"];
        TextObject sochbmrk2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text78"];

        TextObject wrkhb1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text85"];
        TextObject wrkhb2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text86"];
        TextObject wrkhb3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text87"];
        TextObject wrkhb4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text88"];
        TextObject wrkhb5 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text89"];
        TextObject wrkhb6 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text90"];

        TextObject SUBwrkhb1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text43"];
        TextObject SUBwrkhb2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text44"];
        TextObject SUBwrkhb3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text45"];
        TextObject SUBwrkhb4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text46"];
        TextObject SUBwrkhb5 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text47"];
        TextObject SUBwrkhb6 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text48"];

        TextObject pt1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text91"];
        TextObject pt2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text92"];
        TextObject pt3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text93"];

        TextObject SUBpt1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text50"];
        TextObject SUBpt2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text51"];
        TextObject SUBpt3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text52"];

        TextObject session = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text15"];
        TextObject ExamName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text17"];

        TextObject Strenght = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text108"];
        TextObject Suggestion = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text109"];

        TextObject totaldays = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text102"];
        TextObject PresentDay = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text19"];

        strQry = "Execute dbo.usp_Profile @command='attendance' ,@intStudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            //totaldays.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalDay"]);
            PresentDay.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
        }

        session.Text = Convert.ToString(Session["YearName"]);
        ExamName.Text = ddlExam.SelectedItem.ToString().ToUpper();
        //reportname.Text = "REPORT CARD FOR " + ddlSTD.SelectedItem.ToString().ToUpper();

        strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intStudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
        //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            name.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]).ToUpper();

            rollno.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);

            class1.Text = ddlSTD.SelectedItem.ToString().ToUpper();
            sec.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
        }

        strQry = "exec usp_ExamMarks @type='ExamMark_PrimaryHalf',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
        dsObjgrade = sGetDataset(strQry);
        if (dsObjgrade.Tables[0].Rows.Count > 0)
        {
            try
            {
                SUBenglish.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["vchsubjectname"]);
            }
            catch
            {
            }
            try
            {
                SUBphysics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["vchsubjectname"]);
            }
            catch
            {
            }
            try
            {
                SUBconversation.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["vchsubjectname"]);
            }
            catch
            {
            }
            try
            {
                SUBmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["vchsubjectname"]);
            }
            catch
            {
            }
            try
            {
                SUBhindi.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["vchsubjectname"]);
            }
            catch
            {
            }
            try
            {
                SUBsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["vchsubjectname"]);
            }
            catch
            {
            }
            try
            {
                SUBgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["vchsubjectname"]);
            }
            catch
            {
            }

            try
            {
                english.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["UTI"]);
            }
            catch
            {
            }
            try
            {
                physics.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["UTI"]);
            }
            catch
            {
            }
            try
            {
                conversation.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["UTI"]);
            }
            catch
            {
            }
            try
            {
                math.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["UTI"]);
            }
            catch
            {
            }
            try
            {
                hindi.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["UTI"]);
            }
            catch
            {
            }
            try
            {
                sci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["UTI"]);
            }
            catch
            {
            }
            try
            {
                general.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["UTI"]);
            }
            catch
            {
            }

            try
            {
                HYenglishgrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Half Yearly"]);
            }
            catch
            {
            }
            try
            {
                HYphysicsgrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Half Yearly"]);
            }
            catch
            {
            }
            try
            {
                HYconversationgrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Half Yearly"]);
            }
            catch
            {
            }
            try
            {
                HYmathgrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Half Yearly"]);
            }
            catch
            {
            }
            try
            {
                HYhindigrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Half Yearly"]);
            }
            catch
            {
            }
            try
            {
                HYscigrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Half Yearly"]);
            }
            catch
            {
            }
            try
            {
                HYgeneralgrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["Half Yearly"]);
            }
            catch
            {
            }

            try
            {
                englishgrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Grade"]);
            }
            catch
            {
            }
            try
            {
                physicsgrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Grade"]);
            }
            catch
            {
            }
            try
            {
                conversationgrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Grade"]);
            }
            catch
            {
            }
            try
            {
                mathgrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Grade"]);
            }
            catch
            {
            }
            try
            {
                hindigrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Grade"]);
            }
            catch
            {
            }
            try
            {
                scigrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Grade"]);
            }
            catch
            {
            }
            try
            {
                generalgrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["Grade"]);
            }
            catch
            {
            }
        }


        strQry = "exec usp_ExamMarks @type='EnglishActivityMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            //GridView1.DataSource = dsObj;
            //GridView1.DataBind();
            art1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
            // lblengactgrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
            art2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
            // lblengactgrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
            art3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term

            subart1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchName"]);//first term 
            subart2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["VchName"]);//first term            
            subart3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["VchName"]);//first term
        }

        strQry = "exec usp_ExamMarks @type='workhabitMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            wrkhb1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
            wrkhb2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
            wrkhb3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
            wrkhb4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
            wrkhb5.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);
            wrkhb6.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["GRADE"]);

            SUBwrkhb1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchName"]);
            SUBwrkhb2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["VchName"]);
            SUBwrkhb3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["VchName"]);
            SUBwrkhb4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["VchName"]);
            SUBwrkhb5.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["VchName"]);
            SUBwrkhb6.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["VchName"]);
        }
        strQry = "exec usp_ExamMarks @type='skillmarkgrade_first',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            pt1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
            pt2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
            pt3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);

            SUBpt1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchskillName"]);
            SUBpt2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchskillName"]);
            SUBpt3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchskillName"]);
        }

        strQry = "exec usp_ExamMarks @type='personalMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            sochb1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
            sochb2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
            sochb3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
            sochb4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);

            SUBsochb1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchName"]);
            SUBsochb2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["VchName"]);
            SUBsochb3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["VchName"]);
            SUBsochb4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["VchName"]);
        }

        strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "' and intAttendance=1";
        string Strength = sExecuteReader(strQry);
        Strenght.Text = Strength;
        strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "' and intAttendance=2";
        string remark = sExecuteReader(strQry);
        Suggestion.Text = remark;
        crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "'" + ddlStudent.SelectedItem + "'");
        Response.End();  
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Result1and2 : DBUtility
{
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
                    ddlGender.SelectedValue = Convert.ToString(Session["Gender"]);

                    ddlSTD.Enabled = false;
                    ddlGender.Enabled = false;

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
            ddlGender.ClearSelection();
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

            strQry = "select intExam_id,vchExamination_name from tblExaminationDet where intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlExam, strQry, "vchExamination_name", "intExam_id");
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

            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
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
        ddlGender.ClearSelection();
        ddlExam.ClearSelection();
        FillDIV();
    }
    protected void ddlDIV_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlGender.ClearSelection();
        ddlExam.ClearSelection();
        FillStudent();
    }
    protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
    {
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

            pnlresult.Visible = true;
            //strQry = "select distinct (Student_master.vchStudentFirst_name) from Student_master left outer join tblExam_Mark on tblExam_Mark.intStudent_id=Student_master.intStudentID_Number where Student_master.intStudentID_Number='" + ddlStudent.SelectedValue.ToString() + "'";
            //string name = sExecuteReader(strQry);
            //Label1.Text = name;

            strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intStudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
            //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                Label1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                //lblFather.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                //lblMother.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                //lblMother.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                //lblDOB.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
                //lblAddress.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAddress"]);
                Label4.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);
                //lblRegistration.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intAddmission_id"]);
                //lblAdmision.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchapplication_no"]);
                Label2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
                Label3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
            }
        }
        catch
        {
        }
        strQry = "select COUNT(status) from tblSchoolAttendance where dtDate between '2018/04/9' And '2018/09/28' and status='Present' and intStudent_id ='" + ddlStudent.SelectedValue.ToString() + "'";
        string Presentday = sExecuteReader(strQry);
       // Label6.Text = Presentday;
        strQry = " select (datediff(dd, '2018/04/9', '2018/09/28')) - (( DateDiff(wk, '2018/04/9', '2018/09/28') * 2) - case when datepart(dw, '2018/04/9') = 7 then 1 else 0 end -case when datepart(dw, '2018/09/28') = 7 then -1 else 0 end)";
        string totalday = sExecuteReader(strQry);
       // Label7.Text = "96";
        //int attendance = int.Parse(totalday) - int.Parse(Presentday);

        strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "' and intAttendance=1";
        string Strength = sExecuteReader(strQry);
        Label8.Text = Strength;
        strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "'";
        string remark = sExecuteReader(strQry);
        Label9.Text = remark;
        string section = ddlSTD.SelectedValue.ToString();

        if (int.Parse(section) == 1) //&& int.Parse(section) == 2)
        {
            Label2.Text = "I";
        }
        else
        {
            Label2.Text = "II";
        }


        lblsession.Text = Convert.ToString(Session["YearName"]);


        exam = ddlExam.SelectedItem.ToString();

        if (exam == "UTI")
        {

            pnlfirst.Visible = true;
            pnlfinal.Visible = false;
            //English Activity
            try
            {

                strQry = "exec usp_ExamMarks @type='EnglishActivityMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    //GridView1.DataSource = dsObj;
                    //GridView1.DataBind();
                    lblenglishactivity1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                    // lblengactgrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                    lblenglishactivity2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                    // lblengactgrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                    lblenglishactivity3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                    //lblengactgrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                    lblenglishactivity4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                    //lblengactgrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                    lblenglishactivity5.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);//first term
                    //lblengactgrade5.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);

                    strQry = "exec usp_ExamMarks @type='ExamMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
                    dsObjgrade = sGetDataset(strQry);
                    if (dsObjgrade.Tables[0].Rows.Count > 0)
                    {
                        lblenglishactivitygrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["GRADE"]);
                        lblenglishreadergrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["GRADE"]);
                        lblnumberworkgrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["GRADE"]);
                        lblsecondlanggrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["GRADE"]);
                        lblevsgrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["GRADE"]);
                        lblcomputergrd.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["GRADE"]);
                        //string sechindi1 = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["TotalMark"]);
                        //if (int.Parse(sechindi1) > -1 || sechindi1 == "")
                        //{
                        //    sechindilbl1.Text = "Second language Bengali";
                        //    lblsecondlanggrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["GRADE"]);
                        //}
                        //else
                        //{
                        //    sechindilbl1.Text = "Second language Bengali";
                        //    lblsecondlanggrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["GRADE"]);
                        //}
                        //lblevsgrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["GRADE"]);
                        //lblcomputergrd.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["GRADE"]);
                    }
                }
                else
                {
                    lblenglishactivity1.Text = "";
                    lblenglishactivity2.Text = "";
                    lblenglishactivity3.Text = "";
                    lblenglishactivity4.Text = "";
                    lblenglishactivity5.Text = "";
                    lblenglishactivitygrade.Text = "";

                }
            }
            catch
            {
            }
            try
            {

                //English Reader
                //strQry ="select tblskill_Master.vchskillName,tblSkill_Mark.decMark from tblSkill_Mark left outer join tblskill_Master on tblskill_Master.intskill_id=tblSkill_Mark.intSubject_id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                strQry = "exec usp_ExamMarks @type='EnglishReaderMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    //GridView2.DataSource = dsObj;
                    // GridView2.DataBind();

                    lblenglishreader1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                    // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                    lblenglishreader2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                    //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                    lblenglishreader3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                    //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                    lblenglishreader4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                    // lblenglishreadergrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                }
                else
                {
                    lblenglishreader1.Text = "";
                    lblenglishreader2.Text = "";
                    lblenglishreader3.Text = "";
                    lblenglishreader4.Text = "";
                    lblenglishreadergrade.Text = "";
                }
            }
            catch
            {
            }

            //Number Work
            try
            {

                //strQry ="select tblWorkHabit.VchName,tblWorkHabitEntry.vchgrade from tblWorkHabitEntry left outer join tblWorkHabit on tblWorkHabit.id=tblWorkHabitEntry.intSubject_id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                strQry = "exec usp_ExamMarks @type='NumberWorkMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    //GridView5.DataSource = dsObj;
                    //GridView5.DataBind();


                    lblnumberwork1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                    // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                    lblnumberwork2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                    //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                    lblnumberwork3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                    //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                    lblnumberwork4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                    // lblenglishreadergrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"])

                }
                else
                {
                    lblnumberwork1.Text = "";
                    lblnumberwork2.Text = "";
                    lblnumberwork3.Text = "";
                    lblnumberwork4.Text = "";
                    lblnumberworkgrade.Text = "";
                }
            }
            catch
            {
            }
            try
            {

                //Second Language
                //strQry = "select tblPersonalTraits.VchName, vchgrade from tblPersonalTraitsEntry left outer join tblPersonalTraits on tblPersonalTraitsEntry.intSubject_id=tblPersonalTraits.id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                strQry = "exec usp_ExamMarks @type='SecondLanguagebengaliMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
              
                        {
                            lblsecondlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                            // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                            lblsecondlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                            //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                            lblsecondlang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                            //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                            lblsecondlang4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                            // lblenglishreadergrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                        }
                    
                
                else
                {
                    lblsecondlang1.Text = "";
                    lblsecondlang2.Text = "";
                    lblsecondlang3.Text = "";
                    lblsecondlang4.Text = "";
                    lblsecondlanggrade.Text = "";


                }
            }
            catch
            {
            }
            try
            {

                //EVs
                //strQry = "select tblPersonalTraits.VchName, vchgrade from tblPersonalTraitsEntry left outer join tblPersonalTraits on tblPersonalTraitsEntry.intSubject_id=tblPersonalTraits.id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                strQry = "exec usp_ExamMarks @type='EVSMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    //GridView7.DataSource = dsObj;
                    //GridView7.DataBind();

                    lblevs1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                    // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                    lblevs2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                    //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                    lblevs3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                    //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                }
                else
                {
                    lblevs1.Text = "";
                    lblevs2.Text = "";
                    lblevs3.Text = "";
                    lblevsgrade.Text = "";
                }
            }
            catch
            {
            }
            try
            {

                strQry = "exec usp_ExamMarks @type='ComputerMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    //GridView7.DataSource = dsObj;
                    //GridView7.DataBind();

                    //lblcomputer1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                    // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                    lblcomputer2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                    //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                    lblcomputer3.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                    //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);

                }
                else
                {
                    lblcomputer2.Text = "";
                    lblcomputer3.Text = "";
                    lblcomputergrd.Text = "";
                }
            }
            catch
            {
            }
            //skill
            //strQry = "exec usp_ExamMarks @type='skillmarkgrade_first',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    //GridView8.DataSource = dsObj;
            //    //GridView8.DataBind();
            //    try
            //    {
            //        lblartcrft.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
            //        lblpt.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);


            //    }
            //    catch
            //    { }
            //}
            //else
            //{
            //    lblartcrft.Text = "";
            //    lblpt.Text = "";
            //}

            //workhabit
            try
            {
                //strQry ="select tblWorkHabit.VchName,tblWorkHabitEntry.vchgrade from tblWorkHabitEntry left outer join tblWorkHabit on tblWorkHabit.id=tblWorkHabitEntry.intSubject_id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                strQry = "exec usp_ExamMarks @type='workhabitMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    GridView3.Visible = true;
                    GridView9.Visible = false;
                    GridView3.DataSource = dsObj;
                    GridView3.DataBind();
                }
            }
            catch
            {
            }
            try
            {

                //Personal & Social Traits
                //strQry = "select tblPersonalTraits.VchName, vchgrade from tblPersonalTraitsEntry left outer join tblPersonalTraits on tblPersonalTraitsEntry.intSubject_id=tblPersonalTraits.id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                strQry = "exec usp_ExamMarks @type='personalMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    GridView4.Visible = true;
                    GridView10.Visible = false;
                    GridView4.DataSource = dsObj;
                    GridView4.DataBind();
                }
            }
            catch
            {
            }
        }

        if (exam == "UTII")
        {
            pnlfinal.Visible = true;
            pnlfirst.Visible = false;
            strQry = "exec usp_ExamMarks @type='EnglishActivityMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //GridView1.DataSource = dsObj;
                //GridView1.DataBind();

                lblenglishactivity11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                // lblengactgrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                lblenglishactivity22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                // lblengactgrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                lblenglishactivity33.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                //lblengactgrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                lblenglishactivity44.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                //lblengactgrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                lblenglishactivity55.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);//first term
                //lblengactgrade5.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);

                strQry = "exec usp_ExamMarks @type='ExamMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "'";
                dsObjgrade = sGetDataset(strQry);
                if (dsObjgrade.Tables[0].Rows.Count > 0)
                {
                    Label12.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["GRADE"]);
                    Label13.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["GRADE"]);
                    Label14.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["GRADE"]);
                    Label15.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["GRADE"]);
                    Label16.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["GRADE"]);
                    Label25.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["GRADE"]);

                }

            }

            strQry = "exec usp_ExamMarks @type='EnglishActivityMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //GridView1.DataSource = dsObj;
                //GridView1.DataBind();

                lblengactgrade11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                // lblengactgrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                lblengactgrade22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                // lblengactgrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                lblengactgrade33.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                //lblengactgrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                lblengactgrade44.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                //lblengactgrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                lblengactgrade55.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);//first term
                //lblengactgrade5.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);
                try
                {

                    strQry = "exec usp_ExamMarks @type='ExamMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "'";
                    dsObjgrade = sGetDataset(strQry);
                    if (dsObjgrade.Tables[0].Rows.Count > 0)
                    {
                        Label17.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["GRADE"]);
                        Label18.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["GRADE"]);
                        Label23.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["GRADE"]);
                        Label19.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["GRADE"]);
                        Label20.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["GRADE"]);
                        Label27.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["GRADE"]);


                    }

                }
                catch
                {
                }
                try
                {

                    //English Reader
                    //strQry ="select tblskill_Master.vchskillName,tblSkill_Mark.decMark from tblSkill_Mark left outer join tblskill_Master on tblskill_Master.intskill_id=tblSkill_Mark.intSubject_id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                    strQry = "exec usp_ExamMarks @type='EnglishReaderMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        //GridView2.DataSource = dsObj;
                        // GridView2.DataBind();

                        lblenglishreader11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                        // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        lblenglishreader22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                        //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        lblenglishreader33.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                        //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                        lblenglishreader44.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                        // lblenglishreadergrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                    }
                }
                catch
                {
                }
                try
                {

                    strQry = "exec usp_ExamMarks @type='EnglishReaderMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        //GridView2.DataSource = dsObj;
                        // GridView2.DataBind();

                        lblenglishreadergrade11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                        // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        lblenglishreadergrade22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                        //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        lblenglishreadergrade33.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                        //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                        lblenglishreadergrade44.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                        // lblenglishreadergrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                    }
                }
                catch
                {
                }

                //Number Work
                try
                {

                    //strQry ="select tblWorkHabit.VchName,tblWorkHabitEntry.vchgrade from tblWorkHabitEntry left outer join tblWorkHabit on tblWorkHabit.id=tblWorkHabitEntry.intSubject_id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                    strQry = "exec usp_ExamMarks @type='NumberWorkMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        //GridView5.DataSource = dsObj;
                        //GridView5.DataBind();


                        lblnumberwork11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                        // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        lblnumberwork22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                        //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        lblnumberwork33.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                        //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                        lblnumberwork44.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                        // lblenglishreadergrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"])

                    }
                }
                catch
                {
                }
                try
                {

                    strQry = "exec usp_ExamMarks @type='NumberWorkMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        //GridView5.DataSource = dsObj;
                        //GridView5.DataBind();


                        lblnumberworkgrade11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                        // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        lblnumberworkgrade22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                        //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        lblnumberworkgrade33.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                        //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                        lblnumberworkgrade44.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                        // lblenglishreadergrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"])

                    }
                }
                catch
                {
                }
                try
                {
                    //Second Language
                    //strQry = "select tblPersonalTraits.VchName, vchgrade from tblPersonalTraitsEntry left outer join tblPersonalTraits on tblPersonalTraitsEntry.intSubject_id=tblPersonalTraits.id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                    strQry = "exec usp_ExamMarks @type='SecondLanguagebengaliMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        // GridView6.DataSource = dsObj;
                        //GridView6.DataBind();

                        lblsecondlang11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                        // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        lblsecondlang22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                        //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        lblsecondlang33.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                        //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                        lblsecondlang44.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                        // lblenglishreadergrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                    }
                }
                catch
                {
                }
                //try
                //{

                //    strQry = "exec usp_ExamMarks @type='SecondLanguagebengaliMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                //    dsObj = sGetDataset(strQry);
                //    if (dsObj.Tables[0].Rows.Count > 0)
                //    {
                //        // GridView6.DataSource = dsObj;
                //        //GridView6.DataBind();

                //        lblsecondlanggrade11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                //        // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                //        lblsecondlanggrade22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                //        //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                //        lblsecondlanggrade33.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                //        //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                //        lblsecondlanggrade44.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                //        // lblenglishreadergrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                //    }
                //}
                //catch
                //{
                //}
                try
                {

                    //EVs
                    //strQry = "select tblPersonalTraits.VchName, vchgrade from tblPersonalTraitsEntry left outer join tblPersonalTraits on tblPersonalTraitsEntry.intSubject_id=tblPersonalTraits.id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                    strQry = "exec usp_ExamMarks @type='EVSMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        //GridView7.DataSource = dsObj;
                        //GridView7.DataBind();

                        lblevs11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                        // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        lblevs22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                        //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        lblevs33.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                        //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);

                    }
                }
                catch
                {
                }

                try
                {

                    strQry = "exec usp_ExamMarks @type='EVSMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        //GridView7.DataSource = dsObj;
                        //GridView7.DataBind();

                        lblevsgrade11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                        // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        lblevsgrade22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                        //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        lblevsgrade33.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                        //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);

                    }
                }
                catch
                {
                }
                //Computer
                try
                {


                    strQry = "exec usp_ExamMarks @type='ComputerMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        //GridView7.DataSource = dsObj;
                        //GridView7.DataBind();

                        lblcomputer11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                        // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        lblcomputer22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                        //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        lblcomputer33.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                        //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);

                    }
                }
                catch
                {
                }
                try
                {
                    strQry = "exec usp_ExamMarks @type='ComputerMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        //GridView7.DataSource = dsObj;
                        //GridView7.DataBind();

                        lblcomputergrd11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                        // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        //lblcomputergrd22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                        ////lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        //lblcomputergrd33.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                        //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);

                    }
                }
                catch
                {
                }
                //skill
                //strQry = "exec usp_ExamMarks @type='skillmarkgrade_final',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                //dsObj = sGetDataset(strQry);
                //if (dsObj.Tables[0].Rows.Count > 0)
                //{
                //    //GridView8.DataSource = dsObj;
                //    //GridView8.DataBind();

                //       // lblartcrft2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["First Term"]);//first term
                //    Label21.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//final term
                //       // lblpt2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["First Term"]);                       
                //    Label22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);

                //}

                //workhabit



                //strQry ="select tblWorkHabit.VchName,tblWorkHabitEntry.vchgrade from tblWorkHabitEntry left outer join tblWorkHabit on tblWorkHabit.id=tblWorkHabitEntry.intSubject_id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                strQry = "exec usp_ExamMarks @type='workhabitMarkfinal',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    GridView9.Visible = true;
                    GridView3.Visible = false;
                    GridView9.DataSource = dsObj;
                    GridView9.DataBind();
                }

                //Personal & Social Traits
                //strQry = "select tblPersonalTraits.VchName, vchgrade from tblPersonalTraitsEntry left outer join tblPersonalTraits on tblPersonalTraitsEntry.intSubject_id=tblPersonalTraits.id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                strQry = "exec usp_ExamMarks @type='personalMarkfinal',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    GridView10.Visible = true;
                    GridView4.Visible = false;
                    GridView10.DataSource = dsObj;
                    GridView10.DataBind();
                }




                //if (exam == "Half Yearly")
                //{

                //    pnlfirst.Visible = true;
                //    pnlfinal.Visible = false;
                //    //English Activity

                //    strQry = "exec usp_ExamMarks @type='EnglishActivityMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                //    dsObj = sGetDataset(strQry);
                //    if (dsObj.Tables[0].Rows.Count > 0)
                //    {
                //        //GridView1.DataSource = dsObj;
                //        //GridView1.DataBind();
                //        lblenglishactivity1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                //        // lblengactgrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                //        lblenglishactivity2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                //        // lblengactgrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                //        lblenglishactivity3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                //        //lblengactgrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                //        lblenglishactivity4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                //        //lblengactgrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                //        lblenglishactivity5.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);//first term
                //        //lblengactgrade5.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);

                //        strQry = "exec usp_ExamMarks @type='ExamMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
                //        dsObjgrade = sGetDataset(strQry);
                //        if (dsObjgrade.Tables[0].Rows.Count > 0)
                //        {
                //            lblenglishactivitygrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["GRADE"]);
                //            lblenglishreadergrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["GRADE"]);
                //            lblnumberworkgrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["GRADE"]);
                //            string sechindi1 = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["TotalMark"]);
                //            if (int.Parse(sechindi1) > -1 || sechindi1 == "")
                //            {
                //                sechindilbl1.Text = "Second language Hindi";
                //                lblsecondlanggrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["GRADE"]);
                //            }
                //            else
                //            {
                //                sechindilbl1.Text = "Second language Bengali";
                //                lblsecondlanggrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["GRADE"]);
                //            }
                //            lblevsgrade.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["GRADE"]);
                //            lblcomputergrd.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[6]["GRADE"]);
                //        }
                //    }
                //    else
                //    {
                //        lblenglishactivity1.Text = "";
                //        lblenglishactivity2.Text = "";
                //        lblenglishactivity3.Text = "";
                //        lblenglishactivity4.Text = "";
                //        lblenglishactivity5.Text = "";
                //        lblenglishactivitygrade.Text = "";

                //    }

                //    //English Reader
                //    //strQry ="select tblskill_Master.vchskillName,tblSkill_Mark.decMark from tblSkill_Mark left outer join tblskill_Master on tblskill_Master.intskill_id=tblSkill_Mark.intSubject_id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                //    strQry = "exec usp_ExamMarks @type='EnglishReaderMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                //    dsObj = sGetDataset(strQry);
                //    if (dsObj.Tables[0].Rows.Count > 0)
                //    {
                //        //GridView2.DataSource = dsObj;
                //        // GridView2.DataBind();

                //        lblenglishreader1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                //        // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                //        lblenglishreader2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                //        //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                //        lblenglishreader3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                //        //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                //        lblenglishreader4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                //        // lblenglishreadergrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                //    }
                //    else
                //    {
                //        lblenglishreader1.Text = "";
                //        lblenglishreader2.Text = "";
                //        lblenglishreader3.Text = "";
                //        lblenglishreader4.Text = "";
                //        lblenglishreadergrade.Text = "";
                //    }


                //    //Number Work

                //    //strQry ="select tblWorkHabit.VchName,tblWorkHabitEntry.vchgrade from tblWorkHabitEntry left outer join tblWorkHabit on tblWorkHabit.id=tblWorkHabitEntry.intSubject_id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                //    strQry = "exec usp_ExamMarks @type='NumberWorkMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                //    dsObj = sGetDataset(strQry);
                //    if (dsObj.Tables[0].Rows.Count > 0)
                //    {
                //        //GridView5.DataSource = dsObj;
                //        //GridView5.DataBind();


                //        lblnumberwork1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                //        // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                //        lblnumberwork2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                //        //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                //        lblnumberwork3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                //        //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                //        lblnumberwork4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                //        // lblenglishreadergrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"])

                //    }
                //    else
                //    {
                //        lblnumberwork1.Text = "";
                //        lblnumberwork2.Text = "";
                //        lblnumberwork3.Text = "";
                //        lblnumberwork4.Text = "";
                //        lblnumberworkgrade.Text = "";
                //    }

                //    //Second Language
                //    //strQry = "select tblPersonalTraits.VchName, vchgrade from tblPersonalTraitsEntry left outer join tblPersonalTraits on tblPersonalTraitsEntry.intSubject_id=tblPersonalTraits.id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                //    strQry = "exec usp_ExamMarks @type='SecondLanguageMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                //    dsObj = sGetDataset(strQry);
                //    if (dsObj.Tables[0].Rows.Count > 0)
                //    {
                //        // GridView6.DataSource = dsObj;
                //        //GridView6.DataBind();
                //        string sechindi1 = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);

                //        if (sechindi1 != "NA")
                //        {

                //            lblsecondlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                //            // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                //            lblsecondlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                //            //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                //            lblsecondlang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                //            //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                //            lblsecondlang4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                //            // lblenglishreadergrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                //        }
                //        else
                //        {
                //            strQry = "exec usp_ExamMarks @type='SecondLanguagebengaliMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                //            dsObj = sGetDataset(strQry);
                //            if (dsObj.Tables[0].Rows.Count > 0)
                //            {
                //                lblsecondlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                //                // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                //                lblsecondlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                //                //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                //                lblsecondlang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                //                //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                //                lblsecondlang4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);//first term
                //                // lblenglishreadergrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                //            }
                //        }
                //    }
                //    else
                //    {
                //        lblsecondlang1.Text = "";
                //        lblsecondlang2.Text = "";
                //        lblsecondlang3.Text = "";
                //        lblsecondlang4.Text = "";
                //        lblsecondlanggrade.Text = "";


                //    }
                //    //EVs
                //    //strQry = "select tblPersonalTraits.VchName, vchgrade from tblPersonalTraitsEntry left outer join tblPersonalTraits on tblPersonalTraitsEntry.intSubject_id=tblPersonalTraits.id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                //    strQry = "exec usp_ExamMarks @type='EVSMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                //    dsObj = sGetDataset(strQry);
                //    if (dsObj.Tables[0].Rows.Count > 0)
                //    {
                //        //GridView7.DataSource = dsObj;
                //        //GridView7.DataBind();

                //        lblevs1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                //        // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                //        lblevs2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                //        //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                //        lblevs3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term
                //        //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                //    }
                //    else
                //    {
                //        lblevs1.Text = "";
                //        lblevs2.Text = "";
                //        lblevs3.Text = "";
                //        lblevsgrade.Text = "";
                //    }

                //    strQry = "exec usp_ExamMarks @type='ComputerMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                //    dsObj = sGetDataset(strQry);
                //    if (dsObj.Tables[0].Rows.Count > 0)
                //    {
                //        //GridView7.DataSource = dsObj;
                //        //GridView7.DataBind();

                //        //lblcomputer1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                //        // lblenglishreadergrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                //        lblcomputer2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                //        //lblenglishreadergrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                //        lblcomputer3.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                //        //lblenglishreadergrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);

                //    }
                //    else
                //    {
                //        lblcomputer2.Text = "";
                //        lblcomputer3.Text = "";
                //        lblcomputergrd.Text = "";
                //    }

                //    //skill
                //    strQry = "exec usp_ExamMarks @type='skillmarkgrade_first',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                //    dsObj = sGetDataset(strQry);
                //    if (dsObj.Tables[0].Rows.Count > 0)
                //    {
                //        //GridView8.DataSource = dsObj;
                //        //GridView8.DataBind();
                //        try
                //        {
                //            lblartcrft.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                //            lblpt.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);


                //        }
                //        catch
                //        { }
                //    }
                //    else
                //    {
                //        lblartcrft.Text = "";
                //        lblpt.Text = "";
                //    }

                //    //workhabit

                //    //strQry ="select tblWorkHabit.VchName,tblWorkHabitEntry.vchgrade from tblWorkHabitEntry left outer join tblWorkHabit on tblWorkHabit.id=tblWorkHabitEntry.intSubject_id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                //    strQry = "exec usp_ExamMarks @type='workhabitMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                //    dsObj = sGetDataset(strQry);
                //    if (dsObj.Tables[0].Rows.Count > 0)
                //    {
                //        GridView3.Visible = true;
                //        GridView9.Visible = false;
                //        GridView3.DataSource = dsObj;
                //        GridView3.DataBind();
                //    }

                //    //Personal & Social Traits
                //    //strQry = "select tblPersonalTraits.VchName, vchgrade from tblPersonalTraitsEntry left outer join tblPersonalTraits on tblPersonalTraitsEntry.intSubject_id=tblPersonalTraits.id where intStudent_id='"+ddlStudent.SelectedValue.ToString()+"'";
                //    strQry = "exec usp_ExamMarks @type='personalMark',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                //    dsObj = sGetDataset(strQry);
                //    if (dsObj.Tables[0].Rows.Count > 0)
                //    {
                //        GridView4.Visible = true;
                //        GridView10.Visible = false;
                //        GridView4.DataSource = dsObj;
                //        GridView4.DataBind();
                //    }
            }

        }
    }
}
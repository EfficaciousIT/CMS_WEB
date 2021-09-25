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

public partial class Result_IX : DBUtility
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

            //strQry = "exec usp_ExamMarks @type='FillExaminationPrimary',@intSchool_id='" + Session["School_id"] + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
            //sBindDropDownList(ddlExam, strQry, "vchExamination_name", "intExam_id");
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
                   // strQry = "exec usp_ExamMarks @type='ResultIXall',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
                    //        dsObjgrade = sGetDataset(strQry);
                    dsObj = sGetDataset(strQry);
                    Session["rptAllStudentMark"] = dsObj;
                    Session["Exam_id"] = ddlExam.SelectedItem.ToString();
                    Session["Exam_idnum"] = ddlExam.SelectedValue.ToString();
                    Session["standard_id"] = ddlSTD.SelectedItem.ToString();
                    Session["standard_idnum"] = ddlSTD.SelectedValue.ToString();
                    Response.Redirect("rptResult_IX.aspx", true);
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
                Response.Redirect("rptResult_IX.aspx", true);

        }

        }
        catch
        {

        }

    }

    protected void Img1_Click(object sender, EventArgs e)
    {
        string reportPath = Server.MapPath("Result_IX.rpt");
        crystalReport.Load(reportPath);

        TextObject name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text62"];
        //TextObject class1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text54"];
        TextObject sec = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text66"];
        TextObject rollno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text61"];
        TextObject mothername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text64"];
        TextObject fathername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text65"];
        TextObject birthdate = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text63"];
        TextObject session = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text110"];
        TextObject ExamName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text235"];
        TextObject reportname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text8"];

        TextObject totaldays = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text112"];
        TextObject PresentDay = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text67"];

        strQry = "Execute dbo.usp_Profile @command='attendance' ,@intStudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            //totaldays.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalDay"]);
            PresentDay.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
        }

        session.Text = Convert.ToString(Session["YearName"]);
        ExamName.Text = ddlExam.SelectedItem.ToString().ToUpper();
        reportname.Text = "REPORT CARD";
            //+ ddlSTD.SelectedItem.ToString().ToUpper();

        TextObject SUBlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text18"];
        TextObject SUBlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text19"];
        TextObject SUBmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text20"];
        TextObject SUBsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text21"];
        TextObject SUBSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text22"];
        TextObject SUBIT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text115"];

        TextObject lang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text68"];
        TextObject lang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text69"];
        TextObject math = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text70"];
        TextObject sci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text71"];
        TextObject Sosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text72"];
       // TextObject general = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text73"];
        TextObject IT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text116"];

        TextObject NBlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text74"];
        TextObject NBlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text75"];
        TextObject NBmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text76"];
        TextObject NBsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text77"];
        TextObject NBSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text78"];
       // TextObject NBgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text79"];
        TextObject NBIT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text117"];

        TextObject SElang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text80"];
        TextObject SElang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];
        TextObject SEmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text82"];
        TextObject SEsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text83"];
        TextObject SESosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text84"];
       // TextObject SEgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text85"];
        TextObject SEIT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text118"];

        TextObject AElang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text86"];
        TextObject AElang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text87"];
        TextObject AEmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text88"];
        TextObject AEsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text89"];
        TextObject AESosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text90"];
       // TextObject AEgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text91"];
        TextObject AEIT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text119"];

        TextObject totlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text92"];
        TextObject totlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text93"];
        TextObject totmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text94"];
        TextObject totsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text95"];
        TextObject totSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text96"];
        //TextObject totgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text97"];
        TextObject totIT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text120"];

        TextObject grlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text98"];
        TextObject grlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text99"];
        TextObject grmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text100"];
        TextObject grsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text101"];
        TextObject grSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text102"];
        //TextObject grgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text103"];
        TextObject grIT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text121"];

        TextObject WECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text104"];
        TextObject AECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text105"];
        TextObject HPECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text106"];

        TextObject DisciplineTerm1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text107"];
        TextObject Suggestion = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text108"];

        strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intStudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
        //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            try
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
            catch { }
        }

        strQry = "exec usp_ExamMarks @type='ResultIX',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
        dsObjgrade = sGetDataset(strQry);
        if (dsObjgrade.Tables[0].Rows.Count > 0)
        {
            try
            {
                SUBlang1.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["vchsubjectname"]);
            }
            catch { }
            try
            {
                SUBlang2.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["vchsubjectname"]);
            }
            catch { }
            try
            {
                //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                SUBmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["vchsubjectname"]);
            }
            catch { }
            try
            {
                SUBsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["vchsubjectname"]);
            }
            catch { }
            try
            {
                SUBSosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["vchsubjectname"]);
            }
            catch { }
            try
            {
                SUBIT.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["vchsubjectname"]);
            }
            catch { }
            try
            {
                lang1.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["PT"]);
            }
            catch { }
            try
            {
                lang2.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["PT"]);
            }
            catch { }
            try
            {
                //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                math.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["PT"]);
            }
            catch { }
            try
            {
                sci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["PT"]);
            }
            catch { }
            try
            {
                Sosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["PT"]);
            }
            catch { }
            try
            {
                //general.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["PT"]);
            }
            catch { }
            try
            {
                IT.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["PT"]);
            }
            catch { }
            try
            {

                NBlang1.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Note Book"]);
            }
            catch { }
            try
            {
                NBlang2.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Note Book"]);
            }
            catch { }
            try
            {
                //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                NBmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Note Book"]);
            }
            catch { }
            try
            {
                NBsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Note Book"]);
            }
            catch { }
            try
            {
                NBSosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Note Book"]);
            }
            catch { }
            try
            {
                //NBgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Note Book"]);
            }
            catch { }
            try
            {
                NBIT.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Note Book"]);
            }
            catch { }
            try
            {

                SElang1.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Sub Enrichment"]);
            }
            catch { }
            try
            {
                SElang2.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Sub Enrichment"]);
            }
            catch { }
            try
            {
                //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                SEmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Sub Enrichment"]);
            }
            catch { }
            try
            {
                SEsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Sub Enrichment"]);
            }
            catch { }
            try
            {
                SESosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Sub Enrichment"]);
            }
            catch { }
            try
            {
                //SEgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Sub Enrichment"]);
            }
            catch { }
            try
            {
                SEIT.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Sub Enrichment"]);
            }
            catch { }
            try
            {

                AElang1.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["HY"]);
            }
            catch { }
            try
            {
                AElang2.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["HY"]);
            }
            catch { }
            try
            {
                //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                AEmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["HY"]);
            }
            catch { }
            try
            {
                AEsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["HY"]);
            }
            catch { }
            try
            {
                AESosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["HY"]);
            }
            catch { }
            try
            {
                //AEgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["HY"]);
            }
            catch { }
            try
            {
                AEIT.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["HY"]);
            }
            catch { }
            try
            {

                totlang1.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Total"]);
            }
            catch { }
            try
            {
                totlang2.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Total"]);
            }
            catch { }
            try
            {
                //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                totmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Total"]);
            }
            catch { }
            try
            {
                totsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Total"]);
            }
            catch { }
            try
            {
                totSosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Total"]);
            }
            catch { }
            try
            {
                //totgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Total"]);
            }
            catch { }
            try
            {
                totIT.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Total"]);
            }
            catch { }
            try
            {

                grlang1.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[0]["Grade"]);
            }
            catch { }
            try
            {
                grlang2.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[1]["Grade"]);
            }
            catch { }
            try
            {
                //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                grmath.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["Grade"]);
            }
            catch { }
            try
            {
                grsci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[3]["Grade"]);
            }
            catch { }
            try
            {
                grSosci.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[4]["Grade"]);
            }
            catch { }
            try
            {
                //grgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Grade"]);
            }
            catch { }
            try
            {
                grIT.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Grade"]);
            }
            catch
            { 
            }
        }

        strQry = "exec usp_ExamMarks @type='CoscholasticGradeIXstd',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            try
            {
                WECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
            }
            catch { }
            try
            {
                AECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
            }
            catch { }
            try
            {
                HPECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
            }
            catch
            { }

        }

        try
        {

            strQry = "exec usp_ExamMarks @type='DisciplineGrade',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                DisciplineTerm1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);

            }
        }
        catch
        {

        }
        try
        {

            strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "'and intExam_id in(select intExam_id from tblExaminationDet where vchExamination_name like 'half%')";
            string remark = sExecuteReader(strQry);
            if (remark == "-2")
            {
                Suggestion.Text = "NA";
            }
            else
            {
                Suggestion.Text = remark;
            }
        }
        catch { }

        crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "'" + ddlStudent.SelectedItem + "'");
        Response.End();
    }
}
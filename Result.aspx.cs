using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
public partial class Result : DBUtility
{
    DataSet dsObj = new DataSet();
    string strQry = string.Empty;
    string strSubjectAll = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["School_id"] = "1";
        //Session["UserType_id"] = "1";
        //Session["User_id"] = "0";
        //Session["Student_id"] = "372";
        //Session["Standard_id"] = "5";
        //Session["Division_id"] = "40";
        //Session["strUserType"] = "1";
        if (!IsPostBack)
        {
            pnlPerson.Visible = false;
            FillSTD();
            Teacher_Students();
            getStudentDataOnlyM();
           // getData();
        }
    }
    protected void getStudentDataOnlyM()
    {
        if (Convert.ToString(Session["UserType_id"]) == "1" || Convert.ToString(Session["UserType_id"]) == "2")
        {
            pnlPerson.Visible = true;
            strQry = "Execute dbo.usp_Profile @command='ShowProfile',@intUser_id='" + Convert.ToString(Session["Student_id"]) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
            //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                lblFather.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                lblMother.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                lblMother.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                lblDOB.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
                lblAddress.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAddress"]);
                lblRoll.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);
                lblRegistration.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intAddmission_id"]);
                lblAdmision.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchapplication_no"]);
                lblDivison.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]) + " / " + Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);

            }

            //strQry = "usp_Result @intstudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    grdResult.DataSource = dsObj;
            //    grdResult.DataBind();
            //}

            strQry = "Declare @str varchar(1000) SELECT @str= coalesce(@str + ',','') +'['+ a.vchsubjectname+']' FROM (select vchsubjectname from tblSubject_Master inner join tblExaminationSchedule on tblExaminationSchedule.intSubject_id=tblSubject_Master.intSubject_id where tblSubject_Master.intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "' and intactive_flg=1) a select rtrim(ltrim(@str))  as subject";
            // strQry = "Declare @str varchar(1000) SELECT @str= coalesce(@str + ',','') +'['+ a.vchsubjectname+']' FROM (select vchsubjectname from tblSubject_Master where intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "' and intactive_flg=1) a select rtrim(ltrim(@str))  as subject";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                strSubjectAll = Convert.ToString(dsObj.Tables[0].Rows[0]["Subject"]);
                strQry = "SELECT * FROM (select vchsubjectname,decMark,vchExamination_name as Exam from tblExam_Mark inner join tblSubject_Master on tblExam_Mark.intsubject_id=tblSubject_Master.intsubject_id inner join tblExaminationDet on tblExam_Mark.intExam_id=tblExaminationDet.intExam_id where tblExam_Mark.intstudent_id='" + Convert.ToString(Session["Student_id"]) + "' and intactive_flg=1) as s PIVOT(SUM(decMark) FOR [vchsubjectname] IN (" + strSubjectAll.Trim() + "))AS pvt";
                //strQry = "SELECT * FROM (select vchsubjectname,decMark,vchExamination_name as Exam from tblExam_Mark inner join tblSubject_Master on tblExam_Mark.intsubject_id=tblSubject_Master.intsubject_id inner join tblExaminationDet on tblExam_Mark.intExam_id=tblExaminationDet.intExam_id where tblExam_Mark.intstudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "' and intactive_flg=1) as s PIVOT(SUM(decMark) FOR [vchsubjectname] IN (" + strSubjectAll.Trim() + "))AS pvt";

                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    grdResult.DataSource = dsObj;
                    grdResult.DataBind();
                }
                else
                {
                    grdResult.DataSource = dsObj;
                    grdResult.DataBind();
                }
            }
            lblSTD.Visible = false;
            ddlSTD.Visible = false;
            lblDIV.Visible = false;
            ddlDIV.Visible = false;
            lblStudName.Visible = false;
            ddlStudent.Visible = false;
        }
    }
    protected void getData()
    {
        if (Convert.ToString(Session["UserType_id"]) == "1" || Convert.ToString(Session["UserType_id"]) == "2")            
        {
            pnlPerson.Visible = true;
            strQry = "Execute dbo.usp_Profile @command='ShowProfile',@intUser_id='" + Convert.ToString(Session["Student_id"]) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
            //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                lblFather.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                lblMother.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                lblMother.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                lblDOB.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
                lblAddress.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAddress"]);
                lblRoll.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);
                lblRegistration.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intAddmission_id"]);
                lblAdmision.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchapplication_no"]);
                lblDivison.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]) + " / " + Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);

            }

            //strQry = "usp_Result @intstudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    grdResult.DataSource = dsObj;
            //    grdResult.DataBind();
            //}

            strQry = "Declare @str varchar(1000) SELECT @str= coalesce(@str + ',','') +'['+ a.vchsubjectname+']' FROM (select vchsubjectname from tblSubject_Master inner join tblExaminationSchedule on tblExaminationSchedule.intSubject_id=tblSubject_Master.intSubject_id where tblSubject_Master.intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "' and intactive_flg=1) a select rtrim(ltrim(@str))  as subject";
           // strQry = "Declare @str varchar(1000) SELECT @str= coalesce(@str + ',','') +'['+ a.vchsubjectname+']' FROM (select vchsubjectname from tblSubject_Master where intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "' and intactive_flg=1) a select rtrim(ltrim(@str))  as subject";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                strSubjectAll = Convert.ToString(dsObj.Tables[0].Rows[0]["Subject"]);
                strQry = "SELECT * FROM (select vchsubjectname,decMark,vchExamination_name as Exam from tblExam_Mark inner join tblSubject_Master on tblExam_Mark.intsubject_id=tblSubject_Master.intsubject_id inner join tblExaminationDet on tblExam_Mark.intExam_id=tblExaminationDet.intExam_id where tblExam_Mark.intstudent_id='" + Convert.ToString(Session["Student_id"]) + "' and intactive_flg=1) as s PIVOT(SUM(decMark) FOR [vchsubjectname] IN (" + strSubjectAll.Trim() + "))AS pvt";            
                //strQry = "SELECT * FROM (select vchsubjectname,decMark,vchExamination_name as Exam from tblExam_Mark inner join tblSubject_Master on tblExam_Mark.intsubject_id=tblSubject_Master.intsubject_id inner join tblExaminationDet on tblExam_Mark.intExam_id=tblExaminationDet.intExam_id where tblExam_Mark.intstudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "' and intactive_flg=1) as s PIVOT(SUM(decMark) FOR [vchsubjectname] IN (" + strSubjectAll.Trim() + "))AS pvt";

                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    grdResult.DataSource = dsObj;
                    grdResult.DataBind();
                }
                else
                {
                    grdResult.DataSource = dsObj;
                    grdResult.DataBind();
                }
            }
            lblSTD.Visible = false;
            ddlSTD.Visible = false;
            lblDIV.Visible = false;
            ddlDIV.Visible = false;
            lblStudName.Visible = false;
            ddlStudent.Visible = false;
        }
        else if (Convert.ToString(Session["UserType_id"]) == "3")
        {
           
            // strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(Session["Student_id"]) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
            strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
          //  strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intStudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
            lblFather.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
            lblMother.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
            lblMother.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
            lblDOB.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
            lblAddress.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAddress"]);
            lblRoll.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);
            lblRegistration.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intAddmission_id"]);
            lblAdmision.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchapplication_no"]);
            lblDivison.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]) + " / " + Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);

        }

        //strQry = "usp_Result @intstudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
        //dsObj = sGetDataset(strQry);
        //if (dsObj.Tables[0].Rows.Count > 0)
        //{
        //    grdResult.DataSource = dsObj;
        //    grdResult.DataBind();
        //}

        //strQry = "Declare @str varchar(1000) SELECT @str= coalesce(@str + ',','') +'['+ a.vchsubjectname+']' FROM (select vchsubjectname from tblSubject_Master where intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "' and intactive_flg=1) a select rtrim(ltrim(@str))  as subject";
        strQry = "Declare @str varchar(1000) SELECT @str= coalesce(@str + ',','') +'['+ a.vchsubjectname+']' FROM (select vchsubjectname from tblSubject_Master inner join tblExaminationSchedule on tblExaminationSchedule.intSubject_id=tblSubject_Master.intSubject_id where tblSubject_Master.intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "' and intactive_flg=1) a select rtrim(ltrim(@str))  as subject";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            strSubjectAll = Convert.ToString(dsObj.Tables[0].Rows[0]["Subject"]);
            //strQry = "SELECT * FROM (select vchsubjectname,decMark,vchExamination_name as Exam from tblExam_Mark inner join tblSubject_Master on tblExam_Mark.intsubject_id=tblSubject_Master.intsubject_id inner join tblExaminationDet on tblExam_Mark.intExam_id=tblExaminationDet.intExam_id where tblExam_Mark.intstudent_id='" + Convert.ToString(Session["Student_id"]) + "' and intactive_flg=1) as s PIVOT(SUM(decMark) FOR [vchsubjectname] IN (" + strSubjectAll.Trim() + "))AS pvt";            
            strQry = "SELECT * FROM (select vchsubjectname,decMark,vchExamination_name as Exam from tblExam_Mark inner join tblSubject_Master on tblExam_Mark.intsubject_id=tblSubject_Master.intsubject_id inner join tblExaminationDet on tblExam_Mark.intExam_id=tblExaminationDet.intExam_id where tblExam_Mark.intstudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "' and intactive_flg=1) as s PIVOT(SUM(decMark) FOR [vchsubjectname] IN (" + strSubjectAll.Trim() + "))AS pvt";

            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grdResult.DataSource = dsObj;
                grdResult.DataBind();
            }
            else
            {
                grdResult.DataSource = dsObj;
                grdResult.DataBind();
            }
        }
        }      
        
    }
    public void FillResult()
    {
        try
        {

            strQry = "";
            if (ddlStudent.SelectedValue == "-1")
            {
                //strQry = "exec [usp_getAttendance]  @type='AllStudentAttendance' ,@year='" + Convert.ToString(ddlYear.SelectedValue) + "',@month='" + Convert.ToString(ddlMonth.SelectedValue) + "',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@DivId='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            }
            else
            {
                //strQry = "exec [usp_getAttendance]  @type='AllStudentAttendance' ,@year='" + Convert.ToString(ddlYear.SelectedValue) + "',@month='" + Convert.ToString(ddlMonth.SelectedValue) + "',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@DivId='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
                strQry = strQry + ",@intStudentid='" + Convert.ToString(ddlStudent.SelectedValue) + "'";
            }

            dsObj = new DataSet();
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grdResult.DataSource = dsObj;
                grdResult.DataBind();
            }
            else
            {
                grdResult.DataSource = null;
                grdResult.DataBind();
            }
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
    public void FillSTD()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "3")
            {
                strQry = "exec [usp_getAttendance] @type='FillStd',@TeacherId='" + Convert.ToString(Session["User_id"]) + "',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
                FillDIV();
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
                FillDIV();
            }

        }
        catch
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Result.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        pnlPerson.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDIV();       
    }
    public void FillDIV()
    {
        try
        {
            strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlDIV, strQry, "vchDivisionName", "intDivision_id");
            FillStudent();
        }
        catch
        {

        }
    }
    public void FillStudent()
    {
        try
        {
            strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

            sBindDropDownList(ddlStudent, strQry, "Name", "intStudent_id");           
        }
        catch
        {

        }
    }
    protected void ddlDIV_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStudent();
    }
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["UserType_id"]) == "1" || Convert.ToString(Session["UserType_id"]) == "2" || Convert.ToString(Session["UserType_id"]) == "3")
        {
            if (ddlStudent.SelectedValue != "-1" && ddlStudent.SelectedValue != "0")
            {
                pnlPerson.Visible = true;
                getData();

            }
            else if (ddlStudent.SelectedValue == "-1")
            {
                pnlPerson.Visible = true;
                getData();
            }
            else
            {
                pnlPerson.Visible = true;
                getData();
            }
        }
        else  if (Convert.ToString(Session["UserType_id"]) == "5")
        {
            if (ddlStudent.SelectedValue != "-1" && ddlStudent.SelectedValue != "0")
            {
                pnlPerson.Visible = true;
                FillAdmResult();
            }
            else if (ddlStudent.SelectedValue == "-1")
            {
                pnlPerson.Visible = true;
                FillAdmResult();
            }
            else
            {
                pnlPerson.Visible = true;
                FillAdmResult();
            }
        }
    }
    public void FillAdmResult()
    {
        try
        {
            strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                lblFather.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                lblMother.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                lblMother.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                lblDOB.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
                lblAddress.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAddress"]);
                lblRoll.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);
                lblRegistration.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intAddmission_id"]);
                lblAdmision.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchapplication_no"]);
                lblDivison.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]) + " / " + Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);

            }
            //strQry = "Declare @str varchar(1000) SELECT @str= coalesce(@str + ',','') +'['+ a.vchsubjectname+']' FROM (select vchsubjectname from tblSubject_Master where intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "' and intactive_flg=1) a select rtrim(ltrim(@str))  as subject";
            //strQry = "Declare @str varchar(1000) SELECT @str= coalesce(@str + ',','') +'['+ a.vchsubjectname+']' FROM (select vchsubjectname from tblSubject_Master where intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "' and intactive_flg=1) a select rtrim(ltrim(@str))  as subject";
            strQry = "Declare @str varchar(1000) SELECT @str= coalesce(@str + ',','') +'['+ a.vchsubjectname+']' FROM (select vchsubjectname from tblSubject_Master  inner join tblExaminationSchedule on tblExaminationSchedule.intSubject_id=tblSubject_Master.intSubject_id where tblSubject_Master.intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "' and intactive_flg=1) a select rtrim(ltrim(@str))  as subject";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                strSubjectAll = Convert.ToString(dsObj.Tables[0].Rows[0]["Subject"]);
                //strQry = "SELECT * FROM (select vchsubjectname,decMark,vchExamination_name as Exam from tblExam_Mark inner join tblSubject_Master on tblExam_Mark.intsubject_id=tblSubject_Master.intsubject_id inner join tblExaminationDet on tblExam_Mark.intExam_id=tblExaminationDet.intExam_id where tblExam_Mark.intstudent_id='" + Convert.ToString(Session["Student_id"]) + "' and intactive_flg=1) as s PIVOT(SUM(decMark) FOR [vchsubjectname] IN (" + strSubjectAll.Trim() + "))AS pvt";            
                strQry = "SELECT * FROM (select vchsubjectname,decMark,vchExamination_name as Exam from tblExam_Mark inner join tblSubject_Master on tblExam_Mark.intsubject_id=tblSubject_Master.intsubject_id inner join tblExaminationDet on tblExam_Mark.intExam_id=tblExaminationDet.intExam_id where tblExam_Mark.intstudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "' and intactive_flg=1) as s PIVOT(SUM(decMark) FOR [vchsubjectname] IN (" + strSubjectAll.Trim() + "))AS pvt";

                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    grdResult.DataSource = dsObj;
                    grdResult.DataBind();
                }
                else
                {
                    grdResult.DataSource = dsObj;
                    grdResult.DataBind();
                }
            }
        }
        catch
        {

        }
    }
}
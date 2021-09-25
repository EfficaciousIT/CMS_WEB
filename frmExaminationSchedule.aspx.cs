using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Globalization;

public partial class frmExaminationSchedule : DBUtility
{
    DataSet dsObj = new DataSet();
    DataSet dsCalender = new DataSet();
    string strQry = string.Empty;
    bool boolFillExam;
    DateTime nextDate;
    string strExaminationDate = string.Empty;
    string strDivision_id = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lblTitle = new Label();
        //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
        //lblTitle.Visible = true;
        //lblTitle.Text = "Examination Schedule";
        if (!IsPostBack)
        {
            Session["ExamID"] = "";
            //fillExaminationSchedule();
            //FillCalender();
            fillExam();
            fillExamTypenew();
            ViewState["Edit"] = "No";
        }
    }
    protected void fillExamTypenew()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ExamSubjectLink @command='ExamType',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpExamType, strQry, "ExamTypeName", "intExamType_id");

        }
        catch
        {

        }
    }
    protected void fillExaminationSchedule()
    {
        try
        {           

            if (drpAdmStandard.Visible == true)
            {
                strQry = "usp_Examination @command='ExaminationAdmin',@intstandard_id='" + Convert.ToString(drpAdmStandard.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intExam_id='" + Convert.ToString(Session["ExamID"]) + "'";
            }
            else
            {
                strQry = "usp_Examination @command='ExaminationSchedule',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@intDivision_id='" + Convert.ToString("0") + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intExam_id='" + Convert.ToString(Session["ExamID"]) + "'";
            }

            dsObj = sGetDataset(strQry);
            grdExamination.DataSource = dsObj;
            grdExamination.DataBind();

            if (dsObj == null)
            {
                grdExamination.DataSource = null;
                grdExamination.DataBind();
            }
            else
            {
                grdExamination.DataSource = dsObj;
                grdExamination.DataBind();
            }

            if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                grdExamination.Columns[0].Visible = false;
                //grdExamination.Columns[1].Visible = true;
                //grdExamination.Columns[2].Visible = true;
                TabContainer1.Tabs[1].Visible = true;
                TabContainer1.Tabs[0].Visible = true;
                TabContainer1.Tabs[2].Visible = false;
                lbladmStandard.Visible = true;
                drpAdmStandard.Visible = true;
            }
            else
            {
                grdExamination.Columns[0].Visible = false;
                //grdExamination.Columns[1].Visible = false;
                //grdExamination.Columns[2].Visible = false;
                TabContainer1.Tabs[0].Visible = true;
                TabContainer1.Tabs[1].Visible = false;
                TabContainer1.Tabs[2].Visible = false;
                lbladmStandard.Visible = false;
                drpAdmStandard.Visible = false;
            }
        }
        catch
        {

        }    
    }

    protected void FillCalender()
    {        
        dsObj = GetCurrentMonthData();
    }
    public DataSet GetCurrentMonthData()
    {
        try
        {

            strQry = string.Empty;
            if (drpAdmStandard.Visible == true)
            {
                strQry = "usp_Examination @command='ExaminationAdmin',@intstandard_id='" + Convert.ToString(drpAdmStandard.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intExam_id='" + Convert.ToString(Session["ExamID"]) + "'";
            }
            else
            {
                strQry = "usp_Examination @command='ExaminationScheduleCalender',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@intDivision_id='" + Convert.ToString(Session["Division_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intExam_id='" + Convert.ToString(Session["ExamID"]) + "'";
            }
            
            dsCalender = sGetDataset(strQry);
            return dsCalender;
        }
        catch (Exception)
        {
            return dsCalender;
        }
    }
    protected void fillExam()
    {
        if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
        {
            //grdExamination.Columns[0].Visible = false;
            //grdExamination.Columns[1].Visible = true;
            //grdExamination.Columns[2].Visible = true;
            TabContainer1.Tabs[1].Visible = true;
            TabContainer1.Tabs[0].Visible = true;
            TabContainer1.Tabs[2].Visible = false;
            lbladmStandard.Visible = true;
            drpAdmStandard.Visible = true;
            
        }
        else
        {
            grdExamination.Columns[0].Visible = false;
            grdExamination.Columns[7].Visible = false;
            grdExamination.Columns[8].Visible = false;
            TabContainer1.Tabs[0].Visible = true;
            TabContainer1.Tabs[1].Visible = false;
            TabContainer1.Tabs[2].Visible = false;
            lbladmStandard.Visible = false;
            drpAdmStandard.Visible = false;
        }

        strQry = "usp_Examination @command='selectExam',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        boolFillExam = sBindDropDownList(drpSelExam, strQry, "vchExamination_name", "intExam_id");

        strQry = "usp_Examination @command='selectExam',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        boolFillExam = sBindDropDownList(drpExam, strQry, "vchExamination_name", "intExam_id");

        strQry = "usp_Examination @command='standard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        boolFillExam = sBindDropDownList(drpStandard, strQry, "vchStandard_name", "intstandard_id");

        strQry = "usp_Examination @command='standard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        boolFillExam = sBindDropDownList(drpAdmStandard, strQry, "vchStandard_name", "intstandard_id");


    }

    protected void drpSelExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["ExamID"] = "";
        Session["ExamID"] = drpSelExam.SelectedValue.Trim();
        if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
        {
            GetCurrentMonthData();
            fillExaminationSchedule();
        }
        else
        {
            GetCurrentMonthData();
            fillExaminationSchedule();
        }
        
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["ExamID"]) != "")
            {
                if (e.Day.Date.DayOfWeek.ToString() == "Sunday")
                {
                    e.Cell.Style["background-color"] = "#F14C57";
                    e.Cell.ForeColor = System.Drawing.Color.White;
                    //e.Cell.Font.Bold = true;
                    return;
                }
                if (dsCalender != null)
                    //if (dsCalender != null && dsCalender.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsCalender.Tables)
                        //foreach (DataRow dr in dsCalender.Tables[0].Rows)
                    {
                        strExaminationDate = Convert.ToString(dr["dtExamination_date"]);

                        DateTime dt = DateTime.ParseExact(strExaminationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        //DateTime dt = DateTime.ParseExact(strExaminationDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                        if (dt == e.Day.Date)
                        {
                            e.Cell.BackColor = System.Drawing.Color.SkyBlue;
                            e.Cell.ToolTip = (string)dr["vchSubjectName"];
                            Label lbl = new Label();
                            lbl.Text = (string)dr["vchSubjectName"];
                        }
                    }
                }
            }
            else
            {
                if (e.Day.Date.DayOfWeek.ToString() == "Sunday")
                {
                    e.Cell.Style["background-color"] = "#F14C57";
                    e.Cell.ForeColor = System.Drawing.Color.White;
                    //e.Cell.Font.Bold = true;
                    return;
                }
            }
            //Fillgrid();
        }
        catch (Exception)
        {

        }
    }
    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "usp_Examination @command='Division',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue.Trim()) + "'";
        boolFillExam = sBindDropDownList(drpDivision, strQry, "vchDivisionName", "intDivision_id");

        strQry = "usp_Examination @command='Subject',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue.Trim()) + "',@intExam_id='" + drpExam.SelectedValue.Trim() + "',@intExamType_id='" + drpExamType.SelectedValue.Trim() + "'";
        boolFillExam = sBindDropDownList(drpSubject, strQry, "vchSubjectName", "intSubject_id");
    }
    protected void drpDivision_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            int i = 0;

            if (Convert.ToString(ViewState["Edit"]) == "Yes")
            {
                DateTime dt = DateTime.ParseExact(txtExaminationDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                strExaminationDate = Convert.ToDateTime(dt).ToString("M/dd/yyyy");

                strQry = "usp_Examination @command='Update',@intExam_id='" + drpExam.SelectedValue.Trim() + "',@intstandard_id='" + drpStandard.SelectedValue.Trim() + "',@intDivision_id='0',@intSubject_id='" + drpSubject.SelectedValue.Trim() + "',@dtExamination_date='" + strExaminationDate.Trim() + "',@dtExamination_FromTime='" + txtFromTime.Text.Trim() + "',@dtExamination_ToTime='" + txtToDt.Text.Trim() + "',@intExamSchedule_id='" + Convert.ToString(ViewState["strID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intExamType_id='" + drpExamType.SelectedValue + "'";

                i = sExecuteQuery(strQry);

                if (i > 0)
                {
                    fillExaminationSchedule();
                    drpStandard.SelectedIndex = 0;
                    drpSubject.SelectedIndex = 0;
                    drpExamType.SelectedValue = "0";
                    drpDivision.SelectedIndex = 0;
                    drpExam.SelectedIndex = 0;
                    txtExaminationDate.Text = "";
                    txtFromTime.Text = "";
                    txtToDt.Text = "";
                    btnSubmit.Text = "Submit";
                    ViewState["Edit"] = "No";
                    TabContainer1.ActiveTabIndex = 1;
                    MessageBox("Examination Details updated successfully");
                }
                else
                {
                    MessageBox("Examination schedule already exists !!!!");
                }
            }
            else
            {
                DateTime dt = DateTime.ParseExact(txtExaminationDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                strExaminationDate = Convert.ToDateTime(dt).ToString("M/dd/yyyy");

                strQry = "usp_Examination @command='Insert',@intExam_id='" + drpExam.SelectedValue.Trim() + "',@intstandard_id='" + drpStandard.SelectedValue.Trim() + "',@intDivision_id='0',@intSubject_id='" + drpSubject.SelectedValue.Trim() + "',@dtExamination_date='" + strExaminationDate.Trim() + "',@dtExamination_FromTime='" + txtFromTime.Text.Trim() + "',@dtExamination_ToTime='" + txtToDt.Text.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intExamType_id='" + drpExamType.SelectedValue + "'";

                i = sExecuteQuery(strQry);

                if (i > 0)
                {
                    //drpStandard.SelectedIndex = 0;
                    drpSubject.SelectedIndex = 0;
                    // drpExamType.SelectedValue = "0";
                    drpDivision.SelectedIndex = 0;
                    //drpExam.SelectedIndex = 0;
                    txtExaminationDate.Text = "";
                    //txtFromTime.Text = "";
                    //txtToDt.Text = "";
                    ViewState["Edit"] = "No";
                    TabContainer1.ActiveTabIndex = 1;
                    MessageBox("Examination schedule successfully");
                }
                else
                {
                    MessageBox("Examination schedule already exists !!!!");
                }
            }

            //strQry = "usp_Examination @command='Division',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue.Trim()) + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
            //    {
            //        strDivision_id = Convert.ToString(dsObj.Tables[0].Rows[k]["intDivision_id"]);




            //    }


            //}

        
        }
        catch
        {
        }


    }
    public void MessageBox(string msg)
    {
        try
        {
            string script = "alert(\"" + msg + "\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

        }
        catch (Exception)
        {
            // return msg;
        }
    }

    protected void grdExamination_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string strID = Convert.ToString(grdExamination.DataKeys[e.NewEditIndex].Value);

        ViewState["strID"] = strID;

        strQry = "exec usp_Examination @command='Edit',@intExamSchedule_id='" + strID.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            ViewState["Edit"] = "Yes";
            TabContainer1.ActiveTabIndex = 2;
            drpExam.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intExam_id"]);
            //drpExam.Enabled = false;
            drpExamType.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intExamType_id"]);
            //drpExamType.Enabled = false;
            drpStandard.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
            //drpStandard.Enabled = false;
            strQry = "usp_Examination @command='AllSubjects',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue.Trim()) + "'";
            boolFillExam = sBindDropDownList(drpSubject, strQry, "vchSubjectName", "intSubject_id");

            drpSubject.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intSubject_id"]);
            //drpSubject.Enabled = false;
            txtExaminationDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtExamination_date"]);
            txtFromTime.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtExamination_FromTime"]).ToString("HH:mm tt");
            txtToDt.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtExamination_ToTime"]).ToString("HH:mm tt");
            btnSubmit.Text = "Update";
        }
    }
    protected void grdExamination_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strID = Convert.ToString(grdExamination.DataKeys[e.RowIndex].Value);
        
        int k = 0;

        strQry = "usp_Examination @command='Delete',@intExamSchedule_id='" + Convert.ToString(strID) + "'";

        k = sExecuteQuery(strQry);
        if (k > 0)
        {
            
            MessageBox("Exam Deleted Successfully");
            fillExaminationSchedule();
        }
    }
    protected void drpSubject_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdExamination_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{           
        //    //string subject = Convert.ToString(ViewState["intsubject_id"]);
        //    Session.Add("intStandard_id", Convert.ToString(drpAdmStandard.SelectedValue));
        //    LinkButton lnkSub = (LinkButton)e.Row.FindControl("lnkSubject");
        //    lnkSub.Attributes.Add("onclick", "window.open('Syllabus.aspx?intStandard_id=" + Session["intStandard_id"] + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");
        //}
    }

    protected void drpAdmStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpSelExam.ClearSelection();
    }
}

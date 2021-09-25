using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class newMasterPage : System.Web.UI.MasterPage
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    SqlDataAdapter daObj = new SqlDataAdapter();
    string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["esms"].ConnectionString;
    SqlConnection sqlCon;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlCon = new SqlConnection(strCon);

        

        //Session["Reset"] = true;
        //Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
        //SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
        //int timeout = 1 * 1000 * 1800;
        ////int timeout = (int)section.Timeout.TotalMinutes * 1000 * 10;
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", "SessionExpireAlert(" + timeout + ");", true);
        if (Convert.ToString(Session["School_id"]) != "")
        {
            if (Convert.ToString(Session["strUserType"]) == "1")
            {
                if ((Convert.ToString(Session["Student_id"]) == "374") || (Convert.ToString(Session["Student_id"]) == "369") || (Convert.ToString(Session["Student_id"]) == "370"))
                {
                    //if ((Convert.ToString(Session["Student_id"]) == "374") || (Convert.ToString(Session["Student_id"]) == "369") || (Convert.ToString(Session["Student_id"]) == "370"))

                    
                    

                    frmMydiary.Visible = false;
                    frmSelfProfile.Visible = false;
                    changepass.Visible = false;
                    Parentlog.Visible = false;
                    Studentlog.Visible = false;
                    Notification.Visible = false;
                    DownloadApp.Visible = false;
                    PlanLeave.Visible = true;
                    frmNoticeBoard.Visible = false;
                    Group.Visible = false;
                    Member.Visible = false;
                    MsgSend.Visible = false;
                    syllabus.Visible = false;
                    Result.Visible = false;
                    frmBookStatus.Visible = false;
                    frmBookIssue.Visible = false;
                    frmExaminationSchedule.Visible = false;
                    frmLectureSchedule.Visible = false;
                    frmabsent.Visible = false;
                    frmlate.Visible = false;
                    frmattendance.Visible = false;
                    frmcard.Visible = false;
                    frmTeacherRemark.Visible = false;
                    frmcalender.Visible = true;
                    frmholiday.Visible = false;
                    frmvcation.Visible = false;
                    frmtraining.Visible = false;
                    StaffTimetable.Visible = false;
                    frmSelfAttendance.Visible = false;
                    frmStudentAttendance.Visible = false;
                    frmTeacherAttendance.Visible = false;

                    frmselflate.Visible = false;
                    frmTeacherLate.Visible = false;
                    frmstudentLate.Visible = false;

                    frmselfAbsent.Visible = false;
                    frmTeacherAbsent.Visible = false;
                    frmTeacherAbsent.Visible = false;

                    frmselfAbsent.Visible = false;
                    frmstudentabsent.Visible = false;
                    frmTeacherAbsent.Visible = false;

                    frmViewRemark.Visible = false;
                    frmTeacherRemarkEntry.Visible = false;

                    frmListOfStudTkBusService.Visible = false;
                    frmTripwiseStudentRpt.Visible = false;
                    frmPreSchoAbseBus.Visible = false;

                    frmSelfProfile.Visible = true;
                    //  frmStudentProfile.Visible = false;
                    frmcardAssignment.Visible = false;
                    //frmTeacherProfile.Visible = false;
                    frmTransport.Visible = false;
                    frmSelfProfile.HRef = "frmnewStudentProfile.aspx";
                    frmTransport.Visible = false;
                    frmMasterEntries.Visible = false;
                    // frmStudentProfile.Visible = false;
                    // frmTeacherProfile.Visible = false;
                    frmBusPayment.Visible = false;
                    frmBusService.Visible = false;
                    frmNoticeBoard.Visible = true;
                    Studentlog.Visible = false;
                    Parentlog.Visible = false;
                    frmPaStudentProfile.Visible = false;
                    frmLiStudentProfile.Visible = false;
                    frmLiParentProfile.Visible = false;
                    frmLiTeacherProfile.Visible = false;
                    payment.Visible = false;
                    frmSelfProfile.Visible = false;
                    admission.Visible = false;
                    report.Visible = false;
                }
                else
                {
                    Notification.Visible = false;
                    DownloadApp.Visible = false;
                    frmMydiary.Visible = true;
                    frmBookStatus.Visible = false;
                    frmBookIssue.Visible = true;
                    PlanLeave.Visible = true;
                    frmExaminationSchedule.Visible = true;
                    frmLectureSchedule.Visible = true;
                    frmabsent.Visible = true;
                    frmlate.Visible = true;
                    frmattendance.Visible = true;
                    frmcard.Visible = true;
                    frmTeacherRemark.Visible = false;
                    frmcalender.Visible = true;
                    frmholiday.Visible = true;
                    frmvcation.Visible = true;
                    frmtraining.Visible = true;
                    StaffTimetable.Visible = false;
                    frmSelfAttendance.Visible = false;
                    frmStudentAttendance.Visible = false;
                    frmTeacherAttendance.Visible = false;

                    frmselflate.Visible = false;
                    frmTeacherLate.Visible = false;
                    frmstudentLate.Visible = false;

                    frmselfAbsent.Visible = false;
                    frmTeacherAbsent.Visible = false;
                    frmTeacherAbsent.Visible = false;

                    frmselfAbsent.Visible = false;
                    frmstudentabsent.Visible = false;
                    frmTeacherAbsent.Visible = false;

                    frmViewRemark.Visible = false;
                    frmTeacherRemarkEntry.Visible = false;

                    frmListOfStudTkBusService.Visible = false;
                    frmTripwiseStudentRpt.Visible = false;
                    frmPreSchoAbseBus.Visible = false;

                    frmSelfProfile.Visible = true;
                    //  frmStudentProfile.Visible = false;
                    frmcardAssignment.Visible = false;
                    //frmTeacherProfile.Visible = false;
                    frmTransport.Visible = false;
                    frmSelfProfile.HRef = "frmnewStudentProfile.aspx";
                    frmTransport.Visible = false;
                    frmMasterEntries.Visible = false;
                    // frmStudentProfile.Visible = false;
                    // frmTeacherProfile.Visible = false;
                    frmBusPayment.Visible = false;
                    frmBusService.Visible = false;
                    frmNoticeBoard.Visible = true;
                    Studentlog.Visible = true;
                    Parentlog.Visible = false;
                    frmPaStudentProfile.Visible = false;
                    frmLiStudentProfile.Visible = false;
                    frmLiParentProfile.Visible = false;
                    frmLiTeacherProfile.Visible = false;
                    payment.Visible = false;
                    admission.Visible = false;
                    report.Visible = false;
                }


                //  payment.Visible = false;
            }
            else if (Convert.ToString(Session["strUserType"]) == "2")
            {
                frmMydiary.Visible = true;
                frmBookStatus.Visible = false;
                frmBookIssue.Visible = true;
                frmExaminationSchedule.Visible = true;
                mailAttendance.Visible = true;
                frmabsent.Visible = true;
                frmattendance.Visible = true;
                StaffTimetable.Visible = false;
                frmcard.Visible = true;
                PlanLeave.Visible = true;
                frmTeacherRemark.Visible = false;
                frmcalender.Visible = true;
                frmholiday.Visible = true;
                frmvcation.Visible = true;
                frmtraining.Visible = true;
                frmmainleave.Visible = true;
                frmleave.HRef = "FrmPareLeavAppro.aspx";
                frmabsent.Visible = true;
                frmattendance.Visible = true;
                frmcard.Visible = true;
                frmTeacherRemark.Visible = false;
                frmcalender.Visible = true;
                frmholiday.Visible = true;
                frmvcation.Visible = true;
                frmtraining.Visible = true;
                frmSelfAttendance.Visible = false;
                frmStudentAttendance.Visible = false;
                frmTeacherAttendance.Visible = false;
                frmselflate.Visible = false;
                frmTeacherLate.Visible = false;
                frmstudentLate.Visible = false;
                frmselfAbsent.Visible = false;
                frmTeacherAbsent.Visible = false;
                frmTeacherAbsent.Visible = false;
                frmselfAbsent.Visible = false;
                frmstudentabsent.Visible = false;
                frmTeacherAbsent.Visible = false;
                frmViewRemark.Visible = true;
                frmTeacherRemarkEntry.Visible = false;
                frmListOfStudTkBusService.Visible = false;
                frmTripwiseStudentRpt.Visible = false;
                frmPreSchoAbseBus.Visible = false;
                frmSelfProfile.Visible = true;
                frmcardAssignment.Visible = false;
                //  frmStudentProfile.HRef = "frmStudentProfile.aspx";
                // frmStudentProfile.Visible = true;
                frmSelfProfile.HRef = "frmParentsDetails.aspx";
                frmStandard.Visible = false;
                frmDivision.Visible = false;
                frmTransport.Visible = false;
                frmMasterEntries.Visible = false;
                // frmStudentProfile.Visible = false;
                // frmTeacherProfile.Visible = false;
                frmBusPayment.Visible = true;
                frmBusService.Visible = true;
                frmNoticeBoard.Visible = true;
                frmBusPayment.HRef = "frmBus_ser_reqby_pare.aspx";
                frmViewRemark.Visible = false;
                frmViewRemarkP.Visible = true;
                frmPaStudentProfile.HRef = "frmStudentProfile.aspx?successMessage=" + Session["Student_id"] + "";
                frmLiStudentProfile.Visible = false;
                frmLiParentProfile.Visible = false;
                frmLiTeacherProfile.Visible = false;
                admission.Visible = false;
                report.Visible = false;

            }

            else if (Convert.ToString(Session["strUserType"]) == "5")
            {
                frmMydiary.Visible = false;
                frmBookStatus.Visible = true;
                frmExaminationSchedule.Visible = true;
                //BMaster.Visible = true;
                frmmainleave.Visible = true;
                frmleave.HRef = "frmTeacherLeaveMenu.aspx";
                frmstudentTeacherLeave.HRef = "FrmAdminLeavAppro.aspx";
                frmTechRemark.HRef = "";
                frmSelfAttendance.Visible = true;
                frmStudentAttendance.Visible = true;
                frmTeacherAttendance.Visible = true;
                PlanLeave.Visible = false;
                frmattendance.Visible = true;
                StaffTimetable.Visible = false;
                frmselfAbsent.Visible = true;
                frmstudentabsent.Visible = true;
                frmTeacherAbsent.Visible = true;
                frmabsent.Visible = true;
                frmselflate.Visible = true;
                frmstudentLate.Visible = true;
                frmTeacherLate.Visible = true;
                frmlate.Visible = true;
                mailAttendance.Visible = true;
                frmTeacherRemark.Visible = false;
                frmTeacherRemarkEntry.Visible = false;
                frmViewRemark.Visible = true;
                frmselfLeave.Visible = true;
                frmstudentLeave.Visible = true;
                frmListOfStudTkBusService.Visible = true;
                frmTripwiseStudentRpt.Visible = true;
                frmPreSchoAbseBus.Visible = true;
                frmSelfProfile.Visible = false;
                frmcardAssignment.Visible = true;
                // frmSelfProfile.HRef = "FrmTeacherProfile.aspx";
                // frmStudentProfile.HRef = "frmAdmListStudentDetails.aspx";
                // frmStudentProfile.Visible = true;
                frmholiday.Visible = true;
                frmcalender.Visible = true;
                frmvcation.Visible = true;
                frmtraining.Visible = true;
                frmTransport.Visible = true;
                frmMasterEntries.Visible = true;
                // frmStudentProfile.Visible = true;
                //frmTeacherProfile.Visible = true;
                frmBusPayment.Visible = true;
                frmBusService.Visible = false;
                frmNoticeBoard.Visible = true;
                frmNoticeBoard.Visible = true;
                frmPaStudentProfile.Visible = false;
                frmLiStudentProfile.Visible = true;
                frmLiParentProfile.Visible = true;
                frmLiTeacherProfile.Visible = true;
                payment.Visible = false;
                admission.Visible = true;

                if (Convert.ToString(Session["Student_id"]) == "452")
                {
                    mailAttendance.Visible = false;
                    frmmainleave.Visible = false;
                    frmcalender.Visible = false;
                    services.Visible = false;
                    frmMessage.Visible = false;
                    payment.Visible = false;
                    mainprofile.Visible = false;
                    Setting.Visible = false;
                    payment.Visible = false;
                    frmTransport.Visible = false;
                }
                
                
                
            }
            else if (Convert.ToString(Session["strUserType"]) == "3")
            {
                frmMydiary.Visible = true;
                frmBookIssue.Visible = false;
                frmBookStatus.Visible = false;
                frmExaminationSchedule.Visible = false;
                frmmainleave.Visible = true;
                frmleave.HRef = "frmTeacherLeaveMenu.aspx";
                frmstudentTeacherLeave.HRef = "frmTeachLeavAppro.aspx";
                frmTechRemark.HRef = "";
                frmSelfAttendance.Visible = true;
                frmStudentAttendance.Visible = true;
                frmTeacherAttendance.Visible = false;
                frmselfAbsent.Visible = true;
                StaffTimetable.Visible = true;
                frmstudentabsent.Visible = true;
                frmTeacherAbsent.Visible = false;
                frmSelfAttendance.Visible = true;
                frmStudentAttendance.Visible = true;
                PlanLeave.Visible = false;
                frmabsent.Visible = true;
                frmselflate.Visible = true;
                frmstudentLate.Visible = true;
                frmTeacherLate.Visible = false;
                frmlate.Visible = true;
                mailAttendance.Visible = true;
                frmTeacherRemark.Visible = false;
                frmTeacherRemarkEntry.Visible = false;
                frmViewRemark.Visible = true;
                frmselfLeave.Visible = true;
                frmstudentLeave.Visible = true;
                frmListOfStudTkBusService.Visible = true;
                frmTripwiseStudentRpt.Visible = true;
                frmPreSchoAbseBus.Visible = true;
                frmSelfProfile.Visible = true;
                frmSelfProfile.HRef = "FrmTeacherProfile.aspx?successMessage=" + Session["user_id"] + "";
                //  frmStudentProfile.HRef = "frmStudentProfile.aspx";
                //  frmStudentProfile.Visible = true;
                frmcardAssignment.Visible = false;
                //frmTeacherProfile.Visible = true;
                frmcalender.Visible = true;
                frmholiday.Visible = true;
                frmvcation.Visible = true;
                frmtraining.Visible = true;
                //frmTeacherProfile.Visible = false;
                frmStandard.Visible = false;
                frmDivision.Visible = false;
                frmTransport.Visible = false;
                frmMasterEntries.Visible = false;
                // frmStudentProfile.Visible = false;
                // frmTeacherProfile.Visible = false;
                frmBusPayment.Visible = false;
                frmBusPayment.Visible = false;
                frmBusService.Visible = false;
                frmNoticeBoard.Visible = true;
                frmPaStudentProfile.Visible = false;
                frmLiStudentProfile.Visible = true;
                frmLiParentProfile.Visible = true;
                frmLiTeacherProfile.Visible = false;
                payment.Visible = false;
                admission.Visible = false;
                report.Visible = false;

                //try
                //{
                //    strQry = "usp_UserRights @command='rights',@intUser_id='" + Convert.ToString(Session["User_id"]) + "'";
                //    daObj = new SqlDataAdapter(strQry, sqlCon);
                //    daObj.Fill(dsObj);
                //    if (dsObj.Tables[0].Rows.Count > 0)
                //    {
                //        for (int j = 0; j < dsObj.Tables[0].Rows.Count; j++)
                //        {
                //            Control Subctrl = this.Page.Master.FindControl(Convert.ToString(dsObj.Tables[0].Rows[j]["vchformid"]));
                //            Subctrl.Visible = true;
                //            //mailAttendance.Visible = true;
                //        }
                //    }
                //}
                //catch 
                //{

                // }
                frmattendance.Visible = true;
                frmSelfAttendance.Visible = true;
                frmStudentAttendance.Visible = true;

            }


            if (Session["userstatus"] == "student" || Session["userstatus"] == "teacher")
            {
                payment.Visible = false;
            }
            if (Session["userstatus"] == "parent")
            {
                payment.Visible = true;
            }
            if (Session["userstatus"] == "admin")
            {
                //BMaster.Visible = true;
            }
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
        
        

        if (!IsPostBack)
        {
            if (Convert.ToString(Session["UserType_id"]) == "1")
            {
                //mailAttendance.Visible = true;
                frmmainleave.Visible = true;
                services.Visible = true;
                payment.Visible = false;
                mainprofile.Visible = true;
            }
        }
        FindUserName();
    }
    protected void FindUserName()
    {
        lblDate.Text = "Date : " + Convert.ToDateTime(DateTime.Today).ToString("dd/MM/yyyy");
        if (Convert.ToString(Session["UserType_id"]) == "5")
        {
            lblwelName.Text = "Admin";
            lblStudNm.Visible = false;
            lblStud.Visible = false;
            lblDIV.Visible = false;
            lblDIVNm.Visible = false;
            lblSTD.Visible = false;
            lblSTDNm.Visible = false;
        }
        else
        {
            if ((Convert.ToString(Session["UserType_id"]) == "1") || (Convert.ToString(Session["UserType_id"]) == "2"))
            {
                strQry = "usp_welcomename @command='" + Convert.ToString(Session["UserType_id"]) + "',@UserID='" + Convert.ToString(Session["Student_id"]) + "'";
                daObj = new SqlDataAdapter(strQry, sqlCon);
                daObj.Fill(dsObj);
                if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
                {
                    lblwelName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchname"]);
                    lblSTDNm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["STD"]);
                    lblDIVNm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["DIV"]);
                    if ((Convert.ToString(Session["UserType_id"]) == "2"))
                    {
                        lblStudNm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Stud"]);
                        lblStud.Visible = true;
                    }
                    else
                    {
                        lblStudNm.Visible = false;
                        lblStud.Visible = false;

                    }
                }
                else
                {
                    lblwelName.Text = "";
                }
            }

            else
            {
                strQry = "usp_welcomename @command='" + Convert.ToString(Session["UserType_id"]) + "',@UserID='" + Convert.ToString(Session["User_id"]) + "'";
                daObj = new SqlDataAdapter(strQry, sqlCon);
                daObj.Fill(dsObj);
                if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
                {
                    lblwelName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchname"]);
                    lblSTDNm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dept"]);
                    lblDIV.Visible = false;
                    lblDIVNm.Visible = false;
                    lblSTD.Text = "Department :";
                    lblStudNm.Visible = false;
                    lblStud.Visible = false;
                }
                else
                {
                    lblwelName.Text = "";
                }
            }

        }
    }
    //protected void FindUserName()
    //{
    //    if (Convert.ToString(Session["UserType_id"]) == "5")
    //    {
    //        lblwelName.Text = "Admin";
    //    }
    //    else
    //    {
    //        if ((Convert.ToString(Session["UserType_id"]) == "1") || (Convert.ToString(Session["UserType_id"]) == "2"))
    //        {
    //            strQry = "usp_welcomename @command='" + Convert.ToString(Session["UserType_id"]) + "',@UserID='" + Convert.ToString(Session["Student_id"]) + "'";
    //        }
    //        else
    //        {
    //            strQry = "usp_welcomename @command='" + Convert.ToString(Session["UserType_id"]) + "',@UserID='" + Convert.ToString(Session["User_id"]) + "'";
    //        }
    //        daObj = new SqlDataAdapter(strQry, sqlCon);
    //        daObj.Fill(dsObj);
    //        if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            lblwelName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchname"]);
    //        }
    //        else
    //        {
    //            lblwelName.Text = "";
    //        }
    //    }
    //}
    protected void ImgBtnHome_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["strUserType"]) == "1" )
            {
                Response.Redirect("~\\frmStudentDashboard.aspx", false);
            }
            else if (Convert.ToString(Session["strUserType"]) == "2")
            {
                Response.Redirect("~\\frmStudentDashboard.aspx", false);
            }
            else if (Convert.ToString(Session["strUserType"]) == "3" || Convert.ToString(Session["strUserType"]) == "4")
            {
                Response.Redirect("~\\NewTeacherDashboard.aspx", false);
            }
            else
            {
                Response.Redirect("~\\NewAdminDashboard.aspx", false);
            }
        }
        catch 
        {
            
        }
    }
}

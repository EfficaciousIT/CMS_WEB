using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    SqlDataAdapter daObj = new SqlDataAdapter();
    string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["esmsCentralModel"].ConnectionString;
    SqlConnection sqlCon;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlCon = new SqlConnection(strCon);

        if (Convert.ToString(Session["strUserType"]) == "1")
        {
            frmabsent.Visible = true;
            frmlate.Visible = true;
            frmattendance.Visible = true;
            frmcard.Visible = true;
            frmTeacherRemark.Visible = true;
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

            frmViewRemark.Visible = false;
            frmTeacherRemarkEntry.Visible = false;

            frmListOfStudTkBusService.Visible = false;
            frmTripwiseStudentRpt.Visible = false;
            frmPreSchoAbseBus.Visible = false;

            frmSelfProfile.Visible = true;
            frmStudentProfile.Visible = false;
            frmcardAssignment.Visible = false;
            //frmTeacherProfile.Visible = false;
            frmSelfProfile.HRef = "frmStudentProfile.aspx";


        }
        else if (Convert.ToString(Session["strUserType"]) == "2")
        {
            mailAttendance.Visible = true;
            frmabsent.Visible = true;
            frmattendance.Visible = true;
            frmcard.Visible = true;
            frmTeacherRemark.Visible = true;
            frmcalender.Visible = true;
            frmholiday.Visible = true;
            frmvcation.Visible = true;
            frmtraining.Visible = true;
            frmmainleave.Visible = true;
            frmleave.HRef = "FrmPareLeavAppro.aspx";

            frmabsent.Visible = true;
            frmattendance.Visible = true;
            frmcard.Visible = true;
            frmTeacherRemark.Visible = true;
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
            frmStudentProfile.HRef = "frmStudentProfile.aspx";            
            frmStudentProfile.Visible = true;
            frmSelfProfile.HRef = "frmParentsDetails.aspx";
            
        }

        else if (Convert.ToString(Session["strUserType"]) == "5")
        {
            BMaster.Visible = true;
            frmmainleave.Visible = true;
            frmleave.HRef = "frmTeacherLeaveMenu.aspx";
            frmstudentTeacherLeave.HRef = "FrmAdminLeavAppro.aspx";            
            frmTechRemark.HRef = "";
            frmSelfAttendance.Visible = true;
            frmStudentAttendance.Visible = true;
            frmTeacherAttendance.Visible = true;
            frmattendance.Visible = true;

            frmselfAbsent.Visible = true;
            frmstudentabsent.Visible = true;
            frmTeacherAbsent.Visible = true;
            frmabsent.Visible = true;

            frmselflate.Visible = true;
            frmstudentLate.Visible = true;
            frmTeacherLate.Visible = true;
            frmlate.Visible = true;

            mailAttendance.Visible = true;
            frmTeacherRemark.Visible = true;
            frmTeacherRemarkEntry.Visible = true;
            frmViewRemark.Visible = true;

            frmselfLeave.Visible = true;
            frmstudentLeave.Visible = true;

            frmListOfStudTkBusService.Visible = true;
            frmTripwiseStudentRpt.Visible = true;
            frmPreSchoAbseBus.Visible = true;

            frmSelfProfile.Visible = true;            
            frmcardAssignment.Visible = true;
            //frmTeacherProfile.Visible = true;
            frmSelfProfile.HRef = "FrmTeacherProfile.aspx";

            frmStudentProfile.HRef = "frmAdmListStudentDetails.aspx";
            frmStudentProfile.Visible = true;
            
            frmholiday.Visible = true;

            frmcalender.Visible = true;
            frmvcation.Visible = true;
            frmtraining.Visible = true;

        }
        else if (Convert.ToString(Session["strUserType"]) == "3")
        {
            frmmainleave.Visible = true;
            frmleave.HRef = "frmTeacherLeaveMenu.aspx";
            frmstudentTeacherLeave.HRef = "frmTeachLeavAppro.aspx";
            //frmTechRemark.HRef = "";
            frmSelfAttendance.Visible = true;
            frmStudentAttendance.Visible = true;
            frmTeacherAttendance.Visible = false;

            frmselfAbsent.Visible = true;
            frmstudentabsent.Visible = true;
            frmTeacherAbsent.Visible = false;
            frmabsent.Visible = true;

            frmselflate.Visible = true;
            frmstudentLate.Visible = true;
            frmTeacherLate.Visible = false;
            frmlate.Visible = true;

            mailAttendance.Visible = true;
            frmTeacherRemark.Visible = true;
            frmTeacherRemarkEntry.Visible = true;
            frmViewRemark.Visible = true;

            frmselfLeave.Visible = true;
            frmstudentLeave.Visible = true;

            frmListOfStudTkBusService.Visible = true;
            frmTripwiseStudentRpt.Visible = true;
            frmPreSchoAbseBus.Visible = true;

            frmSelfProfile.Visible = true;
            frmStudentProfile.HRef = "frmStudentProfile.aspx";
            frmStudentProfile.Visible = true;
            frmcardAssignment.Visible = false;
            //frmTeacherProfile.Visible = true;

            frmcalender.Visible = true;
            frmholiday.Visible = true;
            frmvcation.Visible = true;
            frmtraining.Visible = true;
            //frmTeacherProfile.Visible = false;

            strQry = "usp_UserRights @command='rights',@intUser_id='" + Convert.ToString(Session["User_id"]) + "'";
            daObj = new SqlDataAdapter(strQry, sqlCon);
            daObj.Fill(dsObj);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < dsObj.Tables[0].Rows.Count; j++)
                {
                    Control Subctrl = this.Page.Master.FindControl(Convert.ToString(dsObj.Tables[0].Rows[j]["vchformid"]));
                    Subctrl.Visible = true;
                    mailAttendance.Visible = true;
                }
            }
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
            BMaster.Visible = true;            
        }

        if (!IsPostBack)
        {
            if (Convert.ToString(Session["UserType_id"]) == "1")
            {
                mailAttendance.Visible = true;
                frmmainleave.Visible = true;
                services.Visible = true;
                payment.Visible = false;
                mainprofile.Visible = true;
            }
        }      
        
    }

}

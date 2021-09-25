using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmViewTeacherDetail : DBUtility 
{
    DataSet dsObj = new DataSet();
    string strQry = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Request.QueryString["Status"]) != "" && Convert.ToString(Request.QueryString["Status"]) != null)
            {
                if (Decrypt(Request.QueryString["Type"].ToString()) == "Student")
                {

                    FillStudent();
                }
                else
                {
                    FillTeacherAtt();
                }
            }
            else if (Convert.ToString(Request.QueryString["LeaveId"]) != "" && Convert.ToString(Request.QueryString["LeaveId"]) != null)
            {
                FillLeaveDetail();
            }
        }
    }
    public void FillStudent()
    {
        try
        {
            //ViewState["Staff"] = Decrypt(Request.QueryString["staff"].ToString());
            ViewState["Status"] = Decrypt(Request.QueryString["status"].ToString());
            if (Convert.ToString(ViewState["Status"]) == "Present")
            {
                strQry = "exec [usp_TeacherDashboard] @type='StudentPresentAttendance',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@intDivision_id='" + Convert.ToString(Session["Division_id"]) + "'";
            }
            else
            {
                strQry = "exec [usp_TeacherDashboard] @type='StudentAtt',@intDivision_id='" + Convert.ToString(Session["Division_id"]) + "'";
                //strQry = "exec [usp_TeacherDashboard] @type='StudentAtt',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@intDivision_id='" + Convert.ToString(Session["Division_id"]) + "',@status='" + Convert.ToString(ViewState["Status"]) + "'";
            }
            dsObj = sGetDataset(strQry);
            grvStudent.DataSource = dsObj;
            grvStudent.DataBind();
        }
        catch
        {

        }
    }
  
    public void FillLeaveDetail()
    {
        try
        {
            ViewState["id"] = Decrypt(Request.QueryString["LeaveId"].ToString());
            // int rowindex = grvLeaveDetail.DataKeys[row.RowIndex].Value;
            strQry = "exec [usp_TeacherDashboard] @type='StudentLeave',@SchoolId='" + Session["School_id"].ToString() + "',@intLeaveApplocation_id='" + ViewState["id"].ToString() + "'";
            dsObj = sGetDataset(strQry);
            grvLeaveDetail.DataSource = dsObj;
            grvLeaveDetail.DataBind();
        }
        catch
        {

        }
    }
    protected void ImgReject_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            TextBox txt = (TextBox)grvLeaveDetail.Rows[0].FindControl("txtRemark");
            strQry = "exec [usp_TeacherDashboard]  @type='UpdateLeave',@intLeaveApplocation_id='" + ViewState["id"] + "',@vchAdminRemark='" + txt.Text + "',@bitAdminApproval='1'";
            if (sExecuteQuery(strQry) != -1)
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "window.close();", true);
                NewTeacherDashboard teacher = new NewTeacherDashboard();
                teacher.FillLeaveDetail();
            }
        }
        catch
        {
        }
    }
    protected void ImgApprove_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            TextBox txt = (TextBox)grvLeaveDetail.Rows[0].FindControl("txtRemark");
            strQry = "exec [usp_TeacherDashboard]  @type='UpdateLeave',@intLeaveApplocation_id='" + ViewState["id"] + "',@vchAdminRemark='" + txt.Text + "',@bitAdminApproval='2'";
            if (sExecuteQuery(strQry) != -1)
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "window.close();", true);
                NewTeacherDashboard teacher = new NewTeacherDashboard();
                teacher.FillLeaveDetail();
            }
        }
        catch
        {

        }
    }

    public void FillTeacherAtt()
    {
        try
        {
             ViewState["Status"] = Decrypt(Request.QueryString["status"].ToString());
             if (Convert.ToString(ViewState["Status"]) == "Present")
             {
                 strQry = "exec [usp_TeacherDashboard] @type='TeacherAttendance',@intUser_id='" + Convert.ToString(Session["User_id"]) + "'";

             }
             else if (Convert.ToString(ViewState["Status"]) == "Absent")
             {
                 strQry = "exec [usp_TeacherDashboard] @type='TeacherAbsent',@intUser_id='" + Convert.ToString(Session["User_id"]) + "'";
             }
             else if (Convert.ToString(ViewState["Status"]) == "Leave")
             {
                 strQry = "exec [usp_TeacherDashboard] @type='TeacherLeave',@intUser_id='" + Convert.ToString(Session["User_id"]) + "'";
             }
             dsObj = sGetDataset(strQry);
             grvStaff.DataSource = dsObj;
             grvStaff.DataBind();
        }
        catch 
        {
            
        }
    }
}
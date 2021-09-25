using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewAdminDetail : DBUtility
{
    DataSet dsObj = new DataSet();
    string strQry = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Request.QueryString["LeaveId"]) != "" && Convert.ToString(Request.QueryString["LeaveId"]) != null)
            {
                FillLeaveDetail();
            }
            else if (Convert.ToString(Request.QueryString["Staff"]) != "" && Convert.ToString(Request.QueryString["Staff"]) != null)
            {
                FillStaff();
            }
            else
            {
                FillBusAttedance();
            }
          
        }
      
    }

    public void FillBusAttedance()
    {
        try
        {
            ViewState["BusId"]=Decrypt(Request.QueryString["BusId"].ToString());
            ViewState["Status"]=Decrypt(Request.QueryString["status"].ToString());
            strQry = "exec [usp_NewAdminDashboard] @type='BusAttendance',@BusId='" + Convert.ToString(ViewState["BusId"]) + "',@status='" + Convert.ToString(ViewState["Status"]) + "'";
            dsObj = sGetDataset(strQry);
            grvBus.DataSource = dsObj;
            grvBus.DataBind();
        }
        catch 
        {
            
        }
    }

    public void FillStaff()
    {
        try
        {
            ViewState["Staff"] = Decrypt(Request.QueryString["staff"].ToString());
            ViewState["Status"] = Decrypt(Request.QueryString["status"].ToString());
            if (Convert.ToString(ViewState["Status"]) == "Present")
            {
                strQry = "exec [usp_NewAdminDashboard] @type='StaffPresentDetail',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@UserTypeId='" + Convert.ToString(ViewState["Staff"]) + "'";
            }
            else
            {
                strQry = "exec [usp_NewAdminDashboard] @type='StaffAbsentLeaveDetail',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@UserTypeId='" + Convert.ToString(ViewState["Staff"]) + "',@status='" + Convert.ToString(ViewState["Status"]) + "'";
            }
            dsObj = sGetDataset(strQry);
            grvStaff.DataSource = dsObj;
            grvStaff.DataBind();
        }
        catch 
        {
            
        }
    }
    public void FillTeacher()
    {
        try
        {
            ViewState["Staff"] = Decrypt(Request.QueryString["staff"].ToString());
            ViewState["Status"] = Decrypt(Request.QueryString["status"].ToString());
            if (Convert.ToString(ViewState["Status"]) == "Present")
            {
                strQry = "exec [usp_NewAdminDashboard] @type='StaffPresentDetail',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@UserTypeId='" + Convert.ToString(ViewState["Staff"]) + "'";
            }
            else
            {
                strQry = "exec [usp_NewAdminDashboard] @type='StaffAbsentLeaveDetail',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@UserTypeId='" + Convert.ToString(ViewState["Staff"]) + "',@status='" + Convert.ToString(ViewState["Status"]) + "'";
            }
            dsObj = sGetDataset(strQry);
            grvStaff.DataSource = dsObj;
            grvStaff.DataBind();
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
            strQry = "exec [usp_NewAdminDashboard] @type='Staff_Leave_Detail',@SchoolId='" + Session["School_id"].ToString() + "',@intLeaveApplocation_id='" + ViewState["id"].ToString() + "'";
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
            TextBox txt=(TextBox)grvLeaveDetail.Rows[0].FindControl("txtRemark");
            strQry = "exec [usp_TeacherDashboard]  @type='UpdateLeave',@intLeaveApplocation_id='" + ViewState["id"] + "',@vchAdminRemark='" + txt.Text + "',@bitAdminApproval='1'";
            if (sExecuteQuery(strQry) != -1)
            {
                ScriptManager.RegisterStartupScript(this,Page.GetType(), "script", "window.close();", true);
                NewAdminDashBoard admin = new NewAdminDashBoard();
                admin.FillStaffLeaves();
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
            strQry = "exec usp_TeacherDashboard  @type='UpdateLeave',@intLeaveApplocation_id='" + ViewState["id"] + "',@vchAdminRemark='" + txt.Text + "',@bitAdminApproval='2'";
            if (sExecuteQuery(strQry) != -1)
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "window.close();", true);
                NewAdminDashBoard admin = new NewAdminDashBoard();
                admin.FillStaffLeaves();
            }
        }
        catch 
        {
            
        } 
    }
}
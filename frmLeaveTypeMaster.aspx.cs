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

public partial class frmLeaveTypeMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drpRole.ClearSelection();
            FillRole();
            fGrid();
        }
    }
    public void FillRole()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_tblDepartment_Mst @type='FillRole',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlRole, strQry, "vchRole", "intRole_Id");
            sBindDropDownList(drpRole, strQry, "vchRole", "intRole_Id");

            
        }
        catch
        {

        }
    }
    protected void fGrid()
    {
        strQry = "usp_LeaveTypeMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtName.Text = "";
            ddlRole.ClearSelection();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlRole.SelectedValue == "0")
        {
            MessageBox("Please Select Role!");
            ddlRole.Focus();
            return;
        }
        if (txtName.Text == "")
        {
            MessageBox("Please Insert Leave Type!");
            txtName.Focus();
            return;
        }
        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_LeaveTypeMaster @command='CheckExist',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@vchLeaveType_name='" + Convert.ToString(txtName.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Leave Type Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_LeaveTypeMaster] @command='insert',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@vchLeaveType_name='" + Convert.ToString(txtName.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Leave Type Inserted Successfully!");
                }
            }
        }
        else
        {
            strQry = "usp_LeaveTypeMaster @command='CheckUpdateExist',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intLeaveType_id='" + Convert.ToString(Session["LeavetypeID"]) + "',@vchLeaveType_name='" + Convert.ToString(txtName.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Leave Type Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_LeaveTypeMaster] @command='Update',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@vchLeaveType_name='" + Convert.ToString(txtName.Text.Trim()) + "',@intLeaveType_id='" + Convert.ToString(Session["LeavetypeID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdate_id='" + Session["User_id"] + "',@IntUpdate_IP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
            }
        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["LeavetypeID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_LeaveTypeMaster @command='Edit',@intLeaveType_id='" + Convert.ToString(Session["LeavetypeID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ddlRole.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRole_Id"]);
                txtName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchLeaveType_name"]);
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["LeavetypeID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_LeaveTypeMaster] @command='Delete',@intLeaveType_id='" + Convert.ToString(Session["LeavetypeID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Standard Deleted Successfully!");
            }
        }
        catch
        {

        }
    }
    //public void MessageBox(string msg)
    //{
    //    try
    //    {
    //        string script = "alert(\"" + msg + "\");";
    //        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
    //    }
    //    catch (Exception)
    //    {
    //        // return msg;
    //    }
    //}
    protected void drpRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "usp_LeaveTypeMaster @command='selectRoleWise',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intRole_Id='" + Convert.ToString(drpRole.SelectedValue) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtName.Text = "";
            ddlRole.ClearSelection();
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtName.Text = "";
            ddlRole.ClearSelection();
        }
    }
}
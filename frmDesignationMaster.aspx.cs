using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmDesignationMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {
                    FillGrid();
                    FillRole();
                    geturl();
                }
            }
            else
            {
                Response.Redirect("~\\index.aspx", false);
            }
        }
        catch
        {

        }
    }
    public void FillGrid()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_DesignationMaster  @type='FillGrid',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        catch
        {

        }
    }
    public void FillRole()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_DesignationMaster  @type='FillRole',@intSchool_id='" + Session["School_Id"] + "'";
            sBindDropDownList(ddlRole, strQry, "vchRole", "intRole_Id");
        }
        catch
        {

        }
    }
    public void FillDepartment()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_DesignationMaster  @type='FillDepartment',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlDept, strQry, "vchDepartment_name", "intDepartment");
        }
        catch
        {

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
        if (ddlDept.SelectedValue == "0")
        {
            MessageBox("Please Select Department!");
            ddlDept.Focus();
            return;
        }
        if (txtDesignation.Text == "")
        {
            MessageBox("Please Insert Department Name!");
            txtDesignation.Focus();
            return;
        }

        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                strQry = "";
                strQry = "exec usp_DesignationMaster   @type='CheckSaveExist',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue).Trim() + "',@intDepartment='" + Convert.ToString(ddlDept.SelectedValue).Trim() + "',@vchDesignation='" + Convert.ToString(txtDesignation.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_DesignationMaster   @type='Insert',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue).Trim() + "',@intDepartment='" + Convert.ToString(ddlDept.SelectedValue).Trim() + "',@vchDesignation='" + Convert.ToString(txtDesignation.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully!");
                    txtDesignation.Text = "";
                    ddlRole.ClearSelection();
                    ddlDept.ClearSelection();
                    FillGrid();
                }
            }
            else
            {
                strQry = "";
                strQry = "exec usp_DesignationMaster   @type='CheckUpdateExist',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue).Trim() + "',@intDepartment='" + Convert.ToString(ddlDept.SelectedValue).Trim() + "',@intDesignation_Id='" + ViewState["Desi_ID"] + "',@vchDesignation='" + Convert.ToString(txtDesignation.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_DesignationMaster   @type='Update',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue).Trim() + "',@intDepartment='" + Convert.ToString(ddlDept.SelectedValue).Trim() + "',@intDesignation_Id='" + ViewState["Desi_ID"] + "',@vchDesignation='" + Convert.ToString(txtDesignation.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intUpdate_id='" + Session["User_id"] + "',@IntUpdate_IP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    txtDesignation.Text = "";
                    ddlRole.ClearSelection();
                    ddlDept.ClearSelection();
                    btnSubmit.Text = "Submit";
                    FillGrid();
                }
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
            int id = (int)grvDetail.DataKeys[e.RowIndex].Value;
            ViewState["Desi_ID"] = id;
            strQry = "exec usp_DesignationMaster  @type='Delete',@intDesignation_Id='" + Convert.ToString(id) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully");
                FillGrid();
            }
        }
        catch
        {

        } 
    }
    protected void grvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            FillGrid();
            grvDetail.PageIndex = e.NewPageIndex;
            grvDetail.DataBind();
        }
        catch
        {

        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            strQry = "";
            int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            ViewState["Desi_ID"] = id;
            strQry = "exec usp_DesignationMaster   @type='Edit',@intDesignation_Id='" + Convert.ToString(id) + "',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ddlRole.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRole_Id"]);
                FillDepartment();
                ddlDept.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intDepartment"]);
                txtDesignation.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDesignation"]);
                TBC.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDepartment();
    }
}
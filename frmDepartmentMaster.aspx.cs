using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmDepartmentMaster : DBUtility
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
    public void FillRole()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_tblDepartment_Mst @type='FillRole',@intSchool_id='" + Session["School_Id"] + "'";
            sBindDropDownList(ddlRole, strQry, "vchRole", "intRole_Id");
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
            txtDeptName.Focus();
            return;
        }
        if (txtDeptName.Text == "")
        {
            MessageBox("Please Insert Department Name!");
            txtDeptName.Focus();
            return;
        }
       
        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                strQry = "";
                strQry = "exec usp_tblDepartment_Mst  @type='CheckSaveExist',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue).Trim() + "',@vchDepartment_name='" + Convert.ToString(txtDeptName.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_tblDepartment_Mst  @type='Insert',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue).Trim() + "',@vchDepartment_name='" + Convert.ToString(txtDeptName.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInerted_by='" + Session["User_id"] + "',@InsertIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully!");
                    txtDeptName.Text = "";
                    ddlRole.ClearSelection();
                    FillGrid();
                }
            }
            else
            {
                strQry = "";
                strQry = "exec usp_tblDepartment_Mst  @type='CheckUpdateExist',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue).Trim() + "',@intDepartment='" + ViewState["Dept_Id"] + "',@vchDepartment_name='" + Convert.ToString(txtDeptName.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_tblDepartment_Mst  @type='Update',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue).Trim() + "',@intDepartment='" + ViewState["Dept_Id"] + "',@vchDepartment_name='" + Convert.ToString(txtDeptName.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intUpdate_by='" + Session["User_id"] + "',@updateIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    txtDeptName.Text = "";
                    ddlRole.ClearSelection();
                    btnSubmit.Text = "Submit";
                    FillGrid();
                }
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
            strQry = "exec usp_tblDepartment_Mst @type='FillGrid',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
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
            ViewState["Dept_Id"] = id;
            strQry = "exec usp_tblDepartment_Mst @type='Delete',@intDepartment='" + Convert.ToString(id) + "',@intDeleteBy='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
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
            ViewState["Dept_Id"] = id;
            strQry = "exec usp_tblDepartment_Mst  @type='Edit',@intDepartment='" + Convert.ToString(id) + "',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ddlRole.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRole_Id"]);
                txtDeptName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDepartment_name"]);
                TBC.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlRole.ClearSelection();
        txtDeptName.Text = "";
    }
}
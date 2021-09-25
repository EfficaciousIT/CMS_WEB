using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmNetworkAdmMaster : DBUtility
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
                    FillAdmin();
                    FillGrid();
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
    public void FillAdmin()
    {
        try
        {
            strQry = "exec usp_NetworkAdmin @type='FillAdmin',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(drpAdmin, strQry, "vchName", "intAdmin_id");
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
            strQry = "exec usp_NetworkAdmin @type='FillGrid',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (drpAdmin.SelectedValue == "0")
        {
            MessageBox("Please Select Administration Name!");
            drpAdmin.Focus();
            return;
        }
        if (txtMobile.Text == "")
        {
            MessageBox("Please Enter Mobile No.!");
            txtMobile.Focus();
            return;
        }

        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                strQry = "";
                strQry = "exec usp_NetworkAdmin  @type='CheckSaveExist',@intAdmin_id='" + Convert.ToString(drpAdmin.SelectedValue).Trim() + "',@intMobileNo='" + Convert.ToString(txtMobile.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_NetworkAdmin  @type='Insert',@intAdmin_id='" + Convert.ToString(drpAdmin.SelectedValue).Trim() + "',@intMobileNo='" + Convert.ToString(txtMobile.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully!");
                    drpAdmin.ClearSelection();
                    txtMobile.Text = "";
                    FillGrid();
                }
            }
            else
            {
                strQry = "";
                strQry = "exec usp_NetworkAdmin  @type='CheckUpdateExist',@intNetwork_id='" + Session["Network_id"] + "',@intAdmin_id='" + Convert.ToString(drpAdmin.SelectedValue).Trim() + "',@intMobileNo='" + Convert.ToString(txtMobile.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_NetworkAdmin  @type='Update',@intNetwork_id='" + Session["Network_id"] + "',@intAdmin_id='" + Convert.ToString(drpAdmin.SelectedValue).Trim() + "',@intMobileNo='" + Convert.ToString(txtMobile.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@IntUpdate_by='" + Session["User_id"] + "',@UpdateIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    drpAdmin.ClearSelection();
                    txtMobile.Text = "";
                    btnSubmit.Text = "Submit";
                    FillGrid();
                }
            }
        }
        catch
        {

        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["Network_id"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            //int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            //ViewState["Network_id"] = id;
            strQry = "exec usp_NetworkAdmin  @type='Edit',@intNetwork_id='" + Convert.ToString(Session["Network_id"]) + "',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpAdmin.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intAdmin_id"]);
                txtMobile.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intMobileNo"]);

                TBC.ActiveTabIndex = 1;
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
            int id = (int)grvDetail.DataKeys[e.RowIndex].Value;
            ViewState["Network_id"] = id;
            strQry = "exec usp_NetworkAdmin @type='Delete',@intNetwork_id='" + Convert.ToString(id) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
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
            grvDetail.PageIndex = e.NewPageIndex;
            grvDetail.DataBind();
        }
        catch
        {

        }
    }
}
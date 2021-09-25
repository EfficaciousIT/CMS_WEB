using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frmSchoolStoreMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fGrid();
        }
    }
    protected void fGrid()
    {
        strQry = "usp_tblSchoolStoreMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtStoreName.Text = "";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtStoreName.Text == "")
        {
            MessageBox("Please Insert store Name");
            txtStoreName.Focus();
            return;
        }
        if (txtStoreAddress.Text == "")
        {
            MessageBox("Please Insert store Address");
            txtStoreAddress.Focus();
            return;
        }
        if (txtEmail.Text == "")
        {
            MessageBox("Please Insert Email Id");
            txtEmail.Focus();
            return;
        }
        if (txtContactNo.Text == "")
        {
            MessageBox("Please Insert Contact Number");
            txtStoreName.Focus();
            return;
        }
        if (txtWebsite.Text == "")
        {
            MessageBox("Please Insert Website ");
            txtWebsite.Focus();
            return;
        }
        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_tblSchoolStoreMaster @command='checkExist',@vchStore_name='" + Convert.ToString(txtStoreName.Text.Trim()) + "',@vchStore_address='" + Convert.ToString(txtStoreAddress.Text.Trim()) + "',@vchStore_website='" + Convert.ToString(txtWebsite.Text.Trim()) + "',@vchStore_email='" + Convert.ToString(txtEmail.Text.Trim()) + "',@vchStore_contact_no='" + Convert.ToString(txtContactNo.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Store Name is Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_tblSchoolStoreMaster] @command='insert',@vchStore_name='" + Convert.ToString(txtStoreName.Text.Trim()) + "',@vchStore_address='" + Convert.ToString(txtStoreAddress.Text.Trim()) + "',@vchStore_website='" + Convert.ToString(txtWebsite.Text.Trim()) + "',@vchStore_email='" + Convert.ToString(txtEmail.Text.Trim()) + "',@vchStore_contact_no='" + Convert.ToString(txtContactNo.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Store Inserted Successfully!");
                    clear();
                }
            }
        }
        else
        {
            strQry = "usp_tblSchoolStoreMaster @command='checkUpdateExist',@intSchoolStore_id='" + Convert.ToString(Session["StoreID"]) + "',@vchStore_name='" + Convert.ToString(txtStoreName.Text.Trim()) + "',@vchStore_address='" + Convert.ToString(txtStoreAddress.Text.Trim()) + "',@vchStore_website='" + Convert.ToString(txtWebsite.Text.Trim()) + "',@vchStore_email='" + Convert.ToString(txtEmail.Text.Trim()) + "',@vchStore_contact_no='" + Convert.ToString(txtContactNo.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Store Name is Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_tblSchoolStoreMaster] @command='update',@intSchoolStore_id='" + Convert.ToString(Session["StoreID"]) + "',@vchStore_name='" + Convert.ToString(txtStoreName.Text.Trim()) + "',@vchStore_address='" + Convert.ToString(txtStoreAddress.Text.Trim()) + "',@vchStore_website='" + Convert.ToString(txtWebsite.Text.Trim()) + "',@vchStore_email='" + Convert.ToString(txtEmail.Text.Trim()) + "',@vchStore_contact_no='" + Convert.ToString(txtContactNo.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                    clear();
                }
            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void clear()
    {
        txtStoreName.Text = "";
        txtStoreAddress.Text = "";
        txtWebsite.Text = "";
        txtEmail.Text = "";
        txtContactNo.Text = "";
        btnSubmit.Text = "Submit";
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
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["StoreID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_tblSchoolStoreMaster] @command='delete',@intSchoolStore_id='" + Convert.ToString(Session["StoreID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Store Deleted Successfully!");
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
            Session["StoreID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_tblSchoolStoreMaster @command='edit',@intSchoolStore_id='" + Convert.ToString(Session["StoreID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtStoreName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStore_name"]);
                txtStoreAddress.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStore_address"]);
                txtWebsite.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStore_website"]);
                txtEmail.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStore_email"]);
                txtContactNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStore_contact_no"]);
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
}
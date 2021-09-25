using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frmSchoolEquipmentMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fGrid();           
            fGetStoreName();
        }
    }
    protected void fGrid()
    {
        strQry = "usp_tblSchoolEquipmentMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtEquipmentName.Text = "";           
            txtEquipmentDetails.Text = "";           
            ddlStoreName.ClearSelection();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtEquipmentName.Text == "")
        {
            MessageBox("Please Insert Equipment  Name");
            txtEquipmentName.Focus();
            return;
        }        

        if (txtEquipmentDetails.Text == "")
        {
            MessageBox("Please Insert Equipment Details");
            txtEquipmentName.Focus();
            return;
        }
        
        if (ddlStoreName.Text == "0")
        {
            MessageBox("Please Select Store name");
            ddlStoreName.Focus();
            return;
        }

        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_tblSchoolEquipmentMaster @command='checkExist',@vchEquipment_name='" + Convert.ToString(txtEquipmentName.Text.Trim()) + "',@vchEquipment_detail='" + Convert.ToString(txtEquipmentDetails.Text.Trim()) + "',@intSchoolStore_id='" + ddlStoreName.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Equipment Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_tblSchoolEquipmentMaster] @command='insert',@vchEquipment_name='" + Convert.ToString(txtEquipmentName.Text.Trim()) + "',@vchEquipment_detail='" + Convert.ToString(txtEquipmentDetails.Text.Trim()) + "',@intSchoolStore_id='" + ddlStoreName.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Equipment Inserted Successfully!");
                    fGrid();
                }
            }
        }
        else
        {
            strQry = "usp_tblSchoolEquipmentMaster @command='checkExist',@vchEquipment_name='" + Convert.ToString(txtEquipmentName.Text.Trim()) + "',@vchEquipment_detail='" + Convert.ToString(txtEquipmentDetails.Text.Trim()) + "',@intSchoolStore_id='" + ddlStoreName.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_tblSchoolEquipmentMaster] @command='update',@intEquipment_id='" + Convert.ToString(Session["EquipmentID"]) + "',@vchEquipment_name='" + Convert.ToString(txtEquipmentName.Text.Trim()) + "',@vchEquipment_detail='" + Convert.ToString(txtEquipmentDetails.Text.Trim()) + "',@intSchoolStore_id='" + ddlStoreName.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";

                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                    fGrid();
                }
            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtEquipmentName.Text = "";      
        txtEquipmentDetails.Text = "";      
        ddlStoreName.ClearSelection();
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



    public void fGetStoreName()
    {
        try
        {
            strQry = "exec usp_tblSchoolEquipmentMaster @command='GetStoreName',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlStoreName, strQry, "vchStore_name", "intSchoolStore_id");
        }
        catch
        {

        }
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["EquipmentID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_tblSchoolEquipmentMaster] @command='delete',@intEquipment_id='" + Convert.ToString(Session["EquipmentID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Equipment has been Deleted Successfully!");
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
            Session["EquipmentID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_tblSchoolEquipmentMaster @command='edit',@intEquipment_id='" + Convert.ToString(Session["EquipmentID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtEquipmentName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEquipment_name"]);              
                txtEquipmentDetails.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEquipment_detail"]);               
                ddlStoreName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intSchoolStore_id"]);
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
}
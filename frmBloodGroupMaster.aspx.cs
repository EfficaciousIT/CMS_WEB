using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frmBloodGroupMaster : DBUtility
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
        strQry = "usp_tblBloodGroupMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtBloodGroup.Text = "";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (txtBloodGroup.Text == "")
        {
            MessageBox("Please Insert Blood group");
            txtBloodGroup.Focus();
            return;
        }
        strQry = "";

        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_tblBloodGroupMaster @command='checkExist',@vchBlood_group='" + Convert.ToString(txtBloodGroup.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Blood Group Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_tblBloodGroupMaster] @command='insert',@vchBlood_group='" + Convert.ToString(txtBloodGroup.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                sExecuteQuery(strQry);
               // if (sExecuteQuery(strQry) != -1)
               // {
                    fGrid();
                    MessageBox("Blood group Inserted Successfully!");
                   //clear();
               //}
            }
        }
        else
        {
            strQry = "usp_tblBloodGroupMaster @command='checkExist',@vchBlood_group='" + Convert.ToString(txtBloodGroup.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exists");
                return;
            }
            else
            {

                strQry = "exec [usp_tblBloodGroupMaster] @command='update',@intBlood_group_Id='" + Convert.ToString(Session["intBloodGroup_ID"]) + "',@vchBlood_group='" + Convert.ToString(txtBloodGroup.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
                 sExecuteQuery(strQry);
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    clear();
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
            }
        }
    
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }


    public void clear()
    {
        txtBloodGroup.Text = "";
        btnSubmit.Text = "Submit";
    }

    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["intBloodGroup_ID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_tblBloodGroupMaster] @command='delete',@intBlood_group_Id='" + Convert.ToString(Session["intBloodGroup_ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Record Deleted Successfully!");
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
            Session["intBloodGroup_ID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_tblBloodGroupMaster @command='edit',@intBlood_group_Id='" + Convert.ToString(Session["intBloodGroup_ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtBloodGroup.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchBlood_group"]);
              
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
}
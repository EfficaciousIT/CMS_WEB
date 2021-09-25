using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frmGenderMaster :DBUtility
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
        strQry = "usp_tblGenderMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtGender.Text = "";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (txtGender.Text == "")
        {
            MessageBox("Please Insert Gender");
            txtGender.Focus();
            return;
        }
        strQry = "";

        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_tblGenderMaster @command='checkExist',@vchGender='" + Convert.ToString(txtGender.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Gender Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_tblGenderMaster] @command='insert',@vchGender='" + Convert.ToString(txtGender.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                sExecuteQuery(strQry);
                // if (sExecuteQuery(strQry) != -1)
                // {
                fGrid();
                MessageBox("Gender Inserted Successfully!");
                //clear();
                //}
            }
        }
        else
        {
            strQry = "usp_tblGenderMaster @command='checkExist',@vchGender='" + Convert.ToString(txtGender.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exists");
                return;
            }
            else
            {

                strQry = "exec [usp_tblGenderMaster] @command='update',@intGender_Id='" + Convert.ToString(Session["intGender_ID"]) + "',@vchGender='" + Convert.ToString(txtGender.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
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
        txtGender.Text = "";
        btnSubmit.Text = "Submit";
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        try
        {
            Session["intGender_ID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_tblGenderMaster] @command='delete',@intGender_Id='" + Convert.ToString(Session["intGender_ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
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
            Session["intGender_ID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_tblGenderMaster @command='edit',@intGender_Id='" + Convert.ToString(Session["intGender_ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtGender.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchGender"]);

                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
}
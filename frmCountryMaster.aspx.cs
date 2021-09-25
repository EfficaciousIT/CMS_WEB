using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class frmCountryMaster : DBUtility
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
        strQry = "usp_tblCountryMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtCountry.Text = "";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (txtCountry.Text == "")
        {
            MessageBox("Please Country group");
            txtCountry.Focus();
            return;
        }
        strQry = "";

        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_tblCountryMaster @command='checkExist',@vchCountry='" + Convert.ToString(txtCountry.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Country Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_tblCountryMaster] @command='insert',@vchCountry='" + Convert.ToString(txtCountry.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                sExecuteQuery(strQry);
                // if (sExecuteQuery(strQry) != -1)
                // {
                fGrid();
                MessageBox("Country Inserted Successfully!");
                //clear();
                //}
            }
        }
        else
        {
            //strQry = "usp_tblCountryMaster @command='checkExist',@vchCountry='" + Convert.ToString(txtCountry.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox("Record Already Exists");
            //    return;
            //}
            //else
            //{

                strQry = "exec [usp_tblCountryMaster] @command='update',@intCountry_id='" + Convert.ToString(Session["intCountry_ID"]) + "',@vchCountry='" + Convert.ToString(txtCountry.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
                sExecuteQuery(strQry);
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    clear();
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
            //}
        }

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }


    public void clear()
    {
        txtCountry.Text = "";
        btnSubmit.Text = "Submit";
    }

    protected void grvDetail_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {

        try
        {
            Session["intCountry_ID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_tblCountryMaster] @command='delete',@intCountry_id='" + Convert.ToString(Session["intCountry_ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
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
    protected void grvDetail_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intCountry_ID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_tblCountryMaster @command='edit',@intCountry_id='" + Convert.ToString(Session["intCountry_ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtCountry.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchCountry"]);

                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
}
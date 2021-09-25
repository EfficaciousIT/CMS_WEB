using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frmState : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fGrid();
            getCountry();
        }
    }

    protected void fGrid()
    {
        strQry = "usp_tblStateMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtState.Text = "";
            DdlCountryName.ClearSelection();
        }
    }
    protected void getCountry()
    {
        try
        {
            string str1 = "[usp_tblStateMaster] @command='GetCountry',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(DdlCountryName, str1, "vchCountry", "intCountry_id");
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (DdlCountryName.SelectedValue == "0")
        {
            MessageBox("Please select Country");
            DdlCountryName.Focus();
            return;
        }

        if (txtState.Text == "")
        {
            MessageBox("Please Insert State");
            txtState.Focus();
            return;
        }

        strQry = "";

        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_tblStateMaster @command='checkExist',@intCountry_id='" + Convert.ToString(DdlCountryName.SelectedValue) + "',@vchState='" + Convert.ToString(txtState.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("State Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_tblStateMaster] @command='insert',@intCountry_id='" + Convert.ToString(DdlCountryName.SelectedValue) + "',@vchState='" + Convert.ToString(txtState.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                sExecuteQuery(strQry);
                // if (sExecuteQuery(strQry) != -1)
                // {
                fGrid();
                MessageBox("State Inserted Successfully!");
                //clear();
                //}
            }
        }
        else
        {
            //strQry = "usp_tblStateMaster @command='checkExist',@intCountry_id='" + Convert.ToString(DdlCountryName.SelectedValue) + "',@vchState='" + Convert.ToString(txtState.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox("Record Already Exists");
            //    return;
            //}
            //else
            //{

                strQry = "exec [usp_tblStateMaster] @command='update',@intCountry_id='" + Convert.ToString(DdlCountryName.SelectedValue) + "',@intState_id='" + Convert.ToString(Session["intState_ID"]) + "',@vchState='" + Convert.ToString(txtState.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
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
        DdlCountryName.ClearSelection();
        txtState.Text = "";
        btnSubmit.Text = "Submit";
    }


    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intState_ID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_tblStateMaster @command='edit',@intState_id='" + Convert.ToString(Session["intState_ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtState.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchState"]);
                DdlCountryName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intCountry_id"]);

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
            Session["intState_ID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_tblStateMaster] @command='delete',@intState_id='" + Convert.ToString(Session["intState_ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
               
                MessageBox("Record Deleted Successfully!");
                fGrid();
            }
        }
        catch
        {

        }
    }
}
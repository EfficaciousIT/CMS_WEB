using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frmCityMaster : DBUtility
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
        strQry = "usp_tblCityMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtCity.Text = "";
        }
    }
    protected void getCountry()
    {
        try
        {
            string str1 = "[usp_tblCityMaster] @command='GetCountry',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(DdlCountryName, str1, "vchCountry", "intCountry_id");
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void getState()
    {
        try
        {
            string str1 = "[usp_tblCityMaster] @command='GetState',@intCountry_id='" + DdlCountryName.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(DdlStateName, str1, "vchState", "intState_id");
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
        if (DdlStateName.SelectedValue == "0")
        {
            MessageBox("Please select State");
            DdlStateName.Focus();
            return;
        }

        if (txtCity.Text == "")
        {
            MessageBox("Please Enter City");
            txtCity.Focus();
            return;
        }

        //if (txtPINCode.Text == "")
        //{
        //    MessageBox("Please Insert PIN Code");
        //    txtPINCode.Focus();
        //    return;
        //}

        strQry = "";

        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_tblCityMaster @command='checkExist',@intCountry_id='" + Convert.ToString(DdlCountryName.SelectedValue.Trim()) + "',@intState_id='" + Convert.ToString(DdlStateName.SelectedValue.Trim()) + "',@vchCity='" + Convert.ToString(txtCity.Text.Trim()) + "',@intPinCode='" + Convert.ToString(txtPINCode.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exists");
                return;
            }

           
            else
            {
                strQry = "exec [usp_tblCityMaster] @command='insert',@intCountry_id='" + Convert.ToString(DdlCountryName.SelectedValue.Trim()) + "',@intState_id='" + Convert.ToString(DdlStateName.SelectedValue.Trim()) + "',@intPinCode='" + Convert.ToString(txtPINCode.Text.Trim()) + "',@vchCity='" + Convert.ToString(txtCity.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                sExecuteQuery(strQry);
                // if (sExecuteQuery(strQry) != -1)
                // {
                fGrid();
                MessageBox("Record Inserted Successfully!");
                clear();
                //}
            }
        }
        else
        {
            //strQry = "usp_tblCityMaster @command='checkExist',@vchCity='" + Convert.ToString(txtCity.Text.Trim()) + "',@intPinCode='" + Convert.ToString(txtPINCode.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox("Record Already Exists");
            //    return;
            //}
            //else
            //{

                strQry = "exec [usp_tblCityMaster] @command='update',@intCountry_id='" + Convert.ToString(DdlCountryName.SelectedValue.Trim()) + "',@intPinCode='" + Convert.ToString(txtPINCode.Text.Trim()) + "',@intState_id='" + Convert.ToString(DdlStateName.SelectedValue.Trim()) + "',@vchCity='" + Convert.ToString(txtCity.Text.Trim()) + "',@intCity_id='" + Convert.ToString(Session["intCity_ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
                sExecuteQuery(strQry);
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    clear();
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
           // }
        }

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }


    public void clear()
    {
        txtCity.Text = "";
        txtPINCode.Text = "";
        btnSubmit.Text = "Submit";
        DdlCountryName.ClearSelection();
        DdlStateName.ClearSelection();
    }


    protected void grvDetail_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["intCity_ID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_tblCityMaster] @command='delete',@intCity_id='" + Convert.ToString(Session["intCity_ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
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
    protected void grvDetail_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intCity_ID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_tblCityMaster @command='edit',@intCity_id='" + Convert.ToString(Session["intCity_ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtPINCode.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intPincode"]);
                txtCity.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchCity"]);
                DdlCountryName.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intCountry_id"]);
                
                DdlStateName.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intState_id"]);
               

                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
                
            }
        }
        catch
        {

        }
    }
    protected void DdlCountryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        getState();
    }
 
}
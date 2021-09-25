using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmSMSTemplateMaster : DBUtility
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
                   // FillAdmin();
                  //  FillGrid();
                  //  geturl();
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
        if (txtTemplateId.Text == "")
        {
            MessageBox("Please enter template Id!");
            txtTemplateId.Focus();
            return;
        }
        if (txtTemplateName.Text == "")
        {
            MessageBox("Please Enter Template Name!");
            txtTemplateName.Focus();
            return;
        }
        if (txtTemplateMessage.Text == "")
        {
            MessageBox("Please Enter Template Message!");
            txtTemplateMessage.Focus();
            return;
        }
        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
               

                strQry = "exec usp_NetworkAdmin  @type='Insert',@intAdmin_id='" + Convert.ToString(drpAdmin.SelectedValue).Trim() + "',@intMobileNo='" + Convert.ToString(txtMobile.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully!");
                    txtTemplateId.Text = "";
                    txtTemplateName.Text = "";
                    txtTemplateMessage.Text = "";
                    FillGrid();
                }
            }
            else
            {
                strQry = "";
                strQry = "exec usp_tblSMSTemplate_master  @command='Update',@intSMSTemp_id='" + Session["intSMSTemp_id"] + "',@vchTemplate_id='" + txtTemplate_id.Text.Trim() + "',@vchTemplate_Name='" + txtTemplate_Name.Text.Trim() + "',@vchTemplate_Message='" + txtTemplate_Message.Text.Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@IntUpdate_by='" + Session["User_id"] + "',@UpdateIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    txtTemplateId.Text = "";
                    txtTemplateName.Text = "";
                    txtTemplateMessage.Text = "";
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
            Session["intSMSTemp_id"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            //int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            //ViewState["Network_id"] = id;
            strQry = "exec usp_tblSMSTemplate_master  @command='Update',@intSMSTemp_id='" + Convert.ToString(Session["intSMSTemp_id"]) +"'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtTemplateId.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchTemplate_id"]);
                txtTemplateName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchTemplate_Name"]);
                txtTemplateMessage.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchTemplate_Message"]);
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
            //int id = (int)grvDetail.DataKeys[e.RowIndex].Value;
            //ViewState["Network_id"] = id;
            //strQry = "exec usp_NetworkAdmin @type='Delete',@intNetwork_id='" + Convert.ToString(id) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
            //if (sExecuteQuery(strQry) != -1)
            //{
            //    MessageBox("Record Deleted Successfully");
            //    FillGrid();
            //}
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
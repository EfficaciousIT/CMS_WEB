using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


public partial class frmInquiryReception : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    DataSet dsObjNew = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fGridafill();
            fillStatus();
            //if (Convert.ToString(Session["UserType_Id"]) == "1" || Convert.ToString(Session["UserType_Id"]) == "2")
            if (Convert.ToString(Session["UserType_Id"]) == "3" || Convert.ToString(Session["UserType_Id"]) == "4")
            {
                lblStatus.Visible = false;
                drpStatus.Visible = false;
                grvDetail.Columns[0].Visible = false;
                grvDetail.Columns[1].Visible = false;
            }
            else
            {
                lblStatus.Visible = true;
                drpStatus.Visible = true;
                grvDetail.Columns[0].Visible = true;
                grvDetail.Columns[1].Visible = true;
            }
        }
    }
    public void fillStatus()
    {
        try
        {
            strQry = "exec usp_InquiryReception @command='fillStatus',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(drpStatus, strQry, "vchStatus", "intStatus_Id");
            sBindDropDownList(ddlStatus, strQry, "vchStatus", "intStatus_Id");
           
        }
        catch
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "")
        {
            MessageBox("Please Enter Name!");
            txtName.Focus();
            return;
        }

        if (txtMail.Text == "")
        {
            MessageBox("Please Enter E-Mail!");
            txtMail.Focus();
            return;
        }

        if (txtMobile.Text == "")
        {
            MessageBox("Please Enter Mobile!");
            txtMobile.Focus();
            return;
        }
      
        if (txtAddress.Text == "")
        {
            MessageBox("Please Enter Address!");
            txtAddress.Focus();
            return;
        }

        if (txtDescription.Text == "")
        {
            MessageBox("Please Enter Description!");
            txtDescription.Focus();
            return;
        }

        if (drpStatus.SelectedValue == "0")
        {
            MessageBox("Please Select Status!");
            drpStatus.Focus();
            return;
        }
        strQry = "";

        if (btnSubmit.Text == "Submit")
        {
            strQry = "exec [usp_InquiryReception] @command='checkExist',@vchEmail='" + txtMail.Text.Trim() + "',@vchMobile='" + txtMobile.Text.Trim() + "',@intStatus_Id='" + drpStatus.SelectedValue + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                fGridafill();
                MessageBox("Record Exist Already");
                return;
            }
            else
            {
                strQry = "exec [usp_InquiryReception] @command='insert',@vchName='" + txtName.Text.Trim() + "',@vchEmail='" + txtMail.Text.Trim() + "',@vchMobile='" + txtMobile.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchDescription='" + txtDescription.Text.Trim() + "',@intStatus_Id='" + drpStatus.SelectedValue + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGridafill();
                    MessageBox("Record Saved Successfully!");
                    clear();
                }
            }
        }
        else
        {
            strQry = "exec [usp_InquiryReception] @command='checkExist',@vchEmail='" + txtMail.Text.Trim() + "',@vchMobile='" + txtMobile.Text.Trim() + "',@intStatus_Id='" + drpStatus.SelectedValue + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Exist Already");
                return;
            }
            else
            {
                strQry = "exec [usp_InquiryReception] @command='update',@vchName='" + txtName.Text.Trim() + "',@vchEmail='" + txtMail.Text.Trim() + "',@vchMobile='" + txtMobile.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchDescription='" + txtDescription.Text.Trim() + "',@intStatus_Id='" + drpStatus.SelectedValue + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInquiryReception_Id='" + Convert.ToString(Session["intInquiryReception_Id"]) + "',@intUpdate_id='" + Session["User_id"] + "',@IntUpdate_IP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGridafill();
                    MessageBox("Record Updated Successfully!");
                   
                    clear();
                }
            }
        }
    }
    public void clear()
    {
        try
        {
            txtName.Text = "";            
            txtMail.Text = "";
            txtMobile.Text = "";             
            txtAddress.Text = "";
            txtDescription.Text = "";
            drpStatus.SelectedValue = "0";
            ddlStatus.ClearSelection();
            btnSubmit.Text = "Submit";
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
    protected void fGridafill()
    {
        strQry = "usp_InquiryReception @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();

            //txtName.Text = "";
        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intInquiryReception_Id"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec [usp_InquiryReception] @command='edit',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInquiryReception_Id='" + Convert.ToString(Session["intInquiryReception_Id"]) + "'";
            dsObjNew = sGetDataset(strQry);
            if (dsObjNew.Tables[0].Rows.Count > 0)
            {
                txtName.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchName"]);
                txtMail.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchEmail"]);
                txtMobile.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchMobile"]);
                txtAddress.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchAddress"]);
                txtDescription.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchDescription"]);
                drpStatus.SelectedItem.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["intStatus_Id"]);

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
        string Str_id = "";
        Str_id = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
        strQry = "exec [usp_InquiryReception] @command='delete',@intInquiryReception_Id='" + Str_id.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
        if (sExecuteQuery(strQry) != -1)
        {
            fGridafill();
            MessageBox("Record deleted Successfully!");

        }
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "usp_InquiryReception @command='StatusGrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intStatus_Id='" + ddlStatus.SelectedValue + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        else {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
    }
}
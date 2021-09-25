using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmPackageMst : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTile = new Label();
        lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        lblTile.Visible = true;
        lblTile.Text = "Notification Package Master";
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {
                FillCurrency();
                FillGrid();
                ddlCurrency.Visible = false;
                txtAmt.Visible = false;
                lblCurrency.Visible = false;
                lblAmt.Visible = false;
                txtSpace.Text = "0";
                txtNotification.Text = "0";
                txtEmail.Text = "0";
                txtSms.Text = "0";
                ActiveState();
                geturl();
            }
            }
            
            else
            {
                Response.Redirect("~\\frmIndex.aspx", false);
            }
        
    }

    public void ActiveState()
    {
        try
        {
            if (btnSubmit.Text == "Submit")
            {
                chkActive.Enabled = false;
                chkActive.Checked = true;
                chkActive_CheckedChanged(null, null);
            }
            else
            {
                chkActive.Enabled = true;
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
            strQry="";
            strQry = "exec [usp_PackageMst] @type='Fillgrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj=new DataSet();
            dsObj=sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvPackage.DataSource = dsObj;
                grvPackage.DataBind();
            }
            else
            {
                grvPackage.DataSource = null;
                grvPackage.DataBind();
            }

            if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                grvPackage.Columns[0].Visible = true;
                grvPackage.Columns[1].Visible = true;

            }
            else
            {
                grvPackage.Columns[0].Visible = false;
                grvPackage.Columns[1].Visible = false;
            }
        }
        catch 
        {

        }
    }
    public void clear()
    {
        try
        {
            txtAmt.Text = "";
            txtDesc.Text = "";
            txtEmail.Text = "0";
            txtFrmDate.Text = "";
            txtNotification.Text = "0";
            txtPackageNm.Text = "";
            txtSms.Text = "0";
            txtSpace.Text = "";
            txtToDate.Text = "";
            ddlCurrency.SelectedValue = "0";
            ddlPackageType.SelectedValue = "0";
            ddlCurrency.Visible = false;
            txtAmt.Visible = false;
            chkActive.Checked = false;
            btnSubmit.Text = "Submit";
            lblCurrency.Visible = false;
            lblAmt.Visible = false;
        }
        catch 
        {
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();
            if (chkActive.Checked == true)
            {
                if (ddlCurrency.SelectedValue == "0")
                {
                    MessageBox("Please Select Currency Name");
                    return;
                }
                else if (txtAmt.Text == "")
                {
                    MessageBox("Please Enter The Amount");
                    return;
                }
            }


            if (btnSubmit.Text == "Submit")
            {
                

                strQry = "";
                strQry = "exec usp_PackageMst @type='Insert',@vchPackage_type='" + Convert.ToString(ddlPackageType.SelectedItem.Text) + "',@vchPackage_name='" + Convert.ToString(txtPackageNm.Text) + "',@vchPackageDescription='" + Convert.ToString(txtDesc.Text) + "',@intNoOfSMS='" + Convert.ToString(txtSms.Text) + "',@intNoOfEmails='" + Convert.ToString(txtEmail.Text) + "',@intNoOfNotification='" + Convert.ToString(txtNotification.Text) + "',@fltDataSpace='" + Convert.ToString(txtSpace.Text) + "',@dtStartDate='" + Convert.ToDateTime(txtFrmDate.Text).ToString("MM/dd/yyyy") + "',@dtEndate='" + Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy") + "',@vchActiveStatus='" + Convert.ToString(chkActive.Checked == true ? "Yes" : "No") + "',@intInsertedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchInsertedIp='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";

                if (chkActive.Checked == true)
                {
                    strQry = strQry + ",@dtActivatedDate='" + (DateTime.Now.Date).ToString("MM/dd/yyyy") + "',@intCurrency_id='" + Convert.ToString(ddlCurrency.SelectedValue) + "',@flatAmount='" + Convert.ToString(txtAmt.Text) + "',@intActivatedBy='" + Convert.ToString(Session["User_Id"]) + "'";
                }
                else
                {
                    strQry = strQry + ",@intdeactivatedBy='" + Convert.ToString(Session["User_Id"]) + "'";
                }

                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Succssefully");
                    clear();
                    FillGrid();
                }
                else
                {
                    MessageBox("Insertion Failed");
                }
            }
            else
            {
                strQry = "";
                strQry = "exec usp_PackageMst @type='Update',@intPackage_id='" + ViewState["PackageId"].ToString() + "',@vchPackage_type='" + Convert.ToString(ddlPackageType.SelectedItem.Text) + "',@vchPackage_name='" + Convert.ToString(txtPackageNm.Text) + "',@vchPackageDescription='" + Convert.ToString(txtDesc.Text) + "',@intNoOfSMS='" + Convert.ToString(txtSms.Text) + "',@intNoOfEmails='" + Convert.ToString(txtEmail.Text) + "',@intNoOfNotification='" + Convert.ToString(txtNotification.Text) + "',@fltDataSpace='" + Convert.ToString(txtSpace.Text) + "',@dtStartDate='" + Convert.ToDateTime(txtFrmDate.Text).ToString("MM/dd/yyyy") + "',@dtEndate='" + Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy") + "',@vchActiveStatus='" + Convert.ToString(chkActive.Checked == true ? "Yes" : "No") + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchUpdatedIp='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";//,@intdeactivatedBy='""',@dtDiscontinueDate='""'";
                if (chkActive.Checked == false)
                {
                    strQry = strQry + ",@intdeactivatedBy='" + Convert.ToString(Session["User_Id"]) + "'";
                }
                else
                {
                    strQry=strQry+ ",@intCurrency_id='" + Convert.ToString(ddlCurrency.SelectedValue) + "',@flatAmount='" + Convert.ToString(txtAmt.Text) + "',@intActivatedBy='" + Convert.ToString(Session["UserId"]) + "',@dtActivatedDate='" + Convert.ToString(DateTime.Now) + "'";
                }
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Succssefully");
                    FillGrid();
                    clear();
                   
                }
            }
            ActiveState();

        }
        catch
        {
            MessageBox("Insertion Failed");
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
    public void FillCurrency()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_FillDropDown] @type='Currency'";
            sBindDropDownList(ddlCurrency, strQry, "vchISO_CODE", "intCurrency_id");
          

        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void chkActive_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkActive.Checked == true)
            {
                ddlCurrency.Visible = true;
                txtAmt.Visible = true;
                lblCurrency.Visible = true;
                lblAmt.Visible = true;
            }
            else
            {
                ddlCurrency.Visible = false;
                txtAmt.Visible = false;
                lblCurrency.Visible = false;
                lblAmt.Visible = false;
            }
        }
        catch 
        {
            
        }
    }
    protected void grvAdd_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvPackage.PageIndex = e.NewPageIndex;
            grvPackage.DataBind();
            FillGrid();

        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void grvAdd_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int PackageId = (int)grvPackage.DataKeys[e.RowIndex].Value;
            strQry = "";
            strQry = "exec usp_PackageMst @type='Delete',@intPackage_id='" + PackageId + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeleteBy='" + Convert.ToString(Session["User_Id"]) + "',@vchDeletedIp='" + GetSystemIP() + "'";  
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
    protected void grvPackage_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int PackageId = (int)grvPackage.DataKeys[e.NewEditIndex].Value;
            strQry = "";
            strQry = "exec [usp_PackageMst] @type='Fillgrid',@intPackage_id='" + PackageId + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ViewState["PackageId"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intPackage_id"]);
                txtPackageNm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPackage_name"]);
                ddlPackageType.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPackage_type"]);
                txtDesc.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPackageDescription"]);
                txtFrmDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtStartDate"]);
                txtToDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtEndate"]);
                txtAmt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["flatAmount"]);
                txtNotification.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intNoOfNotification"]);
                txtSms.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intNoOfSMS"]);
                txtSpace.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["fltDataSpace"]);
                txtEmail.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intNoOfEmails"]);

                if (Convert.ToString(dsObj.Tables[0].Rows[0]["vchActiveStatus"]) == "Yes")
                {
                    chkActive.Checked = true;
                    ddlCurrency.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intCurrency_id"]);
                }
                else
                {
                    chkActive.Checked = false;
                }

                chkActive_CheckedChanged(null, null);
               
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
                ActiveState();

            }
        }
        catch 
        {
            
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear();
    }
}
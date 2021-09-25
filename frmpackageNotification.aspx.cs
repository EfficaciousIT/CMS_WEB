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

public partial class frmpackageNotification : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                Label lblTile = new Label();
                lblTile = (Label)Page.Master.FindControl("lblPageTitle");
                lblTile.Visible = true;
                lblTile.Text = "Notification Package Details";
                if (!IsPostBack)
                {
                FillPackage();
                fillCurrentPackages();
                fillExpiredPackages();
              
                Fillgrid();
                RDB_SelectedIndexChanged(null, null);
                geturl();
               }
            }
            else
            {
                Response.Redirect("~\\frmIndex.aspx", false);
            }
        
    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPackage.SelectedValue != "0")
            {
                strQry = "";
                strQry = "exec [usp_PackageMst] @type='Fillgrid',@intPackage_Id='" + Convert.ToString(ddlPackage.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = new DataSet();
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    ddlPackageType.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPackage_type"]);
                    lblEmail.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intNoOfEmails"]);
                    lblSMS.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intNoOfSMS"]);
                    lblSpace.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["fltDataSpace"]);

                    lblAmt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["flatAmount"]);
                    lblCurr.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Currency"]);
                    
                }
                else
                {
                    ddlPackageType.Text = "0";
                    lblSpace.Text = "0";
                    lblSMS.Text = "0";
                    lblEmail.Text = "0";
                    lblAmount.Text = "0";
                    lblCurr.Text = "";
                }
            }
            else
            {

                ddlPackageType.Text = "0";
                lblSpace.Text = "0";
                lblSMS.Text = "0";
                lblEmail.Text = "0";
                lblAmount.Text = "0";
                lblCurr.Text = "";
            }
        }
        catch
        {
            
        }
    }

    public void FillPackage()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_FillDropDown] @type='FillPackage',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlPackage, strQry, "vchPackage_name", "intPackage_id");

        }
        catch 
        {
            
        }
    }

    private void fillCurrentPackages()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_PackageMst] @type='FillCurrentPackage',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = new DataSet();
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvCurrentPkg.DataSource = dsObj;
                grvCurrentPkg.DataBind();
            }
        }
        catch
        {
          
        }
    }

    private void fillExpiredPackages()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_PackageMst]  @type='FillExpirePackage',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = new DataSet();
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvExpirePkg.DataSource = dsObj;
                grvExpirePkg.DataBind();
            }
        }
        catch 
        {
            
        }
    }
   
   
    public void Fillgrid()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_PackageMst] @type='FillCurrentPackage',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = new DataSet();
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvCurrentPkg.DataSource = dsObj;
                grvCurrentPkg.DataBind();
            }
            else
            {
                grvCurrentPkg.DataSource = null;
                grvCurrentPkg.DataBind();
            }
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
    protected void btnBuy_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();
            if (RDB.Items[0].Selected == true)
            {
                if (txtPayment.Text == "")
                {
                    MessageBox("Please Enter Cheque No.");
                    txtPayment.Focus();
                    return;
                }
            }
            else if (RDB.Items[1].Selected == true)
            {
                if (txtPayment.Text == "")
                {
                    MessageBox("Please Enter Reference Name");
                    txtPayment.Focus();
                    return;
                }
            }
            else if (RDB.Items[2].Selected == true)
            {


            }

            strQry = "";
            strQry = "exec usp_PackageBuy @type='CheckExist',@intPackageId='" + Convert.ToString(ddlPackage.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = new DataSet();
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Selected Package Added Already");
                Clear();
                return;
            }


            strQry = "";
            strQry = "exec usp_PackageBuy @type='Insert',@intPackageId='" + Convert.ToString(ddlPackage.SelectedValue) + "',@intInsertedBy='" + Session["UserId"] + "',@intInsertedIp='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intNoOfPackage='" + Convert.ToString(txtNoOfPackage.Text) + "',@vchPaymentMode='" + Convert.ToString(RDB.SelectedValue) + "',@vchPaymentDetail='" + Convert.ToString(txtPayment.Text).Trim() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Package Bought Successfully!");
                Clear();
               
            }
            fillCurrentPackages();
            fillExpiredPackages();
        }
        catch 
        {
            
        }
    }
    public void Clear()
    {
        ddlPackage.SelectedValue = "0";
        lblAmt.Text = "0";
        lblCurr.Text = "0";
        lblEmail.Text = "0";
        lblSpace.Text = "0";
        txtNoOfPackage.Text = "";
        lblTotalAmount.Text = "";
        lblSMS.Text = "0";
        ddlPackageType.SelectedValue = "0";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
   
  
    protected void txtNoOfPackage_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtNoOfPackage.Text != "")
            {
                lblTotalAmount.Text = Convert.ToString(Convert.ToDouble(lblAmt.Text) * Convert.ToDouble(txtNoOfPackage.Text));
            }
        }
        catch (Exception)
        {
            
          
        }
       // txtNoOfPackage.Attributes.Add("onchange", " AmtCal()");
       
    }
    protected void RDB_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (RDB.SelectedValue == "0")
            {
                lblRef.Text = "Cheque No.";
                lblRef.Visible = true;
                txtPayment.Visible = true;
            }
            else if (RDB.SelectedValue == "1")
            {
                lblRef.Text = "Reference No.";
                lblRef.Visible = true;
                txtPayment.Visible = true;
            }
            else
            {
                
                lblRef.Visible = false;
                txtPayment.Visible = false;
            }
        }
        catch 
        {
            
        }
    }
}

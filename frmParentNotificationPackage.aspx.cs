using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmParentNotificationPackage :DBUtility
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
                Label lblTitle = new Label();
                lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
                lblTitle.Visible = true;
                lblTitle.Text = "Notification Package Detail";
                if (!IsPostBack)
                {
                 FillPackage();
                 fillCurrentPackages();
                 fillExpiredPackages();
                 geturl();
                }
            }
            else
            {
                Response.Redirect("~\\frmIndex.aspx", false);
            }
        
    }
    private void fillCurrentPackages()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_ParentPackages] @type='FillCurrentPackage',@intSchoolId='" + Convert.ToString(Session["School_id"]) + "',@intParentId='" + Session["User_id"] + "'";
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
            strQry = "exec [usp_ParentPackages]  @type='FillExpirePackage',@intSchoolId='" + Convert.ToString(Session["School_id"]) + "',@intParentId='" + Session["User_Id"] + "'";
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
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPackage.SelectedValue != "0")
            {
                strQry = "";
                strQry = "exec [usp_ParentPackages] @type='FillDetail',@intSchoolPackage_id='" + Convert.ToString(ddlPackage.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = new DataSet();
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                   // ddlPackageType.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPackage_type"]);
                    lblEmail.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intNoOfEmails"]);
                    lblSMS.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intNoOfSMS"]);
                    lblSpace.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["fltDataSpace"]);

                    lblAmt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["flatAmount"]);
               //     lblCurr.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Currency"]);

                }
                else
                {
                    //ddlPackageType.Text = "0";
                    lblSpace.Text = "0";
                    lblSMS.Text = "0";
                    lblEmail.Text = "0";
                    lblAmount.Text = "0";
                    lblCurr.Text = "";
                }
            }
            else
            {

               // ddlPackageType.Text = "0";
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
            strQry = "exec [usp_ParentPackages] @type='FillPackage',@intSchoolId='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlPackage, strQry, "vchPackage_name", "intSchoolPackage_id");

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
            //if (Page.IsValid)
            //{
            //    return;
            //}
            //else
            //{
            //    return;
            //}
            if (RDB.Items[0].Selected == true)
            {
                if (txtMode.Text == "")
                {
                    MessageBox("Please Enter Cheque No.");
                    txtMode.Focus();
                    return;
                }
            }
            else if (RDB.Items[1].Selected == true)
            {
                if (txtMode.Text == "")
                {
                    MessageBox("Please Enter Reference Name");
                    txtMode.Focus();
                    return;
                }
            }
            else if (RDB.Items[2].Selected == true)
            {
                

            }

            if (RDB.Items[0].Selected == true)
            {
                if ((txtMode.Text == "" || txtMode.Text.Length < 3) && txtMode.Visible==true)
                {
                    MessageBox("Please Enter Cheque Number");
                    txtMode.Focus();
                    // R2.Validate();
                    return;
                }
            }
            else if (RDB.Items[1].Selected == true)
            {
                if ((txtMode.Text == "" || txtMode.Text.Length < 3) && txtMode.Visible == true)
                {
                    MessageBox( "Please Enter Reference umber");
                    txtMode.Focus();
                   // R2.Validate();
                    return;
                }
            }


            strQry = "";
            strQry = "exec usp_ParentPackages @type='Insert',@intPackageID='" + ddlPackage.SelectedItem.Value + "',@intSchoolId='" + Session["School_Id"] + "',@intParentId='" + Session["User_Id"] + "',@intStudentId='" + Session["Student_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@vchPaymentMode='" + RDB.SelectedValue + "',@vchAmount='" + lblAmt.Text + "',@vchPaymentDetail='" + Convert.ToString(txtMode.Text) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Package Bought Successfully!");
                fillCurrentPackages();
                fillExpiredPackages();
                Clear();
            }
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
        txtMode.Text = "";
        lblSMS.Text = "0";
        //ddlPackageType.SelectedValue = "0";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void ddlMonth1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lnkNext_Click(object sender, EventArgs e)
    {

    }
    protected void lnkPrevious_Click(object sender, EventArgs e)
    {

    }
    protected void lnkNxt_Click1(object sender, EventArgs e)
    {

    }
    protected void lnkPrev1_Click(object sender, EventArgs e)
    {

    }
    protected void RDB_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (RDB.Items[0].Selected == true)
            {
                txtMode.Visible = true;
                lblMode.Visible = true;
                lblMode.Text = "Cheque Number";
            }
            else if (RDB.Items[1].Selected == true)
            {
                txtMode.Visible = true;
                lblMode.Visible = true;
                lblMode.Text = "Reference ";
            }
            else if (RDB.Items[2].Selected == true)
            {
                txtMode.Visible = false;
                lblMode.Visible = false;
               
            }
        }
        catch
        {
            
           
        }
    }
}
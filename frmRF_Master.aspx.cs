using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Windows.Forms;
using System.Web.UI.WebControls;

public partial class frmRF_Master : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    NotifyIcon i = new NotifyIcon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["User_Id"]) != null)
        {
            System.Web.UI.WebControls.Label lblTitle = new System.Web.UI.WebControls.Label();
            lblTitle = (System.Web.UI.WebControls.Label)Page.Master.FindControl("lblPageTitle");
            lblTitle.Visible = true;
            lblTitle.Text = "RF Master";

            if (!IsPostBack)
            {
                FillGrid();

                i.BalloonTipIcon = ToolTipIcon.Info;
                i.BalloonTipText = "Balloon Tip Text.";
                geturl();
            }
        }
        else
        {
            Response.Redirect("~\\Default.aspx", false);
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
        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                strQry = "exec usp_RF_DeviceMst @type='Insert',@vchRF_No='" + Convert.ToString(txtRFNo.Text) + "',@intPort='" + Convert.ToString(txtPort.Text) + "',@vchIP='" + Convert.ToString(txtIP.Text) + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successufully!");
                    FillGrid();
                    clear();
                    return;
                }
            }
            else
            {
                strQry = "exec usp_RF_DeviceMst @type='Update', @intRFid='" + ViewState["Id"] + "',@vchRF_No='" + Convert.ToString(txtRFNo.Text) + "',@intPort='" + Convert.ToString(txtPort.Text) + "',@vchIP='" + Convert.ToString(txtIP.Text) + "',@intUpdatedBy='" + Session["User_Id"] + "',@vchUpdatedIp='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successufully!");
                    FillGrid();
                    clear();
                    return;
                }
            }
            
        }
        catch
        {
            
        }
    }
    protected void grvRF_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvRF.PageIndex = e.NewPageIndex;
        grvRF.DataBind();
    }
    protected void grvRF_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int id = (int)grvRF.DataKeys[e.NewEditIndex].Value;
            strQry = "exec usp_RF_DeviceMst  @type='FillGrid',@intRFid='" + id + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ViewState["Id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intRFid"]);
                txtPort.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intPort"]);
                txtIP.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchIP"]);
                txtRFNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchRF_No"]);
                tbc1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }


        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public void clear()
    {
        txtRFNo.Text = "";
        txtPort.Text = "";
        txtIP.Text = "";
        btnSubmit.Text = "Submit";
    }
    protected void grvRF_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)grvRF.DataKeys[e.RowIndex].Value;
            strQry = "exec usp_RF_DeviceMst @type='Delete',@intRFid='" + id +"',@intDeletedBy='" + Session["user_Id"] + "',@vchDeletedIp='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully");
                FillGrid();
                
                return;
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
            strQry = "exec usp_RF_DeviceMst @type='FillGrid'";
            dsObj = sGetDataset(strQry);
            grvRF.DataSource = dsObj;
            grvRF.DataBind();
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        i.Visible = true;

        i.BalloonTipIcon = ToolTipIcon.Info;
        i.BalloonTipText = "Balloon Tip Text.";
        i.ShowBalloonTip(30000);
        clear();
    }
}
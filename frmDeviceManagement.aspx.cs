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

public partial class frmDeviceManagement : DBUtility
{
    DataSet dsObj = new DataSet();
    string strQry = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                Label lblTile = new Label();
                lblTile = (Label)Page.Master.FindControl("lblPageTitle");
                lblTile.Visible = true;
                lblTile.Text = "Device Detail";
                if (!IsPostBack)
                {
                    FillGrid();
                    geturl();
                }
            }
            else
            {
                Response.Redirect("~\\frmIndex.aspx", false);
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
            grvDevice.DataSource = createDataTable();
            grvDevice.DataBind();

            if (Convert.ToString(Session["UserType_Id"]) == "5")
            {
                grvDevice.Columns[0].Visible = false;
                //txtDevicenumber.Enabled = false;
            }
            else
            {
                grvDevice.Columns[0].Visible = true;
            }
        }
        catch 
        {
            
           
        }
    }
    private DataSet createDataTable()
    {
        try
        {
            strQry = "exec usp_DeviceMaster @type='FillGrid',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            return dsObj;
        }
        catch
        {
            return dsObj;
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int id = (int)grvDevice.DataKeys[e.NewEditIndex].Value;
            strQry = "";
            strQry = "exec usp_DeviceMaster @type='FillGrid',@intSchool_id='" + Session["School_Id"] + "',@intDeviceId='"+ id +"'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ViewState["DeviceID"] = id;
                txtDevicenumber.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDeviceNum"]);
                txtIP.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchIp"]);
                txtPort.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPort"]);
                txtAPN.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAPN"]);
                txtAPNprovider.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchVPN_Provider"]);
                btnSubmin.Text = "Update";
                txtDevicenumber.Enabled = false;
                TabContainer1.ActiveTabIndex = 1;
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
    public void Clear()
    {
        txtDevicenumber.Text = "";
        txtAPNprovider.Text = "";
        txtIP.Text = "";
        txtAPN.Text = "";
        btnSubmin.Text = "Submit";
        txtPort.Text = "";
        txtDevicenumber.Enabled = true;
    }
    protected void btnSubmin_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();

            if (btnSubmin.Text == "Submit")
            {
                strQry = "";
                strQry = "exec usp_DeviceMaster @type='SaveExist',@vchDeviceNum='" + Convert.ToString(txtDevicenumber.Text) + "',@intSchool_id='" + Session["sCHOOL_Id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Device Number Exist Already");
                    return;
                }
                strQry = "exec usp_DeviceMaster @type='Insert',@vchDeviceNum='" + Convert.ToString(txtDevicenumber.Text) + "',@vchIp='" + Convert.ToString(txtIP.Text) + "',@vchPort='" + Convert.ToString(txtPort.Text) + "',@vchAPN='" + Convert.ToString(txtAPN.Text) + "',@vchVPN_Provider='" + Convert.ToString(txtAPNprovider.Text) + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@intSchool_id='" + Session["School_Id"] + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully!");
                    FillGrid();
                    Clear();
                    return;
                }
            }
            else
            {
                strQry = "";
                strQry = "exec usp_DeviceMaster @type='UpdateExist',@intDeviceId='"+ Convert.ToString(ViewState["DeviceID"]) +"',@vchDeviceNum='" + Convert.ToString(txtDevicenumber.Text) + "',@intSchool_id='" + Session["School_Id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Device Number Exist Already");
                    return;
                }
                strQry = "exec usp_DeviceMaster @type='Update',@intDeviceId='" + Convert.ToString(ViewState["DeviceID"]) + "',@vchDeviceNum='" + Convert.ToString(txtDevicenumber.Text) + "',@vchIp='" + Convert.ToString(txtIP.Text) + "',@vchPort='" + Convert.ToString(txtPort.Text) + "',@vchAPN='" + Convert.ToString(txtAPN.Text) + "',@vchVPN_Provider='" + Convert.ToString(txtAPNprovider.Text) + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@intSchool_id='" + Session["School_Id"] + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    FillGrid();
                    Clear();
                    return;
                }
            }

        }
        catch
        {
            
        }
    }
    protected void grvDevice_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)grvDevice.DataKeys[e.RowIndex].Value;
            strQry = "";
            strQry = "exec usp_DeviceMaster @type='Delete',@intDeviceId='" + Convert.ToString(id) + "'";
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
    protected void grvDevice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvDevice.PageIndex = e.NewPageIndex;
        grvDevice.DataBind();
        FillGrid();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            Clear();
        }
        catch 
        {
            
        }
    }
}

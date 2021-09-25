using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmDeviceAssign : DBUtility
{
    string strQry = "";
    DataSet dsObj=new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["School_Id"]) != null)
        {
            Label lblTile = new Label();
            lblTile = (Label)Page.Master.FindControl("lblPageTitle");
            lblTile.Visible = true;
            lblTile.Text = "Assignment Detail of RF Device,ID and Tracking Device";
            if (!IsPostBack)
            {
                FillSchool();
                FillDevice();
                FillCardGrid();
                FillDeviceGrid();
                FillRfGrid();
                chkAll.Visible = false;
                geturl();
            }
        }
        else
        {
            Response.Redirect("~\\frmIndex.aspx", false);
        }
    }
   
    public void FillRfGrid()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_DeviceAssignment @type='FillRFGrid',@School_id='" + ddlSchoolRf.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            grvRF.DataSource = dsObj;
            grvRF.DataBind();

        }
        catch (Exception)
        {

            
        }
    }
    public void FillCardGrid()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_DeviceAssignment @type='FillCardGrid',@School_id='" + ddlSchoolCard.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            grvCard.DataSource = dsObj;
            grvCard.DataBind();
        }
        catch (Exception)
        {

           
        }
    }
    public void FillDeviceGrid()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_DeviceAssignment @type='FillDeviceGrid',@School_id='" + ddlSchoolTrack.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            grvTrack.DataSource = dsObj;
            grvTrack.DataBind();
        }
        catch (Exception)
        {

            
        }
    }
    public void FillSchool()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_DeviceAssignment @type='FillSchool'";
            sBindDropDownList(ddlSchoolRf, strQry, "vchSchool_name", "intSchool_id");
            sBindDropDownList(ddlSchool, strQry, "vchSchool_name", "intSchool_id");
            sBindDropDownList(ddlSchoolCard, strQry, "vchSchool_name", "intSchool_id");
            sBindDropDownList(ddlSchoolTrack, strQry, "vchSchool_name", "intSchool_id");
        }
        catch 
        {
            
        }
    }
    public void FillDevice()
    {
        try
        {
                 strQry = "";
                 strQry = "exec usp_DeviceAssignment @type='FillDeviceType'";
            sBindDropDownList(ddlDeviceType, strQry, "Device", "ID");
        }
        catch (Exception)
        {
            
         
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();

            string type = "",Id="";
            Boolean Assign = false;
            if (Convert.ToString(ddlDeviceType.SelectedValue) == "1")
            {
                type = "AssignedCard";
            }
            else if (Convert.ToString(ddlDeviceType.SelectedValue) == "2")
            {
                type = "AssignedRF";
            }
            else if (Convert.ToString(ddlDeviceType.SelectedValue) == "3")
            {
                type = "AssignedTrackDevice";
            }
            for (int i = 0; i < chkLst.Items.Count; i++)
            {
                if (chkLst.Items[i].Selected == true)
                {
                    Assign = true;
                    strQry = "exec usp_DeviceAssignment @type='" + type + "',@ID='" + chkLst.Items[i].Value + "',@School_id='" + ddlSchool.SelectedValue + "'";
                    if (sExecuteQuery(strQry) != -1)
                    {

                    }
                }
            }
            if (Assign == true)
            {
                MessageBox("Assigned Successfully!");
                FillCardGrid();
                FillDeviceGrid();
                FillRfGrid();
                Clear();
            }
        }
        catch 
        {
            
        }
    }
    public void Clear()
    {
        ddlDeviceType.SelectedValue = "0";
        chkLst.Items.Clear();
        ddlSchool.SelectedValue = "0";
        chkAll.Visible = false;
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
    public void FillRF()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_DeviceAssignment @type='FillRF'";
            sBindCheckBoxList(chkLst, strQry, "vchRF_No", "intRFid");
        }
        catch (Exception)
        {
            
          
        }
    }
    public void FillID()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_DeviceAssignment @type='FillCard'";
            sBindCheckBoxList(chkLst, strQry, "vchCardNo", "intCard_id");

        }
        catch (Exception)
        {
        }

        
    }
    public void FillTrackinDevice()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_DeviceAssignment @type='FillTrackinDevice'";
            sBindCheckBoxList(chkLst, strQry, "vchDeviceNum", "intDeviceId");
        }
        catch (Exception)
        {

          
        }


    }
    protected void ddlDeviceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(ddlDeviceType.SelectedValue) == "1")
            {
                FillID();
            }
            else if (Convert.ToString(ddlDeviceType.SelectedValue) == "2")
            {
                FillRF();
            }
            else if (Convert.ToString(ddlDeviceType.SelectedValue) == "3")
            {
                FillTrackinDevice();
            }
            else
            {
                chkLst.Items.Clear();
            }

            if (chkLst.Items.Count > 0)
            {
                chkAll.Visible = true;
            }
            else
            {
                chkAll.Visible = false;
            }
        }
        catch (Exception)
        {
            
        }
    }
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAll.Checked)
        {
            for (int i = 0; i < chkLst.Items.Count; i++)
            {
                chkLst.Items[i].Selected = true;
            }

        }
        else
        {
            for (int i = 0; i < chkLst.Items.Count; i++)
            {
                chkLst.Items[i].Selected = false;
            }
        }
    }
    protected void chkLst_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < chkLst.Items.Count; i++)
            {
                if (chkLst.Items[i].Selected == true)
                {
                    chkAll.Checked = true;
                }
                else
                {
                    chkAll.Checked = false;
                    return;
                }
            }
        }
        catch (Exception)
        {
            
            
        }
    }
    protected void grvRF_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id=(int)grvRF.DataKeys[e.RowIndex].Value;
            strQry = "exec usp_DeviceAssignment @type='UnAssignedRF',@ID='" + id + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully");
                FillRfGrid();
                return;
            }
        }
        catch 
        {
            
        }
    }
    protected void grvTrack_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)grvTrack.DataKeys[e.RowIndex].Value;
            strQry = "exec usp_DeviceAssignment @type='UnAssignedTrackDevice',@ID='" + id + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Recoed Deleted Successfully");
                FillDeviceGrid();
                return;
            }
        }
        catch (Exception)
        {
            
           
        }
       
    }
    protected void grvCard_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
             int id = (int)grvCard.DataKeys[e.RowIndex].Value;
            strQry = "exec usp_DeviceAssignment @type='UnAssignedCard',@ID='" + id + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Recoed Deleted Successfully");
                FillCardGrid();
                return;
            }
        }
        catch (Exception)
        {
            
            
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void ddlSchoolRf_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillRfGrid();
    }
    protected void ddlSchoolCard_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCardGrid();
    }
    protected void ddlSchoolTrack_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDeviceGrid();
    }
    protected void grvCard_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvCard.PageIndex = e.NewPageIndex;
        grvCard.DataBind();
        FillCardGrid();
    }
    protected void grvTrack_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTrack.PageIndex = e.NewPageIndex;
        grvTrack.DataBind();
        FillDeviceGrid();
    }
    protected void grvRF_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvRF.PageIndex = e.NewPageIndex;
        grvRF.DataBind();
        FillRfGrid();
    }
}
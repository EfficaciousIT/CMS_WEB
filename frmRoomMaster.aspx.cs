using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmRoomMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj=new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {               
                if (!IsPostBack)
                {
                    FillBuilding();                    
                    FillGrid();                  
                    checksession();
                }                
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
            strQry = "exec usp_RoomMasterNew @type='Fillgrid',@intSchool_id='"+ Convert.ToString(Session["School_Id"]) +"'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        catch 
        {

        }
    }
    public void FillBuilding()
    {
        try
        {
            strQry = "exec usp_RoomMasterNew @type='FillBuilding',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(drpBuilding, strQry, "Building_name", "intBuilding_id");
        }
        catch
        {

        }
    }
    public void Fillwing()
    {
        try
        {
            strQry = "exec usp_RoomMasterNew @type='Fillwing',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "'";
            sBindDropDownList(drpWing, strQry, "Building_wing", "intWing_id");
        }
        catch
        {

        }
    }
    public void clear()
    {
        try
        {
            drpBuilding.ClearSelection();
            drpWing.ClearSelection();
            ddlFloor.SelectedValue = "0";
            txtRoom.Text = "";
            txtDescription.Text = "";
            btnSubmit.Text = "Submit";
        }
        catch 
        {
        }
    }
    public void FillFloor()
    {
        try
        {
            strQry = "exec usp_RoomMasterNew @type='FillFloor',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlFloor, strQry, "vchFloor_name", "intFloor_id");
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
            FillGrid();

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
        try
        {
            geturl();
            strQry = "";
            if (btnSubmit.Text == "Submit")
            {
                strQry = "exec usp_RoomMasterNew @type='CheckSaveExist',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@intFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@vchRoom_name='" + Convert.ToString(txtRoom.Text) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Room Name Already Exist On Selected Floor");
                    txtRoom.Focus();
                    return;
                }

                strQry = "exec usp_RoomMasterNew @type='Insert',@vchRoom_name='" + Convert.ToString(txtRoom.Text).Trim() + "',@vchDescription='" + Convert.ToString(txtDescription.Text).Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@intFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@intInserted_by='" + Convert.ToString(Session["User_Id"]) + "',@Inserted_IP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully");
                    FillGrid();
                    clear();
                }
            }
            else
            {
                strQry = "exec usp_RoomMasterNew @type='CheckUpdateExist',@intRoom_id='" + ViewState["RoomId"] + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@vchRoom_name='" + Convert.ToString(txtRoom.Text) + "',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@intFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Room Name Already Exist On Selected Floor");
                    txtRoom.Focus();
                    return;
                }

                strQry = "exec usp_RoomMasterNew @type='Update',@intRoom_id='" + Convert.ToString(ViewState["RoomId"]) + "',@vchRoom_name='" + Convert.ToString(txtRoom.Text).Trim() + "',@vchDescription='" + Convert.ToString(txtDescription.Text).Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@intFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@IntUpdated_By='" + Convert.ToString(Session["User_Id"]) + "',@Updated_IP='" + GetSystemIP() + "'";

                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully");
                    FillGrid();
                    clear();
                }
            }
            Response.Redirect("frmRoomMaster.aspx",false);
        }
        catch 
        {
            
        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
        try
        {
            strQry = "";
            int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            ViewState["RoomId"] = id;
            strQry = "exec [usp_RoomMasterNew] @type='Select',@intRoom_id='" + id + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpBuilding.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intBuilding_id"]);
                Fillwing();
                drpWing.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intWing_id"]);
                FillFloor();
                ddlFloor.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intFloor_id"]);
                txtRoom.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchRoom_name"]);
                txtDescription.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDescription"]);
                btnSubmit.Text = "Update";
                TBC.ActiveTabIndex = 1;

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
            int id = (int)grvDetail.DataKeys[e.RowIndex].Value;
            strQry = "";
            strQry = "exec [usp_RoomMasterNew] @type='Delete',@intRoom_id='" + id + "',@intDeleted_By='" + Convert.ToString(Session["User_Id"]) + "',@vchDeleted_IP='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully!");
                FillGrid();
            }

        }
        catch 
        {
            
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtDescription.Text = "";
        txtRoom.Text = "";
        drpBuilding.ClearSelection();
        drpWing.ClearSelection();
        ddlFloor.SelectedValue = "0";
        btnSubmit.Text = "Submit";
    }

    protected void drpBuilding_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillwing();
    }
    protected void drpWing_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFloor();
    }
}
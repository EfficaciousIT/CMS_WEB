using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HostelRoom : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (drpBuilding.SelectedValue == "0")
        {
            MessageBox("Please Select Building Name!");
            drpBuilding.Focus();
            return;
        }
        if (drpWing.SelectedValue == "0")
        {
            MessageBox("Please Select Wing Name!");
            drpWing.Focus();
            return;
        }
        if (ddlFloor.SelectedValue == "0")
        {
            MessageBox("Please Select Floor Name!");
            drpWing.Focus();
            return;
        }
        if (txtRoom.Text == "")
        {
            MessageBox("Please Enter Room Name!");
            txtRoom.Focus();
            return;
        }
        try
        {
            geturl();
            strQry = "";
            if (btnSubmit.Text == "Submit")
            {
                strQry = "exec usp_HostelRoom @type='CheckSaveExist',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@vchRoom_name='" + Convert.ToString(txtRoom.Text) + "',@intFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Room Name Already Exist On Selected Floor");
                    txtRoom.Focus();
                    return;
                }

                strQry = "exec usp_HostelRoom @type='Insert',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@intFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@vchRoom_name='" + Convert.ToString(txtRoom.Text).Trim() + "',@intTotalChairs='" + Convert.ToString(txtChair.Text).Trim() + "',@intTotalLights='" + Convert.ToString(txtLight.Text).Trim() + "',@intTotalFan='" + Convert.ToString(txtFan.Text).Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intInserted_by='" + Convert.ToString(Session["User_Id"]) + "',@Inserted_IP='" + GetSystemIP() + "'";
               // ,@intTotalBed='" + Convert.ToString(drpBed.SelectedItem.Text).Trim() + "'

                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully");
                    FillGrid();
                    clear();
                }
            }
            else
            {
                strQry = "exec usp_HostelRoom @type='CheckUpdateExist',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelRoom_id='" + ViewState["RoomId"] + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@vchRoom_name='" + Convert.ToString(txtRoom.Text) + "',@intFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Room Name Already Exist On Selected Floor");
                    txtRoom.Focus();
                    return;
                }

                strQry = "exec usp_HostelRoom @type='Update',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelRoom_id='" + Convert.ToString(ViewState["RoomId"]) + "',@vchRoom_name='" + Convert.ToString(txtRoom.Text).Trim() + "',@intTotalChairs='" + Convert.ToString(txtChair.Text).Trim() + "',@intTotalLights='" + Convert.ToString(txtLight.Text).Trim() + "',@intTotalFan='" + Convert.ToString(txtFan.Text).Trim() + "',";
                //strQry = strQry + "@intTotalBed='" + Convert.ToString(drpBed.SelectedItem.Text).Trim() + "'";
                strQry = strQry + "@intFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@IntUpdated_By='" + Convert.ToString(Session["User_Id"]) + "',@Updated_IP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully");
                    FillGrid();
                    clear();
                }
            }
            Response.Redirect("HostelRoom.aspx", false);
        }
        catch
        {

        }
    }
    public void FillGrid()
    {
        try
        {
            strQry = "exec usp_HostelRoom @type='Fillgrid',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();

        }
        catch
        {

        }
    }
    public void clear()
    {
        try
        {
            txtChair.Text = "";
            txtFan.Text = "";
            txtLight.Text = "";
            txtRoom.Text = "";
            ddlFloor.SelectedValue = "0";
            btnSubmit.Text = "Submit";
        }
        catch
        {
        }
    }
    public void FillBuilding()
    {
        try
        {
            strQry = "exec usp_HostelRoom @type='FillBuilding',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(drpBuilding, strQry, "Building_name", "HostelBuilding_id");
        }
        catch
        {

        }
    }
    public void Fillwing()
    {
        try
        {
            strQry = "exec usp_HostelRoom @type='Fillwing',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(drpWing, strQry, "Building_wing", "HostelWing_id");
        }
        catch
        {

        }
    }
    public void FillFloor()
    {
        try
        {
            strQry = "exec usp_HostelRoom @type='FillFloor',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlFloor, strQry, "HostelFloor_name", "HostelFloor_id");
        }
        catch
        {

        }
    }
    public void FillBed()
    {
        try
        {
            strQry = "exec usp_HostelRoom @type='FillBed',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(drpBed, strQry, "vchBed", "HostelBed_id");
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
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            strQry = "";
            int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            ViewState["RoomId"] = id;
            strQry = "exec [usp_HostelRoom] @type='Select',@HostelRoom_id='" + id + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpBuilding.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["HostelBuilding_id"]);
                Fillwing();
                drpWing.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["HostelWing_id"]);
                FillFloor();
                ddlFloor.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["HostelFloor_id"]);
                txtRoom.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchRoom_name"]);
                txtChair.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intTotalChairs"]);
                txtFan.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intTotalFan"]);
                txtLight.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intTotalLights"]);
                //drpBed.SelectedItem.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intTotalBed"]);
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
            strQry = "exec [usp_HostelRoom] @type='Delete',@HostelRoom_id='" + id + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeleted_By='" + Convert.ToString(Session["User_Id"]) + "',@vchDeleted_IP='" + GetSystemIP() + "'";
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
        drpBed.ClearSelection();
        txtChair.Text = "";
        txtFan.Text = "";
        txtLight.Text = "";
        txtRoom.Text = "";
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
    protected void ddlFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        //FillBed();
    }
}
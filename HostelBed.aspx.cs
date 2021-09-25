using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HostelBed : DBUtility
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
    public void FillGrid()
    {
        try
        {
            strQry = "exec usp_HostelBed @type='Fillgrid',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
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
            drpBuilding.ClearSelection();
            drpWing.ClearSelection();
            drpRoom.ClearSelection();
            txtBed.Text = "";
            ddlFloor.SelectedValue = "0";
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
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)grvDetail.DataKeys[e.RowIndex].Value;
            strQry = "";
            strQry = "exec [usp_HostelBed] @type='Delete',@HostelBed_Id='" + id + "',@intDeleted_By='" + Convert.ToString(Session["User_Id"]) + "',@vchDeleted_IP='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
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
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            strQry = "";
            int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            ViewState["BedId"] = id;
            strQry = "exec [usp_HostelBed] @type='Select',@HostelBed_Id='" + id + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpBuilding.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["HostelBuilding_id"]);
                Fillwing();
                drpWing.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["HostelWing_id"]);
                FillFloor();
                ddlFloor.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["HostelFloor_id"]);
                FillRoom();
                drpRoom.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["HostelRoom_id"]);
                txtBed.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchBed"]);
                btnSubmit.Text = "Update";
                TBC.ActiveTabIndex = 1;
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
        if (drpRoom.SelectedValue == "0")
        {
            MessageBox("Please Select Room Name!");
            drpRoom.Focus();
            return;
        }
        if (txtBed.Text == "")
        {
            MessageBox("Please Enter Bed Name!");
            txtBed.Focus();
            return;
        }
        try
        {
            geturl();
            strQry = "";
            if (btnSubmit.Text == "Submit")
            {
                strQry = "exec usp_HostelBed @type='CheckSaveExist',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@HostelRoom_id='" + Convert.ToString(drpRoom.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Bed Name Already Exist On Selected Room");
                    drpRoom.Focus();
                    return;
                }

                strQry = "exec usp_HostelBed @type='Insert',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@HostelRoom_id='" + Convert.ToString(drpRoom.SelectedValue).Trim() + "',@vchBed='" + Convert.ToString(txtBed.Text).Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Convert.ToString(Session["User_Id"]) + "',@Inserted_IP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully");
                    FillGrid();
                    clear();
                }
            }
            else
            {
                strQry = "exec usp_HostelBed @type='CheckUpdateExist',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelBed_Id='" + ViewState["BedId"] + "',@HostelFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@HostelRoom_id='" + Convert.ToString(drpRoom.SelectedValue) + "',@vchBed='" + Convert.ToString(txtBed.Text).Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Bed Name Already Exist On Selected Room");
                    drpRoom.Focus();
                    return;
                }
                else
                {
                    strQry = "exec usp_HostelBed @type='Update',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@HostelRoom_id='" + Convert.ToString(drpRoom.SelectedValue) + "',@HostelBed_Id='" + Convert.ToString(ViewState["BedId"]) + "',@vchBed='" + Convert.ToString(txtBed.Text).Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@IntUpdated_By='" + Convert.ToString(Session["User_Id"]) + "',@Updated_IP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

                    if (sExecuteQuery(strQry) != -1)
                    {
                        MessageBox("Record Updated Successfully");
                        FillGrid();
                        clear();
                    }
                }
            }
            Response.Redirect("HostelBed.aspx", false);
        }
        catch
        {

        }
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
        FillRoom();
    }
    public void FillBuilding()
    {
        try
        {
            strQry = "exec usp_HostelBed @type='FillBuilding',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
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
            strQry = "exec usp_HostelBed @type='Fillwing',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
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
            strQry = "exec usp_HostelBed @type='FillFloor',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlFloor, strQry, "HostelFloor_name", "HostelFloor_id");
        }
        catch
        {

        }
    }
    public void FillRoom()
    {
        try
        {
            strQry = "exec usp_HostelBed @type='FillRoom',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(drpRoom, strQry, "vchRoom_name", "HostelRoom_id");
        }
        catch
        {

        }
    }
}
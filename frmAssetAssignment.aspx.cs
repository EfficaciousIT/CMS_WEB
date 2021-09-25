using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmAssetAssignment : DBUtility
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
                    FillStd();
                    FillItem();
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
            strQry = "exec usp_AssetAssignment @type='Fillgrid',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
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
            ddlFloor.ClearSelection();
            ddlRoom.ClearSelection();
            ddlStandard.ClearSelection();
            ddlDivision.ClearSelection();
            ddlItem.ClearSelection();
            ddlItemDetails.ClearSelection();
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if(drpBuilding.SelectedValue=="0")
            {
                MessageBox("Please Select Building Name!");
                return;
                drpBuilding.Focus();
            }
            if (drpWing.SelectedValue == "0")
            {
                MessageBox("Please Select Wing!");
                return;
                drpWing.Focus();
            }
            if (ddlFloor.SelectedValue == "0")
            {
                MessageBox("Please Select Floor!");
                return;
                ddlFloor.Focus();
            }
            if (ddlRoom.SelectedValue == "0")
            {
                MessageBox("Please Select Room!");
                return;
                ddlRoom.Focus();
            }
            if (ddlStandard.SelectedValue == "0")
            {
                MessageBox("Please Select Standard!");
                return;
                ddlStandard.Focus();
            }
            if (ddlDivision.SelectedValue == "0")
            {
                MessageBox("Please Select Division!");
                return;
                ddlDivision.Focus();
            }
            if (ddlItem.SelectedValue == "0")
            {
                MessageBox("Please Select Item Name!");
                return;
                ddlItem.Focus();
            }
            if (txtQty.Text == "0")
            {
                MessageBox("please Select Quantity!");
                return;
                txtQty.Focus();
            }
            if (ddlItemDetails.SelectedValue == "0")
            {
                MessageBox("Please Select Item Details!");
                return;
                ddlItemDetails.Focus();
            }
            geturl();
            strQry = "";
            if (btnSubmit.Text == "Submit")
            {
                //strQry = "exec usp_AssetAssignment @type='CheckSaveExist',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@intFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@vchRoom_name='" + Convert.ToString(txtRoom.Text) + "'";
                //strQry = "exec usp_AssetAssignment @type='CheckSaveExist',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intType_id='" + Convert.ToString(ddlItemDetails.SelectedValue) + "'";
                //dsObj = sGetDataset(strQry);
                //if (dsObj.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox("Entered Record Already Exist!");
                //    ddlItemDetails.Focus();
                //    return;
                //}

                strQry = "exec usp_AssetAssignment @type='Insert',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@intFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@intRoom_id='" + Convert.ToString(ddlRoom.SelectedValue) + "',@intstandard_id='" + Convert.ToString(ddlStandard.SelectedValue) + "',@intDivision_id='" + Convert.ToString(ddlDivision.SelectedValue) + "',@intEquipItem_id='" + Convert.ToString(ddlItem.SelectedValue)  +"',@vchQuantity='" + Convert.ToString(txtQty.Text) + "',@intType_id='" + Convert.ToString(ddlItemDetails.SelectedValue) + "',@intInserted_by='" + Convert.ToString(Session["User_Id"]) + "',@InseretIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully");
                    FillGrid();
                    clear();
                }
            }
            else
            {
                //strQry = "exec usp_AssetAssignment @type='CheckUpdateExist',@intAsset_id='" + ViewState["AssetID"] + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intType_id='" + Convert.ToString(drpBuilding.SelectedValue) + "'";
                //dsObj = sGetDataset(strQry);
                //if (dsObj.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox("Entered Record Already Exist!");
                //    ddlItemDetails.Focus();
                //    return;
                //}

                strQry = "exec usp_AssetAssignment @type='Update',@intAsset_id='" + Convert.ToString(ViewState["AssetID"]) + "',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@intFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@intRoom_id='" + Convert.ToString(ddlRoom.SelectedValue) + "',@intstandard_id='" + Convert.ToString(ddlStandard.SelectedValue) + "',@intDivision_id='" + Convert.ToString(ddlDivision.SelectedValue) + "',@intEquipItem_id='" + Convert.ToString(ddlItem.SelectedValue) + "',@vchQuantity='" + Convert.ToString(txtQty.Text) + "',@intType_id='" + Convert.ToString(ddlItemDetails.SelectedValue) + "',@IntUpdate_by='" + Convert.ToString(Session["User_Id"]) + "',@UpdateIP='" + GetSystemIP() + "'";

                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully");
                    FillGrid();
                    clear();
                }
            }
            Response.Redirect("frmAssetAssignment.aspx", false);
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
            ViewState["AssetID"] = id;
            strQry = "exec [usp_AssetAssignment] @type='Select',@intAsset_id='" + id + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpBuilding.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intBuilding_id"]);
                Fillwing();
                drpWing.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intWing_id"]);
                FillFloor();
                ddlFloor.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intFloor_id"]);
                FillRoom();
                ddlRoom.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intRoom_id"]);
                ddlStandard.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
                FillDiv();
                ddlDivision.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                ddlItem.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intEquipItem_id"]);
                FillItemType();
                txtQty.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchQuantity"]);
                ddlItemDetails.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intType_id"]);

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
            strQry = "exec [usp_AssetAssignment] @type='Delete',@intAsset_id='" + id + "',@intDelete_by='" + Convert.ToString(Session["User_Id"]) + "',@DeleteIP='" + GetSystemIP() + "'";
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
    protected void drpBuilding_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillwing();
    }
    protected void drpWing_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFloor();
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
    public void FillBuilding()
    {
        try
        {
            strQry = "exec usp_AssetAssignment @type='FillBuilding',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
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
            strQry = "exec usp_AssetAssignment @type='Fillwing',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "'";
            sBindDropDownList(drpWing, strQry, "Building_wing", "intWing_id");
        }
        catch
        {

        }
    }
    public void FillFloor()
    {
        try
        {
            strQry = "exec usp_AssetAssignment @type='FillFloor',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlFloor, strQry, "vchFloor_name", "intFloor_id");
        }
        catch
        {

        }
    }

    public void FillRoom()
    {
        try
        {
            strQry = "exec usp_AssetAssignment @type='FillRoom',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@intFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlRoom, strQry, "vchRoom_name", "intRoom_id");
        }
        catch
        {

        }
    }
    protected void ddlFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillRoom();
    }
    public void FillStd()
    {
        try
        {
            strQry = "exec usp_AssetAssignment @type='FillStd',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlStandard, strQry, "vchStandard_name", "intstandard_id");
        }
        catch
        {

        }
    }
    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDiv();
    }
    public void FillDiv()
    {
        try
        {
            strQry = "exec usp_AssetAssignment @type='FillDiv',@intstandard_id='" + Convert.ToString(ddlStandard.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlDivision, strQry, "vchDivisionName", "intDivision_id");
        }
        catch
        {

        }
    }
    public void FillItem()
    {
        try
        {
            strQry = "exec usp_AssetAssignment @type='FillItem',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlItem, strQry, "vchItem_name", "intEquipItem_id");
        }
        catch
        {

        }
    }
    public void FillItemType()
    {
        try
        {
            strQry = "exec usp_AssetAssignment @type='FillItemType',@intEquipItem_id='" + Convert.ToString(ddlItem.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlItemDetails, strQry, "vchItem_Type", "intType_id");
        }
        catch
        {

        }
    }
    protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillItemType();
    }
}
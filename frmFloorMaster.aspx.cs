using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmFloorMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {              
                if (!IsPostBack)
                {
               
                        FillGrid();
                        geturl();
                        FillBuilding();
                }
             }
                else
                {
                    Response.Redirect("~\\Index.aspx", false);
                }            
        }
        catch
        {

        }
    }
    public void FillBuilding()
    {
        try
        {
            strQry = "exec usp_FloorMst @type='FillBuilding',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(drpBuilding, strQry, "Building_name", "intBuilding_id");
        }
        catch
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (drpBuilding.SelectedValue == "0")
        {
            MessageBox("Please Building Name!");
            drpBuilding.Focus();
            return;
        }
        if (drpWing.Text == "0")
        {
            MessageBox("Please select Wing Name!");
            drpWing.Focus();
            return;
        }
        if (txtFloor.Text == "")
        {
            MessageBox("Please Insert Floor Name!");
            txtFloor.Focus();
            return;
        }
        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                strQry = "";
                strQry = "exec usp_FloorMst  @type='CheckSaveExist',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@vchFloor_name='" + Convert.ToString(txtFloor.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_FloorMst  @type='Insert',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@vchFloor_name='" + Convert.ToString(txtFloor.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully!");                    
                    FillGrid();
                }
            }
            else
            {                
                    strQry = "";
                    strQry = "exec usp_FloorMst  @type='CheckUpdateExist',@intFloor_id='" + ViewState["FloorId"] + "',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@vchFloor_name='" + Convert.ToString(txtFloor.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        MessageBox("Entered Record Already Exist");
                        return;
                    }

                    strQry = "exec usp_FloorMst  @type='Update',@intFloor_id='" + ViewState["FloorId"] + "',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@vchFloor_name='" + Convert.ToString(txtFloor.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@IntUpdate_by='" + Session["User_id"] + "',@UpdateIP='" + GetSystemIP() + "'";
                    if (sExecuteQuery(strQry) != -1)
                    {
                        MessageBox("Record Updated Successfully!");                       
                        btnSubmit.Text = "Submit";
                        FillGrid();
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
            drpBuilding.ClearSelection();
            drpWing.ClearSelection();
            txtFloor.Text = "";
            strQry = "";
            strQry = "exec usp_FloorMst @type='FillGrid',@intSchool_id='"+ Session["School_Id"] +"'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
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
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)grvDetail.DataKeys[e.RowIndex].Value;
            ViewState["FloorId"] = id;
            strQry = "exec usp_FloorMst @type='Delete',@intSchool_id='" + Session["School_Id"] + "',@intFloor_id='" + Convert.ToString(id) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
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
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            ViewState["FloorId"] = "";
            strQry = "";
            int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            ViewState["FloorId"] = id;
            strQry = "exec usp_FloorMst  @type='edit',@intFloor_id='" + Convert.ToString(id) + "',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpBuilding.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intBuilding_id"]);
                Fillwing();
                drpWing.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intWing_id"]);
                txtFloor.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFloor_name"]);
                TBC.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch 
        {
            
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtFloor.Text = "";
    }
    protected void drpBuilding_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillwing();
    }
    public void Fillwing()
    {
        try
        {
            strQry = "exec usp_FloorMst @type='Fillwing',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "'";
            sBindDropDownList(drpWing, strQry, "Building_wing", "intWing_id");
        }
        catch
        {

        }
    }
}
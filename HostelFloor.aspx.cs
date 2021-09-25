using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class HostelFloor : DBUtility
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
                    FillBuilding();
                    FillGrid();
                    geturl();
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
            strQry = "exec usp_HostelFloor @type='FillBuilding',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
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
            strQry = "exec usp_HostelFloor @type='Fillwing',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(drpWing, strQry, "Building_wing", "HostelWing_id");
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
        if (txtFloor.Text == "")
        {
            MessageBox("Please Enter Floor Name!");
            txtFloor.Focus();
            return;
        }
        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                strQry = "";
                strQry = "exec usp_HostelFloor  @type='CheckSaveExist',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelFloor_name='" + Convert.ToString(txtFloor.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_HostelFloor  @type='Insert',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelFloor_name='" + Convert.ToString(txtFloor.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully!");
                    drpBuilding.ClearSelection();
                    drpWing.ClearSelection();
                    txtFloor.Text = "";
                    FillGrid();
                }
            }
            else
            {

                strQry = "";
                strQry = "exec usp_HostelFloor  @type='CheckUpdateExist',@HostelFloor_id='" + ViewState["FloorId"] + "',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelFloor_name='" + Convert.ToString(txtFloor.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_HostelFloor  @type='Update',@HostelFloor_id='" + ViewState["FloorId"] + "',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelFloor_name='" + Convert.ToString(txtFloor.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@IntUpdate_by='" + Session["User_id"] + "',@UpdateIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    drpBuilding.ClearSelection();
                    drpWing.ClearSelection();
                    txtFloor.Text = "";
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
            strQry = "";
            strQry = "exec usp_HostelFloor @type='FillGrid',@intSchool_id='" + Session["School_Id"] + "'";
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        drpBuilding.ClearSelection();
        drpWing.ClearSelection();
        txtFloor.Text = "";
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            strQry = "";
            int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            ViewState["FloorId"] = id;
            strQry = "exec usp_HostelFloor  @type='Edit',@HostelFloor_id='" + Convert.ToString(id) + "',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpBuilding.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["HostelBuilding_id"]);
                Fillwing();

                //strQry = "exec usp_HostelFloor @type='Fillwing',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                //sBindDropDownList(drpWing, strQry, "Building_wing", "HostelWing_id");

                drpWing.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["HostelWing_id"]);               
                txtFloor.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["HostelFloor_name"]);
                TBC.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
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
            ViewState["FloorId"] = id;
            strQry = "exec usp_HostelFloor @type='Delete',@HostelFloor_id='" + Convert.ToString(id) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "',@intSchool_id='" + Session["School_Id"] + "'";
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
        }
        catch
        {

        }
    }
    protected void drpBuilding_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillwing();
    }
}
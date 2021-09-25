using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class HostelWing : DBUtility
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
            strQry = "exec usp_HostelWing @type='FillBuilding',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(drpBuilding, strQry, "Building_name", "HostelBuilding_id");
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
        if (txtWing.Text == "")
        {
            MessageBox("Please Enter Wing Name!");
            txtWing.Focus();
            return;
        }

        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                strQry = "";
                strQry = "exec usp_HostelWing  @type='CheckSaveExist',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue).Trim() + "',@Building_wing='" + Convert.ToString(txtWing.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_HostelWing  @type='Insert',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue).Trim() + "',@Building_wing='" + Convert.ToString(txtWing.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully!");
                    drpBuilding.ClearSelection();
                    txtWing.Text = "";
                    FillGrid();
                }
            }
            else
            {
                strQry = "";
                strQry = "exec usp_HostelWing  @type='CheckUpdateExist',@HostelWing_id='" + ViewState["WingId"] + "',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue).Trim() + "',@Building_wing='" + Convert.ToString(txtWing.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_HostelWing  @type='Update',@HostelWing_id='" + Session["WingId"] + "',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue).Trim() + "',@Building_wing='" + Convert.ToString(txtWing.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@IntUpdate_by='" + Session["User_id"] + "',@UpdateIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    drpBuilding.ClearSelection();
                    txtWing.Text = "";
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
            strQry = "exec usp_HostelWing @type='FillGrid',@intSchool_id='" + Session["School_Id"] + "'";
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
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["WingId"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            //int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            //ViewState["WingId"] = id;
            strQry = "exec usp_HostelWing  @type='Edit',@HostelWing_id='" + Convert.ToString(Session["WingId"]) + "',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpBuilding.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["HostelBuilding_id"]);
                txtWing.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Building_wing"]);
             
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
            ViewState["WingId"] = id;
            strQry = "exec usp_HostelWing @type='Delete',@HostelWing_id='" + Convert.ToString(id) + "',@intSchool_id='" + Session["School_Id"] + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
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
}
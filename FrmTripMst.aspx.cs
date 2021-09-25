using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmTripMst : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    string strRoute_id = "", strTrip_id;
    string strRouteName = "", strStartFrom = "", strEnd = "", strFromTime = "", strEndTime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserType_Id"] != null && Session["User_Id"] != null)
        {
            //Label lblTitle = new Label();
            //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            //lblTitle.Visible = true;
            //lblTitle.Text = "Trip Master";
            if (!IsPostBack)
            {
                fillGrid();
                fillRoute();
            }
        }
    }
   

    protected void fillGrid()
    {
        strQry = "exec [usp_TripMaster] @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvTrip.DataSource = dsObj;
            grvTrip.DataBind();
        }
        else
        {
            grvTrip.DataSource = dsObj;
            grvTrip.DataBind();
        }
    }
    protected void fillRoute()
    {
        strQry = "exec [usp_TripMaster] @command='routefill',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlRoute, strQry, "vchRoute_name", "intRoute_id");
        
    }
    protected void grvTrip_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["TripId"] = Convert.ToString(grvTrip.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_TripMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intTrip_id='" + Convert.ToString(Session["TripId"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txttotime.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtendtime"]).ToString("HH:MM tt");
                txtStartPoint.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchTripStart_from"]);
                txtTrip.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchTrip_name"]);
                txtFrmTime.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtstarttime"]).ToString("HH:MM tt");
                txtEndPoint.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEnd"]);
                ddlRoute.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intRoute_id"]);
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch 
        {

        }
    }
    protected void grvTrip_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        strTrip_id = grvTrip.DataKeys[e.RowIndex].Values[0].ToString();
        strQry = "exec usp_TripMaster @command='delete',@intTrip_id='" + strTrip_id.Trim() + "',@intDeleted_By='" + Convert.ToString(Session["User_Id"]) + "',@vchDeleted_IP='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        int i = sExecuteQuery(strQry);
        if (sExecuteQuery(strQry) != -1)
        {
            MessageBox("Record Deleted Successfully!");
            fillGrid();
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
            strQry = "";

            if (btnSubmit.Text == "Submit")
            {
                strQry = "exec [usp_TripMaster] @command='CheckSaveExist',@vchTrip_name='" + Convert.ToString(txtTrip.Text) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Record Exist Already");
                    return;
                }


                strQry = "exec [usp_TripMaster] @command='insert',@vchTrip_name='" + Convert.ToString(txtTrip.Text) + "',@intRoute_id='" + Convert.ToString(ddlRoute.SelectedValue) + "',@vchTripStart_from='" + Convert.ToString(txtStartPoint.Text) + "',@vchTrip_end='" + Convert.ToString(txtEndPoint.Text) + "',@dtstarttime='" + Convert.ToString(txtFrmTime.Text) + "',@dtendtime='" + Convert.ToString(txttotime.Text) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Convert.ToString(Session["User_id"]) + "',@Inserted_IP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully!");
                    fillGrid();
                    Clear();
                }
            }
            else
            {


                strQry = "exec [usp_TripMaster] @command='CheckUpdateExist',@intTrip_id='" + Convert.ToString(Session["TripId"]) + "',@vchTrip_name='" + Convert.ToString(txtTrip.Text) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Record Exist Already");
                    return;
                }

                strQry = "exec [usp_TripMaster] @command='Update',@intTrip_id='" + Convert.ToString(Session["TripId"]) + "',@vchTrip_name='" + Convert.ToString(txtTrip.Text) + "',@intRoute_id='" + Convert.ToString(ddlRoute.SelectedValue) + "',@vchTripStart_from='" + Convert.ToString(txtStartPoint.Text) + "',@vchTrip_end='" + Convert.ToString(txtEndPoint.Text) + "',@dtstarttime='" + Convert.ToString(txtFrmTime.Text) + "',@dtendtime='" + Convert.ToString(txttotime.Text) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@IntUpdated_By='" + Convert.ToString(Session["User_id"]) + "',@Updated_IP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    fillGrid();
                    Clear();
                }
            }
            
        }
        catch 
        {
            
        }
    }
    public void Clear()
    {
        txtEndPoint.Text = "";
        txtFrmTime.Text = "";
        //txttotime = "";
        txtStartPoint.Text = "";
        txttotime.Text = "";
        txtTrip.Text = "";
        btnSubmit.Text = "Submit";
       ddlRoute.SelectedIndex = -1;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void grvTrip_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTrip.PageIndex = e.NewPageIndex;
        grvTrip.DataBind();
        fillGrid();
    }
}
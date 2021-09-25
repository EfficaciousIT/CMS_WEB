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

public partial class frmRouteDet : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    string strRoute_id = "";
    string strRouteName = "", strStartFrom = "", strEnd = "",strFromTime = "" , strEndTime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserType_Id"] != null && Session["User_Id"] != null)
        {
            //Label lblTitle = new Label();
            //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            //lblTitle.Visible = true;
            //lblTitle.Text = "Route Master";
            if (!IsPostBack)
            {
                fillGrid();
            }
        }
        else
        {
            Response.Redirect("~\\frmIndex.aspx", false);
        }
        
    }
    
    protected void fillGrid()
    {
        strQry = "exec usp_RouteMaster @command='select',@intSchool_id='" + Session["School_id"] + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdRoute.DataSource = dsObj;
            grdRoute.DataBind();
        }
        else
        {
            grdRoute.DataSource = dsObj;
            grdRoute.DataBind();
        }
    }
    public void Clear()
    {
        txtRouteName.Text = "";
        txtRouteFrom.Text = "";
        txtRouteTo.Text = "";
        txtfromtime.Text = "";
        txttotime0.Text = "";
        btnSubmit.Text = "Submit";
    }
    protected void grdRoute_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            strRoute_id = grdRoute.DataKeys[e.NewEditIndex].Values[0].ToString();
            Session["Route_Id"] = strRoute_id;
            strRouteName = grdRoute.DataKeys[e.NewEditIndex].Values[1].ToString();
            strStartFrom = grdRoute.DataKeys[e.NewEditIndex].Values[2].ToString();
            strFromTime = grdRoute.DataKeys[e.NewEditIndex].Values[3].ToString();
            strEndTime = grdRoute.DataKeys[e.NewEditIndex].Values[4].ToString();

            txtRouteName.Text = Convert.ToString(grdRoute.DataKeys[e.NewEditIndex].Values[1].ToString());
            txtRouteFrom.Text = Convert.ToString(grdRoute.DataKeys[e.NewEditIndex].Values[2].ToString());
            txtRouteTo.Text = Convert.ToString(grdRoute.DataKeys[e.NewEditIndex].Values[3].ToString());
            txtfromtime.Text = Convert.ToDateTime(grdRoute.DataKeys[e.NewEditIndex].Values[4].ToString()).ToString("HH:MM /tt");
            txttotime0.Text = Convert.ToDateTime(grdRoute.DataKeys[e.NewEditIndex].Values[5].ToString()).ToString("HH:MM /tt");

            TabContainer1.ActiveTabIndex = 1;
            btnSubmit.Text = "Update";
        }
        catch 
        {
            
        }
       

    }
    protected void grdRoute_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            strRoute_id = grdRoute.DataKeys[e.RowIndex].Values[0].ToString();

            strQry = "exec usp_RouteMaster @command='delete',@intRoute_id='" + strRoute_id + "',@intDeleted_by='" + Session["User_Id"] + "',@delete_ip='" + GetSystemIP() + "'";

            if (sExecuteQuery(strQry) != -1)
            {
                fillGrid();
                MessageBox("Record Deleted Successfully!");
            }
        }
        catch 
        {
            
        }
        
    }
    protected void imgbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {

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
            if (btnSubmit.Text == "Submit")
            {

                strQry = "";
                strQry = "exec [usp_RouteMaster] @command='insert',@vchRoute_name='" + Convert.ToString(txtRouteName.Text) + "',@vchStart_from='" + Convert.ToString(txtRouteFrom.Text) + "',@vchEnd='" + Convert.ToString(txtRouteTo.Text) + "',@dtstarttime='" + Convert.ToString(txtfromtime.Text) + "',@dtendtime='" + Convert.ToString(txttotime0.Text) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Convert.ToString(Session["User_Id"]) + "',@InsertedIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully!");
                    fillGrid();
                    Clear();
                }
            }
            else if (btnSubmit.Text == "Update")
            {
                strQry = "";
                strQry = "exec [usp_RouteMaster] @command='Update',@intRoute_id='" + Convert.ToString(Session["Route_Id"]) + "',@vchRoute_name='" + Convert.ToString(txtRouteName.Text) + "',@vchStart_from='" + Convert.ToString(txtRouteFrom.Text) + "',@vchEnd='" + Convert.ToString(txtRouteTo.Text) + "',@dtstarttime='" + Convert.ToString(txtfromtime.Text) + "',@dtendtime='" + Convert.ToString(txttotime0.Text) + "',@intUpdated_by='" + Convert.ToString(Session["User_Id"]) + "',@Updated_IP='" + GetSystemIP() + "'";
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
    protected void grdRoute_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdRoute.PageIndex = e.NewPageIndex;
            grdRoute.DataBind();
            fillGrid();
        }
        catch 
        {
            
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtRouteName.Text = "";
        txtRouteFrom.Text = "";
        txtRouteTo.Text = "";
        txtfromtime.Text = "";
        txttotime0.Text = "";
    }
}

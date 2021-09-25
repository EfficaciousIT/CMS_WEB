using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmTripwiseStudentRpt : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
       
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                Label lblTitle = new Label();
                lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
                lblTitle.Visible = true;
                lblTitle.Text = "Tripwise Student Present Report";
                if (!IsPostBack)
                {
                FillRoute();
               // txtFrmDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
               // txtToDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
            else
            {
                Response.Redirect("~\\frmIndex.aspx", false);
            }
        
    }

    public void FillTrip()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_TripwiseReport @type='FillTrip',@intRoute_id='" + Convert.ToString(ddlRoute.SelectedValue) + "',@intSchoolid='" + Session["School_id"] + "'";
            sBindDropDownList(ddlTrip, strQry, "vchTrip_name", "intTrip_id");
        }
        catch
        {
            
        }
    }

    public void FillRoute()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_TripwiseReport @type='FillRoute',@intSchoolid='" + Session["School_id"] + "'";
            sBindDropDownList(ddlRoute, strQry, "vchRoute_name", "intRoute_id");
        }
        catch 
        {
            
        }
    }

    protected void ddlTrip_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if(ddlTrip.SelectedValue!="0")
            {
                strQry = "";
                strQry = "exec usp_TripwiseReport @type='TripwiseStudentReport',@intSchoolid='" + Session["School_id"] + "',@intRoute_id='" + Convert.ToString(ddlRoute.SelectedValue) + "',@intTrip_id='" + Convert.ToString(ddlTrip.SelectedValue) + "'";//@dtAttendance_date='" + Convert.ToDateTime(txtFrmDate.Text).ToString("MM/dd/yyyy") + "',@Todate1='" + Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy") + "',
                dsObj = new DataSet();
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    grvTripDetails.DataSource = dsObj;
                    grvTripDetails.DataBind();
                }
                else
                {
                    grvTripDetails.DataSource = null;
                    grvTripDetails.DataBind();
                }

            }
        }
        catch
        {
            
           
        }
    }
   
    protected void ddlRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlRoute.SelectedValue != "0")
            {
                FillTrip();
            }
            else
            {
                ddlTrip.DataSource = null;
            }
        }
        catch 
        {
            
        }
    }
    protected void txtFrmDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            strQry = "";
            strQry = "exec usp_TripwiseReport @type='TripwiseStudentReport',@dtAttendance_date='" + Convert.ToDateTime(txtFrmDate.Text).ToString("MM/dd/yyyy") + "',@Todate1='" + Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy") + "',@intSchoolid='" + Session["School_id"] + "',@intRoute_id='" + Convert.ToString(ddlRoute.SelectedValue) + "',@intTrip_id='" + Convert.ToString(ddlTrip.SelectedValue) + "'";
            dsObj = new DataSet();
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    grvTripDetails.DataSource = dsObj;
                    grvTripDetails.DataBind();
                }
                else
                {
                    grvTripDetails.DataSource = null;
                    grvTripDetails.DataBind();
                }
        }
        catch 
        {
            
        }
    }
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            strQry = "";
            strQry = "exec usp_TripwiseReport @type='TripwiseStudentReport',@dtAttendance_date='" + Convert.ToDateTime(txtFrmDate.Text).ToString("MM/dd/yyyy") + "',@Todate1='" + Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy") + "',@intSchoolid='" + Session["School_id"] + "',@intRoute_id='" + Convert.ToString(ddlRoute.SelectedValue) + "',@intTrip_id='" + Convert.ToString(ddlTrip.SelectedValue) + "'";
            dsObj = new DataSet();
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvTripDetails.DataSource = dsObj;
                grvTripDetails.DataBind();
            }
            else
            {
                grvTripDetails.DataSource = null;
                grvTripDetails.DataBind();
            }
        }
        catch 
        {
            
        }
    }
}
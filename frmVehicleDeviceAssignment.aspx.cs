using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmVehicleDeviceAssignment : DBUtility
{
    DataSet dsObj=new DataSet();
    string strQry = "";
    protected void Page_Load(object sender, EventArgs e)
    {
           try
            {
                if (Session["UserType_Id"] != null && Session["User_Id"] != null)
                {
                    //Label lblTitle = new Label();
                    //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
                    //lblTitle.Visible = true;
                    //lblTitle.Text = "Vehicle-Device Assignment Master";
                    if (!IsPostBack)
                    {
                        FillTranspoter();
                        FillGrid();
                        FillDriver();
                        FillBus();
                        FillRoute();
                        FillTrip();
                        FillBusStop();
                        FillBusDevice();
                        FillBusTripDriver();
                        FillDevice();
                        geturl();
                    }
                }
                else
                {
                    Response.Redirect("~\\frmIndex.aspx", false);
                }
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
    public void FillTrip()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_VehicleDriverTrip_Assign  @type='FillTrip',@intSchool_id='" + Session["School_Id"] + "'";
            sBindDropDownList(ddlTrip, strQry, "vchTrip_name", "intTrip_id");

            strQry = "";
            strQry = "exec usp_BusStop_Trip_Assign @type='FillTrip',@intSchool_Id='" + Session["School_Id"] + "',@intRoute_id='" + Convert.ToString(ddlRoute.SelectedValue) + "'";
            sBindDropDownList(ddlTrips, strQry, "vchTrip_name", "intTrip_id");
        }
        catch 
        {
            
        }
    }

    public void FillBusStop()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_BusStop_Trip_Assign  @type='FillBusStop',@intSchool_Id='" + Session["School_Id"] + "',@intTrip_Id='" + Convert.ToString(ddlTrips.SelectedValue) + "'";
            sBindDropDownList(ddlBusStop, strQry, "vchBusStop_name", "intBusStop_id");
        }
        catch
        {
            
        }
    }

    public void FillTranspoter()
    {
        try
        {
            strQry="";
            strQry = "exec usp_BusMaster @type='FillTranspoter',@intSchool_id='" + Session["School_Id"] + "'";
            sBindDropDownList(ddlTranporterNm, strQry, "vchTransporter_name", "intTransporter_id");
            sBindDropDownList(ddlTranspoter, strQry, "vchTransporter_name", "intTransporter_id");
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
            strQry = "exec usp_BusMaster @type='FillGrid',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();


            strQry = "";
            strQry = "exec usp_BusStop_Trip_Assign @type='FillGrid',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            grvBusStop.DataSource = dsObj;
            grvBusStop.DataBind();
        }
        catch
        {
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                
                strQry = "";
                strQry = "exec usp_BusMaster @type='CheckSaveExist',@vchBusNumber='"+ Convert.ToString(txtBusNum.Text) +"'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Bus Number Already Exist");
                    txtBusNum.Focus();
                    return;
                }

                strQry = "";
                strQry = "exec usp_BusMaster @type='InsertUpdate',@intNoOfSeater='" + Convert.ToString(txtNoOfSeat.Text) + "',@vchBusNumber='" + Convert.ToString(txtBusNum.Text) + "',@intSchool_id='" + Session["School_Id"] + "',@intInsertby='" + Convert.ToString(Session["User_Id"]) + "',@insertip='" + GetSystemIP() + "',@intTranspoterId='" + Convert.ToString(ddlTranporterNm.SelectedValue) + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@UpdateIP='" + GetSystemIP() + "'";
           
            }
            else
            {
                strQry = "";
                strQry = "exec usp_BusMaster @type='CheckUpdateExist',@vchBusNumber='" + Convert.ToString(txtBusNum.Text) + "',@intBus_id='" + ViewState["BusId"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Bus Number Already Exist");
                    txtBusNum.Focus();
                    return;
                }

                strQry = "";
                strQry = "exec usp_BusMaster @type='InsertUpdate',@intBus_id='" + Convert.ToString(ViewState["BusId"]) + "',@intNoOfSeater='" + Convert.ToString(txtNoOfSeat.Text) + "',@vchBusNumber='" + Convert.ToString(txtBusNum.Text) + "',@intSchool_id='" + Session["School_Id"] + "',@intInsertby='" + Convert.ToString(Session["User_Id"]) + "',@insertip='" + GetSystemIP() + "',@intTranspoterId='" + Convert.ToString(ddlTranporterNm.SelectedValue) + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@UpdateIP='" + GetSystemIP() + "'";
           
            }

           if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Saved Successfully!");
                FillGrid();
                FillBus();
                FillBusDevice();
                FillBusTripDriver();
                Clear();
            }
        }
        catch 
        {
            
        }
    }
    public void Clear()
    {
        txtNoOfSeat.Text = "";
        txtBusNum.Text = "";
        ddlTranporterNm.SelectedValue = "0";
        ddlBus.SelectedValue = "0";
        ddlBuses.SelectedValue = "0";
        ddlDevice.SelectedValue = "0";
        btnAssign.Text = "Assign";
        btnSubmit.Text = "Submit";
        ddlTranspoter.SelectedValue = "0";
        ddlTrips.SelectedValue = "0";
        ddlDriver.SelectedValue = "0";
        btnAssign1.Text = "Assign";
        ddlRoute.SelectedValue = "0";
        ddlTrips.SelectedValue="0";
        ddlBusStop.SelectedValue = "0";
        txtFrmTime.Text = "";
        txtToTime.Text = "";
    }
    public void FillDriver()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_VehicleDriverTrip_Assign @type='FillDriver',@intSchool_id='" + Session["School_id"] + "',@intTranspoterId='" + Convert.ToString(ddlTranspoter.SelectedValue) + "'";
            sBindDropDownList(ddlDriver, strQry, "DriverNm", "intDriver_id");
        }
        catch
        {
            
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            strQry = "exec usp_BusMaster @type='FillGrid',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intBus_id='" + Convert.ToString(id) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ViewState["BusId"] = id;
                txtBusNum.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchBusNumber"]);
                txtNoOfSeat.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intNoOfSeater"]);
                ddlTranporterNm.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intTransporter_id"]);
                TabContainer2.ActiveTabIndex = 1;
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
            strQry = "";
            strQry = "exec usp_BusMaster  @type='Delete',@intSchool_id='" + Session["School_Id"] + "',@intBus_id='" + id + "'";
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
    public void FillBus()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_Bus_Device_Assigned @type='FillBuses',@intSchoolId='" + Session["School_Id"] + "'";
            
            sBindDropDownList(ddlBuses, strQry, "vchBusNumber", "intBus_id");


            sBindDropDownList(ddlBus, strQry, "vchBusNumber", "intBus_id");
        }
        catch
        {
            
        }
    }
    
    public void FillDevice()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_Bus_Device_Assigned @type='FillDevice',@intSchoolId='" + Session["School_Id"] + "'";
            sBindDropDownList(ddlDevice, strQry, "vchDeviceNum", "intDeviceId");
        }
        catch
        {
        }
    }
    protected void grvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvDetail.PageIndex = e.NewPageIndex;
        grvDetail.DataBind();

    }
    public void FillBusDevice()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_Bus_Device_Assigned  @type='FillGrid',@intSchoolId='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            grvBUSDevice.DataSource = dsObj;
            grvBUSDevice.DataBind();
        }
        catch (Exception)
        {
            
            
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            checksession();
            if (ddlBus.SelectedValue == "0")
            {
                return;
            }
            if (ddlDevice.SelectedValue == "0")
            {
                return;
            }
            strQry = "";
            if (btnAssign.Text == "Assign")
            {
                strQry = "exec usp_Bus_Device_Assigned @type='InsertUpdate',@intBus_id='" + Convert.ToString(ddlBus.SelectedValue) + "',@intDevice_Id='" + Convert.ToString(ddlDevice.SelectedValue) + "',@intInsertby='" + Session["User_Id"] + "',@insertip='" + GetSystemIP() + "',@intSchoolId='" + Session["School_Id"] + "'";
            }
            else
            {
                strQry = "exec usp_Bus_Device_Assigned @type='InsertUpdate',@intVD_id='" + ViewState["BusDeviceId"] + "',@intBus_id='" + Convert.ToString(ddlBus.SelectedValue) + "',@intDevice_Id='" + Convert.ToString(ddlDevice.SelectedValue) + "',@intInsertby='" + Session["User_Id"] + "',@insertip='" + GetSystemIP() + "',@intSchoolId='" + Session["School_Id"] + "'";
            }
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Device Assigned Successfully");
                FillBusDevice();
                FillDevice();
                FillBus();
                Clear();
            }
        }
        catch 
        {
            
        }
    }
    protected void grvBUSDevice_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int id = (int)grvBUSDevice.DataKeys[e.NewEditIndex].Value;
            strQry = "";
            strQry = "exec usp_Bus_Device_Assigned @type='FillGrid',@intSchoolId='" + Convert.ToString(Session["School_Id"]) + "',@intVD_id='" + id + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ViewState["BusDeviceId"] = id;
                ddlBus.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intBus_id"]);
                ddlDevice.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDeviceId"]);
                btnAssign.Text = "Update";
                TabContainer3.ActiveTabIndex = 1;
            }
        }
        catch 
        {
            
        }
    }
    protected void grvBUSDevice_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)grvBUSDevice.DataKeys[e.RowIndex].Value;
            strQry = "";
            strQry = "exec usp_Bus_Device_Assigned  @type='Delete',@intSchoolid='" + Session["School_Id"] + "',@intVD_id='" + id + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully!");
                FillBusDevice();
                FillBus();
                FillDevice();

            }
        }
        catch 
        {
            
        }
    }
    protected void ddlTranspoter_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDriver();
    }
    public void FillBusTripDriver()
    {
        try
        {
            strQry="";
            strQry="exec [usp_VehicleDriverTrip_Assign] @type='FillGrid',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            grvBusTripDriver.DataSource = dsObj;
            grvBusTripDriver.DataBind();
        }
        catch
        {
            
        }
    }
    [System.Web.Services.WebMethod]
    public static string callAssignButton(string TripId, string BusId)
    {

      string  strQry = "exec  [usp_VehicleDriverTrip_Assign] @type='CheckExist',@intSchool_id='" + Convert.ToString(1) + "',@intBus_id='" + Convert.ToString(BusId) + "',@intTrip_Id='" + Convert.ToString(TripId) + "'";
       DataSet dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            return "true";
            
        }
        return "false";
    }
     
    
    protected void btnAssign1_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();
            strQry = "";
            if (ddlBuses.SelectedValue == "0")
            {
                MessageBox("Please Select Bus");
                return;
            }
            if (ddlDriver.SelectedValue == "0")
            {
                MessageBox("Please Select Driver");
                return;
            }
            if (ddlTranspoter.SelectedValue == "0")
            {
                MessageBox("Please Select Transporter");
                return;
            }
            if (ddlTrip.SelectedValue == "0")
            {
                MessageBox("Please Select Trip");
                return;
            }

           
              
            


            if (btnAssign1.Text == "Assign")
            {

                strQry = "exec  [usp_VehicleDriverTrip_Assign] @type='CheckExist',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intBus_id='" + Convert.ToString(ddlBuses.SelectedValue) + "',@intTrip_Id='" + Convert.ToString(ddlTrip.SelectedValue) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Record Exist Already");
                    return;
                }

                strQry = "exec  [usp_VehicleDriverTrip_Assign] @type='CheckOtherExist',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intBus_id='" + Convert.ToString(ddlBuses.SelectedValue) + "',@intTrip_Id='" + Convert.ToString(ddlTrip.SelectedValue) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Selected Bus Or Trip Already Assigned To Some Other Trip Or Bus");
                    return;
                }


                strQry = "exec [usp_VehicleDriverTrip_Assign] @type='Insert',@intBus_id='" + Convert.ToString(ddlBuses.SelectedValue) + "',@intDriver_Id='" + Convert.ToString(ddlDriver.SelectedValue) + "',@intTrip_Id='" + Convert.ToString(ddlTrip.SelectedValue) + "',@intInsertby='" + Convert.ToString(Session["User_Id"]) + "',@insertip='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
            }
            else
            {

                strQry = "exec  [usp_VehicleDriverTrip_Assign] @type='CheckUpdateExist',@int_VDT_id='" + ViewState["DriverBus"] + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intBus_id='" + Convert.ToString(ddlBuses.SelectedValue) + "',@intTrip_Id='" + Convert.ToString(ddlTrip.SelectedValue) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Record Exist Already");
                    return;
                }


                strQry = "exec  [usp_VehicleDriverTrip_Assign] @type='CheckUpdateOtherExist',@int_VDT_id='" + ViewState["DriverBus"] + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intBus_id='" + Convert.ToString(ddlBuses.SelectedValue) + "',@intTrip_Id='" + Convert.ToString(ddlTrip.SelectedValue) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Selected Bus Or Trip Already Assigned To Some Other Trip Or Bus");
                    return;
                }

                strQry = "exec [usp_VehicleDriverTrip_Assign] @type='Update',@int_VDT_id='" + ViewState["DriverBus"] + "',@intBus_id='" + Convert.ToString(ddlBuses.SelectedValue) + "',@intDriver_Id='" + Convert.ToString(ddlDriver.SelectedValue) + "',@intTrip_Id='" + Convert.ToString(ddlTrip.SelectedValue) + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@UpdateIP='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
            }
            if (sExecuteQuery(strQry) != -1)
            {
             
                MessageBox("Assigned Successfully!");
                FillBusTripDriver();
                Clear();
            }
        }
        catch 
        {
            
        }
    }

  

    protected void grvBusTripDriver_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int id = (int)grvBusTripDriver.DataKeys[e.NewEditIndex].Value;
            strQry = "";
            strQry = "exec [usp_VehicleDriverTrip_Assign] @type='FillGrid',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@int_VDT_id='" + id + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ViewState["DriverBus"] = id;
                ddlBuses.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intBus_id"]);
                ddlTranspoter.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intTransporter_id"]);
                ddlTranspoter_SelectedIndexChanged(null, null);
                ddlDriver.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDriver_id"]);
                ddlTrip.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intTrip_id"]);
                //btnAssign1.Text = "Update";
                //TabContainer4.ActiveTabIndex = 1;
                TabContainer4.ActiveTabIndex = 1;
                btnAssign1.Text = "Update";
            }
        }
        catch
        {

        }
    }
    protected void grvBusTripDriver_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)grvBusTripDriver.DataKeys[e.RowIndex].Value;
            strQry = "";
            strQry = "exec [usp_VehicleDriverTrip_Assign] @type='Delete',@deleteIP='" + GetSystemIP() + "',@intDeleteBy='" + Session["User_Id"] + "',@int_VDT_id='" + id + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully");
                FillBusTripDriver();
                
            }
        }
        catch 
        {
            
        }
    }
    protected void grvBusTripDriver_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvBusTripDriver.PageIndex = e.NewPageIndex;
        grvBusTripDriver.DataBind();
    }
    protected void ddlBuses_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtBus.Value = Convert.ToString(ddlBuses.SelectedValue);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void ddlTrip_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
             txtTrip.Value = Convert.ToString(ddlTrips.SelectedValue);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void btnAssign1_Click1(object sender, EventArgs e)
    {

    }
    protected void ddlRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillTrip();
        }
        catch 
        {
            
        }
    }
    protected void btnAssign2_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();
            strQry = "";
            strQry = "exec usp_BusStop_Trip_Assign @type='Insert',@intBusStop_Id='" + Convert.ToString(ddlBusStop.SelectedValue) + "',@intRoute_id='" + Convert.ToString(ddlRoute.SelectedValue) + "',@intTrip_Id='" + Convert.ToString(ddlTrips.SelectedValue) + "',@dtFromTime='" + Convert.ToString(txtFrmTime.Text) + "',@dtToTime='" + Convert.ToString(txtToTime.Text) + "',@intSchool_Id='" + Session["School_Id"] + "',@intInserted_id='" + Session["User_Id"] + "',@vchInserted_IP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Saved Successfully");
                FillGrid();
                Clear();
            }

        }
        catch
        {
            
        }
    }
    protected void ddlTrips_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillBusStop();
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
            strQry = "exec usp_BusStop_Trip_Assign  @type='FillRoute',@intSchool_id='" + Session["School_Id"] + "'";
            sBindDropDownList(ddlRoute, strQry, "vchRoute_name", "intRoute_id");

        }
        catch 
        {
            
        }
    }
    protected void grvBusStop_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int id = (int)grvBusStop.DataKeys[e.NewEditIndex].Value;
            strQry = "";
            strQry = "exec usp_BusStop_Trip_Assign @type='Fillgrid',@intSchool_Id='" + Session["School_Id"] + "',@int_BT_id='" + id + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ViewState["BTAssign"] = id;
                ddlRoute.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intRoute_id"]);
            }
        }
        catch 
        {
            
        }
    }
    protected void grvBusStop_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)grvBusStop.DataKeys[e.RowIndex].Value;
            strQry = "";
            strQry = "exec usp_BusStop_Trip_Assign @type='Delete',@int_BT_id='" + id + "',@intDeleted_id='" + Convert.ToString(Session["User_Id"]) + "',@vchDeleted_IP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully!");
                FillGrid();
                FillBusStop();
                FillTrip();
                FillRoute();
            }
        }
        catch 
        {
            
        }
    }
    protected void ddlRoute_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void grvBusStop_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvBusStop.PageIndex = e.NewPageIndex;
        grvBusStop.DataBind();
    }
}
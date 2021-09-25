using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Globalization;


public partial class frmBusTracking : DBUtility
{
    DataSet dsObj = new DataSet();
    string strQry = "";
    string strFromDate = "", strToDate = "";
    string strLastDayOfMonth = "";
    bool boolStatus;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lblTitle = new Label();
        //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
        //lblTitle.Visible = true;
        //lblTitle.Text = "Bus Services";
        if (!IsPostBack)
        {
            GetSelectedRecord();
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["Student_id"]) == "374")
                {
                    TabPanel1.Visible = false;
                    TabPanel5.Visible = false;
                    TabPanel3.Visible = false;
                    TabPanel4.Visible = false;
                    TabPanel6.Visible = false;
                    TabPanel7.Visible = false;
                    TabPanel8.Visible = false;
                    TabPanel9.Visible = false;
                    TabPanel10.Visible = false;
                    TabPanel11.Visible = true;
                }
                else if (Convert.ToString(Session["UserType_id"]) == "1")
                {
                    TabPanel1.Visible = true;
                    //TabPanel5.Visible = false;
                    TabPanel3.Visible = false;

                    //TabPanel4.Visible = false;
                    //TabPanel6.Visible = false;
                    //TabPanel7.Visible = false;
                    TabPanel8.Visible = false;
                    TabPanel9.Visible = false;
                    //TabPanel10.Visible = false;
                    TabPanel11.Visible = false;
                }
                else
                {
                    TabPanel11.Visible = false;
                }
                
                checksession();
                geturl();
                fillgrid();
            }

           

            DateTime today = DateTime.Today;
            int numberOfDaysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime endOfMonth = new DateTime(today.Year, today.Month, numberOfDaysInMonth);
            Session["startMonthDate"] = Convert.ToDateTime(startOfMonth).ToString("MM/dd/yyyy");
            Session["LastMonthDate"] = Convert.ToDateTime(endOfMonth).ToString("MM/dd/yyyy");
            fillAbsentDetails(Convert.ToString(Session["startMonthDate"]), Convert.ToString(Session["LastMonthDate"]));
            fillCurrentMonth(Convert.ToString(Session["startMonthDate"]), Convert.ToString(Session["LastMonthDate"]));             
            GridView3.DataSource = fillService();
            GridView3.DataBind();     
            GridView6.DataSource = fillBilling();
            GridView6.DataBind();
        }
    }
    protected void fillgrid()
    {
        try
        {

            string Disquery = "Execute dbo.usp_BusFeesMaster @command='GridBusSerReq',@intSchool_id='" + Session["School_id"] + "'";
            int grvDetail1 = sBindGrid(BusRequestDetail, Disquery);

            string Disy1 = "Execute dbo.usp_BusFeesMaster @command='grid_status',@intParent_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";
            int grvDetail2 = sBindGrid(GridVApp, Disy1);

            string Disy3 = "Execute dbo.usp_BusFeesMaster @command='grid_status',@intParent_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";
            int grvDetail3 = sBindGrid(GridView1, Disy3);
            //;
            //string query5 = "Execute dbo.usp_BusService @command='SelectStud',@intstanderd_id='" + stdvalid + "',@intDivision_id='" + divvalid + "',@intSchool_id='" + Session["School_id"] + "'";
            //bool st1 = sRadioButtonList(SelectBusSer, query5, "name", "intStudent_id");

        }
        catch (Exception ex)
        {
        }

    }


    private void GetSelectedRecord()
    {
        for (int i = 0; i < BusRequestDetail.Rows.Count; i++)
        {
            RadioButton rb = (RadioButton)BusRequestDetail.Rows[i]
                            .Cells[0].FindControl("id11");
            if (rb != null)
            {
                if (rb.Checked)
                {
                    HiddenField hf = (HiddenField)BusRequestDetail.Rows[i]
                                    .Cells[0].FindControl("HiddenField1");
                    if (hf != null)
                    {
                        ViewState["SelectedContact"] = hf.Value;
                        string st = Convert.ToString(ViewState["SelectedContact"]);
                        td1.Text = st;
                    }

                    break;
                }
            }
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        try
        {
            string idv = Convert.ToString(td1.Text);
            string ipval = GetSystemIP();

            string ins2 = "Execute dbo.usp_BusFeesMaster @command='Check_Bus_Service',@intParent_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";

            dsObj = sGetDataset(ins2);


            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Bus services Already Activated");
            }
            else
            {

                string insbusreq1 = "Execute dbo.usp_BusFeesMaster @command='Pare_bus_serappy',@intParent_id='" + Session["User_id"] + "',@intStudent_id='" + Session["Student_id"] + "',@intStandard_id='" + Session["Standard_id"] + "',@intDivision_id='" + Session["Division_id"] + "',@intBusService_id='" + idv + "',@IntInsert_id='" + Session["User_id"] + "',@IntInsert_IP='" + ipval + "',@intSchool_id='" + Session["School_id"] + "'";
                int str = sExecuteQuery(insbusreq1);
                if (str != -1)
                {
                    string display = "Bus Service Successfully Activated!";
                    MessageBox(display);
                    //clear();

                }
                else
                {
                    MessageBox("ooopppsss!Bus Service Activation Failed");

                }
            }
        }
        catch
        {

        }

    }
    protected void BusRequestDetail_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridVApp_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridVApp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridVApp.DataKeys[e.RowIndex].Value);
            Session["Deleteid"] = GridVApp.DataKeys[e.RowIndex].Value;
            string IntDelete_IP = GetSystemIP();
            string strQry1 = "Execute dbo.usp_BusFeesMaster @command='Delete_Request',@intService_id='" + id + "',@intParent_id='" + Session["User_id"] + "',@intschool_id='" + Session["School_id"] + "',@intDelete_id='" + Session["User_id"] + "',@IntDelete_IP='" + IntDelete_IP + "'";
            if (sExecuteQuery(strQry1) != -1)
            {
                MessageBox("Record Deleted Successfully");
                fillgrid();

            }

        }
        catch
        {


        }
    }
    private object createDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Date");
        dt.Columns.Add("Starttime");
        dt.Columns.Add("endtime");
        dt.Columns.Add("Driver");

        DataRow dr = dt.NewRow();
        dr["Date"] = "01-07-2014";
        dr["Starttime"] = "07:05";
        dr["endtime"] = "08:10";
        dr["Driver"] = "Ajay";

        dt.Rows.Add(dr);
        return dt;
    }
    private void fillTravelDetails(string strFromDate, string strToDate)
    {
        strQry = "usp_BusService @command='PresentDet',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@fromdate='" + Convert.ToString(strFromDate.Trim()) + "',@todate='" + Convert.ToString(strToDate) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdHistory.DataSource = dsObj;
            grdHistory.DataBind();            
        }
        else
        {
            grdHistory.DataSource = dsObj;
            grdHistory.DataBind();
        }
    }
    private void fillCurrentMonth(string strFromDate, string strToDate)
    {
        strQry = "usp_BusService @command='PresentDet',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@fromdate='" + Convert.ToString(strFromDate.Trim()) + "',@todate='" + Convert.ToString(strToDate) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdCurrentMonth.DataSource = dsObj;
            grdCurrentMonth.DataBind();

            grdHistory.DataSource = dsObj;
            grdHistory.DataBind();
        }
        else
        {
            grdCurrentMonth.DataSource = dsObj;
            grdCurrentMonth.DataBind();

            grdHistory.DataSource = dsObj;
            grdHistory.DataBind();
        }
    }

    private void fillAbsentDetails(string strFromDate,string strToDate)
    {
        strQry = "usp_BusService @command='AbsentDet',@fromdate='" + strFromDate.Trim() + "',@todate='" + strToDate.Trim() + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        strQry = Convert.ToString(strQry);
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdAbsentDetails.DataSource = dsObj;
            grdAbsentDetails.DataBind();
        }
        else
        {
            grdAbsentDetails.DataSource = dsObj;
            grdAbsentDetails.DataBind();
        }
    }
    private object fillBilling()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("date");
        dt.Columns.Add("mode");
        dt.Columns.Add("amount");
        dt.Columns.Add("receivedate");
        dt.Columns.Add("Chequeno");
        dt.Columns.Add("chequedate");
        dt.Columns.Add("clearancedate");

        DataRow dr = dt.NewRow();
        dr["date"] = "03-07-2014";
        dr["mode"] = "Cash";
        dr["amount"] = "1000";
        dr["receivedate"] = "03-07-2014";
        dr["Chequeno"] = "--";
        dr["chequedate"] = "--";
        dr["clearancedate"] = "--";

        dt.Rows.Add(dr);

        return dt;
    }
    
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {            
            Image img = (Image)e.Row.FindControl("btnEdit");
            img.Attributes.Add("onclick", "window.open('frmTracking.aspx','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=900,top=120,left=200');return false");
        }
    }
    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image img = (Image)e.Row.FindControl("btnEdit");
            img.Attributes.Add("onclick", "window.open('frmTracking.aspx','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=900,top=120,left=200');return false");
        }
    }
    private object fillService()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("route");
        dt.Columns.Add("effectivefrom");
        dt.Columns.Add("effectiveto");
        dt.Columns.Add("fee");
        dt.Columns.Add("paiddate");        

        DataRow dr = dt.NewRow();
        dr["route"] = "Vashi-Palm Beach";
        dr["effectivefrom"] = "01-06-2014";
        dr["effectiveto"] = "30-08-2014";
        dr["fee"] = "900";
        dr["paiddate"] = "01-06-2014";

        dt.Rows.Add(dr);

        return dt;

        
    }
    protected void fillAllVehicle()
    {
        //strQry = "usp_Bustracking @command='select'";
        //dsObj = sGetDataset(strQry);
        //drdTrack.DataSource = dsObj;
        //drdTrack.DataBind();
        
    }
    protected void drdTrack_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    protected void droMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((droMonth.SelectedValue == "01") || (droMonth.SelectedValue == "03") || (droMonth.SelectedValue == "05") || (droMonth.SelectedValue == "7") || (droMonth.SelectedValue == "8") || (droMonth.SelectedValue == "10") || (droMonth.SelectedValue == "12"))
        {
            strLastDayOfMonth = "31";
        }
        else if (droMonth.SelectedValue == "04" || droMonth.SelectedValue == "06" || droMonth.SelectedValue == "09" || droMonth.SelectedValue == "11")
        {
            strLastDayOfMonth = "30";
        }
        else if (droMonth.SelectedValue == "02")
        {
            strLastDayOfMonth = "28";
        }

        strFromDate = "" + Convert.ToString(droMonth.SelectedValue.Trim()) + "/01/" + Convert.ToString(System.DateTime.Now.Year) + "";
        //strFromDate = "" + Convert.ToString(System.DateTime.Now.Year) + "-" + droMonth.SelectedValue.Trim() + "-01";
        //strToDate = Convert.ToString(System.DateTime.Now.Year) + "-" + droMonth.SelectedValue.Trim() + "-" + strLastDayOfMonth;
        strToDate = "" + Convert.ToString(droMonth.SelectedValue.Trim()) + "/" + strLastDayOfMonth + "/" + Convert.ToString(System.DateTime.Now.Year) + "";
        fillTravelDetails(strFromDate, strToDate);
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((DropDownList3.SelectedValue == "01") || (DropDownList3.SelectedValue == "03") || (DropDownList3.SelectedValue == "05") || (DropDownList3.SelectedValue == "7") || (DropDownList3.SelectedValue == "8") || (droMonth.SelectedValue == "10") || (DropDownList3.SelectedValue == "12"))
        {
            strLastDayOfMonth = "31";
        } 
        else if (DropDownList3.SelectedValue == "04" || DropDownList3.SelectedValue == "06" || DropDownList3.SelectedValue == "09" || DropDownList3.SelectedValue == "11")
        {
            strLastDayOfMonth = "30";
        }
        else if (DropDownList3.SelectedValue == "02")
        {
            strLastDayOfMonth = "28";
        }

        strFromDate = "" + Convert.ToString(System.DateTime.Now.Year) + "-" + DropDownList3.SelectedValue.Trim() + "-01";
        strToDate = Convert.ToString(System.DateTime.Now.Year) + "-" + DropDownList3.SelectedValue.Trim() + "-" + strLastDayOfMonth;
        fillAbsentDetails(strFromDate, strToDate);
    }



    protected void grdCurrentMonth_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Session.Add("Devicenumber", Convert.ToString(grdCurrentMonth.DataKeys[e.Row.RowIndex].Values[0]));
            Session.Add("TravelDate", Convert.ToString(grdCurrentMonth.DataKeys[e.Row.RowIndex].Values[1]));
            Session.Add("TripID", Convert.ToString(grdCurrentMonth.DataKeys[e.Row.RowIndex].Values[2]));
            Session.Add("dtInTime", Convert.ToString(grdCurrentMonth.DataKeys[e.Row.RowIndex].Values[3]));
            Session.Add("dtouttime", Convert.ToString(grdCurrentMonth.DataKeys[e.Row.RowIndex].Values[4]));


            //DateTime dtCurrentDate = Convert.ToDateTime(Session["TravelDate"]);

            DateTime dtCurrentDate = DateTime.ParseExact(Session["TravelDate"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            string strDate = string.Empty;
            if (dtCurrentDate.Date == DateTime.Now.Date)
            {

                Image img = (Image)e.Row.FindControl("btnEdit");
                strDate = Convert.ToString(Session["TravelDate"]);
                //Session["Devicenumber"] = "1";
                //Image img = grdCurrentMonth.Rows[e.NewEditIndex].FindControl("btnEdit") as Image;
                //img.Attributes.Add("onclick", "window.open('frmTracking.aspx?TravelDate=" + strDate + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");
                //img.Attributes.Add("onclick", "window.open('FrmAdmLiTeacherProfile.aspx?successMessage1=1','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=500,top=150,left=500');return false");
                img.Attributes.Add("onclick", "window.open('frmTracking.aspx?TravelDate=" + Session["TravelDate"] + "&Trip=" + Session["TripID"] + "&Devicenumber=" + Session["Devicenumber"] + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");
            }
            else
            {
                Image img = (Image)e.Row.FindControl("btnEdit");
                //Image img = grdCurrentMonth.Rows[e.NewEditIndex].FindControl("btnEdit") as Image;
                //img.Attributes.Add("onclick", "window.open('History_Tracking.aspx?TravelDate=" + Convert.ToString(Session["TravelDate"]) + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");
                img.Attributes.Add("onclick", "window.open('MapWithAutoMovingPushpins.aspx?strdate=" + Convert.ToString(Session["TravelDate"]) + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");
            }
        }
    }

    protected void drpMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["Fromdate"] = "" + drpMonth.SelectedValue.Trim() + "" + "/01" + "/2015";

        if (drpMonth.SelectedValue == "01" || drpMonth.SelectedValue == "03" || drpMonth.SelectedValue == "05" || drpMonth.SelectedValue == "07" || drpMonth.SelectedValue == "08" || drpMonth.SelectedValue == "10" || drpMonth.SelectedValue == "12")
        {
            Session["Todate"] = "" + drpMonth.SelectedValue.Trim() + "" + "/31" + "/2015";
        }
        else if (drpMonth.SelectedValue == "04" || drpMonth.SelectedValue == "06" || drpMonth.SelectedValue == "09" || drpMonth.SelectedValue == "11")
        {
            Session["Todate"] = "" + drpMonth.SelectedValue.Trim() + "" + "/30" + "/2015";
        }
        else
        {
            Session["Todate"] = "" + drpMonth.SelectedValue.Trim() + "" + "/28" + "/2015";
        }

        //strQry = "[usp_Rawdatacount] @command='selectDate',@FromDate='" + Convert.ToString(Session["Fromdate"]) + "',@Todate='" + Convert.ToString(Session["Todate"]) + "'";
        //boolStatus = sBindDropDownList(drpDate, strQry, "dtRecieveDatetime", "dtRecieveDatetime");

        strQry = "[usp_Rawdatacount] @command='getDevice',@FromDate='" + Convert.ToString(Session["Fromdate"]) + "',@Todate='" + Convert.ToString(Session["Todate"]) + "'";
        boolStatus = sBindDropDownList(drpDevice, strQry, "vchDeviceNumber", "vchDeviceNumber");


    }
    protected void drpDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "[usp_Rawdatacount] @command='selectDevice',@dtDate='" + Convert.ToString(Convert.ToDateTime(drpDate.SelectedItem.Text.Trim()).ToString("MM/dd/yyyy")).Replace("-", "/") + "'";
        boolStatus = sBindDropDownList(drpDevice, strQry, "vchDeviceNumber", "vchDeviceNumber");
    }
    protected void drpDevice_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "[usp_Rawdatacount] @command='DataDetails',@FromDate='" + Session["Fromdate"].ToString().Replace("-", "/") + "',@Todate='" + Session["Todate"].ToString().Replace("-", "/") + "',@Devicenumber='" + Convert.ToString(drpDevice.SelectedItem.Text.Trim()) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            GridView2.DataSource = dsObj;
            GridView2.DataBind();
        }
    }

    protected void grdRawdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Session.Add("Devicenumber", Convert.ToString(grdRawdata.DataKeys[e.Row.RowIndex].Values[0]));
            Session.Add("dtRecieveDatetime", Convert.ToString(grdRawdata.DataKeys[e.Row.RowIndex].Values[1]));
            Session.Add("Hour", Convert.ToString(grdRawdata.DataKeys[e.Row.RowIndex].Values[2]));

            string strDate = string.Empty;
            LinkButton img = (LinkButton)e.Row.FindControl("lnkIn");
            strDate = Convert.ToString(Session["TravelDate"]);
            img.Attributes.Add("onclick", "window.open('frmRawDataDet.aspx?dtRecieveDatetime=" + Session["dtRecieveDatetime"] + "&Hour=" + Session["Hour"] + "&Devicenumber=" + Session["Devicenumber"] + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");



        }

    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Session.Add("Devicenumber", Convert.ToString(GridView2.DataKeys[e.Row.RowIndex].Values[0]));
            Session.Add("StartDate", Convert.ToString(GridView2.DataKeys[e.Row.RowIndex].Values[1]));

            string strDate = string.Empty;
            LinkButton img = (LinkButton)e.Row.FindControl("lnkIn");
            strDate = Convert.ToString(Session["TravelDate"]);
            img.Attributes.Add("onclick", "window.open('frmRawDataDet.aspx?Status=1&dtRecieveDatetime=" + Session["StartDate"] + "&Devicenumber=" + Session["Devicenumber"] + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=1000,top=5,left=150');return false");


            LinkButton imgOut = (LinkButton)e.Row.FindControl("lnkOut");
            strDate = Convert.ToString(Session["TravelDate"]);
            imgOut.Attributes.Add("onclick", "window.open('frmHourData.aspx?Status=2&dtRecieveDatetime=" + Session["StartDate"] + "&Devicenumber=" + Session["Devicenumber"] + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=1000,top=5,left=150');return false");



        }
    }
    //protected void grdCurrentMonth_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    string strPath = string.Empty;
    //    Session.Add("Devicenumber", Convert.ToString(grdCurrentMonth.DataKeys[e.NewEditIndex].Values[0]));
    //    Session.Add("TravelDate", Convert.ToString(grdCurrentMonth.DataKeys[e.NewEditIndex].Values[1]));
    //    Session.Add("TripID", Convert.ToString(grdCurrentMonth.DataKeys[e.NewEditIndex].Values[2]));
    //    Session.Add("dtInTime", Convert.ToString(grdCurrentMonth.DataKeys[e.NewEditIndex].Values[3]));
    //    Session.Add("dtouttime", Convert.ToString(grdCurrentMonth.DataKeys[e.NewEditIndex].Values[4]));


    //    //DateTime dtCurrentDate = Convert.ToDateTime(Session["TravelDate"]);

    //    DateTime dtCurrentDate = DateTime.ParseExact(Session["TravelDate"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

    //    if (dtCurrentDate.Date == DateTime.Now.Date)
    //    {
    //        //Image img = (Image)e.Row.FindControl("btnEdit");
    //        //Image img = grdCurrentMonth.Rows[e.NewEditIndex].FindControl("btnEdit") as Image;
    //        //img.Attributes.Add("onclick", "window.open('frmTracking.aspx','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");

    //        strPath = "frmTracking.aspx";
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "popup", "window.open('" + strPath + "','_blank,'toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return true')", true);
    //    }
    //    else
    //    {

    //        strPath = "History_Tracking.aspx";
    //        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + strPath + "','_blank,'toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return true')", true);
    //        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + strPath + "','_blank')", true);

    //        //Image img = (Image)e.Row.FindControl("btnEdit");
    //        //Image img = grdCurrentMonth.Rows[e.NewEditIndex].FindControl("btnEdit") as Image;
    //        //img.Attributes.Add("onclick", "window.open('History_Tracking.aspx','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");
    //    }
    //    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + strPath + "','_blank')", true);
    //}
}

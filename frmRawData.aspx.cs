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
using System.Globalization;


public partial class frmRawData : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    bool boolStatus;
    protected void Page_Load(object sender, EventArgs e)
    {

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
        //strQry = "[usp_Rawdatacount] @command='select',@dtDate='" + Convert.ToString(Convert.ToDateTime(drpDate.SelectedItem.Text.Trim()).ToString("MM/dd/yyyy")).Replace("-", "/") + "',@Devicenumber='" + Convert.ToString(drpDevice.SelectedItem.Text.Trim()) + "'";
        //dsObj = sGetDataset(strQry);
        //if (dsObj.Tables[0].Rows.Count > 0)
        //{
        //    grdRawdata.DataSource = dsObj;
        //    grdRawdata.DataBind();
        //}

        strQry = "[usp_Rawdatacount] @command='DataDetails',@FromDate='" + Session["Fromdate"].ToString().Replace("-", "/") + "',@Todate='" + Session["Todate"].ToString().Replace("-", "/") + "',@Devicenumber='" + Convert.ToString(drpDevice.SelectedItem.Text.Trim()) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = dsObj;
            GridView1.DataBind();
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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Session.Add("Devicenumber", Convert.ToString(GridView1.DataKeys[e.Row.RowIndex].Values[0]));
            Session.Add("StartDate", Convert.ToString(GridView1.DataKeys[e.Row.RowIndex].Values[1]));            

            string strDate = string.Empty;
            LinkButton img = (LinkButton)e.Row.FindControl("lnkIn");
            strDate = Convert.ToString(Session["TravelDate"]);
            img.Attributes.Add("onclick", "window.open('frmRawDataDet.aspx?dtRecieveDatetime=" + Session["StartDate"] + "&Devicenumber=" + Session["Devicenumber"] + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=1000,top=5,left=150');return false");



        }
    }
}

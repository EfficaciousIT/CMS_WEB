using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Services;

public partial class History_Tracking : DBUtility
{
    static string strcon;
    DataTable dt;
    string strTravelDate = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        strTravelDate = Request.QueryString["TravelDate"].ToString();
        Session["TravelDateNew"] = strTravelDate;
        //strcon = ConfigurationManager.ConnectionStrings["MicroIOCLdbcons"].ToString();
        if (!IsPostBack)
        {

        }          
        //if(!IsPostBack)
        //    fillCategory();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "replay", "showMap('','');", true);
    }

    //protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlcategory.SelectedItem.Text != "Select Category")
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "showCategory", "loadbyCategories('" + ddlcategory.SelectedItem.Text + "');", true);
    //}

    //public void fillCategory()
    //{
    //    ddlcategory.Items.Clear();
    //    //ddlcategory.Items.Add("Select Category");
    //    string query = "select distinct waypnt_cat from IOCL_WaypointsDet_Online where waypnt_cat<>'' order by waypnt_cat";
    //    ddlcategory.DataSource = sGetDatatable(query, "State", strcon);
    //    ddlcategory.DataValueField = "waypnt_cat";
    //    ddlcategory.DataTextField = "waypnt_cat";
    //    ddlcategory.DataBind();
    //    ddlcategory.Items.Insert(0, "Select Category");
    //}


    [WebMethod(EnableSession = true)]
    public static ArrayList replay_data()
    {
        try
        {            
            ArrayList arr = new ArrayList();
            DataSet ds = sGetDataset("select latitude,longitude from tblBusTravelDet where CONVERT(varchar,dtdatetime,101)=CONVERT(varchar,'" + Convert.ToString(HttpContext.Current.Session["TravelDateNew"]) + "',101) and speed <> 0 and Devicenumber=(select top 1 vchDeviceNum from tblDevice_Mst inner join tbl_Bus_Device_Assign on tblDevice_Mst.intDeviceId=tbl_Bus_Device_Assign.intDevice_Id inner join tblstudent_stop_link_master on tblstudent_stop_link_master.intBus_id=tbl_Bus_Device_Assign.intBus_id where tblstudent_stop_link_master.intStudent_id='" + Convert.ToString(HttpContext.Current.Session["Student_id"]) + "') order by dtdatetime");
            //DataSet ds = sGetDataset("select latitude,longitude from tblBusTravelDet where CONVERT(varchar,dtdatetime,101)=CONVERT(varchar,GETDATE()-5,101) and speed <> 0 order by dtdatetime  ");

            //DataSet ds = sGetDataset("select fltLatitude as [fltlatitude],fltLongitude as [fltlongitude] from " + veh + " " +
            //                         "where convert(varchar,dtdatetime,101) ='" + date + "' order by dtdatetime");

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    arr.Add(ds.Tables[0].Rows[i][0].ToString() + "," + ds.Tables[0].Rows[i][1].ToString());
                }
            }

            return arr;
        }
        catch (Exception ex)
        {
            return null;
        }

    }


    //[WebMethod]
    //public static ArrayList getCategoryData(string catname)
    //{
    //    try
    //    {
    //        ArrayList arr = new ArrayList();
    //        DataSet ds = sGetDataset("select waypnt_name, waypnt_lat, waypnt_long from IOCL_WaypointsDet_Online where waypnt_cat='" + catname + "'", strcon);

    //        if (ds != null)
    //        {
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //                {
    //                    arr.Add(ds.Tables[0].Rows[i][0].ToString() + "#" + ds.Tables[0].Rows[i][1].ToString() + "#" + ds.Tables[0].Rows[i][2].ToString());
    //                }
    //            }
    //        }
    //        return arr;
    //    }
    //    catch (Exception ex)
    //    {
    //        return null;
    //    }
    //}
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        //string query = "select fltLatitude as [fltlatitude], fltLongitude as [fltlongitude], dtdatetime as [dtdatetime]  from " + Request.QueryString[0].ToString() + " " +
        //                             "where convert(varchar,dtdatetime,101) ='" + Request.QueryString[1].ToString() + "' order by dtdatetime";
        //DataTable dt = sGetDatatable(query, "State", strcon);

        DataTable dt1 = new DataTable();
        if (ViewState["data"] == null)
        {
        }
        else
        {
            dt1 = (DataTable)ViewState["data"];

            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/vnd.xls";
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "DeviceReport.xls"));
            HttpContext.Current.Response.Charset = "";
            dgGrid.HeaderStyle.Font.Bold = true;
            dgGrid.DataSource = dt1;
            dgGrid.DataBind();
            dgGrid.RenderControl(hw);
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();
        }
    }
}

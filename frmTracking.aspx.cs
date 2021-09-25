using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;
using System.Data;
using System.Collections.Generic;

public partial class frmTracking : DBUtility
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Devicenumber"] = Request.QueryString["Devicenumber"];
        Session["TravelDate"] = Request.QueryString["TravelDate"];
        Session["TripID"] = Request.QueryString["TripID"];
        if (!IsPostBack)
        {
            showstop();
        }        
    }
    public void showstop()
    {

        string sQuery1;
        sQuery1 = "declare @vchdata varchar(max) set @vchdata=''  select @vchdata=@vchdata+Convert(varchar,fltLatitude,128)+'#'+Convert(varchar,fltLongitude,128)+'#'+vchBusStop_name+'#&'      from  tblbus_stop_master where intSchool_id='" + Convert.ToString(Session["School_id"]) + "' and intBusStop_id in (select intBusStop_id from tblBusStop_Trip_Assign where intTrip_Id='" + Convert.ToString("4") + "') select @vchdata";
        DataTable dt1 = sGetDatatable(sQuery1, "Display");

        if (dt1 != null && dt1.Rows[0][0].ToString() != "")
        {
            hdnStops.Value = dt1.Rows[0][0].ToString().Trim();
        }        
    }
    
    [WebMethod(EnableSession=true)]
    public static string GetLatestrec()
    {
        string strQry = string.Empty;
        SqlDataAdapter daObj = new SqlDataAdapter();
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["esmsCentralModel"].ConnectionString;
        DataSet dsObj = new DataSet();
        strQry = "[usp_BusService] @command='latestRec',@Devicenumber='" + Convert.ToString(HttpContext.Current.Session["Devicenumber"]) + "'";
        daObj = new SqlDataAdapter(strQry, strCon);
        daObj.Fill(dsObj, "Customers");        
        return dsObj.GetXml();
    }    
    public class LocationDetails
    {
        public string dtdatetime { get; set; }
        public string dttime { get; set; }
        public string location { get; set; }

        public string latitude { get; set; }
        public string longitude { get; set; }
        public string speed { get; set; }
    }
    [WebMethod]
    public static LocationDetails[] BindDatatable()
    {
        DataTable dt = new DataTable();
        List<LocationDetails> details = new List<LocationDetails>();

        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["esmsCentralModel"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("[usp_BusService] @command='latestRec',@Devicenumber='" + Convert.ToString(HttpContext.Current.Session["Devicenumber"]) + "'", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dtrow in dt.Rows)
                {
                    LocationDetails user = new LocationDetails();
                    user.dtdatetime = dtrow["dtdatetime"].ToString();
                    user.dttime = dtrow["dttime"].ToString();
                    
                    user.location = dtrow["location"].ToString();
                    user.latitude = dtrow["latitude"].ToString();
                    user.longitude = dtrow["longitude"].ToString();
                    user.speed = dtrow["speed"].ToString();

                    details.Add(user);
                }
            }
        }
        return details.ToArray();
    }


}

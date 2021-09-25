using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class MapWithAutoMovingPushpins : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    SqlDataAdapter daObj = new SqlDataAdapter();
    static string strConSBTS = "Data Source=180.179.99.46;Initial Catalog=newesms;User Id=sa;Password=SA@Admin;Max Pool Size=5000;";
    int i;
    static int count = 0;
    string strDate = string.Empty;
    static int dsCount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            
            
            //drpMonth.SelectedValue = DateTime.Now.Month.ToString();

            //fillVehicle();
            strDate = Request.QueryString["strdate"].ToString().Replace("-","/");

            //strDate = "11/17/2015";


            i = 0;
            //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
            //For samples to run properly, set GoogleAPIKey in Web.Config file.
            GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["GoogleAPIKey"];
            
            GoogleMapForASPNet1.GoogleMapObject.Width = "1330px"; // You can also specify percentage(e.g. 80%) here
            GoogleMapForASPNet1.GoogleMapObject.Height = "630px";

            strQry = "select latitude,longitude from tblbustraveldet where convert(varchar,dtdatetime,101)=convert(varchar,'" + strDate.Trim() + "',101) and speed <> 0";
            //strQry = "select latitude,longitude from tblbustraveldet where convert(varchar,dtdatetime,101)=convert(varchar,getdate()-9,101) and speed <> 0";
            daObj = new SqlDataAdapter(strQry, strConSBTS);
            daObj.Fill(dsObj);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                Session["dsObj"] = dsObj;
                GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("1", Convert.ToDouble(dsObj.Tables[0].Rows[i]["latitude"]), Convert.ToDouble(dsObj.Tables[0].Rows[i]["longitude"]));                
            }

            
            GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 15;
            GoogleMapForASPNet1.GoogleMapObject.ShowZoomControl = true;
            GoogleMapForASPNet1.GoogleMapObject.AutomaticBoundaryAndZoom = false;            

            GooglePoint GP1 = new GooglePoint();
            GP1.ID = "RedCar";
            GP1.Latitude = Convert.ToDouble(dsObj.Tables[0].Rows[i]["latitude"]);
            GP1.Longitude = Convert.ToDouble(dsObj.Tables[0].Rows[i]["longitude"]);  
            GP1.InfoHTML = "This is Pushpin 1";
            
            
            GP1.IconImage = "icons/RedCar.png";
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP1);

        }
        
    }
   

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 15;
        GoogleMapForASPNet1.GoogleMapObject.ShowZoomControl = true;
        GoogleMapForASPNet1.GoogleMapObject.AutomaticBoundaryAndZoom = false;

        dsObj = (DataSet)Session["dsObj"];

        dsCount = dsObj.Tables[0].Rows.Count;

        if (count < dsCount)
        {
            if (count == 0)
            {
                GoogleMapForASPNet1.GoogleMapObject.CenterPoint = GoogleMapForASPNet1.GoogleMapObject.Points[0];
                GoogleMapForASPNet1.GoogleMapObject.RecenterMap = true;

                GoogleMapForASPNet1.GoogleMapObject.Points["RedCar"].Longitude = Convert.ToDouble(dsObj.Tables[0].Rows[count]["longitude"]);
                GoogleMapForASPNet1.GoogleMapObject.Points["RedCar"].Latitude = Convert.ToDouble(dsObj.Tables[0].Rows[count]["latitude"]);
            }

            GoogleMapForASPNet1.GoogleMapObject.Points["RedCar"].Longitude = Convert.ToDouble(dsObj.Tables[0].Rows[count]["longitude"]);
            GoogleMapForASPNet1.GoogleMapObject.Points["RedCar"].Latitude = Convert.ToDouble(dsObj.Tables[0].Rows[count]["latitude"]);
            count = count + 1;
            if (count % 4 == 0)
            {
                GoogleMapForASPNet1.GoogleMapObject.CenterPoint = GoogleMapForASPNet1.GoogleMapObject.Points[0];
                GoogleMapForASPNet1.GoogleMapObject.RecenterMap = true;
            }
        }

        
        
    }
    protected void drpMonth_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

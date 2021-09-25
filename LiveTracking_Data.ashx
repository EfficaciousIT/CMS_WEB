<%@ WebHandler Language="C#" Class="LiveTracking_Data" %>

using System;
using System.Web;
using System.Data;

public class LiveTracking_Data : IHttpHandler ,System.Web.SessionState.IRequiresSessionState{

    static string strConSBTS = System.Configuration.ConfigurationManager.ConnectionStrings["esmsCentralModel"].ConnectionString.ToString();

    string data;
    string strDeviceName = string.Empty, strDate = string.Empty;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        strDeviceName = Convert.ToString(context.Session["Devicenumber"]);
        strDate = Convert.ToString(context.Session["TravelDate"]);
        context.Response.Write(GetLiveData(strDeviceName, strDate));
    }

    public string GetLiveData(string strDevice,string strdDate)
    {
        //string qry = "usp_BustrackData";
        string qry = "usp_BustrackData @dtdatetime='" + Convert.ToString(strdDate.Trim()) + "',@Devicenumber='" + Convert.ToString(strDevice.Trim()) + "'";
        //string qry = "select  latitude+'#&'+longitude from tblBusTravelDet where CONVERT(varchar,dtdatetime,101)=CONVERT(varchar,GETDATE(),101) and intid >=11557 and intrawid is null   order by dtdatetime asc";
        DataSet ds = DBUtility.sGetDataset(qry);
        data = Convert.ToString(ds.Tables[0].Rows[0][0]);
        //data = "19.0708,73.00128333#&19.07178333,72.99973333";
        return data;        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
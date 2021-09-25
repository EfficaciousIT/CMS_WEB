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

public partial class frmRawDataDet : DBUtility
{
    string strFromTime = string.Empty, strToTime = string.Empty, strDate = string.Empty;
    string strDeviceNumber = string.Empty;
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strStatus = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        strStatus = Convert.ToString(Request.QueryString["Status"]);
        strDeviceNumber = Convert.ToString(Request.QueryString["Devicenumber"]);
        strDate = Convert.ToDateTime(Request.QueryString["dtRecieveDatetime"]).ToString("MM/dd/yyyy").Replace("-","/");
        //strFromTime = Convert.ToString(Request.QueryString["Hour"])+":00";
        //strToTime = Convert.ToString(Request.QueryString["Hour"].Substring(0,2)) + ":59:59";

        //strQry = "[usp_Rawdatacount] @command='selectData',@dtDate='" + strDate.Trim() + "',@FromTime='" + strFromTime.Trim() + "',@ToTime='" + strToTime.Trim() + "',@Devicenumber='" + strDeviceNumber.Trim() + "'";
        if (strStatus == "1")
        {
            strQry = "[usp_Rawdatacount] @command='Datadet',@dtDate='" + strDate.Trim() + "',@Devicenumber='" + strDeviceNumber.Trim() + "'";
        }
        else
        {
            strQry = "[usp_Rawdatacount] @command='select',@dtDate='" + strDate.Trim() + "',@Devicenumber='" + strDeviceNumber.Trim() + "'";
        }
        
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = dsObj;
            GridView1.DataBind();
        }


    }
}

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

public partial class ReplayTracking : DBUtility
{
    static string strConSBTS = ConfigurationManager.ConnectionStrings["esms"].ConnectionString.ToString();
    string devicenumber, patch_timing_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "WayPoints();", true);
        WayPoints();
    }
    public void WayPoints()
    {
        HiddenField1.Value = "";
        hdnStops.Value = "";
        try
        {
            DataTable dt;
            string sQuery;
            //for Line no L 1
            //sQuery = "exec [usp_live] @devicenumber= '" + devicenumber + "'";
            //sQuery = "select Waypnt_lat,Waypnt_long,Waypnt_name,Waypnt_Num from IOCL_Waypointsdet_Online where waypnt_Cat = 'TPNo' and Line_no='L 1' order by Waypnt_num asc";// order by Waypnt_lat,Waypnt_long asc"; //order by Waypnt_id asc
            sQuery = "select latitude,longitude from tblLatestRec"; //order by Waypnt_id asc
            DataSet ds = sGetDataset(sQuery);
            dt = ds.Tables[0];
            if (dt != null && dt.Rows[0][0].ToString() != "")
            {
                HiddenField1.Value = dt.Rows[0][0].ToString().Trim() + "#" + dt.Rows[0][1].ToString().Trim();
            }
            //string sQuery1;
            //sQuery1 = "declare @vchdata varchar(max) set @vchdata=''  select @vchdata=@vchdata+Convert(varchar,stop_lat,128)+'#'+Convert(varchar,stop_long,128)+'#'+stop_name+'#&'     from SBTSPatch_Sch_Det join SBTSStop_master on    SBTSPatch_Sch_Det.stop_id=SBTSStop_master.stop_id      where patch_timing_id='" + patch_timing_id + "' select @vchdata";

            //DataTable dt1 = sGetDatatable(sQuery1, "", strConSBTS);

            //if (dt1 != null && dt1.Rows[0][0].ToString() != "")
            //{
            //    hdnStops.Value = dt1.Rows[0][0].ToString().Trim();
            //}
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "WayPoints();", true);
        }
        catch
        {
        }

    }
}

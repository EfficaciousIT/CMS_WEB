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

public partial class frmViewStudentCount : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strDevice = string.Empty;
    string strTime = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        strDevice = Convert.ToString(Request.QueryString["DeviceID"]);
        strTime = Convert.ToString(Request.QueryString["time"]);

        strQry = "usp_NewAdminDashboard @type='StudentBusIn',@intdevice_id='" + strDevice.Trim() + "',@fromTime='" + strTime.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvStaff.DataSource = dsObj;
            grvStaff.DataBind();
        }

    }
}

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

public partial class frmStandardWiseFeePaid : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lblTile = new Label();
        //lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        //lblTile.Visible = true;
        //lblTile.Text = "Fee Payments/Pending Details";
        if (!IsPostBack)
        {
            fillGrid();
        }
    }
    protected void fillGrid()
    {
        strQry = "usp_GetFeeStandardWise";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdFeeM.DataSource = dsObj;
            grdFeeM.DataBind();
            grdFeeM.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Font.Bold = true;

            grdFeeNew.DataSource = dsObj;
            grdFeeNew.DataBind();
            grdFeeNew.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Font.Bold = true;

            
        }
    }
}

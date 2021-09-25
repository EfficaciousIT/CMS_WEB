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

public partial class frmfeePaidDetails : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strMonth = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lblTile = new Label();
        //lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        //lblTile.Visible = true;
        //lblTile.Text = "Fee Payments Details";
        if (!IsPostBack)
        {
            fillGrid();
        }
    }
    protected void fillGrid()
    {
        strQry = "select top 1 * from tblfeecollection where intstudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            strQry = "usp_getMonthHorizontal @intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                strMonth = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
                strQry = "SELECT * FROM (select vchFee as Head,ISNULL(intAmount,0) as intAmount,MonthName from tblfeecollection inner join tblFeeDesc on tblfeecollection.intFeeHeadID=tblFeeDesc.intTutionId	inner join tblStartMonthMaster on tblfeecollection.intMonth=tblStartMonthMaster.monthNo	where intstudent_id='" + Convert.ToString(Session["Student_id"]) + "' group by vchFee,intAmount,intMonth,MonthName ) as s PIVOT(SUM(intAmount) FOR [MonthName] IN (" + strMonth + "))AS p Union all SELECT * FROM (select 'Total' as vchFee,sum(intAmount) as intAmount,MonthName from tblfeecollection inner join tblFeeDesc on tblfeecollection.intFeeHeadID=tblFeeDesc.intTutionId	inner join tblStartMonthMaster on tblfeecollection.intMonth=tblStartMonthMaster.monthNo	where intstudent_id='" + Convert.ToString(Session["Student_id"]) + "' group by vchFee,intAmount,intMonth,MonthName ) as s PIVOT(SUM(intAmount) FOR [MonthName] IN (" + strMonth.Trim() + "))AS p";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    grdFeeM.DataSource = dsObj;
                    grdFeeM.DataBind();
                    grdFeeM.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Font.Bold = true;
                }
                else
                {
                    grdFeeM.DataSource = dsObj;
                    grdFeeM.DataBind();
                }
            }
            strQry = "usp_getPendingFee @command='select',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intstudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["Standard_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                lblTotalDues.Text = "Total Dues     : <b>" + Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
                lblPendingdues.Text = "Outstanding as on Date : <b>" + Convert.ToString(dsObj.Tables[0].Rows[0]["Monthly"]) + "</b>  (" + Convert.ToString(dsObj.Tables[0].Rows[0]["pendingMonth"]) + " Month) ";
                lblPendingdues.Visible = true;
                lblTotalDues.Visible = true;
            }
            else
            {
                lblTotalDues.Text = "Total Dues     : <b>" + Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
                lblPendingdues.Text = "Nil";
                lblPendingdues.Visible = true;
                lblTotalDues.Visible = true;
            }

        }
        else
        {
            grdFeeM.DataSource = dsObj;
            grdFeeM.DataBind();
            lblPendingdues.Visible = false;
            lblTotalDues.Visible = false;
        }

        

    }
}

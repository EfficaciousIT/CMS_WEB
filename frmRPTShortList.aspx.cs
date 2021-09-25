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

public partial class frmRPTShortList : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTile = new Label();
        lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        lblTile.Visible = true;
        lblTile.Text = "Shortlist Students";

        if (!IsPostBack)
        {
            FillStandard();
        }
    }
    protected void FillStandard()
    {
        strQry = "usp_TestSchedule @command='selectStandard',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(drpMain, strQry, "vchStandard_name", "intStandard_id");

    }
    protected void drpMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "usp_RPTEnquiry @command='ShortList',@intStandard_id='" + drpMain.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdShortList.DataSource = dsObj;
            grdShortList.DataBind();
        }
        else
        {
            grdShortList.DataSource = dsObj;
            grdShortList.DataBind();
        }

        strQry = "usp_RPTEnquiry @command='ShortListAccepted',@intStandard_id='" + drpMain.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdAdmission.DataSource = dsObj;
            grdAdmission.DataBind();
        }
        else
        {
            grdAdmission.DataSource = dsObj;
            grdAdmission.DataBind();
        }

        strQry = "usp_RPTEnquiry @command='ShortLisPending',@intStandard_id='" + drpMain.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdPending.DataSource = dsObj;
            grdPending.DataBind();
        }
        else
        {
            grdPending.DataSource = dsObj;
            grdPending.DataBind();
        }

        strQry = "usp_RPTEnquiry @command='Rejected',@intStandard_id='" + drpMain.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdRejected.DataSource = dsObj;
            grdRejected.DataBind();
        }
        else
        {
            grdRejected.DataSource = dsObj;
            grdRejected.DataBind();
        }
    }
}

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

public partial class frmRPTEnquiry : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTile = new Label();
        lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        lblTile.Visible = true;
        lblTile.Text = "Enquiry Details";
        if (!IsPostBack)
        {
            FillStandard();
        }
        
    }
    protected void FillStandard()
    {
        strQry = "usp_TestSchedule @command='selectStandard',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(drpStandard, strQry, "vchStandard_name", "intStandard_id");
        stcardp = sBindDropDownList(drpStandardRegis, strQry, "vchStandard_name", "intStandard_id");
        stcardp = sBindDropDownList(drpStand, strQry, "vchStandard_name", "intStandard_id");
        stcardp = sBindDropDownList(drpAcceptance, strQry, "vchStandard_name", "intStandard_id");
        stcardp = sBindDropDownList(drpMain, strQry, "vchStandard_name", "intStandard_id");  
        
    }
    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "usp_RPTEnquiry @command='selEnquiry',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdEnquiry.Visible = true;
            grdEnquiry.DataSource = dsObj;
            grdEnquiry.DataBind();
        }
        else
        {
            grdEnquiry.Visible = true;
            grdEnquiry.DataSource = dsObj;
            grdEnquiry.DataBind();
        }
    }
    protected void drpStandardRegis_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "usp_RPTEnquiry @command='selRegistrationNotpurchased',@intStandard_id='" + drpStandardRegis.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdRegistrationNotTaken.Visible = true;
            grdRegistrationNotTaken.DataSource = dsObj;
            grdRegistrationNotTaken.DataBind();
        }
        else
        {
            grdRegistrationNotTaken.Visible = true;
            grdRegistrationNotTaken.DataSource = dsObj;
            grdRegistrationNotTaken.DataBind();
        }
    }
    protected void drpStand_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "usp_RPTEnquiry @command='selRegistrationpurchased',@intStandard_id='" + drpStand.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdRegistrationTaken.Visible = true;
            grdRegistrationTaken.DataSource = dsObj;
            grdRegistrationTaken.DataBind();
        }
        else
        {
            grdRegistrationTaken.Visible = true;
            grdRegistrationTaken.DataSource = dsObj;
            grdRegistrationTaken.DataBind();
        }
    }
    protected void drpAcceptance_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "usp_RPTEnquiry @command='selRegistrationSubmited',@intStandard_id='" + drpAcceptance.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdAcceptance.Visible = true;
            grdAcceptance.DataSource = dsObj;
            grdAcceptance.DataBind();
        }
        else
        {
            grdAcceptance.Visible = true;
            grdAcceptance.DataSource = dsObj;
            grdAcceptance.DataBind();
        }
    }
    protected void drpNotAcceptance_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "usp_RPTEnquiry @command='selRegistrationNotSubmited',@intStandard_id='" + drpNotAcceptance.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdNotAcceptance.Visible = true;
            grdNotAcceptance.DataSource = dsObj;
            grdNotAcceptance.DataBind();
        }
        else
        {
            grdNotAcceptance.Visible = true;
            grdNotAcceptance.DataSource = dsObj;
            grdNotAcceptance.DataBind();
        }
    }
    protected void drpMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "usp_RPTEnquiry @command='selEnquiry',@intStandard_id='" + drpMain.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdEnquiry.Visible = true;
            grdEnquiry.DataSource = dsObj;
            grdEnquiry.DataBind();
        }
        else
        {
            grdEnquiry.Visible = true;
            grdEnquiry.DataSource = dsObj;
            grdEnquiry.DataBind();
        }

        strQry = "usp_RPTEnquiry @command='selRegistrationNotpurchased',@intStandard_id='" + drpMain.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdRegistrationNotTaken.Visible = true;
            grdRegistrationNotTaken.DataSource = dsObj;
            grdRegistrationNotTaken.DataBind();
        }
        else
        {
            grdRegistrationNotTaken.Visible = true;
            grdRegistrationNotTaken.DataSource = dsObj;
            grdRegistrationNotTaken.DataBind();
        }

        strQry = "usp_RPTEnquiry @command='selRegistrationpurchased',@intStandard_id='" + drpMain.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdRegistrationTaken.Visible = true;
            grdRegistrationTaken.DataSource = dsObj;
            grdRegistrationTaken.DataBind();
        }
        else
        {
            grdRegistrationTaken.Visible = true;
            grdRegistrationTaken.DataSource = dsObj;
            grdRegistrationTaken.DataBind();
        }

        strQry = "usp_RPTEnquiry @command='selRegistrationSubmited',@intStandard_id='" + drpMain.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdAcceptance.Visible = true;
            grdAcceptance.DataSource = dsObj;
            grdAcceptance.DataBind();
        }
        else
        {
            grdAcceptance.Visible = true;
            grdAcceptance.DataSource = dsObj;
            grdAcceptance.DataBind();
        }

        strQry = "usp_RPTEnquiry @command='selRegistrationNotSubmited',@intStandard_id='" + drpMain.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdNotAcceptance.Visible = true;
            grdNotAcceptance.DataSource = dsObj;
            grdNotAcceptance.DataBind();
        }
        else
        {
            grdNotAcceptance.Visible = true;
            grdNotAcceptance.DataSource = dsObj;
            grdNotAcceptance.DataBind();
        }
    }
}

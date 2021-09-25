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

public partial class frmRPTExamSchedule : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTile = new Label();
        lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        lblTile.Visible = true;
        lblTile.Text = "Exam Details";

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
        strQry = "usp_RPTEnquiry @command='ExamAttended',@intStandard_id='" + drpMain.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdAttendance.DataSource = dsObj;
            grdAttendance.DataBind();
        }
        else
        {
            grdAttendance.DataSource = dsObj;
            grdAttendance.DataBind();
        }

        strQry = "usp_RPTEnquiry @command='ExamAbsent',@intStandard_id='" + drpMain.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdAbsent.DataSource = dsObj;
            grdAbsent.DataBind();
        }
        else
        {
            grdAbsent.DataSource = dsObj;
            grdAbsent.DataBind();
        }
    }
}

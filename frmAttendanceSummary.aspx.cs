using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class frmAttendanceSummary : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strDate = string.Empty;
    string strToDate = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getUserType();
        }
    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        if (drpUserType.SelectedValue == "3")
        {
            if (ddlFilter.SelectedValue == "1")
            {
                ShowAbsentTeacher();
            }
            if (ddlFilter.SelectedValue == "2")
            {
                ShowPresentTeacher();
            }
        }
        if (drpUserType.SelectedValue == "4")
        {
            if (ddlFilter.SelectedValue == "1")
            {
                ShowAbsentStaff();
            }
            if (ddlFilter.SelectedValue == "2")
            {
                ShowPresentStaff();
            }
        }
        if (drpUserType.SelectedValue == "5")
        {
            if (ddlFilter.SelectedValue == "1")
            {
                ShowAbsentAdmin();
            }
            if (ddlFilter.SelectedValue == "2")
            {
                ShowPresentAdmin();
            }
        }
        
    }

    protected void getUserType()
    {
        string strQry = "Execute dbo.usp_UserAttendacesummary @command='selectTypeofuser',@intSchool_id='" + Session["School_id"] + "' ";
        bool stcardp = sBindDropDownList(drpUserType, strQry, "vchUser_name", "intUserType_id");
    }

    protected void drpUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlFilter.ClearSelection();
        txtFromDate.Text = "";
        txtDate.Text = "";
    }

    public void ShowAbsentTeacher()
    {
        strDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strToDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strQry = "usp_UserAttendacesummary  @command='selectTeacher',@fromDate='" + strDate.Trim() + "',@ToDate='" + strToDate.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdAbsent.DataSource = dsObj;
            grdAbsent.DataBind();
        }
    }

    public void ShowPresentTeacher()
    {
        strDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strToDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strQry = "usp_UserAttendacesummary  @command='selectTeacherPresent',@fromDate='" + strDate.Trim() + "',@ToDate='" + strToDate.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdAbsent.DataSource = dsObj;
            grdAbsent.DataBind();
        }
    }
    public void ShowAbsentStaff()
    {
        strDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strToDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strQry = "usp_UserAttendacesummary  @command='selectStaff',@fromDate='" + strDate.Trim() + "',@ToDate='" + strToDate.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdAbsent.DataSource = dsObj;
            grdAbsent.DataBind();
        }
    }
    public void ShowPresentStaff()
    {
        strDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strToDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strQry = "usp_UserAttendacesummary  @command='selectStaffPresent',@fromDate='" + strDate.Trim() + "',@ToDate='" + strToDate.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdAbsent.DataSource = dsObj;
            grdAbsent.DataBind();
        }
    }
    public void ShowAbsentAdmin()
    {
        strDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strToDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strQry = "usp_UserAttendacesummary  @command='selectAdmin',@fromDate='" + strDate.Trim() + "',@ToDate='" + strToDate.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdAbsent.DataSource = dsObj;
            grdAbsent.DataBind();
        }
    }
    public void ShowPresentAdmin()
    {
        strDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strToDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strQry = "usp_UserAttendacesummary  @command='selectAdminPresent',@fromDate='" + strDate.Trim() + "',@ToDate='" + strToDate.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdAbsent.DataSource = dsObj;
            grdAbsent.DataBind();
        }
    }
    protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtFromDate.Text = "";
        txtDate.Text = "";
    }
    protected void grdAbsent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {           
            Label lblDate = (Label)e.Row.FindControl("lblDate");

            LinkButton lnkButton = (LinkButton)e.Row.FindControl("lnkAbsent");

            lnkButton.Attributes.Add("onclick", "window.open('AttendanceSummary.aspx?date=" + lblDate.Text + "&filter=" + ddlFilter.SelectedValue + "&Type=" + drpUserType.SelectedValue + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");
            
        }
    }
}
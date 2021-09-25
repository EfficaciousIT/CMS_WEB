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


public partial class frmstudentTravelDet : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    string strDate = "", strMonth = "", strYear = "";
    string strFromDate = "", strToDate = "";
    string strLastDayOfMonth = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserType_id"] = "1";
        Session["Student_id"] = "";
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["UserType_id"]) == "1")
            {
                grdBusAttendance.Columns[0].Visible = false;
                grdBusAttendance.Columns[1].Visible = false;

                grdAbsent.Columns[0].Visible = false;
                grdAbsent.Columns[1].Visible = false;

                fillGrid();
            }
        }
    }
    protected void fillGrid()
    {
        strQry = "";
        strQry = "exec usp_BusAbsentPresent @command='Present',@Fromdate='" + strFromDate.Trim() + "',@Todate='" + strToDate.Trim() + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdBusAttendance.DataSource = dsObj;
            grdBusAttendance.DataBind();
        }
    }
    protected void drpMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((drpMonth.SelectedValue == "01") || (drpMonth.SelectedValue == "03") || (drpMonth.SelectedValue == "05") || (drpMonth.SelectedValue == "7") || (drpMonth.SelectedValue == "8") || (drpMonth.SelectedValue == "10") || (drpMonth.SelectedValue == "12"))
        {
            strLastDayOfMonth = "31";
        }
        else if (drpMonth.SelectedValue == "04" || drpMonth.SelectedValue == "06" || drpMonth.SelectedValue == "09" || drpMonth.SelectedValue == "11")
        {
            strLastDayOfMonth = "30";
        }
        else if (drpMonth.SelectedValue == "02")
        {
            strLastDayOfMonth = "28";
        }

        strFromDate = "" + Convert.ToString(System.DateTime.Now.Year) + "-" + drpMonth.SelectedValue.Trim() + "-01";
        strToDate = Convert.ToString(System.DateTime.Now.Year) + "-" + drpMonth.SelectedValue.Trim() + "-" + strLastDayOfMonth;

        strQry = "exec usp_BusAbsentPresent @command='Present',@Fromdate='" + strFromDate.Trim() + "',@Todate='" + strToDate.Trim() + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdBusAttendance.DataSource = dsObj;
            grdBusAttendance.DataBind();
        }
        else
        {
            grdBusAttendance.DataSource = dsObj;
            grdBusAttendance.DataBind();
        }
    }
    protected void drpAbsent_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((drpMonth.SelectedValue == "01") || (drpMonth.SelectedValue == "03") || (drpMonth.SelectedValue == "05") || (drpMonth.SelectedValue == "7") || (drpMonth.SelectedValue == "8") || (drpMonth.SelectedValue == "10") || (drpMonth.SelectedValue == "12"))
        {
            strLastDayOfMonth = "31";
        }
        else if (drpMonth.SelectedValue == "04" || drpMonth.SelectedValue == "06" || drpMonth.SelectedValue == "09" || drpMonth.SelectedValue == "11")
        {
            strLastDayOfMonth = "30";
        }
        else if (drpMonth.SelectedValue == "02")
        {
            strLastDayOfMonth = "28";
        }

        strFromDate = "" + Convert.ToString(System.DateTime.Now.Year) + "-" + drpMonth.SelectedValue.Trim() + "-01";
        strToDate = Convert.ToString(System.DateTime.Now.Year) + "-" + drpMonth.SelectedValue.Trim() + "-" + strLastDayOfMonth;

        strQry = "exec usp_BusAbsentPresent @command='Absent',@Fromdate='" + strFromDate.Trim() + "',@Todate='" + strToDate.Trim() + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
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


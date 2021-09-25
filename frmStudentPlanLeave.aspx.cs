using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmStudentPlanLeave :DBUtility 
{
    string strQry = "";
    int id;
    int Month;
    string directoryPath = string.Empty;
    int Year;
    DataSet dsObj, dsCal;
    string filename = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTile = new Label();
        lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        lblTile.Visible = true;
        lblTile.Text = "Plan Your Leave";
        if (!IsPostBack)
        {
            ddlMonth.SelectedValue = Convert.ToString(DateTime.Now.Month);
            FillHolidayDataset();
            Fillgrid();
        }
    }
    public void Fillgrid()
    {
        try
        {

            grvVacation.DataSource = Createtable();
            grvVacation.DataBind();

            if (dsObj == null)
            {
                grvVacation.DataSource = null;
                grvVacation.DataBind();
            }
            else
            {
                grvVacation.DataSource = dsObj;
                grvVacation.DataBind();
            }

            if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                grvVacation.Columns[0].Visible = false;
                grvVacation.Columns[1].Visible = true;
                grvVacation.Columns[2].Visible = true;
               

            }
            else
            {
                grvVacation.Columns[0].Visible = false;
                grvVacation.Columns[1].Visible = false;
                grvVacation.Columns[2].Visible = false;

            }
        }
        catch
        {

        }
    }
    public object Createtable()
    {
        try
        {
            dsObj = new DataSet();
            //if (chkAll.Checked)
            //{
            //    strQry = "exec [usp_setVacationList] @type='FillData',@intSchool_id='" + Session["School_id"] + "',@year='" + Year + "'";
            //}
            //else
            //{
                strQry = "exec [usp_setVacationList] @type='FillData',@intSchool_id='" + Session["School_id"] + "',@month='" + Month + "',@year='" + Year + "'";
            //}
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
                return dsObj;
            else
                return dsObj = null;
        }
        catch
        {
            return dsObj;
        }
    }
    protected void CheckHolidayDataset()
    {

        if (CalHoliday.VisibleDate.Year == 0001)
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;

        }
        else
        {

            Year = CalHoliday.VisibleDate.Year;
            if (CalHoliday.VisibleDate.Month == 12)
            {
                Month = 1;
                Year = CalHoliday.VisibleDate.Year + 1;
            }
            else
            {
                Month = CalHoliday.VisibleDate.Month + 1;
                Year = CalHoliday.VisibleDate.Year;
            }

        }
        DateTime firstDate = new DateTime(Year, Month, 1);
        CalHoliday.VisibleDate = new DateTime(Year, Month, 1);
        DateTime lastDate = GetFirstDayOfNextMonth();
        dsObj = GetCurrentMonthData(firstDate, lastDate);
    }


    protected void FillHolidayDataset()
    {

        if (CalHoliday.VisibleDate.Year == 0001)
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;

        }
        else
        {

            Year = CalHoliday.VisibleDate.Year;

            Month = CalHoliday.VisibleDate.Month;
            Year = CalHoliday.VisibleDate.Year;

        }
        DateTime firstDate = new DateTime(Year, Month, 1);
        CalHoliday.VisibleDate = new DateTime(Year, Month, 1);
        DateTime lastDate = GetFirstDayOfNextMonth();
        dsObj = GetCurrentMonthData(firstDate, lastDate);
    }

    protected DateTime GetFirstDayOfNextMonth()
    {
        DateTime lastDate;
        try
        {
            int monthNumber, yearNumber;
            if (CalHoliday.VisibleDate.Month == 12 || CalHoliday.VisibleDate.Month == 11)
            {
                monthNumber = 1;
                yearNumber = DateTime.Now.Year + 1;
            }
            else
            {
                monthNumber = CalHoliday.VisibleDate.Month + 2;
                yearNumber = CalHoliday.VisibleDate.Year;
            }
            lastDate = new DateTime(yearNumber, monthNumber, 1);
            return lastDate;
        }
        catch (Exception ex)
        {
            DateTime a = new DateTime(DateTime.Now.Year, 1, 1);
            return a;

        }

    }
    public DataSet GetCurrentMonthData(DateTime FirstDt, DateTime LastDt)
    {
        try
        {
            strQry = string.Empty;
            strQry = "exec [usp_StudentDashboard] @type='GetCalendarData',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',  @FirstDate='" + Convert.ToDateTime(FirstDt).ToString("yyyy/MM/dd") + "',@LastDate='" + Convert.ToDateTime(LastDt).ToString("yyyy/MM/dd") + "'";
            dsCal = sGetDataset(strQry);
            Session["DsCal"] = dsCal;
            return dsCal;
        }
        catch (Exception)
        {
            return dsObj;
        }
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        try
        {
            if (e.Day.Date.Day.ToString() == "15")
            {
                Month = e.Day.Date.Month;
                Year = e.Day.Date.Year;
            }

            if (e.Day.Date.DayOfWeek.ToString() == "Sunday")
            {
                //e.Cell.BackColor = System.Drawing.Color.White;
                e.Cell.Style["background-color"] = "#E67c7c";
                e.Cell.ForeColor = System.Drawing.Color.White;
                e.Cell.Font.Bold = true;
                return;
            }

            Boolean bln = false;
            DateTime nextDate;
            string day = string.Empty;
            if (((DataSet)Session["DsCal"]) != null)
            {
                foreach (DataRow dr in ((DataSet)Session["DsCal"]).Tables[0].Rows)
                {

                    nextDate = (DateTime)dr["Date"];
                    day = (string)dr["day"];
                    if (nextDate == e.Day.Date)
                    {
                        if (day == "1")
                        {
                            e.Cell.BackColor = System.Drawing.Color.SkyBlue;
                        }
                        else
                        {
                            e.Cell.BackColor = System.Drawing.Color.LightSeaGreen;
                        }
                            e.Cell.ToolTip = (string)dr["Name"];
                            Label lbl = new Label();
                            lbl.Text = (string)dr["Name"];
                        
                    }

                }
            }
           
        }
        catch (Exception)
        {

        }



    }

    protected void CalHoliday_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        try
        {
            FillHolidayDataset();
            ddlMonth.SelectedValue = Convert.ToString(CalHoliday.VisibleDate.Month);
            ddlMonth_SelectedIndexChanged(null, null);
        }
        catch
        {

        }
    }
    protected void grvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    public void FillTotalGrid()
    {
        try
        {
            strQry = "exec [usp_PlanLeave] @type='TotalMissing',@FrmDt='" + Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy") + "',@ToDt='" + Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy") + "',@intSchoolid='" + Convert.ToString(Session["School_id"]) + "',@STD='" + Convert.ToString(Session["Standard_id"]) + "', @DIV='" +Session["Division_id"]+"'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
        }
        catch
        {
            
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            CalHoliday_VisibleMonthChanged(null, null);
            FillTotalGrid();
        }
        catch 
        {
            
        }
        
        
    }
    protected void txtFrmDt_TextChanged(object sender, EventArgs e)
    {
        CalHoliday.SelectedDate = Convert.ToDateTime(txtFrmDt.Text);
        Session["FirstDate"] = CalHoliday.SelectedDate;

        FillHolidayDataset();

        if (txtFrmDt.Text != "" && txtToDate.Text != "")
        {
            TimeSpan t = Convert.ToDateTime(txtToDate.Text) - Convert.ToDateTime(txtFrmDt.Text);
            for (int i = CalHoliday.SelectedDates.Count; i >= 1; i--)
            {
                CalHoliday.SelectedDates.Remove(CalHoliday.SelectedDate.AddDays(i));
            }
            for (int i = 1; i <= t.Days; i++)
            {
                CalHoliday.SelectedDates.Add(CalHoliday.SelectedDate.AddDays(i));
            }
        }
        FillHolidayDataset();
        
    }
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        FillHolidayDataset();
        TimeSpan t = Convert.ToDateTime(txtToDate.Text) - Convert.ToDateTime(txtFrmDt.Text);
        for (int i = CalHoliday.SelectedDates.Count; i >= 1; i--)
        {
            CalHoliday.SelectedDates.Remove(CalHoliday.SelectedDate.AddDays(i));
        }
        for (int i = 1; i <= t.Days; i++)
        {
            CalHoliday.SelectedDates.Add(CalHoliday.SelectedDate.AddDays(i));
        }
        FillHolidayDataset();
       
    }
    protected void CalHoliday_SelectionChanged(object sender, EventArgs e)
    {
        txtFrmDt.Text = Convert.ToDateTime(CalHoliday.SelectedDate).ToString("dd/MM/yyyy");
        txtFrmDt_TextChanged(null, null);
    }
    protected void lnkNext_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (ddlMonth.SelectedValue != "12")
            {
                ddlMonth.SelectedValue = Convert.ToString((Convert.ToInt32(ddlMonth.SelectedValue) + 1));
                ddlMonth_SelectedIndexChanged(null, null);
            }
            else
            {
                if (CalHoliday.VisibleDate.Year != 001)
                {
                    Year = CalHoliday.VisibleDate.Year + 1;
                    ddlMonth.SelectedValue = "1";
                }
                else
                {
                    Year = DateTime.Now.Year;
                }
                Fillgrid();
                Month = 1;
                CalHoliday.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
                // CalHoliday.VisibleDate = DateTime.ParseExact("" + ddlMonth.Text.Trim() + "/27/" + Year + "", "MM/dd/yyyy", CultureInfo.InvariantCulture);
                FillHolidayDataset();
            }
        }
        catch
        {
        }
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Month = Convert.ToInt32(ddlMonth.SelectedValue);
            if (CalHoliday.VisibleDate.Year != 001)
            {
                Year = CalHoliday.VisibleDate.Year;
            }
            else
            {
                Year = DateTime.Now.Year;
            }
            Fillgrid();

            CalHoliday.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
            FillHolidayDataset();

        }
        catch
        {

        }
    }
    protected void lnkPrevious_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (ddlMonth.SelectedValue != "1")
            {
                ddlMonth.SelectedValue = Convert.ToString((Convert.ToInt32(ddlMonth.SelectedValue) - 1));
                ddlMonth_SelectedIndexChanged(null, null);
            }
            else
            {
                if (CalHoliday.VisibleDate.Year != 001)
                {
                    Year = CalHoliday.VisibleDate.Year - 1;
                    ddlMonth.SelectedValue = "12";
                }
                else
                {
                    Year = DateTime.Now.Year;
                }
                Fillgrid();
               
                Month = 12;
                CalHoliday.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
                FillHolidayDataset();
            }
        }
        catch
        {

        }
    }
    protected void lnkNoOfLec_Click(object sender, EventArgs e)
    {
        try
        {
            if (grvLecDetail.Columns.Count > 2)
            {
                for (int i = grvLecDetail.Columns.Count-1; i >= 2; i--)
                {
                    grvLecDetail.Columns.RemoveAt(i);
                }
            }
            strQry = "exec [usp_PlanLeave]  @type='Detail',@FrmDt='" + Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy") + "',@ToDt='" + Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy") + "',@intSchoolid='" + Convert.ToString(Session["School_id"]) + "',@STD='" + Convert.ToString(Session["Standard_id"]) + "', @DIV='" + Session["Division_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvLecDetail.DataSource = dsObj;
               
                lblStatus.Text = "From " + txtFrmDt.Text + " To " + txtToDate.Text;

                for (int i = 2; i < dsObj.Tables[0].Columns.Count; i++)
                {
                    BoundField b=new BoundField();
                    b.DataField=Convert.ToString(dsObj.Tables[0].Columns[i].ColumnName);
                    b.HeaderText=Convert.ToString(dsObj.Tables[0].Columns[i].ColumnName);
                    grvLecDetail.Columns.Add(b);
                }
                grvLecDetail.DataBind();

                ModalStudLateAtt.Show();
            }
        }
        catch
        {
            
        }
    }
}
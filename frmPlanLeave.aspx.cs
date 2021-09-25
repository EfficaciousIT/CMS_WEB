using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmPlanLeave : DBUtility
{
    DataSet dsObj=new DataSet();
    DataSet dsCal = new DataSet();
    string strQry;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["School_Id"] != null)
            {
                //if (!IsPostBack)
                //{
                    FillTrainingDataset();
                //}
            }
        }
        catch
        {

        }
    }
    protected void FillTrainingDataset()
    {
        int Month, Year;

        if (CalHolidays.VisibleDate.Year == 0001)
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;

        }
        else
        {
            Year = CalHolidays.VisibleDate.Year;
            Month = CalHolidays.VisibleDate.Month-1;
        }
         DateTime firstDate = new DateTime(Year, Month, 1);
        //DateTime firstDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        DateTime lastDate = GetFirstDayOfNextMonth();
        dsObj = GetCurrentMonthData(firstDate, lastDate);
    }
    protected DateTime GetFirstDayOfNextMonth()
    {
        DateTime lastDate;
        try
        {
            int monthNumber, yearNumber;
            if (CalHolidays.VisibleDate.Month == 12)
            {
                monthNumber = 1;
                yearNumber = DateTime.Now.Year + 1;
            }
            else
            {
                monthNumber = DateTime.Now.Month + 1;
                yearNumber = DateTime.Now.Year;
            }
            lastDate = new DateTime(yearNumber, monthNumber, 1);
            return lastDate;
        }
        catch (Exception ex)
        {
            DateTime a = new DateTime(2014, 1, 1);
            return a;

        }

    }

    public DataSet GetCurrentMonthData(DateTime FirstDt, DateTime LastDt)
    {
        try
        {
            strQry = "";
            strQry = "exec usp_PlanLeave @type='Calendar', @FrmDt='" + Convert.ToDateTime(FirstDt).ToString("yyyy/MM/dd") + "',@ToDt='" + Convert.ToDateTime(LastDt).ToString("yyyy/MM/dd") + "',@intSchoolid='" + Convert.ToString(Session["School_id"]) + "',@User_Type='" + Convert.ToString(Session["UserType_Id"]) + "'";
            if (Convert.ToString(Session["UserType_Id"]) == "3" || Convert.ToString(Session["UserType_Id"]) == "4")
            {
                strQry = strQry + ",@User_Id='" + Convert.ToString(Session["User_Id"]) + "'";
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "2")
            {
                strQry = strQry + ",@User_Id='" + Convert.ToString(Session["User_Id"]) + "'";
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "1")
            {
                strQry = strQry + ",@Student_Id='" + Convert.ToString(Session["Student_id"]) + "'";
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "5")
            {
                strQry = strQry + ",@User_Id='" + Convert.ToString(Session["User_Id"]) + "'";
            }
            dsCal = sGetDataset(strQry);
            return dsCal;
        }
        catch (Exception)
        {
            return dsCal;
        }
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        try
        {
            DateTime nextDate;
            string Type="";
            string Name="",ParentApprv="",StaffApprv="",AdminApprv="";
            if (dsCal != null)
            {
                foreach (DataRow dr in dsCal.Tables[0].Rows)
                {
                    nextDate = (DateTime)dr["Date"];
                    Type = (string)dr["Type"];
                    Name = (string)dr["Name"];
                    ParentApprv = (string)dr["Parent"];
                    StaffApprv = (string)dr["Staff"];
                    AdminApprv = (string)dr["Admin"];
                    if (nextDate == e.Day.Date)
                    {
                       




                        if (Type == "Leave")
                        {
                            if (ParentApprv == "Parent Approved")
                            {
                                e.Cell.BackColor = System.Drawing.Color.LightBlue;
                                e.Cell.ToolTip = "Leave Parent Approved";
                            }
                            else if (ParentApprv == "Parent Rejected")
                            {
                                e.Cell.BackColor = System.Drawing.Color.SkyBlue;
                                e.Cell.ToolTip = "Leave Parent Rejected";
                            }
                            else if (ParentApprv == "Parent Pending")
                            {
                                e.Cell.BackColor = System.Drawing.Color.SlateBlue;
                                e.Cell.ToolTip = "Leave Parent Rejected";
                            }

                            if (StaffApprv == "Staff Approved")
                            {
                                e.Cell.BackColor = System.Drawing.Color.Lavender;
                                e.Cell.ToolTip = "Leave Staff Approved";
                            }
                            else if (StaffApprv == "Staff Rejected")
                            {
                                e.Cell.BackColor = System.Drawing.Color.LavenderBlush;
                                e.Cell.ToolTip = "Leave Staff Rejected";
                            }
                            else if (StaffApprv == "Staff Pending")
                            {
                                e.Cell.BackColor = System.Drawing.Color.LawnGreen;
                                e.Cell.ToolTip = "Leave Staff Pending";
                            }

                            if (AdminApprv == "Admin Approved")
                            {
                                e.Cell.BackColor = System.Drawing.Color.LightGreen;
                                e.Cell.ToolTip = "Leave Admin Approved";
                            }
                            else if (AdminApprv == "Admin Rejected")
                            {
                                e.Cell.BackColor = System.Drawing.Color.SeaGreen;
                                e.Cell.ToolTip = "Leave Admin Rejected";
                            }
                            else if (AdminApprv == "Admin Pending")
                            {
                                e.Cell.BackColor = System.Drawing.Color.YellowGreen;
                                e.Cell.ToolTip = "Leave Admin Pending";
                            }
                            //  e.Cell.Attributes.Add((string)dr["Name"], "1");
                        }
                        else if (Type == "Holiday")
                        {
                            e.Cell.BackColor = System.Drawing.Color.SpringGreen;
                            e.Cell.ToolTip = (string)dr["Name"];


                            if (Convert.ToString(Session["UserType_id"]) == "1")
                            {
                                e.Cell.Controls.Clear();

                                HyperLink h = new HyperLink();

                                h.NavigateUrl = "frmStudentLeaveMenu.aspx?Day=" + e.Day.Date;

                                h.Text = e.Day.DayNumberText;

                                e.Cell.Controls.Add(h);

                            }
                            else if (Convert.ToString(Session["UserType_id"]) == "2")
                            {
                                e.Cell.Controls.Clear();

                                HyperLink h = new HyperLink();

                                h.NavigateUrl = "frmStudentLeaveMenu.aspx?Day=" + e.Day.Date;

                                h.Text = e.Day.DayNumberText;

                                e.Cell.Controls.Add(h);
                            }
                            else if (Convert.ToString(Session["UserType_id"]) == "3" || Convert.ToString(Session["UserType_id"]) == "4")
                            {
                                e.Cell.Controls.Clear();

                                HyperLink h = new HyperLink();

                                h.NavigateUrl = "frmTeacherLeaveMenu.aspx?Day=" + e.Day.Date;

                                h.Text = e.Day.DayNumberText;

                                e.Cell.Controls.Add(h);
                            }
                            else
                            {
                                e.Cell.Controls.Clear();

                                HyperLink h = new HyperLink();

                                h.NavigateUrl = "frmTeacherLeaveMenu.aspx?Day=" + e.Day.Date;

                                h.Text = e.Day.DayNumberText;

                                e.Cell.Controls.Add(h);
                            }
                        }
                        else if (Type == "Vacation")
                        {
                            e.Cell.BackColor = System.Drawing.Color.LightGreen;
                            e.Cell.ToolTip = (string)dr["Name"];



                            if (Convert.ToString(Session["UserType_id"]) == "1")
                            {
                                e.Cell.Controls.Clear();

                                HyperLink h = new HyperLink();

                                h.NavigateUrl = "frmStudentLeaveMenu.aspx?Day=" + e.Day.Date;

                                h.Text = e.Day.DayNumberText;

                                e.Cell.Controls.Add(h);

                            }
                            else if (Convert.ToString(Session["UserType_id"]) == "2")
                            {
                                e.Cell.Controls.Clear();

                                HyperLink h = new HyperLink();

                                h.NavigateUrl = "frmStudentLeaveMenu.aspx?Day=" + e.Day.Date;

                                h.Text = e.Day.DayNumberText;

                                e.Cell.Controls.Add(h);
                            }
                            else if (Convert.ToString(Session["UserType_id"]) == "3" || Convert.ToString(Session["UserType_id"]) == "4")
                            {
                                e.Cell.Controls.Clear();

                                HyperLink h = new HyperLink();

                                h.NavigateUrl = "frmTeacherLeaveMenu.aspx?Day=" + e.Day.Date;

                                h.Text = e.Day.DayNumberText;

                                e.Cell.Controls.Add(h);
                            }
                            else
                            {
                                e.Cell.Controls.Clear();

                                HyperLink h = new HyperLink();

                                h.NavigateUrl = "frmTeacherLeaveMenu.aspx?Day=" + e.Day.Date;

                                h.Text = e.Day.DayNumberText;

                                e.Cell.Controls.Add(h);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception)
        {


        }
    }
}
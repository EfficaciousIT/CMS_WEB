using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Text;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmStudentDashboard : DBUtility
{
    DataSet dsObj = new DataSet();
    StringBuilder str = new StringBuilder();
    string[] xAxis;
    int[] yAxis;
    DataTable dt = new DataTable();
    string strQry = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["School_Id"] != null)
        {
            Session["MsgCount"] = Convert.ToString(lblMsgCount.Text);
            if (!IsPostBack)
            {

                //pnlAbsent.Attributes.Add("display", "none");
                //pnlAbsent.Visible = false;
                FillYear();
                ddlMonth.SelectedValue = Convert.ToString(DateTime.Now.Month);
                ddlYear.SelectedValue = Convert.ToString(DateTime.Now.Year);
                HFUserId.Value = Convert.ToString(Session["User_Id"]);
                HFUserType.Value = Convert.ToString(Session["UserType_Id"]);
                FillSchoolChart();
                FillVacation();
                FillHoliday();
                FillLeave();


                FillSTD();
                FillDIV();
                FillStackedChart();
                FillDetail();
                FillLateStudentChart();
                FillTopAtt();
                geturl();
            }
        }
        else
        {
            Response.Redirect("~\\Default.aspx", false);
        }
    }

    [System.Web.Services.WebMethod]
    public static string Notification(string UserType,string Id)
    {
        try
        {
            string strQry="";
            strQry="exec [usp_ChartStaffAttendance] @type='MsgNotification',@UserType='" + UserType + "',@StaffId='" + Id + "'";
            DataSet ds=new DataSet();
             ds=sGetDataset(strQry);
            Label lblMsgCount=new Label();
            if(ds.Tables[0].Rows.Count>0)
            {
                lblMsgCount.Text=Convert.ToString(ds.Tables[0].Rows[0][0]);
            }
            return lblMsgCount.Text;
        }
        catch
        {
             return "false";
           
        }
    }
    public void FillTopAtt()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_AttendanceSummery] @type='Top5Student',@Div='" + ddlDIV.SelectedValue + "',@intSchool_Id='" + Session["School_id"] + "',@Year='" + ddlYear.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            grvTopAtt.DataSource = dsObj;
            grvTopAtt.DataBind();
        }
        catch
        {

        }
    }
    public void FillSchoolChart()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ChartStaffAttendance @type='FillSchoolChart',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "',@StaffId='" + Convert.ToString(Session["User_Id"]) + "',@month='" + ddlMonth.SelectedValue + "',@Year='" + ddlYear.SelectedValue + "',@UserType='" + Convert.ToString(Session["UserType_id"]) + "'";
            dt = sGetDatatable(strQry, "Chart");
            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }

            ChrtSchoolAtt.Series[0].Points.DataBindXY(x, y);
            ChrtSchoolAtt.Series[0].IsValueShownAsLabel = true;
        

            //ChrtSchoolAtt.se

            int point = Convert.ToInt32(ChrtSchoolAtt.Series[0].Points.Count);
            Boolean pointAdd = false;




            for (int i = 0; i < point; i++)
            {
                if (Convert.ToString(ChrtSchoolAtt.Series[0].Points[i].AxisLabel) == "Present")
                {
                    ChrtSchoolAtt.Series[0].Points[i].Color = Color.Green;
                    break;
                }
                //else
                //{

                //    if (pointAdd == false)
                //    {
                //        ChrtSchoolAtt.Series[0].Points.AddXY("Present", 0);
                //        pointAdd = true;

                //    }

                //}
            }

            pointAdd = false;

            for (int i = 0; i < point; i++)
            {
                if (Convert.ToString(ChrtSchoolAtt.Series[0].Points[i].AxisLabel) == "Absent")
                {
                    ChrtSchoolAtt.Series[0].Points[i].Color = Color.Red;
                    break;
                }
                //else
                //{
                //    if (pointAdd == false)
                //    {
                //        ChrtSchoolAtt.Series[0].Points.AddXY("Absent", 0);
                //        pointAdd = true;

                //    }
                //}
            }

            pointAdd = false;
            for (int i = 0; i < point; i++)
            {
                if (Convert.ToString(ChrtSchoolAtt.Series[0].Points[i].AxisLabel) == "Late")
                {
                    ChrtSchoolAtt.Series[0].Points[i].Color = Color.SkyBlue;

                    break;
                }
                //else
                //{
                //    if (pointAdd == false)
                //    {
                //        ChrtSchoolAtt.Series[0].Points.AddXY("Late", 0);
                //        pointAdd = true;
                //    }
                //}
            }

            pointAdd = false;
            for (int i = 0; i < point; i++)
            {
                if (Convert.ToString(ChrtSchoolAtt.Series[0].Points[i].AxisLabel) == "Leave")
                {
                    ChrtSchoolAtt.Series[0].Points[i].Color = Color.Orange;
                    break;
                }
                //else
                //{
                //    if (pointAdd == false)
                //    {
                //        ChrtSchoolAtt.Series[0].Points.AddXY("Leave", 0);
                //        pointAdd = true;
                //    }
                //}
            }
          
            ChrtSchoolAtt.ChartAreas["ChartArea"].Area3DStyle.Enable3D = true;
            ChrtSchoolAtt.Legends[0].Enabled = true;
        }
        catch
        {
            
        }
    }

    public void FillLateStudentChart()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ChartStaffAttendance @type='LateStudents',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "',@StaffId='" + Convert.ToString(Session["User_Id"]) + "',@month='" + ddlMonth.SelectedValue + "',@Year='" + ddlYear.SelectedValue + "',@DIV='" + ddlDIV.SelectedValue + "'";
            dt = sGetDatatable(strQry, "Chart");
            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }

            ChrtLate.Series[0].Points.DataBindXY(x, y);
            ChrtLate.Series[0].IsValueShownAsLabel = true;


            //ChrtSchoolAtt.se

            int point = Convert.ToInt32(ChrtLate.Series[0].Points.Count);
            Boolean pointAdd = false;

            
            pointAdd = false;
            for (int i = 0; i < point; i++)
            {
                if (Convert.ToString(ChrtLate.Series[0].Points[i].AxisLabel) == "Late")
                {
                    ChrtLate.Series[0].Points[i].Color = Color.BurlyWood;

                    break;
                }
                //else
                //{
                //    if (pointAdd == false)
                //    {
                //        ChrtSchoolAtt.Series[0].Points.AddXY("Late", 0);
                //        pointAdd = true;
                //    }
                //}
            }

            pointAdd = false;
            for (int i = 0; i < point; i++)
            {
                if (Convert.ToString(ChrtLate.Series[0].Points[i].AxisLabel) == "On Time")
                {
                    ChrtLate.Series[0].Points[i].Color = Color.DarkOliveGreen;

                    break;
                }
                //else
                //{
                //    if (pointAdd == false)
                //    {
                //        ChrtSchoolAtt.Series[0].Points.AddXY("Late", 0);
                //        pointAdd = true;
                //    }
                //}
            }

            for (int i = 0; i < point; i++)
            {
                if (Convert.ToString(ChrtLate.Series[0].Points[i].AxisLabel) == "Early")
                {
                    ChrtLate.Series[0].Points[i].Color = Color.GreenYellow;

                    break;
                }
                //else
                //{
                //    if (pointAdd == false)
                //    {
                //        ChrtSchoolAtt.Series[0].Points.AddXY("Late", 0);
                //        pointAdd = true;
                //    }
                //}
            }

            ChrtLate.ChartAreas["ChartArea"].Area3DStyle.Enable3D = true;
            ChrtLate.Legends[0].Enabled = true;
        }
        catch
        {

        }
    }

    public void FillYear()
    {
        try
        {
            int count = ddlYear.Items.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                ddlYear.Items.Remove(ddlYear.Items[i].Value);
            }
            for (int i = 2005; i <= DateTime.Now.Year; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
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
            
            FillSchoolChart();
            FillVacation();
            FillHoliday();
            FillLeave();
            FillStackedChart();
            FillDetail();
            FillLateStudentChart();
        }
        catch 
        {
            
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        FillSchoolChart();
        FillVacation();
        FillHoliday();
        FillLeave();
        FillDetail();
        FillLateStudentChart();
    }
    protected void grvAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvHoliday.PageIndex = e.NewPageIndex;
        grvHoliday.DataBind();
    }
    public void FillHoliday()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ChartStaffAttendance @type='FillHoliday',@SchoolId='" + Session["School_Id"] + "',@month='" + ddlMonth.SelectedValue + "',@Year='" + ddlYear.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            grvHoliday.DataSource = dsObj;
            grvHoliday.DataBind();
        }
        catch
        {
            
        }
    }
    public void FillVacation()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ChartStaffAttendance @type='FillVacation',@SchoolId='" + Session["School_Id"] + "',@month='" + ddlMonth.SelectedValue + "',@Year='" + ddlYear.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            grvVacation.DataSource = dsObj;
            grvVacation.DataBind();
        }
        catch
        {

        }
    }
    protected void grvVacation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvVacation.PageIndex = e.NewPageIndex;
        grvVacation.DataBind();
    }

    public void FillLeave()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ChartStaffAttendance @type='FillLeave',@SchoolId='" + Session["School_Id"] + "',@month='" + ddlMonth.SelectedValue + "',@Year='" + ddlYear.SelectedValue + "',@StaffId='" + Convert.ToString(Session["User_Id"]) + "',@UserType='" + Convert.ToString(Session["UserType_id"]) + "'";
            dsObj = sGetDataset(strQry);
            
            grvLeaveStatus.DataSource = dsObj;
            grvLeaveStatus.DataBind();
        }
        catch (Exception)
        {
            
            throw;
        }
    }
  
    protected void grvLeaveStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvLeaveStatus.PageIndex = e.NewPageIndex;
        grvLeaveStatus.DataBind();
    }
    protected void ImgHoliday_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~\\frmHolidayMst.aspx?Month='" + Convert.ToString(ddlMonth.SelectedValue) + "'&Year='" + Convert.ToString(ddlYear.SelectedValue) + "'", false);

    }
    public void FillDIV()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_ChartStaffAttendance] @type='FillDIV',@SchoolId='" + Session["School_Id"] + "',@StaffId='" + Session["User_Id"] + "'";
            sBindDropDownList(ddlDIV, strQry, "vchDivisionName", "intDivision_id");

            if (Convert.ToString(Session["UserType_Id"]) == "3" || Convert.ToString(Session["UserType_Id"]) == "4")
            {
                ddlDIV.Enabled = false;
                ddlSTD.Enabled = false;
                ddlSTD.SelectedIndex=1;
                ddlDIV.SelectedIndex = 1;
            }
        }
        catch
        {
            
        }
    }
    public void FillSTD()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_ChartStaffAttendance] @type='FillSTD',@SchoolId='" + Session["School_Id"] + "',@StaffId='" + Session["User_Id"] + "'";
            sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
        }
        catch 
        {
            
            throw;
        }
    }

    public void FillDetail()
    {
        try
        {
            int TotPresent = 0,TotLate=0,TotEarly=0;
            strQry = "";
            strQry = "exec usp_ChartStaffAttendance @type='GetTotalStudentStatus',@Div='" + ddlDIV.SelectedValue + "',@Year='" + ddlYear.SelectedValue + "',@month='" + ddlMonth.SelectedValue + "',@SchoolId='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);

            if (dsObj.Tables[0].Rows.Count > 0 && Convert.ToInt32(dsObj.Tables[0].Rows[0]["cnt"])>0)
            {
                Detail.Visible = true;
                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToString(dsObj.Tables[0].Rows[i]["status"]) == "Absent")
                    {
                        lnkAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["cnt"]);
                    }
                    if (Convert.ToString(dsObj.Tables[0].Rows[i]["status"]) == "Early")
                    {
                        TotEarly = Convert.ToInt32(dsObj.Tables[0].Rows[i]["cnt"]);
                    }
                    else if (Convert.ToString(dsObj.Tables[0].Rows[i]["status"]) == "Present")
                    {
                        //if (Convert.ToString(lnkLate.Text) != "")
                        //{
                        //    TotPresent = Convert.ToInt32(lnkLate.Text);
                        //}

                       TotPresent=Convert.ToInt32(dsObj.Tables[0].Rows[i]["cnt"]);

                     //  lblPresent.Text = Convert.ToString(TotPresent) ;
                    }
                    else if (Convert.ToString(dsObj.Tables[0].Rows[i]["status"]) == "Late")
                    {
                        lnkLate.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["cnt"]);
                        TotLate = Convert.ToInt32(dsObj.Tables[0].Rows[i]["cnt"]);
                    }
                    else if (Convert.ToString(dsObj.Tables[0].Rows[i]["status"]) == "Leave")
                    {
                        LnkPending.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["cnt"]);
                    }
                }

                TotPresent = TotLate + TotEarly + TotPresent;
                lblPresent.Text = Convert.ToString(TotPresent);
            }
            else
            {
                Detail.Visible = false;
                lblPresent.Text = "";
                lnkLate.Text = "";
            }

        }
        catch
        {
        }
    }

    public void FillStackedChart()
    {
        DataTable dt = new DataTable();
        try
        {
            strQry = "exec [usp_ChartStaffAttendance] @type='FillStudent',@DIV='" + ddlDIV.SelectedValue + "',@STD='" + ddlSTD.SelectedValue + "',@SchoolId='" + Session["School_Id"] + "',@Year='" + ddlYear.SelectedValue + "',@month='" + ddlMonth.SelectedValue + "'";
            dsObj = sGetDataset(strQry);

            

            //for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
            //{
            //    ChrtStudentsAttendance.Series.Add(dsObj.Tables[0].Rows[i]["Name"].ToString());
            //}

            strQry = "exec [usp_ChartStaffAttendance] @type='FillStudentAtt',@DIV='" + ddlDIV.SelectedValue + "',@STD='" + ddlSTD.SelectedValue + "',@SchoolId='" + Session["School_Id"] + "',@Year='" + ddlYear.SelectedValue + "',@month='" + ddlMonth.SelectedValue + "'";
            dsObj = sGetDataset(strQry);



            ChrtStudentsAttendance.Series.Add("Series1");         


            ChrtStudentsAttendance.DataSource = dsObj;

            ChrtStudentsAttendance.Series["Series1"].XValueMember = "Name";
            ChrtStudentsAttendance.Series["Series1"].YValueMembers = "count";


            ChrtStudentsAttendance.DataBind();


            if (dsObj.Tables[0].Rows.Count > 0)
            {
                if (dsObj.Tables[0].Rows.Count <= 10)
                {
                    ChrtStudentsAttendance.Width = 300;
                }
                else if (dsObj.Tables[0].Rows.Count > 10 && dsObj.Tables[0].Rows.Count < 30)
                {
                    ChrtStudentsAttendance.Width = 500;
                }
                else
                {
                    ChrtStudentsAttendance.Width = 900;
                }
            }
           

            //for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
            //{
            //    for (int j = 0; j < ChrtStudentsAttendance.Series.Count; j++)
            //    {
            //        if (ChrtStudentsAttendance.Series[j].Name == Convert.ToString(dsObj.Tables[0].Rows[i]["Name"]))
            //        {
            //            ChrtStudentsAttendance.Series[j].Points.AddXY(Convert.ToString(dsObj.Tables[0].Rows[i]["Name"]), Convert.ToInt32(dsObj.Tables[0].Rows[i]["count"]));
            //        }
            //    }
                
               
            //}

            //ChrtStudentsAttendance.Series.Add("Series 1");
            //ChrtStudentsAttendance.Series.Add("Series 2");
            //ChrtStudentsAttendance.Series.Add("Series 3");
            //ChrtStudentsAttendance.Series.Add("Series 4");
            //ChrtStudentsAttendance.Series.Add("Series 5");
            //ChrtStudentsAttendance.Series["Series 1"].ChartType =     SeriesChartType.StackedColumn;
            ////ChrtStudentsAttendance.Series["Series 2"].ChartType = SeriesChartType.StackedColumn;
            ////ChrtStudentsAttendance.Series["Series 3"].ChartType = SeriesChartType.StackedColumn;
            ////ChrtStudentsAttendance.Series["Series 4"].ChartType = SeriesChartType.StackedColumn;
            ////ChrtStudentsAttendance.Series["Series 5"].ChartType = SeriesChartType.StackedColumn;
            // ChrtStudentsAttendance.Series["Series 1"].Points.AddXY(1, 50);
           //// ChrtStudentsAttendance.Series["Series 2"].Points.AddXY(1, 100);
           // ChrtStudentsAttendance.Series["Series 2"].Points.AddXY(2, 50);
           //// ChrtStudentsAttendance.Series["Series 3"].Points.AddXY(2, 200);
           // ChrtStudentsAttendance.Series["Series 3"].Points.AddXY(3, 100);
           // ChrtStudentsAttendance.Series["Series 4"].Points.AddXY(4, 50);
           // ChrtStudentsAttendance.Series["Series 5"].Points.AddXY(5, 150);


        }
        catch
        {
        }

    }

    protected void lnkAbsent_Click(object sender, System.EventArgs e)
    {
        try
        {
            lblStatus.Text = "Absent Students Details";

            strQry = "";
            strQry = "exec [usp_ChartStaffAttendance] @type='StudentStatus',@DIV='" + ddlDIV.SelectedValue + "',@SchoolId='" + Session["School_Id"] + "',@month='" + ddlMonth.SelectedValue + "',@year='" + ddlYear.SelectedValue + "',@status='Absent'";
            dsObj = sGetDataset(strQry);

            grvStatus.DataSource = dsObj;
            grvStatus.DataBind();

            grvStatus.Columns[2].Visible = true;
            grvStatus.Columns[3].Visible = false;
            grvStatus.Columns[4].Visible = false;
            grvStatus.Columns[5].Visible = false;
            grvStatus.Columns[5].Visible = false;
           // pnlAbsent.Visible = true;
            ModalPopupExtender1.Show();

            FillSchoolChart();
            FillVacation();
            FillHoliday();
            FillLeave();
            FillSTD();
            FillDIV();
            FillStackedChart();
            FillDetail();
            FillLateStudentChart();
        }
        catch
        {
            
        }
    }
    protected void grvStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvStatus.PageIndex = e.NewPageIndex;
        grvStatus.DataBind();
    }
    protected void lnkLate_Click(object sender, System.EventArgs e)
    {
        try
        {
            lblStatus.Text = "Late Reported Students Details";

            strQry = "";
            strQry = "exec [usp_ChartStaffAttendance] @type='StudentStatus',@DIV='" + ddlDIV.SelectedValue + "',@SchoolId='" + Session["School_Id"] + "',@month='" + ddlMonth.SelectedValue + "',@year='" + ddlYear.SelectedValue + "',@status='Late'";
            dsObj = sGetDataset(strQry);

            grvStatus.DataSource = dsObj;
            grvStatus.DataBind();

            grvStatus.Columns[2].Visible = true;
            grvStatus.Columns[3].Visible = false;
            grvStatus.Columns[4].Visible = false;
            grvStatus.Columns[5].Visible = false;
            grvStatus.Columns[6].Visible = true;
            // pnlAbsent.Visible = true;
            ModalPopupExtender1.Show();

            FillSchoolChart();
            FillVacation();
            FillHoliday();
            FillLeave();
            FillSTD();
            FillDIV();
            FillStackedChart();
            FillDetail();
            FillLateStudentChart();
        }
        catch
        {

        }
    }
    protected void LnkPending_Click(object sender, System.EventArgs e)
    {
        try
        {
             lblStatus.Text = "Pending Leave Approvals";

            strQry = "";
            strQry = "exec [usp_ChartStaffAttendance] @type='StudentLeavePending',@DIV='" + ddlDIV.SelectedValue + "',@SchoolId='" + Session["School_Id"] + "',@month='" + ddlMonth.SelectedValue + "',@year='" + ddlYear.SelectedValue + "',@status='Late'";
            dsObj = sGetDataset(strQry);

            grvStatus.DataSource = dsObj;
            grvStatus.DataBind();

            grvStatus.Columns[2].Visible = false;
            grvStatus.Columns[3].Visible = true;
            grvStatus.Columns[4].Visible = true;
            grvStatus.Columns[5].Visible = true;
            grvStatus.Columns[6].Visible = false;
            // pnlAbsent.Visible = true;
          

            FillSchoolChart();
            FillVacation();
            FillHoliday();
            FillLeave();
            FillSTD();
            FillDIV();
            FillStackedChart();
            FillDetail();
            FillLateStudentChart();

            ModalPopupExtender1.Show();
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    protected void ImgMsg_Click(object sender, ImageClickEventArgs e)
    {
        
            Response.Redirect("frmSendGroupMsg.aspx",false);
        
    }
}
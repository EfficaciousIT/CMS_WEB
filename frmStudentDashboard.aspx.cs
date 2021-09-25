using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Text;
//using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frmStudentDashboard : DBUtility
{
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    DataSet dsObj = new DataSet();
    string[] xAxis;
    int[] yAxis;
    DataTable dt = new DataTable();
    string strQry = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["School_Id"] != null)
        {
            Page.Header.DataBind();    
            if (!IsPostBack)
            {
                FillPersonlDetail();
                pnlStudLateAtt.Attributes.Add("display", "none");
                pnlExam.Attributes.Add("display", "none");
                FillYear();
                ddlMonth.SelectedValue = Convert.ToString(DateTime.Now.Month);
                ddlYear.SelectedValue = Convert.ToString(DateTime.Now.Year);
                if (Convert.ToString(Session["UserType_Id"]) == "1")
                {
                    HFUserId.Value = Convert.ToString(Session["Student_Id"]);
                }
                else
                {
                    HFUserId.Value = Convert.ToString(Session["User_Id"]);
                }

                HFUserType.Value = Convert.ToString(Session["UserType_Id"]);
                GetCalAttData();
                FillCalGrid(); 
                //FillBusChart();
                //FillSchoolChart();
                FillVacation();
                
                FillHoliday();
                
                FillTimetable();
                FillLibraryDetails();
                FillLoginDetails();
                FillFeesPending();
                FillInventory();
                FillExam();
                //FillSubject();
                Visibility();
                totalCount();
                fillUnReadMessage();
               // FillNoticeBoard();
                divFees.Visible = false;
                grvFees.Visible = false;
                grvFeesPending.Visible = false;
            }
            FillNoticeBoard();
        }
        else
        {
            Response.Redirect("~\\frmIndex.aspx", false);
        }
    }
    public void fillUnReadMessage()
    {
        strQry = "exec [usp_StudentDashboard] @type='achievement',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@intDivision_id='" + Convert.ToString(Session["Division_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
        //strQry = "exec [usp_StudentDashboard] @type='PendingMessage',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdMessage.DataSource = dsObj;
            grdMessage.DataBind();
        }
    }
    public void totalCount()
    {
        strQry = "exec [usp_StudentDashboard] @type='Top5Student',@DivId='" + Session["Division_id"] + "',@intSchool_Id='" + Session["School_id"] + "',@Year='2015',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToString(dsObj.Tables[0].Rows[0]["SelfCount"]) != "")
            {
                string[] strAry = Convert.ToString(dsObj.Tables[0].Rows[0]["SelfCount"]).Split('/');
                lblTotal.Text = strAry[0].ToString();
                lblPresent.Text = strAry[1].ToString();

                double p = (double)(Convert.ToDouble(strAry[0]) / Convert.ToDouble(strAry[1])) * 100;

                string s = Convert.ToString(p);

                if (s.Length > 5)
                {
                    lblPercent.Text = Convert.ToString(s.Substring(0, 5));
                }
                else
                {
                    lblPercent.Text = Convert.ToString(s);
                }
            }


        }
    }
    public void FillPersonlDetail()
    {
        try
        {
            if (Convert.ToString(Session["UserType_id"]) == "1")
            {
                strQry = "exec [usp_StudentDashboard] @type='S_Detail',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
                dsObj = sGetDataset(strQry);
                lblWelCome.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Personal"]);
                ImgProfile.ImageUrl ="~\\images\\Profile\\Students\\"+ Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
            }
            else if (Convert.ToString(Session["UserType_id"]) == "2")
            {
                strQry = "exec [usp_StudentDashboard] @type='P_Detail',@intParent_id='" + Convert.ToString(Session["User_Id"]) + "'";
                dsObj = sGetDataset(strQry);
                lblWelCome.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Personal"]);
                ImgProfile.ImageUrl = "~\\images\\Profile\\Father\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
            }
        }
        catch 
        {
            
        }
    }
    public void FillNoticeBoard()
    {
        try
        {
            strQry = "exec [usp_StudentDashboard] @type='NoticeBoard',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@DivId='" + Convert.ToString(Session["Division_id"]) + "',@StudentId='" + Convert.ToString(Session["Student_id"]) + "' ";
            //if (Convert.ToString(Session["User_id"]) == "0")
            //{
            //    strQry = "exec [usp_StudentDashboard] @type='NoticeBoard',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@DivId='" + Convert.ToString(Session["Division_id"]) + "',@StudentId='" + Convert.ToString(Session["Student_id"]) + "' ";
            //}
            //else
            //{
            //    strQry = "exec [usp_StudentDashboard] @type='NoticeBoard',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@DivId='" + Convert.ToString(Session["Division_id"]) + "',@StudentId='" + Convert.ToString(Session["User_id"]) + "' ";
            //}
            
            //if (Convert.ToString(Session["UserType_id"]) == "2")
            //{
            //   // strQry =strQry + " ,@StudentId='" + Convert.ToString(Session["Student_id"]) + "'";
            //}

            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grdNotice.DataSource = dsObj;
                grdNotice.DataBind();
            }
          //  Table tbl = new Table();
          ////  TableRow tr = new TableRow();

          //  TableHeaderCell th=new TableHeaderCell();
          //  TableCell td = new TableCell();
          //  tbl.Width = 500;
          //  tbl.CaptionAlign = TableCaptionAlign.Top;
            
          //  for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
          //  {
          //      Label data = new Label();
          //      TableRow tr = new TableRow();
          //      td = new TableCell();
          //      data.Font.Underline = true;
          //      data.Text = "Subject :" + Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubject"]) + " (From : " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtIssue_date"]) + " To " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtEnd_date"])+")";
          //      th.Controls.Add(data);
          //      tr.Cells.Add(th);
          //      tbl.Rows.Add(tr);

          //      TableRow tr1 = new TableRow();
          //      TableCell td1 = new TableCell();
          //      data.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchNotice"]);
          //      td1.Controls.Add(data);
          //      tr1.Cells.Add(td1);
          //      tbl.Rows.Add(tr1);
          //      divNoticeBorad.Controls.Add(tbl);
                
          //  }
            
        }
        catch
        {
            
        }
    }

    public void Visibility()
    {
        if(Convert.ToString(Session["UserType_id"])=="1")
        {
            TabLeave.Visible = false;
            grvLeaveStatus.Visible = true;
            FillLeave();
        }
        else if (Convert.ToString(Session["UserType_id"]) == "2")
        {
            TabLeave.Visible = true;
            grvLeaveStatus.Visible = false;
            FillParentAppliedLeave();
            FillStudentLeave();
        }
        
      
    }

    [System.Web.Services.WebMethod]
    public static string Notification(string UserType, string Id)
    {
        try
        {
            string strQry = "";
            strQry = "exec [usp_ChartStaffAttendance] @type='MsgNotification',@UserType='" + UserType + "',@StaffId='" + Id + "'";
            DataSet ds = new DataSet();
            ds = sGetDataset(strQry);
            Label lblMsgCount = new Label();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMsgCount.Text = Convert.ToString(ds.Tables[0].Rows[0][0]);
            }
            return lblMsgCount.Text;
        }
        catch
        {
            return "false";

        }
    }
   
    public void GetCalAttData()
    {
        try
        {
            string strQry = "";
            DataSet dsObj = new DataSet();

            strQry = "exec [usp_StudentDashboard] @type='getStudentCalenderAtt',@intStudentId=" + HttpContext.Current.Session["Student_id"] + ",@intSchool_id='" + HttpContext.Current.Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            HttpContext.Current.Session["Table"] = dsObj;


            strQry = "exec [usp_StudentDashboard] @type='StudentBusAtt',@intStudentId=" + HttpContext.Current.Session["Student_id"] + ",@intSchool_id='" + HttpContext.Current.Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            HttpContext.Current.Session["BusTable"] = dsObj;
       
        }
        catch
        {
          
        }


    }

    public void FillCalGrid()
    {
        try
        {
            if (CalAttendance.VisibleDate.Year != 001)
            {
                Year = CalAttendance.VisibleDate.Year - 1;
                Month = CalAttendance.VisibleDate.Month;
            }
            else
            {
                Year = DateTime.Now.Year;
                Month = DateTime.Now.Month;
            }

            strQry = "exec [usp_StudentDashboard] @type='StudentsAttendance',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@month='" + Convert.ToString(Month) + "',@year='" + Convert.ToString(Year) + "',@intSchool_id='" + Session["School_id"] + "'";

            dsObj = sGetDataset(strQry);
            Session["Attend"] = dsObj;
            grvAttendance.DataSource = dsObj;
            grvAttendance.DataBind();
        }
        catch
        {
            
        }
    }

    public void FillLibraryDetails()
    {
        try
        {
            strQry = "Select intAssign_id,tblLibraryTrnDet.intLibrary_id,convert(varchar,dtAssignDate,103) 'Issue',convert(varchar,dtReturnDate,103) 'Return',  vchCategory_name 'Category',vchBook_name 'Book' from tblLibraryTrnDet inner join tblLibraryCardDet on tblLibraryCardDet.intLibrary_id=tblLibraryTrnDet.intLibrary_id inner join tblBookDetails on tblBookDetails.intBook_id=tblLibraryTrnDet.intBook_id inner join tblBookCategory on tblBookCategory.intCategory_id=tblBookDetails.intCategory_id where bitDeleteFlag=1 and intStudent_id='" + Convert.ToString(Session["Student_id"]) + "' and tblLibraryTrnDet.intschool_id='" + Convert.ToString(Session["School_id"]) + "' and tblLibraryCardDet.intschool_id='" + Convert.ToString(Session["School_id"]) + "' and tblBookCategory.intschool_id='" + Convert.ToString(Session["School_id"]) + "'  and dtActualRetDate is NULL";
            //strQry = "exec [usp_StudentDashboard] @type='LibraryDetail',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
            //
            dsObj= sGetDataset(strQry);
            grvLibrary.DataSource = dsObj;
            grvLibrary.DataBind();
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                divLibrary.Visible = true;
                grvLibrary.Visible = true;
            }
            else
            {
                divLibrary.Visible = true;
                grvLibrary.Visible = true;
            }
        }
        catch 
        {
            
        }
    }

    public void FillLoginLog()
    {
        try
        {
            strQry = "exec [usp_StudentDashboard] @type='StudentLog',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {

            }
        }
        catch 
        {
            
        }
    }

    //public void FillBusChart()
    //{
        
    //        try
    //        {
                
    //            strQry = "";
    //            strQry = "exec usp_ChartStudentAttendance @type='FillBusAttendance',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "',@StudentId='" + Convert.ToString(Session["Student_id"]) + "',@month='" + Convert.ToString(Month) + "',@Year='" + Convert.ToString(Year) + "'";
    //            dt = sGetDatatable(strQry, "Chart");
    //            string[] x = new string[dt.Rows.Count];
    //            int[] y = new int[dt.Rows.Count];
    //            for (int i = 0; i < dt.Rows.Count; i++)
    //            {
    //                x[i] = dt.Rows[i][0].ToString();
    //                y[i] = Convert.ToInt32(dt.Rows[i][1]);
    //            }
    //            xAxis = x;
    //            yAxis = y;

    //            ChrtBus.Series[0].Points.DataBindXY(x, y);
    //            ChrtBus.Series[0].IsValueShownAsLabel = true;


    //            //ChrtBus.se

    //            int point = Convert.ToInt32(ChrtBus.Series[0].Points.Count);
    //            Boolean pointAdd = false;




    //            for (int i = 0; i < point; i++)
    //            {
    //                if (Convert.ToString(ChrtBus.Series[0].Points[i].AxisLabel) == "Present")
    //                {
    //                    ChrtBus.Series[0].Points[i].Color = Color.Green;
    //                    break;
    //                }
    //                //else
    //                //{

    //                //    if (pointAdd == false)
    //                //    {
    //                //        ChrtBus.Series[0].Points.AddXY("Present", 0);
    //                //        pointAdd = true;

    //                //    }

    //                //}
    //            }

    //            pointAdd = false;

    //            for (int i = 0; i < point; i++)
    //            {
    //                if (Convert.ToString(ChrtBus.Series[0].Points[i].AxisLabel) == "Absent")
    //                {
    //                    ChrtBus.Series[0].Points[i].Color = Color.Red;
    //                    break;
    //                }
    //                //else
    //                //{
    //                //    if (pointAdd == false)
    //                //    {
    //                //        ChrtBus.Series[0].Points.AddXY("Absent", 0);
    //                //        pointAdd = true;

    //                //    }
    //                //}
    //            }

    //            pointAdd = false;
    //            for (int i = 0; i < point; i++)
    //            {
    //                if (Convert.ToString(ChrtBus.Series[0].Points[i].AxisLabel) == "Late")
    //                {
    //                    ChrtBus.Series[0].Points[i].Color = Color.SkyBlue;

    //                    break;
    //                }
    //                //else
    //                //{
    //                //    if (pointAdd == false)
    //                //    {
    //                //        ChrtBus.Series[0].Points.AddXY("Late", 0);
    //                //        pointAdd = true;
    //                //    }
    //                //}
    //            }

    //            pointAdd = false;
    //            for (int i = 0; i < point; i++)
    //            {
    //                if (Convert.ToString(ChrtBus.Series[0].Points[i].AxisLabel) == "Leave")
    //                {
    //                    ChrtBus.Series[0].Points[i].Color = Color.Orange;
    //                    break;
    //                }
    //                //else
    //                //{
    //                //    if (pointAdd == false)
    //                //    {
    //                //        ChrtBus.Series[0].Points.AddXY("Leave", 0);
    //                //        pointAdd = true;
    //                //    }
    //                //}
    //            }

    //            ChrtBus.ChartAreas["ChartArea"].Area3DStyle.Enable3D = true;
    //            ChrtBus.Legends[0].Enabled = true;
    //        }
    //        catch
    //        {

    //        }
        
       
    //}

    //public void FillSchoolChart()
    //{
    //    try
    //    {
    //        strQry = "";
    //        strQry = "exec usp_ChartStudentAttendance @type='FillSchoolChart',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "',@StudentId='" + Convert.ToString(Session["Student_id"]) + "',@month='" + Convert.ToString(Month) + "',@Year='" + Convert.ToString(Year) + "'";
    //        dt = sGetDatatable(strQry, "Chart");
    //        if (dt.Rows.Count > 0)
    //        {
    //            string[] x = new string[dt.Rows.Count];
    //            int[] y = new int[dt.Rows.Count];
    //            for (int i = 0; i < dt.Rows.Count; i++)
    //            {
    //                x[i] = dt.Rows[i][0].ToString();
    //                y[i] = Convert.ToInt32(dt.Rows[i][1]);
    //            }

    //            ChrtSchoolAtt.Series[0].Points.DataBindXY(x, y);
    //            ChrtSchoolAtt.Series[0].IsValueShownAsLabel = true;


    //            //ChrtSchoolAtt.se

    //            int point = Convert.ToInt32(ChrtSchoolAtt.Series[0].Points.Count);
    //            Boolean pointAdd = false;




    //            for (int i = 0; i < point; i++)
    //            {
    //                if (Convert.ToString(ChrtSchoolAtt.Series[0].Points[i].AxisLabel) == "Present")
    //                {
    //                    ChrtSchoolAtt.Series[0].Points[i].Color = Color.Green;
    //                    break;
    //                }
    //                //else
    //                //{

    //                //    if (pointAdd == false)
    //                //    {
    //                //        ChrtSchoolAtt.Series[0].Points.AddXY("Present", 0);
    //                //        pointAdd = true;

    //                //    }

    //                //}
    //            }

    //            pointAdd = false;

    //            for (int i = 0; i < point; i++)
    //            {
    //                if (Convert.ToString(ChrtSchoolAtt.Series[0].Points[i].AxisLabel) == "Absent")
    //                {
    //                    ChrtSchoolAtt.Series[0].Points[i].Color = Color.Red;
    //                    break;
    //                }
    //                //else
    //                //{
    //                //    if (pointAdd == false)
    //                //    {
    //                //        ChrtSchoolAtt.Series[0].Points.AddXY("Absent", 0);
    //                //        pointAdd = true;

    //                //    }
    //                //}
    //            }

    //            pointAdd = false;
    //            for (int i = 0; i < point; i++)
    //            {
    //                if (Convert.ToString(ChrtSchoolAtt.Series[0].Points[i].AxisLabel) == "Late")
    //                {
    //                    ChrtSchoolAtt.Series[0].Points[i].Color = Color.SkyBlue;

    //                    break;
    //                }
    //                //else
    //                //{
    //                //    if (pointAdd == false)
    //                //    {
    //                //        ChrtSchoolAtt.Series[0].Points.AddXY("Late", 0);
    //                //        pointAdd = true;
    //                //    }
    //                //}
    //            }

    //            pointAdd = false;
    //            for (int i = 0; i < point; i++)
    //            {
    //                if (Convert.ToString(ChrtSchoolAtt.Series[0].Points[i].AxisLabel) == "Leave")
    //                {
    //                    ChrtSchoolAtt.Series[0].Points[i].Color = Color.Orange;
    //                    break;
    //                }
    //                //else
    //                //{
    //                //    if (pointAdd == false)
    //                //    {
    //                //        ChrtSchoolAtt.Series[0].Points.AddXY("Leave", 0);
    //                //        pointAdd = true;
    //                //    }
    //                //}
    //            }

    //            ChrtSchoolAtt.ChartAreas["ChartArea"].Area3DStyle.Enable3D = true;
    //            ChrtSchoolAtt.Legends[0].Enabled = true;
    //        }
    //        else
    //        {
    //            ChrtSchoolAtt.Series[0].LegendText = "No Data";
    //            ChrtSchoolAtt.Series[0].IsValueShownAsLabel = true;
    //        }
    //    }
    //    catch
    //    {
            
    //    }
    //}
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
            Month = Convert.ToInt32(ddlMonth.SelectedValue);
            Year = Convert.ToInt32(ddlYear.SelectedValue);
            CalAttendance.VisibleDate = Convert.ToDateTime(Month.ToString().PadLeft(2, '0') + "/" + "01/" + Year);
            GetCalAttData();
            FillCalGrid();
            //FillBusChart();
            //FillSchoolChart();
            FillVacation();
            FillHoliday();
            FillLeave();
            Visibility();
        }
        catch 
        {
            
        }
    }
    public void FillLoginDetails()
    {
        try
        {
            strQry = "exec [usp_StudentDashboard] @type='StudentLog',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
            dsObj = sGetDataset(strQry);
            grvLastLogin.DataSource = dsObj;
            grvLastLogin.DataBind();

        }
        catch 
        {
            
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        Month = Convert.ToInt32(ddlMonth.SelectedValue);
        Year = Convert.ToInt32(ddlYear.SelectedValue);
        CalAttendance.VisibleDate = Convert.ToDateTime(Month.ToString().PadLeft(2, '0') + "/" + "01/" + Year);
        GetCalAttData();
        //FillBusChart();
        //FillSchoolChart();
        FillVacation();
        FillHoliday();
        FillLeave();
        Visibility();
    }
    public void FillFeesPending()
    {
        try
        {
            strQry = "exec usp_tbl_StudentFeeAssignment  @type='FillGrid',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvFeesPending.DataSource = dsObj;
                grvFeesPending.DataBind();
            }
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                divFees.Visible = true;
                grvFeesPending.Visible = true;
            }
            else
            {
                divFees.Visible = false;
                grvFeesPending.Visible = false;
            }
        }
        catch 
        {
            
        }
    }
    protected void grvAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //grvHoliday.PageIndex = e.NewPageIndex;
        //grvHoliday.DataBind();
    }
    public void FillHoliday()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ChartStudentAttendance @type='FillHoliday',@SchoolId='" + Session["School_Id"] + "',@month='" + ddlMonth.SelectedValue + "',@Year='" + ddlYear.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            grvHoliday.DataSource = dsObj;
            grvHoliday.DataBind();
        }
        catch
        {
            
        }
    }
    public void FillStudentLeave()
    {
        try
        {
            strQry = "exec [usp_StudentDashboard] @type='StudentLeaves',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@month='" + ddlMonth.SelectedValue + "',@Year='" + ddlYear.SelectedValue + "',@SchoolId='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            grvStudentLeave.DataSource = dsObj;
            grvStudentLeave.DataBind();
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                divLeave.Visible = true;
                grvStudentLeave.Visible = true;
            }
            else
            {
                // divLeave.Visible = false;
                grvStudentLeave.Visible = false;
            }
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
            strQry = "exec usp_ChartStudentAttendance @type='FillVacation',@SchoolId='" + Session["School_Id"] + "',@month='" + ddlMonth.SelectedValue + "',@Year='" + ddlYear.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            grvVacation.DataSource = dsObj;
            grvVacation.DataBind();
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                divVacation.Visible = true;
                grvVacation.Visible = true;
            }
            else
            {
                divVacation.Visible = false;
                grvVacation.Visible = false;
            }
        }
        catch
        {

        }
    }

    public void FillParentAppliedLeave()
    {
        try
        {
            strQry = "exec [usp_StudentDashboard] @type='ParentLeaves',@month='" + ddlMonth.SelectedValue + "',@Year='" + ddlYear.SelectedValue + "',@StudentId='" + Convert.ToString(Session["Student_id"]) + "',@intUser_id='" + Session["User_id"] + "',@SchoolId='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            grvParentLeave.DataSource = dsObj;
            grvParentLeave.DataBind();
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                divLeave.Visible = true;
                grvParentLeave.Visible = true;
            }
            else
            {
               // divLeave.Visible = false;
                grvParentLeave.Visible = false;
            }
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
            strQry = "exec usp_ChartStudentAttendance @type='FillLeave',@SchoolId='" + Session["School_Id"] + "',@month='" + ddlMonth.SelectedValue + "',@Year='" + ddlYear.SelectedValue + "',@StudentId='" + Convert.ToString(Session["Student_id"]) + "'";
            dsObj = sGetDataset(strQry);
            
            grvLeaveStatus.DataSource = dsObj;
            grvLeaveStatus.DataBind();
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                divLeave.Visible = true;
                grvLeaveStatus.Visible = true;
            }
            else
            {
                divLeave.Visible = false;
                grvLeaveStatus.Visible = false;
            }
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
    protected void ImgMsg_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("frmSendGroupMsg.aspx", false);
    }
    protected void grvTimetable_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        Label lblRecess = (Label)e.Row.FindControl("lblRecess");
        //        Label lblTime = (Label)e.Row.FindControl("lblPeriod");
        //        Label lblSrNo = (Label)e.Row.FindControl("lblSrno");

                
        //        if (lblRecess.Text == "1" || lblRecess.Text == "True")
        //        {
        //            e.Row.BackColor = System.Drawing.Color.Silver;
        //            e.Row.Font.Bold = true;
        //            e.Row.ForeColor = System.Drawing.Color.Red;
        //            e.Row.Cells[2].Text = "R";
        //            e.Row.Cells[3].Text = "E";
        //            e.Row.Cells[4].Text = "C";
        //            e.Row.Cells[5].Text = "E";
        //            e.Row.Cells[6].Text = "S";
        //            e.Row.Cells[7].Text = "S";

        //        }
        //    }
        //}
        //catch
        //{

        //}
    }
    public void FillTimetable()
    {
        try
        {        
            strQry = "";
            strQry = "exec [usp_StudentDashboard] @type='FillTimeTable',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@DivId='" + Convert.ToString(Session["Division_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";//,@intTeacher_id='" + Convert.ToString(Session["User_id"]) + "'";
            DataTable dt = new DataTable();
            dt = sGetDatatable(strQry,"TimeTable");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                BoundField col = new BoundField();
                col.HeaderText = Convert.ToString(dt.Columns[i].ColumnName);
                col.DataField = Convert.ToString(dt.Columns[i].ColumnName);
                grvTimetable.Columns.Add(col);
            }
            grvTimetable.DataSource = dt;
            grvTimetable.DataBind();
        }
        catch 
        {

        }
    }
    public void FillInventory()
    {
        try
        {
            strQry = "exec [usp_StudentDashboard] @type='InventoryDetail',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
            dsObj = sGetDataset(strQry);
            grvInventory.DataSource = dsObj;
            grvInventory.DataBind();
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                divInventory.Visible = true;
                grvInventory.Visible = true;
            }
            else
            {
                divInventory.Visible = true;
                grvInventory.Visible = true;
            }
        }
        catch 
        {
         
        }
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        string Day_Date = e.Day.Date.ToShortDateString();

        if (e.Day.Date.Day.ToString() == "15")
        {
           // ddlMonth.SelectedValue = Convert.ToString(e.Day.Date.Month);
            //ddlMonth_SelectedIndexChanged(null, null);
            Month=  Convert.ToInt32(e.Day.Date.Month);
            Year=  Convert.ToInt32(e.Day.Date.Year);
            //FillBusChart();
            //FillSchoolChart();
        }

        try
        {
            if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F14c57");
                e.Cell.ToolTip = "Holiday";
                // return;
            }
            if (((DataSet)Session["Table"] != null))
            {

                foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                {
                   
                    
                    // var str = ((DataSet)Session["Table"]).Tables[0].Select("LoginDateTime ='" + Convert.ToDateTime(Day_Date).ToString() + "'");
                    string scheduled_LoginTime = Convert.ToString(dr["Login"]);
                    string scheduled_LogoutTime = dr["LogoutDateTime"].ToString();
                    string WeekDay = dr["vchDay"].ToString();
                    if (scheduled_LogoutTime == "")
                    {
                        scheduled_LogoutTime = "0";
                    }
                    else
                    {
                        scheduled_LogoutTime = Convert.ToString(dr["LogoutDateTime"]);
                    }
                    if (e.Day.Date.ToString("dd") == "15")
                    {
                     //   Month = e.Day.Date.Month;
                        Year = e.Day.Date.Year;
                    }
                    //if (str.Length > 0)
                    //{

                    string scheduledDate = Convert.ToDateTime(dr["LoginDateTime"]).ToShortDateString();
                    if (scheduledDate.Equals(Day_Date))
                    {

                        LinkButton lb = new LinkButton();
                       

                        string status = Convert.ToString(dr["Present_Status"]);
                        
                        if (status == "Early")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=blue>Early</font>" + "<br/>" + scheduled_LoginTime;
                           // e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Early";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#006600");

                        }
                        else if (status == "Present")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Present</font>" + "<br/>";
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Present</font>" + "<br/>" + scheduled_LoginTime;
                           // e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Present";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Leave")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Present</font>" + "<br/>";
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Present</font>" + "<br/>" + scheduled_LoginTime;
                         //   e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Leave";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFA500");

                        }
                       
                        
                        else if (status == "Late")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=maroon>Late</font>" + "<br/>" + scheduled_LoginTime;
                          //  e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Late";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#87CEEB");

                        }
                        else if (status == "Absent")
                        {
                            //lc1.Text = @"<br/>" + "<font size=1 color=black>Absent</font>";
                          //  e.Cell.Controls.Add(lc1);
                            e.Cell.ToolTip = "Absent";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");

                        }
                        else if (status == "Leave")
                        {
                            //lc2.Text = @"<br/>" + "<font size=1 color=black> Leave Approving </font>" + "<br/>" + scheduled_LoginTime;
                          //  e.Cell.Controls.Add(lc2);
                            e.Cell.ToolTip = "Leave Approving";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFA500");
                        }
                        else
                        {
                            // e.Cell.Controls.Add(lc1);
                            e.Cell.ToolTip = "Absent";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                        }
                        // break;
                        // }
                        //else
                        //{

                        if ((e.Day.Date <= DateTime.Now.Date) && (e.Cell.BackColor == System.Drawing.ColorTranslator.FromHtml("#FFFFFF")))
                        {
                            // e.Cell.Controls.Add(lc1);
                            e.Cell.ToolTip = "Absent";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");

                        }
                        //   break;
                    }

                }

            }

            if (((DataSet)Session["BusTable"] != null))
            {
                System.Web.UI.WebControls.Image ImgBus = new System.Web.UI.WebControls.Image();
                foreach (DataRow dr in ((DataSet)Session["BusTable"]).Tables[0].Rows)
                {

                    string BusDate = Convert.ToDateTime(dr["dtAttendance_date"]).ToShortDateString();

                   // string BusAtt = Convert.ToString(dr["BusAtt"]);
                    if (BusDate.Equals(Day_Date))
                    {
                        
                            ImgBus.ImageUrl = "~\\images\\bus21.png";
                            ImgBus.Height = 10;
                            ImgBus.Width = 8;
                            ImgBus.ImageAlign = ImageAlign.Left;
                            e.Cell.Controls.Add(ImgBus);
                            e.Cell.Style.Add("align", "right");

                        
                    }
                }
            }

            //ddlMonth_SelectedIndexChanged(null, null);
            FillCalGrid();
         
            //FillVacation();
            //FillHoliday();
            //FillLeave();
        }
        catch (Exception ex)
        {

        }
    }
    protected void lnkstatus_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnk=(LinkButton)sender;
            GridViewRow row = (GridViewRow)lnk.NamingContainer;
            int index = row.RowIndex;
            Label lbl;
            if (Convert.ToString(Session["UserType_Id"]) == "1")
            {
                 lbl = (Label)grvLeaveStatus.Rows[index].FindControl("lblLeaveId");
                 lblStatus.Text = Convert.ToString(grvLeaveStatus.Rows[index].Cells[1].Text);
            }
            else
            {
                if (TabLeave.ActiveTabIndex == 0)
                {
                     lbl = (Label)grvParentLeave.Rows[index].FindControl("lblLeaveId");
                     lblStatus.Text = Convert.ToString(grvParentLeave.Rows[index].Cells[1].Text);
                }
                else
                {
                     lbl = (Label)grvStudentLeave.Rows[index].FindControl("lblLeaveId");
                     lblStatus.Text = Convert.ToString(grvStudentLeave.Rows[index].Cells[1].Text);
                }
            }
            
            
            strQry = "exec [usp_ChartStudentAttendance] @type='FillLeaveDetail',@LeaveId='" + Convert.ToString(lbl.Text) + "',@SchoolId='" + Session["School_Id"] + "',@month='" + ddlMonth.SelectedValue + "',@Year='" + ddlYear.SelectedValue + "',@StudentId='" + Convert.ToString(Session["Student_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvLeaveDetail.DataSource = dsObj;
                grvLeaveDetail.DataBind();
                ModalStudLateAtt.Show();
            }
        }
        catch 
        {
            
        }
    }
    public void FillExam()
    {
        try
        {
            strQry = "exec usp_StudentDashboard @type='ExamSchedule',@intSchool_id='" + Session["School_id"] + "',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@intDivision_id='" + Convert.ToString(Session["Division_id"]) + "'";
            dsObj = sGetDataset(strQry);
            grvExam.DataSource = dsObj;
            grvExam.DataBind();
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                divExams.Visible = true;
                grvExam.Visible = true;
            }
            else
            {
                divExams.Visible = false;
                grvExam.Visible = false;
            }
        }
        catch 
        {
            
        }
    }
    //public void FillSubject()
    //{
    //    try
    //    {
    //        strQry = "exec [usp_StudentDashboard] @type='FillSubjectList',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@intSchool_id='" + Session["School_id"] + "'";
    //        sBindDropDownList(ddlSubject, strQry, "vchSubjectName", "intSubject_id");
    //        FillTeacher();

    //    }
    //    catch
    //    {
            
    //    }
    //}
    //public void FillTeacher()
    //{
    //    try
    //    {
    //        strQry = "exec [usp_StudentDashboard] @type='FillTeacherList',@Subject='" + ddlSubject.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "'";
    //        sBindDropDownList(ddlTeacher, strQry, "Name", "intTeacher_id");
    //    }
    //    catch 
    //    {
            
    //    }
    //}
    protected void lnkExamName_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow grvRow = (GridViewRow)lnk.NamingContainer;
            int rowIndex = grvRow.RowIndex;
            LinkButton lnkName=(LinkButton)grvExam.Rows[rowIndex].FindControl("lnkExamName");
            lblExamName.Text = Convert.ToString(lnkName.Text);
            strQry = "exec [usp_StudentDashboard] @type='ExamDetail',@intExam_id='" + Convert.ToString(grvExam.DataKeys[rowIndex].Value) + "',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@intDivision_id='" + Convert.ToString(Session["Division_id"]) + "',@intSchool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvExamDetails.DataSource = dsObj;
                grvExamDetails.DataBind();
                ModalPopupExtender1.Show();
            }
        }
        catch
        {
            
        }
    }
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //FillTeacher();
        }
        catch 
        {
            
        }
    }
    protected void lnkAction_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton Action = (LinkButton)sender;
            GridViewRow grvRow = (GridViewRow)Action.NamingContainer;
            int index = grvRow.RowIndex;
            lblLeaveAction.Text = Convert.ToString(grvStudentLeave.Rows[index].Cells[2].Text);
            ViewState["LeaveId"] = Convert.ToString(grvStudentLeave.DataKeys[index].Value);
            strQry = "exec [usp_StudentDashboard] @type='GetLeaveDetail',@StudentId='" + Convert.ToString(Session["Student_id"]) + "',@intLeaveApplocation_id='" + Convert.ToString(ViewState["LeaveId"]) +  "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                rdbAction.Items[Convert.ToInt32(dsObj.Tables[0].Rows[0]["bitParentApproval"])].Selected = true;
                txtRemark.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchParentsRemark"]);
                btnSubmit.Text = "Update";
                ModalLeaveRemark.Show();
            }
            else
            {
                btnSubmit.Text = "Submit";
                ModalLeaveRemark.Show();
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
            strQry = "exec [usp_StudentDashboard] @type='UpdateStudentLeave',@intLeaveApplocation_id='" + ViewState["LeaveId"] + "',@vchParentsRemark='" + Convert.ToString(txtRemark.Text) + "',@bitParentApproval='" + Convert.ToString(rdbAction.SelectedItem.Value) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Saved Successfully");
                FillStudentLeave();
                ModalLeaveRemark.Hide();
            }

        }
        catch
        {
            
        }
    }
    protected void grvInventory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblReturn = (Label)e.Row.FindControl("lblReturn");
            Label lblActual = (Label)e.Row.FindControl("lblActual");

            if (lblReturn.Text != "" || lblActual.Text == "")
            {
                if (Convert.ToDateTime(Convert.ToDateTime(lblReturn.Text).ToString("dd/MM/yyyy")) <= Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")))
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#fd2b02");
                    e.Row.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    //e.Row.BackColor = System.Drawing.Color.Orange;
                    //e.Row.ForeColor = System.Drawing.Color.White;
                    //e.Row.Font.Bold = true;
                }
            }
            
        }
    }
    protected void grvLibrary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblReturn = (Label)e.Row.FindControl("lblReturn");
           // Label lblActual = (Label)e.Row.FindControl("lblActual");

            if (lblReturn.Text != "")
            {
                if (Convert.ToDateTime(Convert.ToDateTime(lblReturn.Text).ToString("dd/MM/yyyy")) <= Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")))
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#fd2b02");
                    e.Row.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    //e.Row.BackColor = System.Drawing.Color.Orange;
                    //e.Row.ForeColor = System.Drawing.Color.White;
                    //e.Row.Font.Bold = true;
                }
            }

        }
    }
    protected void CalAttendance_SelectionChanged(object sender, EventArgs e)
    {

    }
}
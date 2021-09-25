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
using System.Data.SqlClient;

public partial class frmLatedays : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    int Year;
    int Month;
    SqlDataAdapter daObj = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
       
            if (Session["UserType_id"] != null && Session["UserId"] != null || Session["Student_id"] != null)
            {
                //Label lblTile = new Label();
                //lblTile = (Label)Page.Master.FindControl("lblPageTitle");
                //lblTile.Visible = true;
                //lblTile.Text = "Late Days Detail";
                if (!IsPostBack)
                {
                GetData();
                ddlMonth1.SelectedValue = Convert.ToString(DateTime.Now.Month);
                ddlMonth1_SelectedIndexChanged(null, null);
                FillGrid();

            }
            
          }
            else
            {
                Response.Redirect("~\\frmIndex.aspx", false);
            }
    }
     private DataSet GetData()
    {
        try
        {
            strQry = "exec usp_getAttendance @type='getCalenderLateAtt',@intUserType_id='" + Convert.ToString(Session["UserType_id"]) + "',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            Session["Table"] = dsObj;
            return dsObj;
        }
        catch (Exception)
        {
            return dsObj;
        }

    }
     protected void Calendar1_SelectionChanged(object sender, EventArgs e)
     {

     }

     public void FillGrid()
     {
         try
         {
             grvLate.DataSource = createDataTable();
             grvLate.DataBind();
             if (Session["UserType_id"] != null)
             {


                 //if (Session["UserType_id"].ToString() == "1" || Session["UserType_id"].ToString() == "2")
                 //{
                 grvLate.Columns[0].Visible = false;
                 grvLate.Columns[1].Visible = false;
                 //}
                 //else
                 //{
                 //    grvLate.Columns[0].Visible = true;
                 //    grvLate.Columns[1].Visible = true;
                 //}
             }
             else
             {

                 Response.Redirect("~\\index.aspx", false);
             }
         }
         catch (Exception)
         {


         }
     }

     protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
     {
         string Day_Date = e.Day.Date.ToShortDateString();
         if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
         {
             e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F14c57");
             e.Cell.ToolTip = "Holiday";
            // return;
         }
         try
         {
             if (((DataSet)Session["Table"] != null))
             {
                 foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                 {
                     string scheduledDate = Convert.ToDateTime(dr["LoginDateTime"]).ToShortDateString();
                     string scheduled_LoginTime = Convert.ToString(dr["Login"]);
                     string scheduled_LogoutTime = dr["LogoutDateTime"].ToString();
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
                         Month = e.Day.Date.Month;
                         Year = e.Day.Date.Year;
                     }
                     if (scheduledDate.Equals(Day_Date))
                     {
                       

                         LinkButton lb = new LinkButton();
                         LiteralControl lc = new LiteralControl();
                         LiteralControl lc1 = new LiteralControl();
                         LiteralControl lc2 = new LiteralControl();

                         string status = Convert.ToString(dr["Present_Status"]);
                       
                         if (status == "Late")
                         {
                             lc.Text = @"<br/>" + "<font size=1 color=maroon>Late</font>" + "<br/>" + scheduled_LoginTime;
                             //e.Cell.Controls.Add(lc);
                             e.Cell.ToolTip = "Late" + Environment.NewLine + Convert.ToDateTime(scheduled_LoginTime).ToString("hh:mm tt");
                             e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#6699FF");

                         }
                         //else if (status == "Absent")
                         //{
                         //    lc1.Text = @"<br/>" + "<font size=1 color=black>Absent</font>";
                         //    e.Cell.Controls.Add(lc1);
                         //    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DC143C");

                         //}
                         //else if (status == "Leave Approving")
                         //{
                         //    lc2.Text = @"<br/>" + "<font size=1 color=black> Leave Approving </font>" + "<br/>" + scheduled_LoginTime;
                         //    e.Cell.Controls.Add(lc2);
                         //    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#9905af");
                         //}

                     }
                     else
                     {

                        // e.Cell.Controls.Add(lc1);
                            // e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DC143C");
                     }

                 }
             }
             FillGrid();
         }
         catch 
         {

         }
     }
     private object createDataTable()
     {
         try
         {

             if (Session["UserType_id"].ToString() == "1" || Session["UserType_id"].ToString() == "2")
             {
                 strQry = "exec usp_getAttendance @type='getLateAtt',@intUserType_id='" + Convert.ToString(Session["UserType_id"]) + "',@intUser_id='" + Convert.ToString(Session["UserId"]) + "',@month='" + Convert.ToString(Month) + "',@year='" + Convert.ToString(Year) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "'";
                 dsObj = sGetDataset(strQry);
             }
             else // if (Session["UserType_id"] == "3")
             {
                 strQry = "exec usp_getAttendance @type='getTeacherLateAtt',@intUserType_id='" + Convert.ToString(Session["UserType_id"]) + "',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@month='" + Convert.ToString(Month) + "',@year='" + Convert.ToString(Year) + "'";
                 dsObj = sGetDataset(strQry);
             }


            
             Session["Attend"] = dsObj;
             return dsObj;
         }
         catch
         {
             return dsObj;
         }
     }
     protected void grvLate_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         grvLate.PageIndex = e.NewPageIndex + 1;
         grvLate.DataBind();
         FillGrid();
     }
     protected void lnkPrevious_Click(object sender, EventArgs e)
     {
         try
         {
             if (ddlMonth1.SelectedValue != "1")
             {
                 ddlMonth1.SelectedValue = Convert.ToString((Convert.ToInt32(ddlMonth1.SelectedValue) - 1));
                 ddlMonth1_SelectedIndexChanged(null, null);
             }
             else
             {
                 
                 if (Calendar1.VisibleDate.Year != 001)
                 {
                     Year = Calendar1.VisibleDate.Year-1;
                 }
                 else
                 {
                     Year = DateTime.Now.Year;
                 }
                 FillGrid();
                 ddlMonth1.SelectedValue = Convert.ToString(12);
                 Month = Convert.ToInt32(ddlMonth1.SelectedValue);
                 Calendar1.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
                 GetData();
             }
         }
         catch
         {

         }
     }
     protected void ddlMonth1_SelectedIndexChanged(object sender, EventArgs e)
     {
         try
         {
             Month = Convert.ToInt32(ddlMonth1.SelectedValue);
             if (Calendar1.VisibleDate.Year != 001)
             {
                 Year = Calendar1.VisibleDate.Year;
             }
             else
             {
                 Year = DateTime.Now.Year;
             }
             FillGrid();
             GetData();
             Calendar1.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
            

         }
         catch
         {

         }
     }
     protected void lnkNext_Click(object sender, EventArgs e)
     {
         try
         {
             if (ddlMonth1.SelectedValue != "12")
             {
                 ddlMonth1.SelectedValue = Convert.ToString((Convert.ToInt32(ddlMonth1.SelectedValue) + 1));
                 ddlMonth1_SelectedIndexChanged(null, null);
             }
             else
             {
                 ddlMonth1.SelectedValue = Convert.ToString(1);
                 if (Calendar1.VisibleDate.Year != 001)
                 {
                     Year = Calendar1.VisibleDate.Year + 1;
                 }
                 else
                 {
                     Year = DateTime.Now.Year;
                 }
                 Month = 1;
                 FillGrid();

                 Calendar1.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
                 GetData();
             }
         }
         catch
         {
         }
     }



     protected void ImgXls_Click(object sender, ImageClickEventArgs e)
     {
         try
         {

             //switch (TabContainer1.ActiveTabIndex)
             //{
             //    case 1:
             //        ExportGrid(grvLate, "LateReport " + DateTime.Now + ".xls", "application/vnd.ms-excel");
             //        break;
             //}

             ClsExportExcel exp = new ClsExportExcel();
             switch (TabContainer1.ActiveTabIndex)
             {
                 case 1:
                     //  ExportGridToPDF(grvAttendance, "Attendance " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                     exp.ExportGrid(grvLate, ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), 0, "", "", "", "1", ddlMonth1.SelectedItem.Text + " Month Attendance");

                     strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["UserType_Id"] + "',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";

                     break;
             }

         }
         catch
         {

         }
     }
     protected void ImgPdf_Click(object sender, ImageClickEventArgs e)
     {
         try
         {

             //switch (TabContainer1.ActiveTabIndex)
             //{
             //    case 1:
             //        ExportGridToPDF(grvLate, "LateReport " + DateTime.Now + ".pdf", "application/pdf");
             //        break;
             //}

             ClsExportPdf pdf = new ClsExportPdf();
             switch (TabContainer1.ActiveTabIndex)
             {
                 case 1:
                     //  ExportGridToPDF(grvAttendance, "Attendance " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                     pdf.Page_Load(null, null, grvLate, ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), 0, "", "", "", "1", ddlMonth1.SelectedItem.Text + " Month Attendance");

                     strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["UserType_Id"] + "',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";

                     break;
             }

         }
         catch
         {

         }
     }
}

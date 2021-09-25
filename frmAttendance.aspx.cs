using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Text;
using iTextSharp;
using System.Threading;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;

public partial class frmAttendance : DBUtility
{
    string strQry = "";
    int Year,Month,RollNo;
    string StudentName, STD, DIV;
    int Present = 0, Absent = 0, Late = 0, Leave = 0, Tot = 0, TotDay = 0;
    DataSet dsObj = new DataSet();
    SqlDataAdapter daObj = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        //ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        ////scriptManager.RegisterPostBackControl();
        //for (int i = 0; i < TabContainer1.Tabs[2].Controls.Count; i++)
        //{
        //    string str = TabContainer1.Tabs[2].Controls[i].UniqueID;

        //}


        Session["School_id"] = "1";
        Session["UserType_id"] = "3";
        Session["User_id"] = "1";
        Session["Student_id"] = "0";
        Session["Standard_id"] = "5";
        Session["Division_id"] = "40";
        try
        {
            if (Session["UserType_id"] != null && Session["User_Id"] != null || Session["Student_id"] != null)
                {

                    //Label lblTile = new Label();
                    //lblTile = (Label)Page.Master.FindControl("lblPageTitle");
                    //lblTile.Visible = true;
                    //lblTile.Text = "Month-Wise Attendance Details";

                    if (!IsPostBack)
                    {
                    
                    GetData();
                    ddlMonth.SelectedValue = Convert.ToString(DateTime.Now.Month);
                    ddlMonth_SelectedIndexChanged(null, null);
                    FillYear();
                    ddlYear1.SelectedValue = Convert.ToString(DateTime.Now.Year);
                    ddlYear2.SelectedValue = Convert.ToString(DateTime.Now.Year);
                    FillSummeryAttendatce();
                    FillTopAtt();
                    if (Convert.ToString(Session["UserType_id"]) == "5" || Convert.ToString(Session["UserType_id"]) == "4" || Convert.ToString(Session["UserType_id"]) == "3" || Convert.ToString(Session["UserType_id"]) == "6")
                    {
                        TabContainer1.Tabs[2].Visible = false;
                        TabContainer1.Tabs[3].Visible = false;
                    }
                    else
                    {
                        TabContainer1.Tabs[2].Visible = true;
                        TabContainer1.Tabs[3].Visible = true;
                    }
                   // FillGrid();
                    geturl();
                }
               
                
            }
                else
                {
                    Response.Redirect("~\\frmIndex.aspx", false);
                }
        }
        catch (Exception)
        {
            
          
        }
       
    }
    public void FillGrid()
    {
        try
        {
            grvAttendance.DataSource = createDataTable();
            grvAttendance.DataBind();
        }
        catch (Exception)
        {
            
           
        }
    }
    private DataSet GetData()
    {
        try
        {
            string startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("MM/dd/yyyy").Replace("-", "/");
            string endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(30).ToString("MM/dd/yyyy").Replace("-", "/");

            strQry = "exec usp_getAttendance @type='getCalenderAtt',@intUserType_id='" + Convert.ToString(Session["UserType_id"]) + "',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@FrmDt='" + startDate.Trim() + "',@EndDt='" + endDate.Trim() + "'";
            dsObj = sGetDataset(strQry);
            Session["Table"] = dsObj;
            return dsObj;
        }
        catch (Exception)
        {
            return dsObj;
        }
       

    }
    public void FillYear()
    {
        try
        {
            int count = ddlYear1.Items.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                
                ddlYear1.Items.Remove(ddlYear1.Items[i].Value);
                ddlYear2.Items.Remove(ddlYear2.Items[i].Value);
            }
            for (int i = 2005; i <= DateTime.Now.Year; i++)
            {
               
                ddlYear1.Items.Add(new System.Web.UI.WebControls.ListItem(i.ToString(), i.ToString()));
                ddlYear2.Items.Add(new System.Web.UI.WebControls.ListItem(i.ToString(), i.ToString()));
            }
        }
        catch
        {
            MessageBox("Problem Found");
        }
    }
    public void MessageBox(string msg)
    {
        try
        {
            string script = "alert(\"" + msg + "\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

        }
        catch (Exception)
        {
            // return msg;
        }
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        string Day_Date = e.Day.Date.ToShortDateString();

        if (e.Day.Date.Day.ToString() == "15")
        {
            ddlMonth.SelectedValue = Convert.ToString(e.Day.Date.Month);
            ddlMonth_SelectedIndexChanged(null, null);
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
                  
                    string scheduledDate = Convert.ToDateTime(dr["LoginDateTime"]).ToShortDateString();
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
                        Month = e.Day.Date.Month;
                        Year = e.Day.Date.Year;
                        ddlMonth.SelectedValue = Convert.ToString(Month);
                    }
                    if (scheduledDate.Equals(Day_Date))
                    {
                        
                        LinkButton lb = new LinkButton();
                        LiteralControl lc = new LiteralControl();
                        LiteralControl lc1 = new LiteralControl();
                        LiteralControl lc2 = new LiteralControl();

                        string status = Convert.ToString(dr["Present_Status"]);
                        if (status == "Early")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=blue>Early</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Early";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#006600");
                            
                        }
                        else if (status == "Present")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Present</font>" + "<br/>";
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Present</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Present";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Early Reported Web")//manual
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Early(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Early Reported Web";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Ontime Reported Web")//manual
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Ontime(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Ontime Reported Web";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Late Reported Web")//manual
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Late(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Late Reported Web";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Present(From Web)")//attandance Issue
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Ontime(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Present(From Web)";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Out Of Office")//out of office
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=Yellow>Out Of Office</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Out Of Office";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Ontime Reported")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Ontime</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Ontime Reported";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Late")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=maroon>Late</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Late";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#6699FF");

                        }
                        else if (status == "Absent")
                        {
                            //lc1.Text = @"<br/>" + "<font size=1 color=black>Absent</font>";
                            e.Cell.Controls.Add(lc1);
                            e.Cell.ToolTip = "Absent";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");

                        }
                        else if (status == "Leave")
                        {
                            //lc2.Text = @"<br/>" + "<font size=1 color=black> Leave Approving </font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc2);
                            e.Cell.ToolTip = "Leave";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6600");
                        }

                    }
                    else
                    {

                        //if (e.Day.Date<=DateTime.Now.Date)
                        //{
                        //    //lc1.Text = @"<br/>" + "<font size=1 color=black>Absent</font>";
                         
                        //    e.Cell.ToolTip = "Absent";
                        //    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");

                        //}
                    }

                }
               
            }
            FillGrid();

        }
        catch (Exception ex)
        {

        }

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        int Month = CalAttendance.VisibleDate.Month;
        FillGrid();
    }
    public object createDataTable()
    {
        try
        {
            strQry = "exec usp_getAttendance @type='getAtt',@intUserType_id='" + Convert.ToString(Session["UserType_id"]) + "',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@month='" + Convert.ToString(Month) + "',@year='" + Convert.ToString(Year) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            Session["Attend"] = dsObj;
            return dsObj;
        }
        catch 
        {
            return 0;
        }
    

    
    }
    protected void grvAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvAttendance.PageIndex = e.NewPageIndex ;
            grvAttendance.DataBind();
            FillGrid();
        }
        catch (Exception)
        {
            
        }
        
    }
    protected void lnkPrevious_Click(object sender, EventArgs e)
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
                if (CalAttendance.VisibleDate.Year != 001)
                {
                    Year = CalAttendance.VisibleDate.Year - 1;
                }
                else
                {
                    Year = DateTime.Now.Year;
                }
                FillGrid();
                Month = 12;
                CalAttendance.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
                GetData();
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
            if (CalAttendance.VisibleDate.Year != 001)
            {
                Year = CalAttendance.VisibleDate.Year;
            }
            else
            {
                Year = DateTime.Now.Year;
            }
            FillGrid();

            CalAttendance.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
            GetData();

        }
        catch
        {

        }
    }
    protected void lnkNext_Click(object sender, EventArgs e)
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
                if (CalAttendance.VisibleDate.Year != 001)
                {
                    Year = CalAttendance.VisibleDate.Year + 1;
                }
                else
                {
                    Year = DateTime.Now.Year;
                }
                FillGrid();
                Month = 1;
                CalAttendance.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
               // CalAttendance.VisibleDate = DateTime.ParseExact("" + ddlMonth.Text.Trim() + "/27/" + Year + "", "MM/dd/yyyy", CultureInfo.InvariantCulture);
                GetData();
            }
        }
        catch
        {
        }
    }
    protected void ddlYear1_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillSummeryAttendatce();
    }
 
    public void FillSummeryAttendatce()
    {
        try
        {            
            strQry = "";
            if (Convert.ToString(Session["UserType_Id"]) == "1" || Convert.ToString(Session["UserType_Id"]) == "2")
            {
                strQry = "exec usp_AttendanceSummery @type='StudentAttendance',@intStudent_Id='" + Session["Student_Id"] + "',@intSchool_Id='" + Session["School_Id"] + "',@Year='" + ddlYear1.SelectedValue + "'";
            }
            else
            {
                strQry = "exec usp_AttendanceSummery @type='StaffAttendance',@intUser_Id='" + Session["User_id"] + "',@intSchool_Id='" + Session["School_Id"] + "',@Year='" + ddlYear1.SelectedValue + "',@intUserType_Id='" + Convert.ToString(Session["UserType_Id"]) +"'";
            }
            dsObj = sGetDataset(strQry); 
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvSummery.DataSource = dsObj;
                grvSummery.DataBind();
                FillFooter();
                grvSummery.DataBind();
                
            }
            else
            {
                grvSummery.DataSource = dsObj;//null
                grvSummery.DataBind();
            }
            
        }
        catch
        {
            
        }
    }

         protected void ddlYear2_SelectedIndexChanged(object sender, EventArgs e)
         {
             try
             {
                 FillTopAtt();
             }
             catch
             {
                 
               
             }
         }
         public void FillTopAtt()
         {
             try
             {
                 strQry = "";
                 strQry = "exec [usp_AttendanceSummery] @type='Top5Student',@Div='" + Session["Division_id"] + "',@intSchool_Id='" + Session["School_id"] + "',@Year='" + ddlYear2.SelectedValue + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
                 dsObj = sGetDataset(strQry);
                 grvTopAtt.DataSource = dsObj;
                 grvTopAtt.DataBind();

                 if (Convert.ToString(Session["UserType_Id"]) == "1")
                 {
                     lblCount.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SelfCount"]);
                     lblNm.Text = "My Attendance ";
                 }
                 else if (Convert.ToString(Session["UserType_Id"]) == "2")
                 {
                     lblCount.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SelfCount"]);
                     lblNm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SelfName"]);
                 }
                 else
                 {
                     lblCount.Visible = false;
                     lblNm.Visible = false;
                  //   lblRank.Visible = false;
                 }
             }
             catch 
             {
                 
             }
         }

         protected void btnExport_Click(object sender, EventArgs e)
         {
         //    Session["Grid"] = grvSummery;
         //    btnExport.Attributes.Add("onclick", "window.open('frmExportData.aspx','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=500,width=500,top=80,left=200,fullscreen=no');return false");
         }
         private void ExportGrid(GridView grv,string fileName, string contentType)
         {
             // throw new NotImplementedException();

             Response.Clear();
             Response.Buffer = true;
             Response.AddHeader("content-disposition", "attachment;fileName=" + fileName);
             Response.Charset = "";
             Response.ContentType = contentType;

             StringWriter sw = new StringWriter();
             HtmlTextWriter hw = new HtmlTextWriter(sw);
             grv.RenderControl(hw);
             Response.Output.Write(sw.ToString());
             Response.Flush();
             Response.Close();
             Response.End();

         }
         private void ExportGridToPDF(GridView grv, string fileName, string contentType)
         {

             Response.ContentType = "application/pdf";
             Response.AddHeader("content-disposition", "attachment;fileName=" + fileName);
             Response.Cache.SetCacheability(HttpCacheability.NoCache);
             StringWriter sw = new StringWriter();
             HtmlTextWriter hw = new HtmlTextWriter(sw);
             grv.RenderControl(hw);
             StringReader sr = new StringReader(sw.ToString());
             Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
             HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
             PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
             pdfDoc.Open();
             htmlparser.Parse(sr);
             pdfDoc.Close();
             Response.Write(pdfDoc);
             Response.End();
             grv.AllowPaging = true;
             grv.DataBind();
         } 
         public override void VerifyRenderingInServerForm(Control control)
         {
             /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
                server control at run time. */
         }
         protected void CalAttendance_DayRender(object sender, DayRenderEventArgs e)
         {

         }
         protected void Button1_Click(object sender, EventArgs e)
         {
             switch (TabContainer1.ActiveTabIndex)
	            {
                 case  1:
                      ExportGrid(grvAttendance,"Attendance "+ DateTime.Now +".xls", "application/vnd.ms-excel");
                      break;
                 case 2:
                      ExportGrid(grvSummery, "AttendanceSummary " + DateTime.Now + ".xls", "application/vnd.ms-excel");
                      break;

                 case 3:
                      ExportGrid(grvTopAtt, "Top5Attendance " + DateTime.Now + ".xls", "application/vnd.ms-excel");
                      break;

	            }

            
         }
         protected void ImgPdf_Click(object sender, ImageClickEventArgs e)
         {

             ClsExportPdf exp = new ClsExportPdf();

             // exp.ExportGrid(grvAttendance, "FileName" + DateTime.Now, Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", "Att");
             if (Convert.ToString(Session["UserType_id"]) == "1" || Convert.ToString(Session["UserType_id"]) == "1")
             {
                 strQry = "exec [usp_ReportDetails] @type='StudentDetails',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intSchoolId='" + Convert.ToString(Session["School_id"]) + "'";
                 dsObj = sGetDataset(strQry);
                 StudentName = string.Empty;
                 STD = string.Empty;
                 DIV = string.Empty;
                 StudentName = Convert.ToString(dsObj.Tables[0].Rows[0]["Name"]);
                 STD = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStandard_name"]);
                 DIV = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
                 RollNo = Convert.ToInt32(dsObj.Tables[0].Rows[0]["RollNo"]);
             }
             else
             {
                 strQry = "exec [usp_ReportDetails] @type='TeacherDetails',@intUserid='" + Convert.ToString(Session["User_id"]) + "',@intUserType='" + Convert.ToString(Session["UserType_id"]) + "'";
                 dsObj = sGetDataset(strQry);
                 StudentName = string.Empty;
                 STD = string.Empty;
                 DIV = string.Empty;
                 StudentName = Convert.ToString(dsObj.Tables[0].Rows[0]["Name"]);
                 STD = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDepartment_name"]);
                 DIV = string.Empty;
                 RollNo = Convert.ToInt32(dsObj.Tables[0].Rows[0]["intTeacher_id"]);
             }


             switch (TabContainer1.ActiveTabIndex)
             {
                 case 1:
                     //  ExportGridToPDF(grvAttendance, "Attendance " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                     exp.Page_Load(null, null, grvAttendance, ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), RollNo, StudentName, STD, DIV, Convert.ToString(Session["UserType_id"]), ddlMonth.SelectedItem.Text + " Month Attendance");

                     strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["UserType_Id"] + "',@vchReportFormat='Pdf',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";

                     break;
                 case 2:
                     //   ExportGrid(grdattendance, "AttendanceDetails " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                     exp.Page_Load(null, null, grvSummery, "" + " " + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), RollNo, StudentName, STD, DIV, Convert.ToString(Session["UserType_id"]), "Year " + ddlYear1.SelectedItem.Text + "  Attendance");

                     strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_Id"] + "',@intUserType='" + Session["User_Type"] + "',@vchReportFormat='Pdf',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                     break;

                 case 3:
                     //   ExportGrid(grdattendance, "AttendanceDetails " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                     exp.Page_Load(null, null, grvTopAtt, "" + " " + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), RollNo, StudentName, STD, DIV, Convert.ToString(Session["UserType_id"]), "Top 5 Attendance");

                     strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["User_Type"] + "',@vchReportFormat='Pdf',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                     break;
             }
             sExecuteQuery(strQry);

             //switch (TabContainer1.ActiveTabIndex)
             //{
             //    case 1:
             //        ExportGridToPDF(grvAttendance, "Attendance " + DateTime.Now + ".pdf", "application/pdf");
             //        break;
             //    case 2:
             //        ExportGridToPDF(grvSummery, "AttendanceSummary " + DateTime.Now + ".pdf", "application/pdf");
             //        break;

             //    case 3:
             //        ExportGridToPDF(grvTopAtt, "Top5Attendance " + DateTime.Now + ".pdf", "application/pdf");
             //        break;

             //}
         }
         protected void ImgXls_Click(object sender, ImageClickEventArgs e)
         {
             try
             {
                  ClsExportExcel exp = new ClsExportExcel();

           // exp.ExportGrid(grvAttendance, "FileName" + DateTime.Now, Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", "Att");
                  if (Convert.ToString(Session["UserType_id"]) == "1" || Convert.ToString(Session["UserType_id"]) == "1")
                  {
                      strQry = "exec [usp_ReportDetails] @type='StudentDetails',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intSchoolId='" + Convert.ToString(Session["School_id"]) + "'";
                      dsObj = sGetDataset(strQry);
                      StudentName = string.Empty;
                      STD = string.Empty;
                      DIV = string.Empty;
                      StudentName = Convert.ToString(dsObj.Tables[0].Rows[0]["Name"]);
                      STD = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStandard_name"]);
                      DIV = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
                      RollNo = Convert.ToInt32(dsObj.Tables[0].Rows[0]["RollNo"]);
                  }
                  else
                  {
                      strQry = "exec [usp_ReportDetails] @type='TeacherDetails',@intUserid='" + Convert.ToString(Session["User_id"]) + "',@intUserType='" + Convert.ToString(Session["UserType_id"]) + "'";
                      dsObj = sGetDataset(strQry);
                      StudentName = string.Empty;
                      STD = string.Empty;
                      DIV = string.Empty;
                      StudentName = Convert.ToString(dsObj.Tables[0].Rows[0]["Name"]);
                      STD = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDepartment_name"]);
                      DIV = string.Empty;
                      RollNo = Convert.ToInt32(dsObj.Tables[0].Rows[0]["intTeacher_id"]);
                  }

                  switch (TabContainer1.ActiveTabIndex)
                  {
                      case 1:
                          //  ExportGridToPDF(grvAttendance, "Attendance " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                          exp.ExportGrid(grvAttendance, ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), RollNo, StudentName, STD, DIV, Convert.ToString(Session["UserType_id"]), ddlMonth.SelectedItem.Text + " Month Attendance");

                          strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["UserType_Id"] + "',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";

                          break;
                      case 2:
                          //   ExportGrid(grdattendance, "AttendanceDetails " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                          exp.ExportGrid(grvSummery, "" + " " + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), RollNo, StudentName, STD, DIV, Convert.ToString(Session["UserType_id"]), "Year " + ddlMonth.SelectedItem.Text + " Attendance");

                          strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_Id"] + "',@intUserType='" + Session["User_Type"] + "',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                          break;

                      case 3:
                          //   ExportGrid(grdattendance, "AttendanceDetails " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                          exp.ExportGrid(grvTopAtt, "" + " " + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), RollNo, StudentName, STD, DIV, Convert.ToString(Session["UserType_id"]), "Top 5 Attendance");

                          strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["User_Type"] + "',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                          break;
                  }
                  sExecuteQuery(strQry);
                 //switch (TabContainer1.ActiveTabIndex)
                 //{
                 //    case 1:
                 //        ExportGrid(grvAttendance, "Attendance " + DateTime.Now + ".xls", "application/vnd.ms-excel");
                 //        break;
                 //    case 2:
                 //        ExportGrid(grvSummery, "AttendanceSummary " + DateTime.Now + ".xls", "application/vnd.ms-excel");
                 //        break;

                 //    case 3:
                 //        ExportGrid(grvTopAtt, "Top5Attendance " + DateTime.Now + ".xls", "application/vnd.ms-excel");
                 //        break;

                 //}

             }
             catch 
             {
                 
             }
         }

         public void FillFooter()
         {
             try
             {
                 int i = 0;
                  for (int j = 0; j < grvSummery.Rows.Count; j++)
                          {
                              for (int k = 1; k < grvSummery.Columns.Count; k++)
                              {
                              i = Convert.ToInt32(grvSummery.Rows[j].Cells[k].Text);

                              if (grvSummery.Columns[k].HeaderText == "Present")
                              {
                                  Present += i;
                                  grvSummery.Columns[k].FooterText = Present.ToString();
                              }
                              else if (grvSummery.Columns[k].HeaderText == "Absent")
                              {
                                  Absent += i;
                                  grvSummery.Columns[k].FooterText = Absent.ToString();
                              }
                              else if (grvSummery.Columns[k].HeaderText == "Leave")
                              {
                                  Leave += i;
                                  grvSummery.Columns[k].FooterText = Leave.ToString();
                              }
                              else if (grvSummery.Columns[k].HeaderText == "Total")
                              {
                                  Tot += i;
                                  grvSummery.Columns[k].FooterText = Tot.ToString();
                              }
                              else if (grvSummery.Columns[k].HeaderText == "Late")
                              {
                                  Late += i;
                                  grvSummery.Columns[k].FooterText = Late.ToString();
                              }
                              else if (grvSummery.Columns[k].HeaderText == "Total Days")
                              {
                                  TotDay += i;
                                  grvSummery.Columns[k].FooterText = TotDay.ToString();
                              }
                          }
                       }
             }
             catch (Exception)
             {
                 
             }
         }
         protected void ImgDoc_Click(object sender, ImageClickEventArgs e)
         {
             try
             {
                 switch (TabContainer1.ActiveTabIndex)
                 {
                     case 1:
                         ExportToWord(grvAttendance, "Attendance " + DateTime.Now + ".doc");
                         break;
                     case 2:
                         ExportToWord(grvSummery, "AttendanceSummary " + DateTime.Now + ".doc");
                         break;

                     case 3:
                         ExportToWord(grvTopAtt, "Top5Attendance " + DateTime.Now + ".doc");
                         break;

                 }

             }
             catch
             {

             }
         }
         protected void grvSummery_RowDataBound(object sender, GridViewRowEventArgs e)
         {
             try
             {
                 int i=0;

                 if (e.Row.RowType == DataControlRowType.DataRow)
                 {
                     int count = grvSummery.Rows.Count + 1;
                    

                     
                 }//
             }
             catch 
             {
                 
             }
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
                     if (CalAttendance.VisibleDate.Year != 001)
                     {
                         Year = CalAttendance.VisibleDate.Year + 1;
                     }
                     else
                     {
                         Year = DateTime.Now.Year;
                     }
                     FillGrid();
                     Month = 1;
                     CalAttendance.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
                     // CalAttendance.VisibleDate = DateTime.ParseExact("" + ddlMonth.Text.Trim() + "/27/" + Year + "", "MM/dd/yyyy", CultureInfo.InvariantCulture);
                     GetData();
                 }
             }
             catch
             {
             }
         }
       
}

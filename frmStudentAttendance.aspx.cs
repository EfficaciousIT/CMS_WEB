using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.UI;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmStudentAttendance : DBUtility
{
    int Year=DateTime.Now.Year;
    int Month=DateTime.Now.Month;
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Tabular123.Visible = false;

        if (Session["UserType_id"] != null && Session["User_id"] != null || Session["Student_id"] != null)
        {            
            if (!IsPostBack)
            {
                ImgPdf.Visible = false;
                //ImgDoc.Visible = false;
               // ImgXls.Visible = false;
                GetData();
                FillSTD();
                ddlMonth1.SelectedValue = Convert.ToString(DateTime.Now.Month);
                ddlMonth1_SelectedIndexChanged(null, null);
                TabContainer1.Visible = false;
                ddlMonths.SelectedValue = Convert.ToString(DateTime.Now.Month);
                FillStudentsAttendance();
                FillStatus();
                Teacher_Students();
                FillAllAttendace();
                geturl();
                
            }
        }
        else
        {
            Response.Redirect("Index.aspx", false);
        }        
    }
    public DataSet GetData()
    {
        try
        {
            if (ddlStudent.SelectedValue != "")
            {
                strQry = "exec usp_getAttendance @type='getStudentCalenderAtt',@intStudentId=" + Convert.ToString(ddlStudent.SelectedValue) + ",@intSchool_id='" + Session["School_id"] + "'";
                dsObj = sGetDataset(strQry);
                Session["Table"] = dsObj;
                
            }
            return dsObj;
        }
        catch (Exception)
        {
            return dsObj;
        }


    }
    protected void Linkbtndepositamt_Click(object sender, EventArgs e)
    {
    }
    public void FillSTD()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "3")
            {
                strQry = "exec [usp_getAttendance] @type='FillStd',@TeacherId='" + Convert.ToString(Session["User_id"]) + "',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
                FillDIV();
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
                FillDIV();
            }
            
        }
        catch
        {

        }
    }
    public void FillDIV()
    {
        try
        {
            strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlDIV, strQry, "vchDivisionName", "intDivision_id");
            FillStudent();
        }
        catch
        {

        }
    }
    public void Teacher_Students()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "3")
            {

                strQry = "exec usp_TimeTable @type='GetSTD_DIV',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intTeacher_id='" + Convert.ToString(Session["User_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    ddlSTD.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
                    // ddlSTD_SelectedIndexChanged(null, null);
                    FillDIV();
                    ddlDIV.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                    ddlSTD.Enabled = false;
                    ddlDIV.Enabled = false;
                    FillStudent();
                }
            }
        }
        catch 
        {
            
        }
    }
    public void FillStudent()
    {
        try
        {

            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

            sBindDropDownList(ddlStudent, strQry, "Name", "intStudent_id");

            if (ddlStudent.Items.Count > 1)
                ddlStudent.Items.Add(new ListItem("All", "-1"));
            else
                ddlStudent.DataSource = null;
        }
        catch
        {

        }
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDIV();
    }
    protected void ddlDIV_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStudent();
    }


    public void FillYear()
    {
        try
        {
            int count=ddlYear.Items.Count;
            for (int i = count-1; i >= 0 ; i--)
            {
                ddlYear.Items.Remove(ddlYear.Items[i].Value);
                ddlYear1.Items.Remove(ddlYear1.Items[i].Value);
                ddlYear2.Items.Remove(ddlYear2.Items[i].Value);
            }
            for (int i = 2015; i <= DateTime.Now.Year; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                ddlYear1.Items.Add(new ListItem(i.ToString(), i.ToString()));
                ddlYear2.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        catch 
        {
            
        }
    }

    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {       
        if (ddlStudent.SelectedValue != "-1" && ddlStudent.SelectedValue != "0")
        {
            TabContainer1.Visible = true;
            TabContainer1.Tabs[0].Enabled = true;
            TabContainer1.Tabs[1].Enabled = true;
            TabContainer1.Tabs[2].Enabled = true;
            TabContainer1.Tabs[3].Enabled = false;
            TabContainer1.Tabs[4].Enabled = true;
            FillGrid();
            GetData();
        
            FillYear();
            ddlYear.SelectedValue = Convert.ToString(DateTime.Now.Year);
            ddlYear1.SelectedValue = Convert.ToString(DateTime.Now.Year);
            ddlYear2.SelectedValue = Convert.ToString(DateTime.Now.Year);
            ddlMonth.SelectedValue = Convert.ToString(DateTime.Now.Month);
            FillAllAttendace();
            FillSummeryAttendatce(); 
        }
        else if (ddlStudent.SelectedValue == "-1")
        {
            TabContainer1.Visible = true;

            TabContainer1.Tabs[0].Enabled = false;
             TabContainer1.Tabs[1].Enabled = true;
            TabContainer1.Tabs[3].Enabled = true;
            TabContainer1.Tabs[2].Enabled = false;
            TabContainer1.Tabs[4].Enabled = true;
            
            FillYear();
            ddlYear.SelectedValue = Convert.ToString(DateTime.Now.Year);
            ddlYear1.SelectedValue = Convert.ToString(DateTime.Now.Year);
            ddlYear2.SelectedValue = Convert.ToString(DateTime.Now.Year);
            ddlMonth.SelectedValue = Convert.ToString(DateTime.Now.Month);
            FillAllAttendace();
            FillStudentsAttendance();
        }
        else
        {
            TabContainer1.Visible = false;
        }
        Tabular123.Enabled = true;
        //Tabular123.Visible = false;
    }
    protected void CalAttendance_DayRender(object sender, DayRenderEventArgs e)
    {
        string Day_Date = e.Day.Date.ToShortDateString();

        if (e.Day.Date.Day.ToString() == "15")
        {
            ddlMonth1.SelectedValue = Convert.ToString(e.Day.Date.Month);
            ddlMonth1_SelectedIndexChanged(null, null);
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
                        Month = e.Day.Date.Month;
                        Year = e.Day.Date.Year;
                        ddlMonth1.SelectedValue = Convert.ToString(Month);
                    }
                    //if (str.Length > 0)
                    //{
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
                        else if (status == "Leave")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Present</font>" + "<br/>";
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Present</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Leave";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6600");

                        }
                        else if (status == "Leave")//manual
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Early(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Leave";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BCC20");

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
                            e.Cell.ToolTip = "Leave Approving";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#9905af");
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
                      
                        if ((e.Day.Date <= DateTime.Now.Date) &&  (e.Cell.BackColor == System.Drawing.ColorTranslator.FromHtml("#FFFFFF")))
                        {
                            // e.Cell.Controls.Add(lc1);
                            e.Cell.ToolTip = "Absent";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                           
                        }
                     //   break;
                    }

                }

            }
            FillGrid();

        }
        catch (Exception ex)
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
    private object createDataTable()
    {
        try
        {

            strQry = "exec usp_getAttendance @type='StudentsAttendance',@intStudentId='" + Convert.ToString(ddlStudent.SelectedValue) + "',@month='" + Month + "',@year='" + Year + "',@intSchool_id='" + Session["School_id"] + "'";

            dsObj = sGetDataset(strQry);
            Session["Attend"] = dsObj;
            return dsObj;
        }
        catch
        {
            return 0;
        }



    }
    public void FillAllAttendace()
    {
        try 
	    {	
            
		    strQry = "";
            if (ddlStudent.SelectedValue == "-1")
            {
                strQry = "exec [usp_getAttendance]  @type='AllStudentAttendance' ,@year='" + Convert.ToString(ddlYear.SelectedValue) + "',@month='" + Convert.ToString(ddlMonth.SelectedValue) + "',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@DivId='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            }
            else
            {
                strQry = "exec [usp_getAttendance]  @type='AllStudentAttendance' ,@year='" + Convert.ToString(ddlYear.SelectedValue) + "',@month='" + Convert.ToString(ddlMonth.SelectedValue) + "',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@DivId='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                strQry = strQry + ",@intStudentid='" + Convert.ToString(ddlStudent.SelectedValue) + "'";
            }

            dsObj = new DataSet();
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grdattendance.DataSource = dsObj;
                grdattendance.DataBind();
            }
            else
            {
                grdattendance.DataSource = null;
                grdattendance.DataBind();
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
            FillAllAttendace();
        //    CalFrmDate.SelectedDate = Convert.ToDateTime("01/"+ddlMonth.SelectedValue+ "/"+ ddlYear.SelectedValue);
           // CalToDate.SelectedDate = Convert.ToDateTime("01/" + ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue);
        }
        catch 
        {
            
         
        }
    }
    protected void grdattendance_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (ddlMonth.SelectedValue == "1" || ddlMonth.SelectedValue == "3" || ddlMonth.SelectedValue == "5" || ddlMonth.SelectedValue == "7" || ddlMonth.SelectedValue == "8" || ddlMonth.SelectedValue == "10" || ddlMonth.SelectedValue == "12")
            {
                //grdattendance.Columns[32].Visible = false;
                grdattendance.Columns[31].Visible = true;
                grdattendance.Columns[30].Visible = true;
                grdattendance.Columns[29].Visible = true;
            }
            else if (ddlMonth.SelectedValue == "4" || ddlMonth.SelectedValue == "6" || ddlMonth.SelectedValue == "9" || ddlMonth.SelectedValue == "11")
            {
                grdattendance.Columns[31].Visible = false;
                grdattendance.Columns[30].Visible = true;
                grdattendance.Columns[29].Visible = true;
            }
            else if (ddlMonth.SelectedValue == "2")
            {
                try
                {
                    DateTime dayDate = Convert.ToDateTime("29/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                    grdattendance.Columns[31].Visible = false;
                    grdattendance.Columns[30].Visible = false;
                }
                catch 
                {
                    grdattendance.Columns[29].Visible = false;
                    grdattendance.Columns[31].Visible = false;
                    grdattendance.Columns[30].Visible = false;
                }
               
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkbtn01 = (LinkButton)e.Row.FindControl("lnkbtn01");


                if (lnkbtn01.Text == "A")
                {
                    lnkbtn01.Text = "A";
                    lnkbtn01.ForeColor = System.Drawing.Color.Red;
                    lnkbtn01.ToolTip = "Absent";

                    DateTime dayDate = Convert.ToDateTime("01/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim() + "");

                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn01.Text = "H";
                        lnkbtn01.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn01.ToolTip = "Sunday";
                    }

                }
                else if (lnkbtn01.Text == "P")
                {

                    lnkbtn01.ForeColor = System.Drawing.Color.Green;
                    lnkbtn01.ToolTip = "Present";

                }
                else
                {
                    if (lnkbtn01.Text == "L")
                    {
                        lnkbtn01.ForeColor = System.Drawing.Color.DarkGreen;
                        lnkbtn01.ToolTip = "Late";
                    }
                }
                LinkButton lnkbtn02 = (LinkButton)e.Row.FindControl("lnkbtn02");
                if (lnkbtn02.Text == "A")
                {
                    lnkbtn02.Text = "A";
                    lnkbtn02.ForeColor = System.Drawing.Color.Red;
                    lnkbtn02.ToolTip = "Absent";

                    DateTime dayDate = Convert.ToDateTime("02/" + ddlMonth.Text.Trim() +"/"+ ddlYear.Text.Trim() + "");

                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn02.Text = "H";
                        lnkbtn02.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn02.ToolTip = "Sunday";
                    }

                }
                else if (lnkbtn02.Text == "P")
                {

                    lnkbtn02.ForeColor = System.Drawing.Color.Green;
                    lnkbtn02.ToolTip = "Present";

                }
                else
                {
                    if (lnkbtn02.Text == "L")
                    {
                        lnkbtn02.ForeColor = System.Drawing.Color.DarkGreen;
                        lnkbtn02.ToolTip = "Late";
                    }
                }
                LinkButton lnkbtn03 = (LinkButton)e.Row.FindControl("lnkbtn03");
                if (lnkbtn03.Text == "A")
                {
                    lnkbtn03.Text = "A";
                    lnkbtn03.ForeColor = System.Drawing.Color.Red;
                    lnkbtn03.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("03/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim() + "");

                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn03.Text = "H";
                        lnkbtn03.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn03.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn03.Text == "P")
                {

                    lnkbtn03.ForeColor = System.Drawing.Color.Green;
                    lnkbtn03.ToolTip = "Present";

                }
                else
                {
                    if (lnkbtn03.Text == "L")
                    {
                        lnkbtn03.ForeColor = System.Drawing.Color.DarkGreen;
                        lnkbtn03.ToolTip = "Late";
                    }
                }
                LinkButton lnkbtn04 = (LinkButton)e.Row.FindControl("lnkbtn04");
                if (lnkbtn04.Text == "A")
                {
                    lnkbtn04.Text = "A";
                    lnkbtn04.ForeColor = System.Drawing.Color.Red;
                    lnkbtn04.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("04/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim() + "");

                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn04.Text = "H";
                        lnkbtn04.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn04.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn04.Text == "P")
                {

                    lnkbtn04.ForeColor = System.Drawing.Color.Green;
                    lnkbtn04.ToolTip = "Present";

                }
                else
                {
                    if (lnkbtn04.Text == "L")
                    {
                        lnkbtn04.ForeColor = System.Drawing.Color.DarkGreen;
                        lnkbtn04.ToolTip = "Late";
                    }
                }
                LinkButton lnkbtn05 = (LinkButton)e.Row.FindControl("lnkbtn05");
                if (lnkbtn05.Text == "A")
                {
                    lnkbtn05.Text = "A";
                    lnkbtn05.ForeColor = System.Drawing.Color.Red;
                    lnkbtn05.ToolTip = "Sunday";
                    DateTime dayDate = Convert.ToDateTime( "05/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim() + "");

                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn05.Text = "H";
                        lnkbtn05.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn05.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn05.Text == "P")
                {
                    if (lnkbtn05.Text == "P")
                    {
                        lnkbtn05.ForeColor = System.Drawing.Color.Green;
                        lnkbtn05.ToolTip = "Present";
                    }
                }
                else
                {

                    lnkbtn05.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn05.ToolTip = "Late";

                }
                LinkButton lnkbtn06 = (LinkButton)e.Row.FindControl("lnkbtn06");
                if (lnkbtn06.Text == "A")
                {
                    lnkbtn06.Text = "A";
                    lnkbtn06.ForeColor = System.Drawing.Color.Red;
                    lnkbtn06.ToolTip = "Absent";

                    DateTime dayDate = Convert.ToDateTime( "06/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim() + "");

                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn06.Text = "H";
                        lnkbtn06.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn06.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn06.Text == "P")
                {
                    if (lnkbtn06.Text == "P")
                    {
                        lnkbtn06.ForeColor = System.Drawing.Color.Green;
                        lnkbtn06.ToolTip = "Present";
                    }
                }
                else
                {
                    if (lnkbtn06.Text == "L")
                    {
                        lnkbtn06.ForeColor = System.Drawing.Color.DarkGreen;
                        lnkbtn06.ToolTip = "Late";
                    }
                }
                LinkButton lnkbtn07 = (LinkButton)e.Row.FindControl("lnkbtn07");
                if (lnkbtn07.Text == "A")
                {
                    lnkbtn07.Text = "A";
                    lnkbtn07.ForeColor = System.Drawing.Color.Red;
                    lnkbtn07.ToolTip = "Present";
                    DateTime dayDate = Convert.ToDateTime("07/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim() + "");

                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn07.Text = "H";
                        lnkbtn07.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn07.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn07.Text == "P")
                {

                    lnkbtn07.ForeColor = System.Drawing.Color.Green;
                    lnkbtn07.ToolTip = "Present";

                }
                else
                {
                    if (lnkbtn07.Text == "L")
                    {
                        lnkbtn07.ForeColor = System.Drawing.Color.DarkGreen;
                        lnkbtn07.ToolTip = "Late";
                    }
                }
                LinkButton lnkbtn08 = (LinkButton)e.Row.FindControl("lnkbtn08");
                if (lnkbtn08.Text == "A")
                {
                    lnkbtn08.Text = "A";
                    lnkbtn08.ForeColor = System.Drawing.Color.Red;
                    lnkbtn08.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("08/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim() + "");

                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn08.Text = "H";
                        lnkbtn08.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn08.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn08.Text == "P")
                {

                    lnkbtn08.ForeColor = System.Drawing.Color.Green;
                    lnkbtn08.ToolTip = "Present";

                }
                else
                {
                    if (lnkbtn08.Text == "L")
                    {
                        lnkbtn08.ForeColor = System.Drawing.Color.DarkGreen;
                        lnkbtn08.ToolTip = "Late";
                    }
                }
                LinkButton lnkbtn09 = (LinkButton)e.Row.FindControl("lnkbtn09");
                if (lnkbtn09.Text == "A")
                {
                    lnkbtn09.Text = "A";
                    lnkbtn09.ForeColor = System.Drawing.Color.Red;
                    lnkbtn09.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("09/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim() + "");

                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn09.Text = "H";
                        lnkbtn09.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn09.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn09.Text == "P")
                {

                    lnkbtn09.ForeColor = System.Drawing.Color.Green;
                    lnkbtn09.ToolTip = "Present";

                }
                else
                {
                    if (lnkbtn09.Text == "L")
                    {
                        lnkbtn09.ForeColor = System.Drawing.Color.DarkGreen;
                        lnkbtn09.ToolTip = "Late";
                    }
                }
                LinkButton lnkbtn10 = (LinkButton)e.Row.FindControl("lnkbtn10");
                if (lnkbtn10.Text == "A")
                {
                    lnkbtn10.Text = "A";
                    lnkbtn10.ForeColor = System.Drawing.Color.Red;
                    DateTime dayDate = Convert.ToDateTime("10/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim() + "");
                    lnkbtn10.ToolTip = "Absent";
                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn10.Text = "H";
                        lnkbtn10.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn10.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn10.Text == "P")
                {

                    lnkbtn10.ForeColor = System.Drawing.Color.Green;
                    lnkbtn10.ToolTip = "Present";

                }
                else
                {
                    if (lnkbtn10.Text == "L")
                    {
                        lnkbtn10.ForeColor = System.Drawing.Color.DarkGreen;
                        lnkbtn10.ToolTip = "Late";
                    }
                }
                LinkButton lnkbtn11 = (LinkButton)e.Row.FindControl("lnkbtn11");
                if (lnkbtn11.Text == "A")
                {
                    lnkbtn11.Text = "A";
                    lnkbtn11.ForeColor = System.Drawing.Color.Red;
                    lnkbtn11.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("11/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim() + "");

                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn11.Text = "H";
                        lnkbtn11.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn11.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn11.Text == "P")
                {

                    lnkbtn11.ForeColor = System.Drawing.Color.Green;
                    lnkbtn11.ToolTip = "Present";

                }
                else
                {
                    if (lnkbtn11.Text == "L")
                    {
                        lnkbtn11.ForeColor = System.Drawing.Color.DarkGreen;
                        lnkbtn11.ToolTip = "Late";
                    }
                }
                LinkButton lnkbtn12 = (LinkButton)e.Row.FindControl("lnkbtn12");
                if (lnkbtn12.Text == "A")
                {
                    lnkbtn12.Text = "A";
                    lnkbtn12.ForeColor = System.Drawing.Color.Red;
                    DateTime dayDate = Convert.ToDateTime("12/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim() + "");
                    lnkbtn12.ToolTip = "Absent";
                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn12.Text = "H";
                        lnkbtn12.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn12.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn12.Text == "P")
                {

                    lnkbtn12.ForeColor = System.Drawing.Color.Green;
                    lnkbtn12.ToolTip = "Present";

                }
                else
                {
                    if (lnkbtn12.Text == "L")
                    {
                        lnkbtn12.ForeColor = System.Drawing.Color.DarkGreen;
                        lnkbtn12.ToolTip = "Late";
                    }
                }
                LinkButton lnkbtn13 = (LinkButton)e.Row.FindControl("lnkbtn13");
                if (lnkbtn13.Text == "A")
                {
                    lnkbtn13.Text = "A";
                    lnkbtn13.ForeColor = System.Drawing.Color.Red;
                    lnkbtn13.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("13/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim() + "");

                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn13.Text = "H";
                        lnkbtn13.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn13.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn13.Text == "P")
                {

                    lnkbtn13.ForeColor = System.Drawing.Color.Green;
                    lnkbtn13.ToolTip = "Present";

                }
                else
                {

                    lnkbtn13.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn13.ToolTip = "Late";

                }
                LinkButton lnkbtn14 = (LinkButton)e.Row.FindControl("lnkbtn14");
                if (lnkbtn14.Text == "A")
                {
                    lnkbtn14.Text = "A";
                    lnkbtn14.ForeColor = System.Drawing.Color.Red;
                    lnkbtn14.ToolTip = "Absent";
                   // DateTime dayDate = Convert.ToDateTime(Convert.ToDateTime("" + ddlMonth.Text.Trim() + "/14/" + ddlYear.Text.Trim() + "").ToString("MM/dd/yyyy"));
                    DateTime dayDate = Convert.ToDateTime("14/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());

                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn14.Text = "H";
                        lnkbtn14.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn14.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn14.Text == "P")
                {

                    lnkbtn14.ForeColor = System.Drawing.Color.Green;
                    lnkbtn14.ToolTip = "Present";
                }
                else
                {

                    lnkbtn14.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn14.ToolTip = "Late";

                }
                LinkButton lnkbtn15 = (LinkButton)e.Row.FindControl("lnkbtn15");
                if (lnkbtn15.Text == "A")
                {
                    lnkbtn15.Text = "A";
                    lnkbtn15.ForeColor = System.Drawing.Color.Red;
                    lnkbtn15.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("15/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim() );
                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn15.Text = "H";
                        lnkbtn15.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn15.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn15.Text == "P")
                {

                    lnkbtn15.ForeColor = System.Drawing.Color.Green;
                    lnkbtn15.ToolTip = "Present";
                }
                else
                {

                    lnkbtn15.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn15.ToolTip = "Late";

                }
                LinkButton lnkbtn16 = (LinkButton)e.Row.FindControl("lnkbtn16");
                if (lnkbtn16.Text == "A")
                {
                    lnkbtn16.Text = "A";
                    lnkbtn16.ForeColor = System.Drawing.Color.Red;
                    lnkbtn16.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("16/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn16.Text = "H";
                        lnkbtn16.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn16.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn16.Text == "P")
                {

                    lnkbtn16.ForeColor = System.Drawing.Color.Green;
                    lnkbtn16.ToolTip = "Present";
                }
                else
                {

                    lnkbtn16.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn16.ToolTip = "Late";

                }
                LinkButton lnkbtn17 = (LinkButton)e.Row.FindControl("lnkbtn17");
                if (lnkbtn17.Text == "A")
                {
                    lnkbtn17.Text = "A";
                    lnkbtn17.ForeColor = System.Drawing.Color.Red;
                    lnkbtn17.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("17/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn17.Text = "H";
                        lnkbtn17.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn17.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn17.Text == "P")
                {

                    lnkbtn17.ForeColor = System.Drawing.Color.Green;
                    lnkbtn17.ToolTip = "Present";
                }
                else
                {

                    lnkbtn17.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn17.ToolTip = "Late";

                }
                LinkButton lnkbtn18 = (LinkButton)e.Row.FindControl("lnkbtn18");
                if (lnkbtn18.Text == "A")
                {
                    lnkbtn18.Text = "A";
                    lnkbtn18.ForeColor = System.Drawing.Color.Red;
                    lnkbtn18.ToolTip = "Present";
                    DateTime dayDate = Convert.ToDateTime("18/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn18.Text = "H";
                        lnkbtn18.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn18.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn01.Text == "P")
                {

                    lnkbtn18.ForeColor = System.Drawing.Color.Green;
                    lnkbtn18.ToolTip = "Present";
                }
                else
                {

                    lnkbtn18.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn18.ToolTip = "Late";

                }
                LinkButton lnkbtn19 = (LinkButton)e.Row.FindControl("lnkbtn19");
                if (lnkbtn19.Text == "A")
                {
                    lnkbtn19.Text = "A";
                    lnkbtn19.ForeColor = System.Drawing.Color.Red;
                    lnkbtn19.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("19/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn19.Text = "H";
                        lnkbtn19.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn19.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn19.Text == "P")
                {

                    lnkbtn19.ForeColor = System.Drawing.Color.Green;
                    lnkbtn19.ToolTip = "Present";
                }
                else
                {

                    lnkbtn19.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn19.ToolTip = "Late";

                }
                LinkButton lnkbtn20 = (LinkButton)e.Row.FindControl("lnkbtn20");
                if (lnkbtn20.Text == "A")
                {
                    lnkbtn20.Text = "A";
                    lnkbtn20.ForeColor = System.Drawing.Color.Red;
                    lnkbtn20.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("20/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn20.Text = "H";
                        lnkbtn20.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn20.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn20.Text == "P")
                {

                    lnkbtn20.ForeColor = System.Drawing.Color.Green;
                    lnkbtn20.ToolTip = "Present";
                }
                else
                {

                    lnkbtn20.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn20.ToolTip = "Late";

                }
                LinkButton lnkbtn21 = (LinkButton)e.Row.FindControl("lnkbtn21");
                if (lnkbtn21.Text == "A")
                {
                    lnkbtn21.Text = "A";
                    lnkbtn21.ForeColor = System.Drawing.Color.Red;
                    lnkbtn21.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("21/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn21.Text = "H";
                        lnkbtn21.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn21.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn21.Text == "P")
                {

                    lnkbtn21.ForeColor = System.Drawing.Color.Green;
                    lnkbtn21.ToolTip = "Present";
                }
                else
                {

                    lnkbtn21.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn21.ToolTip = "Late";

                }
                LinkButton lnkbtn22 = (LinkButton)e.Row.FindControl("lnkbtn22");
                if (lnkbtn22.Text == "A")
                {
                    lnkbtn22.Text = "A";
                    lnkbtn22.ForeColor = System.Drawing.Color.Red;
                    lnkbtn22.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("22/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn22.Text = "H";
                        lnkbtn22.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn22.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn22.Text == "P")
                {

                    lnkbtn22.ForeColor = System.Drawing.Color.Green;
                    lnkbtn22.ToolTip = "Present";
                }
                else
                {

                    lnkbtn22.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn22.ToolTip = "Late";

                }
                LinkButton lnkbtn23 = (LinkButton)e.Row.FindControl("lnkbtn23");
                if (lnkbtn23.Text == "A")
                {
                    lnkbtn23.Text = "A";
                    lnkbtn23.ForeColor = System.Drawing.Color.Red;
                    lnkbtn23.ToolTip = "Absent";

                    DateTime dayDate = Convert.ToDateTime("23/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn23.Text = "H";
                        lnkbtn23.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn23.ToolTip = "Sunday";

                    }
                }
                else if (lnkbtn23.Text == "P")
                {

                    lnkbtn23.ForeColor = System.Drawing.Color.Green;

                }
                else
                {

                    lnkbtn23.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn23.ToolTip = "Late";

                }
                LinkButton lnkbtn24 = (LinkButton)e.Row.FindControl("lnkbtn24");
                if (lnkbtn24.Text == "A")
                {
                    lnkbtn24.Text = "A";
                    lnkbtn24.ForeColor = System.Drawing.Color.Red;
                    lnkbtn24.ToolTip = "Absent";

                    DateTime dayDate = Convert.ToDateTime("24/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn24.Text = "H";
                        lnkbtn24.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn24.ToolTip = "Sunday";

                    }
                }
                else if (lnkbtn24.Text == "P")
                {

                    lnkbtn24.ForeColor = System.Drawing.Color.Green;

                }
                else
                {

                    lnkbtn24.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn24.ToolTip = "Late";

                }
                LinkButton lnkbtn25 = (LinkButton)e.Row.FindControl("lnkbtn25");
                if (lnkbtn25.Text == "A")
                {
                    lnkbtn25.Text = "A";
                    lnkbtn25.ForeColor = System.Drawing.Color.Red;
                    lnkbtn25.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("25/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn25.Text = "H";
                        lnkbtn25.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn25.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn25.Text == "P")
                {

                    lnkbtn25.ForeColor = System.Drawing.Color.Green;

                }
                else
                {

                    lnkbtn25.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn25.ToolTip = "Late";

                }
                LinkButton lnkbtn26 = (LinkButton)e.Row.FindControl("lnkbtn26");
                if (lnkbtn26.Text == "A")
                {
                    lnkbtn26.Text = "A";
                    lnkbtn26.ForeColor = System.Drawing.Color.Red;
                    lnkbtn26.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("26/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn26.Text = "H";
                        lnkbtn26.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn26.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn26.Text == "P")
                {

                    lnkbtn26.ForeColor = System.Drawing.Color.Green;

                }
                else
                {

                    lnkbtn26.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn26.ToolTip = "Late";

                }
                LinkButton lnkbtn27 = (LinkButton)e.Row.FindControl("lnkbtn27");
                if (lnkbtn27.Text == "A")
                {
                    lnkbtn27.Text = "A";
                    lnkbtn27.ForeColor = System.Drawing.Color.Red;
                    lnkbtn27.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("27/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn27.Text = "H";
                        lnkbtn27.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn27.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn27.Text == "P")
                {

                    lnkbtn27.ForeColor = System.Drawing.Color.Green;

                }
                else
                {

                    lnkbtn27.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn27.ToolTip = "Late";

                }
                LinkButton lnkbtn28 = (LinkButton)e.Row.FindControl("lnkbtn28");
                if (lnkbtn28.Text == "A")
                {
                    lnkbtn28.Text = "A";
                    lnkbtn28.ForeColor = System.Drawing.Color.Red;
                    lnkbtn28.ToolTip = "Absent";
                    DateTime dayDate = Convert.ToDateTime("28/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                    if (dayDate.DayOfWeek.ToString() == "Sunday")
                    {
                        lnkbtn28.Text = "H";
                        lnkbtn28.ForeColor = System.Drawing.Color.Blue;
                        lnkbtn28.ToolTip = "Sunday";
                    }
                }
                else if (lnkbtn28.Text == "P")
                {

                    lnkbtn28.ForeColor = System.Drawing.Color.Green;
                    lnkbtn28.ToolTip = "Present";
                }
                else
                {

                    lnkbtn28.ForeColor = System.Drawing.Color.DarkGreen;
                    lnkbtn28.ToolTip = "Late";

                }

                if (ddlMonth.SelectedValue == "2")
                {
                    try
                    {
                        DateTime dayDate = Convert.ToDateTime("29/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());

                        LinkButton lnkbtn29 = (LinkButton)e.Row.FindControl("lnkbtn29");
                        if (lnkbtn29.Text == "A")
                        {
                            lnkbtn29.Text = "A";
                            lnkbtn29.ForeColor = System.Drawing.Color.Red;
                            lnkbtn29.ToolTip = "Absent";
                             dayDate = Convert.ToDateTime("29/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                            if (dayDate.DayOfWeek.ToString() == "Sunday")
                            {
                                lnkbtn29.Text = "H";
                                lnkbtn29.ForeColor = System.Drawing.Color.Blue;
                                lnkbtn29.ToolTip = "Sunday";
                            }
                        }
                        else if (lnkbtn29.Text == "P")
                        {

                            lnkbtn29.ForeColor = System.Drawing.Color.Green;
                            lnkbtn29.ToolTip = "Present";
                        }
                        else
                        {

                            lnkbtn29.ForeColor = System.Drawing.Color.DarkGreen;
                            lnkbtn29.ToolTip = "Late";

                        }

                    }
                    catch
                    {

                    }
                    
                }
                if (ddlMonth.SelectedValue == "4" || ddlMonth.SelectedValue == "6" || ddlMonth.SelectedValue == "9" || ddlMonth.SelectedValue == "11")
                {

                    LinkButton lnkbtn30 = (LinkButton)e.Row.FindControl("lnkbtn30");
                    if (lnkbtn30.Text == "A")
                    {
                        lnkbtn30.Text = "A";
                        lnkbtn30.ForeColor = System.Drawing.Color.Red;
                        lnkbtn30.ToolTip = "Sunday";
                        DateTime dayDate = Convert.ToDateTime("30/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                        if (dayDate.DayOfWeek.ToString() == "Sunday")
                        {
                            lnkbtn30.Text = "H";
                            lnkbtn30.ForeColor = System.Drawing.Color.Blue;
                            lnkbtn30.ToolTip = "Sunday";
                        }
                    }
                    else if (lnkbtn30.Text == "P")
                    {

                        lnkbtn30.ForeColor = System.Drawing.Color.Green;
                        lnkbtn30.ToolTip = "Present";
                    }
                    else
                    {

                        lnkbtn30.ForeColor = System.Drawing.Color.DarkGreen;
                        lnkbtn30.ToolTip = "Late";

                    }
                }
                 

                if (ddlMonth.Text == "1" || ddlMonth.Text == "3" || ddlMonth.Text == "5" || ddlMonth.Text == "7" || ddlMonth.Text == "8" || ddlMonth.Text == "10" || ddlMonth.Text == "12")
                {

                    LinkButton lnkbtn31 = (LinkButton)e.Row.FindControl("lnkbtn31");
                    if (lnkbtn31.Text == "A")
                    {
                        lnkbtn31.Text = "A";
                        lnkbtn31.ForeColor = System.Drawing.Color.Red;
                        lnkbtn31.ToolTip = "Absent";
                        DateTime dayDate = Convert.ToDateTime("31/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim());
                        if (dayDate.DayOfWeek.ToString() == "Sunday")
                        {
                            lnkbtn31.Text = "H";
                            lnkbtn31.ForeColor = System.Drawing.Color.Blue;
                            lnkbtn31.ToolTip = "Sunday";
                        }
                    }
                    else if (lnkbtn31.Text == "P")
                    {

                        lnkbtn31.ForeColor = System.Drawing.Color.Green;
                        lnkbtn31.ToolTip = "Present";
                    }
                    else
                    {

                        lnkbtn31.ForeColor = System.Drawing.Color.DarkGreen;
                        lnkbtn31.ToolTip = "Late";

                    }
                }
            }
        }
        catch (Exception)
        {
            
            throw;
        }
       
    }

    protected void lnkbtn_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnk = sender as LinkButton;
            if (sender != null)
            {
                Session["StudentId"] =  lnk.CommandArgument;
                Session["Date"] = ddlYear.SelectedValue + "/" + ddlMonth.SelectedValue + "/" + lnk.ID.Substring(6, 2); 
                
                ModalPopupExtender1.Show();
            }
        }
        catch 
        {
            
        }
    }
    protected void drpselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(drpselect.SelectedValue) == "Late")
            {
                txtTime.Visible = true;
                lblTime.Visible = true;
                ModalPopupExtender1.Show();
            }
            else
            {
                txtTime.Visible = false;
                lblTime.Visible = true;
                ModalPopupExtender1.Show();
            }
        }
        catch
        {
            
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            
            DateTime dt =DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"), new CultureInfo("en-GB"));
            DateTime SeledtedDate=DateTime.Parse(Convert.ToString(Session["Date"]), new CultureInfo("en-GB"));
            if (Convert.ToDateTime(dt) >= Convert.ToDateTime(SeledtedDate))
            {

                if (drpselect.SelectedValue != "0")
                {
                    strQry = "exec [usp_getAttendance] @type='" + Convert.ToString(drpselect.SelectedValue) + "',@intStudentid='" + Session["StudentId"] + "',@FromDate='" + Convert.ToDateTime(Session["Date"]).ToString("MM/dd/yyyy") + "',@intSchool_id= '" + Session["School_id"] + "',@Remark='" + txtRemark.Text.Trim() + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@intUpdatedIp='" + Convert.ToString(GetSystemIP()) + "',@inTime='"+ txtTime.Text +"'";
                    if (sExecuteQuery(strQry) != -1)
                    {
                        txtRemark.Text = "";
                        FillAllAttendace();
                        
                        CalAttendance.DayRender += new DayRenderEventHandler(CalAttendance_DayRender);
                        GetData();
                        ModalPopupExtender1.Hide();
                    }
                }
            }

        }
        catch 
        {
            
        }
    }
    protected void btnOk_Click(object sender, ImageClickEventArgs e)
    {
        ModalPopupExtender1.Hide();
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillAllAttendace();
          //  CalFrmDate.SelectedDate = Convert.ToDateTime("01/" + ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue);
           // CalToDate.SelectedDate = Convert.ToDateTime("01/" + ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue);
        }
        catch (Exception)
        {
            
            throw;
        }
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
                ddlMonth1.SelectedValue = Convert.ToString(12);
                Month = 12;
                if (CalAttendance.VisibleDate.Year != 001)
                {
                    Year = CalAttendance.VisibleDate.Year - 1;
                }
                else
                {
                    Year = DateTime.Now.Year;
                }
                FillGrid();

                CalAttendance.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
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
            if (ddlMonth1.SelectedValue != "12")
            {
                ddlMonth1.SelectedValue = Convert.ToString((Convert.ToInt32(ddlMonth1.SelectedValue) + 1));
                ddlMonth1_SelectedIndexChanged(null, null);
            }
            else
            {
                ddlMonth1.SelectedValue = Convert.ToString(1);
                Month = 1;
                if (CalAttendance.VisibleDate.Year != 001)
                {
                    Year = CalAttendance.VisibleDate.Year + 1;
                }
                else
                {
                    Year = DateTime.Now.Year;
                }
                FillGrid();

                CalAttendance.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
                GetData();
            }
        }
        catch
        {
        }
    }
    protected void ddlYear1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillSummeryAttendatce();
        }
        catch 
        {
            
        }
    }
    public void FillSummeryAttendatce()
    {
        try
        {
            if(ddlStudent.SelectedValue!="0" && ddlSTD.SelectedValue!="0" && ddlDIV.SelectedValue!="0")
            {
            strQry = "";
            strQry = "exec usp_AttendanceSummery @type='StudentAttendance',@intStudent_Id='" + ddlStudent.SelectedValue + "',@intSchool_Id='" + Session["School_Id"] + "',@Year='" + ddlYear1.SelectedValue  + "'";
            dsObj = sGetDataset(strQry); 
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvSummery.DataSource = dsObj;
                grvSummery.DataBind();
            }
            else
            {
                grvSummery.DataSource = dsObj;//null
                grvSummery.DataBind();
            }
            }
        }
        catch
        {
            
        }
    }
    public void FillStatus()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_AttendanceSummery] @type='FillStatus'";
            sBindDropDownList(ddlStatus, strQry, "status", "Id");

        }
        catch 
        {
            
        }
    }
    public void FillStudentsAttendance()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_AttendanceSummery] @type='TotStudentsAttSummery',@Div='" + ddlDIV.SelectedValue + "',@Year='" + Convert.ToString(ddlYear2.SelectedValue) + "',@intSchool_Id='" + Session["School_Id"] + "',@month='" + ddlMonths.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            grvStudSumm.DataSource = dsObj;
            grvStudSumm.DataBind();
        }
        catch 
        {
            
          
        }
    }
  
    protected void ddlMonths_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillStudentsAttendance();
        }
        catch
        {
            
           
        }
    }
    protected void grvStudSumm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvStudSumm.PageIndex = e.NewPageIndex;
        grvStudSumm.DataBind();

        FillStudentsAttendance();
    }
    protected void ddlMin_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillAttPercent();
        }
        catch
        {
            
        }
    }
    public void FillAttPercent()
    {
        try
        {
             strQry = "";
             if (ddlStatus.SelectedValue == "TotPresent")
             {
                 strQry = "exec [usp_AttendanceSummery] @type='StudentTotAttendancePercent',@intSchool_Id='" + Session["School_Id"] + "',@status='" + ddlStatus.SelectedValue + "',@min='" + ddlMin.SelectedValue + "',@max='" + ddlMax.SelectedValue + "',@Year='2018',@Div='" + ddlDIV.SelectedValue + "',@Std='" + ddlSTD.SelectedValue + "',@intAcademic_id='" + Session["AcademicID"] + "'";
             }
             else
             {
                 strQry = "exec [usp_AttendanceSummery] @type='StudentAttendancePercent',@intSchool_Id='" + Session["School_Id"] + "',@status='" + ddlStatus.SelectedValue + "',@min='" + ddlMin.SelectedValue + "',@max='" + ddlMax.SelectedValue + "',@Year='2018',@Div='" + ddlDIV.SelectedValue + "',@Std='" + ddlSTD.SelectedValue + "',@intAcademic_id='" + Session["AcademicID"] + "'";
             }
            dsObj = sGetDataset(strQry);
            grvpercent.DataSource = dsObj;
            grvpercent.DataBind();
        }
        catch 
        {
            
        }
    }
    protected void ddlMax_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAttPercent();
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAttPercent();
    }

    protected void ImgExport_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (grvpercent.Rows.Count > 0)
            {
                ExportToExcel(grvpercent);
            }
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
        }
    }
    public void ExportToExcel(GridView grv)
    {
       Response.Clear();  
       Response.Buffer = true;  
       Response.ClearContent();  
       Response.ClearHeaders();  
       Response.Charset = "";  
       string FileName ="Vithal"+DateTime.Now+".xls";  
       StringWriter strwritter = new StringWriter();  
       HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);        
       Response.Cache.SetCacheability(HttpCacheability.NoCache);  
       Response.ContentType ="application/vnd.ms-excel";    
       Response.AddHeader("Content-Disposition","attachment;filename=" + FileName);  
       grv.GridLines = GridLines.Both;
       grv.HeaderStyle.Font.Bold = true;
       grv.RenderControl(htmltextwrtter);  
       Response.Write(strwritter.ToString());
       HttpContext.Current.Response.Flush();
       HttpContext.Current.Response.SuppressContent = true;
       HttpContext.Current.ApplicationInstance.CompleteRequest();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }


    protected void ImgXls_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ClsExportExcel exp = new ClsExportExcel();

           // exp.ExportGrid(grvAttendance, "FileName" + DateTime.Now, Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", "Att");


          
            switch (TabContainer1.ActiveTabIndex)
            {
                case 1:
                    //  ExportGridToPDF(grvAttendance, "Attendance " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                    //exp.ExportGrid( grvAttendance, ddlStudent.SelectedItem.Text + " " + ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", ddlMonth1.SelectedItem.Text + " Month Attendance");
                    exp.ExportGrid(grdattendance, ddlStudent.SelectedItem.Text + " " + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", ddlMonth.SelectedItem.Text + " Month Attendance");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlStudent.SelectedItem.Text + " " + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + ddlStudent.SelectedValue + "',@intUserType='1',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";

                    break;
                case 2:
                    //   ExportGrid(grdattendance, "AttendanceDetails " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                    exp.ExportGrid(grdattendance, ddlStudent.SelectedItem.Text + " " + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", ddlMonth.SelectedItem.Text + " Month Attendance");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlStudent.SelectedItem.Text + " " + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + ddlStudent.SelectedValue + "',@intUserType='1',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                    break;

                case 3:
                    //  ExportGrid(grvSummery, "AttendanceSummary " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                   // exp.ExportGrid(grvSummery, "Attendance Summary Of Year " + ddlYear1.SelectedValue + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", "Attendance Summary Of Year " + ddlYear1.SelectedValue);
                    exp.ExportGrid(grdattendance, ddlStudent.SelectedItem.Text + " " + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", ddlMonth.SelectedItem.Text + " Month Attendance");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + "Attendance Summary Of Year " + ddlYear1.SelectedValue + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + ddlStudent.SelectedValue + "',@intUserType='1',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "'";
                    break;

                case 4:
                    //ExportGrid(grvStudSumm, "AttendanceSummary " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                   // exp.ExportGrid(grvStudSumm, "Attendance Summary Of Month " + ddlMonths.SelectedValue + " " + ddlYear2.SelectedValue + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", "Attendance Summary Of Month " + ddlMonths.SelectedValue + " " + ddlYear2.SelectedValue);
                    exp.ExportGrid(grdattendance, ddlStudent.SelectedItem.Text + " " + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", ddlMonth.SelectedItem.Text + " Month Attendance");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + "Attendance Summary Of Month " + ddlMonths.SelectedValue + " " + ddlYear2.SelectedValue + DateTime.Now.ToShortDateString() + "',@intUserid='" + ddlStudent.SelectedValue + "',@intUserType='1',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                    break;

                case 5:
                    // ExportGrid(grvpercent, "AnalyseAttendane " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                   // exp.ExportGrid(grvpercent, "Analyse Attendance Of Status " + ddlStatus.SelectedItem.Text + " between " + ddlMin.SelectedValue + "% and " + ddlMax.SelectedValue + "%" + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", "Analyse Attendance Of Status " + ddlStatus.SelectedItem.Text + " between " + ddlMin.SelectedValue + "% and " + ddlMax.SelectedValue + "%");
                    exp.ExportGrid(grdattendance, ddlStudent.SelectedItem.Text + " " + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", ddlMonth.SelectedItem.Text + " Month Attendance");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + "Analyse Attendance Of Status " + ddlStatus.SelectedItem.Text + " between " + ddlMin.SelectedValue + "% and " + ddlMax.SelectedValue + "%" + DateTime.Now.ToShortDateString() + "',@intUserid='" + ddlStudent.SelectedValue + "',@intUserType='1',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                    break;
            }
            sExecuteQuery(strQry);

            //switch (TabContainer1.ActiveTabIndex)
            //{
            //    case 1:s
            //        ExportGrid(grvAttendance, ddlStudent.SelectedItem.Text + " Attendance " + DateTime.Now + ".xls", "application/vnd.ms-excel");
            //        break;
            //    case 2:
            //        ExportGrid(grdattendance, ddlStudent.SelectedItem.Text + " AttendanceDetails " + DateTime.Now + ".xls", "application/vnd.ms-excel");
            //        break;

            //    case 3:
            //        ExportGrid(grvSummery, ddlStudent.SelectedItem.Text + " AttendanceSummary " + DateTime.Now + ".xls", "application/vnd.ms-excel");
            //        break;

            //    case 4:
            //        ExportGrid(grvStudSumm, ddlStudent.SelectedItem.Text + " AttendanceSummary " + DateTime.Now + ".xls", "application/vnd.ms-excel");
            //        break;

            //    case 5:
            //        ExportGrid(grvpercent, ddlStudent.SelectedItem.Text + " AnalyseAttendane " + DateTime.Now + ".xls", "application/vnd.ms-excel");
            //        break;
            //}
        }
        catch (Exception)
        {
            
        }
    }
    protected void ImgPdf_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            

            ClsExportPdf pdf = new ClsExportPdf();
            switch (TabContainer1.ActiveTabIndex)
            {
                case 1:
                  //  ExportGridToPDF(grvAttendance, "Attendance " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                    pdf.Page_Load(null, null, grvAttendance, ddlStudent.SelectedItem.Text + " " + ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", ddlMonth1.SelectedItem.Text + " Month Attendance");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlStudent.SelectedItem.Text + " " + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + ddlStudent.SelectedValue + "',@intUserType='1',@vchReportFormat='.pdf',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";

                    break;
                case 2:
                 //   ExportGrid(grdattendance, "AttendanceDetails " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                    pdf.Page_Load(null, null, grdattendance, ddlStudent.SelectedItem.Text + " " + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", ddlMonth.SelectedItem.Text + " Month Attendance");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlStudent.SelectedItem.Text + " " + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + ddlStudent.SelectedValue + "',@intUserType='1',@vchReportFormat='.pdf',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                    break;

                case 3:
                  //  ExportGrid(grvSummery, "AttendanceSummary " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                    pdf.Page_Load(null, null, grvSummery, "Attendance Summary Of Year " + ddlYear1.SelectedValue + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", "Attendance Summary Of Year " + ddlYear1.SelectedValue);

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + "Attendance Summary Of Year " + ddlYear1.SelectedValue + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + ddlStudent.SelectedValue + "',@intUserType='1',@vchReportFormat='.pdf',@intSchoolId='" + Session["School_id"] + "'";
                    break;

                case 4:
                    //ExportGrid(grvStudSumm, "AttendanceSummary " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                    pdf.Page_Load(null, null, grvStudSumm, "Attendance Summary Of Month " + ddlMonths.SelectedValue + " " + ddlYear2.SelectedValue + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", "Attendance Summary Of Month " + ddlMonths.SelectedValue + " " + ddlYear2.SelectedValue);

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + "Attendance Summary Of Month " + ddlMonths.SelectedValue + " " + ddlYear2.SelectedValue + DateTime.Now.ToShortDateString() + "',@intUserid='" + ddlStudent.SelectedValue + "',@intUserType='1',@vchReportFormat='.pdf',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                    break;

                case 5:
                   // ExportGrid(grvpercent, "AnalyseAttendane " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                    pdf.Page_Load(null, null, grvpercent, "Analyse Attendance Of Status " + ddlStatus.SelectedItem.Text + " between " + ddlMin.SelectedValue + "% and " + ddlMax.SelectedValue + "%" + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", "Analyse Attendance Of Status " + ddlStatus.SelectedItem.Text + " between " + ddlMin.SelectedValue + "% and " + ddlMax.SelectedValue + "%");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + "Analyse Attendance Of Status " + ddlStatus.SelectedItem.Text + " between " + ddlMin.SelectedValue + "% and " + ddlMax.SelectedValue + "%" + DateTime.Now.ToShortDateString() + "',@intUserid='" + ddlStudent.SelectedValue + "',@intUserType='1',@vchReportFormat='.pdf',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                    break;
            }
            sExecuteQuery(strQry);
        }
        catch
        {
            
        }
    }
    protected void ImgDoc_Click(object sender, ImageClickEventArgs e)
    {
        switch (TabContainer1.ActiveTabIndex)
        {
            case 1:
                ExportToWord(grvAttendance, "Attendance " + DateTime.Now + ".doc");
                break;
            case 2:
                ExportToWord(grdattendance, "AttendanceDetails " + DateTime.Now + ".doc");
                break;

            case 3:
                ExportToWord(grvSummery, "AttendanceSummary " + DateTime.Now + ".doc");
                break;

            case 4:
                ExportToWord(grvStudSumm, "AttendanceSummary " + DateTime.Now + ".doc");
                break;

            case 5:
                ExportToWord(grvpercent, "AnalyseAttendane " + DateTime.Now + ".doc");
                break;
        }
    }
    protected void ddlYear2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillStudentsAttendance();
        }
        catch 
        {
        }
    }

    protected void txtFrmDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtToDate.Text == "")
            {
                for (int i = 1; i < grdattendance.Columns.Count; i++)
                {
                    if (Convert.ToString(grdattendance.Columns[i].HeaderText).PadLeft(2, '0') == Convert.ToDateTime(txtFrmDate.Text).ToString("dd"))
                    {
                        grdattendance.Columns[i].Visible = true;
                        // grdattendance.Width = Convert.ToInt32(grdattendance.Width.Value) + 4;
                    }
                    else
                    {

                        grdattendance.Columns[i].Visible = false;
                        //if (grdattendance.Width.Value > 3)
                        //  grdattendance.Width = Convert.ToInt32(grdattendance.Width.Value) - 3;
                    }
                }
            }
            else
            {
                for (int i = Convert.ToInt32(Convert.ToDateTime(txtFrmDate.Text).ToString("dd")); i < grdattendance.Columns.Count; i++)
                {
                    if (Convert.ToInt32(Convert.ToString(grdattendance.Columns[i].HeaderText).PadLeft(2, '0')) <= Convert.ToInt32(Convert.ToDateTime(txtToDate.Text).ToString("dd")))
                    {
                        grdattendance.Columns[i].Visible = true;
                        // grdattendance.Width = Convert.ToInt32(grdattendance.Width.Value) + 4;
                    }
                    else
                    {

                        grdattendance.Columns[i].Visible = false;
                        //if (grdattendance.Width.Value > 3)
                        //  grdattendance.Width = Convert.ToInt32(grdattendance.Width.Value) - 3;
                    }

                }
                for (int i = 1; i < Convert.ToInt32(Convert.ToDateTime(txtFrmDate.Text).ToString("dd")); i++)
                {
                     grdattendance.Columns[i].Visible = false;
                }
            }
        }
        catch 
        {
            
        }
       
    }
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = Convert.ToInt32(Convert.ToDateTime(txtFrmDate.Text).ToString("dd")); i < grdattendance.Columns.Count; i++)
            {
                if (Convert.ToInt32(Convert.ToString(grdattendance.Columns[i].HeaderText).PadLeft(2, '0')) <= Convert.ToInt32(Convert.ToDateTime(txtToDate.Text).ToString("dd")))
                {
                    grdattendance.Columns[i].Visible = true;
                   // grdattendance.Width = Convert.ToInt32(grdattendance.Width.Value) + 4;
                }
                else
                {

                    grdattendance.Columns[i].Visible = false;
                    //if (grdattendance.Width.Value > 3)
                    //  grdattendance.Width = Convert.ToInt32(grdattendance.Width.Value) - 3;
                }
               
            }
        }
        catch
        {
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;

public partial class frmHolidayMst : DBUtility
{
    string strQry = "";
    int id;
    int Month;
    string StudentName, STD, DIV;
    int RollNo;
    string directoryPath = string.Empty;
    int Year;
    DataSet dsObj, dsCal;
    string filename = "";
    protected void Page_Load(object sender, EventArgs e)
    {
     
          
            TextBox1.Text = Convert.ToDateTime(DateTime.Today).ToString("dd/MM/yyyy");
            Month = DateTime.Now.Month;
            Year = DateTime.Now.Year;
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {
                    ImgXls.Visible = false;
                    ImgPdf.Visible = false;
                    ImgDoc.Visible = false;
                    TabContainer1.ActiveTabIndex = 0;
                    Fillgrid();
                    fillHoliday();
                    FillHolidayDataset(); 
                    geturl();
                }
            //    FillHolidayDataset();
              
            }
    
            else
            {
                Response.Redirect("~\\Index.aspx", false);
            }
        
    }
    protected void fillHoliday()
    {
        string strQry = "Execute usp_setHolidayList @type='fillHoliday',@intSchool_id='" + Session["School_id"] + "' ";
        bool stcardp = sBindDropDownList(ddlHolidayType, strQry, "vchHoliday_Type", "intHoliday_Type_Id");
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
            //if (CalHoliday.VisibleDate.Month == 1)
            //{
            //    Month = 12;
            //    Year = CalHoliday.VisibleDate.Year - 1;
            //}
            //else
            //{
            //    Month = CalHoliday.VisibleDate.Month;
            //    Year = CalHoliday.VisibleDate.Year;
            //}
           
        }
        DateTime firstDate = new DateTime(Year, Month, 1);
        CalHoliday.VisibleDate = new DateTime(Year, Month, 1);
        DateTime lastDate = GetFirstDayOfNextMonth();
        dsObj = GetCurrentMonthData(firstDate, lastDate);
    }

    protected DateTime  GetFirstDayOfNextMonth()
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
            strQry = "exec [usp_setHolidayList] @type='GetCalendarData',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',  @FirstDate='" + Convert.ToDateTime(FirstDt).ToString("yyyy/MM/dd") + "',@LastDate='" + Convert.ToDateTime(LastDt).ToString("yyyy/MM/dd") + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsCal = sGetDataset(strQry);
            return dsCal;
        }
        catch (Exception)
        {
            return dsObj;
        }
    }
    public void Fillgrid()
    {
        try
        {
            grvDetail.DataSource = Createtable();
            grvDetail.DataBind();

            if (dsObj == null)
            {
                grvDetail.DataSource = null;
                grvDetail.DataBind();
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }

             if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
             {
                 grvDetail.Columns[0].Visible = false;
                 grvDetail.Columns[7].Visible = true;
                 grvDetail.Columns[8].Visible = true;
                 TabContainer1.Tabs[1].Visible = true;
                 TabContainer1.Tabs[0].Visible = true;
             }
             else
             {
                 
                 grvDetail.Columns[0].Visible = false;
                 grvDetail.Columns[7].Visible = false;
                 grvDetail.Columns[8].Visible = false;

                 TabContainer1.Tabs[0].Visible = true;
                 TabContainer1.Tabs[1].Visible = true;
                 TabContainer1.Tabs[2].Visible = false;
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
            if (chkAll.Checked)
            {
                strQry = "exec [usp_setHolidayList] @type='FillData',@intSchool_id='" + Session["School_id"] + "',@year='" + Year + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            }
            else
            {
                strQry = "exec [usp_setHolidayList] @type='FillData',@intSchool_id='" + Session["School_id"] + "',@month='" + Month + "',@year='" + Year + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            }
            
           
            dsObj = sGetDataset(strQry);
            return dsObj;
        }
        catch 
        {
            return dsObj;
        }
    }
    protected void grvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    ImageButton view = (ImageButton)e.Row.FindControl("ImgView");
        //  //  string a =e.Row.c
        //    view.Attributes.Add("onclick", "window.open('frmViewDoc.aspx','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=800,top=90,left=100');return false");
        //}
    }

    public void MessageBox(string msg)
    {
        try
        {
            string script = "alert(\"" + msg +"\");";
            ScriptManager.RegisterStartupScript(this, GetType(),"ServerControlScript", script, true);
          
        }
        catch (Exception)
        {
           // return msg;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();
            string Filepath = "";

            // directoryPath = Server.MapPath(string.Format("~/{0}/", "Documents/Holiday"));
            //if (!Directory.Exists(directoryPath))
            //{
            //    Directory.CreateDirectory(directoryPath);
            //}


            //if (Directory.Exists(directoryPath + "/" + Convert.ToString(Session["FileUpload"])))
            //    {
            //        Directory.Delete(directoryPath + "/" + Convert.ToString(Session["FileUpload"]));
            //    }

            
            //Filepath = directoryPath + "/" + Convert.ToString(Session["FileUpload"]);
            

            if (btnSubmit.Text == "Submit")
            {
                string frmDt = Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy"); // DateTime.ParseExact(txtFrmDt.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                string todt = Convert.ToDateTime(txtToDt.Text).ToString("MM/dd/yyyy");// DateTime.ParseExact(txtToDt.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                //Check Exist
                strQry = "exec [usp_setHolidayList] @type='CheckExist',@vchHoliday_name='" + Convert.ToString(txtName.Text).Trim() + "',@dtFromDate='" + frmDt + "',@dtToDate='" + todt + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Record Already Exist!");
                    return;
                }
                //End
                else
                {

                    //string UploadPath = System.IO.Path.GetFullPath(AttchFile.PostedFile.FileName);
                    strQry = "exec usp_setHolidayList @type='InsertUpdate',@intHoliday_Type_Id='" + Convert.ToString(ddlHolidayType.SelectedValue.Trim()) + "',@vchHoliday_name='" + Convert.ToString(txtName.Text.Trim()) + "',@dtFromDate='" + frmDt + "',@dtToDate='" + todt + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@Description='" + Convert.ToString(txtDesc.Text).Trim() + "',@intNoOfDay=" + Convert.ToString(txtNoOfdays.Text) + ",@vchDocPath='" + Convert.ToString(Session["FileName"]) + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchUpdatedIp='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                    //strQry = "exec usp_setHolidayList @type='InsertUpdate',@intHoliday_Type_Id='" + Convert.ToString(ddlHolidayType.Text.Trim()) + "',@vchHoliday_name='" + Convert.ToString(txtName.Text.Trim()) + "',@dtFromDate='" + frmDt + "',@dtToDate='" + todt + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@Description='" + Convert.ToString(txtDesc.Text).Trim() + "',@intNoOfDay=" + Convert.ToString(txtNoOfdays.Text) + ",@intHoliday_id='" + Convert.ToString(Session["id"]) + "',@vchDocPath='" + Convert.ToString(Session["FileName"]) + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchUpdatedIp='" + GetSystemIP() + "'";
                    if (sExecuteQuery(strQry) != -1)
                    {
                        MessageBox("Record Saved Successfully!");
                        Fillgrid();
                        Session["id"] = null;
                        btnSubmit.Text = "Submit";
                        Clear();
                        //    AttachFile.ClearAllFilesFromPersistedStore();
                    }
                    else
                    {
                        MessageBox("Insertion Failed");
                        //  AttachFile.ClearAllFilesFromPersistedStore();
                    }
                }

            }

            if (btnSubmit.Text == "Update")
            {
                //Check Exist
                string frmDt = Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy"); // DateTime.ParseExact(txtFrmDt.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                string todt = Convert.ToDateTime(txtToDt.Text).ToString("MM/dd/yyyy");
                strQry = "exec [usp_setHolidayList]  @type='CheckUpdateExist',@vchHoliday_name='" + Convert.ToString(txtName.Text).Trim() + "',@dtFromDate='" + frmDt + "',@dtToDate='" + todt + "',@intHoliday_id='" + Session["id"] + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Record Already Exist!");
                    return;
                }
                //End
                else
                {
                    //string frmDt = Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy"); // DateTime.ParseExact(txtFrmDt.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    //string todt = Convert.ToDateTime(txtToDt.Text).ToString("MM/dd/yyyy");// DateTime.ParseExact(txtToDt.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    //string UploadPath = System.IO.Path.GetFullPath(AttchFile.PostedFile.FileName);
                  //  strQry = "exec usp_setHolidayList @type='InsertUpdate',@intHoliday_Type_Id='" + Convert.ToString(ddlHolidayType.Text.Trim()) + "',@vchHoliday_name='" + Convert.ToString(txtName.Text.Trim()) + "',@dtFromDate='" + frmDt + "',@dtToDate='" + todt + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@Description='" + Convert.ToString(txtDesc.Text).Trim() + "',@intNoOfDay=" + Convert.ToString(txtNoOfdays.Text) + ",@vchDocPath='" + Convert.ToString(Session["FileName"]) + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchUpdatedIp='" + GetSystemIP() + "'";
                    strQry = "exec usp_setHolidayList @type='InsertUpdate',@intHoliday_Type_Id='" + Convert.ToString(ddlHolidayType.SelectedValue.Trim()) + "',@vchHoliday_name='" + Convert.ToString(txtName.Text.Trim()) + "',@dtFromDate='" + frmDt + "',@dtToDate='" + todt + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@Description='" + Convert.ToString(txtDesc.Text).Trim() + "',@intNoOfDay=" + Convert.ToString(txtNoOfdays.Text) + ",@intHoliday_id='" + Convert.ToString(Session["id"]) + "',@vchDocPath='" + Convert.ToString(Session["FileName"]) + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchUpdatedIp='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                    if (sExecuteQuery(strQry) != -1)
                    {
                        MessageBox("Record Saved Successfully!");
                        Fillgrid();
                        Session["id"] = null;
                        btnSubmit.Text = "Submit";
                        Clear();
                        //    AttachFile.ClearAllFilesFromPersistedStore();
                    }
                    else
                    {
                        MessageBox("Insertion Failed");
                        //  AttachFile.ClearAllFilesFromPersistedStore();
                    }
                }
            }  


            
        }
        catch (Exception)
        {
            MessageBox("Insertion Failed");
        }
    }
    public void Clear()
    {
        txtToDt.Text = "";
        txtFrmDt.Text = "";
        txtNoOfdays.Text = "";
        ddlHolidayType.Text = "Select";
        btnSubmit.Text = "Submit";
        txtDesc.Text = "";
        txtName.Text = "";
        FillHolidayDataset();
        Session["FileUpload"] = null;
        Session["FileSize"] = null;
        Session["FileName"] = null;
    }

        protected void txtToDt_TextChanged(object sender, EventArgs e)
        {
            txtToDt.Attributes.Add("onblur", "NoOfDays()");
            try
            {
                DateTime frm = Convert.ToDateTime(txtFrmDt.Text);
                DateTime to = Convert.ToDateTime(txtToDt.Text);
                if (frm <= to)
                {
                   TimeSpan t = new TimeSpan(1, 0, 0, 0);
                    TimeSpan diff = (to.Date - frm.Date).Add(t);
                    txtNoOfdays.Text = Convert.ToString(diff);
                    txtNoOfdays.Text = txtNoOfdays.Text.Replace(".00:00:00", "");
                }
                else
                {
                    txtNoOfdays.Text = "";
                }
            }
            catch (Exception)
            {
                
             
            }
        }
        protected void txtFrmDt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime frm = Convert.ToDateTime(txtFrmDt.Text);
                DateTime to = Convert.ToDateTime(txtToDt.Text);
                if (frm <= to)
                {
                    TimeSpan t = new TimeSpan(1, 0, 0, 0);
                    TimeSpan diff = (to.Date - frm.Date).Add(t);
                    txtNoOfdays.Text = Convert.ToString(diff);
                    txtNoOfdays.Text = txtNoOfdays.Text.Replace(".00:00:00", "");
                }
                else
                {
                    txtNoOfdays.Text = "";
                }
            }
            catch (Exception)
            {


            }
        }
        protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
               
                 id = Convert.ToInt32(grvDetail.DataKeys[e.NewEditIndex].Value);
                 Session["id"] =grvDetail.DataKeys[e.NewEditIndex].Value;
                dsObj = new DataSet();
                strQry = "exec [usp_setHolidayList] @type='SelectData',@intHoliday_id='" + id + "',@intSchool_id='" + Session["School_id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    txtDesc.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Description"]);
                    txtFrmDt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtFromDate"]);
                    txtToDt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtToDate"]);
                    ddlHolidayType.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intHoliday_Type_Id"]);
                    txtName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchHoliday_name"]);
                    txtNoOfdays.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intNoOfDay"]);
                    TabContainer1.ActiveTabIndex = 2;
                    btnSubmit.Text = "Update";
                    FillHolidayDataset();
                }

            }
            catch 
            {
                
               
            }
        }

        protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(grvDetail.DataKeys[e.RowIndex].Value);
                Session["Deleteid"] = grvDetail.DataKeys[e.RowIndex].Value;
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "ConfirmMessage", " messageConfirm('Do you want to Delete this Record ?')", true);
                 //string ans = Request.Form["confirm_value"].Substring(0,3);

                 //if (ans == "Yes")
                 //{
                     strQry = "exec [usp_setHolidayList]  @type='Delete',@intHoliday_id='" + id + "',@intDeletedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchDeletedIp='" + GetSystemIP() + "',@intSchool_id='" + Session["School_id"] + "'";
                     if (sExecuteQuery(strQry) != -1)
                     {
                         MessageBox("Record Deleted Successfully");
                         Fillgrid();
                         FillHolidayDataset();
                     }
                // }
            }
            catch
            {
                
               
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch
            {


            }
        }
        protected void FileUploadComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            //if (AttachFile.HasFile)
            //{
            //    filename = System.IO.Path.GetFullPath(AttachFile.FileName);
            //    Session["FileUpload"] = System.IO.Path.GetFullPath(AttachFile.FileName);
            //    Session["FileSize"] = AttachFile.PostedFile.ContentLength;
            //    Session["FileName"] = AttachFile.PostedFile.FileName;
            //    directoryPath = Server.MapPath(string.Format("~/{0}/", "Documents/Holiday"));
            //    if (!Directory.Exists(directoryPath))
            //    {
            //        Directory.CreateDirectory(directoryPath);
            //    }


            //    if (Directory.Exists(directoryPath + AttachFile.PostedFile.FileName))
            //    {
            //        Directory.Delete(directoryPath + AttachFile.PostedFile.FileName);
            //    }
            //    AttachFile.SaveAs(directoryPath + AttachFile.PostedFile.FileName);
            //}
        
        }
        protected void grvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "View")
                {
                    ImageButton View = (ImageButton)e.CommandSource;
                    string id = Convert.ToString(Convert.ToString(e.CommandArgument.ToString()));
                    Session["Id"] = null;
                    Session["Id"] = Convert.ToString(id);
                    string path = "~//Documents/Holiday//";
                //    //  string a =e.Row.c
                //    View.Attributes.Add("onclick", "window.open('frmViewDoc.aspx?Path=" + path + "&DocName=" + Session["id"].ToString() + ",'_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=800,top=80,left=75');return false");
                //    View.Attributes.Add("onclick", "window.open('frmTrainingDetail.aspx?TrainingId=12','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=800,top=80,left=75');return false");

                    if (Convert.ToString(Session["Id"]) != "")
                    {
                        Response.Redirect("frmViewDoc.aspx?Path=" + path + "&DocName=" + Session["id"].ToString() + "");
                    }
                    else
                    {
                        MessageBox("Document not uploaded yet!"); 
                    }
                }
            }
            catch 
            {
                
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
                if (dsCal != null)
                {
                    foreach (DataRow dr in dsCal.Tables[0].Rows)
                    {

                        nextDate = (DateTime)dr["Date"];
                        if (nextDate == e.Day.Date)
                        {
                            e.Cell.BackColor = System.Drawing.Color.SkyBlue;
                            e.Cell.ToolTip = (string)dr["Name"];
                            Label lbl = new Label();
                            lbl.Text = (string)dr["Name"]; 

                            //  e.Cell.Attributes.Add((string)dr["Name"], "1");
                        }

                    }
                }
                Fillgrid();
            }
            catch (Exception)
            {

            }



        }
        protected void grvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDetail.PageIndex = e.NewPageIndex;
            grvDetail.DataBind();

            Fillgrid();
        }
        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try 
            {
                try
                {
                   // CheckHolidayDataset();
                    FillHolidayDataset();
                    Fillgrid();
                }
                catch
                {
                   
                }
            }
            catch 
            {
                
            }
        }
        protected void CalHoliday_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            try
            {
                FillHolidayDataset();
            }
            catch 
            {
                
            }
        }
        protected void CalHoliday_SelectionChanged(object sender, EventArgs e)
        {
            FillHolidayDataset();
        }
        protected void ImgXls_Click(object sender, ImageClickEventArgs e)
        {
          
            try
            {
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


                ClsExportExcel pdf = new ClsExportExcel();
                grvDetail.Columns[0].Visible = false;
                grvDetail.Columns[1].Visible = false;
                grvDetail.Columns[2].Visible = false;
                switch (TabContainer1.ActiveTabIndex)
                {
                    case 1:
                       // ExportGrid(grvDetail, "Holiday " + DateTime.Now + ".xls", "application/vnd.ms-excel");
                        pdf.ExportGrid(grvDetail, " Holidays List" + " " + DateTime.Now.ToShortDateString(), RollNo, StudentName, STD, DIV, Convert.ToString(Session["UserType_id"]), "Holiday List");

                         strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='Holiday List',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["User_id"] + "',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";

                         break;
                      
                }
                grvDetail.Columns[0].Visible = true;
                grvDetail.Columns[1].Visible = true;
                grvDetail.Columns[2].Visible = true;
                sExecuteQuery(strQry);
            }
            catch
            {
                
            }
        }
        protected void ImgPdf_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["UserType_id"]) == "1" || Convert.ToString(Session["UserType_id"]) == "2")
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
                else if (Convert.ToString(Session["UserType_id"]) == "2")
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
                grvDetail.Columns[0].Visible = false;
                grvDetail.Columns[1].Visible = false;
                grvDetail.Columns[2].Visible = false;

                 ClsExportPdf pdf = new ClsExportPdf();
                 switch (TabContainer1.ActiveTabIndex)
                 {
                     case 1:
                         //  ExportGridToPDF(grvAttendance, "Attendance " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                         pdf.Page_Load(null, null, grvDetail, " Holidays List" + " " + DateTime.Now.ToShortDateString(), RollNo, StudentName, STD, DIV, Convert.ToString(Session["UserType_id"]), "Holiday List");

                         strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='Holiday List',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["User_id"] + "',@vchReportFormat='.pdf',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";

                         break;
                 }

                 sExecuteQuery(strQry);
                //switch (TabContainer1.ActiveTabIndex)
                //{
                //    case 1:
                //        ExportGridToPDF(grvDetail, "Holiday " + DateTime.Now + ".pdf", "application/pdf");
                //        break;
                //}
                grvDetail.Columns[0].Visible = true;
                grvDetail.Columns[1].Visible = true;
                grvDetail.Columns[2].Visible = true;
            }
            catch 
            {
                
            }
        }
        protected void ImgDoc_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                grvDetail.Columns[0].Visible = false;
                grvDetail.Columns[1].Visible = false;
                grvDetail.Columns[2].Visible = false;
                switch (TabContainer1.ActiveTabIndex)
                {
                    case 1:
                        ExportToWord(grvDetail, "Holiday " + DateTime.Now + ".doc");
                        break;
                }
                grvDetail.Columns[0].Visible = true;
                grvDetail.Columns[1].Visible = true;
                grvDetail.Columns[2].Visible = true;
            }
            catch
            {

            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
             if (FileUp.HasFile)
                {
                    if (FileUp.PostedFile.ContentLength < 20728650)
                    {
                        try
                        {

                            filename = System.IO.Path.GetFullPath(FileUp.FileName);
                            Session["FileUpload"] = System.IO.Path.GetFullPath(FileUp.FileName);
                            Session["FileSize"] = FileUp.PostedFile.ContentLength;
                            Session["FileName"] = FileUp.PostedFile.FileName;
                            directoryPath = Server.MapPath(string.Format("~/{0}/", "Documents/Holiday"));
                            Session["Path"] = directoryPath;
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }


                            if (Directory.Exists(directoryPath + FileUp.PostedFile.FileName))
                            {
                                Directory.Delete(directoryPath + FileUp.PostedFile.FileName);
                            }
                            FileUp.SaveAs(directoryPath + FileUp.PostedFile.FileName);
                            lblMesg.Text = "File Uploaded Successfully";
                        }

                        catch
                        {

                            lblMesg.Text = "File upload failed.";
                        }
                    }
                    else
                    {
                        lblMesg.Text = "File size exceeds maximum limit 20 MB.";
                    }
                }
          
            
        }
}
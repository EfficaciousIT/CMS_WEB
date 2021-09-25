using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmVacationMst : DBUtility
{
    int Month;
    int Year;
    DataSet dsObj, dsCal;
    string strQry;
    string directoryPath = string.Empty;
    string filename;
    int id;
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
                  //  pnlPopUp.Attributes.Add("display", "none");
                    Fillgrid();
                    fillVacation();
                    fillRole();
                    TabContainer1.ActiveTabIndex = 0;
                    geturl();
                    FillVacationDataset();
                    Session["id"] = null;
                }
              //  FillVacationDataset();
            }
            else
            {
                Response.Redirect("~\\Index.aspx", false);
            }
        
    }
    protected void fillVacation()
    {
        string strQry = "Execute usp_setVacationList @type='fillVacation',@intSchool_id='" + Session["School_id"] + "' ";
        bool stcardp = sBindDropDownList(ddlVacationType, strQry, "vchVacation_Type", "intVacation_Type_Id");
    }
    protected void fillRole()
    {
        string strQry = "Execute usp_setVacationList @type='fillRole',@intSchool_id='" + Session["School_id"] + "' ";
        bool stcardp = sBindDropDownList(ddlRole, strQry, "vchRole", "intRole_Id");
    }
    public object Createtable()
    {
        try
        {
            dsObj = new DataSet();
            if (chkAll.Checked)
            {
                strQry = "exec [usp_setVacationList] @type='FillData',@intSchool_id='" + Session["School_id"] + "',@year='" + Year + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            }
            else
            {
                strQry = "exec [usp_setVacationList] @type='FillData',@intSchool_id='" + Session["School_id"] + "',@month='" + Month + "',@year='" + Year + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            }
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
    protected void grvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Get the contents of bound column #4 ("Item4")...
            ImageButton lnkSelect = (ImageButton)e.Row.FindControl("ImgView");
            Label lblName = (Label)e.Row.FindControl("lblPath");
           // lnkSelect.Attributes.Add("onclick", "window.open('frmViewDoc.aspx?Path=Documents/Vacation&DocName=" + Convert.ToString(lblName.Text) + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=800,top=80,left=75');return false");

          //  lnkSelect.Attributes.Add("onclick", "window.open('frmViewDoc.aspx?Path=Documents/Vacation&DocName=" + Convert.ToString(lblName.Text) + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=500,top=150,left=500');return false");
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
    public void Clear()
    {
        txtToDt.Text = "";
        txtFrmDt.Text = "";
        txtNoOfdays.Text = "";
        ddlVacationType.ClearSelection();
        ddlRole.ClearSelection();
        btnSubmit.Text = "Submit";
        txtDesc.Text = "";
        txtName.Text = "";
        Session["FileUpload"] = null;
        Session["FileSize"] = null;
        Session["FileName"] = null;
        lblMesg.Text = "";
    }
    protected void txtToDt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DateTime frm = Convert.ToDateTime(txtFrmDt.Text);
            DateTime to = Convert.ToDateTime(txtToDt.Text);
            if (frm <= to)
            {
                TimeSpan t = new TimeSpan(1, 0, 0, 0);
                TimeSpan diff = (to.Date - frm.Date).Add(t);
                txtNoOfdays.Text = (diff).ToString();
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
                grvDetail.Columns[9].Visible = true;
                grvDetail.Columns[10].Visible = true;
                TabContainer1.Tabs[0].Visible = true;
                TabContainer1.Tabs[1].Visible = true;
                TabContainer1.Tabs[2].Visible = true;
               
            }
            else
            {
                grvDetail.Columns[0].Visible = false;
                grvDetail.Columns[9].Visible = false;
                grvDetail.Columns[10].Visible = false;

                TabContainer1.Tabs[0].Visible = true;
                TabContainer1.Tabs[1].Visible = true;
                TabContainer1.Tabs[2].Visible = false;
            }
        }
        catch
        {

        }
    }

    protected void CheckVacationDataset()
    {
        if (CalVacation.VisibleDate.Year == 0001)
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;

        }
        else
        {

            Year = CalVacation.VisibleDate.Year;
            if (CalVacation.VisibleDate.Month == 12)
            {
                Month = 1;
                Year = CalVacation.VisibleDate.Year + 1;
            }
            else
            {
                Month = CalVacation.VisibleDate.Month+1;
                Year = CalVacation.VisibleDate.Year;
            }
        }
        DateTime firstDate = new DateTime(Year, Month, 1);
        CalVacation.VisibleDate = new DateTime(Year, Month, 1);
        DateTime lastDate = GetFirstDayOfNextMonth();
        dsObj = GetCurrentMonthData(firstDate, lastDate);
    }
    
    protected void FillVacationDataset()
    {
        if (CalVacation.VisibleDate.Year == 0001)
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;

        }
        else
        {

            Year = CalVacation.VisibleDate.Year;

            Month = CalVacation.VisibleDate.Month;
            Year = CalVacation.VisibleDate.Year;
            //if (CalVacation.VisibleDate.Month == 1)
            //{
            //    Month = 12;
            //    Year = CalVacation.VisibleDate.Year - 1;
            //}
            //else
            //{
            //    Month = CalVacation.VisibleDate.Month;
            //    Year = CalVacation.VisibleDate.Year;
            //}
        }
        DateTime firstDate = new DateTime(Year, Month, 1);
        CalVacation.VisibleDate = new DateTime(Year, Month, 1);
        DateTime lastDate = GetFirstDayOfNextMonth();
        dsObj = GetCurrentMonthData(firstDate, lastDate);
    }

    protected DateTime GetFirstDayOfNextMonth()
    {
        DateTime lastDate;
        try
        {
            int monthNumber, yearNumber;
            if (CalVacation.VisibleDate.Month == 12)
            {
                monthNumber = 1;
                yearNumber = DateTime.Now.Year + 1;
            }
            else
            {
                monthNumber = CalVacation.VisibleDate.Month + 1;
                yearNumber = CalVacation.VisibleDate.Year;
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
            strQry = "";
            strQry = "exec [usp_setVacationList] @type='GetCalendarData',  @FirstDate='" + Convert.ToDateTime(FirstDt).ToString("yyyy/MM/dd") + "',@LastDate='" + Convert.ToDateTime(LastDt).ToString("yyyy/MM/dd") + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsCal = sGetDataset(strQry);
            return dsCal;
        }
        catch (Exception)
        {
            return dsObj;
        }
    }
    public string getIP()
    {
        string host = System.Net.Dns.GetHostName();
        string ip = "";
        System.Net.IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(host);
        System.Net.IPAddress[] addr = ipEntry.AddressList;
        for (int i = 0; i < addr.Length; i++)
        {
            if (addr[i].AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
                continue;
            ip= addr[i].ToString();
        }
        return ip;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();
            string Filepath = "";
             directoryPath = Server.MapPath(string.Format("~/{0}/", "Documents/Vacation"));
             Filepath =  filename;
            

            if (btnSubmit.Text == "Submit")
            {
                string frmDt = Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy"); // DateTime.ParseExact(txtFrmDt.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                string todt = Convert.ToDateTime(txtToDt.Text).ToString("MM/dd/yyyy");// DateTime.ParseExact(txtToDt.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                //Check Exist
                strQry = "exec [usp_setVacationList] @type='CheckExist',@vchVacation_name='" + Convert.ToString(txtName.Text).Trim() + "',@dtFromDate='" + frmDt + "',@dtToDate='" + todt + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Record Already Exist!");
                    return;
                }
                //End
                
                string ip = getIP();
                //string hostName = System.Net.Dns.GetHostName();
                //string myIPs = System.Net.Dns.GetHostEntry(hostName).HostName;


                // string UploadPath = System.IO.Path.GetFullPath(AttchFile.PostedFile.FileName);


                // strQry = "exec [usp_setVacationList] @type='InsertUpdate',@varDoc_Path='" + Convert.ToString("kk") + "',@intUserType_id='" + Session["UserType"] + "',@intUser_id='" + Session["UserId"] + "',@intInserted_id='" + Session["UserId"] + "',@vchInserted_IP='" + ip + "'";

                strQry = "";
                strQry = "exec [usp_setVacationList] @type='InsertUpdate',@intVacation_Type_Id='" + Convert.ToString(ddlVacationType.SelectedValue.Trim()) + "',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue.Trim()) + "',@vchVacation_name='" + Convert.ToString(txtName.Text.Trim()) + "',@dtFromDate='" + frmDt + "',@dtToDate='" + todt + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@Description='" + Convert.ToString(txtDesc.Text).Trim() + "',@intNoOfDay=" + Convert.ToString(txtNoOfdays.Text) + ",@intVacation_id='" + Session["id"] + "',@vchDocPath='" + Session["FileName"] + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchUpdatedIp='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Inserted Successfully!");

                    Month = DateTime.Now.Month;
                    Session["id"] = null;
                    Year = DateTime.Now.Year;
                    Fillgrid();
                    FillVacationDataset();
                    btnSubmit.Text = "Submit";
                    Clear();

                }
                else
                {
                    MessageBox("Insertion Failed");

                }

            }
            if (btnSubmit.Text == "Update")
            {
                string frmDt = Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy"); // DateTime.ParseExact(txtFrmDt.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                string todt = Convert.ToDateTime(txtToDt.Text).ToString("MM/dd/yyyy");// DateTime.ParseExact(txtToDt.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                //Check Exist
              //  strQry = "exec [usp_setHolidayList]  @type='CheckUpdateExist',@vchHoliday_name='" + Convert.ToString(txtName.Text).Trim() + "',@dtFromDate='" + frmDt + "',@dtToDate='" + todt + "',@intHoliday_id='" + Session["id"] + "',@intSchool_id='" + Session["School_id"] + "'";
                strQry = "exec [usp_setVacationList] @type='CheckUpdateExist',@vchVacation_name='" + Convert.ToString(txtName.Text).Trim() + "',@dtFromDate='" + frmDt + "',@dtToDate='" + todt + "',@intVacation_id='" + Session["id"] + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Record Already Exist!");
                    return;
                }
                //End

               
                string ip = getIP();
                //string hostName = System.Net.Dns.GetHostName();
                //string myIPs = System.Net.Dns.GetHostEntry(hostName).HostName;


                // string UploadPath = System.IO.Path.GetFullPath(AttchFile.PostedFile.FileName);


                // strQry = "exec [usp_setVacationList] @type='InsertUpdate',@varDoc_Path='" + Convert.ToString("kk") + "',@intUserType_id='" + Session["UserType"] + "',@intUser_id='" + Session["UserId"] + "',@intInserted_id='" + Session["UserId"] + "',@vchInserted_IP='" + ip + "'";

                strQry = "";
                strQry = "exec [usp_setVacationList] @type='InsertUpdate',@intVacation_Type_Id='" + Convert.ToString(ddlVacationType.SelectedValue.Trim()) + "',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue.Trim()) + "',@vchVacation_name='" + Convert.ToString(txtName.Text.Trim()) + "',@dtFromDate='" + frmDt + "',@dtToDate='" + todt + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@Description='" + Convert.ToString(txtDesc.Text).Trim() + "',@intNoOfDay=" + Convert.ToString(txtNoOfdays.Text) + ",@intVacation_id='" + Session["id"] + "',@vchDocPath='" + Session["FileName"] + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchUpdatedIp='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");

                    Month = DateTime.Now.Month;
                    Session["id"] = null;
                    Year = DateTime.Now.Year;
                    Fillgrid();
                    FillVacationDataset();
                    btnSubmit.Text = "Submit";
                    Clear();

                }
                else
                {
                    MessageBox("Insertion Failed");

                }
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
            Session["id"] = grvDetail.DataKeys[e.NewEditIndex].Value;
            dsObj = new DataSet();
            strQry = "exec [usp_setVacationList] @type='SelectData',@intVacation_id='" + id + "',@intSchool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtDesc.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Description"]);
                txtFrmDt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtFromDate"]);
                txtToDt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtToDate"]);
                ddlVacationType.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intVacation_Type_Id"]);
                ddlRole.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRole_Id"]);
                txtName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchVacation_name"]);
                txtNoOfdays.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intNoOfDay"]);
                TabContainer1.ActiveTabIndex = 2;
                btnSubmit.Text = "Update";
            }

        }
        catch (Exception)
        {
            
            throw;
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
    protected void AttchFile_Load(object sender, EventArgs e)
    {
        
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            id = Convert.ToInt32(grvDetail.DataKeys[e.RowIndex].Value);
            Session["Deleteid"] = grvDetail.DataKeys[e.RowIndex].Value;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "ConfirmMessage", " messageConfirm('Do you want to Delete this Record ?')", true);
            //string ans = Request.Form["confirm_value"].Substring(0, 3);

            //if (ans == "Yes")
            //{
            strQry = "exec [usp_setVacationList]  @type='Delete',@intVacation_id='" + id + "',@intSchool_id='" + Session["School_id"] + "',@vchDeletedIp='" + GetSystemIP() + "',@intDeletedBy='" + Session["User_Id"] + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Deleted Successfully");
                    Fillgrid();
                   // ans = "";
                }
            //}
        }
        catch
        {


        }
    }
    protected void FileUploadComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
       
           
    }
    protected void grvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ImageCall")
            {
               
                GridView grid = sender as GridView;
                ImageButton view = e.CommandSource as ImageButton;
                Session["DocName"] = Convert.ToString(e.CommandArgument);
                Session["DocPath"] = "Documents/Vacation&DocName";
                string page = Convert.ToString(Session["DocName"]);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "onclick", "javascript:window.open( 'frmViewDoc.aspx?Path=Documents/Vacation','_blank','height=600px,width=600px,scrollbars=1');", true);
                //view.Attributes.Add("onclick", "window.open('frmViewDoc.aspx?Path=Documents/Vacation&DocName=" + lblPath + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=800,top=90,left=100');return false");
            
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
                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#E67c7c");
            }

            Boolean bln=false;
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
                Fillgrid();
               FillVacationDataset();
            }
            catch
            {

            }
        }
        catch
        {

        }
    }
    protected void CalVacation_SelectionChanged(object sender, EventArgs e)
    {
      
    }
    protected void CalVacation_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        try
        {
            FillVacationDataset();
        }
        catch 
        {
        }
    }
    protected void ImgView_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
           // ModalPopupExtender1.Show();
        }
        catch 
        {
            
        }
    }
    protected void btnOk_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
           // ModalPopupExtender1.Hide();
        }
        catch 
        {
            
        }
    }
    protected void grvDetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton pop = e.Row.FindControl("ImgView") as ImageButton;
            pop.CommandArgument = e.Row.RowIndex.ToString();

        }
    }

    protected void ImgXls_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ClsExportExcel pdf = new ClsExportExcel();
            grvDetail.Columns[0].Visible = false;
            grvDetail.Columns[1].Visible = false;
            grvDetail.Columns[2].Visible = false;
            switch (TabContainer1.ActiveTabIndex)
            {
                case 1:
                    //ExportGrid(grvDetail, "Vacation " + DateTime.Now + ".xls", "application/vnd.ms-excel");
                    //break;
                    pdf.ExportGrid(grvDetail, " Vacation List" + " " + DateTime.Now.ToShortDateString(), 0, "", "", "", "1", "Vacation List");

                      strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='Vacation List',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["User_id"] + "',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";

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
    protected void ImgPdf_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ClsExportPdf pdf = new ClsExportPdf();
            grvDetail.Columns[0].Visible = false;
            grvDetail.Columns[1].Visible = false;
            grvDetail.Columns[2].Visible = false;
            switch (TabContainer1.ActiveTabIndex)
            {
                case 1:
                   // ExportGridToPDF(grvDetail, "Vacation " + DateTime.Now + ".pdf", "application/pdf");
                  //  break;
                    pdf.Page_Load(null, null, grvDetail, " Vacation List" + " " + DateTime.Now.ToShortDateString(), 0, "", "", "", "1", "Vacation List");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='Vacation List',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["User_id"] + "',@vchReportFormat='.pdf',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";

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
                    ExportToWord(grvDetail, "Vacation " + DateTime.Now + ".doc");
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
                    filename = Session["FileName"].ToString();
                    directoryPath = Server.MapPath(string.Format("~/{0}/", "Documents/Vacation"));
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
    protected void grvDetail_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            try
            {
                if (e.CommandName == "Detail")
                {
                    ImageButton View = (ImageButton)e.CommandSource;
                    string id = Convert.ToString(Convert.ToString(e.CommandArgument.ToString()));
                    Session["Id"] = Convert.ToString(id);
                    string path = "~//Documents/Vacation//";
                    //    //  string a =e.Row.c
                    //    View.Attributes.Add("onclick", "window.open('frmViewDoc.aspx?Path=" + path + "&DocName=" + Session["id"].ToString() + ",'_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=800,top=80,left=75');return false");
                    //    View.Attributes.Add("onclick", "window.open('frmTrainingDetail.aspx?TrainingId=12','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=800,top=80,left=75');return false");
                    // Response.Redirect("frmViewDoc.aspx?Path=" + path + "&DocName=" + Session["Id"].ToString() + "");

                    if (Convert.ToString(Session["Id"]) != "")
                    {
                        Response.Redirect("frmViewDoc.aspx?Path=" + path + "&DocName=" + Session["Id"].ToString() + "");
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
        catch 
        {
        }
    }
}
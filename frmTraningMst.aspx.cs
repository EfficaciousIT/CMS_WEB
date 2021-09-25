using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;

public partial class frmTraningMst :DBUtility
{
    string strQry = "";
    DataSet dsObj,dsGrid,dsCal,dsSearch;
    int Err = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //grvDetail.DataSource = CreateDatatable();
        //grvDetail.DataBind();
        if (Session["UserType_id"] != null && Session["User_Id"] != null)
        {
            //Label lblTitle = new Label();
            //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            //lblTitle.Visible = true;
            //lblTitle.Text = "Training Detail";

            if (!IsPostBack)
            {
            
                if (FileUploadApp.HasFile)
                    FileUploadApp.ClearAllFilesFromPersistedStore();
                    FillGrid();
                FillDIV();
                FillSTD();
                FillUserType();
                FillDept();
                divChecklist.Visible = false;
                chkAll.Visible = false;
                
            }
            
            FillTrainingDataset();
        }
        else
        {
            Response.Redirect("~\\frmIndex.aspx", false);
        }

    }
    public void FillGrid()
    {
        try
        {
            strQry="";
            if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                strQry = "exec [usp_TrainingMst] @type='FillGrid',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "4" || Convert.ToString(Session["UserType_Id"]) == "3")
            {
                strQry = "exec [usp_TrainingMst] @type='FillGrid',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intTeacher_id='" + Convert.ToString(Session["User_id"]) + "'";

            }
            else if (Convert.ToString(Session["UserType_Id"]) == "2")
            {
                strQry = "exec [usp_TrainingMst] @type='FillGrid',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intParent_id='" + Convert.ToString(Session["User_id"]) + "'";
            }
            else
            {
                strQry = "exec [usp_TrainingMst] @type='FillGrid',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
            }
            dsGrid = sGetDataset(strQry);
            if (dsGrid.Tables[0].Rows.Count > 0)
            {

                grvDetail.DataSource = dsGrid;
                grvDetail.DataBind();

                if (Convert.ToString(Session["UserType_Id"]) != null)
                {
                    if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
                    {
                        //grvDetail.Columns[0].Visible = true;
                        grvDetail.Columns[1].Visible = true;
                        TabContainer1.Tabs[0].Visible = true;
                        TabContainer1.Tabs[1].Visible = true;
                        TabContainer1.Tabs[2].Visible = true;
                    }
                    else
                    {
                        // grvDetail.Columns[0].Visible = false;
                        grvDetail.Columns[1].Visible = false;
                        grvDetail.Columns[2].Visible = false;
                        TabContainer1.Tabs[0].Visible = true;
                        TabContainer1.Tabs[1].Visible = true;
                        TabContainer1.Tabs[2].Visible = false;
                    }
                }
            }
            else
            {
                if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
                {
                    //grvDetail.Columns[0].Visible = true;
                    //grvDetail.Columns[1].Visible = true;
                    TabContainer1.Tabs[0].Visible = true;
                    TabContainer1.Tabs[1].Visible = true;
                    TabContainer1.Tabs[2].Visible = true;
                }
                else
                {
                    // grvDetail.Columns[0].Visible = false;
                    //grvDetail.Columns[1].Visible = false;
                    //grvDetail.Columns[2].Visible = false;
                    TabContainer1.Tabs[0].Visible = true;
                    TabContainer1.Tabs[1].Visible = true;
                    TabContainer1.Tabs[2].Visible = false;
                }
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
            strQry = "exec usp_FillDropDown @type='STD',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            ddlSTD.DataSource = dsObj;
           
            ddlSTD.DataTextField = "vchStandard_name";
            ddlSTD.DataValueField = "intstandard_id";
            ddlSTD.DataBind();

            if (dsObj.Tables[0].Rows.Count > 0)
            ddlSTD.Items.Insert(0, new ListItem("All", "-1"));
            else
            ddlSTD.Items.Insert(0, new ListItem("Select", "0"));
           
        }
        catch 
        {
           
        }
    }

    public void FillDIV()
    {
        try
        {
            if (ddlSTD.SelectedValue == "-1")
            {
                strQry = "exec usp_FillDropDown @type='DIV',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            }
            else
            {
                strQry = "exec usp_FillDropDown @type='DIV',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue == "-1" ? null : ddlSTD.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            }
            ddlDiv.DataSource = null;
            ddlDiv.DataBind();
            dsObj = sGetDataset(strQry);
            ddlDiv.DataSource = dsObj;
          
            ddlDiv.DataValueField = "intDivision_id";
            ddlDiv.DataTextField = "vchDivisionName";
            ddlDiv.DataBind();

            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ddlDiv.Items.Insert(0, new ListItem("All", "-1"));
               // chkAll.Visible = true;
            }
            else
            {
                chkAll.Visible = false;
                chkNameList.Items.Clear();
            }

            ddlDiv.Items.Insert(0,new ListItem("Select", "0"));
          
          //  ddlDiv.Items.Add("Select");
        }
        catch
        {

        }
    }

    public void FillDept()
    {
        try
        {
            strQry = "exec usp_FillDropDown @type='TrainingDepartment',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intUserType='" + Convert.ToString(ddlType.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            ddlDept.DataSource = dsObj;
           
            ddlDept.DataTextField = "vchDepartment_name";
            ddlDept.DataValueField = "intDepartment";
            ddlDept.DataBind();

            if (dsObj.Tables[0].Rows.Count > 0)
            ddlDept.Items.Insert(0, new ListItem("All", "-1"));

            ddlDept.Items.Insert(0, new ListItem("Select", "0"));
           
        }
        catch
        {

        }
    }

    public void FillUserType()
    {
        try
        {
            strQry = "exec [usp_FillDropDown]  @type='UserType',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlType, strQry, "vchUser_name", "intUserType_id");
        }
        catch 
        {
            
        }
    }

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            chkAll.Visible = false;
            chkNameList.Visible = false;

            if (ddlType.SelectedValue == "1")
            {
                ddlDept.Visible = false;
                txtPName.Visible = false;
                lblDept.Visible = false;
                lblPName.Visible = false;

                lblName.Text = "Student Name";

                //ddlName.Visible = true;
                ddlName.Visible = false;

                lblName.Visible = true;

                ddlSTD.Visible = true;
                ddlDiv.Visible = true;
                ddlSTD.SelectedValue = "0";
                ddlDiv.SelectedValue = "0";
                lblSTD.Visible = true;
                lblDiv.Visible = true;
               // FillStudent();
            }
            else if (ddlType.SelectedValue == "3" || ddlType.SelectedValue == "4")
            {
                FillDept();
                ddlDept.Visible = true;
                ddlDept.SelectedValue = "0";
                txtPName.Visible = false;
                lblDept.Visible = true;
                lblPName.Visible = false;

                lblName.Text = "Staff Name";

               // ddlName.Visible = true;
                ddlName.Visible = false;
                lblName.Visible = true;

              
                ddlSTD.Visible = false;
                ddlDiv.Visible = false;
                
                lblSTD.Visible = false;
                lblDiv.Visible = false;
                
              //  FillTeacher();
            }
            else if (ddlType.SelectedValue == "2")
            {
                ddlDept.Visible = false;
               // txtPName.Visible = true;
                lblDept.Visible = false;
                //lblPName.Visible = true;

                lblName.Text = "Student Name";

                //ddlName.Visible = true;
                ddlName.Visible = false;
                lblName.Visible = true;

              
                ddlSTD.Visible = true;
                ddlDiv.Visible = true;
                lblSTD.Visible = true;
                lblDiv.Visible = true;
                ddlSTD.SelectedValue = "0";
                ddlDiv.SelectedValue = "0";
              //  FillStudent();
            }
          
            chkAll.Visible = false;
        }
            
        catch 
        {
            
           
        }
    }
   
  
    protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlType.SelectedValue == "2")
            {
                strQry = "";
                if(ddlName.SelectedValue == "-1" )
                {
                    strQry = "exec usp_FillDropDown @type='SelectParent',@intDiv_id='" + Convert.ToString(ddlDiv.SelectedValue == "-1" ? null : ddlDiv.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                }
                else
                {
                    strQry = "exec usp_FillDropDown @type='SelectParent',@intDiv_id='" + Convert.ToString(ddlDiv.SelectedValue == "-1" ? null : ddlDiv.SelectedValue) + "',@parameter='" + Convert.ToString(ddlName.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                }
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 1)
                {
                    txtPName.Text = "All";
                }
                else if (dsObj.Tables[0].Rows.Count > 0)
                {
                    txtPName.Text = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
                }
            }
        }
        catch 
        {
            
           
        }
    }
    protected void FillTrainingDataset()
    {
        int Month, Year;

        if (CalTraining.VisibleDate.Year == 0001)
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;

        }
        else
        {
            Year = CalTraining.VisibleDate.Year;
            Month = CalTraining.VisibleDate.Month;
        }
        DateTime firstDate = new DateTime(Year, Month, 1);
        CalTraining.VisibleDate = new DateTime(Year, Month, 1);
        DateTime lastDate = GetFirstDayOfNextMonth();
        dsObj = GetCurrentMonthData(firstDate, lastDate);
    }
    protected DateTime GetFirstDayOfNextMonth()
    {
        DateTime lastDate;
        try
        {
            int monthNumber, yearNumber;
            if (CalTraining.VisibleDate.Month == 12)
            {
                monthNumber = 1;
                yearNumber =DateTime.Now.Year + 1;
            }
            else
            {
                monthNumber = CalTraining.VisibleDate.Month + 1;
                yearNumber = CalTraining.VisibleDate.Year;
            }
             lastDate = new DateTime(yearNumber, monthNumber, 1);
            return lastDate;
        }
        catch (Exception ex)
        {
            DateTime a=new DateTime(2014, 1, 1);
            return a;
            
        }
       
    }

    public DataSet GetCurrentMonthData(DateTime FirstDt, DateTime LastDt)
    {
        try
        {
            strQry = "";
            strQry = "exec usp_CalendarTraining  @FirstDate='" + Convert.ToDateTime(FirstDt).ToString("yyyy/MM/dd") + "',@LastDate='" + Convert.ToDateTime(LastDt).ToString("yyyy/MM/dd") + "',@SchoolId='" + Convert.ToString(Session["School_id"]) + "'";
            if (Convert.ToString(Session["UserType_Id"]) == "3" || Convert.ToString(Session["UserType_Id"]) == "4")
            {
                strQry = strQry + ",@intTeacher_id='" + Convert.ToString(Session["User_Id"]) + "'";
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "2")
            {
                strQry = strQry + ",@intParent_id='" + Convert.ToString(Session["User_Id"]) + "'";
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "1")
            {
                strQry = strQry + ",@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
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
            if (e.Day.Date.DayOfWeek.ToString() == "Sunday")
            {
                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#E67c7c");
            }
            DateTime nextDate;
            if (dsCal != null)
            {
                foreach (DataRow dr in dsCal.Tables[0].Rows)
                {
                    nextDate = (DateTime)dr["Date"];
                    if (nextDate == e.Day.Date)
                    {
                        e.Cell.BackColor = System.Drawing.Color.Pink;
                        e.Cell.ToolTip = (string)dr["Title"];
                        //  e.Cell.Attributes.Add((string)dr["Name"], "1");
                    }
                }
            }
        }
        catch (Exception)
        {


        }
    
        //switch (e.Day.Date.ToString("dd/MM/yyyy"))
        //{


        //    case "19/09/2014":
        //        e.Cell.ToolTip = "Dance Training";
                
        //        e.Cell.Font.Bold = true;
        //        e.Cell.BackColor = System.Drawing.Color.Lavender;
        //        break;
        //    case "20/09/2014":
        //        e.Cell.ToolTip = "Dance Training";
        //        e.Cell.BackColor = System.Drawing.Color.Lavender;
               
        //        e.Cell.Font.Bold = true;
        //        break;
        //    case "01/10/2014":
        //        e.Cell.ToolTip = "Parents Meeting";
               
        //        e.Cell.Font.Bold = true;
        //        e.Cell.BackColor = System.Drawing.Color.LemonChiffon;
        //        break;

        //}

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        FillTrainingDataset();
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(grvDetail.DataKeys[e.NewEditIndex].Value);
            Session["TrainingId"] = Convert.ToInt32(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec [usp_TrainingMst] @type='GetSelectedData',@intTraining_id='" + id + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            dsGrid = sGetDataset(strQry);
            if (dsGrid.Tables[0].Rows.Count > 0)
            {
                txtTitle.Text = Convert.ToString(dsGrid.Tables[0].Rows[0]["varTitle"]);
                txtTrainingName.Text = Convert.ToString(dsGrid.Tables[0].Rows[0]["varName"]);
                txtDesc.Text = Convert.ToString(dsGrid.Tables[0].Rows[0]["varDesc"]);
                txtFrmDt.Text = Convert.ToString(dsGrid.Tables[0].Rows[0]["FrmDt"]);
                txtToDate.Text = Convert.ToString(dsGrid.Tables[0].Rows[0]["ToDt"]);
                //txtStime.Text = Convert.ToDateTime(dsGrid.Tables[0].Rows[0]["STime"]).ToString("HH:MM t.\\M");
                //txtEtime.Text = Convert.ToDateTime(dsGrid.Tables[0].Rows[0]["ETime"]).ToString("HH:MM t.\\M");
                txtStime.Text = DateTime.ParseExact(Convert.ToDateTime(dsGrid.Tables[0].Rows[0]["STime"]).ToString("HH:MM"), "HH:mm", CultureInfo.CurrentCulture).ToString("hh:mm tt");
                txtEtime.Text = DateTime.ParseExact(Convert.ToDateTime(dsGrid.Tables[0].Rows[0]["ETime"]).ToString("HH:MM"), "HH:mm", CultureInfo.CurrentCulture).ToString("hh:mm tt");
                TabContainer1.ActiveTabIndex = 2;
                btnSubmit.Text = "Update";

                strQry = "";
                strQry = "exec [usp_TrainingMst] @type='FillAddGrid',@intTraining_id='" + id + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                dsGrid = new DataSet();
                dsGrid = sGetDataset(strQry);
                if (dsGrid.Tables[0].Rows.Count > 0)
                {
                    VisibleFalseTrue(true);
                    grvAdd.DataSource = dsGrid;
                    grvAdd.DataBind();
                    Session["OldTable"] =dsGrid.Tables[0];
                    VisibleFalseTrue(false);
                }
            }
            FillTrainingDataset();
        }
        catch 
        {
            
           
        }

    }
    protected void grvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label id = (Label)e.Row.FindControl("lblid");
            //    Session["Id"] = Convert.ToString(id.Text);
            //    LinkButton lnkBtn = (LinkButton)e.Row.FindControl("LnkDetail");

            //    lnkBtn.Attributes.Add("onclick", "window.open('frmTrainingDetail.aspx','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=800,top=80,left=75');return false");
            //}

            
        }
        catch (Exception)
        {
            
            throw;
        }
       
    }

    public void FillStudent()
    {
        try
        {
            if (ddlDiv.SelectedValue == "-1")
            {
                strQry = "exec usp_FillDropDown @type='GetStudents',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            }
            else
            {
                strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDiv.SelectedValue == "-1" ? null : ddlDiv.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            }
            ddlName.DataSource = null;
            ddlName.DataBind();

            dsObj = sGetDataset(strQry);
            ddlName.DataSource = dsObj;

            ddlName.DataValueField = "intStudent_id";
            ddlName.DataTextField = "Name";
            ddlName.DataBind();

            chkNameList.DataSource = dsObj;
            chkNameList.DataTextField = "Name";
            chkNameList.DataValueField = "intStudent_id";
            chkNameList.DataBind();

            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ddlName.Items.Insert(0, new ListItem("All", "-1"));
                //chkNameList.Items.Insert(0, new ListItem("All", "-1"));
                chkAll.Visible = true;
                chkNameList.Visible = true;
            }
            else
            {
                chkAll.Visible = false;
                chkNameList.Visible = false;
            }

            ddlName.Items.Insert(0, new ListItem("Select", "0"));


            
        }
        catch
        {
            
          
        }
    }
    public void FillTeacher()
    {
        try
        {
            if (ddlDept.SelectedValue == "-1")
            {
                strQry = "exec usp_FillDropDown @type='GetStaff',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intUserType='" + Convert.ToString(ddlType.SelectedValue) + "'";
            }
            else
            {
                strQry = "exec usp_FillDropDown @type='GetStaff',@intDept_id='" + Convert.ToString(ddlDept.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intUserType='" + Convert.ToString(ddlType.SelectedValue) + "'";
            }


            dsObj = sGetDataset(strQry);
            ddlName.DataSource = dsObj;

            ddlName.DataValueField = "intTeacher_id";
            ddlName.DataTextField = "Name";
            ddlName.DataBind();

            chkNameList.DataSource = dsObj;
            chkNameList.DataTextField = "Name";
            chkNameList.DataValueField = "intTeacher_id";
            chkNameList.DataBind();

            if (dsObj.Tables[0].Rows.Count > 0)
            {
                divChecklist.Visible = true;
                ddlName.Items.Insert(0, new ListItem("All", "-1"));
                // chkNameList.Items.Insert(0, new ListItem("All", "-1"));
                chkAll.Visible = true;
                chkNameList.Visible = true;
            }
            else
            {
                divChecklist.Visible = false;
                chkAll.Visible = false;
                chkNameList.Visible = false;
            }


            ddlName.Items.Insert(0, new ListItem("Select", "0"));
           
        }
        catch
        {


        }
    }


    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillDIV();
            chkAll.Visible = false;
            chkNameList.Visible = false;
            if (ddlSTD.SelectedValue == "-1")
            {
                ddlDiv.SelectedValue = "-1";
                ddlDiv.Enabled = false;
                FillStudent();
                ddlName.SelectedValue = "-1";
                ddlName.Enabled = false;
                divChecklist.Visible = false;
                chkAll.Checked = true;
                chkAll.Enabled = false;
                return;
            }
            else
            {
                ddlDiv.Enabled = true;
                ddlDiv.SelectedValue = "0";

                ddlName.SelectedValue = "0";
                ddlName.Enabled = true;
                divChecklist.Visible = true;
                chkAll.Checked = false;
                chkAll.Enabled = true;
                return;
            }

           
        }
        catch (Exception)
        {
            
        }
    }
    protected void ddlDiv_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillStudent();
            if (ddlDiv.SelectedValue == "-1")
            {

                ddlName.SelectedValue = "-1";
                ddlName.Enabled = false;
                divChecklist.Visible = false;
                chkAll.Checked = true;
                chkAll.Enabled = false;
            }
            else
            {
                ddlName.SelectedValue = "0";
                ddlName.Enabled = true;
                divChecklist.Visible = true;
                chkAll.Checked = false;
                chkAll.Enabled = true;
            }
        }
        catch
        {
            
           
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

    public void InsertUpdate(int LastId)
    {
         Err = 0;
        try
        {
            
            Boolean bln = false;
            
            strQry = "";
             if (grvAdd.Rows.Count > 0)
             {
                        
                        for (int i = 0; i < grvAdd.Rows.Count; i++)
                        {
                            if (grvAdd.Rows[i].Cells[8].Text == "1" || grvAdd.Rows[i].Cells[8].Text == "2")
                            {
                                strQry = "";

                                strQry = "";
                                strQry = "exec usp_TrainingMst @type='InsertSub',@intTraining_id='" + Convert.ToString(LastId) + "',@intTeacher_id='" + null + "',@intDept_id='" + null + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@intUserType='" + Convert.ToString(grvAdd.Rows[i].Cells[8].Text) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";

                                if (grvAdd.Rows[i].Cells[12].Text != "-1")//All STD 
                                {
                                    strQry = strQry + ",@intSTD_id='" + Convert.ToString(grvAdd.Rows[i].Cells[12].Text) + "'";
                                }
                                if (grvAdd.Rows[i].Cells[13].Text != "-1") //All Particular STD & All DIV
                                {
                                    strQry = strQry + ",@intDiv_id='" + Convert.ToString(grvAdd.Rows[i].Cells[13].Text) + "'";

                                }
                                 if (grvAdd.Rows[i].Cells[2].Text != "-1")
                                {
                                    strQry = strQry + ",@intStudent_id='" + Convert.ToString(grvAdd.Rows[i].Cells[2].Text) + "'";
                                }
                                 if (grvAdd.Rows[i].Cells[10].Text != "-1")
                                {
                                    strQry = strQry + ",@intParent_id='" + Convert.ToString(grvAdd.Rows[i].Cells[10].Text) + "'";
                                }

                                if (sExecuteQuery(strQry) != -1)
                                {
                                    // MessageBox("Record Saved Successfully ! ");
                                    bln = true;
                                }
                                else
                                {
                                    MessageBox("Insertion Failed! ");
                                    bln = false;
                                    return;
                                }
                            }
                        
                            else
                            {
                                strQry = "";
                                

                                //if (strQry != "")
                                //{
                                    //dsObj = sGetDataset(strQry);
                                    //if (dsObj.Tables[0].Rows.Count > 0)
                                    //{
                                    //    for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                                    //    {

                                            strQry = "";
                                            strQry = "exec usp_TrainingMst @type='InsertSub',@intTraining_id='" + Convert.ToString(LastId) + "',@intSTD_id='" + null + "',@intDiv_id='" + null + "',@intStudent_id='" + null + "',@intParent_id='" + null + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@intUserType='" + Convert.ToString(grvAdd.Rows[i].Cells[8].Text) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";

                                            if (grvAdd.Rows[i].Cells[11].Text != "-1" && grvAdd.Rows[i].Cells[11].Text != "0")
                                            {
                                                strQry = strQry + ",@intTeacher_id='" + Convert.ToString(grvAdd.Rows[i].Cells[11].Text) + "'";
                                            }


                                            if (grvAdd.Rows[i].Cells[11].Text != "-1" && grvAdd.Rows[i].Cells[11].Text != "0")
                                            {
                                                strQry = strQry + ",@intDept_id='" + Convert.ToString(grvAdd.Rows[i].Cells[11].Text) + "'";
                                            }

                                            if (sExecuteQuery(strQry) != -1)
                                            {
                                                // MessageBox("Record Saved Successfully ! ");
                                                bln = true;
                                            }
                                            else
                                            {
                                                bln = true;
                                                MessageBox("Insertion Failed! ");
                                                return;
                                            }
                                    //    }
                                    //}
                                //}
                                //else
                                //{
                                //    strQry = "exec usp_TrainingMst @type='InsertSub',@intTraining_id='" + Convert.ToString(LastId) + "',@intSTD_id='" + null + "',@intDiv_id='" + null + "',@intStudent_id='" + null + "',@intTeacher_id='" + Convert.ToString(grvAdd.Rows[i].Cells[11].Text) + "',@intParent_id='" + null + "',@intDept_id='" + Convert.ToString(grvAdd.Rows[i].Cells[9].Text) + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@intUserType='" + Convert.ToString(grvAdd.Rows[i].Cells[8].Text) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";


                                //    if (sExecuteQuery(strQry) != -1)
                                //    {
                                //        // MessageBox("Record Saved Successfully ! ");
                                //        bln = true;
                                //    }
                                //    else
                                //    {
                                //        MessageBox("Insertion Failed! ");
                                //        bln = false;
                                //        return;
                                //    }
                                //}



                            }


                        }



                        if (bln == true)
                        {
                            MessageBox("Record Saved Successfully ! ");
                        }
                        else
                        {
                            MessageBox("Insertion Failed! ");
                        }
                    }
        }
        catch (Exception ex)
        {
            Err = 1;
            MessageBox(ex.Message);
        }
    }

    public void Clear()
    {
        try
        {
            txtDesc.Text = "";
            txtEtime.Text = "";
            txtFrmDt.Text = "";
            txtPName.Text = "";
            txtStime.Text = "";
            txtTitle.Text = "";
            txtToDate.Text = "";
            txtTrainingName.Text = "";
            ddlDept.SelectedValue = "0";
            ddlDiv.SelectedValue = "0";
            ddlSTD.SelectedValue = "0";
            ddlType.SelectedValue = "0";
            ddlDept.Visible = false;
            ddlDiv.Visible = false;
            ddlSTD.Visible = false;
            chkAll.Visible = false;
            chkNameList.Visible = false;
            grvAdd.DataSource = null;
            grvAdd.DataBind();
            Session["OldTable"]=null;
            btnSubmit.Text = "Submit";
            lblDiv.Visible = false;
            lblSTD.Visible = false;
            lblName.Visible = false;
            lblDept.Visible = false;
            geturl();
        }
        catch 
        {
            
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();
            if (grvAdd.Rows.Count == 0 || grvAdd.Rows.Count == 0)
            {
                MessageBox("Please Add At Least One People");
                FillTrainingDataset();
                return;
            }

            string Filepath = "";
            string directoryPath = Server.MapPath(string.Format("~/{0}/", "Documents/Training"));
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (FileUploadApp.HasFile)
            {
                if (Directory.Exists(directoryPath + FileUploadApp.PostedFile.FileName))
                {
                    Directory.Delete(directoryPath + FileUploadApp.PostedFile.FileName);
                }

                FileUploadApp.SaveAs(directoryPath + FileUploadApp.PostedFile.FileName);
                Filepath = directoryPath + FileUploadApp.PostedFile.FileName;
            }

            if (btnSubmit.Text == "Update")
            {
                strQry = "";
                strQry = "exec usp_TrainingMst  @type='CheckUpdateExist',@intTraining_id='" + Session["TrainingId"] + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@varName='" + Convert.ToString(txtTrainingName.Text) + "',@varTitle='" + Convert.ToString(txtTitle.Text) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Record Already Exist With Same Title And Name");
                    return;
                }


                strQry = "";
                strQry = "exec usp_TrainingMst @type='DeleteAllMembers',@intTraining_id='" + Session["TrainingId"] + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@vchDeletedIp='" + GetSystemIP() + "'";

                if (sExecuteQuery(strQry) != -1)
                {
                    strQry = "";
                    strQry = "exec usp_TrainingMst @type='UpdateMain',@varTitle='" + Convert.ToString(txtTitle.Text) + "',@varName='" + Convert.ToString(txtTrainingName.Text) + "',@varDesc='" + Convert.ToString(txtDesc.Text) + "',@dtFrm_Date='" + Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy") + "',@dtTo_Date='" + Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy") + "',@dtFrm_Time='" + Convert.ToDateTime(txtStime.Text).ToString("HH:MM") + "',@dtTo_Time='" + Convert.ToDateTime(txtEtime.Text).ToString("HH:MM") + "',@intUserType='" + Convert.ToString(ddlType.SelectedValue) + "',@intDoc_id='" + Convert.ToString("1") + "',@intUpdatedBy='" + Session["User_Id"] + "',@vchUpdatedIp='" + GetSystemIP() + "',@intTraining_id='" + Session["TrainingId"] + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "', @varDoc_Path='" + Session["FileUpload"] + "'";
                    if (sExecuteQuery(strQry) != -1)
                    {
                        int LastId = (int)Session["TrainingId"];


                        InsertUpdate(LastId);


                        if (Err == 1)
                        {
                            MessageBox("Insertion Failed");
                            return;
                            Err = 0;
                        }

                    }
                }
            }

            else if (btnSubmit.Text == "Submit")
            {

                strQry = "";
                strQry = "exec usp_TrainingMst  @type='CheckSaveExist',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@varName='" + Convert.ToString(txtTrainingName.Text) + "',@varTitle='" + Convert.ToString(txtTitle.Text) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Record Already Exist With Same Title And Name");
                    return;
                }


                Boolean bln = false;
                int LastId=0;
                strQry = "";
                strQry = "exec usp_TrainingMst @type='InsertMain',@varTitle='" + Convert.ToString(txtTitle.Text) + "',@varName='" + Convert.ToString(txtTrainingName.Text) + "',@varDesc='" + Convert.ToString(txtDesc.Text) + "',@dtFrm_Date='" + Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy") + "',@dtTo_Date='" + Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy") + "',@dtFrm_Time='" + Convert.ToDateTime(txtStime.Text).ToString("HH:MM") + "',@dtTo_Time='" + Convert.ToDateTime(txtEtime.Text).ToString("HH:MM") + "',@intUserType='" + Convert.ToString(ddlType.SelectedValue) + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "', @varDoc_Path='" + Session["FileUpload"] + "'";

                //--------Get Last Inserted id-------//
                if (sExecuteQuery(strQry) != -1)
                {
                  
                    strQry = "";
                    strQry = "exec usp_TrainingMst @type='LastInsertId',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        LastId = Convert.ToInt32(dsObj.Tables[0].Rows[0][0]);
                    }
                }
                   
                else
                {
                    if (FileUploadApp.HasFile)
                        FileUploadApp.ClearAllFilesFromPersistedStore();
                    return;
                }
                //---------End---------//
                    strQry = "";
                //
                //------Commented Code Paste Here------//
                //
                    if (Convert.ToString(ddlType.SelectedValue) != "-1")
                    {
                        InsertUpdate(LastId);
                    }
                    else
                    {
                        strQry = "exec [usp_TrainingMst] @type='InsertSub',@intTraining_id='" + LastId + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@intUserType='" + Convert.ToString(Session["UserType_Id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                        if (sExecuteQuery(strQry) != -1)
                        {
                            MessageBox("Record Saved Successfully!");
                            FillGrid();
                            FillTrainingDataset();
                            Calendar1_DayRender(null, null);
                            Clear();
                            if (FileUploadApp.HasFile)
                                FileUploadApp.ClearAllFilesFromPersistedStore();
                        }
                    }
                    if (Err == 1)
                    {
                        MessageBox("Insertion Failed");
                        if (FileUploadApp.HasFile)
                            FileUploadApp.ClearAllFilesFromPersistedStore();
                        return;
                        Err = 0;
                    }
            }
            FillGrid();
            FillTrainingDataset();
            Calendar1_DayRender(null, null);
            Clear();
            if (FileUploadApp.HasFile)
                FileUploadApp.ClearAllFilesFromPersistedStore();
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
            if (FileUploadApp.HasFile)
                FileUploadApp.ClearAllFilesFromPersistedStore();
        }
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillTeacher();
            if (ddlDept.SelectedValue == "-1")
            {
                ddlName.SelectedValue = "-1";
                ddlName.Enabled = false;
                divChecklist.Visible = false;
                chkAll.Checked = true;
                chkAll.Enabled = false;
            }
            else
            {
                ddlName.Enabled = true;
                ddlName.SelectedValue = "0";
                divChecklist.Visible = true;
                chkAll.Checked = false;
                chkAll.Enabled = true;

            }
        }
        catch 
        {
            
        }
    }
    protected void CalTraining_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        FillTrainingDataset();
    }

    protected void grvDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      
        //Session["Id"] = Convert.ToString(grvDetail.Rows[e.RowIndex].Cells[0].Text);
        //LinkButton lnkBtn = (LinkButton)grvDetail.Rows[e.RowIndex].FindControl("LnkDetail");

        //lnkBtn.Attributes.Add("onclick", "window.open('frmTrainingDetail.aspx','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=800,top=80,left=75');return false");
    }
   
    protected void chkNameList_SelectedIndexChanged(object sender, EventArgs e)
    {

        for (int i = 0; i < chkNameList.Items.Count; i++)
        {
            if (chkNameList.Items[i].Selected == false)
            {
               chkAll.Checked = false;
                 break;
            }
            else
            {
                chkAll.Checked = true;
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            FillTrainingDataset();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("StudId");
            dt.Columns.Add("Type");
            dt.Columns.Add("Name");
            dt.Columns.Add("STD");
            dt.Columns.Add("DIV");
            dt.Columns.Add("Department");
            dt.Columns.Add("TypeId");
            dt.Columns.Add("DeptId");
            dt.Columns.Add("ParentId");
            dt.Columns.Add("StaffId");
            dt.Columns.Add("STD_ID");
            dt.Columns.Add("DIV_ID");
           
            DataRow dr;
            // To add Previous Data//
            //for (int j = 0; j < grvAdd.Rows.Count; j++)
            //{
                
            //    GridViewRow row = grvAdd.Rows[j];
            //    dr = dt.NewRow();
            //    for (int i = 0; i < row.Cells.Count-1; i++)
            //    {
            //        dr[i] = row.Cells[j].Text;
            //    }

            //    dt.Rows.Add(dr);
            //}
            if (grvAdd.Rows.Count > 0)
            {
                dt = (DataTable)Session["OldTable"];
                VisibleFalseTrue(true);
                grvAdd.DataSource = dt;
                grvAdd.DataBind();
                VisibleFalseTrue(false);
            }

            Boolean chkExist = false;
            for (int i = 0; i < chkNameList.Items.Count; i++)
            {
                chkExist = false;
                if (chkNameList.Items[i].Selected == true)
                {
                    for (int j = 0; j < grvAdd.Rows.Count; j++)
                    {
                        if (Convert.ToString(ddlType.SelectedValue) == Convert.ToString(grvAdd.Rows[j].Cells[8].Text))
                        {
                            if (Convert.ToString(grvAdd.Rows[j].Cells[8].Text)=="1")
                            {
                                if (Convert.ToString(grvAdd.Rows[j].Cells[2].Text) == Convert.ToString(chkNameList.Items[i].Value))
                                {
                                    chkExist = true;
                                    break;
                                }
                                if (Convert.ToString(grvAdd.Rows[j].Cells[12].Text) == "-1")
                                {
                                    MessageBox("You have already added all students");
                                    chkExist = true;
                                    break;
                                }
                                if (Convert.ToString(grvAdd.Rows[j].Cells[13].Text) == "-1" && Convert.ToString(grvAdd.Rows[j].Cells[12].Text)==Convert.ToString(ddlSTD.SelectedValue))
                                {
                                    MessageBox("You have already added all students of Standard " + Convert.ToString(grvAdd.Rows[j].Cells[5].Text));
                                    chkExist = true;
                                    break;
                                }
                            }
                            else if (Convert.ToString(grvAdd.Rows[j].Cells[8].Text) == "2")
                            {
                                if (Convert.ToString(grvAdd.Rows[j].Cells[10].Text) == Convert.ToString(chkNameList.Items[i].Value))
                                {
                                    chkExist = true;
                                    break;
                                }
                                if (Convert.ToString(grvAdd.Rows[j].Cells[12].Text) == "-1")
                                {
                                    MessageBox("You have already added all Parents");
                                    chkExist = true;
                                    break;
                                }
                                if (Convert.ToString(grvAdd.Rows[j].Cells[13].Text) == "-1" && Convert.ToString(grvAdd.Rows[j].Cells[12].Text) == Convert.ToString(ddlSTD.SelectedValue))
                                {
                                    MessageBox("You have already added all Parents of Standard " + Convert.ToString(grvAdd.Rows[j].Cells[5].Text));
                                    chkExist = true;
                                    break;
                                }
                            }
                            else if (Convert.ToString(grvAdd.Rows[j].Cells[8].Text)== "3" || (Convert.ToString(grvAdd.Rows[j].Cells[8].Text)== "4"))
                            {
                                if (Convert.ToString(grvAdd.Rows[j].Cells[11].Text) == Convert.ToString(chkNameList.Items[i].Value))
                                {
                                    chkExist = true;
                                    break;
                                }
                                if (Convert.ToString(grvAdd.Rows[j].Cells[9].Text) == "-1")
                                {
                                    MessageBox("You have already added all Staff Members");
                                    chkExist = true;
                                    break;
                                }
                            }
                     }
                    }
                

                    if (chkExist == false)
                    {
                        if (chkAll.Checked == true && chkAll.Visible==true)
                        {
                            if (ddlType.SelectedValue == "2" || ddlType.SelectedValue == "1")
                            {


                                strQry = "exec usp_TrainingMst  @type='GetStud_Div_Or_Std_Wise',@intSTD_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intDiv_id='" + Convert.ToString(ddlDiv.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                                    dsObj = sGetDataset(strQry);
                                    if (dsObj.Tables[0].Rows.Count > 0)
                                    {
                                        if ((Session["OldTable"] != null))
                                         {
                                            //Remove Previous Existing Record 
                                             DataTable dsTemp = (DataTable)Session["OldTable"];
                                             bool chk = false;

                                                    for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                                                    {
                                                        
                                                        for (int t = 0; t < dsTemp.Rows.Count; t++)
                                                         {
                                                             if (Convert.ToString(dsTemp.Rows[t]["TypeId"]) == Convert.ToString(ddlType.SelectedValue))
                                                             {
                                                                 if (Convert.ToString(dsObj.Tables[0].Rows[k]["intStudent_id"]) == Convert.ToString(dsTemp.Rows[t]["StudId"]))
                                                                 {
                                                                     chk = true;
                                                                     break;
                                                                 }

                                                                 else if (Convert.ToString(dsObj.Tables[0].Rows[k]["intParentId"]) == Convert.ToString(dsTemp.Rows[t]["ParentId"]))
                                                                 {
                                                                     chk = true;
                                                                     break;
                                                                 }
                                                             }
                                                         }

                                                        if (chk == false)
                                                        {
                                                            dr = dt.NewRow();

                                                            dr["StudId"] = Convert.ToString(dsObj.Tables[0].Rows[k]["intStudent_id"]);
                                                            dr["Name"] = Convert.ToString(dsObj.Tables[0].Rows[k]["StudentName"]);
                                                            dr["Type"] = Convert.ToString(ddlType.SelectedItem.Text);
                                                            dr["TypeId"] = Convert.ToString(ddlType.SelectedValue);
                                                            dr["DeptId"] = Convert.ToString(0);
                                                            dr["ParentId"] = Convert.ToString(dsObj.Tables[0].Rows[k]["intParentID"]);
                                                            dr["Department"] = Convert.ToString("");
                                                            dr["StaffId"] = Convert.ToString(0);
                                                            dr["STD_ID"] = Convert.ToString(dsObj.Tables[0].Rows[k]["intStandard_id"]);
                                                            dr["STD"] = Convert.ToString(ddlSTD.SelectedItem.Text);
                                                            dr["DIV_ID"] = Convert.ToString(dsObj.Tables[0].Rows[k]["intDivision_id"]);
                                                            dr["DIV"] = Convert.ToString(ddlDiv.SelectedItem.Text);
                                                            dt.Rows.Add(dr);
                                                        }
                                           
                                                     }
                                             
                                         }
                                        break;
                                    }
                                
                            }
                            else
                            {
                                strQry = "exec [usp_TrainingMst]  @type='GetTeacher_DeptWise',@intDept_id='" + Convert.ToString(ddlDept.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intUserType='" + Convert.ToString(ddlType.SelectedValue) + "'";
                                dsObj = sGetDataset(strQry);
                                if (dsObj.Tables[0].Rows.Count > 0)
                                {

                                    for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                                    {
                                        dr = dt.NewRow();
                                        dr["StudId"] = Convert.ToString(0);
                                        dr["Name"] = Convert.ToString(dsObj.Tables[0].Rows[k]["Name"]);
                                        dr["Type"] = Convert.ToString(ddlType.SelectedItem.Text);
                                        dr["TypeId"] = Convert.ToString(ddlType.SelectedValue);
                                        dr["DeptId"] = Convert.ToString(dsObj.Tables[0].Rows[k]["intDepartment_id"]);
                                        dr["Department"] = Convert.ToString(ddlDept.SelectedItem.Text);
                                        dr["StaffId"] = Convert.ToString(dsObj.Tables[0].Rows[k]["intTeacher_id"]);
                                        dr["STD_ID"] = Convert.ToString(0);
                                        dr["STD"] = Convert.ToString("");
                                        dr["DIV_ID"] = Convert.ToString(0);
                                        dr["DIV"] = Convert.ToString("");
                                        dt.Rows.Add(dr);
                                    }

                                }
                            }
                        }

                        
                        else
                        {

                            //Find out Parent Id//
                            string ParentId = "";
                            if (ddlType.SelectedValue == "2" || ddlType.SelectedValue == "1")
                            {
                                DataSet ds = new DataSet();
                                strQry = "";
                                strQry = "exec [usp_TrainingMst] @type='GetParent',@intStudent_id='" + Convert.ToString(chkNameList.Items[i].Value) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                                ds = sGetDataset(strQry);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    ParentId = Convert.ToString(ds.Tables[0].Rows[0][0]);
                                }
                                dr = dt.NewRow();
                                dr["StudId"] = Convert.ToString(ddlType.SelectedValue == "1" || ddlType.SelectedValue == "2" ? chkNameList.Items[i].Value : "");
                                dr["ParentId"] = Convert.ToString(ParentId);
                                dr["Name"] = Convert.ToString(chkNameList.Items[i].Text).ToUpper();
                                dr["Type"] = Convert.ToString(ddlType.SelectedItem.Text);
                                dr["TypeId"] = Convert.ToString(ddlType.SelectedValue);
                                dr["DeptId"] = Convert.ToString(0);
                                dr["Department"] = Convert.ToString("".Replace("&nbsp", ""));
                                dr["StaffId"] = Convert.ToString(0);
                                dr["STD_ID"] = Convert.ToString(ddlSTD.SelectedValue);
                                dr["STD"] = Convert.ToString(ddlSTD.SelectedItem.Text);
                                dr["DIV_ID"] = Convert.ToString(ddlDiv.SelectedValue);
                                dr["DIV"] = Convert.ToString(ddlDiv.SelectedItem.Text);
                                dt.Rows.Add(dr);
                            }
                            else
                            {
                                dr = dt.NewRow();
                                dr["StudId"] = Convert.ToString(ddlType.SelectedValue == "1" || ddlType.SelectedValue == "2" ? chkNameList.Items[i].Value : "");
                                dr["ParentId"] = Convert.ToString(0);
                                dr["Name"] = Convert.ToString(chkNameList.Items[i].Text).ToUpper();
                                dr["Type"] = Convert.ToString(ddlType.SelectedItem.Text);
                                dr["TypeId"] = Convert.ToString(ddlType.SelectedValue);
                                dr["DeptId"] = Convert.ToString(ddlDept.SelectedValue);
                                dr["Department"] = Convert.ToString(ddlDept.SelectedItem.Text);
                                dr["StaffId"] = Convert.ToString(chkNameList.Items[i].Value);
                                dr["STD_ID"] = Convert.ToString(0);
                                dr["STD"] = Convert.ToString("");
                                dr["DIV_ID"] = Convert.ToString(0);
                                dr["DIV"] = Convert.ToString("");
                                dt.Rows.Add(dr);
                            }
                            //End//

                          
                        }
                    
                    }
                

                 }
                else if(ddlType.SelectedValue == "2" || ddlType.SelectedValue == "1")
                { 
                    if (ddlSTD.SelectedValue == "-1" || ddlDiv.SelectedValue == "-1")
                    {
                        Boolean chk = false;
                        if (ddlSTD.SelectedValue == "-1")
                        {
                            for (int t = dt.Rows.Count-1; t >=0 ; t--)
                            {
                                if (Convert.ToString(dt.Rows[t]["TypeId"]) == Convert.ToString(ddlType.SelectedValue))
                                {
                                    dt.Rows.RemoveAt(t);
                                }
                            }
                        }
                        else if (ddlDiv.SelectedValue == "-1")
                        {
                            for (int t = dt.Rows.Count-1; t >= 0; t--)
                            {
                                if (Convert.ToString(dt.Rows[t]["STD_ID"]) == "-1")
                                {
                                    if (Convert.ToString(ddlType.SelectedValue)=="1")
                                    MessageBox("You have already added all students");
                                    else
                                        MessageBox("You have already added all Parents");
                                    chk = true;
                                    break;
                                }
                                if (ddlSTD.SelectedValue == Convert.ToString(dt.Rows[t]["STD_ID"]))
                                {
                                    dt.Rows.RemoveAt(t);
                                }
                            }
                        }

                        if (chk == false)
                        {
                            dr = dt.NewRow();
                            dr["Name"] = Convert.ToString("All Students").ToUpper();
                            dr["Type"] = Convert.ToString(ddlType.SelectedItem.Text);
                            dr["TypeId"] = Convert.ToString(ddlType.SelectedValue);
                            dr["STD_ID"] = Convert.ToString(ddlSTD.SelectedValue);
                            dr["STD"] = Convert.ToString(ddlSTD.SelectedItem.Text);
                            dr["DIV_ID"] = Convert.ToString(ddlDiv.SelectedValue);
                            dr["DIV"] = Convert.ToString(ddlDiv.SelectedItem.Text);
                            dt.Rows.Add(dr);
                            break;
                        }
                    }
                }

                else if (ddlDept.SelectedValue == "-1")
                {
                    for (int t = dt.Rows.Count - 1; t >= 0; t--)
                    {
                        if (Convert.ToString(dt.Rows[t]["TypeId"]) == Convert.ToString(ddlType.SelectedValue))
                        {
                            dt.Rows.RemoveAt(t);
                        }
                    }

                    dr = dt.NewRow();
                    dr["StudId"] = Convert.ToString(0);
                    dr["Name"] = Convert.ToString("All Staff");
                    dr["Type"] = Convert.ToString(ddlType.SelectedItem.Text);
                    dr["TypeId"] = Convert.ToString(ddlType.SelectedValue);
                    dr["DeptId"] = Convert.ToString(ddlDept.SelectedValue);
                    dr["Department"] = Convert.ToString(ddlDept.SelectedItem.Text);
                    dr["StaffId"] = Convert.ToString(0);
                    dr["STD_ID"] = Convert.ToString(0);
                    dr["STD"] = Convert.ToString("");
                    dr["DIV_ID"] = Convert.ToString(0);
                    dr["DIV"] = Convert.ToString("");
                    dt.Rows.Add(dr);
                    break;
                }
            }
             Session["OldTable"]=dt;
             VisibleFalseTrue(true);
            grvAdd.DataSource = dt;
            grvAdd.DataBind();
            VisibleFalseTrue(false);
        }
        catch 
        {

        }
    }
    public void VisibleFalseTrue(Boolean value)
    {
        grvAdd.Columns[1].Visible = value;
        grvAdd.Columns[2].Visible = value;
        grvAdd.Columns[8].Visible = value;
        grvAdd.Columns[9].Visible = value;
        grvAdd.Columns[10].Visible = value;
        grvAdd.Columns[11].Visible = value;
        grvAdd.Columns[12].Visible = value;
        grvAdd.Columns[13].Visible = value;
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            FillTrainingDataset();

            DataTable dt = new DataTable();
            dt = (DataTable)Session["OldTable"];
            
            for (int i = 0; i < chkNameList.Items.Count; i++)
            {
                if(chkNameList.Items[i].Selected==true)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {

                        if (j == 86)
                        {

                        }
                        if ( dt.Rows[j]["TypeId"].ToString() == Convert.ToString(ddlType.Text))
                            {
                                if (Convert.ToString(dt.Rows[j]["StudId"]) == Convert.ToString(chkNameList.Items[i].Value))
                                {
                                    dt.Rows.RemoveAt(j);
                                }
                                else if (Convert.ToString(dt.Rows[j]["ParentId"]) == Convert.ToString(chkNameList.Items[i].Value))
                                {
                                    dt.Rows.RemoveAt(j);
                                }
                                else if (Convert.ToString(dt.Rows[j]["StaffId"]) == Convert.ToString(chkNameList.Items[i].Value))
                                {
                                    dt.Rows.RemoveAt(j);
                                }
                            }
                        
                    }
                 }
            }
            Session["OldTable"] = dt;
            grvAdd.DataSource = dt;
            grvAdd.DataBind();
        }
        catch
        {
        }
    }
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {

        if (chkAll.Checked == true)
        {
            for (int i = 0; i < chkNameList.Items.Count; i++)
            {
                chkNameList.Items[i].Selected = true;
            }
        }
        else
        {
            for (int i = 0; i < chkNameList.Items.Count; i++)
            {
                chkNameList.Items[i].Selected = false;
            }
        }


        
    }
    protected void grvAdd_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdd.PageIndex = e.NewPageIndex;
        grvAdd.DataSource = Session["OldTable"];
        grvAdd.DataBind();
    }

    protected void grvAdd_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = new DataTable();
            dt = (DataTable)Session["OldTable"];
            dt.Rows.RemoveAt(index);
            Session["OldTable"]=dt;
            grvAdd.DataSource = dt;
            grvAdd.DataBind();
        }
        catch 
        {
            
           
        }
    }
    protected void grvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ImgCall")
            {
                int id = Convert.ToInt32(Convert.ToInt32(e.CommandArgument.ToString()));
                Session["Id"] = Convert.ToString(id);

                ImageButton lnkBtn = (ImageButton)e.CommandSource;
               // GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

                //  LinkButton lnkBtn = (LinkButton)e.CommandArgument; // grvDetail.FindControl("LnkDetail");

                lnkBtn.Attributes.Add("onclick", "window.open('frmTrainingDetail.aspx?TrainingId=" + Convert.ToString(Session["Id"]) + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=800,top=80,left=75');return false");
                FillTrainingDataset();
            }
        }
        catch (Exception)
        {
        }

        //if (e.CommandName == "ImgCall")
        //{

        //    string UnivID = e.CommandArgument.ToString();
        //    Session["Id"] = e.CommandArgument.ToString();
        //    ImageButton lb = (ImageButton)e.CommandSource;
        //    GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
        //   // LinkButton lblMemId = (LinkButton)grvDetail.Rows[gvr.RowIndex].FindControl("ImgDetail");
        //    //Label lblReceivedid = (Label)grvPrivateMsg.Rows[gvr.RowIndex].FindControl("lblReceiveId");
        //    //Response.Redirect("frmViewChatDetails.aspx?intGroup_id=" + UnivID + "&intGrpMem_Id=" + lblMemId.Text);
        //    lb.Attributes.Add("onclick", "window.open('frmTrainingDetail.aspx','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=800,top=80,left=75');return false");
        //}
       
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
        FillTrainingDataset();
        txtTitle.Focus();
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)grvDetail.DataKeys[e.RowIndex].Value;
            strQry = "";
            strQry = "exec usp_TrainingMst @type='DeleteAllMembers',@intTraining_id='" + id + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Convert.ToString(Session["User_id"]) + "',@vchDeletedIp='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                strQry = "";
                strQry = "exec usp_TrainingMst @type='Delete',@intTraining_id='" + id + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Convert.ToString(Session["User_id"]) + "',@vchDeletedIp='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Deleted Successfully!");
                    FillGrid();

                }
            }
        }
        catch 
        {

        }
    }
    protected void FileUploadApp_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        Session["FileUpload"] = Convert.ToString(FileUploadApp.FileName);
        Session["FileSize"] = Convert.ToString(FileUploadApp.FileContent.Length);
    }


    protected void grvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvDetail.PageIndex = e.NewPageIndex;
        grvDetail.DataBind();

        FillGrid();
    }
}
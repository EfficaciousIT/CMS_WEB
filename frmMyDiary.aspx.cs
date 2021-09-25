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

public partial class frmMyDiary : DBUtility
{
    string strQry = string.Empty;
    int CountSubject = 0;
    DataSet dsObj = new DataSet();
    int subjectId = 0;
    DataSet dsCal;
    int Month;
    string subjectNm = "";
    bool checkPostback = false;
    int Year;
    // a Property that manages a counter stored in ViewState
    protected void Page_Load(object sender, EventArgs e)
    {
        Month = DateTime.Now.Month;
        Year = DateTime.Now.Year;
       
        if (!IsPostBack)
        {
            FillSTD();
          
            if (Convert.ToString(Session["UserType_Id"]) == "3")
            {
                TabContainer1.Tabs[0].Visible = true;
                TabContainer1.Tabs[1].Visible = false;
               
                DiaryNew.Visible = true; 
                Fillgrid();
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "2" || Convert.ToString(Session["UserType_Id"]) == "1")
            {

                //LalStudentTecher.Visible = true;
                //ddlStudentTecher.Visible = true;

                //TabContainer1.Tabs[0].Visible = true;
                //TabContainer1.Tabs[1].Visible = true;
                //TabContainer1.Tabs[2].Visible = true;


                //ddlSTD2.SelectedValue = Convert.ToString(Session["Standard_id"]);
                //ddlSTD2_SelectedIndexChanged(null, null);
                ////ddlSTD2.Enabled = false;
                //ddlDIV2.SelectedValue = Convert.ToString(Session["Division_id"]);
                //ddlDIV2_SelectedIndexChanged(null, null);
                ////ddlDIV2.Enabled = false;
                //FillMonth("3");
                ////Fillgrid();



               

                //TabContainer1.Tabs[0].Visible = false;
                //TabContainer1.Tabs[1].Visible = false;
                //TabContainer1.Tabs[2].Visible = true;

              
               
                Fillgrid();

            }

        }
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
              
                //sBindDropDownList(ddlSTD1, strQry, "vchStandard_name", "intstandard_id");
                FillDIV();
            }
            else
            {
                strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
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

            strQry = "usp_MyDiary @command='TeachersDiv',@intteacher_id='" + Convert.ToString(Session["User_id"]) + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue.Trim()) + "'";
            //strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlDiv, strQry, "vchDivisionName", "intDivision_id");
            //FillStudent();
        }
        catch
        {

        }
    }
    //public void FillStudent()
    //{
    //    try
    //    {

    //        strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV2.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
    //        sBindDropDownList(ddlStudent, strQry, "Name", "intStudent_id");
    //        strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
    //        sBindDropDownList(ddlStud, strQry, "Name", "intStudent_id");



    //    }
    //    catch
    //    {

    //    }
    //}
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDIV();
    }
    protected void ddlDiv_SelectedIndexChanged(object sender, EventArgs e)
    {       
        try
        {
            strQry = "usp_MyDiary @command='subject',@intteacher_id='" + Convert.ToString(Session["User_id"]) + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue.Trim()) + "',@intDivision_id='" + Convert.ToString(ddlDiv.SelectedValue.Trim()) + "'";
            sBindDropDownList(ddlsubject, strQry, "vchsubjectname", "intsubject_id"); 

            strQry = "usp_MyDiary @command='StudentName',@intDivision_id='" + Convert.ToString(ddlDiv.SelectedValue.Trim()) + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue.Trim()) + "'";            
            sBindDropDownList(ddlStudent, strQry, "vchstudentfirst_name", "intstudent_id");

            strQry = "usp_MyDiary @command='StudentName',@intDivision_id='" + Convert.ToString(ddlDiv.SelectedValue.Trim()) + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue.Trim()) + "'";
            sBindCheckBoxList(ChkDivList, strQry, "vchstudentfirst_name", "intstudent_id");

            strQry = "usp_MyDiary @command='StudentName',@intDivision_id='" + Convert.ToString(ddlDiv.SelectedValue.Trim()) + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue.Trim()) + "'";
            sBindCheckBoxList(chkAllStuList, strQry, "vchstudentfirst_name", "intstudent_id");


            
        }
        catch
        {

        }
    }
    //protected void FillHolidayDataset()
    //{


    //    DateTime firstDate = new DateTime(Year, Month, 1);
    //    DateTime lastDate = GetFirstDayOfNextMonth();
    //    dsObj = GetCurrentMonthData(firstDate, lastDate);
    //}
    //protected DateTime GetFirstDayOfNextMonth()
    //{
    //    DateTime lastDate;
    //    try
    //    {
    //        int monthNumber, yearNumber;
    //        if (CalHoliday.VisibleDate.Month == 12 || CalHoliday.VisibleDate.Month == 11)
    //        {
    //            monthNumber = 1;
    //            yearNumber = DateTime.Now.Year + 1;
    //        }
    //        else
    //        {
    //            monthNumber = CalHoliday.VisibleDate.Month + 2;
    //            yearNumber = CalHoliday.VisibleDate.Year;
    //        }
    //        lastDate = new DateTime(yearNumber, monthNumber, 1);
    //        return lastDate;
    //    }
    //    catch (Exception ex)
    //    {
    //        DateTime a = new DateTime(DateTime.Now.Year, 1, 1);
    //        return a;

    //    }

    //}
    public DataSet GetCurrentMonthData(DateTime FirstDt, DateTime LastDt)
    {
        try
        {
            strQry = string.Empty;
            strQry = "exec [usp_setHolidayList] @type='GetCalendarData',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',  @FirstDate='" + Convert.ToDateTime(FirstDt).ToString("yyyy/MM/dd") + "',@LastDate='" + Convert.ToDateTime(LastDt).ToString("yyyy/MM/dd") + "'";
            dsCal = sGetDataset(strQry);
            return dsCal;
        }
        catch (Exception)
        {
            return dsObj;
        }
    }
    public object Createtable()
    {
        try
        {
            dsObj = new DataSet();
            //if (CheckBox1.Checked)
            //{
            //    strQry = "exec [usp_setHolidayList] @type='FillData',@intSchool_id='" + Session["School_id"] + "',@year='" + Year + "'";
            //}
            //else
            //{
                strQry = "exec [usp_setHolidayList] @type='FillData',@intSchool_id='" + Session["School_id"] + "',@month='" + Month + "',@year='" + Year + "'";
            //}


            dsObj = sGetDataset(strQry);
            return dsObj;
        }
        catch
        {
            return dsObj;
        }
    }
    public void Fillgrid()
    {
        try
        {
           
            if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
              
                TabContainer1.Tabs[1].Visible = true;
                TabContainer1.Tabs[0].Visible = true;
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "1" || Convert.ToString(Session["UserType_Id"]) == "2")
            {
               
                TabContainer1.Tabs[0].Visible = false;
                TabContainer1.Tabs[1].Visible = true;              
            }            
        }
        catch
        {

        }
    }
    
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            try
            {
                //CheckHolidayDataset();
                //FillHolidayDataset();
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if ((ddlType.Text == "Study Remark") || (ddlType.Text == "Homework"))
        {
            //string strDate = Convert.ToDateTime(txtDateAssignment.Text).ToString("MM/dd/yyyy").Replace("-", "/");

            //for (int i = 0; i < ChkDivList.Items.Count; i++)
            //{
            //    if (ChkDivList.Items[i].Selected == true)
            //    {
            //        string strStudent_id = Convert.ToString(ChkDivList.Items[i].Value);
            //        //strQry = "usp_MyDiary @command='Insert',@vchComment='" + txtComments.Text.Trim() + "',@intteacher_id='" + Convert.ToString(Session["User_id"]) + "',@intSubject_id='" + Convert.ToString(ddlsubject.SelectedValue.Trim()) + "',@intStudent_id='" + strStudent_id.ToString().Trim() + "',@intstandard_id='" + ddlSTD.SelectedValue.Trim() + "',@intDivision_id='" + Convert.ToString(ddlDiv.SelectedValue.Trim()) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@dtDate='" + strDate + "',@vchType='" + ddlType.Text.Trim() + "',@vchCapter='" + txtchapter.Text.Trim() + "'";
            //        //int j = sExecuteQuery(strQry);
            //        //if (j > 0)
            //        //{
            //        //    MessageBox("Comments added successfully");
            //        //}

            //    }
            //}

            string strDate = Convert.ToDateTime(txtDateAssignment.Text).ToString("MM/dd/yyyy").Replace("-", "/");
            int j = 0;
            for (int i = 0; i < chkAllStuList.Items.Count; i++)
            {
                if (chkAllStuList.Items[i].Selected == true)
                {
                    string strStudent_id = Convert.ToString(chkAllStuList.Items[i].Value);

                    strQry = "usp_MyDiary @command='Insert',@vchComment='" + txtMessage.Text.Trim() + "',@intteacher_id='" + Convert.ToString(Session["User_id"]) + "',@intSubject_id='" + Convert.ToString(ddlsubject.SelectedValue.Trim()) + "',@intStudent_id='" + strStudent_id.ToString().Trim() + "',@intstandard_id='" + ddlSTD.SelectedValue.Trim() + "',@intDivision_id='" + Convert.ToString(ddlDiv.SelectedValue.Trim()) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@dtDate='" + strDate + "',@vchType='" + ddlType.Text.Trim() + "',@vchCapter='" + txtchapter.Text.Trim() + "'";
                    j = sExecuteQuery(strQry);
                    
                }
            }
            if (j > 0)
            {
                MessageBox("Details added successfully");
            }
        }
        if (ddlType.Text == "Message")
        {
            int j = 0;
            string strDate = Convert.ToDateTime(txtDateAssignment.Text).ToString("MM/dd/yyyy").Replace("-", "/");

            for (int i = 0; i < chkAllStuList.Items.Count; i++)
            {
                if (chkAllStuList.Items[i].Selected == true)
                {
                    string strStudent_id = Convert.ToString(chkAllStuList.Items[i].Value);

                    strQry = "usp_MyDiary @command='Insert',@vchComment='" + txtMessage.Text.Trim() + "',@intteacher_id='" + Convert.ToString(Session["User_id"]) + "',@intSubject_id='" + Convert.ToString(ddlsubject.SelectedValue.Trim()) + "',@intStudent_id='" + strStudent_id.ToString().Trim() + "',@intstandard_id='" + ddlSTD.SelectedValue.Trim() + "',@intDivision_id='" + Convert.ToString(ddlDiv.SelectedValue.Trim()) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@dtDate='" + strDate + "',@vchType='" + ddlType.Text.Trim() + "',@vchCapter='" + txtchapter.Text.Trim() + "'";
                    j = sExecuteQuery(strQry);
                    
                }
            }
            if (j > 0)
            {
                MessageBox("Comments added successfully");
            }
        }                

    }

    
    protected void chkAll2_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkAllStu.Checked)
            {

                for (int i = 0; i < ChkDivList.Items.Count; i++)
                {
                    chkAllStuList.Items[i].Selected = true;

                    string valim = chkAllStuList.Items[i].Text;

                }

            }
            else
            {
                for (int i = 0; i < chkAllStuList.Items.Count; i++)
                {
                    chkAllStuList.Items[i].Selected = false;
                }
            }
        }
        catch { }

    }
    protected void chkAll3_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkAllStu.Checked)
            {
                for (int i = 0; i < ChkDivList.Items.Count; i++)
                {
                    chkAllStuList.Items[i].Selected = true;

                    string valim = chkAllStuList.Items[i].Text;

                }

            }
            else
            {
                for (int i = 0; i < chkAllStuList.Items.Count; i++)
                {
                    chkAllStuList.Items[i].Selected = false;
                }
            }
        }
        catch { }

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
   
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlType.Text == "Study Remark")
        {
            studydet.Visible = false;
            divMessage.Visible = true;
            lblExam.Text = "Study";
        }
        else if (ddlType.Text == "Message")
        {
            divMessage.Visible = true;
            studydet.Visible = false;
            lblMessage.Text = "Message";
        }
        else if (ddlType.Text == "Homework")
        {
            studydet.Visible = false;
            divMessage.Visible = true;
            lblExam.Text = "Homework";
        }
    }
}

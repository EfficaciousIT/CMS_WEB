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
using System.Collections.Generic;
using System.IO;
using System.Globalization;


public partial class frmNoticeBoardCreation : DBUtility
{
    string strQry = "";
    int stdId;
    int idnotice;
    string strStandard_id = "", strDivision = "", strDepartment = "", strStaff_id = "", strStudent_id = "", strUserType = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {      
        if (!IsPostBack)
        {
            fillDrp();
            fillNotice();
            grdNotice.Columns[4].Visible = false;
            grdNotice.Columns[5].Visible = false;
            if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                grdNotice.Columns[0].Visible = true;
                grdNotice.Columns[4].Visible = true;
                grdNotice.Columns[5].Visible = true;

                TabContainer1.Tabs[1].Visible = true;
                TabContainer1.Tabs[0].Visible = true;
            }
            else
            {
                grdNotice.Columns[0].Visible = true;
                grdNotice.Columns[4].Visible = false;
                grdNotice.Columns[5].Visible = false;

                TabContainer1.Tabs[0].Visible = true;
                TabContainer1.Tabs[1].Visible = false;
                //TabContainer1.Tabs[2].Visible = false;
            }
        }
    }

    protected void fillNotice()
    {

        btnUpdate.Visible = false;
        if (Convert.ToString(Session["UserType_Id"]) == "3")        
        {
           
            strQry = "exec [usp_TeacherDashboard] @type='NoticeBoardGrid',@intUserType_id='" + Convert.ToString(Session["UserType_Id"]) + "' ";
        }
        else if (Convert.ToString(Session["UserType_Id"]) == "4")
        {
            strQry = "[usp_StaffDashboard] @type='NoticeBoardGrid',@intUserType_id='" + Convert.ToString(Session["UserType_Id"]) + "',@intschool_id='" + Session["School_id"] + "'";
        }
        else if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
        {
            strQry = "usp_NocticeBoard @command='select',@intschool_id='" + Session["School_id"] + "',@AcademicID='" + Convert.ToString(Session["AcademicID"]) + "'";
        }
        else if (Convert.ToString(Session["UserType_Id"]) == "1" || Convert.ToString(Session["UserType_Id"]) == "2")
        {
            strQry = "exec [usp_StudentDashboard] @type='NoticeBoard',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@DivId='" + Convert.ToString(Session["Division_id"]) + "',@StudentId='" + Convert.ToString(Session["Student_id"]) + "' ";
        }
        
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdNotice.DataSource = dsObj;
            grdNotice.DataBind();
        }

        if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
        {
            grdNotice.Columns[0].Visible = true;
            grdNotice.Columns[1].Visible = true;
        }
        else
        {
            grdNotice.Columns[0].Visible = true;
            grdNotice.Columns[1].Visible = true;
            //TabContainer1.Tabs[2].Visible = false;
        }
    }

    protected void fillDrp()
    {
        string strQry = "Execute dbo.usp_idcard @command='selectTypeofuser',@intSchool_id='" + Session["School_id"] + "' ";
        bool stcardp = sBindDropDownList(drpUserType, strQry, "vchUser_name", "intUserType_id");
        drpUserType.Items.Insert(1, "All");

        //strQry = "Execute dbo.usp_idcard @command='SelectDepartment',@intSchool_id='" + Session["School_id"] + "' ";
        //bool stcardp2 = sBindDropDownList(drpDepartment, strQry, "vchDepartment_name", "intDepartment");
        //drpDepartment.Items.Insert(1, "All");
    }

    protected void drpUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpUserType.Text == "All")
        {
            //drpDivision.Enabled = false;
            //drpDepartment.Enabled = false;
            //drpDepartment.ClearSelection();
            drpStandard.Enabled = false;
            drpStandard.ClearSelection();
           // drpStudent.Enabled = false;
           // drpStaff.Enabled = false;
        }
        else if (drpUserType.Text == "1")
        {
            //drpDivision.Enabled = true;
            //drpDepartment.Enabled = false;
            //drpDepartment.ClearSelection();
            drpStandard.Enabled = true;
           // drpStudent.Enabled = true;
          //  drpStaff.Enabled = false;

            string strQry = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
            bool st = sBindDropDownList(drpStandard, strQry, "Standard_name", "intStandard_id");
            drpStandard.Items.Insert(1, "All");
        }
        else if (drpUserType.Text == "3")
        {
            //drpDivision.Enabled = false;
            //drpDepartment.Enabled = true;
            drpStandard.Enabled = false;
            drpStandard.ClearSelection();
            //drpStudent.Enabled = false;
            //drpStaff.Enabled = true;
        }
        else
        {
            //drpDivision.Enabled = false;
            //drpDepartment.Enabled = true;
            drpStandard.Enabled = false;
            drpStandard.ClearSelection();
            //drpStudent.Enabled = false;
           // drpStaff.Enabled = true;

            //strQry = "Execute dbo.usp_idcard @command='Selectstaff',@intSchool_id='" + Session["School_id"] + "' ";
            //bool stcardp2 = sBindDropDownList(drpDepartment, strQry, "vchDepartment_name", "intDepartment");
            //drpDepartment.Items.Insert(1, "All");
        }        
    }

    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpStandard.Text == "All")
        {
            drpStandard.Enabled = true;
            //drpDivision.Enabled = false;
            //drpStaff.Enabled = false;
            //drpDepartment.Enabled = false;
           // drpDepartment.ClearSelection();
            //drpStudent.Enabled = false;
        }
        else
        {
            stdId = Convert.ToInt32(drpStandard.SelectedItem.Value);
            string strQry = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stdId + "' ";
            //bool st2 = sBindDropDownList(drpDivision, strQry, "vchDivisionName", "intDivision_id");
            //drpDivision.Items.Insert(1, "All");
        }
        
    }

    //protected void drpDepartment_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (drpDepartment.Text == "All")
    //    {
    //       // drpStaff.Enabled = false;
    //    }
    //    else
    //    {
    //        int typeid = Convert.ToInt32(drpUserType.SelectedItem.Value);
    //        int depid = Convert.ToInt32(drpDepartment.SelectedItem.Value);
    //        string query2 = "Execute dbo.usp_idcard @command='SelectStaffId',@intSchool_id='" + Session["School_id"] + "',@intDepartment_id='" + depid + "',@intUserType_id='" + typeid + "' ";
    //        //bool st3 = sBindDropDownList(drpStaff, query2, "Name", "intTeacher_id");

    //        //drpStaff.Items.Insert(1, "All");
    //    }
        
    //}

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var encodedStr = txtSubject.Text;
        var encodedStr1 = txtNotice.Text;

        if (drpUserType.Text == "0")
        {
            MessageBox("Please select User Type!");
            return;
        }
        if (txtfromdate.Text == "")
        {
            MessageBox("Please select from Date!");
            return;
        }
        if (txtTodate.Text == "")
        {
            MessageBox("Please select to Date!");
            return;
        }

        if(txtSubject.Text=="")
        {
            MessageBox("Please Enter Subject!");
            return;
        }
        if (txtNotice.Text == "")
        {
            MessageBox("Please Enter Notice!");
            return;
        }
        strQry = "";
        int j = 0;

        if (drpUserType.Text == "All")
        {
            //strQry = "usp_NocticeBoard @command='student',@intschool_id='" + Session["School_id"] + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    //for (int i = 0; i <= dsObj.Tables[0].Rows.Count-1; i++)
            //    //{
            //        strStandard_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
            //        strDivision = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
            //        strStudent_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intstudent_id"]);

                    encodedStr = (encodedStr).Replace("'", "''");
                    encodedStr1 = (encodedStr1).Replace("'", "''");

                    strQry = "usp_NocticeBoard @command='insert',@intschool_id='" + Session["School_id"] + "',@intUserType_id='0',@intStandard_id='" + strStandard_id.Trim() + "',@intDivision_id='" + strDivision.Trim() + "',@intStudent_id='" + strStudent_id.Trim() + "',@intDepartment_id='0',@intTeacher_id='0',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject=N'" + encodedStr + "',@vchNotice=N'" + encodedStr1 + "',@intInserted_by='" + Session["User_Id"] + "',@InsertIP='" + GetSystemIP() + "',@AcademicID='" + Session["AcademicID"] + "'";
                    j = sExecuteQuery(strQry);
                   
                //}
            //}

            //strQry = "usp_NocticeBoard @command='staff',@intschool_id='" + Session["School_id"] + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    //for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
            //    //{
            //        strUserType = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
            //        strDepartment = Convert.ToString(dsObj.Tables[0].Rows[0]["intDepartment_id"]);
            //        strStaff_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intTeacher_id"]);

            //        encodedStr = (encodedStr).Replace("'", "''");
            //        encodedStr1 = (encodedStr1).Replace("'", "''");

            //        //strQry = "usp_NocticeBoard @command='insert',@intschool_id='" + Session["School_id"] + "',@intUserType_id='" + strUserType.Trim() + "',@intStandard_id='0',@intDivision_id='0',@intStudent_id='',@intDepartment_id='" + strDepartment.Trim() + "',@intTeacher_id='" + strStaff_id.Trim() + "',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject=N'" + encodedStr + "',@vchNotice=N'" + encodedStr1 + "',@intInserted_by='" + Session["User_Id"] + "',@InsertIP='" + GetSystemIP() + "'";
            //        //j = sExecuteQuery(strQry);
                    
            //    //}
            //}
            if (j > 0)
            {
                MessageBox("Notice addedd succefully");
                Clear();
            }
            else
            {
                MessageBox("Opppps Notice addedd succefully");
            }
        }
        else if (drpUserType.Text == "1")
        {
            if (drpStandard.Text == "All")
            {
                //strQry = "usp_NocticeBoard @command='student',@intschool_id='" + Session["School_id"] + "'";
                //dsObj = sGetDataset(strQry);
                //if (dsObj.Tables[0].Rows.Count > 0)
                //{
                //for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
                //{
                //  strStandard_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
                //  strDivision = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                //  strStudent_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intstudent_id"]);

                encodedStr = (encodedStr).Replace("'", "''");
                encodedStr1 = (encodedStr1).Replace("'", "''");

                strQry = "usp_NocticeBoard @command='insert',@intschool_id='" + Session["School_id"] + "',@intUserType_id='1',@intStandard_id='" + stdId.ToString() + "',@intDepartment_id='0',@intTeacher_id='0',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject=N'" + encodedStr + "',@vchNotice=N'" + encodedStr1 + "',@intInserted_by='" + Session["User_Id"] + "',@InsertIP='" + GetSystemIP() + "',@AcademicID='" + Session["AcademicID"] + "'";
                sExecuteQuery(strQry);
                MessageBox("Notice addedd succefully");
                Clear();

                //}

            }
            else
            {
                encodedStr = (encodedStr).Replace("'", "''");
                encodedStr1 = (encodedStr1).Replace("'", "''");
                stdId = Convert.ToInt32(drpStandard.SelectedItem.Value);
                strQry = "usp_NocticeBoard @command='insert',@intschool_id='" + Session["School_id"] + "',@intUserType_id='1',@intStandard_id='" + stdId.ToString() + "',@intDepartment_id='0',@intTeacher_id='0',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject=N'" + encodedStr + "',@vchNotice=N'" + encodedStr1 + "',@intInserted_by='" + Session["User_Id"] + "',@InsertIP='" + GetSystemIP() + "',@AcademicID='" + Session["AcademicID"] + "'";
                sExecuteQuery(strQry);
                MessageBox("Notice addedd succefully");
                Clear();
            }
        }
        else if (drpUserType.Text == "2")
        {
            if (drpStandard.Text == "All")
            {
                strQry = "usp_NocticeBoard @command='AllTeachers',@intschool_id='" + Session["School_id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    //for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
                    //{
                    strUserType = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
                    strDepartment = Convert.ToString(dsObj.Tables[0].Rows[0]["intDepartment_id"]);
                    strStaff_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intTeacher_id"]);
                    encodedStr = (encodedStr).Replace("'", "''");
                    encodedStr1 = (encodedStr1).Replace("'", "''");

                    strQry = "usp_NocticeBoard @command='insert',@intschool_id='" + Session["School_id"] + "',@intUserType_id='" + strUserType.Trim() + "',@intStandard_id='0',@intDivision_id='0',@intStudent_id='',@intDepartment_id='" + strDepartment.Trim() + "',@intTeacher_id='" + strStaff_id.Trim() + "',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject=N'" + encodedStr + "',@vchNotice=N'" + encodedStr1 + "',@intInserted_by='" + Session["User_Id"] + "',@InsertIP='" + GetSystemIP() + "',@AcademicID='" + Session["AcademicID"] + "'";
                    j = sExecuteQuery(strQry);

                    //}
                }
                if (j > 0)
                {
                    MessageBox("Notice addedd succefully");
                    Clear();
                }
            }
        }
        else if (drpUserType.Text == "3")
        {
            //if (drpDepartment.Text == "All")
            //{
            //    strQry = "usp_NocticeBoard @command='AllTeachers',@intschool_id='" + Session["School_id"] + "'";
            //    dsObj = sGetDataset(strQry);
            //    if (dsObj.Tables[0].Rows.Count > 0)
            //    {
            //        //for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
            //        //{
            //        strUserType = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
            //        strDepartment = Convert.ToString(dsObj.Tables[0].Rows[0]["intDepartment_id"]);
            //        strStaff_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intTeacher_id"]);

            //        strQry = "usp_NocticeBoard @command='insert',@intschool_id='" + Session["School_id"] + "',@intUserType_id='" + strUserType.Trim() + "',@intStandard_id='0',@intDivision_id='0',@intStudent_id='',@intDepartment_id='" + strDepartment.Trim() + "',@intTeacher_id='" + strStaff_id.Trim() + "',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject='" + txtSubject.Text.Trim() + "',@vchNotice='" + txtNotice.Text.Trim() + "'";
            //        j = sExecuteQuery(strQry);

            //        //}
            //    }
            //    if (j > 0)
            //    {
            //        MessageBox("Notice addedd succefully");
            //    }
            //}
            //else
            //{
               // strQry = "usp_NocticeBoard @command='AllTeachersDepartment',@intschool_id='" + Session["School_id"] + "',@intDepartment_id='" + drpDepartment.SelectedValue.Trim() + "'";
                strQry = "usp_NocticeBoard @command='AllTeachersDepartment',@intschool_id='" + Session["School_id"] + "'";    
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    //for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
                    //{
                    strUserType = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
                    strDepartment = Convert.ToString(dsObj.Tables[0].Rows[0]["intDepartment_id"]);
                    strStaff_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intTeacher_id"]);

                    encodedStr = (encodedStr).Replace("'", "''");
                    encodedStr1 = (encodedStr1).Replace("'", "''");

                    strQry = "usp_NocticeBoard @command='insert',@intschool_id='" + Session["School_id"] + "',@intUserType_id='" + strUserType.Trim() + "',@intStandard_id='0',@intDivision_id='0',@intStudent_id='',@intDepartment_id='" + strDepartment.Trim() + "',@intTeacher_id='" + strStaff_id.Trim() + "',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject=N'" + encodedStr + "',@vchNotice=N'" + encodedStr1 + "',@intInserted_by='" + Session["User_Id"] + "',@InsertIP='" + GetSystemIP() + "',@AcademicID='" + Session["AcademicID"] + "'";
                    j = sExecuteQuery(strQry);

                    //}
                }
                if (j > 0)
                {
                    MessageBox("Notice addedd succefully");
                    Clear();
                }
           // }

        }
        else if (drpUserType.Text == "4")
        {
            //if (drpDepartment.Text == "All")
            //{
            //    strQry = "usp_NocticeBoard @command='AllStaffNon',@intschool_id='" + Session["School_id"] + "'";
            //    dsObj = sGetDataset(strQry);
            //    if (dsObj.Tables[0].Rows.Count > 0)
            //    {
            //        //for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
            //        //{
            //        strUserType = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
            //        strDepartment = Convert.ToString(dsObj.Tables[0].Rows[0]["intDepartment_id"]);
            //        strStaff_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intTeacher_id"]);

            //        strQry = "usp_NocticeBoard @command='insert',@intschool_id='" + Session["School_id"] + "',@intUserType_id='" + strUserType.Trim() + "',@intStandard_id='0',@intDivision_id='0',@intStudent_id='',@intDepartment_id='" + strDepartment.Trim() + "',@intTeacher_id='" + strStaff_id.Trim() + "',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject='" + txtSubject.Text.Trim() + "',@vchNotice='" + txtNotice.Text.Trim() + "'";
            //        j = sExecuteQuery(strQry);

            //        //}
            //    }
            //    if (j > 0)
            //    {
            //        MessageBox("Notice addedd succefully");
            //    }
            //}
            //else
            //{
                //strQry = "usp_NocticeBoard @command='AllStaffDepartment',@intschool_id='" + Session["School_id"] + "',@intDepartment_id='" + drpDepartment.SelectedValue.Trim() + "'";
            //strQry = "usp_NocticeBoard @command='AllStaffDepartment',@intschool_id='" + Session["School_id"] + "'";
            //    dsObj = sGetDataset(strQry);
            //    if (dsObj.Tables[0].Rows.Count > 0)
            //    {
            //        //for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
            //        //{
            //        strUserType = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
            //        strDepartment = Convert.ToString(dsObj.Tables[0].Rows[0]["intDepartment_id"]);
            //        strStaff_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intTeacher_id"]);

                    encodedStr = (encodedStr).Replace("'", "''");
                    encodedStr1 = (encodedStr1).Replace("'", "''");

                    strQry = "usp_NocticeBoard @command='insert',@intschool_id='" + Session["School_id"] + "',@intUserType_id='" + strUserType.Trim() + "',@intStandard_id='0',@intDivision_id='0',@intStudent_id='',@intDepartment_id='" + strDepartment.Trim() + "',@intTeacher_id='" + strStaff_id.Trim() + "',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject=N'" + encodedStr + "',@vchNotice=N'" + encodedStr1 + "',@intInserted_by='" + Session["User_Id"] + "',@InsertIP='" + GetSystemIP() + "',@AcademicID='" + Session["AcademicID"] + "'";
                    j = sExecuteQuery(strQry);

                    //}
                //}
                if (j > 0)
                {
                    MessageBox("Notice addedd succefully");
                    Clear();
                }
           // }

        }
        else
        {

            strQry = "usp_NocticeBoard @command='AllAdmin',@intschool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
                //{
                strUserType = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
                strDepartment = Convert.ToString(dsObj.Tables[0].Rows[0]["intDepartment_id"]);
                strStaff_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intAdmin_id"]);

                encodedStr = (encodedStr).Replace("'", "''");
                encodedStr1 = (encodedStr1).Replace("'", "''");

                strQry = "usp_NocticeBoard @command='insert',@intschool_id='" + Session["School_id"] + "',@intUserType_id='" + strUserType.Trim() + "',@intStandard_id='0',@intDivision_id='0',@intStudent_id='',@intDepartment_id='" + strDepartment.Trim() + "',@intTeacher_id='" + strStaff_id.Trim() + "',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject=N'" + encodedStr + "',@vchNotice=N'" + encodedStr1 + "',@intInserted_by='" + Session["User_Id"] + "',@InsertIP='" + GetSystemIP() + "',@AcademicID='" + Session["AcademicID"] + "'";
                j = sExecuteQuery(strQry);

                //}
            }
            if (j > 0)
            {
                MessageBox("Notice addedd succefully");
                Clear();
            }
            // }

        }
    }

    protected void Clear()
    {
        drpUserType.ClearSelection();
        drpStandard.ClearSelection();
        txtfromdate.Text = "";
        txtTodate.Text = "";
        txtSubject.Text = "";
        txtNotice.Text = "";
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

    protected void grdNotice_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            idnotice = Convert.ToInt32(grdNotice.DataKeys[e.RowIndex].Value);
            //Session["Deleteid"] = grdNotice.DataKeys[e.RowIndex].Value;

            strQry = "exec [usp_NocticeBoard]  @command='Delete',@intNotice_id='" + idnotice + "',@intDeletedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchDeletedIp='" + GetSystemIP() + "',@intSchool_id='" + Session["School_id"] + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully");
                fillNotice();
            }           
        }
        catch
        {


        }
    }
    protected void grdNotice_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {

            idnotice = Convert.ToInt32(grdNotice.DataKeys[e.NewEditIndex].Value);
            Session["id"] = grdNotice.DataKeys[e.NewEditIndex].Value;
            dsObj = new DataSet();
            strQry = "exec [usp_NocticeBoard] @command='SelectEditData',@intNotice_id='" + idnotice + "',@intSchool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                string usertype = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
                if (usertype == "0")
                {
                    drpUserType.SelectedIndex = 1;
                }
                else
                {
                    drpUserType.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
                }

                if (drpUserType.SelectedValue == "1")
                {
                    string strQry1 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
                    bool st = sBindDropDownList(drpStandard, strQry1, "Standard_name", "intStandard_id");
                    drpStandard.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
                }

                txtfromdate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Issue_Date"]);
                txtTodate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["End_Date"]);
                txtSubject.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Subject"]);
                txtNotice.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Notice"]);
                TabContainer1.ActiveTabIndex = 2;
                btnSubmit.Visible=false;
                btnUpdate.Visible = true;
              //  fillNotice();
            }

        }
        catch
        {


        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        var encodedStr = txtSubject.Text;
        var encodedStr1 = txtNotice.Text;


        if (drpUserType.Text == "0")
        {
            MessageBox("Please select User Type!");
            return;
        }
        if (txtfromdate.Text == "")
        {
            MessageBox("Please select from Date!");
            return;
        }
        if (txtTodate.Text == "")
        {
            MessageBox("Please select to Date!");
            return;
        }

        if (txtSubject.Text == "")
        {
            MessageBox("Please Enter Subject!");
            return;
        }
        if (txtNotice.Text == "")
        {
            MessageBox("Please Enter Notice!");
            return;
        }
        strQry = "";
        int j = 0;

        if (drpUserType.Text == "All")
        {
            //strQry = "usp_NocticeBoard @command='student',@intschool_id='" + Session["School_id"] + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    strStandard_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
            //    strDivision = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
            //    strStudent_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intstudent_id"]);

            //    strQry = "usp_NocticeBoard @command='Update',@intNotice_id='" + Session["id"] + "',@intschool_id='" + Session["School_id"] + "',@intUserType_id='1',@intStandard_id='" + strStandard_id.Trim() + "',@intDivision_id='" + strDivision.Trim() + "',@intStudent_id='" + strStudent_id.Trim() + "',@intDepartment_id='0',@intTeacher_id='0',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject='" + txtSubject.Text.Trim() + "',@vchNotice='" + txtNotice.Text.Trim() + "',@intUpdate_by='" + Convert.ToString(Session["User_Id"]) + "',@UpdateIP='" + GetSystemIP() + "'";
            //    j = sExecuteQuery(strQry);
            //}

            //strQry = "usp_NocticeBoard @command='staff',@intschool_id='" + Session["School_id"] + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    strUserType = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
            //    strDepartment = Convert.ToString(dsObj.Tables[0].Rows[0]["intDepartment_id"]);
            //    strStaff_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intTeacher_id"]);

            //    strQry = "usp_NocticeBoard @command='Update',@intNotice_id='" + Session["id"] + "',@intschool_id='" + Session["School_id"] + "',@intUserType_id='" + strUserType.Trim() + "',@intStandard_id='0',@intDivision_id='0',@intStudent_id='',@intDepartment_id='" + strDepartment.Trim() + "',@intTeacher_id='" + strStaff_id.Trim() + "',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject='" + txtSubject.Text.Trim() + "',@vchNotice='" + txtNotice.Text.Trim() + "',@intUpdate_by='" + Convert.ToString(Session["User_Id"]) + "',@UpdateIP='" + GetSystemIP() + "'";
            //    j = sExecuteQuery(strQry);
            //}

            encodedStr = (encodedStr).Replace("'", "''");
            encodedStr1 = (encodedStr1).Replace("'", "''");


            strQry = "usp_NocticeBoard @command='Update',@intNotice_id='" + Session["id"] + "',@intschool_id='" + Session["School_id"] + "',@intUserType_id=0,@intStandard_id='0',@intDivision_id='0',@intStudent_id='',@intDepartment_id='" + strDepartment.Trim() + "',@intTeacher_id='" + strStaff_id.Trim() + "',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject='" + encodedStr + "',@vchNotice='" + encodedStr1 + "',@intUpdate_by='" + Convert.ToString(Session["User_Id"]) + "',@UpdateIP='" + GetSystemIP() + "'";
            j = sExecuteQuery(strQry);

            if (j > 0)
            {
                MessageBox("Notice Updated succefully");
            }
            else
            {
                MessageBox("Opppps Notice Updated succefully");
            }
        }
        else if (drpUserType.Text == "1")
        {
            if (drpStandard.Text == "All")
            {
                encodedStr = (encodedStr).Replace("'", "''");
                encodedStr1 = (encodedStr1).Replace("'", "''");


                strQry = "usp_NocticeBoard @command='Update',@intNotice_id='" + Session["id"] + "',@intschool_id='" + Session["School_id"] + "',@intUserType_id='1',@intStandard_id='" + stdId.ToString() + "',@intDepartment_id='0',@intTeacher_id='0',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject='" + encodedStr + "',@vchNotice='" + encodedStr1 + "',@intUpdate_by='" + Convert.ToString(Session["User_Id"]) + "',@UpdateIP='" + GetSystemIP() + "'";
                sExecuteQuery(strQry);
                MessageBox("Notice Updated succefully");
            }
            else
            {
                encodedStr = (encodedStr).Replace("'", "''");
                encodedStr1 = (encodedStr1).Replace("'", "''");

                stdId = Convert.ToInt32(drpStandard.SelectedItem.Value);
                strQry = "usp_NocticeBoard @command='Update',@intNotice_id='" + Session["id"] + "',@intschool_id='" + Session["School_id"] + "',@intUserType_id='1',@intStandard_id='" + stdId.ToString() + "',@intDepartment_id='0',@intTeacher_id='0',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject='" + encodedStr + "',@vchNotice='" + encodedStr1 + "',@intUpdate_by='" + Convert.ToString(Session["User_Id"]) + "',@UpdateIP='" + GetSystemIP() + "'";
                sExecuteQuery(strQry);
                MessageBox("Notice Updated succefully");
            }
        }
        else if (drpUserType.Text == "2")
        {
            if (drpStandard.Text == "All")
            {
                strQry = "usp_NocticeBoard @command='AllTeachers',@intschool_id='" + Session["School_id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    encodedStr = (encodedStr).Replace("'", "''");
                    encodedStr1 = (encodedStr1).Replace("'", "''");

      
                    strUserType = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
                    strDepartment = Convert.ToString(dsObj.Tables[0].Rows[0]["intDepartment_id"]);
                    strStaff_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intTeacher_id"]);

                    strQry = "usp_NocticeBoard @command='Update',@intNotice_id='" + Session["id"] + "',@intschool_id='" + Session["School_id"] + "',@intUserType_id='" + strUserType.Trim() + "',@intStandard_id='0',@intDivision_id='0',@intStudent_id='',@intDepartment_id='" + strDepartment.Trim() + "',@intTeacher_id='" + strStaff_id.Trim() + "',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject='" + encodedStr + "',@vchNotice='" + encodedStr1 + "',@intUpdate_by='" + Convert.ToString(Session["User_Id"]) + "',@UpdateIP='" + GetSystemIP() + "'";
                    j = sExecuteQuery(strQry);
                }
                if (j > 0)
                {
                    MessageBox("Notice Updated succefully");
                }
            }
        }
        else if (drpUserType.Text == "3")
        {
            strQry = "usp_NocticeBoard @command='AllTeachersDepartment',@intschool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                encodedStr = (encodedStr).Replace("'", "''");
                encodedStr1 = (encodedStr1).Replace("'", "''");


                strUserType = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
                strDepartment = Convert.ToString(dsObj.Tables[0].Rows[0]["intDepartment_id"]);
                strStaff_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intTeacher_id"]);

                strQry = "usp_NocticeBoard @command='Update',@intNotice_id='" + Session["id"] + "',@intschool_id='" + Session["School_id"] + "',@intUserType_id='" + strUserType.Trim() + "',@intStandard_id='0',@intDivision_id='0',@intStudent_id='',@intDepartment_id='" + strDepartment.Trim() + "',@intTeacher_id='" + strStaff_id.Trim() + "',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject='" + encodedStr + "',@vchNotice='" + encodedStr1 + "',@intUpdate_by='" + Convert.ToString(Session["User_Id"]) + "',@UpdateIP='" + GetSystemIP() + "'";
                j = sExecuteQuery(strQry);
            }
            if (j > 0)
            {
                MessageBox("Notice Updated succefully");
            }
        }
        else if (drpUserType.Text == "4")
        {
            strQry = "usp_NocticeBoard @command='AllStaffDepartment',@intschool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                encodedStr = (encodedStr).Replace("'", "''");
                encodedStr1 = (encodedStr1).Replace("'", "''");

                strUserType = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
                strDepartment = Convert.ToString(dsObj.Tables[0].Rows[0]["intDepartment_id"]);
                strStaff_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intTeacher_id"]);

                strQry = "usp_NocticeBoard @command='Update',@intNotice_id='" + Session["id"] + "', @intschool_id='" + Session["School_id"] + "',@intUserType_id='" + strUserType.Trim() + "',@intStandard_id='0',@intDivision_id='0',@intStudent_id='',@intDepartment_id='" + strDepartment.Trim() + "',@intTeacher_id='" + strStaff_id.Trim() + "',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject='" + encodedStr + "',@vchNotice='" + encodedStr1 + "',@intUpdate_by='" + Convert.ToString(Session["User_Id"]) + "',@UpdateIP='" + GetSystemIP() + "'";
                j = sExecuteQuery(strQry);
            }
            if (j > 0)
            {
                MessageBox("Notice Updated succefully");
            }
        }
    }
}

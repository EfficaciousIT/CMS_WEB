using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Net;

public partial class frmOnlineNotice : DBUtility
{
    string strQry = "";
    int stdId;
    int idnotice;
    string strStandard_id = "", strDivision = "", strDepartment = "", strStaff_id = "", strStudent_id = "", strUserType = "", strFcmTokan = "";
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
        if (Convert.ToString(Session["UserType_Id"]) == "3")        {
           
            strQry = "exec [usp_TeacherDashboard] @type='NoticeBoardGrid',@intUserType_id='" + Convert.ToString(Session["UserType_Id"]) + "' ";
        }
        else if (Convert.ToString(Session["UserType_Id"]) == "4")
        {
            strQry = "[usp_StaffDashboard] @type='NoticeBoardGrid',@intUserType_id='" + Convert.ToString(Session["UserType_Id"]) + "',@intschool_id='" + Session["School_id"] + "'";
        }
        else if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
        {
            strQry = "usp_OnlineNocticeBoard @command='select',@intschool_id='" + Session["School_id"] + "'";
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
       
        strQry = "Execute dbo.usp_LectureAssign @command='LectureTeacher',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        bool stcardp = sBindDropDownList(DropDownList8, strQry, "Name", "intTeacher_id");

        strQry = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
        bool st = sBindDropDownList(drpStandard, strQry, "Standard_name", "intStandard_id");

    }

    protected void drpUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        if (drpUserType.Text == "1")
        {
            string strQry = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
            bool st = sBindDropDownList(drpStandard, strQry, "Standard_name", "intStandard_id");
           // drpStandard.Items.Insert(1, "All");
        }
    }

    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpLectureName.ClearSelection();
        DropDownList8.ClearSelection();
        TextBox2.Text = "";
        TextBox1.Text = "";
        txtlecturedate.Text = "";

        if (drpStandard.Text == "All")
        {
            drpDivision.Enabled = false;
            drpDivision.Items.Insert(1, "All");
            drpDivision.SelectedValue = "All";
            
        }
        else
        {
            stdId = Convert.ToInt32(drpStandard.SelectedItem.Value);
            string strQry = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stdId + "' ";
            bool st2 = sBindDropDownList(drpDivision, strQry, "vchDivisionName", "intDivision_id");
            drpDivision.Items.Insert(1, "All");

            drpDivision.SelectedValue = "All";

            string queryp7 = "Execute dbo.usp_LectureAssign @command='LectureSubject',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intStandard_id='" + drpStandard.SelectedValue + "'";
            bool st7 = sBindDropDownList(drpsubject, queryp7, "vchSubjectName", "intSubject_id");

             strQry = "Execute usp_OnlineNocticeBoard @command='SelectLectureNameSTD',@intSchool_id='" + Session["School_id"] + "',@intstandard_id='" + stdId + "',@intDivision_id='" + drpDivision.SelectedValue + "' ";
             st2 = sBindDropDownList(drpLectureName, strQry, "vchLecture_name", "intOnlinelecture_id");


        }
        
    }
    protected void drpDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpLectureName.ClearSelection();
        DropDownList8.ClearSelection();
        TextBox2.Text = "";
        TextBox1.Text = "";
        txtlecturedate.Text = "";

        stdId = Convert.ToInt32(drpStandard.SelectedItem.Value);

        if (drpDivision.SelectedValue == "All")
        {
            string strQry = "Execute usp_OnlineNocticeBoard @command='SelectLectureNameSTD',@intSchool_id='" + Session["School_id"] + "',@intstandard_id='" + stdId + "',@intDivision_id='" + drpDivision.SelectedValue + "' ";
            bool st2 = sBindDropDownList(drpLectureName, strQry, "vchLecture_name", "intOnlinelecture_id");
        }
        else
        {      
            string strQry = "Execute usp_OnlineNocticeBoard @command='SelectLectureName',@intSchool_id='" + Session["School_id"] + "',@intstandard_id='" + stdId + "',@intDivision_id='" + drpDivision.SelectedValue + "' ";
            bool st2 = sBindDropDownList(drpLectureName, strQry, "vchLecture_name", "intOnlinelecture_id");
        }
    }

    protected void drpLectureName_SelectedIndexChanged(object sender, EventArgs e)
    {
        dsObj = new DataSet();
        strQry = "exec usp_OnlineNocticeBoard @command='intOnlineLectureData',@intOnlinelecture_id='" + drpLectureName.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            DateTime var = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtLecture_date"]);
            txtlecturedate.Text = var.ToString("dd/MM/yyyy").Replace("-", "/");

            DateTime var1 = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtFromTime"]);
            TextBox1.Text = var1.ToString("hh:mm tt");

            DateTime var2 = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtToTime"]);
            TextBox2.Text = var2.ToString("hh:mm tt");

            DropDownList8.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intTeacher_id"]);

            string queryp5 = "Execute dbo.usp_LectureAssign @command='LecSubj',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
           bool stcardp5 = sBindDropDownList(drpsubject, queryp5, "vchSubjectName", "intSubject_id");
            drpsubject.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intSubject_id"]);
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var encodedStr = txtSubject.Text;
        var encodedStr1 = txtNotice.Text;

        if (drpUserType.Text == "0")
        {
            MessageBox("Please select User Type!");
            return;
        }
        //if (txtfromdate.Text == "")
        //{
        //    MessageBox("Please select from Date!");
        //    return;
        //}
        //if (txtTodate.Text == "")
        //{
        //    MessageBox("Please select to Date!");
        //    return;
        //}
        else if (drpLectureName.Text == "0")
        {
            MessageBox("Please Enter Lecture Name !");
            return;
        }
        else if(txtSubject.Text=="")
        {
            MessageBox("Please Enter Meeting Details!");
            return;
        }
        else if (txtNotice.Text == "")
        {
            MessageBox("Please Enter Description/Link !");
            return;
        }
        if (DropDownList8.Text == "")
        {
            MessageBox("Please Select Teacher Name");
            return;
        }
        else if (txtusername.Text == "")
        {
            MessageBox("Please Enter Meeting ID!");
            return;
        }
        else if (txtpassword.Text == "")
        {
            MessageBox("Please Enter Password!");
            return;
        }
        else
        {
            strQry = "";
            int j = 0;

            if (drpUserType.Text == "1")
            {
                if (drpStandard.Text == "All")
                {

                    encodedStr = (encodedStr).Replace("'", "''");
                    encodedStr1 = (encodedStr1).Replace("'", "''");

                    //strQry = "usp_NocticeBoard @command='insert',@intschool_id='" + Session["School_id"] + "',@intUserType_id='1',@intStandard_id='" + stdId.ToString() + "',@intDepartment_id='0',@intTeacher_id='0',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject=N'" + encodedStr + "',@vchNotice=N'" + encodedStr1 + "',@intInserted_by='" + Session["User_Id"] + "',@InsertIP='" + GetSystemIP() + "'";


                    strQry = "usp_OnlineNocticeBoard @command='insert',@intschool_id='" + Session["School_id"] + "',@intUserType_id='1',@intStandard_id='0',@intDivision_id='0',@intStudent_id='0',@intDepartment_id='0',@intTeacher_id='0'," +
                        // "@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "'"
                    ",@vchSubject=N'" + encodedStr + "',@vchonlineNotice=N'" + encodedStr1 + "',@intOnlinelecture_id='" + drpLectureName.SelectedValue + "'" +
                        "@vchLectureBy='" + DropDownList8.SelectedValue + "',@vchMeetingId='" + txtusername.Text + "',@vchpassword='" + txtpassword.Text + "',@intInserted_by='" + Session["User_Id"] + "',@InsertIP='" + GetSystemIP() + "',@AcademicID='" + Session["AcademicID"] + "',@intOnlinelecture_id='" + drpLectureName.SelectedValue + "'";


                    sExecuteQuery(strQry);
                    MessageBox("Online Class Details Submitted succefully");
                    fillNotice();
                    //}

                }
                else
                {
                    stdId = Convert.ToInt32(drpStandard.SelectedItem.Value);

                    encodedStr = (encodedStr).Replace("'", "''");
                    encodedStr1 = (encodedStr1).Replace("'", "''");

                    //strQry = "usp_NocticeBoard @command='insert',@intschool_id='" + Session["School_id"] + "',@intUserType_id='1',@intStandard_id='" + stdId.ToString() + "',@intDepartment_id='0',@intTeacher_id='0',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject=N'" + encodedStr + "',@vchNotice=N'" + encodedStr1 + "',@intInserted_by='" + Session["User_Id"] + "',@InsertIP='" + GetSystemIP() + "'";

                    string divisionID = drpDivision.SelectedValue == "All" ? divisionID = "0" : divisionID = drpDivision.SelectedValue;

                    strQry = "usp_OnlineNocticeBoard @command='insert',@intschool_id='" + Session["School_id"] + "',@intUserType_id='1',@intStandard_id='" + drpStandard.SelectedValue + "',@intDivision_id='" + divisionID + "',@intStudent_id='0',@intDepartment_id='0',@intTeacher_id='0'," +
                        //"@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "'"
                    "@vchSubject=N'" + encodedStr + "',@vchonlineNotice=N'" + encodedStr1 + "'," +
                        "@vchLectureBy='" + DropDownList8.SelectedValue + "',@vchMeetingId='" + txtusername.Text + "',@vchpassword='" + txtpassword.Text + "',@intInserted_by='" + Session["User_Id"] + "',@InsertIP='" + GetSystemIP() + "',@AcademicID='" + Session["AcademicID"] + "',@intOnlinelecture_id='" + drpLectureName.SelectedValue + "'";


                    sExecuteQuery(strQry);
                    MessageBox("Online Class Details Submitted succefully");
                    fillNotice();
                }
            }


            drpUserType.ClearSelection();
            drpStandard.ClearSelection();
            drpDivision.ClearSelection();
            //txtfromdate.Text = "";
            //txtTodate.Text = "";
            drpLectureName.ClearSelection();
            drpsubject.ClearSelection();
            DropDownList8.ClearSelection();
            TextBox2.Text = "";
            TextBox1.Text = "";
            txtlecturedate.Text = "";
            txtSubject.Text = "";
            txtNotice.Text = "";
            DropDownList8.ClearSelection();
            txtusername.Text = "";
            txtpassword.Text = "";
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

    protected void grdNotice_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            idnotice = Convert.ToInt32(grdNotice.DataKeys[e.RowIndex].Value);
            //Session["Deleteid"] = grdNotice.DataKeys[e.RowIndex].Value;

            strQry = "exec usp_OnlineNocticeBoard  @command='Delete',@intOnlineNotice_id='" + idnotice + "',@intDeletedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchDeletedIp='" + GetSystemIP() + "',@intSchool_id='" + Session["School_id"] + "'";
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
            strQry = "exec usp_OnlineNocticeBoard @command='SelectEditData',@intOnlineNotice_id='" + idnotice + "',@intSchool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                fillDrp();
                string usertype = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
                if (usertype == "0")
                {
                    drpUserType.SelectedIndex =1;
                }
                else
                {
                    drpUserType.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
                }

                if (drpUserType.SelectedValue == "1")
                {
                    lblStandard.Visible = true;
                    drpStandard.Visible = true;
                    Label3.Visible = true;
                    drpDivision.Visible = true;

                    string strQry1 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
                    bool st = sBindDropDownList(drpStandard, strQry1, "Standard_name", "intStandard_id");
                    drpStandard.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);

                    strQry = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + drpStandard.SelectedValue + "' ";
                    bool st2 = sBindDropDownList(drpDivision, strQry, "vchDivisionName", "intDivision_id");
                    drpDivision.Items.Insert(1, "All");

                    if (Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]) != "0")
                    {
                        drpDivision.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);

                         strQry = "Execute usp_OnlineNocticeBoard @command='SelectLecture',@intSchool_id='" + Session["School_id"] + "',@intstandard_id='" + drpStandard.SelectedValue + "',@intDivision_id='" + drpDivision.SelectedValue + "' ";
                         st2 = sBindDropDownList(drpLectureName, strQry, "vchLecture_name", "intOnlinelecture_id");

                    }
                    else
                    {
                        drpDivision.SelectedIndex = 1;
                        strQry = "Execute usp_OnlineNocticeBoard @command='SelectLectureSTD',@intSchool_id='" + Session["School_id"] + "',@intstandard_id='" + drpStandard.SelectedValue + "'";
                        st2 = sBindDropDownList(drpLectureName, strQry, "vchLecture_name", "intOnlinelecture_id");

                    }
                }

                string queryp7 = "Execute dbo.usp_LectureAssign @command='LectureSubject',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intStandard_id='" + drpStandard.SelectedValue + "'";
               bool st7 = sBindDropDownList(drpsubject, queryp7, "vchSubjectName", "intSubject_id");

               drpsubject.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intSubject_id"]);
                drpLectureName.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intOnlinelecture_id"]);
                txtlecturedate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtLecture_date"]);


                DateTime var1 = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtFromTime"]);
                TextBox1.Text = var1.ToString("hh:mm tt");

                DateTime var2 = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtToTime"]);
                TextBox2.Text = var2.ToString("hh:mm tt");

                //txtfromdate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Issue_Date"]);
                //txtTodate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["End_Date"]);
                txtSubject.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Subject"]);
                txtNotice.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Notice"]);
                DropDownList8.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intTeacher_id"]);
                txtusername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMeetingId"]);
                txtpassword.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpassword"]);

                TabContainer1.ActiveTabIndex = 2;
                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
               // fillNotice();
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
        //if (txtfromdate.Text == "")
        //{
        //    MessageBox("Please select from Date!");
        //    return;
        //}
        //if (txtTodate.Text == "")
        //{
        //    MessageBox("Please select to Date!");
        //    return;
        //}
        else if (drpLectureName.Text == "0")
        {
            MessageBox("Please Enter Lecture Name !");
            return;
        }
        else if (txtSubject.Text == "")
        {
            MessageBox("Please Enter Subject!");
            return;
        }
        else if (txtNotice.Text == "")
        {
            MessageBox("Please Enter Notice!");
            return;
        }
        else if (DropDownList8.Text == "")
        {
            MessageBox("Please Select Teacher Name");
            return;
        }
        else if (txtusername.Text == "")
        {
            MessageBox("Please Enter Meeting ID!");
            return;
        }
        else if (txtpassword.Text == "")
        {
            MessageBox("Please Enter Password!");
            return;
        }
        else
        {
            strQry = "";
            int j = 0;



            if (drpUserType.Text == "1")
            {
                if (drpStandard.Text == "All")
                {

                    encodedStr = (encodedStr).Replace("'", "''");
                    encodedStr1 = (encodedStr1).Replace("'", "''");

                    //strQry = "usp_NocticeBoard @command='insert',@intschool_id='" + Session["School_id"] + "',@intUserType_id='1',@intStandard_id='" + stdId.ToString() + "',@intDepartment_id='0',@intTeacher_id='0',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject=N'" + encodedStr + "',@vchNotice=N'" + encodedStr1 + "',@intInserted_by='" + Session["User_Id"] + "',@InsertIP='" + GetSystemIP() + "'";


                    strQry = "usp_OnlineNocticeBoard @command='Update',@intschool_id='" + Session["School_id"] + "',@intUserType_id='1',@intStandard_id='0',@intDivision_id='0',@intStudent_id='0',@intDepartment_id='0',@intTeacher_id='0'," +
                        //  "@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "'"
                    ",@vchSubject=N'" + encodedStr + "',@vchonlineNotice=N'" + encodedStr1 + "',@intOnlinelecture_id='" + drpLectureName.SelectedValue + "'" +
                        "@vchLectureBy='" + DropDownList8.SelectedValue + "',@vchMeetingId='" + txtusername.Text + "',@vchpassword='" + txtpassword.Text + "',@intUpdate_by='" + Session["User_Id"] + "',@UpdateIP='" + GetSystemIP() + "',@intOnlineNotice_id='" + Session["id"] + "'";


                    sExecuteQuery(strQry);
                    MessageBox("Online Class Details Updated succefully");
                    fillNotice();
                    //}

                }
                else
                {
                    stdId = Convert.ToInt32(drpStandard.SelectedItem.Value);

                    encodedStr = (encodedStr).Replace("'", "''");
                    encodedStr1 = (encodedStr1).Replace("'", "''");

                    //strQry = "usp_NocticeBoard @command='insert',@intschool_id='" + Session["School_id"] + "',@intUserType_id='1',@intStandard_id='" + stdId.ToString() + "',@intDepartment_id='0',@intTeacher_id='0',@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "',@vchSubject=N'" + encodedStr + "',@vchNotice=N'" + encodedStr1 + "',@intInserted_by='" + Session["User_Id"] + "',@InsertIP='" + GetSystemIP() + "'";

                    string divisionID = drpDivision.SelectedValue == "All" ? divisionID = "0" : divisionID = drpDivision.SelectedValue;

                    strQry = "usp_OnlineNocticeBoard @command='Update',@intschool_id='" + Session["School_id"] + "',@intUserType_id='1',@intStandard_id='" + drpStandard.SelectedValue + "',@intDivision_id='" + divisionID + "',@intStudent_id='0',@intDepartment_id='0',@intTeacher_id='0'," +
                        // "@dtIssue_date='" + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + "',@dtEnd_date='" + Convert.ToDateTime(txtTodate.Text).ToString("MM/dd/yyyy") + "'"
                    "@vchSubject=N'" + encodedStr + "',@vchonlineNotice=N'" + encodedStr1 + "'," +
                        "@vchLectureBy='" + DropDownList8.SelectedValue + "',@vchMeetingId='" + txtusername.Text + "',@vchpassword='" + txtpassword.Text + "',@intUpdate_by='" + Session["User_Id"] + "',@UpdateIP='" + GetSystemIP() + "',@intOnlineNotice_id='" + Session["id"] + "',@intOnlinelecture_id='" + drpLectureName.SelectedValue + "'";


                    sExecuteQuery(strQry);
                    MessageBox("Online Class Details Updated succefully");
                    fillNotice();
                }
            }

            drpUserType.ClearSelection();
            drpStandard.ClearSelection();
            drpDivision.ClearSelection();
            //txtfromdate.Text = "";
            //txtTodate.Text = "";
            drpLectureName.ClearSelection();
            drpsubject.ClearSelection();
            DropDownList8.ClearSelection();
            TextBox2.Text = "";
            TextBox1.Text = "";
            txtlecturedate.Text = "";
            txtSubject.Text = "";
            txtNotice.Text = "";
            DropDownList8.ClearSelection();
            txtusername.Text = "";
            txtpassword.Text = "";
            btnUpdate.Visible = false;
            btnSubmit.Visible = true;
        }
    }
}


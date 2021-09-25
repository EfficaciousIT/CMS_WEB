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
using System.Globalization;

public partial class frmAdmLectureAssign : DBUtility
{

    public string strQry = string.Empty;
    public string Disquery = string.Empty;
    public int grvDetail1 = 0;
    public string queryp1 = string.Empty;
    public string query2 = string.Empty;
    public string queryp3 = string.Empty;
    public string queryp4 = string.Empty;
    public string query5 = string.Empty;
    public string query6 = string.Empty;
    public string queryp7 = string.Empty;
    public string queryp5 = string.Empty;
    public string Lecname = string.Empty;
    public string insertdt = string.Empty;
    public string ipval = string.Empty;
    public string instremaquery1 = string.Empty;
    public string display = string.Empty;
    public string DeleteIP = string.Empty;

    public string Day = string.Empty;
    public string dtUpdateDate = string.Empty;
    public string updateIP = string.Empty;

    public bool stcardp, st, stcardp2, stcardp4, st5, st6, st7, st2, stcardp5 = true;
    int LectType, stand, Divi, id, seteach = 0;
    int vid, Sess, Peri, Teachnm, Subj, result1, stat, sess = 0;
    DataSet dsObj = new DataSet();


    DateTime CurrentDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                checksession();
                geturl();
                //gridfill1();
                gridfill();
            }
        }
        catch
        {
            throw;

        }
    }
    protected void grvDetail_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grvDetail.PageIndex = e.NewPageIndex;
        gridfill1();


    }

    protected void gridfill1()
    {
        if (drpStandard.Text == "---Select---" && drpDivision.Text == "---Select---" && drpDay.Text == "---Select---")
        {
            Disquery = "Execute dbo.usp_LectureAssign @command='LectureReport',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            grvDetail1 = sBindGrid(grvDetail, Disquery);
        }
        else if (drpStandard.Text != "---Select---" && drpDivision.Text != "---Select---")
        {
            if (drpStandard.Text != "---Select---" && drpDivision.Text != "---Select---" && drpDay.Text != "---Select---")
            {
                Disquery = "Execute dbo.usp_LectureAssign @command='DayWise',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intDivision_id='" + drpDivision.SelectedValue.Trim() + "',@vchDay='" + drpDay.Text.Trim() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                grvDetail1 = sBindGrid(grvDetail, Disquery);
            }
            else
            {
                Disquery = "Execute dbo.usp_LectureAssign @command='Divisionwise',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intDivision_id='" + drpDivision.SelectedValue.Trim() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                grvDetail1 = sBindGrid(grvDetail, Disquery);
            }

        }
        //else if (drpStandard.Text != "---Select---" && drpDivision.Text != "---Select---" && drpDay.Text != "---Select---")
        //{
        //    Disquery = "Execute dbo.usp_LectureAssign @command='DayWise',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intDivision_id='" + drpDivision.SelectedValue.Trim() + "',@vchDay='" + drpDay.Text.Trim() + "'";
        //    grvDetail1 = sBindGrid(grvDetail, Disquery);
        //}         

    }
    protected void gridfill()
    {

        try
        {

            queryp1 = "Execute dbo.usp_LectureAssign @command='LectureType',@intSchool_id='" + Session["School_id"] + "' ";
            stcardp = sBindDropDownList(DropDownList2, queryp1, "vcLecture_type", "intLecture_type");


            query2 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "'";
            st = sBindDropDownList(DropDownList3, query2, "Standard_name", "intStandard_id");
            st = sBindDropDownList(drpStandard, query2, "Standard_name", "intStandard_id");


            queryp3 = "Execute dbo.usp_LectureAssign @command='LectureSession',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            stcardp2 = sBindDropDownList(DropDownList6, queryp3, "SessionName", "intSession_id");
            stcardp2 = sBindDropDownList(drpSession, queryp3, "SessionName", "intSession_id");

            queryp4 = "Execute dbo.usp_LectureAssign @command='LectureTeacher',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            stcardp4 = sBindDropDownList(DropDownList8, queryp4, "Name", "intTeacher_id");

            query5 = "Execute dbo.usp_Profile @command='RemarkDivision1',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intSchool_id='" + Session["School_id"] + "'";
            st5 = sBindDropDownList(DropDownList4, query5, "vchDivisionName", "intDivision_id");
            st5 = sBindDropDownList(drpDivision, query5, "vchDivisionName", "intDivision_id");

            query6 = "Execute dbo.usp_LectureAssign @command='LecturePeriod1',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            st6 = sBindDropDownList(DropDownList7, query6, "TimeName", "intPeriod_id");

            queryp7 = "Execute dbo.usp_LectureAssign @command='LectureSubject',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            st7 = sBindDropDownList(DropDownList9, queryp7, "vchSubjectName", "intSubject_id");


        }
        catch
        {

        }


    }


    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Lecname = Convert.ToString(TextBox1.Text);
            LectType = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            stand = Convert.ToInt32(DropDownList3.SelectedItem.Value);
            Divi = Convert.ToInt32(DropDownList4.SelectedItem.Value);
            Day = Convert.ToString(DropDownList5.SelectedItem.Value);
            Sess = Convert.ToInt32(DropDownList6.SelectedItem.Value);
            Peri = Convert.ToInt32(DropDownList7.SelectedItem.Value);
            Teachnm = Convert.ToInt32(DropDownList8.SelectedItem.Value);
            Subj = Convert.ToInt32(DropDownList9.SelectedItem.Value);

            //long insertby = Convert.ToInt64(Session["User_id"]);
            string insetedby = Convert.ToString(Session["User_id"]);
            insertdt = DateTime.Now.ToString("MM/dd/yyyy");

            ipval = GetSystemIP();

            //Code by Nikhil
            string query1 = "Execute usp_LectureAssign @command='CheckLectureExists',@intTeacher_id='" + Teachnm + "',@intSession_id='" + Sess + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intPeriod_id='" + Peri + "',@vchDay='" + Day + "'"; //"select * from tblLectureSchedules where intTeacher_id='" + Teachnm + "' and intPeriod_id='" + Peri + "' and vchDay='" + str + "' and @intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            int test1 = sExecuteQuery(query1);
            dsObj = sGetDataset(query1);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("At this time already lecture is assigned to this teacher...");
            }
            else
            {
                string query = "Execute usp_LectureAssign @command='Check',@intTeacher_id='" + Teachnm + "',@intSession_id='" + Sess + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intPeriod_id='" + Peri + "',@vchDay='" + Day + "',@intschool_id='" + Session["School_id"] + "',@intStandard_id='" + stand + "',@intDivision_id='" + Divi + "'"; //"select * from tblLectureSchedules where intTeacher_id='" + Teachnm + "' and intPeriod_id='" + Peri + "' and vchDay='" + str + "' and @intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                //int test = sExecuteQuery(query);
                dsObj = sGetDataset(query);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Record already exists...");
                }
                else
                {

                    instremaquery1 = "Execute dbo.usp_LectureAssign @command='LectureSchedule',@vchLecture_name='" + Lecname + "',@intLecture_type='" + LectType + "',@intStandard_id='" + stand + "',@intDivision_id='" + Divi + "',@vchDay='" + Day + "',@intSession_id='" + Sess + "',@intPeriod_id='" + Peri + "',@intTeacher_id='" + Teachnm + "',@intSubject_id='" + Subj + "',@intInerted_by='" + insetedby + "',@dtInsertDate='" + insertdt + "',@InsertIP='" + ipval + "',@intschool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

                    result1 = sExecuteQuery(instremaquery1);

                    if (result1 != -1)
                    {
                        display = "Lecture Assigned Successfully!";
                        MessageBox(display);
                        Clear();
                        gridfill1();
                        gridfill();
                        TabContainer1.ActiveTabIndex = 1;
                    }
                    else
                    {
                        MessageBox("ooopppsss!lecture Assignment Failed");

                    }
                }
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
            DeleteIP = GetSystemIP();
            strQry = "Execute dbo.usp_LectureAssign @command='DeleteSchedule',@intLecture_id='" + id + "',@intschool_id='" + Session["School_id"] + "',@DeleteIP='" + DeleteIP + "',@intDeleteBy='" + Session["user_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully");
                gridfill1();
            }

        }
        catch
        {


        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ////////////////only required field control are enable /////////////////////
        try
        {
            id = Convert.ToInt32(grvDetail.DataKeys[e.NewEditIndex].Value);
            Session["id"] = grvDetail.DataKeys[e.NewEditIndex].Value;

            strQry = "exec dbo.usp_LectureAssign @command='EditLectureReport',@intLecture_id='" + id + "',@intschool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                TextBox2.Text = Convert.ToString(Session["id"]);
                TextBox1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchLecture_name"]);
                DropDownList2.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intLecture_type"]);
                DropDownList3.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);

                stat = Convert.ToInt32(DropDownList3.SelectedItem.Value);
                query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "'";
                st2 = sBindDropDownList(DropDownList4, query2, "vchDivisionName", "intDivision_id");
                DropDownList4.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                DropDownList5.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDay"]);

                DropDownList6.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intSession_id"]);
                DropDownList7.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intPeriod_id"]);
                // DropDownList8.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intTeacher_id"]);

                queryp5 = "Execute dbo.usp_LectureAssign @command='LecSubj',@intStandard_id='" + DropDownList3.SelectedValue.Trim() + "',@vchday='" + DropDownList5.SelectedItem.Text + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                stcardp5 = sBindDropDownList(DropDownList9, queryp5, "vchSubjectName", "intSubject_id");
                //DropDownList9.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intSubject_id"]);
                // DropDownList9.Enabled = false;
                DropDownList7.Enabled = true;
                DropDownList6.Enabled = true;
                Button1.Visible = false;
                Button2.Visible = true;
                TabContainer1.ActiveTabIndex = 1;
                // btnSubmit.Text = "Update";
            }

        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void Clear()
    {

        try
        {
            TextBox1.Text = string.Empty;
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            DropDownList4.Items.Clear();

            DropDownList5.SelectedValue = "Select";
            DropDownList6.Items.Clear();
            DropDownList7.Items.Clear();
            DropDownList8.Items.Clear();
            DropDownList9.Items.Clear();

        }
        catch
        {

        }
    }
    protected void grvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {

            vid = Convert.ToInt32(TextBox2.Text);
            Lecname = Convert.ToString(TextBox1.Text);
            LectType = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            stand = Convert.ToInt32(DropDownList3.SelectedItem.Value);
            Divi = Convert.ToInt32(DropDownList4.SelectedItem.Value);
            Day = Convert.ToString(DropDownList5.SelectedItem.Value);
            Sess = Convert.ToInt32(DropDownList6.SelectedItem.Value);
            Peri = Convert.ToInt32(DropDownList7.SelectedItem.Value);
            Teachnm = Convert.ToInt32(DropDownList8.SelectedItem.Value);
            Subj = Convert.ToInt32(DropDownList9.SelectedItem.Value);

            // long intUpdate_by = Convert.ToInt64(Session["User_id"]);
            string Updateby = Convert.ToString(Session["User_id"]);
            dtUpdateDate = DateTime.Now.ToString("MM/dd/yyyy");

            updateIP = GetSystemIP();


            instremaquery1 = "Execute dbo.usp_LectureAssign @command='LectureScheduleUpdate',@vchLecture_name='" + Lecname + "',@intLecture_type='" + LectType + "',@intStandard_id='" + stand + "',@intDivision_id='" + Divi + "',@vchDay='" + Day + "',@intPeriod_id='" + Peri + "',@intTeacher_id='" + Teachnm + "',@intSubject_id='" + Subj + "',@intUpdate_by='" + Updateby + "',@dtUpdateDate='" + dtUpdateDate + "',@updateIP='" + updateIP + "',@intschool_id='" + Session["School_id"] + "',@intLecture_id='" + vid + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

            int result1 = sExecuteQuery(instremaquery1);

            if (result1 != -1)
            {
                string display = "Card Assignment Modified Successfully!";
                MessageBox(display);
                Clear();
                Button2.Visible = false;
                Button1.Visible = true;
                gridfill1();
                gridfill();
                TabContainer1.ActiveTabIndex = 1;
            }
            else
            {
                MessageBox("ooopppsss!Card Assignment Modification Failed");

            }

        }
        catch
        {

        }


    }
    protected void grvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            stat = Convert.ToInt32(DropDownList3.SelectedItem.Value);

            query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "' ";
            st2 = sBindDropDownList(DropDownList4, query2, "vchDivisionName", "intDivision_id");



        }
        catch
        {

        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        queryp5 = "Execute dbo.usp_LectureAssign @command='LectureSubject',@intStandard_id='" + DropDownList3.SelectedValue.Trim() + "',@vchday='" + DropDownList5.SelectedItem.Text + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        stcardp5 = sBindDropDownList(DropDownList9, queryp5, "vchSubjectName", "intSubject_id");
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        sess = Convert.ToInt32(DropDownList6.SelectedItem.Value);
        query5 = "Execute dbo.usp_LectureAssign @command='LecturePeriod',@intSchool_id='" + Session["School_id"] + "',@intSession_id='" + sess + "',@vchDay='" + DropDownList5.Text.Trim() + "',@intStandard_id='" + DropDownList3.SelectedValue.Trim() + "',@intDivision_id='" + DropDownList4.SelectedValue.Trim() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        st2 = sBindDropDownList(DropDownList7, query5, "TimeName", "intPeriod_id");


    }
    protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
    {


        //seteach = Convert.ToInt32(DropDownList8.SelectedItem.Value);

        //queryp5 = "Execute dbo.usp_LectureAssign @command='LectureSubject',@intSchool_id='" + Session["School_id"] + "',@intUser_id='" + seteach + "',@intStandard_id='" + DropDownList3.SelectedValue.Trim() + "'";
        //stcardp5 = sBindDropDownList(DropDownList9, queryp5, "vchSubjectName", "intSubject_id");


    }
    protected void DropDownList9_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            stat = Convert.ToInt32(drpStandard.SelectedItem.Value);

            query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "' ";
            st2 = sBindDropDownList(drpDivision, query2, "vchDivisionName", "intDivision_id");

            //
            drpDivision.ClearSelection();
            drpDay.ClearSelection();
            grvDetail1 = sBindGrid(grvDetail, query2);
        }
        catch
        {

        }
    }

    protected void drpDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpDay.SelectedValue == "---Select---")
        {
            Disquery = "Execute dbo.usp_LectureAssign @command='Divisionwise',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intDivision_id='" + drpDivision.SelectedValue.Trim() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            grvDetail1 = sBindGrid(grvDetail, Disquery);
        }
        else
        {
            Disquery = "Execute dbo.usp_LectureAssign @command='DayWise',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intDivision_id='" + drpDivision.SelectedValue.Trim() + "',@vchDay='" + drpDay.Text.Trim() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            grvDetail1 = sBindGrid(grvDetail, Disquery);
            drpSession.ClearSelection();
        }
    }
    protected void drpDay_SelectedIndexChanged(object sender, EventArgs e)
    {
        Disquery = "Execute dbo.usp_LectureAssign @command='DayWise',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intDivision_id='" + drpDivision.SelectedValue.Trim() + "',@vchDay='" + drpDay.Text.Trim() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        grvDetail1 = sBindGrid(grvDetail, Disquery);
    }
    protected void drpSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        Disquery = "Execute dbo.usp_LectureAssign @command='SessionWise',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intDivision_id='" + drpDivision.SelectedValue.Trim() + "',@vchDay='" + drpDay.Text.Trim() + "',@intSession_id='" + drpSession.SelectedValue.Trim() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        grvDetail1 = sBindGrid(grvDetail, Disquery);
    }

    //Copy Timetable from last year to current year
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        try
        {
            int intAcademic_id = Convert.ToInt32(Session["AcademicID"]);
            intAcademic_id -= 1;
            //string query1 = "Execute usp_LectureAssign @command='CopyFromLastYear',@intAcademic_id='" + intAcademic_id + "',@intSchool_id='" + Session["School_id"] + "'";

            string query1 = "Execute usp_LectureAssign @command='MoveLecture',@intAcademic_id='" + intAcademic_id + "',@intSchool_id='" + Session["School_id"] + "'";

            dsObj = sGetDataset(query1);
            SqlBulkCopy objbulk = new SqlBulkCopy(getConnectionString());
            //assign Destination table name  
            //objbulk.DestinationTableName = "temptblLectureSchedules";
            //objbulk.WriteToServer(dsObj.Tables[0]);  
            string str;
            string insertby;
            string intSchool_id;
            for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
            {
                try
                {
                    Lecname = Convert.ToString(dsObj.Tables[0].Rows[i]["vchLecture_name"]);
                    LectType = Convert.ToInt32(dsObj.Tables[0].Rows[i]["intLecture_type"]);
                    stand = Convert.ToInt32(dsObj.Tables[0].Rows[i]["intStandard_id"]);
                    Divi = Convert.ToInt32(dsObj.Tables[0].Rows[i]["intDivision_id"]);
                    str = Convert.ToString(dsObj.Tables[0].Rows[i]["vchDay"]);
                    Sess = Convert.ToInt32(dsObj.Tables[0].Rows[i]["intSession_id"]);
                    Peri = Convert.ToInt32(dsObj.Tables[0].Rows[i]["intPeriod_id"]);
                    Teachnm = Convert.ToInt32(dsObj.Tables[0].Rows[i]["intTeacher_id"]);
                    Subj = Convert.ToInt32(dsObj.Tables[0].Rows[i]["intSubject_id"]);
                    insertby = null;
                    insertdt = null;
                    ipval = null;
                    intSchool_id = Convert.ToString(dsObj.Tables[0].Rows[i]["intSchool_id"]);

                    query1 = "Execute usp_LectureAssign @command='CheckLectureExists',@intTeacher_id='" + Teachnm + "',@intSession_id='" + Sess + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intPeriod_id='" + Peri + "',@vchDay='" + str + "'";
                    int test1 = sExecuteQuery(query1);
                    if (test1 < 1)
                    {
                        instremaquery1 = "Execute dbo.usp_LectureAssign @command='LectureSchedule',@vchLecture_name='" + Lecname + "',@intLecture_type='" + LectType + "',";
                        instremaquery1 += "@intStandard_id='" + stand + "',@intDivision_id='" + Divi + "',@vchDay='" + str + "',@intSession_id='" + Sess + "',@intPeriod_id='" + Peri + "',";
                        instremaquery1 += "@intTeacher_id='" + Teachnm + "',@intSubject_id='" + Subj + "',@intInerted_by='" + insertby + "',@dtInsertDate='" + insertdt + "',";
                        instremaquery1 += "@InsertIP='" + ipval + "',@intschool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

                        result1 = sExecuteQuery(instremaquery1);
                    }
                }
                catch (Exception ex)
                {
                }
                btnCopy.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }


}







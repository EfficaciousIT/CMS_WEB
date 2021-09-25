using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmAdmOnlineLectureCreation : DBUtility
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
            drpDivision.Visible = false;
            Label1.Visible = false;
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
        if (drpStandard.Text == "---Select---" && drpDivision.Text == "---Select---")
        {
            Disquery = "Execute dbo.usp_onlineLecture @command='FillGrid',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            grvDetail1 = sBindGrid(grvDetail, Disquery);
        }
        else if (drpStandard.Text != "---Select---" && drpDivision.Text != "---Select---")
        {
            if (drpStandard.Text != "---Select---" )
            {
                Disquery = "Execute dbo.usp_onlineLecture @command='StandardWiseDataForWeb',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intDivision_id='" + drpDivision.SelectedValue.Trim() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                grvDetail1 = sBindGrid(grvDetail, Disquery);
            }
            else
            {
                Disquery = "Execute dbo.usp_onlineLecture @command='DivisionWiseList',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intDivision_id='" + drpDivision.SelectedValue.Trim() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                grvDetail1 = sBindGrid(grvDetail, Disquery);
            }

        }
        else if (drpStandard.Text != "---Select---")
        {
            Disquery = "Execute dbo.usp_onlineLecture @command='StandardWiseList',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intDivision_id='" + drpDivision.SelectedValue.Trim() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            grvDetail1 = sBindGrid(grvDetail, Disquery);
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

          
            query2 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "'";
            st = sBindDropDownList(DropDownList3, query2, "Standard_name", "intStandard_id");
            st = sBindDropDownList(drpStandard, query2, "Standard_name", "intStandard_id");

           
            queryp4 = "Execute dbo.usp_LectureAssign @command='LectureTeacher',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            stcardp4 = sBindDropDownList(DropDownList8, queryp4, "Name", "intTeacher_id");

            query5 = "Execute dbo.usp_Profile @command='RemarkDivision1',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intSchool_id='" + Session["School_id"] + "'";
            st5 = sBindDropDownList(DropDownList4, query5, "vchDivisionName", "intDivision_id");
            st5 = sBindDropDownList(drpDivision, query5, "vchDivisionName", "intDivision_id");

          
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
            DateTime v1 = Convert.ToDateTime(TextBox3.Text);
            string Periodfrom = v1.ToString("HH:mm");
            DateTime v2 = Convert.ToDateTime(TextBox4.Text);
            string PeriodTo = v2.ToString("HH:mm"); 

          
                     
                        Lecname = Convert.ToString(TextBox1.Text);
                       
                        stand = Convert.ToInt32(DropDownList3.SelectedItem.Value);
                       // Divi = Convert.ToInt32(DropDownList4.SelectedItem.Value);

                        string DivisionID = DropDownList4.SelectedValue == "All" ? DivisionID = "0" : DivisionID = DropDownList4.SelectedValue;


                        string lecturedate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy");

                        Teachnm = Convert.ToInt32(DropDownList8.SelectedItem.Value);
                        Subj = Convert.ToInt32(DropDownList9.SelectedItem.Value);

                        long insertby = Convert.ToInt64(Session["User_id"]);

                        insertdt = DateTime.Now.ToString("MM/dd/yyyy");

                        ipval = GetSystemIP();
                        strQry = "usp_onlineLecture @command='CheckExists',@dtLecture_date='" + lecturedate + "',@dtFromTime='" + Periodfrom + "',@dtToTime='" + PeriodTo + "',@intTeacher_id='" + Teachnm + "'";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count == 0)
                        {

                            instremaquery1 = "Execute dbo.usp_onlineLecture @command='insertOnlineLecture',@vchLecture_name='" + TextBox1.Text + "',@intStandard_id='" + stand + "',@intDivision_id='" + DivisionID + "',@dtLecture_date='" + lecturedate + "',@dtFromTime='" + Periodfrom + "',@dtToTime='" + PeriodTo + "',@intTeacher_id='" + Teachnm + "',@intSubject_id='" + Subj + "',@intInsertby='" + insertby + "',@InsertIP='" + ipval + "',@intschool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

                            result1 = sExecuteQuery(instremaquery1);
                            display = "Lecture Assigned Successfully!";
                            MessageBox(display);

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
                        else
                        {
                            display = "Teacher is not available at this date and time ";
                            MessageBox(display);
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
            strQry = "Execute dbo.usp_onlineLecture @command='DeletePediod',@intOnlinelecture_id='" + id + "',@intschool_id='" + Session["School_id"] + "',@DeleteIP='" + DeleteIP + "',@intDeleteBy='" + Session["user_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
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

            strQry = "exec dbo.usp_onlineLecture @command='EditPediod',@intOnlinelecture_id='" + id + "',@intschool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                TextBox2.Text = Convert.ToString(Session["id"]);
                TextBox1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchLecture_name"]);
              
                DropDownList3.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);

                stat = Convert.ToInt32(DropDownList3.SelectedItem.Value);
                query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "'";
                st2 = sBindDropDownList(DropDownList4, query2, "vchDivisionName", "intDivision_id");

                DropDownList4.Items.Insert(1, "All");

                DropDownList4.SelectedValue = "All";

               // DropDownList4.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);

                //txtDate.Text  = Convert.ToString(dsObj.Tables[0].Rows[0]["dtLecture_date"]);
                DateTime var = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtLecture_date"]);
                txtDate.Text = var.ToString("dd/MM/yyyy").Replace("-","/");

               // TextBox3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtFromTime"]);
                DateTime var1 = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtFromTime"]);

                TextBox3.Text = var1.ToString("hh:mm tt");


                //TextBox4.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtToTime"]);

                DateTime var2 = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtToTime"]);
                TextBox4.Text = var2.ToString("hh:mm tt");

                DropDownList8.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intTeacher_id"]);

                queryp5 = "Execute dbo.usp_LectureAssign @command='LecSubj',@intStandard_id='" + DropDownList3.SelectedValue.Trim() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                stcardp5 = sBindDropDownList(DropDownList9, queryp5, "vchSubjectName", "intSubject_id");
                DropDownList9.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intSubject_id"]);
                // DropDownList9.Enabled = false;
               
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
           
            DropDownList3.Items.Clear();
            DropDownList4.Items.Clear();

            txtDate.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";

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
           
            stand = Convert.ToInt32(DropDownList3.SelectedItem.Value);
            //Divi = Convert.ToInt32(DropDownList4.SelectedItem.Value);

            string DivisionID = DropDownList4.SelectedValue == "All" ? DivisionID = "0" : DivisionID = DropDownList4.SelectedValue;


            string lecturedate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy");

            //string fromtime = Convert.ToDateTime(TextBox3.Text).ToString("dd/MM/yyyy");
            //string Totime = Convert.ToDateTime(TextBox4.Text).ToString("dd/MM/yyyy");


            DateTime v1 = Convert.ToDateTime(TextBox3.Text);
            string Periodfrom = v1.ToString("HH:mm");
            DateTime v2 = Convert.ToDateTime(TextBox4.Text);
            string PeriodTo = v2.ToString("HH:mm"); ;


            Teachnm = Convert.ToInt32(DropDownList8.SelectedItem.Value);
            Subj = Convert.ToInt32(DropDownList9.SelectedItem.Value);

            long intUpdate_by = Convert.ToInt64(Session["User_id"]);

            dtUpdateDate = DateTime.Now.ToString("MM/dd/yyyy");

            updateIP = GetSystemIP();


            instremaquery1 = "Execute dbo.usp_onlineLecture @command='UpdatePediod',@vchLecture_name='" + Lecname + "',@intStandard_id='" + stand + "',@intDivision_id='" + DivisionID + "',@dtLecture_date='" + lecturedate + "',@dtFromTime='" + Periodfrom + "',@dtToTime='" + PeriodTo + "',@intTeacher_id='" + Teachnm + "',@intSubject_id='" + Subj + "',@intUpdatedBy='" + intUpdate_by + "',@dtUpdateDate='" + dtUpdateDate + "',@updateIP='" + updateIP + "',@intschool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intOnlinelecture_id='" + Session["id"] + "'";

            int result1 = sExecuteQuery(instremaquery1);

            if (result1 != -1)
            {
                string display = "Lecture Updated Successfully!";
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
                MessageBox("ooopppsss!Lecture not updated");

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

            DropDownList4.Items.Insert(1, "All");

            DropDownList4.SelectedValue = "All";

        }
        catch
        {

        }
    }
  
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

  
   
    protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
    {


        seteach = Convert.ToInt32(DropDownList8.SelectedItem.Value);

        queryp5 = "Execute dbo.usp_LectureAssign @command='LectureSubject',@intSchool_id='" + Session["School_id"] + "',@intUser_id='" + seteach + "',@intStandard_id='" + DropDownList3.SelectedValue.Trim() + "'";
        stcardp5 = sBindDropDownList(DropDownList9, queryp5, "vchSubjectName", "intSubject_id");


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
            drpDivision.ClearSelection();
            gridfill1();
        }
        catch
        {

        }
    }

    protected void drpDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridfill1();
    }
    protected void drpDay_SelectedIndexChanged(object sender, EventArgs e)
    {
        Disquery = "Execute dbo.usp_LectureAssign @command='DayWise',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intDivision_id='" + drpDivision.SelectedValue.Trim() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        grvDetail1 = sBindGrid(grvDetail, Disquery);
    }
    protected void drpSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        Disquery = "Execute dbo.usp_LectureAssign @command='SessionWise',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intDivision_id='" + drpDivision.SelectedValue.Trim() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        grvDetail1 = sBindGrid(grvDetail, Disquery);
    }

}
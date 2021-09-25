using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class frmMarkEntry1and2 : DBUtility
{
    string strQry = string.Empty;
    int CountSubject = 0;
    DataSet dsObj = new DataSet();
    int subjectId = 0;
    string subjectNm = "";
    bool checkPostback = false;
    // a Property that manages a counter stored in ViewState
    protected int NumberOfControls
    {
        get { return (int)ViewState["NumControls"]; }
        set { ViewState["NumControls"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                //
                FillSubjectMarksGridDynamically();
                EnglishActivityMarksGridDynamically();
                EnglishReaderMarksGridDynamically();
                NumberWorkMarkGridDynamically();
                SecondLanguageMarksGridDynamically();
                SecondLanguageBengaliMarksGridDynamically();
                EVSMarkGridDynamically();
                ComputerMarkGridDynamically();
                SkillMarksGridDynamically();
                workhabitGridDynamically();
                FillPersonalMarksGridDynamically();
                FillAttendanceRemarkGridDynamically();
                checkPostback = true;
                //TabPanel4.Visible = false;
                //TabPanel5.Visible = false;
                //TabPanel6.Visible = false;
                if (!IsPostBack)
                {

                   //FillSTD();
                    ddlSTD2_SelectedIndexChanged(null, null);
                    ddlStudent2_SelectedIndexChanged(null, null);
                    ddlDIV2_SelectedIndexChanged(null, null);

                    if (Convert.ToString(Session["UserType_Id"]) == "3")
                    {

                        ddlSTD2.SelectedValue = Convert.ToString(Session["Standard_id"]);
                        ddlSTD2_SelectedIndexChanged(null, null);
                        ddlSTD2.Enabled = false;

                        ddlDIV2.SelectedValue = Convert.ToString(Session["Division_id"]);
                        ddlDIV2_SelectedIndexChanged(null, null);
                        ddlDIV2.Enabled = false;

                        ddlSTD1.SelectedValue = Convert.ToString(Session["Standard_id"]);
                        ddlSTD1_SelectedIndexChanged(null, null);
                        ddlSTD1.Enabled = false;

                        ddlDIV1.SelectedValue = Convert.ToString(Session["Division_id"]);
                        //ddlDiv1_SelectedIndexChanged(null, null);
                        ddlDIV1.Enabled = false;

                        ddlGender.SelectedValue = Convert.ToString(Session["Gender"]);
                        //ddlGender_SelectedIndexChanged(null, null);
                        ddlGender.Enabled = false;


                        

                    }
                    else if (Convert.ToString(Session["UserType_Id"]) == "2" || Convert.ToString(Session["UserType_Id"]) == "1")
                    {
                        lblName.Visible = false;
                        lblGetName.Visible = false;
                        MainTab.Tabs[1].Visible = false;
                        ddlSTD2.Visible = false;
                        ddlDIV2.Visible = false;
                        ddlStudent2.Visible = false;
                        lblSTD2.Visible = false;
                        lblDIV2.Visible = false;
                        lblStud.Visible = false;
                        ddlSTD2.SelectedValue = Convert.ToString(Session["Standard_id"]);
                        ddlSTD2_SelectedIndexChanged(null, null);
                        ddlDIV2.SelectedValue = Convert.ToString(Session["Division_id"]);
                        ddlStudent2_SelectedIndexChanged(null, null);
                        ddlExam2_SelectedIndexChanged(null, null);
                    }

                }

                //FillMarksGridDynamically();
                //else
                //{
                //    if (checkPostback == true)
                //    {
                //        grvMarks.DataSource = null;
                //        grvMarks.DataBind();
                //       // checkPostback = false;
                //        FillMarksGridDynamically();
                //        btnSubmit1_Click(null, null);
                //    }
                //}
            }
            else
            {
                Response.Redirect("~\\Index.aspx", false);
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
            if (Convert.ToString(Session["UserType_Id"]) == "3")
            {
                strQry = "exec [usp_getAttendance] @type='FillStd',@TeacherId='" + Convert.ToString(Session["User_id"]) + "',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD2, strQry, "vchStandard_name", "intstandard_id");
                sBindDropDownList(ddlSTD1, strQry, "vchStandard_name", "intstandard_id");
                FillDIV();
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD2, strQry, "vchStandard_name", "intstandard_id");
                sBindDropDownList(ddlSTD1, strQry, "vchStandard_name", "intstandard_id");
                FillDIV();
            }
            else
            {
                strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD2, strQry, "vchStandard_name", "intstandard_id");
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

            strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlDIV1, strQry, "vchDivisionName", "intDivision_id");
            FillStudent();
        }
        catch
        {

        }
    }

    public void FillStudent()
    {
        try
        {

            strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV2.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlStudent, strQry, "Name", "intStudent_id");
            strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlStud, strQry, "Name", "intStudent_id");
        }
        catch
        {

        }
    }

    public void FillExamination()
    {
        try
        {

            strQry = "exec usp_ExamMarks @type='FillExamination',@intSchool_id='" + Session["School_id"] + "'";  //+ "',@intDivision_id='" + ddlDIV2.SelectedValue.ToString() 
            sBindDropDownList(ddlExam, strQry, "vchExamination_name", "intExam_id");

            //strQry = "exec usp_ExamMarks @type='FillExamination',@intSchool_id='" + Session["School_id"] + "',@intDivision_id='" + ddlDIV1.SelectedValue + "'";
            //sBindDropDownList(ddlExam1, strQry, "vchExamination_name", "intExam_id"); // previus m 
            strQry = "exec usp_ExamMarks @type='FillExamination1and2',@intSchool_id='" + Session["School_id"] + "'";  //+ "',@intStandard_id='" + ddlSTD1.SelectedValue 
            sBindDropDownList(ddlExam1, strQry, "vchExamination_name", "intExam_id");
        }
        catch
        {

        }
    }

    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDIV();
    }
    protected void ddlDiv_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStudent();
    }
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillExamination();
    }
    
    protected void ddlExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillSubjectMarksDetails();
            FillEnglishActivityMarksDetails();
            fillEnglishReaderMarkDetails();
            FillNumberWorkMarkDetails();
            FillSecondLanguageMarkDetails();
            FillSecondLanguageBengaliMarkDetails();
            FillEVSMarkDetails();
            FillPersonalDetails();
        }
        catch
        {

        }
    }
    protected void ddlExam1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // if(checkPostback==false)
        try
        {
            //string view = ddlExam1.SelectedValue.ToString();
            //int view1 = int.Parse(view);
            //if (view1 == 7 || view1==11)
            //{
            //    TabPanel4.Visible = true;
            //    TabPanel5.Visible = true;
            //    TabPanel6.Visible = true;
            //}
            FillSubjectMarksGridDynamically();
            EnglishActivityMarksGridDynamically();
            EnglishReaderMarksGridDynamically();
            NumberWorkMarkGridDynamically();
            SecondLanguageMarksGridDynamically();
            SecondLanguageBengaliMarksGridDynamically();
            EVSMarkGridDynamically();
            FillPersonalMarksGridDynamically();

            //strQry = "exec usp_ExamMarks @type='FillExamSubject',@intExam_id='" + ddlExam1.SelectedValue + "',@intDivision_id='" + ddlDIV1.SelectedValue + "'";
            strQry = "exec usp_ExamMarks @type='FillExamSubject',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);


            strQry = "exec usp_ExamMarks @type='FillSubjectEnglishActivity',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

            strQry = "exec usp_ExamMarks @type='FillSubjectEnglishReader',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            dsObj = sGetDataset(strQry);
            CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

            strQry = "exec usp_ExamMarks @type='FillSubjectNumberWork',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            dsObj = sGetDataset(strQry);
            CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

            strQry = "exec usp_ExamMarks @type='FillSubjectSecondLanguage',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            dsObj = sGetDataset(strQry);
            CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

            strQry = "exec usp_ExamMarks @type='FillSubjectSecondbengaliLanguage',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            dsObj = sGetDataset(strQry);
            CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

            strQry = "exec usp_ExamMarks @type='FillSubjectEVS',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            dsObj = sGetDataset(strQry);
            CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);
        }
        catch
        {


        }
    }

    public void FillSubjectMarksDataGrid()
    {
        try
        {
            // strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "'";

            dsObj = sGetDataset(strQry);
            GridView9.DataSource = dsObj;
            GridView9.DataBind();
            //GridView1.DataSource = dsObj;
            //GridView1.DataBind();


            strQry = "exec usp_ExamMarks @type='FillMarks',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //SubMaxMarks.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["intMaxMark"]);
                for (int i = 0; i < GridView9.Rows.Count; i++)
                {
                    for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                    {
                        subjectId = Convert.ToInt32((GridView9.Columns.Count - 2) / 2) + 1;

                        for (int j = 1; j < (GridView9.Columns.Count / 2); j++)
                        {
                            Label lblStudent = (Label)GridView9.Rows[i].FindControl("lblStudentId");
                            if (Convert.ToString(lblStudent.Text).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intStudent_id"]).Trim())
                            {
                                subjectId = subjectId + 1;
                                if (Convert.ToString(GridView9.Columns[subjectId].HeaderText).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intSubject_id"]).Trim())
                                {
                                    string decmark = Convert.ToString(dsObj.Tables[0].Rows[k]["decMark"]).Trim();
                                    TextBox txtmark = (TextBox)GridView9.Rows[i].FindControl("txtSub" + j.ToString());
                                    string vchgrade = txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["decMark"]).Trim();
                                    if (vchgrade == "-1")
                                    {
                                        txtmark.Text = "NA";
                                    }
                                    else if (vchgrade == "-2")
                                    {
                                        txtmark.Text = "AB";
                                    }
                                    else
                                    {
                                        txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["decMark"]).Trim();
                                    }
                                    //j = j + 1;
                                }
                                //else
                                //{
                                //    TextBox txtmark = (TextBox)grvMarks.Rows[i].FindControl("txtSub" + j.ToString());
                                //    txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["decMark"]).Trim();
                                //}
                            }

                        }

                    }
                }

            }
        }
        catch
        {

        }
    }
    public void FillSubjectMarksGridDynamically()
    {
        try
        {
            //GridView grv = new GridView();
            //grv.ID = "grvMarks";
            //grv.AutoGenerateColumns = false;
            //grv.Width = 500;
            //grv.CssClass = "mGrid";
            if (ddlExam1.SelectedValue != "0" && ddlExam1.SelectedValue != "")
            {

                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
                DataTable grid = new DataTable();
                //strQry = "exec usp_ExamMarks @type='FillExamSubject',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "'";              
                strQry = "exec usp_ExamMarks @type='FillExamSubject',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

                for (int i = 0; i < CountSubject; i++)
                {
                    // grvMarks.HeaderRow.Cells[i + 2].Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);

                    GridView9.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);
                    GridView9.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                    //GridView1.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);
                    //GridView1.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                }



                for (int i = GridView9.Columns.Count - 1; i > CountSubject + 1; i--)
                {
                    GridView9.Columns.RemoveAt(i);
                    // GridView1.Columns.RemoveAt(i);
                }
                //for (int i = GridView1.Columns.Count - 1; i > CountSubject + 1; i--)
                //{
                //    GridView1.Columns.RemoveAt(i);
                //}


                for (int i = 0; i < CountSubject; i++)
                {
                    TemplateField temp = new TemplateField();
                    temp.HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["intSubject_id"]);
                    temp.Visible = false;
                    GridView9.Columns.Add(temp);
                    //GridView1.Columns.Add(temp);
                }

                //--------For Empty Row-----///

                grid.Rows.Add(grid.NewRow());
                //GridView1.DataSource =grid;
                //GridView1.DataBind();
                //GridView1.Rows[0].Visible = false;
                //----------End-----------//

                // grvMarks.DataBind();

                FillSubjectMarksDataGrid();
                btnSubmit1.Visible = true;
                btnClear1.Visible = true;
                checkPostback = true;

            }
            else
            {
                GridView9.DataSource = null;
                GridView9.DataBind();

                //GridView1.DataSource = null;
                //GridView1.DataBind();

                for (int i = GridView9.Columns.Count - 1; i > 1; i--)
                {
                    GridView9.Columns.RemoveAt(i);
                    //  GridView1.Columns.RemoveAt(i);
                }
                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
            }
        }
        catch
        {

        }

    }
    public void FillSubjectMarksDetails()
    {
        try
        {
            strQry = "exec usp_ExamMarks @type='FillExamSubject',@intExam_id='" + ddlExam.SelectedValue + "',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            Table tbl = new Table();
            // tbl.BorderWidth = 1;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    TableCell td1 = new TableCell();
                    TableCell td2 = new TableCell();
                    TableCell td3 = new TableCell();

                    Label lbl = new Label();
                    lbl.ID = Convert.ToString(dsObj.Tables[0].Rows[i]["intSubject_id"]);
                    lbl.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);

                    td.Controls.Add(lbl);

                    TextBox txt = new TextBox();
                    txt.ID = "txt" + i.ToString();
                    txt.Width = 70;
                    td1.Controls.Add(txt);


                    TextBox txtT = new TextBox();
                    txtT.ID = "txtT" + i.ToString();
                    txtT.Enabled = false;
                    txtT.Text = "100";
                    txtT.Width = 70;
                    td2.Controls.Add(txtT);


                    td3.Width = 20;


                    tr.Controls.Add(td);
                    tr.Controls.Add(td1);
                    tr.Controls.Add(td3);
                    tr.Controls.Add(td2);
                    tbl.Controls.Add(tr);
                }
                btnSubmit.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
                btnClear.Visible = false;
            }
            divTable.Controls.Add(tbl);
        }
        catch
        {
        }
    }

    public void FillEnglishActivityMarksDataGrid()
    {
        try
        {
           // strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            grvMarks.DataSource = dsObj;
            grvMarks.DataBind();
            //GridView1.DataSource = dsObj;
            //GridView1.DataBind();


            strQry = "exec usp_ExamMarks @type='FillEnglishActivitySkill',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //SubMaxMarks.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["intMaxMark"]);
                for (int i = 0; i < grvMarks.Rows.Count; i++)
                {
                    for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                    {
                        subjectId = Convert.ToInt32((grvMarks.Columns.Count - 2) / 2) + 1;

                        for (int j = 1; j < (grvMarks.Columns.Count / 2); j++)
                        {
                            Label lblStudent = (Label)grvMarks.Rows[i].FindControl("lblStudentId");
                            if (Convert.ToString(lblStudent.Text).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intStudent_id"]).Trim())
                            {
                                subjectId = subjectId + 1;
                                if (Convert.ToString(grvMarks.Columns[subjectId].HeaderText).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intSubject_id"]).Trim())
                                {
                                    TextBox txtmark = (TextBox)grvMarks.Rows[i].FindControl("txtSub" + j.ToString());
                                   string vchgrade = txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    if (vchgrade == "-1")
                                    {
                                        txtmark.Text = "NA";
                                    }
                                    else if (vchgrade == "-2")
                                    {
                                        txtmark.Text = "AB";
                                    }
                                    else
                                    {
                                        txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    }
                                    //j = j + 1;
                                }
                                //else
                                //{
                                //    TextBox txtmark = (TextBox)grvMarks.Rows[i].FindControl("txtSub" + j.ToString());
                                //    txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["decMark"]).Trim();
                                //}
                            }

                        }

                    }
                }

            }
        }
        catch
        {

        }
    }
    public void EnglishActivityMarksGridDynamically()
    {
        try
        {
            //GridView grv = new GridView();
            //grv.ID = "grvMarks";
            //grv.AutoGenerateColumns = false;
            //grv.Width = 500;
            //grv.CssClass = "mGrid";
            if (ddlExam1.SelectedValue != "0" && ddlExam1.SelectedValue != "")
            {

                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
                DataTable grid = new DataTable();
                //strQry = "exec usp_ExamMarks @type='FillExamSubject',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "'";              
                strQry = "exec usp_ExamMarks @type='FillSubjectEnglishActivity',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

                for (int i = 0; i < CountSubject; i++)
                {
                    // grvMarks.HeaderRow.Cells[i + 2].Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);

                    grvMarks.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["vchName"]);
                    grvMarks.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                    //GridView1.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);
                    //GridView1.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                }



                for (int i = grvMarks.Columns.Count - 1; i > CountSubject + 1; i--)
                {
                    grvMarks.Columns.RemoveAt(i);
                    // GridView1.Columns.RemoveAt(i);
                }
                //for (int i = GridView1.Columns.Count - 1; i > CountSubject + 1; i--)
                //{
                //    GridView1.Columns.RemoveAt(i);
                //}


                for (int i = 0; i < CountSubject; i++)
                {
                    TemplateField temp = new TemplateField();
                    temp.HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["id"]);
                    temp.Visible = false;
                    grvMarks.Columns.Add(temp);
                    //GridView1.Columns.Add(temp);
                }

                //--------For Empty Row-----///

                grid.Rows.Add(grid.NewRow());
                //GridView1.DataSource =grid;
                //GridView1.DataBind();
                //GridView1.Rows[0].Visible = false;
                //----------End-----------//

                // grvMarks.DataBind();

                FillEnglishActivityMarksDataGrid();
                btnSubmit1.Visible = true;
                btnClear1.Visible = true;
                checkPostback = true;

            }
            else
            {
                grvMarks.DataSource = null;
                grvMarks.DataBind();

                //GridView1.DataSource = null;
                //GridView1.DataBind();

                for (int i = grvMarks.Columns.Count - 1; i > 1; i--)
                {
                    grvMarks.Columns.RemoveAt(i);
                    //  GridView1.Columns.RemoveAt(i);
                }
                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
            }
        }
        catch
        {

        }
    }
    public void FillEnglishActivityMarksDetails()
    {
        try
        {
            strQry = "exec usp_ExamMarks @type='FillSubjectEnglishActivity',@intExam_id='" + ddlExam.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            Table tbl = new Table();
            // tbl.BorderWidth = 1;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    TableCell td1 = new TableCell();
                    TableCell td2 = new TableCell();
                    TableCell td3 = new TableCell();

                    Label lbl = new Label();
                    lbl.ID = Convert.ToString(dsObj.Tables[0].Rows[i]["intSubject_id"]);
                    lbl.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);

                    td.Controls.Add(lbl);

                    TextBox txt = new TextBox();
                    txt.ID = "txt" + i.ToString();
                    txt.Width = 70;
                    td1.Controls.Add(txt);


                    TextBox txtT = new TextBox();
                    txtT.ID = "txtT" + i.ToString();
                    txtT.Enabled = false;
                    txtT.Text = "100";
                    txtT.Width = 70;
                    td2.Controls.Add(txtT);


                    td3.Width = 20;


                    tr.Controls.Add(td);
                    tr.Controls.Add(td1);
                    tr.Controls.Add(td3);
                    tr.Controls.Add(td2);
                    tbl.Controls.Add(tr);
                }
                btnSubmit.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
                btnClear.Visible = false;
            }
            divTable.Controls.Add(tbl);
        }
        catch
        {
        }
    }



    public void EnglishReaderMarksGridDynamically()
    {
        try
        {
            //GridView grv = new GridView();
            //grv.ID = "grvMarks";
            //grv.AutoGenerateColumns = false;
            //grv.Width = 500;
            //grv.CssClass = "mGrid";
            if (ddlExam1.SelectedValue != "0" && ddlExam1.SelectedValue != "")
            {

                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
                DataTable grid = new DataTable();
                //strQry = "exec usp_ExamMarks @type='FillExamSubject',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "'";              
                strQry = "exec usp_ExamMarks @type='FillSubjectEnglishReader',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

                for (int i = 0; i < CountSubject; i++)
                {
                    // grvMarks.HeaderRow.Cells[i + 2].Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);

                    GridView1.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["VchName"]);
                    GridView1.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                    //GridView1.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);
                    //GridView1.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                }



                for (int i = GridView1.Columns.Count - 1; i > CountSubject + 1; i--)
                {
                    GridView1.Columns.RemoveAt(i);
                    // GridView1.Columns.RemoveAt(i);
                }
                //for (int i = GridView1.Columns.Count - 1; i > CountSubject + 1; i--)
                //{
                //    GridView1.Columns.RemoveAt(i);
                //}


                for (int i = 0; i < CountSubject; i++)
                {
                    TemplateField temp = new TemplateField();
                    temp.HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["id"]);
                    temp.Visible = false;
                    GridView1.Columns.Add(temp);
                    //GridView1.Columns.Add(temp);
                }

                //--------For Empty Row-----///

                grid.Rows.Add(grid.NewRow());
                //GridView1.DataSource =grid;
                //GridView1.DataBind();
                //GridView1.Rows[0].Visible = false;
                //----------End-----------//

                // grvMarks.DataBind();

                FillSubjectReaderMarksDataGrid();
                btnSubmit1.Visible = true;
                btnClear1.Visible = true;
                checkPostback = true;

            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();

                //GridView1.DataSource = null;
                //GridView1.DataBind();

                for (int i = GridView1.Columns.Count - 1; i > 1; i--)
                {
                    GridView1.Columns.RemoveAt(i);
                    //  GridView1.Columns.RemoveAt(i);
                }
                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
            }
        }
        catch
        {

        }
    }
    public void FillSubjectReaderMarksDataGrid()
    {
        try
        {
            //strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "'";
            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "'";


            dsObj = sGetDataset(strQry);
            GridView1.DataSource = dsObj;
            GridView1.DataBind();


            strQry = "exec usp_ExamMarks @type='FillEnglishReaderSkill',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //SubMaxMarks.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["intMaxMark"]);
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                    {
                        subjectId = Convert.ToInt32((GridView1.Columns.Count - 2) / 2) + 1;

                        for (int j = 1; j < (GridView1.Columns.Count / 2); j++)
                        {
                            Label lblStudent = (Label)GridView1.Rows[i].FindControl("lblStudentId");
                            if (Convert.ToString(lblStudent.Text).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intStudent_id"]).Trim())
                            {
                                subjectId = subjectId + 1;
                                if (Convert.ToString(GridView1.Columns[subjectId].HeaderText).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intSubject_id"]).Trim())
                                {
                                    TextBox txtmark = (TextBox)GridView1.Rows[i].FindControl("txtSub" + j.ToString());
                                    string vchgrade = txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    if (vchgrade == "-1")
                                    {
                                        txtmark.Text = "NA";
                                    }
                                    else if (vchgrade == "-2")
                                    {
                                        txtmark.Text = "AB";
                                    }
                                    else
                                    {
                                        txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    }
                                    //j = j + 1;
                                }
                                //else
                                //{
                                //    TextBox txtmark = (TextBox)grvMarks.Rows[i].FindControl("txtSub" + j.ToString());
                                //    txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                //}
                            }

                        }

                    }
                }

            }
        }
        catch
        {

        }
    }
    public void fillEnglishReaderMarkDetails()
    {
        try
        {
            strQry = "exec usp_ExamMarks @type='FillSubjectEnglishReader',@intExam_id='" + ddlExam.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            Table tbl = new Table();
            // tbl.BorderWidth = 1;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    TableCell td1 = new TableCell();
                    TableCell td2 = new TableCell();
                    TableCell td3 = new TableCell();

                    Label lbl = new Label();
                    lbl.ID = Convert.ToString(dsObj.Tables[0].Rows[i]["id"]);
                    lbl.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["VchName"]);

                    td.Controls.Add(lbl);

                    TextBox txt = new TextBox();
                    txt.ID = "txt" + i.ToString();
                    txt.Width = 70;
                    td1.Controls.Add(txt);


                    TextBox txtT = new TextBox();
                    txtT.ID = "txtT" + i.ToString();
                    txtT.Enabled = false;
                    txtT.Text = "100";
                    txtT.Width = 70;
                    td2.Controls.Add(txtT);


                    td3.Width = 20;


                    tr.Controls.Add(td);
                    tr.Controls.Add(td1);
                    tr.Controls.Add(td3);
                    tr.Controls.Add(td2);
                    tbl.Controls.Add(tr);
                }
                btnSubmit.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
                btnClear.Visible = false;
            }
            divTable.Controls.Add(tbl);
        }
        catch
        {
        }

    }


    public void NumberWorkMarkGridDynamically()
    {
        try
        {

            if (ddlExam1.SelectedValue != "0" && ddlExam1.SelectedValue != "")
            {

                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
                DataTable grid = new DataTable();
                strQry = "exec usp_ExamMarks @type='FillSubjectNumberWork',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

                for (int i = 0; i < CountSubject; i++)
                {


                    GridView2.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["VchName"]);
                    GridView2.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;



                }

                for (int i = GridView2.Columns.Count - 1; i > CountSubject + 1; i--)
                {
                    GridView2.Columns.RemoveAt(i);

                }



                for (int i = 0; i < CountSubject; i++)
                {
                    TemplateField temp = new TemplateField();
                    temp.HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["id"]);
                    temp.Visible = false;
                    GridView2.Columns.Add(temp);

                }



                grid.Rows.Add(grid.NewRow());


                FillNumberWorkDataGrid();
                btnSubmit1.Visible = true;
                btnClear1.Visible = true;
                checkPostback = true;

            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();

                //GridView1.DataSource = null;
                //GridView1.DataBind();

                for (int i = GridView2.Columns.Count - 1; i > 1; i--)
                {
                    GridView2.Columns.RemoveAt(i);
                    //  GridView1.Columns.RemoveAt(i);
                }
                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
            }
        }
        catch
        {

        }
    }
    public void FillNumberWorkDataGrid()
    {
        try
        {
            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "'";


            dsObj = sGetDataset(strQry);
            GridView2.DataSource = dsObj;
            GridView2.DataBind();


            strQry = "exec usp_ExamMarks @type='FillNumberWorkSkill',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < GridView2.Rows.Count; i++)
                {
                    for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                    {
                        subjectId = Convert.ToInt32((GridView2.Columns.Count - 2) / 2) + 1;

                        for (int j = 1; j < (GridView2.Columns.Count / 2); j++)
                        {
                            Label lblStudent = (Label)GridView2.Rows[i].FindControl("lblStudentId");
                            if (Convert.ToString(lblStudent.Text).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intStudent_id"]).Trim())
                            {
                                subjectId = subjectId + 1;
                                if (Convert.ToString(GridView2.Columns[subjectId].HeaderText).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intSubject_id"]).Trim())
                                {
                                    TextBox txtmark = (TextBox)GridView2.Rows[i].FindControl("txtSub" + j.ToString());
                                    string vchgrade = txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    if (vchgrade == "-1")
                                    {
                                        txtmark.Text = "NA";
                                    }
                                    else if (vchgrade == "-2")
                                    {
                                        txtmark.Text = "AB";
                                    }
                                    else
                                    {
                                        txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    }
                                    //j = j + 1;
                                }

                            }

                        }

                    }
                }

            }
        }
        catch
        {

        }
    }
    public void FillNumberWorkMarkDetails()
    {
        try
        {
            strQry = "exec usp_ExamMarks @type='FillSubjectNumberWork',@intExam_id='" + ddlExam.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            Table tbl = new Table();
            // tbl.BorderWidth = 1;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    TableCell td1 = new TableCell();
                    TableCell td2 = new TableCell();
                    TableCell td3 = new TableCell();

                    Label lbl = new Label();
                    lbl.ID = Convert.ToString(dsObj.Tables[0].Rows[i]["id"]);
                    lbl.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["VchName"]);

                    td.Controls.Add(lbl);

                    TextBox txt = new TextBox();
                    txt.ID = "txt" + i.ToString();
                    txt.Width = 70;
                    td1.Controls.Add(txt);


                    TextBox txtT = new TextBox();
                    txtT.ID = "txtT" + i.ToString();
                    txtT.Enabled = false;
                    txtT.Text = "100";
                    txtT.Width = 70;
                    td2.Controls.Add(txtT);


                    td3.Width = 20;


                    tr.Controls.Add(td);
                    tr.Controls.Add(td1);
                    tr.Controls.Add(td3);
                    tr.Controls.Add(td2);
                    tbl.Controls.Add(tr);
                }
                btnSubmit.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
                btnClear.Visible = false;
            }
            divTable.Controls.Add(tbl);
        }
        catch
        {
        }

    }


    public void SecondLanguageMarksGridDynamically()
    {
        try
        {
            //GridView grv = new GridView();
            //grv.ID = "grvMarks";
            //grv.AutoGenerateColumns = false;
            //grv.Width = 500;
            //grv.CssClass = "mGrid";
            if (ddlExam1.SelectedValue != "0" && ddlExam1.SelectedValue != "")
            {

                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
                DataTable grid = new DataTable();
                //strQry = "exec usp_ExamMarks @type='FillSubjectSkill',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "'";              
                strQry = "exec usp_ExamMarks @type='FillSubjectSecondLanguage',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

                for (int i = 0; i < CountSubject; i++)
                {
                    // grvMarks.HeaderRow.Cells[i + 2].Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);

                    GridView3.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["VchName"]);
                    GridView3.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                    //GridView1.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);
                    //GridView1.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                }



                for (int i = GridView3.Columns.Count - 1; i > CountSubject + 1; i--)
                {
                    GridView3.Columns.RemoveAt(i);
                    // GridView1.Columns.RemoveAt(i);
                }
                //for (int i = GridView1.Columns.Count - 1; i > CountSubject + 1; i--)
                //{
                //    GridView1.Columns.RemoveAt(i);
                //}


                for (int i = 0; i < CountSubject; i++)
                {
                    TemplateField temp = new TemplateField();
                    temp.HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["id"]);
                    temp.Visible = false;
                    GridView3.Columns.Add(temp);
                    //GridView1.Columns.Add(temp);
                }

                //--------For Empty Row-----///

                grid.Rows.Add(grid.NewRow());
                //GridView1.DataSource =grid;
                //GridView1.DataBind();
                //GridView1.Rows[0].Visible = false;
                //----------End-----------//

                // grvMarks.DataBind();

                FillSecondLanguageMarksDataGrid();
                btnSubmit1.Visible = true;
                btnClear1.Visible = true;
                checkPostback = true;

            }
            else
            {
                GridView3.DataSource = null;
                GridView3.DataBind();

                //GridView1.DataSource = null;
                //GridView1.DataBind();

                for (int i = GridView3.Columns.Count - 1; i > 1; i--)
                {
                    GridView3.Columns.RemoveAt(i);
                    //  GridView1.Columns.RemoveAt(i);
                }
                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
            }
        }
        catch
        {

        }
    }
    public void FillSecondLanguageMarksDataGrid()
    {
        try
        {
            //strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "'";
            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "'";


            dsObj = sGetDataset(strQry);
            GridView3.DataSource = dsObj;
            GridView3.DataBind();


            strQry = "exec usp_ExamMarks @type='FillSecondLanguageSkill',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //SubMaxMarks.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["intMaxMark"]);
                for (int i = 0; i < GridView3.Rows.Count; i++)
                {
                    for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                    {
                        subjectId = Convert.ToInt32((GridView3.Columns.Count - 2) / 2) + 1;

                        for (int j = 1; j < (GridView3.Columns.Count / 2); j++)
                        {
                            Label lblStudent = (Label)GridView3.Rows[i].FindControl("lblStudentId");
                            if (Convert.ToString(lblStudent.Text).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intStudent_id"]).Trim())
                            {
                                subjectId = subjectId + 1;
                                if (Convert.ToString(GridView3.Columns[subjectId].HeaderText).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intSubject_id"]).Trim())
                                {
                                    TextBox txtmark = (TextBox)GridView3.Rows[i].FindControl("txtSub" + j.ToString());
                                    string vchgrade = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    if (vchgrade == "-1")
                                    {
                                        txtmark.Text = "NA";
                                    }
                                    else if (vchgrade == "-2")
                                    {
                                        txtmark.Text = "AB";
                                    }
                                    else
                                    {
                                        txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    }
                                    //j = j + 1;
                                }
                                //else
                                //{
                                //    TextBox txtmark = (TextBox)grvMarks.Rows[i].FindControl("txtSub" + j.ToString());
                                //    txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                //}
                            }

                        }

                    }
                }

            }
        }
        catch
        {

        }
    }
    public void FillSecondLanguageMarkDetails()
    {
        try
        {
            strQry = "exec usp_ExamMarks @type='FillSubjectSecondLanguage',@intExam_id='" + ddlExam.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            Table tbl = new Table();
            // tbl.BorderWidth = 1;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    TableCell td1 = new TableCell();
                    TableCell td2 = new TableCell();
                    TableCell td3 = new TableCell();

                    Label lbl = new Label();
                    lbl.ID = Convert.ToString(dsObj.Tables[0].Rows[i]["id"]);
                    lbl.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["VchName"]);

                    td.Controls.Add(lbl);

                    TextBox txt = new TextBox();
                    txt.ID = "txt" + i.ToString();
                    txt.Width = 70;
                    td1.Controls.Add(txt);


                    TextBox txtT = new TextBox();
                    txtT.ID = "txtT" + i.ToString();
                    txtT.Enabled = false;
                    txtT.Text = "100";
                    txtT.Width = 70;
                    td2.Controls.Add(txtT);


                    td3.Width = 20;


                    tr.Controls.Add(td);
                    tr.Controls.Add(td1);
                    tr.Controls.Add(td3);
                    tr.Controls.Add(td2);
                    tbl.Controls.Add(tr);
                }
                btnSubmit.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
                btnClear.Visible = false;
            }
            divTable.Controls.Add(tbl);
        }
        catch
        {
        }
    }


    public void SecondLanguageBengaliMarksGridDynamically()
    {
        try
        {
            //GridView grv = new GridView();
            //grv.ID = "grvMarks";
            //grv.AutoGenerateColumns = false;
            //grv.Width = 500;
            //grv.CssClass = "mGrid";
            if (ddlExam1.SelectedValue != "0" && ddlExam1.SelectedValue != "")
            {

                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
                DataTable grid = new DataTable();
                //strQry = "exec usp_ExamMarks @type='FillSubjectSkill',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "'";              
                strQry = "exec usp_ExamMarks @type='FillSubjectSecondLanguagebengali',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

                for (int i = 0; i < CountSubject; i++)
                {
                    // grvMarks.HeaderRow.Cells[i + 2].Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);

                    GridView7.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["VchName"]);
                    GridView7.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                    //GridView1.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);
                    //GridView1.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                }



                for (int i = GridView7.Columns.Count - 1; i > CountSubject + 1; i--)
                {
                    GridView7.Columns.RemoveAt(i);
                    // GridView1.Columns.RemoveAt(i);
                }
                //for (int i = GridView1.Columns.Count - 1; i > CountSubject + 1; i--)
                //{
                //    GridView1.Columns.RemoveAt(i);
                //}


                for (int i = 0; i < CountSubject; i++)
                {
                    TemplateField temp = new TemplateField();
                    temp.HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["id"]);
                    temp.Visible = false;
                    GridView7.Columns.Add(temp);
                    //GridView1.Columns.Add(temp);
                }

                //--------For Empty Row-----///

                grid.Rows.Add(grid.NewRow());
                //GridView1.DataSource =grid;
                //GridView1.DataBind();
                //GridView1.Rows[0].Visible = false;
                //----------End-----------//

                // grvMarks.DataBind();

                FillSecondLanguageBengaliMarksDataGrid();
                btnSubmit1.Visible = true;
                btnClear1.Visible = true;
                checkPostback = true;

            }
            else
            {
                GridView7.DataSource = null;
                GridView7.DataBind();

                //GridView1.DataSource = null;
                //GridView1.DataBind();

                for (int i = GridView7.Columns.Count - 1; i > 1; i--)
                {
                    GridView7.Columns.RemoveAt(i);
                    //  GridView1.Columns.RemoveAt(i);
                }
                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
            }
        }
        catch
        {

        }
    }
    public void FillSecondLanguageBengaliMarksDataGrid()
    {
        try
        {
            //strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "'";
            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "'";


            dsObj = sGetDataset(strQry);
            GridView7.DataSource = dsObj;
            GridView7.DataBind();


            strQry = "exec usp_ExamMarks @type='FillSecondLanguagebengaliSkill',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //SubMaxMarks.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["intMaxMark"]);
                for (int i = 0; i < GridView7.Rows.Count; i++)
                {
                    for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                    {
                        subjectId = Convert.ToInt32((GridView7.Columns.Count - 2) / 2) + 1;

                        for (int j = 1; j < (GridView7.Columns.Count / 2); j++)
                        {
                            Label lblStudent = (Label)GridView7.Rows[i].FindControl("lblStudentId");
                            if (Convert.ToString(lblStudent.Text).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intStudent_id"]).Trim())
                            {
                                subjectId = subjectId + 1;
                                if (Convert.ToString(GridView7.Columns[subjectId].HeaderText).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intSubject_id"]).Trim())
                                {
                                    TextBox txtmark = (TextBox)GridView7.Rows[i].FindControl("txtSub" + j.ToString());
                                    string vchgrade = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    if (vchgrade == "-1")
                                    {
                                        txtmark.Text = "NA";
                                    }
                                    else if (vchgrade == "-2")
                                    {
                                        txtmark.Text = "AB";
                                    }
                                    else
                                    {
                                        txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    }
                                    
                                    //j = j + 1;
                                }
                                //else
                                //{
                                //    TextBox txtmark = (TextBox)grvMarks.Rows[i].FindControl("txtSub" + j.ToString());
                                //    txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                //}
                            }

                        }

                    }
                }

            }
        }
        catch
        {

        }
    }
    public void FillSecondLanguageBengaliMarkDetails()
    {
        try
        {
            strQry = "exec usp_ExamMarks @type='FillSubjectSecondLanguagebengali',@intExam_id='" + ddlExam.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            Table tbl = new Table();
            // tbl.BorderWidth = 1;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    TableCell td1 = new TableCell();
                    TableCell td2 = new TableCell();
                    TableCell td3 = new TableCell();

                    Label lbl = new Label();
                    lbl.ID = Convert.ToString(dsObj.Tables[0].Rows[i]["id"]);
                    lbl.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["VchName"]);

                    td.Controls.Add(lbl);

                    TextBox txt = new TextBox();
                    txt.ID = "txt" + i.ToString();
                    txt.Width = 70;
                    td1.Controls.Add(txt);


                    TextBox txtT = new TextBox();
                    txtT.ID = "txtT" + i.ToString();
                    txtT.Enabled = false;
                    txtT.Text = "100";
                    txtT.Width = 70;
                    td2.Controls.Add(txtT);


                    td3.Width = 20;


                    tr.Controls.Add(td);
                    tr.Controls.Add(td1);
                    tr.Controls.Add(td3);
                    tr.Controls.Add(td2);
                    tbl.Controls.Add(tr);
                }
                btnSubmit.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
                btnClear.Visible = false;
            }
            divTable.Controls.Add(tbl);
        }
        catch
        {
        }
    }

    public void EVSMarkGridDynamically()
    {
        try
        {
            //GridView grv = new GridView();
            //grv.ID = "grvMarks";
            //grv.AutoGenerateColumns = false;
            //grv.Width = 500;
            //grv.CssClass = "mGrid";
            if (ddlExam1.SelectedValue != "0" && ddlExam1.SelectedValue != "")
            {

                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
                DataTable grid = new DataTable();
                //strQry = "exec usp_ExamMarks @type='FillExamSubject',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "'";              
                strQry = "exec usp_ExamMarks @type='FillSubjectEVS',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

                for (int i = 0; i < CountSubject; i++)
                {
                    // grvMarks.HeaderRow.Cells[i + 2].Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);

                    GridView4.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["VchName"]);
                    GridView4.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                    //GridView1.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);
                    //GridView1.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                }



                for (int i = GridView4.Columns.Count - 1; i > CountSubject + 1; i--)
                {
                    GridView4.Columns.RemoveAt(i);
                    // GridView1.Columns.RemoveAt(i);
                }
                //for (int i = GridView1.Columns.Count - 1; i > CountSubject + 1; i--)
                //{
                //    GridView1.Columns.RemoveAt(i);
                //}


                for (int i = 0; i < CountSubject; i++)
                {
                    TemplateField temp = new TemplateField();
                    temp.HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["id"]);
                    temp.Visible = false;
                    GridView4.Columns.Add(temp);
                    //GridView1.Columns.Add(temp);
                }

                //--------For Empty Row-----///

                grid.Rows.Add(grid.NewRow());
                //GridView1.DataSource =grid;
                //GridView1.DataBind();
                //GridView1.Rows[0].Visible = false;
                //----------End-----------//

                // grvMarks.DataBind();

                FillEVSMarksDataGrid();
                btnSubmit1.Visible = true;
                btnClear1.Visible = true;
                checkPostback = true;

            }
            else
            {
                GridView4.DataSource = null;
                GridView4.DataBind();

                //GridView1.DataSource = null;
                //GridView1.DataBind();

                for (int i = GridView4.Columns.Count - 1; i > 1; i--)
                {
                    GridView4.Columns.RemoveAt(i);
                    //  GridView1.Columns.RemoveAt(i);
                }
                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
            }
        }
        catch
        {

        }
    }
    public void FillEVSMarksDataGrid()
    {
        try
        {
            //strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "'";
            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "'";


            dsObj = sGetDataset(strQry);
            GridView4.DataSource = dsObj;
            GridView4.DataBind();


            strQry = "exec usp_ExamMarks @type='FillEVSSkill',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //SubMaxMarks.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["intMaxMark"]);
                for (int i = 0; i < GridView4.Rows.Count; i++)
                {
                    for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                    {
                        subjectId = Convert.ToInt32((GridView4.Columns.Count - 2) / 2) + 1;

                        for (int j = 1; j < (GridView4.Columns.Count / 2); j++)
                        {
                            Label lblStudent = (Label)GridView4.Rows[i].FindControl("lblStudentId");
                            if (Convert.ToString(lblStudent.Text).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intStudent_id"]).Trim())
                            {
                                subjectId = subjectId + 1;
                                if (Convert.ToString(GridView4.Columns[subjectId].HeaderText).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intSubject_id"]).Trim())
                                {
                                    TextBox txtmark = (TextBox)GridView4.Rows[i].FindControl("txtSub" + j.ToString());
                                    string vchgrade = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    if (vchgrade == "-1")
                                    {
                                        txtmark.Text = "NA";
                                    }
                                    else if (vchgrade == "-2")
                                    {
                                        txtmark.Text = "AB";
                                    }
                                    else
                                    {
                                        txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    }
                                    //j = j + 1;
                                }
                                //else
                                //{
                                //    TextBox txtmark = (TextBox)grvMarks.Rows[i].FindControl("txtSub" + j.ToString());
                                //    txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                //}
                            }

                        }

                    }
                }

            }
        }
        catch
        {

        }
    
    }
    public void FillEVSMarkDetails()
    {
        try
        {
            //strQry = "exec usp_ExamMarks @type='FillExamSubject',@intExam_id='" + ddlExam.SelectedValue + "',@intDivision_id='" + ddlDIV2.SelectedValue + "'";
            strQry = "exec usp_ExamMarks @type='FillSubjectEVS',@intExam_id='" + ddlExam.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            Table tbl = new Table();
            // tbl.BorderWidth = 1;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    TableCell td1 = new TableCell();
                    TableCell td2 = new TableCell();
                    TableCell td3 = new TableCell();

                    Label lbl = new Label();
                    lbl.ID = Convert.ToString(dsObj.Tables[0].Rows[i]["id"]);
                    lbl.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["VchName"]);

                    td.Controls.Add(lbl);

                    TextBox txt = new TextBox();
                    txt.ID = "txt" + i.ToString();
                    txt.Width = 70;
                    td1.Controls.Add(txt);


                    TextBox txtT = new TextBox();
                    txtT.ID = "txtT" + i.ToString();
                    txtT.Enabled = false;
                    txtT.Text = "100";
                    txtT.Width = 70;
                    td2.Controls.Add(txtT);


                    td3.Width = 20;


                    tr.Controls.Add(td);
                    tr.Controls.Add(td1);
                    tr.Controls.Add(td3);
                    tr.Controls.Add(td2);
                    tbl.Controls.Add(tr);
                }
                btnSubmit.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
                btnClear.Visible = false;
            }
            divTable.Controls.Add(tbl);
        }
        catch
        {
        }
    }

    public void ComputerMarkGridDynamically()
    {
        try
        {
            //GridView grv = new GridView();
            //grv.ID = "grvMarks";
            //grv.AutoGenerateColumns = false;
            //grv.Width = 500;
            //grv.CssClass = "mGrid";
            if (ddlExam1.SelectedValue != "0" && ddlExam1.SelectedValue != "")
            {

                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
                DataTable grid = new DataTable();
                //strQry = "exec usp_ExamMarks @type='FillExamSubject',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "'";              
                strQry = "exec usp_ExamMarks @type='FillSubjectComputer',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

                for (int i = 0; i < CountSubject; i++)
                {
                    // grvMarks.HeaderRow.Cells[i + 2].Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);

                    GridView10.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["VchName"]);
                    GridView10.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                    //GridView1.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);
                    //GridView1.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                }



                for (int i = GridView10.Columns.Count - 1; i > CountSubject + 1; i--)
                {
                    GridView10.Columns.RemoveAt(i);
                    // GridView1.Columns.RemoveAt(i);
                }
                //for (int i = GridView1.Columns.Count - 1; i > CountSubject + 1; i--)
                //{
                //    GridView1.Columns.RemoveAt(i);
                //}


                for (int i = 0; i < CountSubject; i++)
                {
                    TemplateField temp = new TemplateField();
                    temp.HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["id"]);
                    temp.Visible = false;
                    GridView10.Columns.Add(temp);
                    //GridView1.Columns.Add(temp);
                }

                //--------For Empty Row-----///

                grid.Rows.Add(grid.NewRow());
                //GridView1.DataSource =grid;
                //GridView1.DataBind();
                //GridView1.Rows[0].Visible = false;
                //----------End-----------//

                // grvMarks.DataBind();

                FillComputerMarksDataGrid();
                btnSubmit1.Visible = true;
                btnClear1.Visible = true;
                checkPostback = true;

            }
            else
            {
                GridView10.DataSource = null;
                GridView10.DataBind();

                //GridView1.DataSource = null;
                //GridView1.DataBind();

                for (int i = GridView10.Columns.Count - 1; i > 1; i--)
                {
                    GridView10.Columns.RemoveAt(i);
                    //  GridView1.Columns.RemoveAt(i);
                }
                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
            }
        }
        catch
        {

        }
    }
    //public void FillComputerMarksDataGrid()
    //{
    //    try
    //    {
    //        //strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "'";
    //        strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "'";


    //        dsObj = sGetDataset(strQry);
    //        GridView7.DataSource = dsObj;
    //        GridView7.DataBind();


    //        strQry = "exec usp_ExamMarks @type='FillComputerSkill',@intExam_id='" + Convert.ToString(ddlExam1.SelectedValue) + "',@intstandard_id='" + ddlSTD1.SelectedValue + "'";
    //        dsObj = sGetDataset(strQry);
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            //SubMaxMarks.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["intMaxMark"]);
    //            for (int i = 0; i < GridView7.Rows.Count; i++)
    //            {
    //                for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
    //                {
    //                    subjectId = Convert.ToInt32((GridView7.Columns.Count - 2) / 2) + 1;

    //                    for (int j = 1; j < (GridView7.Columns.Count / 2); j++)
    //                    {
    //                        Label lblStudent = (Label)GridView7.Rows[i].FindControl("lblStudentId");
    //                        if (Convert.ToString(lblStudent.Text).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intStudent_id"]).Trim())
    //                        {
    //                            subjectId = subjectId + 1;
    //                            if (Convert.ToString(GridView7.Columns[subjectId].HeaderText).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intSubject_id"]).Trim())
    //                            {
    //                                TextBox txtmark = (TextBox)GridView7.Rows[i].FindControl("txtSub" + j.ToString());
    //                                txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
    //                                //j = j + 1;
    //                            }
    //                            //else
    //                            //{
    //                            //    TextBox txtmark = (TextBox)grvMarks.Rows[i].FindControl("txtSub" + j.ToString());
    //                            //    txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
    //                            //}
    //                        }

    //                    }

    //                }
    //            }

    //        }
    //    }
    //    catch
    //    {

    //    }

    //}
    public void FillComputerMarkDetails()
    {
        try
        {
            //strQry = "exec usp_ExamMarks @type='FillExamSubject',@intExam_id='" + ddlExam.SelectedValue + "',@intDivision_id='" + ddlDIV2.SelectedValue + "'";
            strQry = "exec usp_ExamMarks @type='FillSubjectComputer',@intExam_id='" + ddlExam.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            Table tbl = new Table();
            // tbl.BorderWidth = 1;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    TableCell td1 = new TableCell();
                    TableCell td2 = new TableCell();
                    TableCell td3 = new TableCell();

                    Label lbl = new Label();
                    lbl.ID = Convert.ToString(dsObj.Tables[0].Rows[i]["id"]);
                    lbl.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["VchName"]);

                    td.Controls.Add(lbl);

                    TextBox txt = new TextBox();
                    txt.ID = "txt" + i.ToString();
                    txt.Width = 70;
                    td1.Controls.Add(txt);


                    TextBox txtT = new TextBox();
                    txtT.ID = "txtT" + i.ToString();
                    txtT.Enabled = false;
                    txtT.Text = "100";
                    txtT.Width = 70;
                    td2.Controls.Add(txtT);


                    td3.Width = 20;


                    tr.Controls.Add(td);
                    tr.Controls.Add(td1);
                    tr.Controls.Add(td3);
                    tr.Controls.Add(td2);
                    tbl.Controls.Add(tr);
                }
                btnSubmit.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
                btnClear.Visible = false;
            }
            divTable.Controls.Add(tbl);
        }
        catch
        {
        }
    }
    public void FillComputerMarksDataGrid()
    {
        try
        {
            //strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "'";
            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "'";


            dsObj = sGetDataset(strQry);
            GridView10.DataSource = dsObj;
            GridView10.DataBind();


            strQry = "exec usp_ExamMarks @type='FillComputerSkill',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //SubMaxMarks.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["intMaxMark"]);
                for (int i = 0; i < GridView10.Rows.Count; i++)
                {
                    for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                    {
                        int subjectId1 = Convert.ToInt32((GridView10.Columns.Count - 2) / 2) + 1;

                        for (int j = 1; j < (GridView10.Columns.Count / 2); j++)
                        {
                            Label lblStudent = (Label)GridView10.Rows[i].FindControl("lblStudentId");
                            if (Convert.ToString(lblStudent.Text).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intStudent_id"]).Trim())
                            {
                                subjectId1 = subjectId1 + 1;
                                if (Convert.ToString(GridView10.Columns[subjectId1].HeaderText).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intSubject_id"]).Trim())
                                {
                                    TextBox txtmark = (TextBox)GridView10.Rows[i].FindControl("txtSub" + j.ToString());
                                    string vchgrade = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    if (vchgrade == "-1")
                                    {
                                        txtmark.Text = "NA";
                                    }
                                    else if (vchgrade == "-2")
                                    {
                                        txtmark.Text = "AB";
                                    }
                                    else
                                    {
                                        txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    }
                                    //j = j + 1;
                                }
                                //else
                                //{
                                //    TextBox txtmark = (TextBox)grvMarks.Rows[i].FindControl("txtSub" + j.ToString());
                                //    txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                //}
                            }

                        }

                    }
                }

            }
        }
        catch
        {

        }
    }


    public void SkillMarksGridDynamically()
    {
        try
        {
            //GridView grv = new GridView();
            //grv.ID = "grvMarks";
            //grv.AutoGenerateColumns = false;
            //grv.Width = 500;
            //grv.CssClass = "mGrid";
            if (ddlExam1.SelectedValue != "0" && ddlExam1.SelectedValue != "")
            {

                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
                DataTable grid = new DataTable();
                //strQry = "exec usp_ExamMarks @type='FillExamSubject',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "'";              
                strQry = "exec usp_ExamMarks @type='FillSubjectSkill',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

                for (int i = 0; i < CountSubject; i++)
                {
                    // grvMarks.HeaderRow.Cells[i + 2].Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);

                    GridView8.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["vchskillName"]);
                    GridView8.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                    //GridView1.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);
                    //GridView1.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                }



                for (int i = GridView8.Columns.Count - 1; i > CountSubject + 1; i--)
                {
                    GridView8.Columns.RemoveAt(i);
                    // GridView1.Columns.RemoveAt(i);
                }
                //for (int i = GridView1.Columns.Count - 1; i > CountSubject + 1; i--)
                //{
                //    GridView1.Columns.RemoveAt(i);
                //}


                for (int i = 0; i < CountSubject; i++)
                {
                    TemplateField temp = new TemplateField();
                    temp.HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["intskill_id"]);
                    temp.Visible = false;
                    GridView8.Columns.Add(temp);
                    //GridView1.Columns.Add(temp);
                }

                //--------For Empty Row-----///

                grid.Rows.Add(grid.NewRow());
                //GridView1.DataSource =grid;
                //GridView1.DataBind();
                //GridView1.Rows[0].Visible = false;
                //----------End-----------//

                // grvMarks.DataBind();

                FillSkillMarksDataGrid();
                btnSubmit1.Visible = true;
                btnClear1.Visible = true;
                checkPostback = true;

            }
            else
            {
                GridView8.DataSource = null;
                GridView8.DataBind();

                //GridView1.DataSource = null;
                //GridView1.DataBind();

                for (int i = GridView1.Columns.Count - 1; i > 1; i--)
                {
                    GridView8.Columns.RemoveAt(i);
                    //  GridView1.Columns.RemoveAt(i);
                }
                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
            }
        }
        catch
        {

        }
    }
    public void FillSkillMarksDataGrid()
    {
        try
        {
            //strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "'";
            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "'";


            dsObj = sGetDataset(strQry);
            GridView8.DataSource = dsObj;
            GridView8.DataBind();


            strQry = "exec usp_ExamMarks @type='FillSkill',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //SubMaxMarks.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["intMaxMark"]);
                for (int i = 0; i < GridView8.Rows.Count; i++)
                {
                    for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                    {
                        subjectId = Convert.ToInt32((GridView8.Columns.Count - 2) / 2) + 1;

                        for (int j = 1; j < (GridView8.Columns.Count / 2); j++)
                        {
                            Label lblStudent = (Label)GridView8.Rows[i].FindControl("lblStudentId");
                            if (Convert.ToString(lblStudent.Text).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intStudent_id"]).Trim())
                            {
                                subjectId = subjectId + 1;
                                if (Convert.ToString(GridView8.Columns[subjectId].HeaderText).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intSubject_id"]).Trim())
                                {
                                    TextBox txtmark = (TextBox)GridView8.Rows[i].FindControl("txtSub" + j.ToString());

                                    string vchgrade = Convert.ToString(dsObj.Tables[0].Rows[k]["decMark"]).Trim();
                                    if (vchgrade == "-1")
                                    {
                                        txtmark.Text = "NA";
                                    }
                                    else if (vchgrade == "-2")
                                    {
                                        txtmark.Text = "AB";
                                    }
                                    else
                                    {
                                        txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["decMark"]).Trim();
                                    }
                                    
                                    //j = j + 1;
                                }
                                //else
                                //{
                                //    TextBox txtmark = (TextBox)grvMarks.Rows[i].FindControl("txtSub" + j.ToString());
                                //    txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                //}
                            }

                        }

                    }
                }

            }
        }
        catch
        {

        }
    }
    public void fillSkill()
    {
        try
        {
            strQry = "exec usp_ExamMarks @type='FillSkill',@intExam_id='" + ddlExam.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            Table tbl = new Table();
            // tbl.BorderWidth = 1;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    TableCell td1 = new TableCell();
                    TableCell td2 = new TableCell();
                    TableCell td3 = new TableCell();

                    Label lbl = new Label();
                    lbl.ID = Convert.ToString(dsObj.Tables[0].Rows[i]["intskill_id"]);
                    lbl.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchskillName"]);

                    td.Controls.Add(lbl);

                    TextBox txt = new TextBox();
                    txt.ID = "txt" + i.ToString();
                    txt.Width = 70;
                    td1.Controls.Add(txt);


                    TextBox txtT = new TextBox();
                    txtT.ID = "txtT" + i.ToString();
                    txtT.Enabled = false;
                    txtT.Text = "100";
                    txtT.Width = 70;
                    td2.Controls.Add(txtT);


                    td3.Width = 20;


                    tr.Controls.Add(td);
                    tr.Controls.Add(td1);
                    tr.Controls.Add(td3);
                    tr.Controls.Add(td2);
                    tbl.Controls.Add(tr);
                }
                btnSubmit.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
                btnClear.Visible = false;
            }
            divTable.Controls.Add(tbl);
        }
        catch
        {
        }

    }

    public void workhabitGridDynamically()
    {
        try
        {

            if (ddlExam1.SelectedValue != "0" && ddlExam1.SelectedValue != "")
            {

                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
                DataTable grid = new DataTable();
                strQry = "exec usp_ExamMarks @type='FillSubjectWorkHabitskill',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

                for (int i = 0; i < CountSubject; i++)
                {


                    GridView5.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["VchName"]);
                    GridView5.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;



                }

                for (int i = GridView5.Columns.Count - 1; i > CountSubject + 1; i--)
                {
                    GridView5.Columns.RemoveAt(i);

                }



                for (int i = 0; i < CountSubject; i++)
                {
                    TemplateField temp = new TemplateField();
                    temp.HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["id"]);
                    temp.Visible = false;
                    GridView5.Columns.Add(temp);

                }



                grid.Rows.Add(grid.NewRow());


                FillworkhabitDataGrid();
                btnSubmit1.Visible = true;
                btnClear1.Visible = true;
                checkPostback = true;

            }
            else
            {
                GridView5.DataSource = null;
                GridView5.DataBind();

                //GridView1.DataSource = null;
                //GridView1.DataBind();

                for (int i = GridView5.Columns.Count - 1; i > 1; i--)
                {
                    GridView5.Columns.RemoveAt(i);
                    //  GridView1.Columns.RemoveAt(i);
                }
                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
            }
        }
        catch
        {

        }
    }
    public void FillworkhabitDataGrid()
    {
        try
        {
            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "'";


            dsObj = sGetDataset(strQry);
            GridView5.DataSource = dsObj;
            GridView5.DataBind();


            strQry = "exec usp_ExamMarks @type='FillWorkHabitEntrySkill',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < GridView5.Rows.Count; i++)
                {
                    for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                    {
                        subjectId = Convert.ToInt32((GridView5.Columns.Count - 2) / 2) + 1;

                        for (int j = 1; j < (GridView5.Columns.Count / 2); j++)
                        {
                            Label lblStudent = (Label)GridView5.Rows[i].FindControl("lblStudentId");
                            if (Convert.ToString(lblStudent.Text).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intStudent_id"]).Trim())
                            {
                                subjectId = subjectId + 1;
                                if (Convert.ToString(GridView5.Columns[subjectId].HeaderText).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intSubject_id"]).Trim())
                                {
                                    TextBox txtmark = (TextBox)GridView5.Rows[i].FindControl("txtSub" + j.ToString());
                                    string vchgrade = txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    if (vchgrade == "-1")
                                    {
                                        txtmark.Text = "NA";
                                    }
                                    else if (vchgrade == "-2")
                                    {
                                        txtmark.Text = "AB";
                                    }
                                    else
                                    {
                                        txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    }
                                    //j = j + 1;
                                }

                            }

                        }

                    }
                }

            }
        }
        catch
        {

        }
    }
    public void FillWorkhabitDetails()
    {
        try
        {
            strQry = "exec usp_ExamMarks @type='FillWorkHabitEntrySkill',@intExam_id='" + ddlExam.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            Table tbl = new Table();
            // tbl.BorderWidth = 1;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    TableCell td1 = new TableCell();
                    TableCell td2 = new TableCell();
                    TableCell td3 = new TableCell();

                    Label lbl = new Label();
                    lbl.ID = Convert.ToString(dsObj.Tables[0].Rows[i]["intskill_id"]);
                    lbl.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchskillName"]);

                    td.Controls.Add(lbl);

                    TextBox txt = new TextBox();
                    txt.ID = "txt" + i.ToString();
                    txt.Width = 70;
                    td1.Controls.Add(txt);


                    TextBox txtT = new TextBox();
                    txtT.ID = "txtT" + i.ToString();
                    txtT.Enabled = false;
                    txtT.Text = "100";
                    txtT.Width = 70;
                    td2.Controls.Add(txtT);


                    td3.Width = 20;


                    tr.Controls.Add(td);
                    tr.Controls.Add(td1);
                    tr.Controls.Add(td3);
                    tr.Controls.Add(td2);
                    tbl.Controls.Add(tr);
                }
                btnSubmit.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
                btnClear.Visible = false;
            }
            divTable.Controls.Add(tbl);
        }
        catch
        {
        }
    }

    public void FillAttendanceRemarkDetails()
    {
        try
        {
            //strQry = "exec usp_ExamMarks @type='FillExamSubject',@intExam_id='" + ddlExam.SelectedValue + "',@intDivision_id='" + ddlDIV2.SelectedValue + "'";
            strQry = "exec usp_Area @command='selectExamAttendance',@intSchool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            Table tbl = new Table();
            // tbl.BorderWidth = 1;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    TableCell td1 = new TableCell();
                    TableCell td2 = new TableCell();
                    TableCell td3 = new TableCell();

                    Label lbl = new Label();
                    lbl.ID = Convert.ToString(dsObj.Tables[0].Rows[i]["intSubject_id"]);
                    lbl.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);

                    td.Controls.Add(lbl);

                    TextBox txt = new TextBox();
                    txt.ID = "txt" + i.ToString();
                    txt.Width = 70;
                    td1.Controls.Add(txt);


                    TextBox txtT = new TextBox();
                    txtT.ID = "txtT" + i.ToString();
                    txtT.Enabled = false;
                    txtT.Text = "100";
                    txtT.Width = 70;
                    td2.Controls.Add(txtT);


                    td3.Width = 20;


                    tr.Controls.Add(td);
                    tr.Controls.Add(td1);
                    tr.Controls.Add(td3);
                    tr.Controls.Add(td2);
                    tbl.Controls.Add(tr);
                }
                btnSubmit.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
                btnClear.Visible = false;
            }
            divTable.Controls.Add(tbl);
        }
        catch
        {
        }
    }
    public void FillAttendanceRemarkGridDynamically()
    {
        try
        {
            //GridView grv = new GridView();
            //grv.ID = "grvMarks";
            //grv.AutoGenerateColumns = false;
            //grv.Width = 500;
            //grv.CssClass = "mGrid";
            if (ddlExam1.SelectedValue != "0" && ddlExam1.SelectedValue != "")
            {

                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
                DataTable grid = new DataTable();
                //strQry = "exec usp_ExamMarks @type='FillExamSubject',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "'";              
                //strQry = "exec usp_ExamMarks @type='FillExamSubject',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                strQry = "exec usp_Area @command='selectExamAttendance',@intSchool_id='" + Session["School_id"] + "'";
                dsObj = sGetDataset(strQry);
                CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

                for (int i = 0; i < CountSubject; i++)
                {
                    // grvMarks.HeaderRow.Cells[i + 2].Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);

                    GridView13.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);
                    GridView13.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                    //GridView1.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);
                    //GridView1.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                }



                for (int i = GridView13.Columns.Count - 1; i > CountSubject + 1; i--)
                {
                    GridView13.Columns.RemoveAt(i);
                    // GridView1.Columns.RemoveAt(i);
                }
                //for (int i = GridView1.Columns.Count - 1; i > CountSubject + 1; i--)
                //{
                //    GridView1.Columns.RemoveAt(i);
                //}


                for (int i = 0; i < CountSubject; i++)
                {
                    TemplateField temp = new TemplateField();
                    temp.HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["intSubject_id"]);
                    temp.Visible = false;
                    GridView13.Columns.Add(temp);
                    //GridView1.Columns.Add(temp);
                }

                //--------For Empty Row-----///

                grid.Rows.Add(grid.NewRow());
                //GridView1.DataSource =grid;
                //GridView1.DataBind();
                //GridView1.Rows[0].Visible = false;
                //----------End-----------//

                // grvMarks.DataBind();

                FillAttendanceRemarkDataGrid();
                btnSubmit1.Visible = true;
                btnClear1.Visible = true;
                checkPostback = true;

            }
            else
            {
                GridView13.DataSource = null;
                GridView13.DataBind();

                //GridView1.DataSource = null;
                //GridView1.DataBind();

                for (int i = GridView13.Columns.Count - 1; i > 1; i--)
                {
                    GridView13.Columns.RemoveAt(i);
                    //  GridView1.Columns.RemoveAt(i);
                }
                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
            }
        }
        catch
        {

        }
    }
    public void FillAttendanceRemarkDataGrid()
    {
        try
        {
            //strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "'";
            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "'";


            dsObj = sGetDataset(strQry);
            GridView13.DataSource = dsObj;
            GridView13.DataBind();


            strQry = "exec usp_ExamMarks @type='FillStudentExamAttendance',@intExam_id='" + ddlExam1.SelectedValue + "',@intStandard_id='" + ddlSTD1.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //SubMaxMarks.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["intMaxMark"]);
                for (int i = 0; i < GridView13.Rows.Count; i++)
                {
                    for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                    {
                        subjectId = Convert.ToInt32((GridView13.Columns.Count - 2) / 2) + 1;

                        for (int j = 1; j < (GridView13.Columns.Count / 2); j++)
                        {
                            Label lblStudent = (Label)GridView13.Rows[i].FindControl("lblStudentId");
                            if (Convert.ToString(lblStudent.Text).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intStudent_id"]).Trim())
                            {
                                subjectId = subjectId + 1;
                                if (Convert.ToString(GridView13.Columns[subjectId].HeaderText).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intSubject_id"]).Trim())
                                {
                                    TextBox txtmark = (TextBox)GridView13.Rows[i].FindControl("txtSub" + j.ToString());
                                    txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["decMark"]).Trim();
                                    //j = j + 1;
                                }
                                //else
                                //{
                                //    TextBox txtmark = (TextBox)grvMarks.Rows[i].FindControl("txtSub" + j.ToString());
                                //    txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["decMark"]).Trim();
                                //}
                            }

                        }

                    }
                }

            }
        }
        catch
        {

        }
    }
   
    public void FillPersonalMarksGridDynamically()
    {
        try
        {
            //GridView grv = new GridView();
            //grv.ID = "grvMarks";
            //grv.AutoGenerateColumns = false;
            //grv.Width = 500;
            //grv.CssClass = "mGrid";
            if (ddlExam1.SelectedValue != "0" && ddlExam1.SelectedValue != "")
            {

                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
                DataTable grid = new DataTable();
                //strQry = "exec usp_ExamMarks @type='FillSubjectSkill',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "'";              
                strQry = "exec usp_ExamMarks @type='FillSubjectPersonalTraitsEntrykill',@intstandard_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

                for (int i = 0; i < CountSubject; i++)
                {
                    // grvMarks.HeaderRow.Cells[i + 2].Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);

                    GridView6.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["VchName"]);
                    GridView6.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                    //GridView1.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubjectName"]);
                    //GridView1.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                }



                for (int i = GridView6.Columns.Count - 1; i > CountSubject + 1; i--)
                {
                    GridView6.Columns.RemoveAt(i);
                    // GridView1.Columns.RemoveAt(i);
                }
                //for (int i = GridView1.Columns.Count - 1; i > CountSubject + 1; i--)
                //{
                //    GridView1.Columns.RemoveAt(i);
                //}


                for (int i = 0; i < CountSubject; i++)
                {
                    TemplateField temp = new TemplateField();
                    temp.HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["id"]);
                    temp.Visible = false;
                    GridView6.Columns.Add(temp);
                    //GridView1.Columns.Add(temp);
                }

                //--------For Empty Row-----///

                grid.Rows.Add(grid.NewRow());
                //GridView1.DataSource =grid;
                //GridView1.DataBind();
                //GridView1.Rows[0].Visible = false;
                //----------End-----------//

                // grvMarks.DataBind();

                FillPersonalMarksDataGrid();
                btnSubmit1.Visible = true;
                btnClear1.Visible = true;
                checkPostback = true;

            }
            else
            {
                GridView6.DataSource = null;
                GridView6.DataBind();

                //GridView1.DataSource = null;
                //GridView1.DataBind();

                for (int i = GridView6.Columns.Count - 1; i > 1; i--)
                {
                    GridView6.Columns.RemoveAt(i);
                    //  GridView1.Columns.RemoveAt(i);
                }
                btnSubmit1.Visible = false;
                btnClear1.Visible = false;
            }
        }
        catch
        {

        }
    }
    public void FillPersonalMarksDataGrid()
    {
        try
        {
            //strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "'";
            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "'";


            dsObj = sGetDataset(strQry);
            GridView6.DataSource = dsObj;
            GridView6.DataBind();


            strQry = "exec usp_ExamMarks @type='FillPersonalTraitsEntrySkill',@intExam_id='" + ddlExam1.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //SubMaxMarks.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["intMaxMark"]);
                for (int i = 0; i < GridView6.Rows.Count; i++)
                {
                    for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                    {
                        subjectId = Convert.ToInt32((GridView6.Columns.Count - 2) / 2) + 1;

                        for (int j = 1; j < (GridView6.Columns.Count / 2); j++)
                        {
                            Label lblStudent = (Label)GridView6.Rows[i].FindControl("lblStudentId");
                            if (Convert.ToString(lblStudent.Text).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intStudent_id"]).Trim())
                            {
                                subjectId = subjectId + 1;
                                if (Convert.ToString(GridView6.Columns[subjectId].HeaderText).Trim() == Convert.ToString(dsObj.Tables[0].Rows[k]["intSubject_id"]).Trim())
                                {
                                    TextBox txtmark = (TextBox)GridView6.Rows[i].FindControl("txtSub" + j.ToString());
                                    string vchgrade = txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    if (vchgrade == "-1")
                                    {
                                        txtmark.Text = "NA";
                                    }
                                    else if (vchgrade == "-2")
                                    {
                                        txtmark.Text = "AB";
                                    }
                                    else
                                    {
                                        txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                    }
                                    
                                    //j = j + 1;
                                }
                                //else
                                //{
                                //    TextBox txtmark = (TextBox)grvMarks.Rows[i].FindControl("txtSub" + j.ToString());
                                //    txtmark.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["vchgrade"]).Trim();
                                //}
                            }

                        }

                    }
                }

            }
        }
        catch
        {

        }
    }
    public void FillPersonalDetails()
    {
        try
        {
            strQry = "exec usp_ExamMarks @type='FillSubjectPersonalTraitsEntrykill',@intExam_id='" + ddlExam.SelectedValue + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            Table tbl = new Table();
            // tbl.BorderWidth = 1;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    TableCell td1 = new TableCell();
                    TableCell td2 = new TableCell();
                    TableCell td3 = new TableCell();

                    Label lbl = new Label();
                    lbl.ID = Convert.ToString(dsObj.Tables[0].Rows[i]["id"]);
                    lbl.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["VchName"]);

                    td.Controls.Add(lbl);

                    TextBox txt = new TextBox();
                    txt.ID = "txt" + i.ToString();
                    txt.Width = 70;
                    td1.Controls.Add(txt);


                    TextBox txtT = new TextBox();
                    txtT.ID = "txtT" + i.ToString();
                    txtT.Enabled = false;
                    txtT.Text = "100";
                    txtT.Width = 70;
                    td2.Controls.Add(txtT);


                    td3.Width = 20;


                    tr.Controls.Add(td);
                    tr.Controls.Add(td1);
                    tr.Controls.Add(td3);
                    tr.Controls.Add(td2);
                    tbl.Controls.Add(tr);
                }
                btnSubmit.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
                btnClear.Visible = false;
            }
            divTable.Controls.Add(tbl);
        }
        catch
        {
        }
    }

    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                for (int i = 1; i < GridView3.Columns.Count + 1; i++)
                {
                    //TextBox txtmark = (TextBox)grvMarks.Rows[e.Row.RowIndex - 1].FindControl("txtSub"+i.ToString());
                    //txtmark.MaxLength = Convert.ToInt32(SubMaxMarks.Value.Length);
                }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //  e.Row.Style.Add("height", "100px");


            }
        }
        catch
        {

        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                for (int i = 1; i < GridView2.Columns.Count + 1; i++)
                {

                }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {



            }
        }
        catch
        {

        }
    }
    protected void grvMarks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                for (int i = 1; i < grvMarks.Columns.Count + 1; i++)
                {
                    //TextBox txtmark = (TextBox)grvMarks.Rows[e.Row.RowIndex - 1].FindControl("txtSub"+i.ToString());
                    //txtmark.MaxLength = Convert.ToInt32(SubMaxMarks.Value.Length);
                }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //  e.Row.Style.Add("height", "100px");


            }
        }
        catch
        {

        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                for (int i = 1; i < GridView1.Columns.Count + 1; i++)
                {
                    //TextBox txtmark = (TextBox)grvMarks.Rows[e.Row.RowIndex - 1].FindControl("txtSub"+i.ToString());
                    //txtmark.MaxLength = Convert.ToInt32(SubMaxMarks.Value.Length);
                }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //  e.Row.Style.Add("height", "100px");


            }
        }
        catch
        {

        }
    }
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                for (int i = 1; i < GridView4.Columns.Count + 1; i++)
                {
                    //TextBox txtmark = (TextBox)grvMarks.Rows[e.Row.RowIndex - 1].FindControl("txtSub"+i.ToString());
                    //txtmark.MaxLength = Convert.ToInt32(SubMaxMarks.Value.Length);
                }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //  e.Row.Style.Add("height", "100px");


            }
        }
        catch
        {

        }
    }
    protected void GridView8_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                for (int i = 1; i < GridView8.Columns.Count + 1; i++)
                {
                    //TextBox txtmark = (TextBox)grvMarks.Rows[e.Row.RowIndex - 1].FindControl("txtSub"+i.ToString());
                    //txtmark.MaxLength = Convert.ToInt32(SubMaxMarks.Value.Length);
                }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //  e.Row.Style.Add("height", "100px");


            }
        }
        catch
        {

        }
    }
    protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                for (int i = 1; i < GridView5.Columns.Count + 1; i++)
                {
                    //TextBox txtmark = (TextBox)grvMarks.Rows[e.Row.RowIndex - 1].FindControl("txtSub"+i.ToString());
                    //txtmark.MaxLength = Convert.ToInt32(SubMaxMarks.Value.Length);
                }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //  e.Row.Style.Add("height", "100px");


            }
        }
        catch
        {

        }
    }
    protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                for (int i = 1; i < GridView6.Columns.Count + 1; i++)
                {
                    //TextBox txtmark = (TextBox)grvMarks.Rows[e.Row.RowIndex - 1].FindControl("txtSub"+i.ToString());
                    //txtmark.MaxLength = Convert.ToInt32(SubMaxMarks.Value.Length);
                }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //  e.Row.Style.Add("height", "100px");


            }
        }
        catch
        {

        }
    }
    protected void GridView7_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                for (int i = 1; i < GridView7.Columns.Count + 1; i++)
                {
                    //TextBox txtmark = (TextBox)grvMarks.Rows[e.Row.RowIndex - 1].FindControl("txtSub"+i.ToString());
                    //txtmark.MaxLength = Convert.ToInt32(SubMaxMarks.Value.Length);
                }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //  e.Row.Style.Add("height", "100px");


            }
        }
        catch
        {

        }
    }
    protected void GridView9_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                for (int i = 1; i < GridView9.Columns.Count + 1; i++)
                {
                    //TextBox txtmark = (TextBox)grvMarks.Rows[e.Row.RowIndex - 1].FindControl("txtSub"+i.ToString());
                    //txtmark.MaxLength = Convert.ToInt32(SubMaxMarks.Value.Length);
                }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //  e.Row.Style.Add("height", "100px");


            }
        }
        catch
        {

        }
    }
    protected void GridView10_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                for (int i = 1; i < GridView10.Columns.Count + 1; i++)
                {
                    //TextBox txtmark = (TextBox)grvMarks.Rows[e.Row.RowIndex - 1].FindControl("txtSub"+i.ToString());
                    //txtmark.MaxLength = Convert.ToInt32(SubMaxMarks.Value.Length);
                }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //  e.Row.Style.Add("height", "100px");


            }
        }
        catch
        {

        }
    }
    protected void GridView13_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                for (int i = 1; i < GridView13.Columns.Count + 1; i++)
                {
                    //TextBox txtmark = (TextBox)grvMarks.Rows[e.Row.RowIndex - 1].FindControl("txtSub"+i.ToString());
                    //txtmark.MaxLength = Convert.ToInt32(SubMaxMarks.Value.Length);
                }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //  e.Row.Style.Add("height", "100px");


            }
        }
        catch
        {

        }
    }

    protected void ddlSTD1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlDIV1.ClearSelection();
        ddlGender.ClearSelection();
        ddlExam1.ClearSelection();
        ViewState["ddlSTD"] = Convert.ToString(ddlSTD.SelectedValue);
        FillExamination();
        FillDIV();
    }
    protected void ddlDiv1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlGender.ClearSelection();
        ddlExam1.ClearSelection();
        FillExamination();
        FillStudent();
    }
    protected void grvMarks_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
        try
        {

            for (int i = 0; i < GridView9.Rows.Count; i++)
            {
                subjectId = Convert.ToInt32((GridView9.Columns.Count - 2) / 2) + 1;

                for (int j = 1; j < (GridView9.Columns.Count / 2); j++)
                {
                    Label lblStud = (Label)GridView9.Rows[i].FindControl("lblStudentId");
                    TextBox txtmark = (TextBox)GridView9.Rows[i].FindControl("txtSub" + j.ToString());
                    subjectId = subjectId + 1;//For Getting Dynamic Columns Subjectid
                    subjectNm = GridView9.Columns[subjectId].HeaderText.Trim();
                    if (txtmark.Text != null && txtmark.Text != "")
                    {
                        if (txtmark.Text == "NA" || txtmark.Text == "na" || txtmark.Text == "Na" || txtmark.Text == "nA")
                        {
                            txtmark.Text = "-1";
                        }
                        if (txtmark.Text == "AB" || txtmark.Text == "ab" || txtmark.Text == "Ab" || txtmark.Text == "aB")
                        {
                            txtmark.Text = "-2";
                        }


                            strQry = "exec usp_ExamMarks @type='Insert1and2',@intExam_id='" + ddlExam1.SelectedValue + "',@intStudent_id='" + lblStud.Text + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',";
                            strQry = strQry + "@intSubject_id='" + subjectNm + "',@decMark='" + txtmark.Text + "'";
                            try
                            {
                                sExecuteQuery(strQry);
                            }
                            catch
                            {
                                break;
                            }


                    }
                    //else
                    //{
                    //    break;
                    //}
                }
            }
            //skillMark
            for (int i = 0; i < GridView8.Rows.Count; i++)
            {
                int Skill_subjectId = Convert.ToInt32((GridView8.Columns.Count - 2) / 2) + 1;

                for (int j = 1; j < (GridView8.Columns.Count / 2); j++)
                {
                    Label lblStud = (Label)GridView8.Rows[i].FindControl("lblStudentId");
                    TextBox txtmark = (TextBox)GridView8.Rows[i].FindControl("txtSub" + j.ToString());
                    Skill_subjectId = Skill_subjectId + 1;//For Getting Dynamic Columns Subjectid
                    subjectNm = GridView8.Columns[Skill_subjectId].HeaderText.Trim();
                    if (txtmark.Text != null && txtmark.Text != "")
                    {
                        if (txtmark.Text == "NA" || txtmark.Text == "na" || txtmark.Text == "Na" || txtmark.Text == "nA")
                        {
                            txtmark.Text = "-1";
                        }
                        if (txtmark.Text == "AB" || txtmark.Text == "ab" || txtmark.Text == "Ab" || txtmark.Text == "aB")
                        {
                            txtmark.Text = "-2";
                        }
                        strQry = "exec usp_ExamMarks @type='InsertSkillsmarks',@intExam_id='" + ddlExam1.SelectedValue + "',@intStudent_id='" + lblStud.Text + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',";
                        strQry = strQry + "@intSubject_id='" + subjectNm + "',@decMark='" + txtmark.Text + "'";
                        try
                        {
                            sExecuteQuery(strQry);
                        }
                        catch
                        {
                            break;
                        }
                    }

                }
            }

            //Workhabitmark
            for (int i = 0; i < GridView5.Rows.Count; i++)
            {
                int work_subjectId = Convert.ToInt32((GridView5.Columns.Count - 2) / 2) + 1;

                for (int j = 1; j < (GridView5.Columns.Count / 2); j++)
                {
                    Label lblStud = (Label)GridView5.Rows[i].FindControl("lblStudentId");
                    TextBox txtmark = (TextBox)GridView5.Rows[i].FindControl("txtSub" + j.ToString());
                    work_subjectId = work_subjectId + 1;//For Getting Dynamic Columns Subjectid
                    subjectNm = GridView5.Columns[work_subjectId].HeaderText.Trim();
                    if (txtmark.Text != null && txtmark.Text != "")
                    {
                        if (txtmark.Text == "NA" || txtmark.Text == "na" || txtmark.Text == "Na" || txtmark.Text == "nA")
                        {
                            txtmark.Text = "-1";
                        }
                        if (txtmark.Text == "AB" || txtmark.Text == "ab" || txtmark.Text == "Ab" || txtmark.Text == "aB")
                        {
                            txtmark.Text = "-2";
                        }
                        strQry = "exec usp_ExamMarks @type='InsertWorkhabitEntry',@intExam_id='" + ddlExam1.SelectedValue + "',@intStudent_id='" + lblStud.Text + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',";
                        strQry = strQry + "@intSubject_id='" + subjectNm + "',@vchgrade='" + txtmark.Text + "'";
                        try
                        {
                            sExecuteQuery(strQry);
                        }
                        catch
                        {
                            break;
                        }
                    }

                }
            }

            //personalmark
            for (int i = 0; i < GridView6.Rows.Count; i++)
            {
                subjectId = Convert.ToInt32((GridView6.Columns.Count - 2) / 2) + 1;

                for (int j = 1; j < (GridView6.Columns.Count / 2); j++)
                {
                    Label lblStud = (Label)GridView6.Rows[i].FindControl("lblStudentId");
                    TextBox txtmark = (TextBox)GridView6.Rows[i].FindControl("txtSub" + j.ToString());
                    subjectId = subjectId + 1;//For Getting Dynamic Columns Subjectid
                    subjectNm = GridView6.Columns[subjectId].HeaderText.Trim();
                    if (txtmark.Text != null && txtmark.Text != "")
                    {
                        if (txtmark.Text == "NA" || txtmark.Text == "na" || txtmark.Text == "Na" || txtmark.Text == "nA")
                        {
                            txtmark.Text = "-1";
                        }
                        if (txtmark.Text == "AB" || txtmark.Text == "ab" || txtmark.Text == "Ab" || txtmark.Text == "aB")
                        {
                            txtmark.Text = "-2";
                        }
                        strQry = "exec usp_ExamMarks @type='InsertPersonalTraitsEntry',@intExam_id='" + ddlExam1.SelectedValue + "',@intStudent_id='" + lblStud.Text + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',";
                        strQry = strQry + "@intSubject_id='" + subjectNm + "',@vchGrade='" + txtmark.Text + "'";
                        try
                        {
                            sExecuteQuery(strQry);
                        }
                        catch
                        {
                            break;
                        }
                    }
                    //else
                    //{
                    //    break;
                    //}
                }
            }

            //attendance
            for (int i = 0; i < GridView13.Rows.Count; i++)
            {
                int att_subjectId = Convert.ToInt32((GridView13.Columns.Count - 2) / 2) + 1;

                for (int j = 1; j < (GridView13.Columns.Count / 2); j++)
                {
                    Label lblStud = (Label)GridView13.Rows[i].FindControl("lblStudentId");
                    TextBox txtmark = (TextBox)GridView13.Rows[i].FindControl("txtSub" + j.ToString());
                    att_subjectId = att_subjectId + 1;//For Getting Dynamic Columns Subjectid
                    subjectNm = GridView13.Columns[att_subjectId].HeaderText.Trim();
                    if (txtmark.Text != null && txtmark.Text != "")
                    {
                        //strQry = "exec usp_ExamMarks @type='InsertStudentExamAttendance',@intExam_id='" + ddlExam1.SelectedValue + "',@intStudent_id='" + lblStud.Text + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',";
                        //strQry = strQry + "@intAttendance='" + subjectNm + "',@TeacherRemark='" + txtmark.Text + "',@intDivision_id='" + ddlDIV1.SelectedValue + "'";
                        if (txtmark.Text == "NA" || txtmark.Text == "na" || txtmark.Text == "Na" || txtmark.Text == "nA")
                        {
                            txtmark.Text = "-1";
                        }
                        if (txtmark.Text == "AB" || txtmark.Text == "ab" || txtmark.Text == "Ab" || txtmark.Text == "aB")
                        {
                            txtmark.Text = "-2";
                        }
                        strQry = "exec usp_ExamMarks @type='InsertExamMarks',@intExam_id='" + ddlExam1.SelectedValue + "',@intStudent_id='" + lblStud.Text + "',@intDivision_id='" + ddlDIV1.SelectedValue + "',@intStandard_id='" + ddlSTD1.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',";
                        strQry = strQry + "  @intSubject_id='" + subjectNm + "',@decMark='" + txtmark.Text + "'";

                        strQry = "exec usp_ExamMarks @type='InsertStudentExamAttendance',@intExam_id='" + ddlExam1.SelectedValue + "',@intStudent_id='" + lblStud.Text + "',@intDivision_id='" + ddlDIV1.SelectedValue + "',@intStandard_id='" + ddlSTD1.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',";
                        strQry = strQry + "@intAttendance='" + subjectNm + "',@TeacherRemark='" + txtmark.Text + "'";
                        try
                        {
                            sExecuteQuery(strQry);
                        }
                        catch
                        {
                            break;
                        }

                    }
                }
            }

            
            //EnglishActivity
            for (int i = 0; i < grvMarks.Rows.Count; i++)
            {
                subjectId = Convert.ToInt32((grvMarks.Columns.Count - 2) / 2) + 1;

                for (int j = 1; j < (grvMarks.Columns.Count / 2); j++)
                {
                    Label lblStud = (Label)grvMarks.Rows[i].FindControl("lblStudentId");
                    TextBox txtmark = (TextBox)grvMarks.Rows[i].FindControl("txtSub" + j.ToString());
                    subjectId = subjectId + 1;//For Getting Dynamic Columns Subjectid
                    subjectNm = grvMarks.Columns[subjectId].HeaderText.Trim();
                    if (txtmark.Text != null && txtmark.Text != "")
                    {
                        if (txtmark.Text == "NA" || txtmark.Text == "na" || txtmark.Text == "Na" || txtmark.Text == "nA")
                        {
                            txtmark.Text = "-1";
                        }
                        if (txtmark.Text == "AB" || txtmark.Text == "ab" || txtmark.Text == "Ab" || txtmark.Text == "aB")
                        {
                            txtmark.Text = "-2";
                        }
                        strQry = "exec usp_ExamMarks @type='InsertEnglishActivityEntry',@intExam_id='" + ddlExam1.SelectedValue + "',@intStudent_id='" + lblStud.Text + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',";
                        strQry = strQry + "  @intSubject_id='" + subjectNm + "',@vchgrade='" + txtmark.Text + "'";
                        try
                        {
                            sExecuteQuery(strQry);
                        }
                        catch
                        {
                            break;
                        }

                    }
                    //else
                    //{
                    //    break;
                    //}
                }
            }

            //EnglishReader
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                int Skill_subjectId = Convert.ToInt32((GridView1.Columns.Count - 2) / 2) + 1;

                for (int j = 1; j < (GridView1.Columns.Count / 2); j++)
                {
                    Label lblStud = (Label)GridView1.Rows[i].FindControl("lblStudentId");
                    TextBox txtmark = (TextBox)GridView1.Rows[i].FindControl("txtSub" + j.ToString());
                    Skill_subjectId = Skill_subjectId + 1;//For Getting Dynamic Columns Subjectid
                    subjectNm = GridView1.Columns[Skill_subjectId].HeaderText.Trim();
                    if (txtmark.Text != null && txtmark.Text != "")
                    {
                        if (txtmark.Text == "NA" || txtmark.Text == "na" || txtmark.Text == "Na" || txtmark.Text == "nA")
                        {
                            txtmark.Text = "-1";
                        }
                        if (txtmark.Text == "AB" || txtmark.Text == "ab" || txtmark.Text == "Ab" || txtmark.Text == "aB")
                        {
                            txtmark.Text = "-2";
                        }
                        strQry = "exec usp_ExamMarks @type='InsertEnglishReaderEntry',@intExam_id='" + ddlExam1.SelectedValue + "',@intStudent_id='" + lblStud.Text + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',";
                        strQry = strQry + "@intSubject_id='" + subjectNm + "',@vchgrade='" + txtmark.Text + "'";
                        try
                        {
                            sExecuteQuery(strQry);
                        }
                        catch
                        {
                            break;
                        }
                    }

                }
            }

            //NumberWork
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                int work_subjectId = Convert.ToInt32((GridView2.Columns.Count - 2) / 2) + 1;

                for (int j = 1; j < (GridView2.Columns.Count / 2); j++)
                {
                    Label lblStud = (Label)GridView2.Rows[i].FindControl("lblStudentId");
                    TextBox txtmark = (TextBox)GridView2.Rows[i].FindControl("txtSub" + j.ToString());
                    work_subjectId = work_subjectId + 1;//For Getting Dynamic Columns Subjectid
                    subjectNm = GridView2.Columns[work_subjectId].HeaderText.Trim();
                    if (txtmark.Text != null && txtmark.Text != "")
                    {
                        if (txtmark.Text == "NA" || txtmark.Text == "na" || txtmark.Text == "Na" || txtmark.Text == "nA")
                        {
                            txtmark.Text = "-1";
                        }
                        if (txtmark.Text == "AB" || txtmark.Text == "ab" || txtmark.Text == "Ab" || txtmark.Text == "aB")
                        {
                            txtmark.Text = "-2";
                        }
                        strQry = "exec usp_ExamMarks @type='InsertNumberWorkEntry',@intExam_id='" + ddlExam1.SelectedValue + "',@intStudent_id='" + lblStud.Text + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',";
                        strQry = strQry + "@intSubject_id='" + subjectNm + "',@vchgrade='" + txtmark.Text + "'";
                        try
                        {
                            sExecuteQuery(strQry);
                        }
                        catch
                        {
                            break;
                        }
                    }

                }
            }

            //SecondLanguage hindi
            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                subjectId = Convert.ToInt32((GridView3.Columns.Count - 2) / 2) + 1;

                for (int j = 1; j < (GridView3.Columns.Count / 2); j++)
                {
                    Label lblStud = (Label)GridView3.Rows[i].FindControl("lblStudentId");
                    TextBox txtmark = (TextBox)GridView3.Rows[i].FindControl("txtSub" + j.ToString());
                    subjectId = subjectId + 1;//For Getting Dynamic Columns Subjectid
                    subjectNm = GridView3.Columns[subjectId].HeaderText.Trim();
                    if (txtmark.Text != null && txtmark.Text != "")
                    {
                        if (txtmark.Text == "NA" || txtmark.Text == "na" || txtmark.Text == "")
                        {
                            txtmark.Text = "-1";
                        }
                        if (txtmark.Text == "AB" || txtmark.Text == "ab" || txtmark.Text == "Ab" || txtmark.Text == "aB")
                        {
                            txtmark.Text = "-2";
                        }
                        strQry = "exec usp_ExamMarks @type='InsertSecondLanguageEntry',@intExam_id='" + ddlExam1.SelectedValue + "',@intStudent_id='" + lblStud.Text + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',";
                        strQry = strQry + "@intSubject_id='" + subjectNm + "',@vchGrade='" + txtmark.Text + "'";
                        try
                        {
                            sExecuteQuery(strQry);
                        }
                        catch
                        {
                            break;
                        }
                    }
                    //else
                    //{
                    //    break;
                    //}
                }
            }

            //SecondLanguage bengali
            for (int i = 0; i < GridView7.Rows.Count; i++)
            {
                subjectId = Convert.ToInt32((GridView7.Columns.Count - 2) / 2) + 1;

                for (int j = 1; j < (GridView7.Columns.Count / 2); j++)
                {
                    Label lblStud = (Label)GridView7.Rows[i].FindControl("lblStudentId");
                    TextBox txtmark = (TextBox)GridView7.Rows[i].FindControl("txtSub" + j.ToString());
                    subjectId = subjectId + 1;//For Getting Dynamic Columns Subjectid
                    subjectNm = GridView7.Columns[subjectId].HeaderText.Trim();
                    if (txtmark.Text != null && txtmark.Text != "")
                    {
                        if (txtmark.Text == "NA" || txtmark.Text == "na" || txtmark.Text == "")
                        {
                            txtmark.Text = "-1";
                        }
                        if (txtmark.Text == "AB" || txtmark.Text == "ab" || txtmark.Text == "Ab" || txtmark.Text == "aB")
                        {
                            txtmark.Text = "-2";
                        }
                        strQry = "exec usp_ExamMarks @type='InsertSecondLanguagebengaliEntry',@intExam_id='" + ddlExam1.SelectedValue + "',@intStudent_id='" + lblStud.Text + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',";
                        strQry = strQry + "@intSubject_id='" + subjectNm + "',@vchGrade='" + txtmark.Text + "'";
                        try
                        {
                            sExecuteQuery(strQry);
                        }
                        catch
                        {
                            break;
                        }
                    }
                    //else
                    //{
                    //    break;
                    //}
                }
            }

            //EVS
            for (int i = 0; i < GridView4.Rows.Count; i++)
            {
                subjectId = Convert.ToInt32((GridView4.Columns.Count - 2) / 2) + 1;

                for (int j = 1; j < (GridView4.Columns.Count / 2); j++)
                {
                    Label lblStud = (Label)GridView4.Rows[i].FindControl("lblStudentId");
                    TextBox txtmark = (TextBox)GridView4.Rows[i].FindControl("txtSub" + j.ToString());
                    subjectId = subjectId + 1;//For Getting Dynamic Columns Subjectid
                    subjectNm = GridView4.Columns[subjectId].HeaderText.Trim();
                    if (txtmark.Text != null && txtmark.Text != "")
                    {
                        //strQry = "exec usp_ExamMarks @type='InsertExamMarks',@intExam_id='" + ddlExam1.SelectedValue + "',@intStudent_id='" + lblStud.Text + "',@intDivision_id='" + ddlDIV1.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',";
                        //strQry = strQry + "  @intSubject_id='" + subjectNm + "',@decMark='" + txtmark.Text + "'";
                        if (txtmark.Text == "NA" || txtmark.Text == "na" || txtmark.Text == "Na" || txtmark.Text == "nA")
                        {
                            txtmark.Text = "-1";
                        }
                        if (txtmark.Text == "AB" || txtmark.Text == "ab" || txtmark.Text == "Ab" || txtmark.Text == "aB")
                        {
                            txtmark.Text = "-2";
                        }
                        strQry = "exec usp_ExamMarks @type='InsertEVSEntry',@intExam_id='" + ddlExam1.SelectedValue + "',@intStudent_id='" + lblStud.Text + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',";
                        strQry = strQry + "@intSubject_id='" + subjectNm + "',@vchGrade='" + txtmark.Text + "'";
                        try
                        {
                            sExecuteQuery(strQry);
                        }
                        catch
                        {
                            break;
                        }

                    }
                }
            }

            //computer
            for (int i = 0; i < GridView10.Rows.Count; i++)
            {
                subjectId = Convert.ToInt32((GridView10.Columns.Count - 2) / 2) + 1;

                for (int j = 1; j < (GridView10.Columns.Count / 2); j++)
                {
                    Label lblStud = (Label)GridView10.Rows[i].FindControl("lblStudentId");
                    TextBox txtmark = (TextBox)GridView10.Rows[i].FindControl("txtSub" + j.ToString());
                    subjectId = subjectId + 1;//For Getting Dynamic Columns Subjectid
                    subjectNm = GridView10.Columns[subjectId].HeaderText.Trim();
                    if (txtmark.Text != null && txtmark.Text != "")
                    {
                        //strQry = "exec usp_ExamMarks @type='InsertExamMarks',@intExam_id='" + ddlExam1.SelectedValue + "',@intStudent_id='" + lblStud.Text + "',@intDivision_id='" + ddlDIV1.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',";
                        //strQry = strQry + "  @intSubject_id='" + subjectNm + "',@decMark='" + txtmark.Text + "'";
                        if (txtmark.Text == "NA" || txtmark.Text == "na" || txtmark.Text == "Na" || txtmark.Text == "nA")
                        {
                            txtmark.Text = "-1";
                        }
                        if (txtmark.Text == "AB" || txtmark.Text == "ab" || txtmark.Text == "Ab" || txtmark.Text == "aB")
                        {
                            txtmark.Text = "-2";
                        }
                        strQry = "exec usp_ExamMarks @type='InsertComputerEntry',@intExam_id='" + ddlExam1.SelectedValue + "',@intStudent_id='" + lblStud.Text + "',@intstandard_id='" + ddlSTD1.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',";
                        strQry = strQry + "@intSubject_id='" + subjectNm + "',@vchGrade='" + txtmark.Text + "'";
                        try
                        {
                            sExecuteQuery(strQry);
                        }
                        catch
                        {
                            break;
                        }

                    }
                }
            }

            MessageBox("Marks Assigned Successfully!");
            ddlExam1.SelectedValue = "0";
            ddlExam1_SelectedIndexChanged(null, null);

            //txtTime.Text = "";
            //txtDate.Text = "";
           

            
        }
        catch
        {

        }




    }
    protected void Sv1_Click(object sender, EventArgs e)
    {

    }

    public void GenerateDynamicProgressReports(DataSet ds, string Type)
    {
        try
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                Table tb = new Table();
                tb.Style.Add("width", "100% !important");
                TableRow tr1 = new TableRow();
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    lblName.Visible = true;
                    lblGetName.Visible = true;
                    TableHeaderCell th = new TableHeaderCell();
                    th.BackColor = System.Drawing.Color.LightGray;
                    Label lblH = new Label();
                    if (Type == "Student")
                    {

                        lblName.Text = "Student Name :";
                        if (Convert.ToString(ds.Tables[0].Columns[i].ColumnName) != "Roll No" && Convert.ToString(ds.Tables[0].Columns[i].ColumnName) != "Name")
                        {
                            lblH.Text = Convert.ToString(ds.Tables[0].Columns[i].ColumnName);
                            th.Controls.Add(lblH);
                            tr1.Controls.Add(th);
                        }
                        else
                        {
                            lblGetName.Text = Convert.ToString(ddlStudent2.SelectedItem.Text);
                        }
                    }
                    else if (Type == "Single" || Type == "All")
                    {
                        lblName.Text = "Examination";
                        if (Convert.ToString(ds.Tables[0].Columns[i].ColumnName) != "Examination")
                        {
                            lblH.Text = Convert.ToString(ds.Tables[0].Columns[i].ColumnName);
                            th.Controls.Add(lblH);
                            tr1.Controls.Add(th);
                        }
                        else
                        {
                            lblGetName.Text = Convert.ToString(ddlExam2.SelectedItem.Text);
                        }
                    }

                    tb.Controls.Add(tr1);
                }
                divMarksHeader.Controls.Add(tb);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Table tbl = new Table();
                        tbl.BorderWidth = 1;
                        tbl.Style.Add("width", "100% !important");
                        TableRow tr = new TableRow();

                        for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                        {
                            TableCell td = new TableCell();
                            Label lbl = new Label();
                            if (Type == "Student")
                            {
                                if (Convert.ToString(ds.Tables[0].Columns[j].ColumnName) != "Roll No" && Convert.ToString(ds.Tables[0].Columns[j].ColumnName) != "Name")
                                {
                                    lbl.Text = Convert.ToString(ds.Tables[0].Rows[i][j]);
                                    td.Controls.Add(lbl);
                                    tr.Controls.Add(td);
                                }
                            }
                            else if (Type == "Single" || Type == "All")
                            {
                                if (Convert.ToString(ds.Tables[0].Columns[j].ColumnName) != "Examination")
                                {
                                    lbl.Text = Convert.ToString(ds.Tables[0].Rows[i][j]);
                                    td.Controls.Add(lbl);
                                    tr.Controls.Add(td);
                                }
                            }

                            tbl.Controls.Add(tr);
                        }

                        if (Type == "Student")
                        {
                            divMarksHeader.Controls.Add(tbl);
                            divMarksHeader.Controls.Add(new LiteralControl("<br/>"));
                            divMarks.Visible = false;
                        }
                        else
                        {
                            divMarks.Visible = true;
                            divMarks.Controls.Add(tbl);
                            divMarks.Controls.Add(new LiteralControl("<br/>"));
                        }
                    }
                }
                else
                {
                    if (Type == "Student")
                    {
                        divMarksHeader.Controls.Add(new LiteralControl("<table><tr><td>Marks Not Assigned Yet</td></tr></table>"));
                        divMarksHeader.Controls.Add(new LiteralControl("<br/>"));
                        divMarks.Visible = false;
                    }
                    else
                    {
                        divMarks.Visible = true;

                        divMarks.Controls.Add(new LiteralControl("<table><tr><td>Marks Not Assigned Yet</td></tr></table>"));
                        divMarks.Controls.Add(new LiteralControl("<br/>"));
                    }
                }
            }

        }
        catch
        {

        }
    }
    public void FillReport()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "3" || Convert.ToString(Session["UserType_Id"]) == "4" || Convert.ToString(Session["UserType_Id"]) == "5")
            {
                if (ddlStudent2.SelectedValue == "0")
                {
                    btnView.Visible = false;
                }
                else
                {
                    if (ddlExam2.SelectedValue != "-1" && ddlExam2.SelectedValue != "0")
                    {
                        btnView.Visible = true;
                    }
                    else
                    {
                        btnView.Visible = false;
                    }
                }
            }
            else
            {
                if (ddlExam2.SelectedValue == "0")
                {
                    btnView.Visible = false;
                }
                else
                {
                    btnView.Visible = true;
                }
            }


            lblName.Visible = false;
            lblGetName.Visible = false;

            if (Convert.ToString(Session["UserType_Id"]) == "2" || Convert.ToString(Session["UserType_Id"]) == "1")
            {
                if (ddlExam2.SelectedValue != "-1")
                {
                    //strQry = "exec GenerateExamReport @intDivision_id='" + Convert.ToString(Session["Division_id"]) + "',@intExam_id='" + ddlExam2.SelectedValue + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
                    //dsObj = sGetDataset(strQry);
                    //if (dsObj.Tables[0].Rows.Count > 0)
                    //{
                    //    GenerateDynamicProgressReports(dsObj, "Student");                        
                    //}
                    GenerateDynamicProgressReports(dsObj, "Student");
                    lblName.Visible = false;
                    lblGetName.Visible = false;

                }
                else if (ddlExam2.SelectedValue != "0")
                {
                    for (int i = 0; i < ddlExam2.Items.Count; i++)
                    {
                        if (ddlExam2.Items[i].Value != "-1" && ddlExam2.Items[i].Value != "0")
                        {
                            strQry = "exec GenerateExamReport @intDivision_id='" + Convert.ToString(Session["Division_id"]) + "',@intExam_id='" + ddlExam2.Items[i].Value + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
                            dsObj = sGetDataset(strQry);
                            if (dsObj.Tables[0].Rows.Count > 0)
                            {
                                GenerateDynamicProgressReports(dsObj, "Student");
                            }
                        }
                        //strQry = "exec [usp_ExamMarks] @type='FillExamination',@intDivision_id='" + ddlDIV2.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "'";
                    }
                    lblName.Visible = false;
                    lblGetName.Visible = false;
                }
            }
            //else if (Convert.ToString(Session["UserType_Id"]) == "3")
            //{
            //    strQry = "exec GenerateExamReport @intDivision_id='" + Convert.ToString(Session["Division_id"]) + "',@intExam_id='" + ddlExam2.SelectedValue + "',@intStudent_id='" + ddlStudent2 + "'";
            //    dsObj = sGetDataset(strQry);
            //    GenerateDynamicProgressReports(dsObj, "Student");
            //}
            else
            {
                FillReportCaRD();
            }
        }
        catch
        {

        }
    }
    protected void ddlExam2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["UserType_id"]) == "1" || Convert.ToString(Session["UserType_id"]) == "2")
            {
                if (ddlExam2.SelectedValue != "0")
                {
                    //strQry = "exec [usp_ExamMarks] @type='DeclarationDate',@intExam_id='" + Convert.ToString(ddlExam2.SelectedValue) + "',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@intDivision_id='" + Convert.ToString(Session["Division_id"]) + "'";
                    //dsObj = sGetDataset(strQry);
                    //if (dsObj.Tables[0].Rows.Count > 0)
                    //{
                    //    FillReport();
                    //} Declare @str varchar(1000) SELECT @str= coalesce(@str + ',','') +'['+ a.vchsubjectname+']' FROM (SELECT DISTINCT vchsubjectname from tblSubject_Master where intstandard_id='5'  and intactive_flg=0 and intSchool_id='1') a select rtrim(ltrim(@str))  as subject

                    strQry = "Declare @str varchar(1000) SELECT @str= coalesce(@str + ',','') +'['+ a.vchsubjectname+']' FROM (SELECT DISTINCT vchsubjectname from tblSubject_Master where intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "'  and intactive_flg=0 and intSchool_id='" + Session["School_id"] + "') a select rtrim(ltrim(@str))  as subject";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        string strSubjects = Convert.ToString(dsObj.Tables[0].Rows[0][0]);

                        strQry = "SELECT * FROM (SELECT Student_Master.intStudent_id as 'Roll No',Student_Master.vchStudentFirst_name +  ' ' + Student_Master.vchStudentLast_name as 'Name',tblExaminationDet.vchExamination_name as 'Examination',tblSubject_Master.vchSubjectName,decMark FROM Student_Master inner join tblExam_Mark on Student_Master.intStudent_id=tblExam_Mark.intStudent_id inner join tblExaminationDet on tblExam_Mark.intExam_id=tblExaminationDet.intExam_id inner join tblSubject_Master on tblSubject_Master.intSubject_id=tblExam_Mark.intSubject_id where Student_Master.intDivision_id='40' and tblExam_Mark.intExam_id='2' and tblExam_Mark.intStudent_id=case when '372'=0 then tblExam_Mark.intStudent_id else '372' end and tblExaminationDet.bitActiveFlg=1 and tblSubject_Master.intactive_flg=1) AS p  PIVOT (max(decMark) FOR vchSubjectName IN(" + strSubjects.Trim() + ") ) AS p1 order by Name ";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            FillReport();
                        }


                    }
                }

            }
            else
            {
                FillReport();
            }

        }
        catch
        {

        }
    }
    public void FillReportCaRD()
    {
        try
        {
            if (ddlExam2.SelectedValue == "-1")
            {
                for (int i = 0; i < ddlExam2.Items.Count; i++)
                {
                    if (ddlExam2.Items[i].Value != "-1" && ddlExam2.Items[i].Value != "0")
                    {
                        strQry = "exec GenerateExamReport @intDivision_id='" + ddlDIV2.SelectedValue + "',@intExam_id='" + ddlExam2.Items[i].Value + "',@intStudent_id='" + ddlStudent2.SelectedValue + "'";
                        dsObj = sGetDataset(strQry);

                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            GenerateDynamicProgressReports(dsObj, "Student");
                        }
                    }
                    //strQry = "exec [usp_ExamMarks] @type='FillExamination',@intDivision_id='" + ddlDIV2.SelectedValue + "',@intSchool_id='" + Session["School_id"] + "'";
                }

            }
            else
            {
                strQry = "exec GenerateExamReport @intDivision_id='" + ddlDIV2.SelectedValue + "',@intExam_id='" + ddlExam2.SelectedValue + "'";
                if (ddlStudent2.SelectedValue == "-1")
                {
                    dsObj = sGetDataset(strQry);
                    GenerateDynamicProgressReports(dsObj, "All");
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        GenerateDynamicProgressReports(dsObj, "All");
                    }
                }
                else if (ddlStudent2.SelectedValue != "0")
                {
                    strQry += ",@intStudent_Id='" + ddlStudent2.SelectedValue + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        GenerateDynamicProgressReports(dsObj, "All");
                    }

                }
                else
                {
                    divMarks.Controls.Clear();
                }
            }
        }
        catch
        {

        }
    }

    protected void ddlDIV2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblName.Visible = false;
            lblGetName.Visible = false;

            strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV2.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

            sBindDropDownList(ddlStudent2, strQry, "Name", "intStudent_id");

            if (ddlStudent2.Items.Count > 1)
            {
                // ddlStudent2.Items.Add(new ListItem("All", "-1"));
                ddlStudent2.Items.Insert(0, new ListItem("All", "-1"));
            }
            else
                ddlStudent2.DataSource = null;
        }
        catch
        {

        }
    }
    protected void ddlSTD2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblName.Visible = false;
            lblGetName.Visible = false;

            strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSTD2.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlDIV2, strQry, "vchDivisionName", "intDivision_id");
        }
        catch
        {

        }
    }
    protected void ddlStudent2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblName.Visible = false;
            lblGetName.Visible = false;

            strQry = "exec usp_ExamMarks @type='FillExamination',@intSchool_id='" + Session["School_id"] + "',@intDivision_id='" + ddlDIV2.SelectedValue + "'";
            sBindDropDownList(ddlExam2, strQry, "vchExamination_name", "intExam_id");

            if (ddlStudent2.Items.Count > 0)
            {
                if (ddlStudent2.SelectedValue != "-1")
                    ddlExam2.Items.Insert(0, new ListItem("All", "-1"));
                else
                    ddlExam2.Items.Remove(new ListItem("All", "-1"));
            }
        }
        catch
        {

        }
    }
    public void OpenReportCardInPDF()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "1" || Convert.ToString(Session["UserType_Id"]) == "2")
            {
                strQry = "exec GenerateReportCard @intDivision_id='" + Session["Division_id"] + "',@intExam_id='" + ddlExam2.SelectedValue + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";

            }
            else
            {
                strQry = "exec GenerateReportCard @intDivision_id='" + ddlDIV2.SelectedValue + "',@intExam_id='" + ddlExam2.SelectedValue + "',@intStudent_id='" + ddlStudent2.SelectedValue + "'";

            }

            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                GenerateReportCard grn = new GenerateReportCard();
                grn.FillTable(dsObj);
            }
        }
        catch
        {

        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        OpenReportCardInPDF();
        FillReport();
    }
    protected void btnClear1_Click(object sender, EventArgs e)
    {
        //txtTime.Text = "";
        //txtDate.Text = "";
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
       // FillMarksGridDynamically();
    }

    protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSTD1.SelectedValue == "0")
        {
            MessageBox("Please Select Standard!");
            ddlSTD1.Focus();
            return;
        }
        if (ddlDIV1.SelectedValue == "0")
        {
            MessageBox("Please Select Section!");
            ddlDIV1.Focus();
            return;
        }
        ddlExam1.ClearSelection();
        FillExamination();
        //FillEnglishActivityMarksDataGrid();
        //FillSubjectReaderMarksDataGrid();
        //FillNumberWorkDataGrid();
        //FillSecondLanguageMarksDataGrid();
        //FillSecondLanguageMarksDataGrid();
        //FillEVSMarksDataGrid();
        //FillComputerMarksDataGrid();
    }
}
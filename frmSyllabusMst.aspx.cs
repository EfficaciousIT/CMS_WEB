using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using System.Data;
using Microsoft.Office.Interop;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Configuration;


public partial class frmSyllabusMst : DBUtility
{
    string strQry = string.Empty;
    string STD = string.Empty, DIV = string.Empty;

    string strDiv = string.Empty;
    Boolean chk = false;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_id"] != null && Session["User_Id"] != null || Session["Student_id"] != null)
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["UserType_id"]) == "5" || Convert.ToString(Session["UserType_id"]) == "3" || Convert.ToString(Session["UserType_id"]) == "10" || Convert.ToString(Session["UserType_id"]) == "8")
                    {
                        tabcon.Tabs[0].Visible = false;
                        tabcon.Tabs[1].Visible = true;
                        tabcon.Tabs[2].Visible = true;
                    }
                    else
                    {
                        tabcon.Tabs[0].Visible = false;                        
                        tabcon.Tabs[1].Visible = false;
                        tabcon.Tabs[2].Visible = false;
                        ddlSTD1.Visible = false;
                        filtertable.Width = "400";

                        // ddlSub.Visible = false;
                        // lblSub1.Visible = false;
                        lblSTD1.Visible = false;
                        ddlDIV.Visible = false;
                        lblDIV12.Visible = false;
                    }

                    // ddlDIV.Attributes["multiple"] = "multiple";
                    FillExam();
                    FillSTD();
                    FillSubject();
                    FillGrid();
                    FillSyllabusGrid();
                  
                    //FillDivForSearch();
                    FillSubjectForSearch();
                    //FillDivForSearchSyllabus();
                    FillSubjectForSearchSyllabus();
                    if (!IsPostBack)
                    {
                        BindGrid();
                    }
                }


            }
            else
            {
                Response.Redirect("~\\Index.aspx", false);
            }
        }
        catch (Exception)
        {
        }
    }

    protected void FillExam()
    {
        try
        {
            strQry = "exec usp_Syllabus_Master @type='ExamDet',@intSchool_id='" + Session["School_id"] + "'";
          //  sBindCheckBoxList(chkExamList, strQry, "vchExamination_name", "intExam_id");
            sBindDropDownList(ddlExam, strQry, "vchExamination_name", "intExam_id");
        }
        catch
        {

        }

    }

    public void FillGrid()
    {
        try
        {
            strQry = "exec usp_TopicMaster @type='FillGrid',@intSchool_id='" + Session["School_id"] + "'";
            if (ddlSTD2.SelectedValue == "-1")
            {
                //ddlDIV2.SelectedValue = "-1";
                ddlSub1.SelectedValue = "-1";
            }
            else if (ddlDIV2.SelectedValue == "-1")
            {
                ddlSub1.SelectedValue = "-1";
                strQry = strQry + ",@intSTD_id='" + ddlSTD2.SelectedValue + "'";
            }
            else if (ddlSub1.SelectedValue == "-1")
            {
                strQry = strQry + ",@intSTD_id='" + ddlSTD2.SelectedValue + "'";//,@intDiv_id='" + Convert.ToString(ddlDIV2.SelectedValue) + "'";
            }
            else
            {
                strQry = strQry + ",@intSTD_id='" + ddlSTD2.SelectedValue + "',@intSubject_id='" + Convert.ToString(ddlSub1.SelectedValue) + "'";//@intDiv_id='" + Convert.ToString(ddlDIV2.SelectedValue) + "',
            }

            dsObj = new DataSet();
            dsObj = sGetDataset(strQry);
            grvTopic.DataSource = dsObj;
            grvTopic.DataBind();

        }
        catch
        {

        }
    }

    public void FillSTD()
    {
        try
        {

            strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
            sBindDropDownList(ddlSTD1, strQry, "vchStandard_name", "intstandard_id");
            sBindDropDownList(ddlSTD3, strQry, "vchStandard_name", "intstandard_id");
            sBindDropDownList(ddlSTD2, strQry, "vchStandard_name", "intstandard_id");
            sBindDropDownList(ddlSTD4, strQry, "vchStandard_name", "intstandard_id");
            //FillDIV();
            ddlSTD2.Items.Insert(0, new ListItem("All", "-1"));
            ddlSTD2.SelectedValue = "-1";

            ddlSTD4.Items.Insert(0, new ListItem("All", "-1"));
            ddlSTD4.SelectedValue = "-1";
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
            sBindCheckBoxList(ChkDivList, strQry, "vchDivisionName", "intDivision_id");
            if (ChkDivList.Items.Count > 0)
            {
                chkAll.Visible = true;
            }
            else
            {
                chkAll.Visible = false;
            }

            strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlDIV, strQry, "vchDivisionName", "intDivision_id");

        }
        catch
        {

        }
    }

    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //FillDIV();
            FillSubject2();
        }
        catch
        {

        }

    }
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkAll.Checked == true)
            {
                for (int i = 0; i < ChkDivList.Items.Count; i++)
                {
                    ChkDivList.Items[i].Selected = true;
                }

            }
            else
            {
                for (int i = 0; i < ChkDivList.Items.Count; i++)
                {
                    ChkDivList.Items[i].Selected = false;
                }
            }
        }
        catch
        {

        }
    }
    protected void ChkDivList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < ChkDivList.Items.Count; i++)
            {
                if (ChkDivList.Items[i].Selected == false)
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
        catch
        {

        }
    }
    public void FillSubject2()
    {
        try
        {
            strQry = "exec [usp_TopicMaster] @type='FillSubject',@intSTD_id='" + ddlSTD.SelectedValue + "'";
            sBindDropDownList(ddlSubject, strQry, "vchSubjectName", "intSubject_id");
        }
        catch (Exception)
        {

        }

    }
    public void FillSubject()
    {
        try
        {
            // strQry = "exec usp_FillDropDown @type='TrainingDepartment',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intUserType='3'";
            if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_id"]) == "3" || Convert.ToString(Session["UserType_id"]) == "10" || Convert.ToString(Session["UserType_id"]) == "8")
            {
                strQry = "exec [usp_Syllabus_Master] @type='FillSubject',@intSTD='" + ddlSTD1.SelectedValue + "'";//,@intDiv_id='" + ddlDIV.SelectedValue + "'";
            }
            else
            {
                strQry = "exec [usp_Syllabus_Master] @type='FillSubject',@intSTD='" + Session["Standard_id"] + "'";//,@intDiv_id='" + Session["Division_id"] + "'";
            }


            sBindDropDownList(ddlSub, strQry, "vchSubjectName", "intSubject_id");
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {


        try
        {
            chk = false;

            //for (int i = 0; i < chkExamList.Items.Count; i++)
            //{
            //    if (chkExamList.Items[i].Selected == true)
            //    {
            //        string strVal = Convert.ToString(chkExamList.Items[i].Value);


            //    }

            //}
            if (btnSubmit.Text == "Submit")
            {
                strQry = "exec [usp_TopicMaster] @type='CheckExistSave',@vchTopicName='" + Convert.ToString(txtTopicNm.Text).Trim() + "',@intSTD_id='" + ddlSTD.SelectedValue + "',@intSubject_id='" + ddlSubject.SelectedValue + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@vchInsertedIP='" + GetSystemIP() + "'";
                //strQry = "exec [usp_TopicMaster] @type='CheckExistSave',@vchTopicName='" + Convert.ToString(txtTopicNm.Text.Replace("'", "''")).Trim() + "',@intSTD_id='" + ddlSTD.SelectedValue + "',@intDiv_id=" + Convert.ToString(ChkDivList.Items[i].Value) + ",@intSubject_id='" + ddlSubject.SelectedValue + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@vchInsertedIP='" + GetSystemIP() + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    //strDiv += Convert.ToString(ChkDivList.Items[i].Text + ", ");
                    MessageBox("Enter Record Already Exist");
                }

                strQry = "exec usp_TopicMaster @type='Insert',@vchTopicName=N'" + Convert.ToString(txtTopicNm.Text).Trim() + "',@intSTD_id='" + ddlSTD.SelectedValue + "',@intSubject_id='" + ddlSubject.SelectedValue + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@vchInsertedIP='" + GetSystemIP() + "'";
                //strQry = "exec usp_TopicMaster @type='Insert',@vchTopicName='" + Convert.ToString(txtTopicNm.Text.Replace("'", "''")).Trim() + "',@intSTD_id='" + ddlSTD.SelectedValue + "',@intDiv_id=" + Convert.ToString(ChkDivList.Items[i].Value) + ",@intSubject_id='" + ddlSubject.SelectedValue + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@vchInsertedIP='" + GetSystemIP() + "',@intExam_id='" + chkExamList.SelectedValue[i].ToString() + "'";
            }
            else if (btnSubmit.Text == "Update")
            {
                strQry = "exec [usp_TopicMaster] @type='CheckExistUpdate',@intTopic_id='" + Session["TopicId"].ToString() + "',@vchTopicName='" + Convert.ToString(txtTopicNm.Text).Trim() + "',@intSTD_id='" + ddlSTD.SelectedValue + "',@intSubject_id='" + ddlSubject.SelectedValue + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@vchInsertedIP='" + GetSystemIP() + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    //strDiv += Convert.ToString(ChkDivList.Items[i].Text + ", ");
                    MessageBox("Enter Record Already Exist");
                }

                strQry = "exec usp_TopicMaster @type='Update',@intTopic_id='" + Session["TopicId"].ToString() + "',@vchTopicName=N'" + Convert.ToString(txtTopicNm.Text).Trim() + "',@intSTD_id='" + ddlSTD.SelectedValue + "',@intSubject_id='" + ddlSubject.SelectedValue + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@vchUpdatedIp='" + GetSystemIP() + "'";
                //strQry = "exec usp_TopicMaster @type='Update',@intTopic_id='" + Session["TopicId"].ToString() + "',@vchTopicName='" + Convert.ToString(txtTopicNm.Text.Replace("'", "''")).Trim() + "',@intSTD_id='" + ddlSTD.SelectedValue + "',@intDiv_id=" + Convert.ToString(ChkDivList.Items[i].Value) + ",@intSubject_id='" + ddlSubject.SelectedValue + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@vchUpdatedIp='" + GetSystemIP() + "',@intExam_id='" + Convert.ToString(chkExamList.Items[i].Value) + "'";
            }
            if (sExecuteQuery(strQry) != -1)
            {
                chk = true;
            }
            else
            {
                MessageBox("Problem Found");
                return;
            }
            if (chk == true)
            {
                MessageBox("Record Saved Successfully!");
                Session["TopicId"] = null;
                FillGrid();
                //FillTopic();
                ClearTopic();
            }
            FillGrid();
            Session["TopicId"] = null;
            //FillTopic();
            ClearTopic();
        }
        catch
        {

        }
    }
    public void ClearTopic()
    {
        txtTopicNm.Text = "";
        ChkDivList.Items.Clear();
        ddlSTD.ClearSelection();
        ddlSubject.ClearSelection();
        btnSubmit.Text = "Submit";
    }
    //public void FillTopic()
    //{
    //    try
    //    {
    //        strQry = "exec usp_Syllabus_Master @type='FillTopic',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + ddlSTD3.SelectedValue + "',@intDivision_id='" + ddlDIV3.SelectedValue + "',@intSubject_id='" + ddlSub2.SelectedValue + "'";
    //        sBindDropDownList(ddlTopic, strQry, "vchTopicName", "intTopic_id");

    //    }
    //    catch
    //    {

    //    }
    //}

    protected void grvTopic_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)grvTopic.DataKeys[e.RowIndex].Value;
            strQry = "exec usp_TopicMaster @type='Delete',@intTopic_id='" + id + "',@intDeletedBy='" + Session["User_Id"] + "',@vchDeletedIP='" + GetSystemIP() + "'";
            sExecuteQuery(strQry);
            FillGrid();
            MessageBox("Record Deleted Successfully!");
        }
        catch
        {

        }
    }
    protected string Values;
    protected void Post(object sender, EventArgs e)
    {
        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
        string contentType = FileUpload1.PostedFile.ContentType;

        using (Stream fs = FileUpload1.PostedFile.InputStream)
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string constr = ConfigurationManager.ConnectionStrings["esmsCentralModel"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "insert into tblexport values (@Name, @ContentType, @Data,@intstandard_id,@intSubject_id,@intExam_id)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Name", filename);
                        cmd.Parameters.AddWithValue("@ContentType", contentType);
                        cmd.Parameters.AddWithValue("@Data", bytes);
                        cmd.Parameters.AddWithValue("@intstandard_id", ddlSTD3.SelectedValue);
                        cmd.Parameters.AddWithValue("@intSubject_id", ddlSub2.SelectedValue);
                       // cmd.Parameters.AddWithValue("@intExam_id", chkExamList.SelectedValue);
                        // cmd.Parameters.AddWithValue("@13", DropDownList2.SelectedValue);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
        Response.Redirect(Request.Url.AbsoluteUri);
        //if (FileUpload1.HasFile)
        //{
        //    string strPath = Server.MapPath(FileUpload1.FileName);

        //    if (!Directory.Exists(Server.MapPath("~") + "/Documents/syllabus/" + ddlSTD3.Text + "/" + ddlSub2.Text + "/" + ddlTopic.Text))
        //    {
        //        Directory.CreateDirectory(Server.MapPath("~") + "/Documents/syllabus/" + ddlSTD3.Text + "/" + ddlSub2.Text + "/" + ddlTopic.Text);
        //        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Documents/syllabus/" + ddlSTD3.Text + "/" + ddlSub2.Text + "/" + ddlTopic.Text + "/" + FileUpload1.FileName));
        //    }
        //    else
        //    {
        //        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Documents/syllabus/" + ddlSTD3.Text + "/" + ddlSub2.Text + "/" + ddlTopic.Text + "/" + FileUpload1.FileName));
        //    }

        //}

        //chk = false;

        //for (int i = 0; i < chkExamList.Items.Count; i++)
        //{
        //    if (chkExamList.Items[i].Selected == true)
        //    {
        //        string strVal = Convert.ToString(chkExamList.Items[i].Value);

        //        strQry = "exec usp_Syllabus_Master @type='Insert',@intTopic_id='" + Convert.ToString(ddlTopic.SelectedValue) + "',@vchSyllabusNm='" + Convert.ToString(txtSyllabus.Text.Trim()) + "',";
        //        strQry = strQry + "@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@vchInsertedIP='" + GetSystemIP() + "',@intExam_id='" + strVal.Trim() + "',@FilePath='" + "~/Documents/syllabus/" + ddlSTD3.Text + "/" + ddlSub2.Text + "/" + ddlTopic.Text + "/" + FileUpload1.FileName + "'";

        //        if (sExecuteQuery(strQry) != -1)
        //        {
        //            strQry = "";
        //            chk = true;
        //        }
        //        else
        //        {
        //            MessageBox("Problem Found");
        //            return;
        //        }
        //    }

        //}

        //if (chk == true)
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Saved Successfully');window.location ='frmSyllabusMst.aspx';", true);
        //    //MessageBox("Record Saved Successfully!");
        //    strQry = "";
        //    FillSyllabusGrid();
        //    ClearSyllabus();
        //}

    }
    public void FillSyllabusGrid()
    {
        try
        {


            strQry = "exec usp_Syllabus_Master @type='FillGrid',@intSchool_id='" + Session["School_id"] + "'";
            if (ddlSTD4.SelectedValue == "-1")
            {
                // ddlDIV4.SelectedValue = "-1";
                ddlSub4.SelectedValue = "-1";
            }
            //else if (ddlDIV4.SelectedValue == "-1")
            //{
            //    ddlSub4.SelectedValue = "-1";
            //    strQry = strQry + ",@intSTD_id='" + ddlSTD4.SelectedValue + "'";
            //}
            else if (ddlSub4.SelectedValue == "-1")
            {
                strQry = strQry + ",@intSTD_id='" + ddlSTD4.SelectedValue + "'";//,@intDiv_id='" + Convert.ToString(ddlDIV4.SelectedValue) + "'";
            }
            else
            {
                strQry = strQry + ",@intSTD_id='" + ddlSTD4.SelectedValue + "',@intSubject_id='" + Convert.ToString(ddlSub4.SelectedValue) + "'";
            }

            dsObj = new DataSet();
            dsObj = sGetDataset(strQry);
            grvSyllabus.DataSource = dsObj;
            grvSyllabus.DataBind();
        }
        catch
        {

        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearTopic();
    }
    public void ClearSyllabus()
    {


    }
    public void FillSyllabusDetail()
    {
        try
        {
            if (Convert.ToString(Session["UserType_id"]) == "5" || Convert.ToString(Session["UserType_id"]) == "10")
            {
                strQry = "exec [usp_Syllabus_Master] @type='FillGrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSubject_id='" + Convert.ToString(ddlSub.SelectedValue) + "',@intExam_id='" + Convert.ToString(ddlExam.SelectedValue) + "'";
                dsObj = sGetDataset(strQry);
            }
            else
            {
                strQry = "exec [usp_Syllabus_Master] @type='FillGrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSubject_id='" + Convert.ToString(ddlSub.SelectedValue) + "',@intExam_id='" + Convert.ToString(ddlExam.SelectedValue) + "'";
                dsObj = sGetDataset(strQry);
            }

            for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl p1 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                p1.ID = "div" + i.ToString();
                //p1.Style.Add(HtmlTextWriterStyle.Height,"300px");
                p1.Style.Add(HtmlTextWriterStyle.BackgroundImage, "~/images/panelBg.png");
                CollapsDiv.Controls.Add(p1);



                System.Web.UI.HtmlControls.HtmlGenericControl p2 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                p2.ID = "divv" + i.ToString();
                //p2.Style.Add(HtmlTextWriterStyle.Height, "10px");
                //p2.Style.Add(HtmlTextWriterStyle.BackgroundImage, "~/images/expandBd.jpg");
                CollapsDiv.Controls.Add(p2);


                Panel pnl = new Panel();
                pnl.ID = "pnl" + i.ToString();
                pnl.Width = 800;
                //pnl.Height = 40;
                pnl.BackImageUrl = "~/images/panelBg.png";

                Label lbl1 = new Label();
                lbl1.ID = "lbll" + i.ToString();
                lbl1.ForeColor = System.Drawing.Color.White;
                lbl1.Font.Bold = true;
                lbl1.Width = 700;
                lbl1.Text = (i + 1) + ". " + Convert.ToString(dsObj.Tables[0].Rows[i]["vchTopicName"]);

                Image Img = new Image();
                Img.ID = "Image" + i.ToString();


                Table tbl = new Table();
                TableRow tr = new TableRow();
                TableCell td = new TableCell();
                TableCell td2 = new TableCell();

                tbl.Width = 780;
                tbl.Height = 10;
                tbl.CaptionAlign = TableCaptionAlign.Top;
                // tbl.BorderWidth = 1;

                td.ColumnSpan = 2;
                td.VerticalAlign = VerticalAlign.Top;
                td2.VerticalAlign = VerticalAlign.Middle;
                td2.HorizontalAlign = HorizontalAlign.Left;
                td2.Width = 10;

                td2.HorizontalAlign = HorizontalAlign.Right;

                td.Controls.Add(lbl1);
                // td1.Controls.Add();
                td2.Controls.Add(Img);

                tr.Cells.Add(td);
                //tr.Cells.Add(td1);
                tr.Cells.Add(td2);

                tbl.Rows.Add(tr);

                pnl.Controls.Add(tbl);

                p1.Controls.Add(pnl);



                Panel pnl1 = new Panel();
                pnl1.ID = "pnll" + i.ToString();
                pnl1.Width = 800;
                pnl1.BorderStyle = BorderStyle.None;
                //pnl1.BackImageUrl = "~/images/pnl1Bg.jpg";
                pnl1.BackColor = System.Drawing.Color.White;

                GridView grv = new GridView();
                grv.ID = "grv" + i.ToString();
                grv.Width = 650;
                grv.HeaderStyle.HorizontalAlign = HorizontalAlign.Justify;
                grv.RowStyle.HorizontalAlign = HorizontalAlign.Justify;


                strQry = "exec [usp_Syllabus_Master] @type='FillSyllabus',@intTopic_id='" + Convert.ToString(dsObj.Tables[0].Rows[i]["intTopic_id"]) + "',@intExam_id='" + Convert.ToString(ddlExam.SelectedValue) + "'";
                DataSet ds = new DataSet();
                ds = sGetDataset(strQry);
                grv.DataSource = ds;
                grv.DataBind();




                pnl1.Controls.Add(grv);


                p2.Controls.Add(pnl1);


                CollapsiblePanelExtender collapsiblePanelExtender = new CollapsiblePanelExtender();
                collapsiblePanelExtender.ID = "Collaps" + i.ToString();
                collapsiblePanelExtender.TargetControlID = pnl1.ID;//your panel id 
                collapsiblePanelExtender.ExpandControlID = pnl.ID;//your link button id
                collapsiblePanelExtender.CollapseControlID = pnl.ID;
                //your panel id collapsiblePanelExtender.ScrollContents = false;
                collapsiblePanelExtender.Collapsed = true;
                collapsiblePanelExtender.CollapsedSize = 0;
                //  collapsiblePanelExtender.ExpandedSize = 120;
                collapsiblePanelExtender.ExpandedImage = "~/images/Collapse.gif";
                collapsiblePanelExtender.CollapsedImage = "~/images/Expand.gif";
                collapsiblePanelExtender.ExpandDirection = CollapsiblePanelExpandDirection.Vertical;
                collapsiblePanelExtender.SuppressPostBack = true;
                collapsiblePanelExtender.ImageControlID = Img.ID;
                // collapsiblePanelExtender.TextLabelID = lbl.ID; //your label id
                collapsiblePanelExtender.CollapsedText = "Collapsed";
                collapsiblePanelExtender.ExpandedText = "Opended";
                //the name of panel that containt CollapsiblePanelExtender
                this.CollapsDiv.Controls.Add(collapsiblePanelExtender);
                // this.Page.Controls.Add(collapsiblePanelExtender);


                //TextBox txt = new TextBox();
                //txt.ID = "t";
                //CollapsDiv.Controls.Add(txt);
            }
        }
        catch
        {

        }
    }
    protected void ddlSub_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillSyllabusDetail();
            Response.Redirect("frmSyllabusMst.aspx?Value=" + ddlSub.SelectedValue);
        }
        catch
        {

        }
    }
    protected void ddlSTD3_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //FillDivSyllabus();
            FillSubjectSyllabus();
        }
        catch (Exception)
        {

        }
    }
    //public void FillDivSyllabus()
    //{
    //    try
    //    {
    //        strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSTD3.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
    //        sBindDropDownList(ddlDIV3, strQry, "vchDivisionName", "intDivision_id");
    //        FillSubjectSyllabus();

    //    }
    //    catch
    //    {

    //    }
    //}
    public void FillSubjectSyllabus()
    {
        try
        {
            //strQry = "exec [usp_TopicMaster] @type='FillSubject',@intSTD_id='" + ddlSTD3.SelectedValue + "',@intDiv_id='" + Convert.ToString(ddlDIV3.SelectedValue) + "'";
            strQry = "exec [usp_TopicMaster] @type='FillSubject',@intSTD_id='" + ddlSTD3.SelectedValue + "'";
            sBindDropDownList(ddlSub2, strQry, "vchSubjectName", "intSubject_id");
        }
        catch
        {

        }
    }
    protected void ddlSTD1_SelectedIndexChanged(object sender, EventArgs e)
    {

       //if (ddlSTD1.SelectedValue == "1")
       //{
       //    pdf1.Visible = true;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //         }
       //else if (ddlSTD1.SelectedValue == "2")
       //{
       //    pdf1.Visible = false;
       //    pdf2.Visible = true;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //}
       //else if (ddlSTD1.SelectedValue == "3")
       //{

       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = true;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //}
       //else if (ddlSTD1.SelectedValue == "4")
       //{

       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = true;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
     
       //}
       //else if (ddlSTD1.SelectedValue == "5")
       //{

       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = true;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //}
       //else if (ddlSTD1.SelectedValue == "6")
       //{

       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = true;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //}
       //else if (ddlSTD1.SelectedValue == "7")
       //{

       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //}
       //else if (ddlSTD1.SelectedValue == "8")
       //{

       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = true;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //}
       //else if (ddlSTD1.SelectedValue == "9")
       //{

       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = true;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;

       //}
       //else if (ddlSTD1.SelectedValue == "10")
       //{

       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = true;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //}
       //else if (ddlSTD1.SelectedValue == "11")
       //{

       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = true;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;

       //}
       //else if (ddlSTD1.SelectedValue == "12")
       //{
       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = true;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //}
       //else if (ddlSTD1.SelectedValue == "13")
       //{
       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = true;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;

       //}
       //else if (ddlSTD1.SelectedValue == "14")
       //{
       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = true;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;

       //}
       //else if (ddlSTD1.SelectedValue == "15")
       //{
       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = true;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;


       //}
       //else if (ddlSTD1.SelectedValue == "16")
       //{
       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = true;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;


       //}
       //else if (ddlSTD1.SelectedValue == "17")
       //{
       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //}
       //else if (ddlSTD1.SelectedValue == "18")
       //{
       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //}
       //else if (ddlSTD1.SelectedValue == "19")
       //{
       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //}
       //else if (ddlSTD1.SelectedValue == "20")
       //{
       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //}
       //else if (ddlSTD1.SelectedValue == "21")
       //{
       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //    pdf21.Visible = false;
       //    pdf23.Visible = false;
       //}
       //else if (ddlSTD1.SelectedValue == "22")
       //{
       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //    pdf23.Visible = false;
       //    pdf21.Visible = true;
       //}
       //else if (ddlSTD1.SelectedValue == "23")
       //{
       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //    pdf21.Visible = false;
       //    pdf23.Visible = false;
       //}
       //else if (ddlSTD1.SelectedValue == "24")
       //{
       //    pdf1.Visible = false;
       //    pdf2.Visible = false;
       //    pdf3.Visible = false;
       //    pdf4.Visible = false;
       //    pdf5.Visible = false;
       //    pdf6.Visible = false;
       //    pdf7.Visible = false;
       //    pdf8.Visible = false;
       //    pdf9.Visible = false;
       //    pdf10.Visible = false;
       //    pdf11.Visible = false;
       //    pdf12.Visible = false;
       //    pdf13.Visible = false;
       //    pdf14.Visible = false;
       //    pdf15.Visible = false;
       //    pdf16.Visible = false;
       //    pdf17.Visible = false;
       //    pdf18.Visible = false;
       //    pdf21.Visible = false;
       //    pdf23.Visible = true;
       //}
       //else
       //{
       //    //MessageBox("Record Not Found");
       //}
        //FillSubject();
        //ddlDIV.ClearSelection();
        //ddlSub.ClearSelection();
       
        //FillDIV();
       // Response.Redirect("frmSyllabusMst.aspx?Value=" + ddlSub.SelectedValue);
    }

    protected void lnkTopic_Click(object sender, EventArgs e)
    {
        try
        {
            Label TopicId = (Label)grvSyllabus.Rows[((GridViewRow)(sender as Control).NamingContainer).RowIndex].FindControl("lblId");
            Session["TopicSyllabus"] = TopicId.Text;
            FillTopicSyllabusDetail(Convert.ToInt32(TopicId.Text));
        }
        catch
        {

        }
    }

    public void FillTopicSyllabusDetail(int TopicId)
    {
        try
        {
            strQry = "exec [usp_Syllabus_Master] @type='Syllabus',@intTopic_id='" + TopicId + "'";
            dsObj = sGetDataset(strQry);
            grvStudLate.DataSource = dsObj;
            grvStudLate.DataBind();
            lblTopicNm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchTopicName"]);
            ModalStudLateAtt.Show();
        }
        catch
        {

        }
    }

    public void FillDivForSearch()
    {
        try
        {
            strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSTD2.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlDIV2, strQry, "vchDivisionName", "intDivision_id");
            ddlDIV2.Items.Insert(0, new ListItem("All", "-1"));
            ddlDIV2.SelectedValue = "-1";
        }
        catch
        {

        }
    }
    public void FillDivForSearchSyllabus()
    {
        try
        {
            strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSTD4.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlDIV4, strQry, "vchDivisionName", "intDivision_id");

            ddlDIV4.Items.Insert(0, new ListItem("All", "-1"));
            ddlDIV4.SelectedValue = "-1";
        }
        catch
        {

        }
    }
    protected void ddlSTD2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillSubjectForSearch();
            //FillDivForSearch();
            FillGrid();
        }
        catch
        {

        }
    }
    protected void ddlSTD4_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillSubjectForSearchSyllabus();
            // FillDivForSearchSyllabus();
            FillSyllabusGrid();
        }
        catch
        {

        }
    }
    public void FillSubjectForSearch()
    {
        try
        {
            strQry = "exec [usp_TopicMaster] @type='FillSubject',@intSTD_id='" + ddlSTD2.SelectedValue + "'";//,@intDiv_id='" + Convert.ToString(ddlDIV2.SelectedValue) + "'";
            sBindDropDownList(ddlSub1, strQry, "vchSubjectName", "intSubject_id");

            ddlSub1.Items.Insert(0, new ListItem("All", "-1"));
            ddlSub1.SelectedValue = "-1";
        }
        catch
        {

        }
    }
    public void FillSubjectForSearchSyllabus()
    {
        try
        {
            strQry = "exec [usp_TopicMaster] @type='FillSubject',@intSTD_id='" + ddlSTD4.SelectedValue + "'";//,@intDiv_id='" + Convert.ToString(ddlDIV4.SelectedValue) + "'";
            sBindDropDownList(ddlSub4, strQry, "vchSubjectName", "intSubject_id");

            ddlSub4.Items.Insert(0, new ListItem("All", "-1"));
            ddlSub4.SelectedValue = "-1";
        }
        catch
        {

        }
    }
    protected void ddlSub1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillGrid();
        }
        catch
        {

        }
    }
    protected void ddlSub4_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillSyllabusGrid();
        }
        catch
        {

        }
    }

    protected void ddlDIV2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillSubjectForSearch();
            FillGrid();
        }
        catch
        {

        }
    }
    protected void ddlDIV4_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillSubjectForSearchSyllabus();
            FillSyllabusGrid();
        }
        catch
        {

        }
    }
    protected void ddlSub2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlDIV3_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillSubjectSyllabus();
        }
        catch
        {

        }
    }

    protected void grvTopic_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int TopicId = (int)grvTopic.DataKeys[e.NewEditIndex].Value;
            Session["TopicId"] = TopicId;
            strQry = "exec [usp_TopicMaster] @type='Select',@intTopic_id='" + TopicId + "',@intSchool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ddlSTD.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intSTD_id"]);
                ddlSTD_SelectedIndexChanged(null, null);
                for (int i = 0; i < ChkDivList.Items.Count; i++)
                {
                    if (Convert.ToString(ChkDivList.Items[i].Value) == Convert.ToString(dsObj.Tables[0].Rows[0]["intDiv_id"]))
                    {
                        ChkDivList.Items[i].Selected = true;
                    }
                }
                ddlSubject.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intSubject_id"]);
                txtTopicNm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchTopicName"]);
                btnSubmit.Text = "Update";
                TabContainer1.ActiveTabIndex = 0;
            }
        }
        catch
        {

        }
    }
    protected void grvTopic_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvTopic.PageIndex = e.NewPageIndex;
            FillGrid();
        }
        catch
        {

        }
    }
    protected void grvStudLate_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int intSyllabus_id = (int)grvStudLate.DataKeys[e.NewEditIndex].Value;
            strQry = "exec [usp_Syllabus_Master] @type='Select',@intSyllabus_id='" + intSyllabus_id + "',@intSchool_id='" + Session["School_id"].ToString() + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtAddSyllabus.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Syllabus"]);
                Session["SyllabusId"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intSyllabus_id"]);
                btnAddS.Text = "Update";
            }
            ModalStudLateAtt.Show();
        }
        catch
        {

        }
    }
    protected void grvStudLate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int SyllabusId = (int)grvStudLate.DataKeys[e.RowIndex].Value;
            strQry = "exec [usp_Syllabus_Master] @type='Delete',@intSyllabus_id='" + SyllabusId + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_id"] + "',@vchDeletedIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Selected Syllabus Deleted Successfully!");
                FillTopicSyllabusDetail(Convert.ToInt32(Session["TopicSyllabus"]));
                txtAddSyllabus.Text = "";
                btnAddS.Text = "Add";
            }
        }
        catch
        {

        }
    }
    protected void btnAddS_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnAddS.Text == "Add")
            {
                strQry = "exec [usp_Syllabus_Master] @type='CheckExistSave',@vchSyllabusNm='" + Convert.ToString(txtAddSyllabus.Text).Trim() + "',@intTopic_id='" + Session["TopicSyllabus"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Syllabus Already Exist");
                    ModalStudLateAtt.Show();
                    return;
                }
                //Inserting New Syllabus Details

                strQry = "exec usp_Syllabus_Master @type='Insert',@intTopic_id='" + Session["TopicSyllabus"] + "',@vchSyllabusNm='" + Convert.ToString(txtAddSyllabus.Text.Trim()) + "',";
                strQry = strQry + "@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@vchInsertedIP='" + GetSystemIP() + "'";

                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Syllabus Added Successfully");
                    FillTopicSyllabusDetail(Convert.ToInt32(Session["TopicSyllabus"]));
                    txtAddSyllabus.Text = "";

                }

            }
            else if (btnAddS.Text == "Update")
            {
                strQry = "exec [usp_Syllabus_Master] @type='CheckExistUpdate',@intSyllabus_id='" + Convert.ToString(Session["SyllabusId"]) + "',@vchSyllabusNm='" + Convert.ToString(txtAddSyllabus.Text).Trim() + "',@intTopic_id='" + Session["TopicSyllabus"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Syllabus Already Exist");
                    return;
                }
                //Inserting New Syllabus Details

                strQry = "exec usp_Syllabus_Master @type='Update',@intTopic_id='" + Session["TopicSyllabus"] + "',@intSyllabus_id='" + Convert.ToString(Session["SyllabusId"]) + "',@vchSyllabusNm='" + Convert.ToString(txtAddSyllabus.Text.Trim()) + "',";
                strQry = strQry + "@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@vchUpdatedIp='" + GetSystemIP() + "'";

                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Syllabus Updated Successfully");
                    FillTopicSyllabusDetail(Convert.ToInt32(Session["TopicSyllabus"]));
                    txtAddSyllabus.Text = "";
                    btnAddS.Text = "Add";
                }
            }
        }
        catch
        {

        }
    }
    protected void grvSyllabus_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            // Label TopicId = (Label)grvSyllabus.Rows[((GridViewRow)(sender as Control).NamingContainer).RowIndex].FindControl("lblId");
            int TopicId = (int)grvSyllabus.DataKeys[e.RowIndex].Value;
            strQry = "exec [usp_Syllabus_Master] @type='Select',@intTopic_id='" + Convert.ToString(TopicId).Trim() + "',@intSchool_id='" + Session["School_id"].ToString() + "'";
            dsObj = sGetDataset(strQry);
            for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
            {
                strQry = "exec [usp_Syllabus_Master] @type='Delete',@intSyllabus_id='" + Convert.ToString(dsObj.Tables[0].Rows[i]["intSyllabus_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_id"] + "',@vchDeletedIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {

                }
                else
                {
                    MessageBox("Problem Found");
                    return;
                }
            }
            MessageBox("Record Deleted Successfully!");
            FillSyllabusGrid();
        }
        catch
        {

        }
    }
    protected void ddlDIV_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillSubject();
        }
        catch
        {

        }
    }
    protected void grvSyllabus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvSyllabus.PageIndex = e.NewPageIndex;
            FillSyllabusGrid();
        }
        catch
        {

        }
    }
    protected void grvStudLate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvStudLate.PageIndex = e.NewPageIndex;
            FillTopicSyllabusDetail(Convert.ToInt32(Session["TopicSyllabus"]));
        }
        catch
        {

        }
    }
    protected void ImgExcel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        grvSyllabus.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
       
    }
    private void releaseObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch (Exception ex)
        {
            obj = null;
            MessageBox("Exception Occured while releasing object " + ex.ToString());
        }
        finally
        {
            GC.Collect();
        }
    }
    public void ExportGrid()
    {
        try
        {
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", ddlSub.SelectedItem.Text + DateTime.Now + ".xls"));
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView gvDetails = new GridView();
            gvDetails.AutoGenerateColumns = true;
            gvDetails.Width = 100;

            htw.Write("<table width='100%'><tr><td colspan='1' rowspan='2'><img src='~\\images\\pdflogo.jpg' alt='' /></td><td></td><td colspan='4' ><h2>Deep Global School</h2></td></tr>");
            htw.Write("<table><tr><td></td><td></td><td colspan='2' align='left'>Kurla</td><td colspan='2' align='left'> Pin:401501</td></tr><tr><td><br/></td></tr></table>");

            //if (Convert.ToString(Session["UserType_id"]) == "5")
            //{
            if (Convert.ToString(Session["UserType_Id"]) == "1" || Convert.ToString(Session["UserType_Id"]) == "2")
            {
                htw.Write("<table width='100%'><tr><td><b></b></td><td colspan='3'> </td></tr>");
                htw.Write("<table width='100%'><tr><td><b>STD</b></td><td colspan='2' align='left'>5</td><td></td><td></td><td><b>Date</b></td><td align='left'>" + Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy") + "</td></tr>");
                htw.Write("<table width='100%'><tr><td><b>DIV</b></td><td colspan='2' align='left'>A</td><td></td><td></td><td><b>Time</b></td><td align='left'>" + Convert.ToDateTime(DateTime.Now).ToString("hh:mm \tt") + "</td></tr>");
                STD = Session["Standard_id"].ToString();
                DIV = Session["Division_id"].ToString();
            }
            else
            {
                htw.Write("<table width='100%'><tr><td><b></b></td><td colspan='3'> </td><td><b></b></td></tr>");
                htw.Write("<table width='100%'><tr><td><b>STD</b></td><td colspan='2' align='center'>" + Convert.ToString(ddlSTD1.SelectedItem.Text) + "</td><td></td><td></td><td><b>Date</b></td><td align='left'>" + Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy") + "</td></tr>");
                htw.Write("<table width='100%'><tr><td><b>DIV</b></td><td colspan='2' align='center'>" + Convert.ToString(ddlDIV.SelectedItem.Text) + "</td><td></td><td></td><td><b>Time</b></td><td align='left'>" + Convert.ToDateTime(DateTime.Now).ToString("hh:mm \tt") + "</td></tr>");
                STD = Convert.ToString(ddlSTD1.SelectedValue);
                DIV = Convert.ToString(ddlDIV.SelectedValue);
            }
            htw.Write("<table width='100%'><tr><td></td><td colspan='5' align='center'></td></tr>");
            htw.Write("<table width='100%'><tr><td></td><td colspan='1' align='center'>Subject :</td><td colspan='3' align='left'><b>" + dsObj.Tables[0].Rows[0]["Subject"] + "</b></td></tr>");
            htw.Write("<table width='100%'><tr><td colspan='5' align='center'></td></tr>");




            for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
            {
                strQry = "exec [usp_Syllabus_Master] @type='FillReportSyllabus',@intTopic_id='" + Convert.ToString(dsObj.Tables[0].Rows[i]["intTopic_id"]) + "',@intstandard_id='" + STD + "',@intDivision_id='" + Convert.ToString(DIV) + "'";
                DataTable dt = new DataTable();
                dt = sGetDatatable(strQry, "Data");
                try
                {
                    htw.Write("<table width='100%'><tr><td></td><td colspan='1' align='center'>Topic :</td><td colspan='3' align='left'><b>" + dt.Rows[0]["vchTopicName"].ToString() + "</b></td></tr>");
                    htw.Write("<table width='100%'><tr><td></td><td colspan='5' align='center'></td></tr>");
                    gvDetails.DataSource = dt;
                    gvDetails.DataBind();

                    //gvDetails.Columns[2].Visible = false;
                    //gvDetails.Columns[3].Visible = false;

                    gvDetails.AllowPaging = false;
                    //Change the Header Row back to white color
                    gvDetails.HeaderRow.Style.Add("background-color", "#FFFFFF");
                    //Applying stlye to gridview header cells
                    for (int k = 0; k < gvDetails.HeaderRow.Cells.Count; k++)
                    {
                        gvDetails.HeaderRow.Cells[k].Style.Add("background-color", "#037403");
                        gvDetails.HeaderRow.Cells[k].Style.Add("color", "#FFFFFF");
                    }
                    gvDetails.HeaderRow.Cells[0].Visible = false;
                    gvDetails.HeaderRow.Cells[1].ColumnSpan = 2;
                    gvDetails.HeaderRow.Cells[2].ColumnSpan = 5;
                    gvDetails.HeaderRow.Cells[3].Visible = false;
                    gvDetails.HeaderRow.Cells[4].Visible = false;
                    int j = 1;
                    //Set alternate row color
                    foreach (GridViewRow gvrow in gvDetails.Rows)
                    {
                        gvrow.BackColor = System.Drawing.Color.White;
                        if (j <= gvDetails.Rows.Count)
                        {

                            gvrow.Cells[0].Visible = false;
                            gvrow.Cells[1].ColumnSpan = 2;
                            gvrow.Cells[2].ColumnSpan = 5;
                            gvrow.Cells[3].Visible = false;
                            gvrow.Cells[4].Visible = false;
                        }
                        j++;
                    }
                    gvDetails.RenderControl(htw);
                    htw.Write("<table width='100%'><tr><td></td><td colspan='5' align='center'></td></tr>");
                }
                catch (Exception ex)
                {
                    dsObj = null;
                    //MessageBox.Show(ex.ToString());
                }
            }




            HttpContext.Current.Response.Write(sw.ToString());
            HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }
        catch
        {

        }

    }
    public void ExportWord()
    {
        try
        {
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", ddlSub.SelectedItem.Text + DateTime.Now + ".doc"));
            HttpContext.Current.Response.ContentType = "application/ms-word";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView gvDetails = new GridView();
            gvDetails.AutoGenerateColumns = true;
            gvDetails.Width = 100;
            STD = Session["Standard_id"].ToString();
            DIV = Session["Division_id"].ToString();
            htw.Write("<table width='100%'><tr><td colspan='1' rowspan='2'><img src='~\\images\\pdflogo.jpg' alt='' /></td><td></td><td colspan='4' ><h2>Deep Global School</h2></td></tr>");
            htw.Write("<table><tr><td></td><td></td><td colspan='2' align='left'>Kurla</td><td colspan='2' align='left'> Pin:401501</td></tr><tr><td><br/></td></tr></table>");

            //if (Convert.ToString(Session["UserType_id"]) == "5")
            //{
            if (Convert.ToString(Session["UserType_Id"]) == "1" || Convert.ToString(Session["UserType_Id"]) == "2")
            {
                htw.Write("<table width='100%'><tr><td><b></b></td><td colspan='3'> </td></tr>");
                htw.Write("<table width='100%'><tr><td><b>STD</b></td><td colspan='3' align='left'>" + Session["Standard_id"].ToString() + "</td><td><b>Date</b></td><td align='left'>" + Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy") + "</td></tr>");
                htw.Write("<table width='100%'><tr><td><b>DIV</b></td><td colspan='3' align='left'>" + Session["Division_id"].ToString() + "</td><td><b>Time</b></td><td align='left'>" + Convert.ToDateTime(DateTime.Now).ToString("hh:mm \tt") + "</td></tr>");
            }
            else
            {
                htw.Write("<table width='100%'><tr><td><b></b></td><td colspan='3'> </td><td><b>Date</b></td><td>" + Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy") + "</td></tr>");
                htw.Write("<table width='100%'><tr><td><b>STD</b></td><td colspan='3' align='left'>" + Convert.ToString(ddlSTD1.SelectedValue) + "</td><td><b>Time</b></td><td align='left'>" + Convert.ToDateTime(DateTime.Now).ToString("hh:mm \tt") + "</td></tr>");
                htw.Write("<table width='100%'><tr><td><b>DIV</b></td><td colspan='3' align='left'>" + Convert.ToString(ddlDIV.SelectedValue) + "</td></tr>");
            }
            //}

            //else
            //{
            //    htw.Write("<table width='100%'><tr><td><b>Date</b></td><td>" + Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy") + "</td></tr>");
            //    htw.Write("<table width='100%'><tr><td><b>Time</b></td><td>" + Convert.ToDateTime(DateTime.Now).ToString("hh:mm \tt") + "</td></tr>");
            // //   htw.Write("<table width='100%'><tr><td><b>DIV</b></td><td colspan='3' align='left'>" + DIV + "</td></tr>");
            //}
            htw.Write("<table width='100%'><tr><td></td><td colspan='5' align='center'></td></tr>");
            htw.Write("<table width='100%'><tr><td></td><td colspan='1' align='center'>Subject :</td><td colspan='3' align='left'><b>" + dsObj.Tables[0].Rows[0]["Subject"] + "</b></td></tr>");
            htw.Write("<table width='100%'><tr><td colspan='5' align='center'></td></tr>");




            for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
            {
                strQry = "exec [usp_Syllabus_Master] @type='FillReportSyllabus',@intTopic_id='" + Convert.ToString(dsObj.Tables[0].Rows[i]["intTopic_id"]) + "',@intstandard_id='" + STD + "',@intDivision_id='" + Convert.ToString(DIV) + "'";
                DataTable dt = new DataTable();
                dt = sGetDatatable(strQry, "Data");
                try
                {
                    htw.Write("<table width='100%'><tr><td></td><td colspan='1' align='center'>Topic :</td><td colspan='3' align='left'><b>" + dt.Rows[0]["vchTopicName"].ToString() + "</b></td></tr>");
                    htw.Write("<table width='100%'><tr><td></td><td colspan='5' align='center'></td></tr>");
                    gvDetails.DataSource = dt;
                    gvDetails.DataBind();

                    //gvDetails.Columns[2].Visible = false;
                    //gvDetails.Columns[3].Visible = false;

                    gvDetails.AllowPaging = false;
                    //Change the Header Row back to white color
                    gvDetails.HeaderRow.Style.Add("background-color", "#FFFFFF");
                    //Applying stlye to gridview header cells
                    for (int k = 0; k < gvDetails.HeaderRow.Cells.Count; k++)
                    {
                        gvDetails.HeaderRow.Cells[k].Style.Add("background-color", "#037403");
                        gvDetails.HeaderRow.Cells[k].Style.Add("color", "#FFFFFF");
                    }
                    gvDetails.HeaderRow.Cells[0].Visible = false;
                    gvDetails.HeaderRow.Cells[1].ColumnSpan = 2;
                    gvDetails.HeaderRow.Cells[2].ColumnSpan = 5;
                    gvDetails.HeaderRow.Cells[3].Visible = false;
                    gvDetails.HeaderRow.Cells[4].Visible = false;
                    int j = 1;
                    //Set alternate row color
                    foreach (GridViewRow gvrow in gvDetails.Rows)
                    {
                        gvrow.BackColor = System.Drawing.Color.White;
                        if (j <= gvDetails.Rows.Count)
                        {

                            gvrow.Cells[0].Visible = false;
                            gvrow.Cells[1].ColumnSpan = 2;
                            gvrow.Cells[2].ColumnSpan = 5;
                            gvrow.Cells[3].Visible = false;
                            gvrow.Cells[4].Visible = false;
                        }
                        j++;
                    }
                    gvDetails.RenderControl(htw);
                    htw.Write("<table width='100%'><tr><td></td><td colspan='5' align='center'></td></tr>");
                }
                catch (Exception ex)
                {
                    dsObj = null;
                    //MessageBox.Show(ex.ToString());
                }
            }

            HttpContext.Current.Response.Write(sw.ToString());
            HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }
        catch
        {

        }
    }
    protected void ImgDoc_Click(object sender, ImageClickEventArgs e)
    {

        //Response.Clear();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
        //Response.Charset = "";
        //Response.ContentType = "application/vnd.ms-excel";
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        // grvStudLate.RenderControl(hw);
        //Response.Output.Write(sw.ToString());

        //Response.Flush();
        //Response.End();
        strQry = "exec [usp_Syllabus_Master] @type='FillGrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSubject_id='" + Convert.ToString(ddlSub.SelectedValue) + "'";
        dsObj = sGetDataset(strQry);

        try
        {
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ExportWord();
            }
            else
            {
                MessageBox("Please Select Subject First");
            }
        }
        catch
        {

        }
    }
    protected void ddlExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSTD1.ClearSelection();
        ddlDIV.ClearSelection();
        ddlSub.ClearSelection();
    }

    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["esmsCentralModel"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select id, Name from tblexport";
                cmd.Connection = con;
                con.Open();
                //GridView1.DataSource = cmd.ExecuteReader();
                //GridView1.DataBind();
                con.Close();
            }
        }
    }
    protected void DownloadFile(object sender, EventArgs e)
    {

        int id = int.Parse((sender as LinkButton).CommandArgument);
        byte[] bytes;
        string fileName, contentType;

        string constr = ConfigurationManager.ConnectionStrings["esmsCentralModel"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select Name,Data,ContentType from tblexport where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    bytes = (byte[])sdr["Data"];
                    contentType = sdr["ContentType"].ToString();
                    fileName = sdr["Name"].ToString();
                }
                con.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        //    {
        //        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
        //        string contentType = FileUpload1.PostedFile.ContentType;
        //        using (Stream fs = FileUpload1.PostedFile.InputStream)
        //        {
        //            using (BinaryReader br = new BinaryReader(fs))
        //            {
        //                byte[] bytes = br.ReadBytes((Int32)fs.Length);
        //                string constr = ConfigurationManager.ConnectionStrings["esmsCentralModel"].ConnectionString;
        //                using (SqlConnection con = new SqlConnection(constr))
        //                {
        //                    string query = "insert into tblexport values (@Name, @ContentType, @Data,@intStandard_id,@intSubject_id,@intExam_id)";
        //                    using (SqlCommand cmd = new SqlCommand(query))
        //                    {
        //                        cmd.Connection = con;
        //                        cmd.Parameters.AddWithValue("@Name", filename);
        //                        cmd.Parameters.AddWithValue("@ContentType", contentType);
        //                        cmd.Parameters.AddWithValue("@Data", bytes);
        //                        cmd.Parameters.AddWithValue("@intstandard_id", ddlSTD3.SelectedValue);
        //                        cmd.Parameters.AddWithValue("@intSubject_id", ddlSub2.SelectedValue);
        //                        cmd.Parameters.AddWithValue("@intExam_id", chkExamList.SelectedValue);
        //                        con.Open();
        //                        cmd.ExecuteNonQuery();
        //                        con.Close();
        //                    }
        //                }
        //            }
        //        }
        //        Response.Redirect(Request.Url.AbsoluteUri);
        //    }
        //}
    }
   
}
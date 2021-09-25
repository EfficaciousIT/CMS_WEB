using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class frmSendGroupMsg : DBUtility
{
    string strQry = string.Empty;
    string GroupId = "";
    string MemId = "";
    
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserType_Id"] != null && Session["User_Id"] != null)
        {
            Label lblTitle = new Label();
            lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            lblTitle.Visible = true;
            lblTitle.Text = "Messaging Detail";

            if (!IsPostBack)
            {
                if (Convert.ToString(Session["UserType_Id"]) == "1")
                {
                    Session["User_Id1"] = Session["Student_Id"];
                }
                else
                {
                    Session["User_Id1"] = Session["User_Id"];
                }
                lblName.Visible = false;
                ddlName.Visible = false;
                StudVisible(false);
                TeacherVisible(false);
                FillGrid();
                FillUserType();
                geturl();

                if (Convert.ToString(Session["UserType_id"]) == "3")
                {
                    trSTD.Visible = true;
                    trDiv.Visible = true;
                }
                // Timer1.Enabled = true;
            }
        }
        else
        {
            Response.Redirect("~\\frmIndex.aspx", false);
        }
        
    }

    [System.Web.Services.WebMethod]
    public static string OP()
    {
        string a = "";
        Page page = HttpContext.Current.Handler as Page;
        TextBox txt = new TextBox();
        txt = (TextBox)page.FindControl("txtChat");
        return a;
    }

    //[System.Web.Services.WebMethod(EnableSession=true)]
    //public static string OpenChat()
    //{
    //    string strQry = string.Empty;
    //    DataSet dsObj = new DataSet();
    //    TextBox txtChat = new TextBox();
    //    TextBox txtMsg = new TextBox();
    //    Page page = HttpContext.Current.Handler as Page;
    //    try
    //    {
    //        //if (HttpContext.Current.Session["GrpId"] != null)
    //        //{

    //            strQry = "select top 100 *,vchStudentFirst_name as name from  tblMessage_Mst inner join student_master on tblMessage_Mst.intUser_SenderId=student_master.intstudent_id where ((intUser_SenderId='" + HttpContext.Current.Session["Student_id"] + "' and intUser_ReceiveId='"+ ddl +"') or (intUser_SenderId='" + HttpContext.Current.Session["Student_id"] + "' and intUser_ReceiveId='372'))";
    //            //strQry = "select top 100 *,vchStudentFirst_name as name from  tblMessage_Mst inner join student_master on tblMessage_Mst.intUser_SenderId=student_master.intstudent_id where ((intUser_SenderId='372' and intUser_ReceiveId='388') or (intUser_SenderId='388' and intUser_ReceiveId='372'))";
    //            //strQry = "exec usp_MessageMst @type='Chatbox',@intGroupid='" + Convert.ToString(HttpContext.Current.Session["GrpId"]) + "',@intSchool_Id='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "'";
    //            //
    //            dsObj = new DataSet();
    //            dsObj = sGetDataset(strQry);
    //            if (dsObj.Tables[0].Rows.Count > 0)
    //            {

    //                txtChat.Text = "";
    //                txtChat.Style["text-align"] = "Left";

    //                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
    //                {

    //                    Label txt = new Label();
    //                    txt.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Message"]);
    //                    txt.ForeColor = System.Drawing.Color.Green;

    //                    //txtChat.Text = txtChat.Text + Environment.NewLine + "You :" + Convert.ToString(dsObj.Tables[0].Rows[i]["Name"]) + " " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtMessageDate"]) + Environment.NewLine + Convert.ToString(txt.Text) + Environment.NewLine;

    //                    txtChat.Text = txtChat.Text + Environment.NewLine + "You :" + dsObj.Tables[0].Rows[i]["Name"] + " " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtMessageDate"]) + Environment.NewLine + Convert.ToString(dsObj.Tables[0].Rows[i]["Message"]) + Environment.NewLine;

    //                    //txtChat.Text = txtChat.Text + Environment.NewLine + Convert.ToString(HttpContext.Current.Session["MemId"].ToString() == dsObj.Tables[0].Rows[i]["intGrpMem_Id"].ToString() ? "You" : dsObj.Tables[0].Rows[i]["Name"]) + " " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtMessageDate"]) + Environment.NewLine + Convert.ToString(txt.Text) + Environment.NewLine;
    //                    //if (HttpContext.Current.Session["MemId"].ToString() == dsObj.Tables[0].Rows[i]["intGrpMem_Id"].ToString())
    //                    //{
                            
    //                    //}
    //                    //else
    //                    //{
    //                    //    //txtChat.Style["text-align"] = "end";
    //                    //    txtChat.Text = txtChat.Text + Environment.NewLine + Convert.ToString(HttpContext.Current.Session["MemId"].ToString() == dsObj.Tables[0].Rows[i]["intGrpMem_Id"].ToString() ? "You" : dsObj.Tables[0].Rows[i]["Name"]) + " " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtMessageDate"]) + Environment.NewLine + Convert.ToString(dsObj.Tables[0].Rows[i]["Message"]) + Environment.NewLine;
    //                    //}
    //                }
    //                // btnMsg.Attributes.Add("onclick", "textBoxScroll()");


    //                //ScriptManager.RegisterStartupScript(page, page.GetType(), "name", "Scroll();", true);

    //            }

    //            // txtMsg.Text = Session["Text"].ToString(); ;
    //            //txtMsg.Focus();
    //            //strQry = string.Empty;
    //            //strQry = "exec [usp_MessageMst] @type='UpdateNotification',@intGrpMember_Id='" + HttpContext.Current.Session["MemId"].ToString() + "',@intSchool_Id='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "'";
    //            //sExecuteQuery(strQry);

    //            return txtChat.Text;

    //        //}
    //        //else
    //        //{
    //        //   // Response.Redirect("~\\index.aspx", false);
    //        //    return "false";
    //        //}
    //    }
    //    catch(Exception ex)
    //    {
    //        return "false";
    //    }
    //}

    


    public void FillSTD()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "1" || Convert.ToString(Session["UserType_Id"]) == "2")
            {
                strQry = "exec [usp_FillDropDownForGroupMsg] @type='FillSTD_Student',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intStudent_id='" + Convert.ToString(Session["User_Id1"]) + "'";
                sBindDropDownList(ddlStd, strQry, "vchStandard_name", "intstandard_id");
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "3")
            {
                strQry = "exec [usp_FillDropDownForGroupMsg] @type='FillSTD_Staff',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intUserId='" + Convert.ToString(Session["User_Id1"]) + "'";
                sBindDropDownList(ddlStd, strQry, "vchStandard_name", "intstandard_id");
            }
            else
            {
                strQry = "exec [usp_FillDropDownForGroupMsg] @type='FillSTD',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                sBindDropDownList(ddlStd, strQry, "vchStandard_name", "intstandard_id");
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
            if (Convert.ToString(Session["UserType_Id"]) == "1" || Convert.ToString(Session["UserType_Id"]) == "2")
            {

                strQry = "exec [usp_FillDropDownForGroupMsg] @type='FillDIV_Student',@STD='" + Convert.ToString(ddlStd.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intStudent_id='" + Convert.ToString(Session["User_id1"]) + "'";
                sBindDropDownList(ddlDiv, strQry, "vchDivisionName", "intDivision_id");
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "3")
            {
                strQry = "exec [usp_FillDropDownForGroupMsg] @type='FillDIV_Staff',@STD='" + Convert.ToString(ddlStd.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intUserId='" + Convert.ToString(Session["User_id1"]) + "'";
                sBindDropDownList(ddlDiv, strQry, "vchDivisionName", "intDivision_id");
            }
            else
            {
                strQry = "exec [usp_FillDropDown] @type='DIV',@intStandard_id='" + Convert.ToString(ddlStd.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                sBindDropDownList(ddlDiv, strQry, "vchDivisionName", "intDivision_id");
            }

        }
        catch
        {

        }
    }
    public void FillUserType()
    {
        try
        {
            strQry = string.Empty;
            strQry = "exec [usp_FillDropDown] @type='UserType',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlType, strQry, "vchUser_name", "intUserType_id");
        }
        catch
        {

        }
    }
    public void FillDept()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "1" || Convert.ToString(Session["UserType_Id"]) == "2")
            {
                strQry = "exec [usp_FillDropDownForGroupMsg] @type='Department_Student',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intUserType='" + Convert.ToString(ddlType.SelectedValue) + "',@DIV='" + Convert.ToString(Session["Division_id"]) + "'";
                sBindDropDownList(ddlName, strQry, "Name", "intTeacher_id");
            }
            else
            {
                strQry = "exec usp_FillDropDown @type='TrainingDepartment',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intUserType='" + Convert.ToString(ddlType.SelectedValue) + "'";
            }
            sBindDropDownList(ddlDept, strQry, "vchDepartment_name", "intDepartment");
            ddlName.Visible = true;
            lblName.Visible = true;
            //ddlDept.Items.Add(new ListItem("All", "-1"));

        }
        catch
        {

        }
    }
    public void FillStudent()
    {
        try
        {
            if (Convert.ToString(Session["Student_id"]) != "")
            {
                strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(Session["Division_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                sBindDropDownList(ddlName, strQry, "Name", "intStudent_id");
            }
            else
            {
                strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDiv.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                sBindDropDownList(ddlName, strQry, "Name", "intStudent_id");
            }            
            // ddlName.Items.Add(new ListItem("All", "-1"));
        }
        catch
        {

        }
    }
    public void OpenChat()
    {
        try
        {
            if ((Session["Student_id"] != null && ddlName.SelectedValue != "0") || Session["User_id"]!="")
            {


                strQry = string.Empty;
                //strQry = "exec usp_MessageMst @type='PrivateChatBox',@intUser_id='" + Session["Student_id"].ToString() + "',@intUser_id2='" + Convert.ToString(ddlName.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                string strID = string.Empty;
                if (Convert.ToString(Session["Student_id"]) != "0")
                {
                    strID = Convert.ToString(Session["Student_id"]);
                }
                else
                {
                    strID = Convert.ToString(Session["User_id"]);
                }

                strQry = "select dtMessageDate,message,vchStudentFirst_name as name from  tblMessage_Mst inner join student_master on tblMessage_Mst.intUser_SenderId=student_master.intstudent_id where ((intUser_SenderId='" + strID.Trim() + "' and intUser_ReceiveId='" + ddlName.SelectedValue.Trim() + "') or (intUser_SenderId='" + ddlName.SelectedValue.Trim() + "' and intUser_ReceiveId='" + strID.Trim() + "'))";
                //26-11-2014
                //strQry = "exec usp_MessageMst @type='ChatBox',@intGroupid='" + Convert.ToString(dsObj.Tables[0].Rows[0]["intGroup_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";

                dsObj = new DataSet();
                dsObj = sGetDataset(strQry);

                txtChat.Text = "";

                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    txtChat.Text = "";

                    for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                    {
                        //txtChat.Text = "";
                        txtChat.Style["text-align"] = "Left";

                        //if (Session["Student_id"].ToString() == dsObj.Tables[0].Rows[i]["intUser_SenderId"].ToString() && Session["UserType_Id"].ToString() == dsObj.Tables[0].Rows[i]["intUserType_id"].ToString())
                        if (txtChat.Text == "")
                        {
                            Label txt = new Label();
                            txt.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Message"]);
                            txt.ForeColor = System.Drawing.Color.Green;
                            txtChat.Text = txtChat.Text + Environment.NewLine + Convert.ToString("You") + " " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtMessageDate"]) + Environment.NewLine + Convert.ToString(txt.Text) + Environment.NewLine;
                        }
                        else
                        {
                            //txtChat.Style["text-align"] = "end";
                            txtChat.Text = txtChat.Text + Environment.NewLine + Convert.ToString(dsObj.Tables[0].Rows[i]["Name"]) + " " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtMessageDate"]) + Environment.NewLine + Convert.ToString(dsObj.Tables[0].Rows[i]["Message"]) + Environment.NewLine;
                        }
                        int intlen = txtChat.Text.Length;
                        // btnMsg.Attributes.Add("onclick", "textBoxScroll()");


                        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "Scroll();", true);

                    }
                }
                



                //strQry = string.Empty;
                //strQry = "exec usp_MessageMst @type='CheckExist',@intUser_id2='" + Convert.ToString(Session["User_Id1"]) + "',@intUserType_id2='" + Convert.ToString(Session["UserType_Id"]) + "',@intUser_id='" + Convert.ToString(ddlName.SelectedValue) + "',@intUserType_id='" + Convert.ToString(ddlType.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                //dsObj = new DataSet();
                //dsObj = sGetDataset(strQry);
                //if (dsObj.Tables[0].Rows.Count > 0)
                //{

                //}
                //else
                //{
                //    txtChat.Text = "";
                //    Session["GrpId"] = null;
                //}
            }
        }
        catch
        {

        }
    }
    protected void UpdateTimer_Tick(object sender, EventArgs e)
    {
        OpenChat();
        //string strSender_id = string.Empty;


        //string strQry = string.Empty;
        //DataSet dsObj = new DataSet();
        //TextBox txtChat = new TextBox();
        //TextBox txtMsg = new TextBox();
        //Page page = HttpContext.Current.Handler as Page;
        //try
        //{
        //    strQry = string.Empty;
        //    //strQry = "exec usp_MessageMst @type='PrivateChatBox',@intUser_id='" + Session["Student_id"].ToString() + "',@intUser_id2='" + Convert.ToString(ddlName.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";

        //    strQry = "select dtMessageDate,message,vchStudentFirst_name as name from  tblMessage_Mst inner join student_master on tblMessage_Mst.intUser_SenderId=student_master.intstudent_id where ((intUser_SenderId='" + HttpContext.Current.Session["Student_id"] + "' and intUser_ReceiveId='" + ddlName.SelectedValue.Trim() + "') or (intUser_SenderId='" + ddlName.SelectedValue.Trim() + "' and intUser_ReceiveId='" + HttpContext.Current.Session["Student_id"] + "'))";
        //    //26-11-2014
        //    //strQry = "exec usp_MessageMst @type='ChatBox',@intGroupid='" + Convert.ToString(dsObj.Tables[0].Rows[0]["intGroup_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";

        //    dsObj = new DataSet();
        //    dsObj = sGetDataset(strQry);

        //    txtChat.Text = "";

        //    if (dsObj.Tables[0].Rows.Count > 0)
        //    {
        //        txtChat.Text = "";

        //        for (int i = 0; i <= dsObj.Tables[0].Rows.Count; i++)
        //        {
        //            //txtChat.Text = "";
        //            txtChat.Style["text-align"] = "Left";

        //            //if (Session["Student_id"].ToString() == dsObj.Tables[0].Rows[i]["intUser_SenderId"].ToString() && Session["UserType_Id"].ToString() == dsObj.Tables[0].Rows[i]["intUserType_id"].ToString())
        //            if (txtChat.Text == "")
        //            {
        //                Label txt = new Label();
        //                txt.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Message"]);
        //                txt.ForeColor = System.Drawing.Color.Green;
        //                txtChat.Text = txtChat.Text + Environment.NewLine + Convert.ToString("You") + " " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtMessageDate"]) + Environment.NewLine + Convert.ToString(txt.Text) + Environment.NewLine;
        //            }
        //            else
        //            {
        //                //txtChat.Style["text-align"] = "end";
        //                txtChat.Text = txtChat.Text + Environment.NewLine + Convert.ToString(dsObj.Tables[0].Rows[i]["Name"]) + " " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtMessageDate"]) + Environment.NewLine + Convert.ToString(dsObj.Tables[0].Rows[i]["Message"]) + Environment.NewLine;
        //            }

        //            // btnMsg.Attributes.Add("onclick", "textBoxScroll()");


        //            //ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "Scroll();", true);

        //        }
        //    }                     
        //}
        //catch (Exception ex)
        //{
        //    //return "false";
        //}


    }
    public void FillTeacher()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) != "1" && Convert.ToString(Session["UserType_Id"]) != "2")
            {
                strQry = "exec usp_FillDropDown @type='GetStaff',@intDept_id='" + Convert.ToString(ddlDept.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intUserType='" + Convert.ToString(ddlType.SelectedValue) + "'";
                sBindDropDownList(ddlName, strQry, "Name", "intTeacher_id");
            }
            //ddlName.Items.Add(new ListItem("All", "-1"));
        }
        catch
        {

        }
    }
    protected void txtStudSearch_TextChanged(object sender, EventArgs e)
    {
        try
        {
            
        
        }
        catch
        {           
            
        }
    }
    
    public DataSet CreateTable()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
               strQry = string.Empty;
               strQry = "exec usp_MessageMst @type='FillNotificationGrid_Admin',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            }
            else
            {
                strQry = string.Empty;
                strQry = "exec usp_MessageMst @type='FillNotificationGrid',@intUser_id='" + Session["User_Id1"] + "',@intUserType_id='" + Session["UserType_Id"] + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
            }
            dsObj = sGetDataset(strQry);
            return dsObj;
        }
        catch (Exception)
        {
            return dsObj;
        }
       

    }


    public DataSet CreatePrivateTable()
    {
        try
        {
         
           
                strQry = string.Empty;
                strQry = "exec usp_MessageMst @type='FillNotificationGrid_Private',@intUser_id='" + Session["User_Id1"] + "',@intUserType_id='" + Session["UserType_Id"] + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
                
             
            dsObj = sGetDataset(strQry);
            return dsObj;
        }
        catch (Exception)
        {
            return dsObj;
        }


    }
    public void FillGrid()
    {
        try
        {
            grvChatDetail.DataSource = CreateTable();
            grvChatDetail.DataBind();

            grvPrivateMsg.DataSource = CreatePrivateTable();
            grvPrivateMsg.DataBind();
        }
        catch 
        {
            
        }
    }

    

    public void StudVisible(Boolean bln)
    {
        lblName.Text = "Roll-Name";
        lblDiv.Visible = bln;
        lblStd.Visible = bln;
        ddlDiv.Visible = bln;
        ddlStd.Visible = bln;
       
    }
    public void TeacherVisible(Boolean bln)
    {
       
        lblDept.Visible = bln;
        ddlDept.Visible = bln;
        
    }
    
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlType.SelectedValue == "1")
        {
            StudVisible(true);
            TeacherVisible(false);
            FillSTD();
            lblName.Visible = true;
            ddlName.Visible = true;
            lblName.Text = "Student";
            FillStudent();
        }
        else if (ddlType.SelectedValue == "2")
        {
            StudVisible(true);
            TeacherVisible(false);
            FillSTD();
            lblName.Visible = true;
            ddlName.Visible = true;
        }
        else if (ddlType.SelectedValue == "3" || ddlType.SelectedValue == "4")
        {
           
            StudVisible(false);
            TeacherVisible(true);
            FillDept();
            FillTeacher();
            lblName.Visible = true;
            ddlName.Visible = true;
            lblName.Text = "Staff";
        }
     
        else if (ddlType.SelectedValue == "0")
        {
            StudVisible(false);
            lblName.Visible = false;
            ddlName.Visible = false;
           
        }
    }
    protected void ddlStd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlStd.SelectedValue != "0")
            {
                FillDIV();
                FillStudent();
                ddlDiv.Visible = true;
                lblDiv.Visible = true;
            }
            else
            {
                ddlDiv.Visible = false;
                lblDiv.Visible = false;
            }
        }
        catch 
        {
            
        }
    }
    
  
    protected void Button5_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();
            if (ddlType.SelectedValue == "0")
            {
                MessageBox("Please Select Type First");
                return;
            }
             if (ddlStd.Visible == true)
            {
                if (ddlStd.SelectedValue == "0")
                {
                    MessageBox("Please Select Standard First");
                    return;
                }
            }
             if (ddlDiv.Visible == true)
            {
                if (ddlDiv.SelectedValue == "0")
                {
                    MessageBox("Please Select Division First");
                    return;
                }
            }
             if (ddlDept.Visible == true)
            {
                if (ddlDept.SelectedValue == "0")
                {
                    MessageBox("Please Select Department First");
                    return;
                }
            }
            else if (ddlName.Visible == true)
            {
                if (ddlName.SelectedValue == "0")
                {
                    MessageBox("Please Select Name First");
                    return;
                }
            }


            string GroupId;

            if (txtMsg.Text != "")
            {


                strQry = string.Empty;
                strQry = "exec usp_MessageMst @type='CheckExist',@intUser_id2='" + Convert.ToString(Session["User_Id1"]) + "',@intUserType_id2='" + Convert.ToString(Session["UserType_Id"]) + "',@intUser_id='" + Convert.ToString(ddlName.SelectedValue) + "',@intUserType_id='" + Convert.ToString(ddlType.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = new DataSet();
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    Session["GrpId"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intGroup_id"]);
                    Session["MemId"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intGrpMem_Id"]);


                    strQry = string.Empty;
                    strQry = "exec [usp_MessageMst] @type='UpdateNotification',@intGrpMember_Id='" + Session["MemId"].ToString() + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                    sExecuteQuery(strQry);
                }
                else
                {
                    strQry = string.Empty;
                    //strQry = "exec usp_GroupMsg_Mst @type='Insert',@vchGroup_name='Private',@vchGroupType='Private',@intGroupCreatedBy='" + Session["User_Id"] + "',@intUser_id='" + Session["User_Id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                    
                    //26-11-2014  This will adding group details as well as created gropu member detail also
                    strQry = "exec [usp_GroupMemberMsg_Mst] @type='Insert',@vchGroup_name='Private',@vchGroupType='Private',@intGroupCreatedByType='" + Convert.ToString(Session["UserType_Id"]) + "',@intUserType_id='" + Convert.ToString(Session["UserType_Id"]) + "',@intGroupCreatedBy='" + Session["User_Id1"] + "',@intStudent_id='" + Convert.ToString(Session["UserType_Id"] == "1" ? Session["User_Id1"] : "0") + "',@intUser_id='" + Convert.ToString(Session["UserType_Id"] == "1" ? "0" : Session["User_Id1"]) + "',@intInsertedBy='" + Session["User_Id1"] + "',@vchInsertedIp='" + GetSystemIP() + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                    if (sExecuteQuery(strQry) != -1)
                    {
                        strQry = string.Empty;
                        strQry = "exec [usp_GroupMsg_Mst] @type='LastInsertedId',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                        dsObj = new DataSet();
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            Session["GrpId"] = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
                            GroupId = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
                            strQry = string.Empty;
                            //strQry = "exec usp_GroupMemberMsg_Mst @type='InsertMember',@intGroup_id='" + Convert.ToString(GroupId) + "',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@intUserType_id='" + Convert.ToString(Session["UserType_Id"]) + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + Convert.ToString(GetSystemIP()) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                               
                            //if (sExecuteQuery(strQry) != -1)
                            //{
                                strQry = string.Empty;
                                strQry = "exec usp_GroupMemberMsg_Mst @type='InsertMember',@intGroup_id='" + Convert.ToString(GroupId) + "',@intUser_id='" + Convert.ToString(ddlType.SelectedValue == "1" ? "0" : ddlName.SelectedValue) + "',@intStudent_id='" + Convert.ToString(ddlType.SelectedValue == "1" ? ddlName.SelectedValue : "0") + "',@intUserType_id='" + Convert.ToString(ddlType.SelectedValue) + "',@intInsertedBy='" + Session["User_Id1"] + "',@vchInsertedIp='" + Convert.ToString(GetSystemIP()) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                            
                                sExecuteQuery(strQry);

                                 strQry = string.Empty;
                                 strQry = "exec [usp_GroupMsg_Mst] @type='LastInsertedId',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                                    dsObj = new DataSet();
                                    dsObj = sGetDataset(strQry);
                                    if (dsObj.Tables[0].Rows.Count > 0)
                                    {
                                        Session["MemId"] = dsObj.Tables[0].Rows[0][0];

                                        strQry = string.Empty;
                                        strQry = "exec [usp_MessageMst] @type='UpdateNotification',@intGrpMember_Id='" + Session["MemId"].ToString() + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                                        sExecuteQuery(strQry);
                                    }
                            //}
                        }
                    }

                }


           


                dsObj = new DataSet();
                strQry = string.Empty;
                strQry = "exec usp_MessageMst @type='Insert',@intGroupid='" + Session["GrpId"] + "',@intGrpMember_Id='" + Session["MemId"] + "',@intUser_SenderId='" + Convert.ToString(Session["User_Id1"]) + "',@intUser_ReceiveType='" + Convert.ToString(ddlType.SelectedValue) + "',@intUser_ReceiveId='" + Convert.ToString(ddlName.SelectedValue) + "',@intInserted_by='" + Session["User_Id1"] + "',@Inserted_IP='" + GetSystemIP() + "',@Message='" + Convert.ToString(txtMsg.Text.Trim()) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    txtMsg.Text = "";
                    OpenChat();
                }
                else
                {
                    MessageBox("Problem Found! ");
                }
            }
        }
        catch (Exception)
        {

            throw;
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
    protected void ddlDiv_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDiv.SelectedValue != "0")
            {
                FillStudent();
                ddlName.Visible = true;
                lblName.Visible = true;
            }
            else
            {
                ddlName.Visible = false;
                lblName.Visible = false;
            }
            
        }
        catch
        {
            
        }
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDept.SelectedValue != "0")
            {
                FillTeacher();
                ddlName.Visible = true;
                lblName.Visible = true;
            }
            else
            {
                ddlName.Visible = false;
                lblName.Visible = false;
            }
        }
        catch 
        {
            
        }
    }



    protected void grvChatDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ImgCall")
            {
                
                string UnivID = e.CommandArgument.ToString();
                ImageButton lb = (ImageButton)e.CommandSource;
               GridViewRow gvr= (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                Label lblMemId = (Label)grvChatDetail.Rows[gvr.RowIndex].FindControl("lblMemid");
                //Response.Redirect("frmViewChatDetails.aspx?intGroup_id=" + UnivID + "&intGrpMem_Id=" + lblMemId.Text);

                strQry = string.Empty;
                strQry = "exec [usp_MessageMst] @type='UpdateNotification',@intGrpMember_Id='" + lblMemId.Text + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                sExecuteQuery(strQry);

                

                //FillGrid();
                lb.Attributes.Add("onclick", "window.open('frmViewChatDetails.aspx?intGroup_id=" + UnivID + "&intGrpMem_Id=" + lblMemId.Text + "&Type=Public','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=800,top=90,left=100');return false");
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        FillGrid();
        if (Session["GrpId"] != null)
        {
            OpenChat();
        }
    }
    protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
    {
        OpenChat();
        //try
        //{
        //    if (Session["Student_id"] != null && ddlName.SelectedValue != "0")
        //    {


        //        strQry = string.Empty;
        //        //strQry = "exec usp_MessageMst @type='PrivateChatBox',@intUser_id='" + Session["Student_id"].ToString() + "',@intUser_id2='" + Convert.ToString(ddlName.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";

        //        strQry = "select dtMessageDate,message,vchStudentFirst_name as name from  tblMessage_Mst inner join student_master on tblMessage_Mst.intUser_SenderId=student_master.intstudent_id where ((intUser_SenderId='" + HttpContext.Current.Session["Student_id"] + "' and intUser_ReceiveId='" + ddlName.SelectedValue.Trim() + "') or (intUser_SenderId='" + ddlName.SelectedValue.Trim() + "' and intUser_ReceiveId='" + HttpContext.Current.Session["Student_id"] + "'))";
        //        //26-11-2014
        //        //strQry = "exec usp_MessageMst @type='ChatBox',@intGroupid='" + Convert.ToString(dsObj.Tables[0].Rows[0]["intGroup_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";

        //        dsObj = new DataSet();
        //        dsObj = sGetDataset(strQry);

        //        txtChat.Text = "";

        //        if (dsObj.Tables[0].Rows.Count > 0)
        //        {
        //            txtChat.Text = "";

        //            for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
        //            {
        //                //txtChat.Text = "";
        //                txtChat.Style["text-align"] = "Left";

        //                //if (Session["Student_id"].ToString() == dsObj.Tables[0].Rows[i]["intUser_SenderId"].ToString() && Session["UserType_Id"].ToString() == dsObj.Tables[0].Rows[i]["intUserType_id"].ToString())
        //                if (txtChat.Text == "")
        //                {
        //                    Label txt = new Label();
        //                    txt.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Message"]);
        //                    txt.ForeColor = System.Drawing.Color.Green;
        //                    txtChat.Text = txtChat.Text + Environment.NewLine + Convert.ToString("You") + " " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtMessageDate"]) + Environment.NewLine + Convert.ToString(txt.Text) + Environment.NewLine;
        //                }
        //                else
        //                {
        //                    //txtChat.Style["text-align"] = "end";
        //                    txtChat.Text = txtChat.Text + Environment.NewLine + Convert.ToString(dsObj.Tables[0].Rows[i]["Name"]) + " " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtMessageDate"]) + Environment.NewLine + Convert.ToString(dsObj.Tables[0].Rows[i]["Message"]) + Environment.NewLine;
        //                }

        //                // btnMsg.Attributes.Add("onclick", "textBoxScroll()");


        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "Scroll();", true);

        //            }
        //        }



        //        //strQry = string.Empty;
        //        //strQry = "exec usp_MessageMst @type='CheckExist',@intUser_id2='" + Convert.ToString(Session["User_Id1"]) + "',@intUserType_id2='" + Convert.ToString(Session["UserType_Id"]) + "',@intUser_id='" + Convert.ToString(ddlName.SelectedValue) + "',@intUserType_id='" + Convert.ToString(ddlType.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
        //        //dsObj = new DataSet();
        //        //dsObj = sGetDataset(strQry);
        //        //if (dsObj.Tables[0].Rows.Count > 0)
        //        //{

        //        //}
        //        //else
        //        //{
        //        //    txtChat.Text = "";
        //        //    Session["GrpId"] = null;
        //        //}
        //    }
        //}
        //catch
        //{

        //}


        //string strSender_id = string.Empty;


        //string strQry = string.Empty;
        //DataSet dsObj = new DataSet();
        //TextBox txtChat = new TextBox();
        //TextBox txtMsg = new TextBox();
        //Page page = HttpContext.Current.Handler as Page;
        //try
        //{
        //    strQry = "select dtMessageDate,message,vchStudentFirst_name as name from  tblMessage_Mst inner join student_master on tblMessage_Mst.intUser_SenderId=student_master.intstudent_id where ((intUser_SenderId='" + HttpContext.Current.Session["Student_id"] + "' and intUser_ReceiveId='" + ddlName.SelectedValue.Trim() + "') or (intUser_SenderId='" + ddlName.SelectedValue.Trim() + "' and intUser_ReceiveId='" + HttpContext.Current.Session["Student_id"] + "'))";

        //    dsObj = new DataSet();
        //    dsObj = sGetDataset(strQry);
        //    if (dsObj.Tables[0].Rows.Count > 0)
        //    {

        //        txtChat.Text = "";
        //        txtChat.Style["text-align"] = "Left";

        //        for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
        //        {

        //            Label txt = new Label();
        //            txt.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Message"]);
        //            txt.ForeColor = System.Drawing.Color.Black;

        //            txtMsg.Text = txtMsg.Text + Environment.NewLine + "You :" + dsObj.Tables[0].Rows[i]["Name"] + " " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtMessageDate"]) + Environment.NewLine + Convert.ToString(dsObj.Tables[0].Rows[i]["Message"]) + Environment.NewLine;
        //        }               

        //    }
        //}
        //catch (Exception ex)
        //{
        //    //return "false";
        //}
    }
    protected void grvPrivateMsg_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ImgCall")
            {

                string UnivID = e.CommandArgument.ToString();
                ImageButton lb = (ImageButton)e.CommandSource;
                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                Label lblMemId = (Label)grvPrivateMsg.Rows[gvr.RowIndex].FindControl("lblMemid");
                Label ownMemId = (Label)grvPrivateMsg.Rows[gvr.RowIndex].FindControl("lblOwnMemId");
               // Label lblReceivedid = (Label)grvPrivateMsg.Rows[gvr.RowIndex].FindControl("lblReceiveId");
                //Response.Redirect("frmViewChatDetails.aspx?intGroup_id=" + UnivID + "&intGrpMem_Id=" + lblMemId.Text);

                strQry = string.Empty;
                strQry = "exec [usp_MessageMst] @type='UpdateNotification',@intGrpMember_Id='" + ownMemId.Text + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                sExecuteQuery(strQry);



                //FillGrid();
                lb.Attributes.Add("onclick", "window.open('frmViewChatDetails.aspx?intGroup_id=" + UnivID + "&intGrpMem_Id=" + lblMemId.Text + "&OwnMemId=" + ownMemId.Text + "&Type=Private','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=800,top=90,left=100');return false");
            }
        }
        catch 
        {

        }
    }
    protected void grvChatDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvChatDetail.PageIndex = e.NewPageIndex;
            grvChatDetail.DataBind();
            FillGrid();
        }
        catch 
        {
            
        }
    }
    protected void grvPrivateMsg_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvPrivateMsg.PageIndex = e.NewPageIndex;
            grvPrivateMsg.DataBind();
            FillGrid();
        }
        catch 
        {
            
        }
    }
}
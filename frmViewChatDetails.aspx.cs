using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmViewChatDetails : DBUtility
{
    string MemId = "";
    string GrpId = "";
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {
                    MemId = Request.QueryString["intGrpMem_Id"];
                    GrpId = Request.QueryString["intGroup_id"];
                    ViewState["GrpId"] = GrpId;
                    ViewState["MemId"] =MemId ;
                    ViewState["OwnMemId"] = Request.QueryString["OwnMemId"];
                    ViewState["Type"] = Request.QueryString["Type"];
                    Timer1.Enabled = true;

                    OpenChat();
                    geturl();
                }
            }
         else
                {
                   // Response.Redirect("~\\frmIndex.aspx", false);
                    MessageBox("Session Time Out");
                }
    }
    public void OpenChat()
    {
        try
        {
            if (ViewState["GrpId"] != null)
            {
                strQry = "exec usp_MessageMst @type='ChatBox',@intGroupid='" + Convert.ToString(ViewState["GrpId"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = new DataSet();
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                   
                    txtChat.Text = "";
                    txtChat.Style["text-align"] = "Left";

                    for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                    {
                        if ( ViewState["Type"].ToString()=="Public")
                        {
                            Label txt =new Label();
                            txt.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Message"]);
                            txt.ForeColor = System.Drawing.Color.Green;
                            txtChat.Text = txtChat.Text + Environment.NewLine + Convert.ToString(ViewState["MemId"].ToString() == dsObj.Tables[0].Rows[i]["intGrpMem_Id"].ToString() ? "You" : dsObj.Tables[0].Rows[i]["Name"]) + " " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtMessageDate"]) + Environment.NewLine + Convert.ToString(txt.Text) + Environment.NewLine;
                        }
                        else
                        {
                            //txtChat.Style["text-align"] = "end";
                            txtChat.Text = txtChat.Text + Environment.NewLine + Convert.ToString(ViewState["MemId"].ToString() == dsObj.Tables[0].Rows[i]["intGrpMem_Id"].ToString() ? "You" : dsObj.Tables[0].Rows[i]["Name"]) + " " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtMessageDate"]) + Environment.NewLine + Convert.ToString(dsObj.Tables[0].Rows[i]["Message"]) + Environment.NewLine;
                        }
                    }
                   // btnMsg.Attributes.Add("onclick", "textBoxScroll()");


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "Scroll();", true);
               
                }

               // txtMsg.Text = Session["Text"].ToString(); ;

                strQry = "";
                if (ViewState["Type"].ToString() == "Public")
                {
                    strQry = "exec [usp_MessageMst] @type='UpdateNotification',@intGrpMember_Id='" + ViewState["MemId"].ToString() + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
               
                  }
                else
                {
                    strQry = "exec [usp_MessageMst] @type='UpdateNotification',@intGrpMember_Id='" + ViewState["OwnMemId"].ToString() + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
               
                }
                sExecuteQuery(strQry);
               
            }
            else
            {
                Response.Redirect("~\\index.aspx", false);
            }
        }
        catch 
        {
            
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //ImgBtnView.Attributes.Add("onclick", "window.open('frmViewGroupPeople.aspx','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=800,top=90,left=100');return false");
        try
        {

            ImgBtnView.Attributes.Add("onclick", "window.open('frmViewGroupPeople.aspx?intGroup_id=" + ViewState["GrpId"] + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=800,top=90,left=100');return false");
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
    protected void btnMsg_Click(object sender, EventArgs e)
    {
       // txtChat.Text.Replace(Environment.NewLine, "<br/>");
        //txtChat.Style["text-align"] = "right";
        //txtChat.Text = txtChat.Text + Environment.NewLine + "You: "+ Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy HH:MM") + Environment.NewLine + txtMsg.Text;

        checksession();

        if (txtMsg.Text != "")
        {
            dsObj = new DataSet();
            strQry = "";
          //  ViewState["PartnerUserId"]
           if(Convert.ToString(ViewState["Type"])=="Public")
           {
             strQry = "exec usp_MessageMst @type='Insert',@intGroupid='" + ViewState["GrpId"] + "',@intGrpMember_Id='" + ViewState["MemId"] + "',@intUser_SenderId='" + Convert.ToString(Session["User_Id"]) + "',@intInserted_by='" + Session["User_Id"] + "',@Inserted_IP='" + GetSystemIP() + "',@Message='" + Convert.ToString(txtMsg.Text.Trim()) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'"; //,@vchAttachment_path='" + Convert.ToString(ViewState["FileUpload"]) + "',',@intUser_ReceiveId=" + ViewState["PartnerUserId"].ToString() + "'
           }
           else if (Convert.ToString(ViewState["Type"]) == "Private")
           {
               strQry = "exec usp_MessageMst @type='Insert',@intGroupid='" + ViewState["GrpId"] + "',@intGrpMember_Id='" + ViewState["MemId"] + "',@intUser_SenderId='" + Convert.ToString(Session["User_Id"]) + "',@intInserted_by='" + Session["User_Id"] + "',@Inserted_IP='" + GetSystemIP() + "',@Message='" + Convert.ToString(txtMsg.Text.Trim()) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intGrpMem_Id_2='" + ViewState["OwnMemId"] + "'";//,@vchAttachment_path='" + Convert.ToString(ViewState["FileUpload"]) + "'
           }
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
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        txtMsg.Focus();
        Session["Text"] = txtMsg.Text;
        OpenChat();
    }
    protected void FileUploadApp_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        try
        {
           // ViewState["FileUpload"] = System.IO.Path.GetFullPath(AttachFile.PostedFile.FileName);
        }
        catch
        {
        }
    }
}
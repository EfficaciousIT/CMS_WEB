using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Data.SqlTypes;
using System.Web.UI.WebControls;

public partial class frmGroupMst : DBUtility
{
    string strQry = "";
    DataSet dsObj;

    protected void Page_Load(object sender, EventArgs e)
    {
       
             if (Session["UserType_id"] != null && Session["User_Id"] != null)
                {
                    Label lblTile = new Label();
                    lblTile = (Label)Page.Master.FindControl("lblPageTitle");
                    lblTile.Visible = true;
                    lblTile.Text = "Group Message Master";
                    if (!IsPostBack)
                    {
                    if (Convert.ToString(Session["UserType_id"]) == "1")
                    {
                        Session["User_Id"] = Session["Student_id"];
                    }
                    FillGrid();
                    }
                }
             else
             {
                 // Response.Redirect("~\\index.aspx", false);
                 Response.Redirect("~\\frmIndex.aspx", false);
             }
        
        
    }
    public void FillGrid()
    {
        try
        {
            grvGroup.DataSource = createDataTable();
            grvGroup.DataBind();

            if (Convert.ToString(Session["UserType_Id"]) != null)
            {
               
                    grvGroup.Columns[0].Visible = true;
                    grvGroup.Columns[1].Visible = true;
                    TabContainer1.Tabs[0].Visible = true;
                    TabContainer1.Tabs[1].Visible = true;
               
            }
            else
            {
                Response.Redirect("~\\frmIndex.aspx", false);
            }
        }
        catch 
        {

        }
    }
    private DataSet createDataTable()
    {
        try
        {
            strQry = "";
            if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                strQry = "exec usp_GroupMsg_Mst  @type='FillGrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            }
            else
            {
                strQry = "exec usp_GroupMsg_Mst  @type='FillGrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intGroupCreatedBy='" + Convert.ToString(Session["User_Id"]) + "',@intGroupCreatedByType='" + Convert.ToString(Session["UserType_Id"]) + "'";
            }
            dsObj = new DataSet();
            dsObj = sGetDataset(strQry);
            return dsObj;
        }
        catch
        {
            return dsObj; 
        }
    }
    protected void grvGroup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    LinkButton lnk = (LinkButton)e.Row.FindControl("lnkCount");

            
        //    lnk.Attributes.Add("onclick", "window.open('ReplayTracking.aspx','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=900,top=120,left=200');return false");
        //}
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
            //strQry = "";
            //strQry = "exec usp_GroupMsg_Mst @type='CheckExist' ,@vchGroup_name='" + Convert.ToString(txtGroupName.Text.Trim()) + "',@intGroup_id='" + Convert.ToString(btnSubmit.Text == "Submit" ? System.Data.SqlTypes.SqlBoolean.Null : Session["GroupId"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intGroupCreatedByType='" + Session["UserType_Id"] + "',@intGroupCreatedBy='" + Session["User_Id"] + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox("Entered Group Name Already Exist");
            //    txtGroupName.Focus();
            //    return;
            //}
            if(btnSubmit.Text=="Submit")
            {
               
                    strQry = "";
                    //strQry = "exec usp_GroupMsg_Mst @type='Insert',@vchGroup_name='" + Convert.ToString(txtGroupName.Text.Trim()) + "',@vchGroupType='Public',@intGroupCreatedBy='" + Session["User_Id"] + "',@intUser_id='" + Session["User_Id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intGroupCreatedByType='" + Session["UserType_Id"] + "'";
                    //if (sExecuteQuery(strQry) != -1)
                    //{
                        strQry = "exec [usp_GroupMemberMsg_Mst] @type='Insert',@vchGroup_name='" + Convert.ToString(txtGroupName.Text.Trim()) + "',@vchGroupType='Public',@intGroupCreatedBy='" + Session["User_Id"] + "',@intUser_id='" + Session["User_Id"] + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intGroupCreatedByType='" + Session["UserType_Id"] + "',@intUserType_id='" + Session["UserType_Id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";

                        if (sExecuteQuery(strQry) != -1)
                        {
                            MessageBox("Record Saved Successfully!");
                            Clear();
                        }
                   // }
                    else
                    {
                        MessageBox("Inertion Failed!");
                        return;
                    }
                
            }
            else if (btnSubmit.Text == "Update")
            {
                strQry = "";
                strQry = "exec usp_GroupMsg_Mst @type='Update',@intGroup_id='" + Session["GroupId"] + "',@vchGroup_name='" + Convert.ToString(txtGroupName.Text.Trim()) + "',@intUpdatedBy ='" + Session["User_Id"] + "',@vchUpdatdIp='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intGroupCreatedByType='" + Session["UserType_Id"] + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    Clear();
                }
                else
                {
                    MessageBox("Updation Failed!");
                    return;
                }
                btnSubmit.Text = "Submit";
                Clear();
            }
            FillGrid();
        }
        catch
        {
            
        }
    }

    public void Clear()
    {
        txtGroupName.Text = "";
        txtGroupName.Focus();
    }
    protected void grvGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "LinkCall")
            {
                string UnivID = e.CommandArgument.ToString();
                LinkButton lb = (LinkButton)e.CommandSource;

              //  Response.Redirect("frmViewGroupPeople.aspx?intGroup_id=" + UnivID);
                lb.Attributes.Add("onclick", "window.open('frmViewGroupPeople.aspx?intGroup_id=" + UnivID +"','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=800,top=90,left=100');return false");
            } 
        }
        catch 
        {
            
        }
    }
    protected void grvGroup_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int groupid = (int)grvGroup.DataKeys[e.NewEditIndex].Value;
            strQry = "";
            strQry = "exec usp_GroupMsg_Mst @type='SelectData',@intGroup_id='" + groupid + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            DataSet dsObj = new DataSet();
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtGroupName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGroup_name"]);
                Session["GroupId"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intGroup_id"]);
            }
            TabContainer1.ActiveTabIndex = 1;
            btnSubmit.Text = "Update";
           
        }
        catch
        {
            
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtGroupName.Text = "";
        btnSubmit.Text = "Submit";
        txtGroupName.Focus();
    }
    protected void grvGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvGroup.PageIndex = e.NewPageIndex;
        grvGroup.DataBind();

        FillGrid();
    }
    protected void grvGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int DeleteId = (int)grvGroup.DataKeys[e.RowIndex].Value;
            strQry = "exec [usp_GroupMsg_Mst] @type='Delete',@intGroup_id='" + Convert.ToString(DeleteId) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully");
                FillGrid();
            }
        }
        catch (Exception)
        {
            
        }
    }
}
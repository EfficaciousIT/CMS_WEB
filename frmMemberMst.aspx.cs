using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmMemberMst : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                Label lblTile = new Label();
                lblTile = (Label)Page.Master.FindControl("lblPageTitle");
                lblTile.Visible = true;
                lblTile.Text = "Group Member Master";
                if (!IsPostBack)
                {

                FillGroupName();
                FillUserType();
                geturl();
            }
            }
            else
            {
                Response.Redirect("~\\frmIndex.aspx", false);
            }
        
    }

    public void FillUserType()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_FillDropDown] @type='UserType',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlType, strQry, "vchUser_name", "intUserType_id");

            //if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            //{
                grvDetails.Columns[0].Visible = true;
                TabContainer1.Tabs[0].Visible = true;
                TabContainer1.Tabs[1].Visible = true;
            //}
            //else
            //{
            //    grvDetails.Columns[0].Visible = false;
            //    TabContainer1.Tabs[0].Visible = true;
            //    TabContainer1.Tabs[1].Visible = false;
            //}
        }
        catch 
        {
            
        }
    }

    public void FillGroupName()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                strQry = "exec usp_FillDropDown @type='GroupMsgName',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";//',@intGroupCreatedByType='" + Convert.ToString(Session["UserType_Id"]) + "',@intGroupCreatedBy='" + Convert.ToString(Session["User_Id"]) + "'";
            }
            else
            {
                strQry = "exec usp_FillDropDown @type='GroupMsgName',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intGroupCreatedByType='" + Convert.ToString(Session["UserType_Id"]) + "',@intGroupCreatedBy='" + Convert.ToString(Session["User_Id"]) + "'";
            }
            sBindDropDownList(ddlGroupNm, strQry, "vchGroup_name", "intGroup_id");
            sBindDropDownList(ddlGrp, strQry, "vchGroup_name", "intGroup_id");
            //ddlDept.Items.Add(new ListItem("All", "-1"));
           // ddlDept.Items.Add(new ListItem("Select", "0"));
            
        }
        catch
        {

        }
    }
    public void FillGrid()
    {
        try
        {
            grvDetails.DataSource = createDataTable();
            grvDetails.DataBind();

          
        }
        catch 
        {
            
        }
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlType.Text == "1" || ddlType.Text == "2")
            {
                ddlStd.Visible = true;
                ddlDiv.Visible = false;
                lblSTD.Visible = true;
                lblDIv.Visible = false;
                ddlDept.Visible = false;
                lbldept.Visible = false;
                ddlName.Visible = false;
                lblName.Visible = false;
                lblName.Text = "Student Name";
                FillSTD();
            }
            else if (ddlType.Text == "3")
            {
                ddlStd.Visible = false;
                ddlDiv.Visible = false;
                lblSTD.Visible = false;
                lblDIv.Visible = false;
                ddlDept.Visible = true;
                lbldept.Visible = true;
                ddlName.Visible = false;
                lblName.Visible = false;
                lblName.Text = "Teacher Name";
                FillDept();
                FillTeacher();
            }
            else if (ddlType.Text == "4")
            {
                ddlStd.Visible = false;
                ddlDiv.Visible = false;
                lblSTD.Visible = false;
                lblDIv.Visible = false;
                ddlDept.Visible = true;
                lbldept.Visible = true;
                ddlName.Visible = false;
                lblName.Visible = false;
                lblName.Text = "Staff Name";
                FillDept();
                FillTeacher();
            }
            else
            {
                ddlStd.Visible = false;
                ddlDiv.Visible = false;
                lblSTD.Visible = false;
                lblDIv.Visible = false;
                ddlDept.Visible = false;
                lbldept.Visible = false;
                ddlName.Visible = false;
                lblName.Visible = false;
                
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
            if (Convert.ToString(Session["UserType_Id"]) == "1" || Convert.ToString(Session["UserType_Id"]) == "2")
            {
                strQry = "exec [usp_FillDropDownForGroupMsg] @type='FillSTD_Student',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intStudent_id='" + Convert.ToString(Session["User_Id"]) + "'";
                sBindDropDownList(ddlStd, strQry, "vchStandard_name", "intstandard_id");
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "3")
            {
                strQry = "exec [usp_FillDropDownForGroupMsg] @type='FillSTD_Staff',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intUserId='" + Convert.ToString(Session["User_Id"]) + "'";
                sBindDropDownList(ddlStd, strQry, "vchStandard_name", "intstandard_id");
            }
            else
            {
                strQry = "exec [usp_FillDropDown] @type='STD',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
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

                strQry = "exec [usp_FillDropDownForGroupMsg] @type='FillDIV_Student',@STD='" + Convert.ToString(ddlStd.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intStudent_id='" + Convert.ToString(Session["User_id"]) + "'";
                sBindDropDownList(ddlDiv, strQry, "vchDivisionName", "intDivision_id");
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "3")
            {
                strQry = "exec [usp_FillDropDownForGroupMsg] @type='FillDIV_Staff',@STD='" + Convert.ToString(ddlStd.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intUserId='" + Convert.ToString(Session["User_id"]) + "'";
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
    public void FillDept()
    {
        try
        {

            strQry = "exec usp_FillDropDown @type='TrainingDepartment',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUserType='" + Convert.ToString(ddlType.SelectedValue) + "'";
            sBindDropDownList(ddlDept, strQry, "vchDepartment_name", "intDepartment");
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
            strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDiv.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlName, strQry, "Name", "intStudent_id");
           // ddlName.Items.Add(new ListItem("All", "-1"));
        }
        catch 
        {
            
        }
    }
    public void FillTeacher()
    {
        try
        {
            strQry = "exec usp_FillDropDown @type='GetStaff',@intDept_id='" + Convert.ToString(ddlDept.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUserType='" + Convert.ToString(ddlType.SelectedValue) + "'";
            sBindDropDownList(ddlName, strQry, "Name", "intTeacher_id");
            //ddlName.Items.Add(new ListItem("All", "-1"));
        }
        catch
        {

        }
    }
    public DataSet createDataTable()
    {
        try
        {
            strQry = "exec [usp_GroupMemberMsg_Mst]  @type='FillGrid',@intGroup_id='" + Convert.ToString(ddlGrp.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
           
            dsObj = sGetDataset(strQry);
            return dsObj;
        }
        catch (Exception)
        {

            return dsObj;
        }
       
    }

    protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlType.SelectedValue == "1")
            {
                ddlParentNm.Visible = false;
                lblParentNm.Visible = false;
                
            }
            else if (ddlType.SelectedValue == "3")
            {

                ddlParentNm.Visible = false;
                lblParentNm.Visible = false;
            }
            else if (ddlType.SelectedValue == "2")
            {

                ddlParentNm.Visible = true;
                lblParentNm.Visible = true;
                strQry = "exec [usp_FillDropDown] @type='SelectParent',@intDiv_id='" + Convert.ToString(ddlDiv.SelectedValue) + "',@parameter='" + Convert.ToString(ddlName.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                sBindDropDownList(ddlParentNm, strQry, "ParentNm", "intParentID");
                ddlParentNm.SelectedIndex = 1;
                ddlParentNm.Enabled = false;
            }
            if (ddlName.Visible == true && ddlName.SelectedValue != "0")
            {
                btnSubmit.Visible = true;
                btnCancel.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
                btnCancel.Visible = false;
            }
        }
        catch 
        {
            
        }
    }
    protected void ddlDiv_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDiv.SelectedValue != "0")
        {
            FillStudent();
            ddlName.Visible = true;
            lblName.Visible = true;
            lblName.Text = "Student Name";
        }
        else
        {
            ddlName.Visible = false;
            lblName.Visible = false;
        }
    }
    protected void ddlStd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStd.SelectedValue != "0")
        {
            FillDIV();
            ddlDiv.Visible = true;
            lblDIv.Visible = true;
            ddlName.Visible = false;
            lblName.Visible = false;
        }
        else
        {

            ddlDiv.Visible = false;
            lblDIv.Visible = false;
        }
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDept.SelectedValue != "0")
        {
            FillTeacher();
            ddlName.Visible = true;
            lblName.Visible = true;
            lblName.Text = "Staff Name";
        }
        else
        {
            ddlName.Visible = false;
            ddlName.Visible = false;
            
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
            checksession();
            strQry = "";
            strQry = "exec [usp_GroupMemberMsg_Mst]  @type='CheckExist',@intUserType_id='" + Convert.ToString(ddlType.SelectedValue) + "',@intGroup_id='" + Convert.ToString(ddlGroupNm.SelectedValue) + "',@intUser_id='" + Convert.ToString(ddlName.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Selected Member has been Added Already!");
                return;
            }
            strQry = "";
            strQry = "exec usp_GroupMemberMsg_Mst @type='InsertMember',@intGroup_id='" + Convert.ToString(ddlGroupNm.SelectedValue) + "',@intUser_id='" + Convert.ToString(ddlType.SelectedValue == "1" ? "0" :  ddlType.SelectedValue=="2" ? ddlParentNm.SelectedValue : ddlName.SelectedValue) + "',@intUserType_id='" + Convert.ToString(ddlType.SelectedValue) + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + Convert.ToString(GetSystemIP()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intStudent_id='" + Convert.ToString(ddlType.SelectedValue == "1" || ddlType.SelectedValue == "2" ? ddlName.SelectedValue : "0") + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Saved Successfully");
                ddlName.SelectedValue = "0";
                ddlParentNm.SelectedValue = "0";
                FillGrid();
            }
        } 
        catch
        {
            
        }
    }
    protected void ddlGrp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillGrid();
        }
        catch 
        {
            
        }
    }
    protected void grvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int MemberId = (int)grvDetails.DataKeys[e.RowIndex].Value;
            strQry = "";
            strQry = "exec [usp_GroupMemberMsg_Mst] @type='Delete',@intGroup_id='" + Convert.ToString(MemberId) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@vchDeletedIp='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully!");
                FillGrid();
            }

        }
        catch 
        {
            
        }
    }
}
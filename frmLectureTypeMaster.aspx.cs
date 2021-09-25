using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmLectureTypeMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {

                    FillGrid();
                    geturl();
                }
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtLectureType.Text == "")
        {
            MessageBox("Please Insert Lecture Type!");
            txtLectureType.Focus();
            return;
        }
        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                strQry = "";
                strQry = "exec usp_LectureType  @type='CheckSaveExist',@vcLecture_type='" + Convert.ToString(txtLectureType.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_LectureType  @type='Insert',@vcLecture_type='" + Convert.ToString(txtLectureType.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInerted_by='" + Session["User_id"] + "',@InsertIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully!");
                    txtLectureType.Text = "";
                    FillGrid();
                }
            }
            else
            {
                strQry = "";
                strQry = "exec usp_LectureType  @type='CheckUpdateExist',@intLecture_type='" + ViewState["Lecture_typeId"] + "',@vcLecture_type='" + Convert.ToString(txtLectureType.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_LectureType  @type='Update',@intLecture_type='" + ViewState["Lecture_typeId"] + "',@vcLecture_type='" + Convert.ToString(txtLectureType.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intUpdate_by='" + Session["User_id"] + "',@updateIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    txtLectureType.Text = "";
                    btnSubmit.Text = "Submit";
                    FillGrid();
                }
            }
        }
        catch
        {

        }
    }
    public void FillGrid()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_LectureType @type='FillGrid',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        catch
        {

        }
    }
    //public void MessageBox(string msg)
    //{
    //    try
    //    {
    //        string script = "alert(\"" + msg + "\");";
    //        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
    //    }
    //    catch (Exception)
    //    {
    //        // return msg;
    //    }
    //}
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)grvDetail.DataKeys[e.RowIndex].Value;
            ViewState["Lecture_typeId"] = id;
            strQry = "exec usp_LectureType @type='Delete',@intLecture_type='" + Convert.ToString(id) + "',@intDeleteBy='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully");
                FillGrid();
            }
        }
        catch
        {

        } 
    }
    protected void grvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvDetail.PageIndex = e.NewPageIndex;
            grvDetail.DataBind();
        }
        catch
        {

        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            strQry = "";
            int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            ViewState["Lecture_typeId"] = id;
            strQry = "exec usp_LectureType  @type='FillGrid',@intLecture_type='" + Convert.ToString(id) + "',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtLectureType.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vcLecture_type"]);
                TBC.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtLectureType.Text = "";
    }
}
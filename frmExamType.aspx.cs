using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frmExamType : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strMax_id = string.Empty;
    string strID = string.Empty;
    int k = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //fillSubjects();
            //FillExam();
            fillGrid();
            FillSTD();
            ViewState["Edit"] = "No";
        }        
    }
    protected void fillSubjects()
    {        
        strQry = "";
        strQry = "exec usp_ExamType @command='subject',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
        sBindCheckBoxList(chkSTD, strQry, "vchsubjectname", "intsubject_id");
    }
    public void FillExam()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ExamType @command='Exam',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpExam, strQry, "vchExamination_name", "intExam_id");

        }
        catch
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int i = 0;
        //strQry = "exec usp_ExamType @command='InsertMaster',@ExamTypeName='" + txtExamType.Text.Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intExam_id='" + drpExam.SelectedValue.Trim() + "',@Maxmarks='" + txtExamMax.Text.Trim() + "'";
        
        //i = sExecuteQuery(strQry);
        //if (i > 0)
        //{
        //    strQry = "exec usp_ExamType @command='selectMax',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
        //    dsObj = sGetDataset(strQry);
        //    if (dsObj.Tables[0].Rows.Count > 0)
        //    {
        //        strMax_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intExamType_id"]);

        //        for (int j = 0; j < chkSTD.Items.Count; j++)
        //        {
        //            if (chkSTD.Items[j].Selected == true)
        //            {
        //                strQry = "exec usp_ExamType @command='InsertTrn',@intExamType_id='" + strMax_id.Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intExam_id='" + drpExam.SelectedValue.Trim() + "',@intSubject_id='" + Convert.ToString(chkSTD.Items[j].Value) + "'";
        //                i = sExecuteQuery(strQry);
        //            }
        //        }

                

        //    }
        //}
        if (Convert.ToString(ViewState["Edit"]) == "Yes")
        {
            strQry = "usp_ExamTypeNew  @command='CheckUpdateExist',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@ExamTypeName='" + txtExamType.Text.Trim() + "',@intExamType_id='" + Convert.ToString(ViewState["strID"]) + "',@intStandard_id='"+ddlSTD1.SelectedValue+"'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exist!");
                return;
            }
            else
            {
                strQry = "exec usp_ExamTypeNew @command='Update',@ExamTypeName='" + txtExamType.Text.Trim() + "',@intExamType_id='" + Convert.ToString(ViewState["strID"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdateIP='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='"+ddlSTD1.SelectedValue+"'";

                i = sExecuteQuery(strQry);
                if (i > 0)
                {
                    fillGrid();
                    txtExamType.Text = "";
                    ViewState["Edit"] = "No";
                    MessageBox("Exam Type Updated Successfully");
                }
            }
        }
        else
        {
            strQry = "usp_ExamTypeNew  @command='CheckExamExist',@ExamTypeName='" + txtExamType.Text.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + ddlSTD1.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exist!");
                return;
            }
            else
            {
                strQry = "exec usp_ExamTypeNew @command='InsertMaster',@ExamTypeName='" + txtExamType.Text.Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInsertby='" + Convert.ToString(Session["User_id"]) + "',@insertip='" + GetSystemIP() + "',@intStandard_id='"+ddlSTD1.SelectedValue+"'";

                i = sExecuteQuery(strQry);
                if (i > 0)
                {
                    fillGrid();
                    txtExamType.Text = "";
                    ViewState["Edit"] = "No";
                    MessageBox("Exam Type Addedd Successfully");
                }
            }
        }

    }

    public void FillSTD()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "3")
            {
                strQry = "exec [usp_getAttendance] @type='FillStd',@TeacherId='" + Convert.ToString(Session["User_id"]) + "',@intSchool_id='" + Session["School_id"] + "'";
                
                sBindDropDownList(ddlSTD1, strQry, "vchStandard_name", "intstandard_id");
              
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
                
                sBindDropDownList(ddlSTD1, strQry, "vchStandard_name", "intstandard_id");
                
            }
            else
            {
                strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD1, strQry, "vchStandard_name", "intstandard_id");
            }

        }
        catch
        {

        }
    }

    protected void fillGrid()
    {
        strQry = "usp_ExamTypeNew @command='select',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            TabContainer1.ActiveTabIndex = 0;
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
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

    protected void btnClear_Click(object sender, EventArgs e)
    {

    }

    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        strID = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);

        ViewState["strID"] = strID;

        strQry = "exec usp_ExamTypeNew @command='Edit',@intExamType_id='" + strID.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";        
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            ViewState["Edit"] = "Yes";
            TabContainer1.ActiveTabIndex = 1;
            txtExamType.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["ExamTypeName"]);
            btnSubmit.Text = "Update";

        }
    }

    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        strID = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);

        strQry = "usp_ExamTypeNew @command='Delete',@intExamType_id='" + Convert.ToString(strID) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intDeleteBy='" + Session["User_id"] + "',@deleteIP='" + GetSystemIP() + "'";

        k = sExecuteQuery(strQry);
        if (k > 0)
        {
            fillGrid();
            MessageBox("Exam Type Deleted Successfully");
        }
    }

    protected void grvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
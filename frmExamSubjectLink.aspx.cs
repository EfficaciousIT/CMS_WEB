using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmExamSubjectLink : DBUtility
{
    string strQry = "";
    DataSet dsObj=new DataSet();
    string strID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillExamType();
            fillStandard();
            fillExamTypenew();
            ViewState["Edit"] = "No";
            TabContainer1.ActiveTabIndex = 0;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(ViewState["Edit"]) == "Yes")
        {
            strQry = "exec usp_ExamSubjectLink @command='Update',@intExam_id='" + drpExam.SelectedValue.Trim() + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intSubject_id='" + drpSubject.SelectedValue.Trim() + "',@intMaxMarks='" + txtTotalMarks.Text.Trim() + "',@intExamType_id='" + drpExamType.SelectedValue.Trim() + "',@intMarks='" + txtExamMax.Text.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intID='" + Convert.ToString(ViewState["strID"]) + "'";
            int i = sExecuteQuery(strQry);
            if (i > 0)
            {
                TabContainer1.ActiveTabIndex = 0;
                fillGrid(drpStdSelect.SelectedValue, drpExamSelect.SelectedValue);
                MessageBox("Details Updated successfully");
            }
        }
        else
        {
            strQry = "exec usp_ExamSubjectLink @command='Insert',@intExam_id='" + drpExam.SelectedValue.Trim() + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intSubject_id='" + drpSubject.SelectedValue.Trim() + "',@intMaxMarks='" + txtTotalMarks.Text.Trim() + "',@intExamType_id='" + drpExamType.SelectedValue.Trim() + "',@intMarks='" + txtExamMax.Text.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
            int i = sExecuteQuery(strQry);
            if (i > 0)
            {
                MessageBox("Details Configure successfully");
            }
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
    protected void fillExamType()
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
    protected void fillExamTypenew()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ExamSubjectLink @command='ExamType',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpExamType, strQry, "ExamTypeName", "intExamType_id");

        }
        catch
        {

        }
    }
    protected void fillStandard()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ExamSubjectLink @command='standard',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpStandard, strQry, "vchstandard_name", "intstandard_id");
            sBindDropDownList(drpStdSelect, strQry, "vchstandard_name", "intstandard_id");

        }
        catch
        {

        }
    }
    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ExamSubjectLink @command='Subject',@intstandard_id='" + drpStandard.SelectedValue + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpSubject, strQry, "vchsubjectname", "intsubject_id");

        }
        catch
        {

        }
    }
    protected void grvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //TabContainer1.[1] = true;
        strID = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);

        ViewState["strID"] = strID;

        strQry = "exec usp_ExamSubjectLink @command='Edit',@intID='" + strID.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            ViewState["Edit"] = "Yes";
            TabContainer1.ActiveTabIndex = 1;
            drpExam.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intExam_id"]);
            drpStandard.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
            drpExamType.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intExamType_id"]);

            strQry = "exec usp_ExamSubjectLink @command='Subject',@intstandard_id='" + drpStandard.SelectedValue + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpSubject, strQry, "vchsubjectname", "intsubject_id");

            drpSubject.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intSubject_id"]);
            txtTotalMarks.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intMaxMarks"]);
            txtExamMax.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intMarks"]);

        }

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {

    }
    protected void drpSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void drpSubject_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ExamSubjectLink @command='MaxMarks',@intschool_id='" + Convert.ToString(Session["School_Id"]) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue) + "',@intSubject_id='" + Convert.ToString(drpSubject.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtTotalMarks.Text = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
                strQry = "";
                strQry = "exec usp_ExamSubjectLink @command='SUmOfMarks',@intschool_id='" + Convert.ToString(Session["School_Id"]) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue) + "',@intSubject_id='" + Convert.ToString(drpSubject.SelectedValue) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    txtExamMax.Text = Convert.ToString(Convert.ToInt32(txtTotalMarks.Text) - Convert.ToInt32(Convert.ToString(dsObj.Tables[0].Rows[0][0])));
                }


            }
            else
            {
                txtTotalMarks.Text = Convert.ToString("");
            }
        }
        catch
        {

        }
    }
    protected void drpStdSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ExamSubjectLink @command='ExamSelect',@intstandard_id='" + drpStdSelect.SelectedValue + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpExamSelect, strQry, "vchexamination_name", "intexam_id");

        }
        catch
        {

        }
    }
    protected void drpExamSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillGrid(drpStdSelect.SelectedValue, drpExamSelect.SelectedValue);
    }
    protected void fillGrid(string strStandard, string strExamType)
    {
        strQry = "exec usp_ExamSubjectLink @command='Grid',@intStandard_id='" + Convert.ToString(strStandard.Trim()) + "',@intExam_id='" + Convert.ToString(strExamType.Trim()) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["ID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_ExamSubjectLink ] @command='delete',@intID='" + Convert.ToString(Session["ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fillGrid(drpStdSelect.SelectedValue, drpExamSelect.SelectedValue);
                MessageBox("Criteria Deleted Successfully!");
            }
        }
        catch
        {

        }
    }
}
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class frmExamMaster : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    int k = 0;
    string strFeeID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            standard();
            ddlSTD_SelectedIndexChanged(null, null);
            ViewState["Edit"] = "No";
        }
    }
    public void standard()
    {
        try
        {
             strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
             sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
             sBindDropDownList(drpSTD, strQry, "vchStandard_name", "intstandard_id");

             FillExaminationType();
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        //ViewState["ddlSTD"] = Convert.ToString(ddlSTD.SelectedValue);
        //FillExaminationType();
        strQry = "exec usp_ExamMarks @type='FillExaminationType',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + ddlSTD.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        sBindDropDownList(ddlExamType, strQry, "ExamTypeName", "intExamType_id");
        
    }

    public void FillExaminationType()
    {
        strQry = "exec usp_ExamMarks @type='FillExaminationType1',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        sBindDropDownList(ddlExamType, strQry, "ExamTypeName", "intExamType_id");

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(ViewState["Edit"]) == "Yes")
        {
            strQry = "usp_ExamMaster  @command='CheckUpdateExist',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + Convert.ToInt32(ddlSTD.SelectedValue.Trim()) + "',@intExam_id='" + Convert.ToString(ViewState["strFeeID"]) + "',@vchExamination_name='" + txtExam.Text.Trim() + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exist!");
                return;
            }
            else
            {
                strQry = "usp_ExamMaster  @command='Update',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + Convert.ToInt32(ddlSTD.SelectedValue.Trim()) + "',@intExam_id='" + Convert.ToString(ViewState["strFeeID"]) + "',@vchExamination_name='" + txtExam.Text.Trim() + "',@intMinMark='" + txtPassing.Text.Trim() + "',@intMaxMark='" + txtMax.Text.Trim() + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdateIP='" + GetSystemIP() + "',@intExamType_id ='"+ddlExamType.SelectedValue+"'";
                k = sExecuteQuery(strQry);
                if (k > 0)
                {
                    fillGrid();
                    MessageBox("Record Updated Successfully");
                    txtExam.Text = "";
                    txtMax.Text = "";
                    txtPassing.Text = "";
                    btnUpdate.Text = "Sumbit";
                    ViewState["Edit"] = "No";
                }
            }
        }
        else
        {
            strQry = "usp_ExamMaster  @command='CheckExist',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + Convert.ToInt32(ddlSTD.SelectedValue.Trim()) + "',@vchExamination_name='" + txtExam.Text.Trim() + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exist!");
                return;
            }
            else
            {
                strQry = "usp_ExamMaster  @command='Insert',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + Convert.ToInt32(ddlSTD.SelectedValue.Trim()) + "',@intInsertby='" + Convert.ToString(Session["User_id"]) + "',@vchExamination_name='" + txtExam.Text.Trim() + "',@intMinMark='" + txtPassing.Text.Trim() + "',@intMaxMark='" + txtMax.Text.Trim() + "',@insertip='" + GetSystemIP() + "',@intExamType_id='"+ddlExamType.SelectedValue+"'";
                k = sExecuteQuery(strQry);
                if (k > 0)
                {
                    fillGrid();
                    MessageBox("Record Addedd Successfully");
                    txtExam.Text = "";
                    txtMax.Text = "";
                    txtPassing.Text = "";
                    btnUpdate.Text = "Sumbit";
                    ViewState["Edit"] = "No";
                }

            }
        }

        
    }
    protected void fillGrid()
    {
        strQry = "usp_ExamMaster  @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + Convert.ToInt32(drpSTD.SelectedValue.Trim()) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            TabContainer1.ActiveTabIndex = 0;
            grdExam.DataSource = dsObj;
            grdExam.DataBind();
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
            
        }
    }
    protected void grdExam_RowEditing(object sender, GridViewEditEventArgs e)
    {
        strFeeID = Convert.ToString(grdExam.DataKeys[e.NewEditIndex].Value);

        ViewState["strFeeID"] = strFeeID;
        FillExaminationType();
        strQry = "usp_ExamMaster  @command='edit',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intExam_id='" + strFeeID.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            ViewState["Edit"] = "Yes";
            TabContainer1.ActiveTabIndex = 1;
            ddlSTD.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
            ddlExamType.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intExamType_id"]);
            txtExam.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchExamination_name"]);
            txtPassing.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intMinMark"]);
            txtMax.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intMaxMark"]);
            btnUpdate.Text = "Update";
        }
    }
    protected void grdExam_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        strFeeID = Convert.ToString(grdExam.DataKeys[e.RowIndex].Value);

        strQry = "usp_ExamMaster  @command='Delete',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intExam_id='" + Convert.ToString(strFeeID.Trim()) + "',@intDeleteBy='" + Session["User_id"] + "',@deleteIP='" + GetSystemIP() + "'";
        k = sExecuteQuery(strQry);
        if (k > 0)
        {
            fillGrid();
            MessageBox("Record Deleted Successfully");            
        }
    }

    protected void drpSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillGrid();
    }
}

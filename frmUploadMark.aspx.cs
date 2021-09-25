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


public partial class frmUploadMark : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillStandard();
            FillCategory();
            fGrid();
        }  
    }
    protected void fGrid()
    {
        strQry = "spMarksUpload @command='gridSelect',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
    }
    protected void FillStandard()
    {
        strQry = "usp_TestSchedule @command='selectStandard',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(drpStandard, strQry, "vchStandard_name", "intStandard_id");
    }
    protected void FillCategory()
    {
        strQry = "usp_TestSchedule @command='selectCategory',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(drpCategory, strQry, "vchCategory", "intCat_Id");
        sBindDropDownList(ddlCAT, strQry, "vchCategory", "intCat_Id");
    }
    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "spMarksUpload @command='getStudent',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(drpStudent, strQry, "candiateName", "intTest_id");      
    }
   
    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
        if (drpStandard.SelectedValue == "0")
        {
            MessageBox("Please Select Standard!");
            drpStandard.Focus();
            return;
        }
        if (drpStudent.SelectedValue == "0")
        {
            MessageBox("Please Select Student!");
            drpStudent.Focus();
            return;
        }
        if (txtMarks1.Text == "")
        {
            MessageBox("Please Enter Obtained Marks!");
            txtMarks1.Focus();
            return;
        }
        if (txtTotalMarks.Text == "")
        {
            MessageBox("Please Enter Out of Marks!");
            txtTotalMarks.Focus();
            return;
        }
        if (drpCategory.SelectedValue == "0")
        {
            MessageBox("Please Select Category!");
            drpCategory.Focus();
            return;
        }
        int k = 0;

        strQry = "spMarksUpload @command='updateStudent',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intTest_id='" + drpStudent.SelectedValue.Trim() + "',@marks1='" + txtMarks1.Text.Trim() + "',@TotalMarks='" + txtTotalMarks.Text.Trim() + "',@castType='" + drpCategory.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            k = sExecuteQuery(strQry);
   
        if (k > 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Makrs Uploaded Successfully');window.location ='frmUploadMark.aspx';", true);
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
    protected void ddlCAT_SelectedIndexChanged(object sender, EventArgs e)
    {
        fDDLGrid();
    }
  
    protected void fDDLGrid()
    {
        strQry = "spMarksUpload @command='gridDDLSelect',@castType='" + ddlCAT.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
    }
    protected void ddlQualified_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlQualified.SelectedValue == "1")
        {
            strQry = "spMarksUpload @command='gridDDLQualified',@castType='" + ddlCAT.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
        }
        //else if (ddlQualified.SelectedValue == "1")
        //{
        //    strQry = "spMarksUpload @command='gridDDLDisQualified',@castType='" + ddlCAT.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        //    dsObj = sGetDataset(strQry);
        //    if (dsObj.Tables[0].Rows.Count > 0)
        //    {
        //        grvDetail.DataSource = dsObj;
        //        grvDetail.DataBind();
        //    }
        //    else
        //    {
        //        grvDetail.DataSource = dsObj;
        //        grvDetail.DataBind();
        //    }
        //}
        else
        {
            fGrid();
        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["ID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec [spMarksUpload] @command='selectedQualifiedCandidate',@intTest_id='" + Convert.ToString(Session["ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Candidate Selected Successfully!');window.location ='frmUploadMark.aspx';", true);
                fGrid();
            }
        }
        catch
        {

        }
    }
}
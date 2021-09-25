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

public partial class HostelStudentMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    DataSet dsObjNew = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillAcademicYear();
            fGridafill();          
        }
    }
    public void fillAcademicYear()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_HostelStudentMaster @command='fillAcademicYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpFinYear, strQry, "AcademicYear", "intAcademic_id");           
        }
        catch
        {

        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["HostelSId"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec [usp_HostelStudentMaster] @command='edit',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@HostelSId='" + Convert.ToString(Session["HostelSId"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObjNew = sGetDataset(strQry);
            if (dsObjNew.Tables[0].Rows.Count > 0)
            {
                txtStudentName.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchStudentName"]);               
                drpFinYear.SelectedValue = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchFinYear"]);
                txtStandard.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchStandard"]);
                txtDivision.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchDivision"]);
                txtMobile.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchMobile"]);
                drpGender.SelectedValue = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchGender"]);
                txtAddress.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchAddress"]);
                txtMessage.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchMessage"]);
            
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string StrStu_id = "";
        StrStu_id = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
        strQry = "exec [usp_HostelStudentMaster] @command='delete',@HostelSId='" + StrStu_id.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        if (sExecuteQuery(strQry) != -1)
        {            
            MessageBox("Record deleted Successfully!");
            fGridafill();

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        strQry = "";

        if (btnSubmit.Text == "Submit")
        {
            strQry = "exec [usp_HostelStudentMaster] @command='checkExists',@vchStudentName='" + Convert.ToString(txtStudentName.Text.Trim()) + "',@vchStandard='" + txtStandard.Text.Trim() + "',@vchDivision='" + txtDivision.Text.Trim() + "',@vchFinYear='" + drpFinYear.SelectedValue + "',@vchMobile='" + txtMobile.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchGender='" + drpGender.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                fGridafill();
                MessageBox("Record Exist Already");
                return;
            }
            else
            {
                strQry = "exec [usp_HostelStudentMaster] @command='insert',@vchStudentName='" + txtStudentName.Text.Trim() + "',@vchStandard='" + txtStandard.Text.Trim() + "',@vchDivision='" + txtDivision.Text.Trim() + "',@vchFinYear='" + drpFinYear.SelectedValue + "',@vchMobile='" + txtMobile.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchGender='" + drpGender.SelectedValue.Trim() + "',@vchMessage='" + txtMessage.Text.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGridafill();
                    MessageBox("Record Saved Successfully!");
                    clear();
                }
            }
        }
        else
        {
            strQry = "exec [usp_HostelStudentMaster] @command='checkExists',@vchStudentName='" + Convert.ToString(txtStudentName.Text.Trim()) + "',@vchStandard='" + txtStandard.Text.Trim() + "',@vchDivision='" + txtDivision.Text.Trim() + "',@vchFinYear='" + drpFinYear.SelectedValue + "',@vchMobile='" + txtMobile.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchGender='" + drpGender.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Exist Already");
                return;
            }
            else
            {
                strQry = "exec [usp_HostelStudentMaster] @command='update',@vchStudentName='" + txtStudentName.Text.Trim() + "',@vchStandard='" + txtStandard.Text.Trim() + "',@vchDivision='" + txtDivision.Text.Trim() + "',@vchFinYear='" + drpFinYear.SelectedValue + "',@vchMobile='" + txtMobile.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchGender='" + drpGender.SelectedValue.Trim() + "',@vchMessage='" + txtMessage.Text.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@HostelSId='" + Convert.ToString(Session["HostelSId"]) + "',@IntUpdate_by='" + Session["User_id"] + "',@UpdateIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGridafill();
                    MessageBox("Record Updated Successfully!");
                    clear();
                }
            }
        }
    }
    public void clear()
    {
        try
        {
            txtStudentName.Text = "";
            drpFinYear.ClearSelection();
            txtStandard.Text="";
            txtDivision.Text="";
            txtMobile.Text = "";
            drpGender.ClearSelection();
            txtAddress.Text = "";
            txtMessage.Text = "";           
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
    protected void fGridafill()
    {
        strQry = "usp_HostelStudentMaster @command='gridselect',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            //txtStudentName.Text = "";
        }
    }  
}
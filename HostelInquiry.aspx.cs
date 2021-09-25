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


public partial class HostelInquiry : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    DataSet dsObjNew = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fGridafill();
            fillAcademicYear();
        }
    }
    public void fillAcademicYear()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_HostelInquiry @command='fillAcademicYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
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
            Session["HostelinquiryId"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec [usp_HostelInquiry] @command='edit',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@HostelinquiryId='" + Convert.ToString(Session["HostelinquiryId"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObjNew = sGetDataset(strQry);
            if (dsObjNew.Tables[0].Rows.Count > 0)
            {
                drpHostelType.SelectedItem.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchHostelType"]);
                drpRoomType.SelectedItem.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchRoomType"]);
                txtName.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchStudentName"]);
                drpFinYear.SelectedValue = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchFinYear"]);
                txtStandard.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchStandard"]);
                txtDivision.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchDivision"]);
                txtMobile.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchMobile"]);
                drpGender.SelectedItem.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchGender"]);
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
        strQry = "exec [usp_HostelInquiry] @command='delete',@HostelinquiryId='" + StrStu_id.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        if (sExecuteQuery(strQry) != -1)
        {
           
            MessageBox("Record deleted Successfully!");
            fGridafill();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (drpHostelType.SelectedValue == "0")
        {
            MessageBox("Please Select HostelType!");
            drpHostelType.Focus();
            return;
        }
        if (drpRoomType.SelectedValue == "0")
        {
            MessageBox("Please Select Room Type!");
            drpRoomType.Focus();
            return;
        }
        if (txtName.Text == "")
        {
            MessageBox("Please Enter Name!");
            txtName.Focus();
            return;
        }
        if (drpFinYear.SelectedValue == "0")
        {
            MessageBox("Please Select Financial Year!");
            drpFinYear.Focus();
            return;
        }
        if (txtStandard.Text == "")
        {
            MessageBox("Please Enter Standard!");
            txtStandard.Focus();
            return;
        }
        if (txtDivision.Text == "")
        {
            MessageBox("Please Enter Division!");
            txtDivision.Focus();
            return;
        }
        if (txtMobile.Text == "")
        {
            MessageBox("Please Enter Mobile!");
            txtMobile.Focus();
            return;
        }
        if (drpGender.SelectedValue == "0")
        {
            MessageBox("Please Select Gender!");
            drpGender.Focus();
            return;
        }
        if (txtAddress.Text == "")
        {
            MessageBox("Please Enter Address!");
            txtAddress.Focus();
            return;
        }
        strQry = "";

        if (btnSubmit.Text == "Submit")
        {
            strQry = "exec [usp_HostelInquiry] @command='checkExists',@vchHostelType='" + drpHostelType.SelectedItem.Text + "',@vchRoomType='" + drpRoomType.SelectedItem.Text + "',@vchStudentName='" + Convert.ToString(txtName.Text.Trim()) + "',@vchStandard='" + txtStandard.Text.Trim() + "',@vchDivision='" + txtDivision.Text.Trim() + "',@vchFinYear='" + drpFinYear.SelectedValue.Trim() + "',@vchMobile='" + txtMobile.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchGender='" + drpGender.SelectedItem.Text + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                fGridafill();
                MessageBox("Record Exist Already");
                return;
            }
            else
            {
                strQry = "exec [usp_HostelInquiry] @command='insert',@vchHostelType='" + drpHostelType.SelectedItem.Text + "',@vchRoomType='" + drpRoomType.SelectedItem.Text + "',@vchStudentName='" + txtName.Text.Trim() + "',@vchStandard='" + txtStandard.Text.Trim() + "',@vchDivision='" + txtDivision.Text.Trim() + "',@vchFinYear='" + drpFinYear.SelectedValue.Trim() + "',@vchMobile='" + txtMobile.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchGender='" + drpGender.SelectedItem.Text + "',@vchMessage='" + txtMessage.Text.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
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
            strQry = "exec [usp_HostelInquiry] @command='checkExists',@vchHostelType='" + drpHostelType.SelectedItem.Text + "',@vchRoomType='" + drpRoomType.SelectedItem.Text + "',@vchStudentName='" + Convert.ToString(txtName.Text.Trim()) + "',@vchStandard='" + txtStandard.Text.Trim() + "',@vchDivision='" + txtDivision.Text.Trim() + "',@vchFinYear='" + drpFinYear.SelectedValue.Trim() + "',@vchMobile='" + txtMobile.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchGender='" + drpGender.SelectedItem.Text + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Exist Already");
                return;
            }
            else
            {
                strQry = "exec [usp_HostelInquiry] @command='update',@vchHostelType='" + drpHostelType.SelectedItem.Text + "',@vchRoomType='" + drpRoomType.SelectedItem.Text + "',@vchStudentName='" + txtName.Text.Trim() + "',@vchStandard='" + txtStandard.Text.Trim() + "',@vchDivision='" + txtDivision.Text.Trim() + "',@vchFinYear='" + drpFinYear.SelectedValue.Trim() + "',@vchMobile='" + txtMobile.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchGender='" + drpGender.SelectedItem.Text + "',@vchMessage='" + txtMessage.Text.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@HostelinquiryId='" + Convert.ToString(Session["HostelinquiryId"]) + "',@IntUpdate_by='" + Session["User_id"] + "',@UpdateIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
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
            drpHostelType.ClearSelection();
            drpRoomType.ClearSelection();
            txtName.Text = "";
            drpFinYear.ClearSelection();
            txtStandard.Text = "";
            txtDivision.Text = "";
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
        strQry = "usp_HostelInquiry @command='gridselect',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        
            //txtName.Text = "";
        }
    }  
}
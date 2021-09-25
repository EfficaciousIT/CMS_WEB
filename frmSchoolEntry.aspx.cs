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

public partial class frmSchoolEntry : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fGrid();
            getState();
        }
    }

    protected void fGrid()
    {
        strQry = "usp_SchoolMaster @command='select'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            clear();
        }
    }
    protected void getState()
    {
        try
        {
            string str1 = "usp_SchoolMaster @command='GetState'";
            sBindDropDownList(ddlState, str1, "vchState", "intState_id");          
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void getCity()
    {
        try
        {
            string str1 = "usp_SchoolMaster @command='GetCity',@intState_id='" + Convert.ToString(ddlState.SelectedValue) + "'";
            sBindDropDownList(ddlCity, str1, "vchCity", "intCity_id");
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtSchoolName.Text == "")
        {
            MessageBox("Please Insert School Name!");
            txtSchoolName.Focus();
            return;
        }
        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_SchoolMaster @command='checkExist',@vchSchool_name='" + Convert.ToString(txtSchoolName.Text.Trim()) + "',@intSchool='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("School Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_SchoolMaster] @command='insert',@intType='" + Convert.ToString(ddlType.SelectedItem.Text.Trim()) + "',@vchSchool_name='" + Convert.ToString(txtSchoolName.Text.Trim()) + "',@vchSchool_shortname='" + Convert.ToString(txtShortSchoolName.Text.Trim()) + "',@vchAddress='" + Convert.ToString(txtAddress.Text.Trim()) + "',@vchLandmark='" + Convert.ToString(txtLandmark.Text.Trim()) + "',@intState_id='" + Convert.ToString(ddlState.SelectedValue) + "',@intCity_id='" + Convert.ToString(ddlCity.SelectedValue.Trim()) + "',@numPinCode='" + Convert.ToString(txtPinCode.Text.Trim()) + "',@numPhoneNo1='" + Convert.ToString(txtPhone1.Text.Trim()) + "',@numPhoneNo2='" + Convert.ToString(txtPhone2.Text.Trim()) + "',@numPhoneNo3='" + Convert.ToString(txtPhone3.Text.Trim()) + "',@vchSchoolWebsite='" + Convert.ToString(txtWebsite.Text.Trim()) + "',@numFaxNo='" + Convert.ToString(txtFax.Text.Trim()) + "',@vchContactPerson1='" + Convert.ToString(txtContactPerson1.Text.Trim()) + "',@vchDesignation1='" + Convert.ToString(txtDesignation1.Text.Trim()) + "',@numMobileNo1='" + Convert.ToString(txtMobile1.Text.Trim()) + "',@vchEmailID1='" + Convert.ToString(txtEmail1.Text.Trim()) + "',@vchContactPerson2='" + Convert.ToString(txtContactPerson2.Text.Trim()) + "',@vchDesignation2='" + Convert.ToString(txtDesignation2.Text.Trim()) + "',@numMobileNo2='" + Convert.ToString(txtMobile2.Text.Trim()) + "',@vchEmailID2='" + Convert.ToString(txtEmail2.Text.Trim()) + "',@vchContactPerson3='" + Convert.ToString(txtContactPerson3.Text.Trim()) + "',@vchDesignation3='" + Convert.ToString(txtDesignation3.Text.Trim()) + "',@numMobileNo3='" + Convert.ToString(txtMobile3.Text.Trim()) + "',@vchEmailID3='" + Convert.ToString(txtEmail3.Text.Trim()) + "',@intSchool='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("School Inserted Successfully!");
                }
            }
        }
        else
        {
            //strQry = "usp_SchoolMaster @command='checkExist',@vchSchool_name='" + Convert.ToString(txtSchoolName.Text.Trim()) + "',@intSchool='" + Convert.ToString(Session["School_id"]) + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox("School Name Already Exists");
            //    return;
            //}
            //else
            //{
            strQry = "exec [usp_SchoolMaster] @command='update',@intType='" + Convert.ToString(ddlType.SelectedItem.Text.Trim()) + "',@vchSchool_name='" + Convert.ToString(txtSchoolName.Text.Trim()) + "',@vchSchool_shortname='" + Convert.ToString(txtShortSchoolName.Text.Trim()) + "',@vchAddress='" + Convert.ToString(txtAddress.Text.Trim()) + "',@vchLandmark='" + Convert.ToString(txtLandmark.Text.Trim()) + "',@intState_id='" + Convert.ToString(ddlState.SelectedValue) + "',@intCity_id='" + Convert.ToString(ddlCity.SelectedValue.Trim()) + "',@numPinCode='" + Convert.ToString(txtPinCode.Text.Trim()) + "',@numPhoneNo1='" + Convert.ToString(txtPhone1.Text.Trim()) + "',@numPhoneNo2='" + Convert.ToString(txtPhone2.Text.Trim()) + "',@numPhoneNo3='" + Convert.ToString(txtPhone3.Text.Trim()) + "',@vchSchoolWebsite='" + Convert.ToString(txtWebsite.Text.Trim()) + "',@numFaxNo='" + Convert.ToString(txtFax.Text.Trim()) + "',@vchContactPerson1='" + Convert.ToString(txtContactPerson1.Text.Trim()) + "',@vchDesignation1='" + Convert.ToString(txtDesignation1.Text.Trim()) + "',@numMobileNo1='" + Convert.ToString(txtMobile1.Text.Trim()) + "',@vchEmailID1='" + Convert.ToString(txtEmail1.Text.Trim()) + "',@vchContactPerson2='" + Convert.ToString(txtContactPerson2.Text.Trim()) + "',@vchDesignation2='" + Convert.ToString(txtDesignation2.Text.Trim()) + "',@numMobileNo2='" + Convert.ToString(txtMobile2.Text.Trim()) + "',@vchEmailID2='" + Convert.ToString(txtEmail2.Text.Trim()) + "',@vchContactPerson3='" + Convert.ToString(txtContactPerson3.Text.Trim()) + "',@vchDesignation3='" + Convert.ToString(txtDesignation3.Text.Trim()) + "',@numMobileNo3='" + Convert.ToString(txtMobile3.Text.Trim()) + "',@vchEmailID3='" + Convert.ToString(txtEmail3.Text.Trim()) + "',@SID='" + Convert.ToString(Session["SID"]) + "',@intSchool='" + Convert.ToString(Session["School_id"]) + "',@intUpdate_id='" + Session["User_id"] + "',@IntUpdate_IP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("School Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
           // }
        }
    }
  
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["SID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_SchoolMaster] @command='delete',@SID='" + Convert.ToString(Session["SID"]) + "',@intSchool='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("School Deleted Successfully!");
            }
        }
        catch
        {

        }
    }

    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["SID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_SchoolMaster @command='edit',@SID='" + Convert.ToString(Session["SID"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ddlType.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["intType"]);
                txtSchoolName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchSchool_name"]);
                txtShortSchoolName.Text=Convert.ToString(dsObj.Tables[0].Rows[0]["vchSchool_shortname"]);
                txtAddress.Text=Convert.ToString(dsObj.Tables[0].Rows[0]["vchAddress"]);
                txtLandmark.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchLandmark"]);
                ddlState.SelectedValue=Convert.ToString(dsObj.Tables[0].Rows[0]["intState_id"]);
                getCity();
                ddlCity.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intCity_id"]);
                txtPinCode.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["numPinCode"]);
                txtPhone1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numPhoneNo1"]);
                txtPhone2.Text=Convert.ToString(dsObj.Tables[0].Rows[0]["numPhoneNo2"]);
                txtPhone3.Text=Convert.ToString(dsObj.Tables[0].Rows[0]["numPhoneNo3"]);
                txtWebsite.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchSchoolWebsite"]);
                txtFax.Text=Convert.ToString(dsObj.Tables[0].Rows[0]["numFaxNo"]);
                txtContactPerson1.Text=Convert.ToString(dsObj.Tables[0].Rows[0]["vchContactPerson1"]);
                txtDesignation1.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchDesignation1"]);
                txtMobile1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numMobileNo1"]);
                txtEmail1.Text=Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmailID1"]);
                txtContactPerson2.Text=Convert.ToString(dsObj.Tables[0].Rows[0]["vchContactPerson2"]);
                txtDesignation2.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchDesignation2"]);
                txtMobile2.Text=Convert.ToString(dsObj.Tables[0].Rows[0]["numMobileNo2"]);
                txtEmail2.Text=Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmailID2"]);
                txtContactPerson3.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchContactPerson3"]);
                txtDesignation3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDesignation3"]);
                txtMobile3.Text=Convert.ToString(dsObj.Tables[0].Rows[0]["numMobileNo3"]);
                txtEmail3.Text=Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmailID3"]);
             
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
    protected void clear()
    {
        ddlType.Text =""; 
        txtSchoolName.Text ="";
        txtShortSchoolName.Text=""; 
        txtAddress.Text = "";
        txtLandmark.Text ="";
        ddlState.ClearSelection();
        ddlCity.SelectedValue="0";
        txtPinCode.Text="";
        txtPhone1.Text = "";
        txtPhone2.Text="";
        txtPhone3.Text ="";
        txtWebsite.Text ="";
        txtFax.Text ="";
        txtContactPerson1.Text=""; 
        txtDesignation1.Text ="";
        txtMobile1.Text ="";
        txtEmail1.Text ="";
        txtContactPerson2.Text=""; 
        txtDesignation2.Text ="";
        txtMobile2.Text ="";
        txtEmail2.Text ="";
        txtContactPerson3.Text=""; 
        txtDesignation3.Text ="";
        txtMobile3.Text ="";
        txtEmail3.Text ="";
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        getCity();
    }
}
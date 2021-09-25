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

public partial class frmFeeMstGen : DBUtility
{
    DataSet dsObj = new DataSet();
    string strQry = string.Empty;
    string strTution = string.Empty;
    string strLibrary = string.Empty;
    string strComputer = string.Empty;
    string strClubActivity = string.Empty;
    string strActivityFee = string.Empty;
    string strRegistrationFee = string.Empty;
    string strAdmissionFee = string.Empty;
    string strSecurityFee = string.Empty;
    string strAnnualFee = string.Empty;
    string strDevelopmentFee = string.Empty;
    string strIDCardFee = string.Empty;
    string strMagazineFee = string.Empty;
    string strOther1 = string.Empty;
    string strOther2 = string.Empty;
    string strOther3 = string.Empty;
    string strOther4 = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillStandard();
            Session["Update"] = "";

        }
    }
    protected void FillStandard()
    {
        strQry = "usp_TestSchedule @command='selectStandard',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(drpStandard, strQry, "vchStandard_name", "intStandard_id");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Update"]) == "No")
        {
            strQry = "usp_FeeMaster @command='Insert',@academic_Year='" + drpAcademic.Text.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@TutionFee='" + txtTution.Text.Trim() + "',@TutionFeeType='" + drpTution.Text.Trim() + "',@LibraryFee='" + txtLibrary.Text.Trim() + "',@LibraryFeeType='" + drpLibrary.Text.Trim() + "',@Computer='" + txtComputer.Text.Trim() + "',@ComputerType='" + drpComputer.Text.Trim() + "',@ClubActivity='" + txtClubActivity.Text.Trim() + "',@ClubActivityType='" + drpClubActivity.Text.Trim() + "',@ActivityFee='" + txtActivityFee.Text.Trim() + "',@ActivityFeeType='" + drpActivityFee.Text.Trim() + "',@AdmissionFee='" + txtAdmissionFee.Text.Trim() + "',@AdmissionFeeType='" + drpAdmissionFee.Text + "',@RegistrationFee='" + txtRegistrationFee.Text.Trim() + "',@RegistrationFeeType='" + drpRegistrationFee.Text + "',@SecurityFee='" + txtSecurityFee.Text.Trim() + "',@SecurityFeeType='" + drpSecurityFee.Text.Trim() + "',@AnnualFee='" + txtAnnualFee.Text.Trim() + "',@AnnualFeeType='" + drpAnnualFee.Text.Trim() + "',@DevelopmentFee='" + txtDevelopmentFee.Text.Trim() + "',@DevelopmentFeeType='" + drpDevelopmentFee.Text.Trim() + "',@IDCardFee='" + txtICard.Text.Trim() + "',@IDCardFeeType='" + drpICard.Text + "',@MagazineFee='" + txtMagazine.Text.Trim() + "',@MagazineFeeType='" + drpMagazine.Text.Trim() + "',@totalonetime='',@totalonetimeType='',@totalyearly='',@totalyearlyType='',@schme='',@OtherFee1='" + txtOther1.Text.Trim() + "',@OtherFeeType='" + drpOther1.Text.Trim() + "',@OtherFee1Description='" + txtOther1Des.Text.Trim() + "',@OtherFee2='" + txtOther2.Text.Trim() + "',@OtherFee2Type='" + drpOther2.Text.Trim() + "',@OtherFee2Description='" + txtOther2Des.Text.Trim() + "',@OtherFee3='" + txtOther3.Text.Trim() + "',@OtherFee3Type='" + drpOther3.Text.Trim() + "',@OtherFee3Description='" + txtOther3Des.Text.Trim() + "',@OtherFee4='" + txtOther4.Text.Trim() + "',@OtherFee4Type='" + drpOther4.Text.Trim() + "',@OtherFee4Description='" + txtOther4Des.Text.Trim() + "'";

            int i = sExecuteQuery(strQry);

            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Fee Master Addedd Succussfully');window.location ='frmFeeMstGen.aspx';", true);
            }
        }
        else if (Convert.ToString(Session["Update"]) == "Yes")
        {
            strQry = "usp_FeeMaster @command='update',@academic_Year='" + drpAcademic.Text.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@TutionFee='" + txtTution.Text.Trim() + "',@TutionFeeType='" + drpTution.Text.Trim() + "',@LibraryFee='" + txtLibrary.Text.Trim() + "',@LibraryFeeType='" + drpLibrary.Text.Trim() + "',@Computer='" + txtComputer.Text.Trim() + "',@ComputerType='" + drpComputer.Text.Trim() + "',@ClubActivity='" + txtClubActivity.Text.Trim() + "',@ClubActivityType='" + drpClubActivity.Text.Trim() + "',@ActivityFee='" + txtActivityFee.Text.Trim() + "',@ActivityFeeType='" + drpActivityFee.Text.Trim() + "',@AdmissionFee='" + txtAdmissionFee.Text.Trim() + "',@AdmissionFeeType='" + drpAdmissionFee.Text + "',@RegistrationFee='" + txtRegistrationFee.Text.Trim() + "',@RegistrationFeeType='" + drpRegistrationFee.Text + "',@SecurityFee='" + txtSecurityFee.Text.Trim() + "',@SecurityFeeType='" + drpSecurityFee.Text.Trim() + "',@AnnualFee='" + txtAnnualFee.Text.Trim() + "',@AnnualFeeType='" + drpAnnualFee.Text.Trim() + "',@DevelopmentFee='" + txtDevelopmentFee.Text.Trim() + "',@DevelopmentFeeType='" + drpDevelopmentFee.Text.Trim() + "',@IDCardFee='" + txtICard.Text.Trim() + "',@IDCardFeeType='" + drpICard.Text + "',@MagazineFee='" + txtMagazine.Text.Trim() + "',@MagazineFeeType='" + drpMagazine.Text.Trim() + "',@totalonetime='',@totalonetimeType='',@totalyearly='',@totalyearlyType='',@schme='',@OtherFee1='" + txtOther1.Text.Trim() + "',@OtherFeeType='" + drpOther1.Text.Trim() + "',@OtherFee1Description='" + txtOther1Des.Text.Trim() + "',@OtherFee2='" + txtOther2.Text.Trim() + "',@OtherFee2Type='" + drpOther2.Text.Trim() + "',@OtherFee2Description='" + txtOther2Des.Text.Trim() + "',@OtherFee3='" + txtOther3.Text.Trim() + "',@OtherFee3Type='" + drpOther3.Text.Trim() + "',@OtherFee3Description='" + txtOther3Des.Text.Trim() + "',@OtherFee4='" + txtOther4.Text.Trim() + "',@OtherFee4Type='" + drpOther4.Text.Trim() + "',@OtherFee4Description='" + txtOther4Des.Text.Trim() + "'";

            int i = sExecuteQuery(strQry);

            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Fee Master Updated Succussfully');window.location ='frmFeeMstGen.aspx';", true);
            }
        }
        

    }

    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "usp_FeeMaster @command='select',@academic_Year='" + drpAcademic.Text.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            Session["Update"] = "Yes";
            txtTution.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TutionFee"]);
            drpTution.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TutionFeeType"]);

            txtLibrary.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["LibraryFee"]);
            drpLibrary.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["LibraryFeeType"]);

            txtComputer.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Computer"]);
            drpComputer.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["ComputerType"]);

            txtClubActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["ClubActivity"]);
            drpClubActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["ClubActivityType"]);

            txtActivityFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["ActivityFee"]);
            drpActivityFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["ActivityFeeType"]);

            txtAdmissionFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["AdmissionFee"]);
            drpAdmissionFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["AdmissionFeeType"]);

            txtRegistrationFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["RegistrationFee"]);
            drpRegistrationFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["RegistrationFeeType"]);

            txtSecurityFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SecurityFee"]);
            drpSecurityFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SecurityFeeType"]);

            txtAnnualFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["AnnualFee"]);
            drpAnnualFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["AnnualFeeType"]);

            txtDevelopmentFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["DevelopmentFee"]);
            drpDevelopmentFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["DevelopmentFeeType"]);

            txtICard.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["IDCardFee"]);
            drpICard.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["IDCardFeeType"]);

            txtMagazine.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["MagazineFee"]);
            drpMagazine.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["MagazineFeeType"]);

            txtOther1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["OtherFee1"]);
            drpOther1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["OtherFeeType"]);
            txtOther1Des.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["OtherFee1Description"]);

            txtOther2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["OtherFee2"]);
            drpOther2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["OtherFee2Type"]);
            txtOther2Des.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["OtherFee2Description"]);

            txtOther3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["OtherFee3"]);
            drpOther3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["OtherFee3Type"]);
            txtOther3Des.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["OtherFee2Description"]);

            txtOther4.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["OtherFee4"]);
            drpOther4.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["OtherFee4Type"]);
            txtOther4Des.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["OtherFee2Description"]);
        }
        else
        {
            Session["Update"] = "No";
            txtTution.Text = "";
            drpTution.Text = "--Select--";

            txtLibrary.Text = "";
            drpLibrary.Text = "--Select--";

            txtComputer.Text = "";
            drpComputer.Text = "--Select--";

            txtClubActivity.Text = "";
            drpClubActivity.Text = "--Select--";

            txtActivityFee.Text = "";
            drpActivityFee.Text = "--Select--";

            txtAdmissionFee.Text = "";
            drpAdmissionFee.Text = "--Select--";

            txtRegistrationFee.Text = "";
            drpRegistrationFee.Text = "--Select--";

            txtSecurityFee.Text = "";
            drpSecurityFee.Text = "--Select--";

            txtAnnualFee.Text = "";
            drpAnnualFee.Text = "--Select--";

            txtDevelopmentFee.Text = "";
            drpDevelopmentFee.Text = "--Select--";

            txtICard.Text = "";
            drpICard.Text = "--Select--";

            txtMagazine.Text = "";
            drpMagazine.Text = "--Select--";

            txtOther1.Text = "";
            drpOther1.Text = "--Select---";
            txtOther1Des.Text = "";

            txtOther2.Text = "";
            drpOther2.Text = "--Select---";
            txtOther2Des.Text = "";

            txtOther3.Text = "";
            drpOther3.Text = "--Select---";
            txtOther3Des.Text = "";

            txtOther4.Text = "";
            drpOther4.Text = "--Select---";
            txtOther4Des.Text = "";
        }
    }
}

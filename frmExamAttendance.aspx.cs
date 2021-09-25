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

public partial class frmExamAttendance : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strExaminationDate = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lblTile = new Label();
        //lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        //lblTile.Visible = true;
        //lblTile.Text = "Exam Attendance";
        if (!IsPostBack)
        {
           
            Button2.Visible = false;
            fillAcademicYear();
        }
    }
    public void fillAcademicYear()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_SchoolFeeCollection @type='fillAcademicYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpAcademiYear, strQry, "AcademicYear", "intAcademic_id");


        }
        catch
        {

        }
    }
    protected void FillStandard()
    {
        strQry = "usp_TestSchedule @command='selectStandard',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(drpStandardDet, strQry, "vchStandard_name", "intStandard_id");
    }
    protected void drpStandardDet_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "usp_TestSchedule @command='selectDateAttendance',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + drpAcademiYear.SelectedValue.Trim() + "',@intStandard_id='" + drpStandardDet.SelectedValue.Trim() + "'";
        bool stcardp = sBindDropDownList(drpDate, strQry, "dtInterviewdate", "");
    }
    protected void drpDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        strExaminationDate = Convert.ToDateTime(drpDate.Text.Trim()).ToString("MM/dd/yyyy").Replace("-", "/");

        strQry = "usp_TestSchedule @command='selectGridFillAttendance',@intAcademic_id='" + drpAcademiYear.SelectedValue.Trim() + "',@intStandard_id='" + drpStandardDet.SelectedValue.Trim() + "',@dtinterviewdate='" + strExaminationDate.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdTestSchedule.DataSource = dsObj;
            grdTestSchedule.DataBind();
            Button2.Visible = true;
        }
        else
        {
            grdTestSchedule.DataSource = dsObj;
            grdTestSchedule.DataBind();
            Button2.Visible = false;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int k = 0;
        for (int i = 0; i < grdTestSchedule.Rows.Count; i++)
        {
            Label Label = (Label)grdTestSchedule.Rows[i].Cells[0].FindControl("lblTestID");

            CheckBox chk = (CheckBox)grdTestSchedule.Rows[i].Cells[0].FindControl("chkCtrl");
            if (chk.Checked)
            {
                strQry = "spMarksUpload @command='MarkAttendance',@inttest_id='" + Label.Text.Trim() + "'";
                k = sExecuteQuery(strQry);
            }            
        }

        if (k > 0)
        {
            //MessageBox("Attendance Marked Successfully");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Attendance Marked Successfully');window.location ='frmExamAttendance.aspx';", true);
        }
    }
    protected void drpAcademiYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStandard();
    }
}

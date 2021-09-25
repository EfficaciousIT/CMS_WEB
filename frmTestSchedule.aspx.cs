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
using System.Net;
using System.Text;
using System.IO;

public partial class frmTestSchedule : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strExaminationDate = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillStandard();
            FillTeacher();
            fillAcademicYear();
            Button2.Visible = false;
        }
    }
    public void fillAcademicYear()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_TestSchedule @command='fillAcademicYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpAcademiYear, strQry, "AcademicYear", "intAcademic_id");
            sBindDropDownList(ddlAcademicYear, strQry, "AcademicYear", "intAcademic_id");
        

        }
        catch
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (drpAcademiYear.SelectedValue == "0")
        {            
            MessageBox("Please Select Academic Year!");
            drpAcademiYear.Focus();
            return;
        }
        if (drpStandard.SelectedValue == "0")
        {
            MessageBox("Please Select Standard!");
            drpStandard.Focus();
            return;
        }
        string strChildInterview = string.Empty;
        string strChildExam = string.Empty;
        string strParentInterview = string.Empty;
        

        if (chkChildExamYes.Checked)
        {
            strChildExam = "Yes";
        }
        else
        {
            strChildExam = "No";
        }

        if (rdbYes.Checked)
        {
            strChildInterview = "Yes";
        }
        else
        {
            strChildInterview = "No";
        }

        if (rdbYes.Checked)
        {
            strChildInterview = "Yes";
        }
        else
        {
            strChildInterview = "No";
        }

        
        strExaminationDate = Convert.ToDateTime(txtDate.Text.Trim()).ToString("MM/dd/yyyy").Replace("-","/");

        for (int j = 0; j < chkListStudent.Items.Count; j++)
        {
            if (chkListStudent.Items[j].Selected)
            {
                string strRF_id = chkListStudent.Items[j].Value;
                string strStudent_name = chkListStudent.Items[j].Text;
                strQry = "usp_TestSchedule @command='Insert',@intRegistration_id='" + strRF_id.Trim() + "',@intAcademic_id='" + drpAcademiYear.SelectedValue + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@dtInterviewDate='" + strExaminationDate.Trim() + "',@dtfromTime='" + txtFromTime.Text.Trim() + "',@dtToTime='" + txtToTime.Text.Trim() + "',@intTeacher_id='" + drpInterviewBy.SelectedValue.Trim() + "',@location='" + txtLocation.Text.Trim() + "',@childInterview='" + strChildInterview.Trim() + "',@childExam='" + strChildExam.Trim() + "',@parentInterview='" + strParentInterview.Trim() + "',@candiateName='" + strStudent_name.Trim() + "'";
                int i = sExecuteQuery(strQry);
            }
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Test has been schedule for selected candidate');window.location ='frmTestSchedule.aspx';", true);
        
        //if (i > 0)
        //{
        //    MessageBox("Test ");
        //}

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
    protected void grdNotice_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {

        strQry = "usp_TestSchedule @command='selectStudent',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "'";
        sBindCheckBoxList(chkListStudent, strQry, "vchCandiadateName", "intRF_id");

    }
    protected void FillStandard()
    {
        strQry = "usp_TestSchedule @command='selectStandard',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(drpStandard, strQry, "vchStandard_name", "intStandard_id");
        stcardp = sBindDropDownList(drpStandardDet, strQry, "vchStandard_name", "intStandard_id");
    }

    protected void FillTeacher()
    {
        strQry = "usp_TestSchedule @command='selectTeacher',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(drpInterviewBy, strQry, "vchTeacherFirst_name", "intTeacher_id");
    }

    protected void drpStandardDet_SelectedIndexChanged(object sender, EventArgs e)
    {
        //drpDate.ClearSelection();
        strQry = "usp_TestSchedule @command='selectDate',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + ddlAcademicYear.SelectedValue.Trim() + "',@intStandard_id='" + drpStandardDet.SelectedValue.Trim() + "'";
        bool stcardp = sBindDropDownList(drpDate, strQry, "dtInterviewdate", "");
    }

    protected void drpDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        strExaminationDate = Convert.ToDateTime(drpDate.Text.Trim()).ToString("MM/dd/yyyy").Replace("-", "/");
        strQry = "usp_TestSchedule @command='selectGridFill',@intAcademic_id='" + ddlAcademicYear.SelectedValue.Trim() + "',@intStandard_id='" + drpStandardDet.SelectedValue.Trim() + "',@dtinterviewdate='" + strExaminationDate.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            Button2.Visible = true;
            grdTestSchedule.DataSource = dsObj;
            grdTestSchedule.DataBind();
        }
        else
        {
            grdTestSchedule.DataSource = dsObj;
            grdTestSchedule.DataBind();
            Button2.Visible = false;
        }

    }
    protected void chkCtrl_CheckedChanged(object sender, EventArgs e)
    {
        //lblmsg.Text = "Hello";
    }
    protected void ChckedChanged(object sender, EventArgs e)
    {        
        
        tblEdit.Visible = true; 
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int k = 0;
        for (int i = 0; i < grdTestSchedule.Rows.Count; i++)
        {
            Label Label = (Label)grdTestSchedule.Rows[i].Cells[0].FindControl("lblTestID");

            Label lblFatherMobile = (Label)grdTestSchedule.Rows[i].Cells[0].FindControl("lblfather");

            Label lblFromTime = (Label)grdTestSchedule.Rows[i].Cells[0].FindControl("lblFromTime");

            Label lblRF = (Label)grdTestSchedule.Rows[i].Cells[0].FindControl("lblRF");

            
            strQry = "usp_TestSchedule @command='SendMessage',@inttest_id='" + Label.Text.Trim() + "'";
            k = sExecuteQuery(strQry);
            if (k > 0)
            {
                POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + lblFatherMobile.Text.Trim() + "&msg=Please be inform that your child admission exam is schedule on " + drpDate.Text + " at " + lblFromTime.Text.Trim() + ".your registration no is " + lblRF.Text.Trim() + ". &alert=1", "");
            }
        }

        if (k > 0)
        {
            //MessageBox("Message Sent successfully");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Message Sent successfully');window.location ='frmTestSchedule.aspx';", true);
        }
    }
    private void POST(string url, string data)
    {
        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
        req.Method = "POST";
        req.Headers.Add(HttpRequestHeader.AcceptLanguage, "de-DE,de;q=0.8,en-US;q=0.7,en;q=0.3");

        req.Timeout = req.ReadWriteTimeout = 15000;

        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] dataBytes = encoding.GetBytes(data);
        req.ContentLength = dataBytes.Length;
        Stream stream = req.GetRequestStream();
        stream.Write(dataBytes, 0, dataBytes.Length);
        stream.Close();

        req.GetResponse();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //drpStandardDet.ClearSelection();
        //drpDate.ClearSelection();
    }
}

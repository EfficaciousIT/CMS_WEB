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
using System.Text;
using System.Net;
using System.IO;

public partial class frmAttendanceMark : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    bool boolSTatus;
    string strStudent_id = string.Empty;
    string strDate = string.Empty;
    string strAttendanceStatus = string.Empty;
    string strInTime = string.Empty, strOutTime = string.Empty;
    int k = 0;
    string strHoloidayStatys = string.Empty;
    string strMobileNo = string.Empty;
    string strStudentName = string.Empty;
    DateTime dtDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            txtDate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")).Replace("-","/");
            strDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
            fillStandard();
        }
    }
    protected void fillStandard()
    {
        try
        {

            strQry = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            boolSTatus = sBindDropDownList(drpStandard, strQry, "Standard_name", "intStandard_id");
        }
        catch
        {
        }

    }
    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            strQry = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstanderd_id='" + drpStandard.SelectedValue + "' ";
            boolSTatus = sBindDropDownList(drpDivision, strQry, "vchDivisionName", "intDivision_id");

            drpDivision.ClearSelection();
        }
        catch
        {
        }

    }
    protected void drpStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void SqlDataSource1_Selecting(object sender,SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 5000;
    }

    protected void drpDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            strDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
            GridViewRow row = (sender as DropDownList).NamingContainer as GridViewRow;
            strQry = "usp_MarkAttendance @command='BackDate',@intstanderd_id='" + drpStandard.SelectedValue.Trim() + "',@intdivision_id='" + drpDivision.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@dtDate='" + Convert.ToString(strDate) + "',@intAcademicYear_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                btnUpdate.Visible = true;
                btnSMS.Visible = true;
                btnSMSAdmin.Visible = true;
                grdMarkAttendance.DataSource = dsObj;
                grdMarkAttendance.DataBind();
               
            }
            else
            {
                btnUpdate.Visible = false;
                btnSMS.Visible = false;
                btnSMSAdmin.Visible = false;
                grdMarkAttendance.DataSource = dsObj;
                grdMarkAttendance.DataBind();
            }
        }
        catch
        {
        }
    }

    protected void Status_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            GridViewRow row = (sender as DropDownList).NamingContainer as GridViewRow;

            string dataKey = this.grdMarkAttendance.DataKeys[row.RowIndex].Value.ToString();

            CheckBox chk = (CheckBox)row.FindControl("chkCtrl");

            chk.Checked = true;

            row.BackColor = System.Drawing.Color.Cornsilk;

        }
        catch
        {
        }

    }
    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            strDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");

            foreach (GridViewRow row in grdMarkAttendance.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkCtrl") as CheckBox);
                    if (chkRow.Checked)
                    {
                        strStudent_id = this.grdMarkAttendance.DataKeys[row.RowIndex].Values[0].ToString();
                        strInTime = "00:00:00.000";
                        strOutTime = "00:00:00.000";
                        strAttendanceStatus = "Absent";
                        string regId = this.grdMarkAttendance.DataKeys[row.RowIndex].Values[4].ToString();

                        var applicationID = "AIzaSyBhKk8a8prrNtRy1uc0Q8yp7QG0vI4dykU"; // PbojmyrmspdqkZ0pINni7DyqvhY2

                        string message = "You are marked Absent as on" + strDate;
                        string title = "Attendance";
                        var SENDER_ID = "154368864541";
                        // 73064704159
                        var value = "You are marked Absent as on" + strDate;
                        WebRequest tRequest;
                        tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                        tRequest.Method = "post";
                        tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                        tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

                        tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

                        string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                            + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "&data.title=" + title + "";

                        Console.WriteLine(postData);
                        Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                        tRequest.ContentLength = byteArray.Length;

                        Stream dataStream = tRequest.GetRequestStream();
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Close();

                        WebResponse tResponse = tRequest.GetResponse();

                        dataStream = tResponse.GetResponseStream();

                        StreamReader tReader = new StreamReader(dataStream);

                        String sResponseFromServer = tReader.ReadToEnd();

                        //txtResponse.Text = sResponseFromServer; //printing response from GCM server.
                        //txtStream.Text = postData.ToString().Trim();
                        tReader.Close();
                        dataStream.Close();
                        tResponse.Close();
                    }
                    else
                    {
                        strStudent_id = this.grdMarkAttendance.DataKeys[row.RowIndex].Values[0].ToString();

                        strInTime = "00:00:00.000";
                        strOutTime = "00:00:00.000"; 
                        //strInTime = this.grdMarkAttendance.DataKeys[row.RowIndex].Values[1].ToString();
                        //strOutTime = this.grdMarkAttendance.DataKeys[row.RowIndex].Values[2].ToString();
                        strAttendanceStatus = "Present";
                        string regId = this.grdMarkAttendance.DataKeys[row.RowIndex].Values[4].ToString();

                        var applicationID = "AIzaSyBhKk8a8prrNtRy1uc0Q8yp7QG0vI4dykU"; // PbojmyrmspdqkZ0pINni7DyqvhY2

                        string message = "You are marked Present as on" + strDate;
                        string title = "Attendance";
                        var SENDER_ID = "154368864541";
                        // 73064704159
                        var value = "You are marked Present as on" + strDate;
                        WebRequest tRequest;
                        tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                        tRequest.Method = "post";
                        tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                        tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

                        tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

                        string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                            + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "&data.title=" + title + "";

                        Console.WriteLine(postData);
                        Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                        tRequest.ContentLength = byteArray.Length;

                        Stream dataStream = tRequest.GetRequestStream();
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Close();

                        WebResponse tResponse = tRequest.GetResponse();

                        dataStream = tResponse.GetResponseStream();

                        StreamReader tReader = new StreamReader(dataStream);

                        String sResponseFromServer = tReader.ReadToEnd();

                        //txtResponse.Text = sResponseFromServer; //printing response from GCM server.
                        //txtStream.Text = postData.ToString().Trim();
                        tReader.Close();
                        dataStream.Close();
                        tResponse.Close();
                    }
                    strQry = "usp_MarkAttendance @command='Insert',@intUserType_id='1',@intUser_id='0',@dtDate='" + strDate.Trim() + "',@inTime='" + strInTime.Trim() + "',@outTime='" + strOutTime.Trim() + "',@status='" + strAttendanceStatus.Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intStudent_id='" + strStudent_id.Trim() + "',@intAcademicYear_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                    k = sExecuteQuery(strQry);
                }
            }
            if (k > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Attendance marked Successfully')", true);
                //strQry = "usp_MarkAttendance @command='BackDate',@intstanderd_id='" + drpStandard.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@dtDate='" + Convert.ToString(strDate) + "',@intAcademicYear_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                strQry = "usp_MarkAttendance @command='BackDate',@intstanderd_id='" + drpStandard.SelectedValue.Trim() + "',@intdivision_id='" + drpDivision.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@dtDate='" + Convert.ToString(strDate) + "',@intAcademicYear_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    btnUpdate.Visible = true;
                    btnSMS.Visible = true;
                    btnSMSAdmin.Visible = true;
                    grdMarkAttendance.DataSource = dsObj;
                    grdMarkAttendance.DataBind();
                }
            }
        }
        catch
        {

        }
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        try
        {

            strDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
            //if (Convert.ToDateTime(strDate).Equals(DateTime.Now.ToString("MM/dd/yyyy").Replace("-","/")))
            if (strDate == DateTime.Now.ToString("MM/dd/yyyy").Replace("-", "/"))
            {
                btnSMS.Visible = true;
                btnSMSAdmin.Visible = true;
            }
            else
            {
                btnSMS.Visible = false;
                btnSMSAdmin.Visible = false;
            }

            strQry = "usp_MarkAttendance @command='checkHolidays',@dtDate='" + Convert.ToString(strDate) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                strHoloidayStatys = Convert.ToString(dsObj.Tables[0].Rows[0][0]);

                dtDate = DateTime.ParseExact(strDate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                if ((strHoloidayStatys == "Yes") || (dtDate.Date.DayOfWeek == DayOfWeek.Sunday))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myconfirm", "confirm('Its holiday for selected date. Are sure you want mark attendance for same date');", true);

                    strQry = "usp_MarkAttendance @command='BackDate',@intstanderd_id='" + drpStandard.SelectedValue.Trim() + "',@intdivision_id='" + drpDivision.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@dtDate='" + Convert.ToString(strDate) + "',@intAcademicYear_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        btnUpdate.Visible = true;
                        //btnSMS.Visible = true;
                        grdMarkAttendance.DataSource = dsObj;
                        grdMarkAttendance.DataBind();
                    }
                }
                else
                {
                    strQry = "usp_MarkAttendance @command='BackDate',@intstanderd_id='" + drpStandard.SelectedValue.Trim() + "',@intdivision_id='" + drpDivision.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@dtDate='" + Convert.ToString(strDate) + "',@intAcademicYear_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        btnUpdate.Visible = true;
                        //btnSMS.Visible = true;
                        grdMarkAttendance.DataSource = dsObj;
                        grdMarkAttendance.DataBind();
                    }
                }

            }
        
        }
        catch
        {
        }

    }
    
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

            GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
            int index = row.RowIndex;
            CheckBox cb1 = (CheckBox)grdMarkAttendance.Rows[index].FindControl("chkCtrl");
            Label lblStatus = (Label)grdMarkAttendance.Rows[index].FindControl("lblAttstatus");

            if (cb1.Checked == true)
            {
                lblStatus.Text = "Absent";
                row.BackColor = System.Drawing.Color.Cornsilk;
            }
            else if (cb1.Checked == false)
            {
                lblStatus.Text = "Present";
                row.BackColor = System.Drawing.Color.Transparent;

            }
            
        }
        catch
        {
        }

    }
    protected void btnSMS_Click(object sender, EventArgs e)
    {
        try
        {

            foreach (GridViewRow row in grdMarkAttendance.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkCtrl") as CheckBox);
                    if (chkRow.Checked)
                    {
                        strMobileNo = this.grdMarkAttendance.DataKeys[row.RowIndex].Values[3].ToString();
                        strStudentName = this.grdMarkAttendance.DataKeys[row.RowIndex].Values[4].ToString();
                        string msgParent = "Your Child : " + strStudentName + " is absent as on " + strDate + " in School, Thank you.";
                        POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A2cabcee227fa491ee050155a13485498&sender=CMSBKP&to=" + strMobileNo + "&message=" + msgParent.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                        //POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A2cabcee227fa491ee050155a13485498&sender=CMSBKP&to=" + strMobileNo + "&message=" + msgParent.Trim() + "&senderid=CMSBKP&accusage=1", "");
                        //POST("http://e-smartsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + strMobileNo + "&message=" + msgParent.Trim() + "&senderid=CMSBKP&accusage=1", "");
                        //POST("http://alerts.justnsms.com/api/v3/?method=sms&api_key=Ad68553890184f28bf0a8c8951f3a665f&to=" + strMobileNo + "&sender=EFFICA&message=" + msgParent + "&format=json&custom=1,2&flash=0", "");
                        //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobileNo.Trim() + "&msg=Your child " + strStudentName.Trim() + " is absent today in school&alert=1", "");
                        strQry = "Messaging_SP @type='Insert',@uesr_type='" + Convert.ToString(Session["strUserType"]) + "',@student_id=0,@mobile='" + strMobileNo.Trim() + "',@msgCount='" + 1 + "',@message='" + msgParent.Trim() + "',@InsertedBy='" + Session["User_Id"] + "',@insertIP='" + GetSystemIP() + "'";
                        k = sExecuteQuery(strQry);

                    }
                }
            }
            MessageBox("SMS Send Successfuly");
        }
        catch
        {
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
    protected void btnSMSAdmin_Click(object sender, EventArgs e)
    {

        try
        {
            string str = string.Empty;
            string strname = string.Empty;
            foreach (GridViewRow gvrow in grdMarkAttendance.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkCtrl");
                if (chk != null & chk.Checked)
                {
                    //str += grdMarkAttendance.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                    str += this.grdMarkAttendance.DataKeys[gvrow.RowIndex].Values[4].ToString() + ',';
                    //strname += gvrow.Cells[2].Text + ',';
                }
            }
            str = str.Trim(",".ToCharArray());
            strQry = "usp_MarkAttendance @command='FillAdmin',@intschool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
                {
                    string strMobileNo = Convert.ToString(dsObj.Tables[0].Rows[i]["intMobileNo"]);
                    //strMobileNo = "9831109717";
                    string msgParent = "" + str + " these Students are absent as on " + strDate + ". for Class " + drpStandard.SelectedItem.Text.Trim() + "";
                    //POST("http://e-smartsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + strMobileNo + "&message=" + msgParent.Trim() + "&senderid=CMSBKP&accusage=1", "");
                    POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A2cabcee227fa491ee050155a13485498&sender=CMSBKP&to=" + strMobileNo + "&message=" + msgParent.Trim() + "&senderid=CMSBKP&accusage=1", "");
                    //POST("http://alerts.justnsms.com/api/v3/?method=sms&api_key=Ad68553890184f28bf0a8c8951f3a665f&to=" + strMobileNo + "&sender=EFFICA&message=" + msgParent + "&format=json&custom=1,2&flash=0", "");
                    //strname = strname.Trim(",".ToCharArray());
                    //lblmsg.Text = "Selected UserIds: <b>" + str + "</b><br/>" + "Selected UserNames: <b>" + strname + "</b>";
                    strQry = "Messaging_SP @type='Insert',@uesr_type='" + Convert.ToString(Session["strUserType"]) + "',@student_id=0,@mobile='" + strMobileNo.Trim() + "',@msgCount='" + 1 + "',@message='" + msgParent.Trim() + "',@InsertedBy='" + Session["User_Id"] + "',@insertIP='" + GetSystemIP() + "'";
                    k = sExecuteQuery(strQry);

                }
            }
            MessageBox(" SMS Send Successfuly");

        }
        catch
        {

        }
    }
}

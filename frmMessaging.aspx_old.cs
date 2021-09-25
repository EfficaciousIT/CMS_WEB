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

public partial class frmMessaging : DBUtility
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
    string strFCMToken; //= string.Empty;
    DateTime dtDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillDrp();   
        }
    }
    protected void fillDrp()
    {
        string strQry = "Execute dbo.usp_idcard @command='selectTypeofuser',@intSchool_id='" + Session["School_id"] + "' ";
        bool stcardp = sBindDropDownList(drpUserType, strQry, "vchUser_name", "intUserType_id");
        drpUserType.Items.Insert(0, "Multiple");

        strQry = "Execute dbo.usp_idcard @command='SelectDepartment',@intSchool_id='" + Session["School_id"] + "',@intRole_Id='" + drpUserType.SelectedValue.Trim() + "' ";
        bool stcardp2 = sBindDropDownList(drpDepartment, strQry, "vchDepartment_name", "intDepartment");
        // drpDepartment.Items.Insert(1, "All");
    }
    protected void drpUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpUserType.Text == "All")
        {
            trStudent.Visible = false;
            trStaff.Visible = false;
            Numbers.Visible = false;
            grdMessage.Visible = false;
        }
        else if (drpUserType.Text == "1")
        {
            trStudent.Visible = true;
            trStaff.Visible = false;
            Numbers.Visible = false;

            string strQry = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
            bool st = sBindDropDownList(drpStandard, strQry, "Standard_name", "intStandard_id");
            drpStandard.Items.Insert(1, "All");
            grdMessage.Visible = false;
        }
        else if (drpUserType.Text == "3")
        {
            //drpStaff.ClearSelection();
            trStudent.Visible = false;
            trStaff.Visible = true;
            Numbers.Visible = false;
            fillDept();
            grdMessage.Visible = false;
        }
        else if (drpUserType.Text == "4")
        {
            //drpStaff.ClearSelection();
            trStudent.Visible = false;
            trStaff.Visible = true;
            Numbers.Visible = false;
            fillDept();
            grdMessage.Visible = false;
        }
        else if (drpUserType.Text == "5")
        {
            trStudent.Visible = false;
            trStaff.Visible = false;
            Numbers.Visible = false;
            allAdmin();
            grdMessage.Visible = true;
        }
        else if (drpUserType.Text == "Multiple")
        {
            Numbers.Visible = true;
            trStudent.Visible = false;
            trStaff.Visible = false;

            grdMessage.Visible = false;
        }
    }
    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpStandard.Text == "All")
        {
            drpStandard.Enabled = true;
            drpDivision.Enabled = false;
            ddlGender.Enabled = false;
            allStandard();
            grdMessage.Visible = true;
        }
        else
        {
            drpDivision.Enabled = true;
            ddlGender.Enabled = true;
            int stat = Convert.ToInt32(drpStandard.SelectedItem.Value);
            string strQry = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "' ";
            bool st2 = sBindDropDownList(drpDivision, strQry, "vchDivisionName", "intDivision_id");
            drpDivision.Items.Insert(1, "All");
            getStandard();
            grdMessage.Visible = true;
        }
    }
    protected void fillDept()
    {
        strQry = "Execute dbo.usp_idcard @command='SelectDepartment',@intSchool_id='" + Session["School_id"] + "',@intRole_Id='" + drpUserType.SelectedValue.Trim() + "' ";
        bool stcardp2 = sBindDropDownList(drpDepartment, strQry, "vchDepartment_name", "intDepartment");
        drpDepartment.Items.Insert(1, "All");
    }
    protected void fillStandard()
    {
        strQry = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        boolSTatus = sBindDropDownList(drpStandard, strQry, "Standard_name", "intStandard_id");
    }
    public void getSection()
    {
        try
        {
            strQry = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstanderd_id='" + drpStandard.SelectedValue + "' ";
            boolSTatus = sBindDropDownList(drpDivision, strQry, "vchDivisionName", "intDivision_id");
        }
        catch
        {

        }
    }
    protected void drpDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpUserType.SelectedValue == "3")
        {
            if (drpDepartment.Text == "All")
            {
                //int typeid = Convert.ToInt32(drpUserType.SelectedItem.Value);
                //int depid = Convert.ToInt32(drpDepartment.SelectedItem.Value);
                //string query2 = "Execute [usp_NewAdminDashboard] @type='AllTeacher',@SchoolId='" + Session["School_id"] + "'";
                
                    GridViewRow row = (sender as DropDownList).NamingContainer as GridViewRow;
                    strQry = "usp_NewAdminDashboard @type='AllTeacher1',@SchoolId='" + Session["School_id"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        btnSMS.Visible = true;
                        grdMessage.Visible = true;
                        grdMessage.DataSource = dsObj;
                        grdMessage.DataBind();
                    }
                    else
                    {
                        btnSMS.Visible = false;
                        grdMessage.Visible = true;
                        grdMessage.DataSource = dsObj;
                        grdMessage.DataBind();
                    }

                    // bool st3 = sBindDropDownList(drpStaff, query2, "vchFirst_name", "intTeacher_id");
                    //drpStaff.Items.Insert(1, "All");
                    //drpStaff.Enabled = true;
                }
     
            else

            {
                int typeid = Convert.ToInt32(drpUserType.SelectedItem.Value);
                int depid = Convert.ToInt32(drpDepartment.SelectedItem.Value);
                string query2 = "Execute dbo.usp_NewAdminDashboard @type='SelectTeacherId',@SchoolId='" + Session["School_id"] + "',@intDepartment_id='" + depid + "'";
                dsObj = sGetDataset(query2);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    btnSMS.Visible = true;
                    grdMessage.Visible = true;
                    grdMessage.DataSource = dsObj;
                    grdMessage.DataBind();

                }
                else
                {
                    btnSMS.Visible = false;
                    grdMessage.Visible = true;
                    grdMessage.DataSource = dsObj;
                    grdMessage.DataBind();
                }
            }
        }
        if (drpUserType.SelectedValue == "4")
        {
            if (drpDepartment.Text == "All")
            {
                strQry = "usp_NewAdminDashboard @type='AllStaffsms',@SchoolId='" + Session["School_id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    btnSMS.Visible = true;
                    grdMessage.Visible = true;
                    grdMessage.DataSource = dsObj;
                    grdMessage.DataBind();
                }
                else
                {
                    btnSMS.Visible = false;
                    grdMessage.Visible = true;
                    grdMessage.DataSource = dsObj;
                    grdMessage.DataBind();
                }
            }
            else
            {
                int typeid = Convert.ToInt32(drpUserType.SelectedItem.Value);
                int depid = Convert.ToInt32(drpDepartment.SelectedItem.Value);
                string query2 = "Execute dbo.usp_NewAdminDashboard @type='SelectStaffId',@SchoolId='" + Session["School_id"] + "',@intDepartment_id='" + depid + "'";
                dsObj = sGetDataset(query2);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    btnSMS.Visible = true;
                    grdMessage.Visible = true;
                    grdMessage.DataSource = dsObj;
                    grdMessage.DataBind();


                }
                else
                {
                    btnSMS.Visible = false;
                    grdMessage.Visible = true;
                    grdMessage.DataSource = dsObj;
                    grdMessage.DataBind();
                }

            }
        }

    }

    //protected void drpDepartment_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (drpUserType.SelectedValue == "3")
    //    {
    //        int typeid = Convert.ToInt32(drpUserType.SelectedItem.Value);
    //        int depid = Convert.ToInt32(drpDepartment.SelectedItem.Value);
    //        string query2 = "Execute Messaging_SP @type='getTeacher',@intschool_id='" + Session["School_id"] + "',@intDepartment_id='" + depid + "'";
    //        dsObj = sGetDataset(query2);
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            btnSMS.Visible = true;
    //            grdMessage.DataSource = dsObj;
    //            grdMessage.DataBind();
    //        }
    //        else
    //        {
    //            btnSMS.Visible = false;
    //            grdMessage.DataSource = dsObj;
    //            grdMessage.DataBind();
    //        }   
    //    }
    //    if (drpUserType.SelectedValue == "4")
    //    {
    //        int typeid = Convert.ToInt32(drpUserType.SelectedItem.Value);
    //        int depid = Convert.ToInt32(drpDepartment.SelectedItem.Value);
    //        string query2 = "Execute Messaging_SP @type='getStaff',@intschool_id='" + Session["School_id"] + "',@intDepartment_id='" + depid + "'";
    //        dsObj = sGetDataset(query2);
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            btnSMS.Visible = true;
    //            grdMessage.DataSource = dsObj;
    //            grdMessage.DataBind();
    //        }
    //        else
    //        {
    //            btnSMS.Visible = false;
    //            grdMessage.DataSource = dsObj;
    //            grdMessage.DataBind();
    //        }       
    //    }
    //    grdMessage.Visible = true;
    //} 
    protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpStandard.SelectedValue == "0")
        {            
            MessageBox("Please Select Standard!");
            drpStandard.Focus();
            return;
        }
        if (drpDivision.SelectedValue == "0")
        {
            MessageBox("Please Select Division!");
            drpDivision.Focus();
            return;
        }
        
        GridViewRow row = (sender as DropDownList).NamingContainer as GridViewRow;
        strQry = "Messaging_SP @type='getGender',@intstanderd_id='" + drpStandard.SelectedValue.Trim() + "',@intDivision_id='" + drpDivision.SelectedValue.Trim() + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {            
            btnSMS.Visible = true;
            grdMessage.Visible = true;
            grdMessage.DataSource = dsObj;
            grdMessage.DataBind();
        }
        else
        {
            btnSMS.Visible = false;
            grdMessage.Visible = true;
            grdMessage.DataSource = dsObj;
            grdMessage.DataBind();
        }
    }

    protected void btnSMS_Click(object sender, EventArgs e)
    {
        try
        {
            //
            var encodedStr = txtNotice.Text.Trim();

            if (txtNotice.Text == "")
            {
                MessageBox("Please Type Message!");
                txtNotice.Focus();
                return;
            }
            //if (txtNotice.Text.Length >= 161)
            //{
            //    MessageBox("Please enter 160 character Message!");
            //    txtNotice.Focus();
            //    return;
            //}
            if (drpUserType.Text == "Multiple")
            {
                string s = txtNumbers.Text;
                string[] values = s.Split(',');

                //
                encodedStr = (encodedStr).Replace("+", "plus;");
                encodedStr = (encodedStr).Replace("&", "amp;");
                encodedStr = (encodedStr).Replace("#", ";hash");
                encodedStr = (encodedStr).Replace(",", "comma;");

                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                    string msgParent = txtNotice.Text.Trim();
                    //POST("http://alerts.justnsms.com/api/v3/?method=sms&api_key=Ad68553890184f28bf0a8c8951f3a665f&to=" + values[i].Trim() + "&sender=EFFICA&message=" + msgParent + "&format=json&custom=1,2&flash=0", "");
                    //POST("http://e-smartsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + values[i].Trim() + "&message=" + txtNotice.Text.Trim() + "&senderid=CMSBKP&accusage=1", "");
                    //POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A2cabcee227fa491ee050155a13485498&sender=CMSBKP&to=" + values[i].Trim() + "&message=" + txtNotice.Text.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                    //POST("http://www.smsjust.com/sms/user/urlsms.php?username=Central Model school&pass=$b5@ZtX3&senderid=CMSBKP&dest_mobileno=" + strMobileNo + "&msgtype=TXT&message=" + txtNotice.Text.Trim() + "&response=Y", "");
                    //POST("http://www.smsjust.com/sms/user/urlsms.php?username=Central Model school&pass=$b5@ZtX3&senderid=CMSBKP&dest_mobileno=" + values[i].Trim() + "&msgtype=TXT&message=" + txtNotice.Text.Trim() + "&response=Y", "");
                  //  POST("http://www.smsjust.com/sms/user/urlsms.php?username=Central Model school&pass=$b5@ZtX3&senderid=CMSBKP&dest_mobileno=" + values[i].Trim() + "&msgtype=TXT&message=" + encodedStr + "&response=Y", "");
                    POST("http://www.smsjust.com/sms/user/urlsms.php?username=Central Model school&pass=w_F@2R6g&senderid=CMSBKP&dest_mobileno=" + values[i].Trim() + "&msgtype=TXT&message=" + msgParent + "&response=Y&dlttempid=1507163100574058180", "");
                    strQry = "Messaging_SP @type='Insert',@uesr_type='" + drpUserType.SelectedValue.Trim() + "',@student_id=0,@mobile='" + values[i].Trim() + "',@message='" + txtNotice.Text.Trim() + "',@InsertedBy='" + Session["User_Id"] + "',@insertIP='" + GetSystemIP() + "'";
                    k = sExecuteQuery(strQry);

                }
            }
            else
            {
                foreach (GridViewRow row in grdMessage.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkCtrl") as CheckBox);
                        if (chkRow.Checked == false)
                        {
                            //
                            encodedStr = (encodedStr).Replace("+", "plus;");
                            encodedStr = (encodedStr).Replace("&", "amp;");
                            encodedStr = (encodedStr).Replace("#", ";hash");
                            encodedStr = (encodedStr).Replace(",", "comma;");

                            strMobileNo = this.grdMessage.DataKeys[row.RowIndex].Values[2].ToString();
                            strStudentName = this.grdMessage.DataKeys[row.RowIndex].Values[1].ToString();
                            strFCMToken = this.grdMessage.DataKeys[row.RowIndex].Values[3].ToString();
                            string msgParent = txtNotice.Text.Trim();
                            //POST("http://e-smartsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + strMobileNo + "&message=" + txtNotice.Text.Trim() + "&senderid=CMSBKP&accusage=1", "");
                            //POST("http://alerts.justnsms.com/api/v3/?method=sms&api_key=Ad68553890184f28bf0a8c8951f3a665f&to=" + strMobileNo + "&sender=EFFICA&message=" + msgParent + "&format=json&custom=1,2&flash=0", "");
                            //POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A2cabcee227fa491ee050155a13485498&sender=CMSBKP&to=" + strMobileNo + "&message=" + txtNotice.Text.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                            //POST("http://www.smsjust.com/sms/user/urlsms.php?username=Central Model school&pass=$b5@ZtX3&senderid=CMSBKP&dest_mobileno=" + strMobileNo + "&msgtype=TXT&message=" + txtNotice.Text.Trim() + "&response=Y", "");
                            //POST("http://www.smsjust.com/sms/user/urlsms.php?username=Central Model school&pass=$b5@ZtX3&senderid=CMSBKP&dest_mobileno=" + strMobileNo + "&msgtype=TXT&message=" + txtNotice.Text.Trim() + "&response=Y", "");
                            
                            //POST("http://www.smsjust.com/sms/user/urlsms.php?username=Central Model school&pass=$b5@ZtX3&senderid=CMSBKP&dest_mobileno=" + strMobileNo + "&msgtype=TXT&message=" + encodedStr + "&response=Y", "");
                            POST("http://www.smsjust.com/sms/user/urlsms.php?username=Central Model school&pass=w_F@2R6g&senderid=CMSBKP&dest_mobileno=" + strMobileNo + "&msgtype=TXT&message=" + msgParent + "&response=Y&dlttempid=1507163100574058180", "");
                            string regId = this.grdMessage.DataKeys[row.RowIndex].Values[3].ToString();

                            var applicationID = "AIzaSyBhKk8a8prrNtRy1uc0Q8yp7QG0vI4dykU"; // PbojmyrmspdqkZ0pINni7DyqvhY2

                            string message = txtNotice.Text;
                            string title = "Message Center";
                            var SENDER_ID = "154368864541";
                            // 73064704159
                            var value = txtNotice.Text.Trim();
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
                            strQry = "Messaging_SP @type='Insert',@uesr_type='" + drpUserType.SelectedValue.Trim() + "',@student_id='" + strStudent_id.Trim() + "',@mobile='" + strMobileNo.Trim() + "',@message='" + msgParent.Trim() + "',@InsertedBy='" + Session["User_Id"] + "',@insertIP='" + GetSystemIP() + "'";
                            k = sExecuteQuery(strQry);
                        }
                    }
                }
            }

            MessageBox("SMS Send Successfuly");
            Clear();
        }
        catch
        { 
        }
    }

    //code by nikhil
    private void Clear()
    {
        drpUserType.ClearSelection();
        drpStandard.ClearSelection();
        drpDivision.ClearSelection();
        ddlGender.ClearSelection();
        txtNotice.Text = "";
        drpDepartment.ClearSelection();
        txtNumbers.Text = "";
    }

    private void POST(string url, string data)
    {
        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
        req.Method = "POST";
        req.Headers.Add(HttpRequestHeader.AcceptLanguage, "de-DE,de;q=0.8,en-US;q=0.7,en;q=0.3");

        req.Timeout = req.ReadWriteTimeout = 30000;

        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] dataBytes = encoding.GetBytes(data);
        req.ContentLength = dataBytes.Length;
        Stream stream = req.GetRequestStream();
        stream.Write(dataBytes, 0, dataBytes.Length);
        stream.Close();

        req.GetResponse();
    }
    
    protected void allAdmin()
    {
        strQry = "Messaging_SP @type='AllSMSAdmin',@intschool_id='" + Session["School_id"] + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            btnSMS.Visible = true;
            grdMessage.DataSource = dsObj;
            grdMessage.DataBind();
        }
        else
        {
            btnSMS.Visible = false;
            grdMessage.DataSource = dsObj;
            grdMessage.DataBind();
        }
    }

    protected void allStandard()
    {
        strQry = "Messaging_SP @type='AllStandard',@intschool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            btnSMS.Visible = true;
            grdMessage.DataSource = dsObj;
            grdMessage.DataBind();
        }
        else
        {
            btnSMS.Visible = false;
            grdMessage.DataSource = dsObj;
            grdMessage.DataBind();
        }
    }
    protected void getStandard()
    {
        strQry = "Messaging_SP @type='getStandard',@intstanderd_id='" + Convert.ToInt32(drpStandard.SelectedValue) + "',@intschool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            btnSMS.Visible = true;
            grdMessage.DataSource = dsObj;
            grdMessage.DataBind();
        }
        else
        {
            btnSMS.Visible = false;
            grdMessage.DataSource = dsObj;
            grdMessage.DataBind();
        }
    }
    protected void drpDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (drpDivision.Text == "All")
            {
                ddlGender.Enabled = false;
                allDivision();
            }
            else
            {
                ddlGender.Enabled = true;
                getDivision();
            }
            grdMessage.Visible = true;
        }
        catch
        {

        }
    }
    protected void allDivision()
    {
        strQry = "Messaging_SP @type='allDivision',@intstanderd_id='" + Convert.ToInt32(drpStandard.SelectedValue) + "',@intschool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            btnSMS.Visible = true;
            grdMessage.DataSource = dsObj;
            grdMessage.DataBind();
        }
        else
        {
            btnSMS.Visible = false;
            grdMessage.DataSource = dsObj;
            grdMessage.DataBind();
        }
    }
    protected void getDivision()
    {
        strQry = "Messaging_SP @type='getDivision',@intstanderd_id='" + Convert.ToInt32(drpStandard.SelectedValue) + "',@intDivision_id='" + Convert.ToInt32(drpDivision.SelectedValue) + "',@intschool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            btnSMS.Visible = true;
            grdMessage.DataSource = dsObj;
            grdMessage.DataBind();
        }
        else
        {
            btnSMS.Visible = false;
            grdMessage.DataSource = dsObj;
            grdMessage.DataBind();
        }
    }

    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{

    //    // string strQry = "";
    //    string ConnStr = ConfigurationManager.ConnectionStrings["esmsCentralModel"].ConnectionString;
    //    SqlConnection conn = new SqlConnection();
    //    conn = new SqlConnection(ConnStr);
    //    string SqlString = "select vchFCMToken from tblTeacher_Master where vchFCMToken IS NOT NULL";
    //    SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
    //    DataTable dt = new DataTable();
    //    sda.Fill(dt);
    //    string s = txtnotce.Text;
    //    string[] values = s.Split(',');

    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {

    //        string msgParent = txtnotce.Text.Trim();

    //        string regId = dt.Rows[i]["vchFCMToken"].ToString();
           
    //        var applicationID = "AIzaSyBhKk8a8prrNtRy1uc0Q8yp7QG0vI4dykU"; 
           

    //        string message = txtnotce.Text;
    //        string title = "DASHBOARD";

    //        var SENDER_ID = "154368864541";
          
    //        var value = txtnotce.Text;
    //        WebRequest tRequest;
    //        tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
    //        tRequest.Method = "post";
    //        tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
    //        tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

    //        tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

    //        string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
    //            + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "&data.title=" + title + "";

    //        Console.WriteLine(postData);
    //        Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    //        tRequest.ContentLength = byteArray.Length;

    //        Stream dataStream = tRequest.GetRequestStream();
    //        dataStream.Write(byteArray, 0, byteArray.Length);
    //        dataStream.Close();

    //        WebResponse tResponse = tRequest.GetResponse();

    //        dataStream = tResponse.GetResponseStream();

    //        StreamReader tReader = new StreamReader(dataStream);

    //        String sResponseFromServer = tReader.ReadToEnd();

    //        //txtResponse.Text = sResponseFromServer; //printing response from GCM server.
    //        //txtStream.Text = postData.ToString().Trim();
    //        tReader.Close();
    //        dataStream.Close();
    //        tResponse.Close();
    //    }
    //}
}

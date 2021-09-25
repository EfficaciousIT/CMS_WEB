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

public partial class frmAttendanceMarkAdmin : DBUtility
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
            txtDate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")).Replace("-", "/");           
            fillGrid(txtDate.Text);
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
                        string regId = this.grdMarkAttendance.DataKeys[row.RowIndex].Values[1].ToString();

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
                        strAttendanceStatus = "Present";
                        string regId = this.grdMarkAttendance.DataKeys[row.RowIndex].Values[1].ToString();

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
                    strQry = "usp_MarkAttendance @command='InsertAdmin',@intUserType_id='5',@intUser_id='" + strStudent_id.Trim() + "',@dtDate='" + strDate.Trim() + "',@inTime='" + strInTime.Trim() + "',@outTime='" + strOutTime.Trim() + "',@status='" + strAttendanceStatus.Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                    k = sExecuteQuery(strQry);
                }
            }
            if (k > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Attendance marked Successfully')", true);
                fillGrid(txtDate.Text);
            }
        }
        catch
        {
        }

    }
    protected void fillGrid(string strDate)
    {
        try
        {

            strDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
            strDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
            strQry = "usp_MarkAttendance @command='BackDatAdmin',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@dtDate='" + strDate.Trim() + "'  ";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                btnUpdate.Visible = true;
                btnSMS.Visible = false;
                grdMarkAttendance.DataSource = dsObj;
                grdMarkAttendance.DataBind();

            }
            else
            {
                btnUpdate.Visible = false;
                btnSMS.Visible = false;
                grdMarkAttendance.DataSource = dsObj;
                grdMarkAttendance.DataBind();
            }
        }
        catch
        {
        }

    }
    protected void drpStaff_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        //txtDate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")).Replace("-", "/");
        fillGrid(txtDate.Text);
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
    protected void Status_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = (sender as DropDownList).NamingContainer as GridViewRow;

        string dataKey = this.grdMarkAttendance.DataKeys[row.RowIndex].Value.ToString();

        CheckBox chk = (CheckBox)row.FindControl("chkCtrl");

        chk.Checked = true;

        row.BackColor = System.Drawing.Color.Cornsilk;

    }
    protected void btnSMS_Click(object sender, EventArgs e)
    {

    }
}
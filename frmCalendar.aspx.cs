using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

public partial class frmCalendar : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    SqlDataAdapter daObj = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView5.DataSource = createDataTable();
        GridView5.DataBind();
        GetData();
    }
    private DataSet GetData()
    {
        strQry = "select dtDate as LoginDateTime,intime as Login,outtime as LogoutDateTime ,status as Present_Status from tblSchoolAttendance_trn";

        dsObj = sGetDataset(strQry);
        Session["Table"] = dsObj;
        return dsObj;

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        string Day_Date = e.Day.Date.ToShortDateString();

        try
        {
            if (((DataSet)Session["Table"] != null))
            {
                foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                {
                    string scheduledDate = Convert.ToDateTime(dr["LoginDateTime"]).ToShortDateString();
                    string scheduled_LoginTime = Convert.ToString(dr["Login"]);
                    string scheduled_LogoutTime = dr["LogoutDateTime"].ToString();
                    if (scheduled_LogoutTime == "")
                    {
                        scheduled_LogoutTime = "0";
                    }
                    else
                    {
                        scheduled_LogoutTime = Convert.ToString(dr["LogoutDateTime"]);
                    }

                    if (scheduledDate.Equals(Day_Date))
                    {
                        LinkButton lb = new LinkButton();
                        LiteralControl lc = new LiteralControl();
                        LiteralControl lc1 = new LiteralControl();
                        LiteralControl lc2 = new LiteralControl();

                        string status = Convert.ToString(dr["Present_Status"]);
                        if (status == "Early Reported")
                        {
                            lc.Text = @"<br/>" + "<font size=1 color=blue>Early</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Present")
                        {
                            lc.Text = @"<br/>" + "<font size=1 color=black>Present</font>" + "<br/>";
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Present</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#008B8B");

                        }
                        else if (status == "Early Reported Web")//manual
                        {
                            lc.Text = @"<br/>" + "<font size=1 color=black>Early(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Ontime Reported Web")//manual
                        {
                            lc.Text = @"<br/>" + "<font size=1 color=black>Ontime(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Early")//manual
                        {
                            lc.Text = @"<br/>" + "<font size=1 color=black>Early</font>" + "<br/>";
                            e.Cell.Controls.Add(lc);
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#708090");

                        }
                        else if (status == "Late Reported Web")//manual
                        {
                            lc.Text = @"<br/>" + "<font size=1 color=black>Late(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Present(From Web)")//attandance Issue
                        {
                            lc.Text = @"<br/>" + "<font size=1 color=black>Ontime(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Out Of Office")//out of office
                        {
                            lc.Text = @"<br/>" + "<font size=1 color=Yellow>Out Of Office</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Ontime Reported")
                        {
                            lc.Text = @"<br/>" + "<font size=1 color=black>Ontime</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Late")
                        {
                            lc.Text = @"<br/>" + "<font size=1 color=maroon>Late</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DAA520");

                        }
                        else if (status == "Absent")
                        {
                            lc1.Text = @"<br/>" + "<font size=1 color=black>Absent</font>";
                            e.Cell.Controls.Add(lc1);
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DC143C");

                        }
                        else if (status == "Leave Approving")
                        {
                            lc2.Text = @"<br/>" + "<font size=1 color=black> Leave Approving </font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc2);
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#9905af");
                        }

                    }
                    else
                    {

                        //e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7f16ab");
                    }

                }
            }

        }
        catch (Exception ex)
        {

        }
    }
    private object createDataTable()
    {
        DataTable dt = new DataTable();
        //dt.Columns.Add("RollNo");
        //dt.Columns.Add("Name");
        dt.Columns.Add("dtDate");
        dt.Columns.Add("vchday");
        dt.Columns.Add("reason");
        dt.Columns.Add("parentapproval");
        dt.Columns.Add("teacherapproval");

        DataRow dr3 = dt.NewRow();
        //dr3["RollNo"] = "01";
        //dr3["Name"] = "Ajay";
        dr3["dtDate"] = "06-08-2014";
        dr3["vchday"] = "Monday";
        dr3["reason"] = "Missed Bus";
        dr3["parentapproval"] = "Approved";
        dr3["teacherapproval"] = "Approved";

        dt.Rows.Add(dr3);

        DataRow dr4 = dt.NewRow();
        //dr4["RollNo"] = "01";
        //dr4["Name"] = "Ajay";
        dr4["dtDate"] = "08-08-2014";
        dr4["vchday"] = "Tuesday";
        dr4["reason"] = "Missed Bus";
        dr4["parentapproval"] = "Approved";
        dr4["teacherapproval"] = "Approved";

        dt.Rows.Add(dr4);

        return dt;
    }
}

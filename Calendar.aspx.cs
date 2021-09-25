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

public partial class Calendar : DBUtility
{
    public string controlToEdit;
    public string isPostBack;
    public string strQry = string.Empty;
    DataSet dsObj = new DataSet();

    public Calendar()
    {
        LoadComplete += new EventHandler(Page_LoadComplete);
    }
    void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            controlToEdit = Request.QueryString["controlID"];
            Session.Add("controlToEdit", controlToEdit);
            isPostBack = Request.QueryString["isPostBack"];
            Session.Add("isPostBack", isPostBack);
            
            try
            {
                Cal.SelectedDate = Cal.VisibleDate = Convert.ToDateTime(lblDate.Text);
            }
            catch
            {
                Cal.SelectedDate = Cal.VisibleDate = DateTime.Today;
            }
            // Fills in correct values for the dropdown menus
            FillCalendarChoices();
            SelectCorrectValues();
            
        }
        else
        {
            if (Session["controlToEdit"] != null)
                controlToEdit = (string)Session["controlToEdit"];
            if (Session["isPostBack"] != null)
                isPostBack = (string)Session["isPostBack"];
        }
    }
    private void FillMyStudy(string strdate)
    {
        strQry = "usp_MyDiary @command='MyDiaryStudy',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@Month='" + MonthSelect.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@dtDate='" + strdate.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {

            lblTodaysStudy1.Visible = true;
            lblTodaysStudy1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchcomment"]);

            if (dsObj.Tables[0].Rows.Count > 1)
            {
                lblTodaysStudy2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchcomment"]);
                lblTodaysStudy2.Visible = true;
            }

            if (dsObj.Tables[0].Rows.Count > 2)
            {
                lblTodaysStudy3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchcomment"]);
                lblTodaysStudy3.Visible = true;
            }

            if (dsObj.Tables[0].Rows.Count > 3)
            {
                lblTodaysStudy4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchcomment"]);
                lblTodaysStudy4.Visible = true;
            }

            if (dsObj.Tables[0].Rows.Count > 4)
            {
                lblTodaysStudy5.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["vchcomment"]);
                lblTodaysStudy5.Visible = true;
            }


           
        }
    }
    private void FillHomeWork(string strdate)
    {
        strQry = "usp_MyDiary @command='MyDiaryHomework',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@Month='" + MonthSelect.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@dtDate='" + strdate.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            lblHomework1.Visible = true;
            lblHomework1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchcomment"]);

            if (dsObj.Tables[0].Rows.Count > 1)
            {
                lblHomework2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchcomment"]);
                lblHomework2.Visible = true;
            }

            if (dsObj.Tables[0].Rows.Count > 2)
            {
                lblHomework3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchcomment"]);
                lblHomework3.Visible = true;
            }

            if (dsObj.Tables[0].Rows.Count > 3)
            {
                lblHomework4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchcomment"]);
                lblHomework4.Visible = true;
            }

            if (dsObj.Tables[0].Rows.Count > 4)
            {
                lblHomework5.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["vchcomment"]);
                lblHomework5.Visible = true;
            }

            
            //for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
            //{

            //}
        }
    }
    private void FillMessage(string strdate)
    {
        strQry = "usp_MyDiary @command='MyDiaryMessage',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@Month='" + MonthSelect.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@dtDate='" + strdate.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            lblMessage1.Visible = true;
            lblMessage1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchcomment"]);

            if (dsObj.Tables[0].Rows.Count > 1)
            {
                lblMessage2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchcomment"]);
                lblMessage2.Visible = true;
            }

            if (dsObj.Tables[0].Rows.Count > 2)
            {
                lblMessage3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchcomment"]);
                lblMessage3.Visible = true;
            }

            if (dsObj.Tables[0].Rows.Count > 3)
            {
                lblMessage4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchcomment"]);
                lblMessage4.Visible = true;
            }

            if (dsObj.Tables[0].Rows.Count > 4)
            {
                lblMessage5.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["vchcomment"]);
                lblMessage5.Visible = true;
            }


            //for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
            //{

            //}
        }
    }
    void Page_LoadComplete(object sender, System.EventArgs e)
    {
        //OKButton.OnClientClick = "javascript:window.opener.SetControlValue('" + this.controlToEdit + "','" + lblDate.Text + "','" + this.isPostBack + "');";
    }

    protected void FillCalendarChoices()
    {
        DateTime thisdate = (DateTime.Now).AddYears(5);

        // Fills in month values
        for (int x = 0; x < 12; x++)
        {
            // Loops through 12 months of the year and fills in each month value
            ListItem li = new ListItem(thisdate.ToString("MMMM"), thisdate.Month.ToString());
            MonthSelect.Items.Add(li);
            //to add next next month name to the monthselect drop downlist control like aug then sept and so on....
            thisdate = thisdate.AddMonths(1);
        }

        // Fills in year values and change y value to other years if necessary
        for (int y = 2000; y <= thisdate.Year; y++)
        {
            YearSelect.Items.Add(y.ToString());
        }
    }

    protected void SelectCorrectValues()
    {

        lblHomework1.Text = "";
        lblHomework2.Text = "";
        lblHomework3.Text = "";
        lblHomework4.Text = "";
        lblHomework5.Text = "";

        lblMessage1.Text = "";
        lblMessage2.Text = "";
        lblMessage3.Text = "";
        lblMessage4.Text = "";
        lblMessage5.Text = "";

        lblTodaysStudy1.Text = "";
        lblTodaysStudy2.Text = "";
        lblTodaysStudy3.Text = "";
        lblTodaysStudy4.Text = "";
        lblTodaysStudy5.Text = "";

        lblDate.Text = Convert.ToDateTime(Cal.SelectedDate.ToShortDateString()).ToString("MM/dd/yyyy");        
        datechosen.Value = lblDate.Text;
        MonthSelect.SelectedIndex = MonthSelect.Items.IndexOf(MonthSelect.Items.FindByValue(Cal.SelectedDate.Month.ToString()));
        YearSelect.SelectedIndex = YearSelect.Items.IndexOf(YearSelect.Items.FindByValue(Cal.SelectedDate.Year.ToString()));


        FillMyStudy(lblDate.Text);
        FillHomeWork(lblDate.Text);
        FillMessage(lblDate.Text);
    }

    protected void Cal_SelectionChanged(object sender, System.EventArgs e)
    {
        Cal.VisibleDate = Cal.SelectedDate;
        SelectCorrectValues();
    }

    protected void MonthSelect_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        Cal.SelectedDate = Cal.VisibleDate
            = new DateTime(Convert.ToInt32(YearSelect.SelectedItem.Value),
                           Convert.ToInt32(MonthSelect.SelectedItem.Value), 1); ;
        SelectCorrectValues();
    }

    protected void YearSelect_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        Cal.SelectedDate = Cal.VisibleDate
            = new DateTime(Convert.ToInt32(YearSelect.SelectedItem.Value),
                           Convert.ToInt32(MonthSelect.SelectedItem.Value), 1); ;
        SelectCorrectValues();
    }
}

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

public partial class frmMyDiaryCal : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strSubjectAll = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Session["Table"] = "";
            if (Convert.ToString(Session["Student_id"]) != "0")
            {
                fillSubjects(Convert.ToDateTime(DateTime.Now.Date).ToString("MM/dd/yyyy").Replace("-", "/"), Convert.ToString(Session["Standard_id"]));
            }
            else
            {
                fillNonTeacher(Convert.ToDateTime(DateTime.Now.Date).ToString("MM/dd/yyyy").Replace("-", "/"));
            }

            //try
            //{
            //    //Cal.SelectedDate = Cal.VisibleDate = Convert.ToDateTime(lblDate.Text);
            //}
            //catch
            //{
            //    //Cal.SelectedDate = Cal.VisibleDate = DateTime.Today;
            //}

            //  FillCalendarChoices();
            //  GetData();
        }
    }
    protected void fillNonTeacher(string strDate)
    {
        strQry = "Execute dbo.usp_MyDiary @command='fillNonTeacher',@intteacher_id='" + Convert.ToString(Session["User_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        //strQry = "Declare @str varchar(1000) SELECT @str= coalesce(@str + ',','') +'['+ a.vchsubjectname+']' FROM (select vchsubjectname from tblSubject_Master where intsubject_id in (select intsubject_id from tblLectureSchedules where intteacher_id='" + Convert.ToString(Session["User_id"]) + "') and intactive_flg=1 and intSchool_id=1) a select rtrim(ltrim(@str))  as subject";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            strSubjectAll = Convert.ToString(dsObj.Tables[0].Rows[0]["Subject"]);

            //strQry = "SELECT * FROM (select Convert(varchar,dtDatetime,103) as Date,isnull(vchsubjectname,'-') vchsubjectname ,isnull(vchcomment,'-') vchcomment,vchtype as [Remark],tblstandard_master.vchStandard_name+'/'+tblDivision_master.vchDivisionName as standard from tblSubject_Master left join tblmydiary on tblmydiary.intsubject_id=tblSubject_Master.intsubject_id inner join tblstandard_master on tblmydiary.intStandard_id=tblstandard_master.intStandard_id inner join tblDivision_master on tblmydiary.intDivision_id=tblDivision_master.intDivision_id and convert(varchar,dtdatetime,101)=convert(varchar,'" + strDate.Trim() + "',101) and tblmydiary.intTeacher_id='" + Convert.ToString(Session["User_id"]) + "' and vchtype is not null and vchType <> 'Message') as s PIVOT(max(vchcomment) FOR vchsubjectname IN (" + strSubjectAll.Trim() + "))AS p where [Remark] is not null";
            strQry = "SELECT * FROM (select Convert(varchar,dtDatetime,103) as Date,isnull(vchsubjectname,'-') vchsubjectname ,isnull(vchcomment,'-') vchcomment,vchtype as [Remark],tblstandard_master.vchStandard_name+'/'+tblDivision_master.vchDivisionName as standard from tblSubject_Master left join tblmydiary on tblmydiary.intsubject_id=tblSubject_Master.intsubject_id inner join tblstandard_master on tblmydiary.intStandard_id=tblstandard_master.intStandard_id inner join tblDivision_master on tblmydiary.intDivision_id=tblDivision_master.intDivision_id and MONTH(dtdatetime) = MONTH(dateadd(dd, -1, GetDate())) and tblmydiary.intTeacher_id='" + Convert.ToString(Session["User_id"]) + "' and vchtype is not null) as s PIVOT(max(vchcomment) FOR vchsubjectname IN (" + strSubjectAll.Trim() + "))AS p where [Remark] is not null";
           // strQry = "Execute dbo.usp_MyDiary @command='fillSubjectTeacher',@intTeacher_id='" + Convert.ToString(Session["User_id"]) + "',@vchsubjectname='" + strSubjectAll + "'";

            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
        }

    }
    protected void fillSubjects(string strDate, string strStandard)
    {
        //strQry = "Declare @str varchar(1000) SELECT @str= coalesce(@str + ',','') +'['+ a.vchsubjectname+']' FROM (SELECT DISTINCT vchsubjectname from tblSubject_Master where intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "'  and intactive_flg=1 and intSchool_id='" + Convert.ToString(Session["School_id"]) + "') a select rtrim(ltrim(@str))  as subject";
        //strQry = "Declare @str varchar(1000) SELECT @str= coalesce(@str + ',','') +'['+ a.vchsubjectname+']' FROM (SELECT DISTINCT vchsubjectname from tblSubject_Master where intstandard_id='" + strStandard.Trim() + "'  and intactive_flg=1 and intSchool_id='" + Convert.ToString(Session["School_id"]) + "') a select rtrim(ltrim(@str))  as subject";
        strQry = "Execute dbo.usp_MyDiary @command='fillSubjects',@intstandard_id='" + strStandard.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            strSubjectAll = Convert.ToString(dsObj.Tables[0].Rows[0]["Subject"]);

            if (Convert.ToString(Session["UserType_id"]) == "1" || Convert.ToString(Session["UserType_id"]) == "2")
            {
                //strQry = "SELECT * FROM ( select Convert(varchar,dtDatetime,103) as Date, isnull(vchsubjectname,'-') vchsubjectname ,isnull(vchcomment,'-') vchcomment,vchtype as [Remark] from tblSubject_Master left join tblmydiary on tblmydiary.intsubject_id=tblSubject_Master.intsubject_id and convert(varchar,dtdatetime,101)=convert(varchar,'" + strDate.Trim() + "',101) and tblmydiary.intstudent_id='" + Convert.ToString(Session["Student_id"]) + "' and vchtype is not null ) as s PIVOT(max(vchcomment) FOR vchsubjectname IN (" + strSubjectAll.Trim() + "))AS p where [Remark] is not null";
                strQry = "SELECT * FROM ( select Convert(varchar,dtDatetime,103) as Date, isnull(vchsubjectname,'-') vchsubjectname ,isnull(vchcomment,'-') vchcomment,vchtype as [Remark] from tblSubject_Master left join tblmydiary on tblmydiary.intsubject_id=tblSubject_Master.intsubject_id and MONTH(dtdatetime) = MONTH(dateadd(dd, -1, GetDate())) and tblmydiary.intstudent_id='" + Convert.ToString(Session["Student_id"]) + "' and vchtype is not null ) as s PIVOT(max(vchcomment) FOR vchsubjectname IN (" + strSubjectAll.Trim() + "))AS p where [Remark] is not null order by Date asc";
            }
            else
            {
                fillNonTeacher(strDate);
            }

            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
        }
    }
}
    //protected void MonthSelect_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Cal.SelectedDate = Cal.VisibleDate
    //        = new DateTime(Convert.ToInt32(YearSelect.SelectedItem.Value),
    //                       Convert.ToInt32(MonthSelect.SelectedItem.Value), 1);

    //    Session["Table"] = "";
    //    if (Convert.ToString(Session["UserType_id"]) == "1" || Convert.ToString(Session["UserType_id"]) == "2")
    //    {
    //        strQry = "select distinct(convert(varchar(50),dtdatetime,121)) as dtdatetime from tblMyDiary where intstudent_id='" + Convert.ToString(Session["Student_id"]) + "' and month(dtdatetime)='" + MonthSelect.SelectedValue.Trim() + "'";
    //    }
    //    else
    //    {
    //        strQry = "select distinct(convert(varchar(50),dtdatetime,121)) as dtdatetime from tblMyDiary where intdivision_id='" + Convert.ToString(Session["Division_id"]) + "' and month(dtdatetime)='" + MonthSelect.SelectedValue.Trim() + "'";
    //    }
    //    dsObj = sGetDataset(strQry);
    //    if (dsObj.Tables[0].Rows.Count > 0)
    //    {
    //        Session["Table"] = dsObj;
    //    }
    //    else
    //    {
    //        Session["Table"] = dsObj;
    //    }
    //}

    //private DataSet GetData()
    //{
    //    try
    //    {
    //        Session["Table"] = "";
    //        if (Convert.ToString(Session["UserType_id"]) == "1" || Convert.ToString(Session["UserType_id"]) == "2")
    //        {
    //            strQry = "select distinct(convert(varchar(50),dtdatetime,121)) as dtdatetime from tblMyDiary where intstudent_id='" + Convert.ToString(Session["Student_id"]) + "' and month(dtdatetime)='" + MonthSelect.SelectedValue.Trim() + "'";
    //        }
    //        else
    //        {
    //            //strQry = "select distinct(convert(varchar(50),dtdatetime,121)) as dtdatetime from tblMyDiary where intdivision_id='" + Convert.ToString(Session["Division_id"]) + "' and month(dtdatetime)='" + MonthSelect.SelectedValue.Trim() + "'";
    //            strQry = "select distinct(convert(varchar(50),dtdatetime,121)) as dtdatetime from tblMyDiary where intTeacher_id='" + Convert.ToString(Session["User_id"]) + "' and month(dtdatetime)='" + MonthSelect.SelectedValue.Trim() + "'";
    //        }
            
    //        dsObj = sGetDataset(strQry);
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            Session["Table"] = dsObj;
    //        }
    //        else
    //        {
    //            Session["Table"] = dsObj;
    //        }
    //        return dsObj;
    //    }
    //    catch (Exception)
    //    {
    //        return dsObj;
    //    }


   // }
    //protected void YearSelect_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Cal.SelectedDate = Cal.VisibleDate
    //        = new DateTime(Convert.ToInt32(YearSelect.SelectedItem.Value),
    //                       Convert.ToInt32(MonthSelect.SelectedItem.Value), 1);
    //}
    //protected void Cal_SelectionChanged(object sender, EventArgs e)
    //{
    //    Cal.VisibleDate = Cal.SelectedDate;
    //    SelectCorrectValues();
    //}
    //protected void FillCalendarChoices()
    //{   
    //    for (int y = 2015; y <= 2016; y++)
    //    {
    //        YearSelect.Items.Add(y.ToString());
    //    }

    //    MonthSelect.SelectedValue = Convert.ToString(DateTime.Now.Month);       

    //}
    //protected void SelectCorrectValues()
    //{     
    //    lblDate.Text = Convert.ToDateTime(Cal.SelectedDate.ToShortDateString()).ToString("MM/dd/yyyy");
    //    datechosen.Value = lblDate.Text;
    //    MonthSelect.SelectedIndex = MonthSelect.Items.IndexOf(MonthSelect.Items.FindByValue(Cal.SelectedDate.Month.ToString()));
    //    YearSelect.SelectedIndex = YearSelect.Items.IndexOf(YearSelect.Items.FindByValue(Cal.SelectedDate.Year.ToString()));
    //    fillSubjects(lblDate.Text.Replace("-","/"),Convert.ToString(Session["Standard_id"]));      
    //}
    //protected void Cal_DayRender(object sender, DayRenderEventArgs e)
    //{
    //    int Year = DateTime.Now.Year;
    //    int Month = DateTime.Now.Month;
    //    string Day_Date = e.Day.Date.ToShortDateString();
    //    if (((DataSet)Session["Table"] != null) && ((DataSet)Session["Table"]).Tables[0].Rows.Count > 0)
    //    {
    //        foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
    //        {
    //            string scheduledDate = Convert.ToDateTime(dr["dtdatetime"]).ToShortDateString();                
                               
    //            if (scheduledDate.Equals(Day_Date))
    //            {
    //                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");
    //            }
    //            else
    //            {

    //                //if (e.Day.Date<=DateTime.Now.Date)
    //                //{
    //                //    //lc1.Text = @"<br/>" + "<font size=1 color=black>Absent</font>";

    //                //    e.Cell.ToolTip = "Absent";
    //                //    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");

    //                //}
    //            }

    //        }

    //   }
   // }

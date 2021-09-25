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

public partial class frmViewResult : DBUtility
{
    DataSet dsObj = new DataSet();
    string strQry = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lblTile = new Label();
        //lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        //lblTile.Visible = true;
        //lblTile.Text = "Shortlisting";
        if (!IsPostBack)
        {
            FillStandard();
            
        }
    }
    protected void FillStandard()
    {
        strQry = "usp_TestSchedule @command='selectStandard',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(drpStandard, strQry, "vchStandard_name", "intStandard_id");        
    }

    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "spMarksUpload @command='ResultCategoryWise',@intStandard_id='" + drpStandard.SelectedValue + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvCandiateCount.DataSource = dsObj;
            grvCandiateCount.DataBind();
            //tblmarks.Visible = false;
        }
        else
        {
            grvCandiateCount.DataSource = dsObj;
            grvCandiateCount.DataBind();
        }

        FillMarksGridDynamically();
    }
    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
        //for (int i = 0; i < grvMarks.Rows.Count; i++)
        //{
        //    string strColname= Convert.ToString(grvMarks.HeaderRow.Cells[0].Text);
            
            
        //    TextBox txtSub3 = (TextBox)grvMarks.Rows[i].Cells[0].FindControl("txtSub3");
        //    TextBox txtSub4 = (TextBox)grvMarks.Rows[i].Cells[1].FindControl("txtSub4");
        //    TextBox txtSub5 = (TextBox)grvMarks.Rows[i].Cells[2].FindControl("txtSub5");
        //    TextBox txtSub6 = (TextBox)grvMarks.Rows[i].Cells[3].FindControl("txtSub6");
        //    TextBox txtSub7 = (TextBox)grvMarks.Rows[i].Cells[4].FindControl("txtSub7");
            
        //}

        DataTable dt = new DataTable();
        dt.Columns.Add("intTest_id", typeof(string));
        dt.Columns.Add("vchfathermobile", typeof(string));
        dt.Columns.Add("candiateName", typeof(string));
        dt.Columns.Add("Marks", typeof(string));
        dt.Columns.Add("castType", typeof(string));
        for (int i = 0; i < grvMarks.Columns.Count-2; i++)
        {
            string strColname = Convert.ToString(grvMarks.HeaderRow.Cells[i+2].Text);
            TextBox txtSub3 = (TextBox)grvMarks.Rows[0].Cells[i+2].FindControl("txtSub3");
            TextBox txtSub4 = (TextBox)grvMarks.Rows[0].Cells[i+2].FindControl("txtSub4");
            TextBox txtSub5 = (TextBox)grvMarks.Rows[0].Cells[i+2].FindControl("txtSub5");
            TextBox txtSub6 = (TextBox)grvMarks.Rows[0].Cells[i+2].FindControl("txtSub6");
            TextBox txtSub7 = (TextBox)grvMarks.Rows[0].Cells[i+2].FindControl("txtSub7");

            if (i == 0)
            {
                if (txtSub3.Text != "")
                {
                    strQry = "select top " + txtSub3.Text.Trim() + " intTest_id,vchfathermobile,candiateName,(marks1+marks2+marks3+marks4+marks5) as Marks,castType from tblTestNMarks  inner join tblRegistration on tblTestNMarks.intregistration_id=intrf_id where castType='" + strColname + "' and ExamAttendance='Y' and shortlist is null order by Marks desc";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j <= dsObj.Tables[0].Rows.Count - 1; j++)
                        {
                            dt.Rows.Add(Convert.ToString(dsObj.Tables[0].Rows[j]["intTest_id"]), Convert.ToString(dsObj.Tables[0].Rows[j]["vchfathermobile"]), Convert.ToString(dsObj.Tables[0].Rows[j]["candiateName"]), Convert.ToString(dsObj.Tables[0].Rows[j]["Marks"]), Convert.ToString(dsObj.Tables[0].Rows[j]["castType"]));
                        }
                    }
                }
            }

            if (i == 1)
            {
                if (txtSub4.Text != "")
                {
                    strQry = "select top " + txtSub4.Text.Trim() + " intTest_id,vchfathermobile,candiateName,(marks1+marks2+marks3+marks4+marks5) as Marks,castType from tblTestNMarks  inner join tblRegistration on tblTestNMarks.intregistration_id=intrf_id where castType='" + strColname + "' and ExamAttendance='Y' and shortlist is null order by Marks desc";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j <= dsObj.Tables[0].Rows.Count - 1; j++)
                        {
                            dt.Rows.Add(Convert.ToString(dsObj.Tables[0].Rows[j]["intTest_id"]), Convert.ToString(dsObj.Tables[0].Rows[j]["vchfathermobile"]), Convert.ToString(dsObj.Tables[0].Rows[j]["candiateName"]), Convert.ToString(dsObj.Tables[0].Rows[j]["Marks"]), Convert.ToString(dsObj.Tables[0].Rows[j]["castType"]));
                        }
                    }
                }
            }

            if (i == 2)
            {
                if (txtSub5.Text != "")
                {
                    strQry = "select top " + txtSub5.Text.Trim() + " intTest_id,vchfathermobile,candiateName,(marks1+marks2+marks3+marks4+marks5) as Marks,castType from tblTestNMarks  inner join tblRegistration on tblTestNMarks.intregistration_id=intrf_id where castType='" + strColname + "' and ExamAttendance='Y' and shortlist is null order by Marks desc";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j <= dsObj.Tables[0].Rows.Count - 1; j++)
                        {
                            dt.Rows.Add(Convert.ToString(dsObj.Tables[0].Rows[j]["intTest_id"]), Convert.ToString(dsObj.Tables[0].Rows[j]["vchfathermobile"]), Convert.ToString(dsObj.Tables[0].Rows[j]["candiateName"]), Convert.ToString(dsObj.Tables[0].Rows[j]["Marks"]), Convert.ToString(dsObj.Tables[0].Rows[j]["castType"]));
                        }
                    }
                }
            }

            if (i == 3)
            {
                if (txtSub6.Text != "")
                {
                    strQry = "select top " + txtSub6.Text.Trim() + " intTest_id,vchfathermobile,candiateName,(marks1+marks2+marks3+marks4+marks5) as Marks,castType from tblTestNMarks  inner join tblRegistration on tblTestNMarks.intregistration_id=intrf_id where castType='" + strColname + "' and ExamAttendance='Y' and shortlist is null order by Marks desc";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j <= dsObj.Tables[0].Rows.Count - 1; j++)
                        {
                            dt.Rows.Add(Convert.ToString(dsObj.Tables[0].Rows[j]["intTest_id"]), Convert.ToString(dsObj.Tables[0].Rows[j]["vchfathermobile"]), Convert.ToString(dsObj.Tables[0].Rows[j]["candiateName"]), Convert.ToString(dsObj.Tables[0].Rows[j]["Marks"]), Convert.ToString(dsObj.Tables[0].Rows[j]["castType"]));
                        }
                    }
                }
            }

            if (i == 4)
            {
                if (txtSub7.Text != "")
                {
                    strQry = "select top " + txtSub7.Text.Trim() + " intTest_id,vchfathermobile,candiateName,(marks1+marks2+marks3+marks4+marks5) as Marks,castType from tblTestNMarks  inner join tblRegistration on tblTestNMarks.intregistration_id=intrf_id where castType='" + strColname + "' and ExamAttendance='Y' and shortlist is null order by Marks desc";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j <= dsObj.Tables[0].Rows.Count - 1; j++)
                        {
                            dt.Rows.Add(Convert.ToString(dsObj.Tables[0].Rows[j]["intTest_id"]), Convert.ToString(dsObj.Tables[0].Rows[j]["vchfathermobile"]), Convert.ToString(dsObj.Tables[0].Rows[j]["candiateName"]), Convert.ToString(dsObj.Tables[0].Rows[j]["Marks"]), Convert.ToString(dsObj.Tables[0].Rows[j]["castType"]));
                        }
                    }
                }
            }
            

        }

        grdCandidate.DataSource = dt;
        grdCandidate.DataBind();
    }
    
    



    public void FillMarksGridDynamically()
    {
        try
        {
            int CountSubject = 0;
            DataTable grid = new DataTable();
            strQry = "select vchcategory_name from tblCastDet where intschool_id='1'";
            dsObj = sGetDataset(strQry);
            CountSubject = Convert.ToInt32(dsObj.Tables[0].Rows.Count);

            for (int i = 0; i < CountSubject; i++)
            {
                grvMarks.Columns[i + 2].HeaderText = Convert.ToString(dsObj.Tables[0].Rows[i]["vchcategory_name"]);
                grvMarks.Columns[i + 2].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            }

            for (int i = grvMarks.Columns.Count - 1; i > CountSubject + 1; i--)
            {
                grvMarks.Columns.RemoveAt(i);                
            }
           

            grid.Rows.Add(grid.NewRow());
            FillMarksDataGrid();
            
        }
        catch(Exception ex)
        {

        }
    }
    public void FillMarksDataGrid()
    {
        try
        {
            strQry = "spMarksUpload @command='ResultCategoryWise',@intStandard_id='5',@intschool_id='1'";
            dsObj = sGetDataset(strQry);
            grvMarks.DataSource = dsObj;
            grvMarks.DataBind();            
        }
        catch
        {

        }
    }
    protected void grvMarks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 1; i < grvMarks.Columns.Count + 1; i++)
                {
                    TextBox txtmark = (TextBox)grvMarks.Rows[e.Row.RowIndex - 1].FindControl("txtSub" + i.ToString());                 
                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //  e.Row.Style.Add("height", "100px");
            }
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
    protected void btnSub_Click(object sender, EventArgs e)
    {
        int k = 0;
        for (int i = 0; i < grdCandidate.Rows.Count; i++)
        {
            Label Label = (Label)grdCandidate.Rows[i].Cells[0].FindControl("lblTestID");
            Label lblFatherMobile = (Label)grdCandidate.Rows[i].Cells[0].FindControl("lblFatherMobile");

            

            strQry = "spMarksUpload @command='Approval',@intTest_id='" + Label.Text.Trim() + "'";
            k = sExecuteQuery(strQry);
            if (k > 0)
            {
                POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + lblFatherMobile.Text.Trim() + "&msg=Congratulation, your child has been shortlisted. Please complete the admission process&alert=1", "");
            }

        }
        if (k > 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Candidate selected');window.location ='frmViewResult.aspx';", true);
        }
    }
    
}

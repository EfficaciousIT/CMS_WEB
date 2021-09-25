using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Net;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;

public partial class frmPayment : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {
                    fillStudent();
                    Clear();
                    fillDurationType();
                    fillTotalFee();

                    // NameValueCollection nvc = Request.Form;
                    //string Vmmp_txn = nvc["mmp_txn"].ToString();
                    //string VpaymentStatus = nvc["f_code"].ToString();
                    //string Vmer_txn = Request.Form["mer_txn"];

                    //   if (VpaymentStatus == "Ok")
                    //    {
                    //      //"Transaction proceed successfully."
                    //    }
                    //    else
                    //    {
                    //    //"Transaction Failed.";
                    //    }
                    
                }
            }
            else
            {
                Response.Redirect("~\\Index.aspx", false);
            }
        }
        catch
        {

        }
    }
    private static string EncodeTo64UTF8(String str)
    {
        byte[] toEncode2Bytes = System.Text.Encoding.UTF8.GetBytes(str);
        string sReturnValue = System.Convert.ToBase64String(toEncode2Bytes);
        return sReturnValue;
    }
    protected void SendPostRequestNew()
    {
        string strDate = Convert.ToDateTime(DateTime.Now).ToString();
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://payment.atomtech.in/paynetz/epi/fts");

        request.Method = "POST";
        //------
        request.ContentType = "application/x-www-form-urlencoded";
        request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; CK={CVxk71YSfgiE6+6P6ftT7lWzblrdvMbRqavYf/6OcMIH8wfE6iK7TNkcwFAsxeChX7qRAlQhvPWso3KI6Jthvnvls9scl+OnAEhsgv+tuvs=}; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        string postData = "login=19538&pass=India@123&ttype=NBFundTransfer&prodid=EFFICACIOUS&amt=" + Convert.ToString(txtEnterAmt.Text.Trim()) + "&txncurr=INR&txnscamt=0&clientcode=007=&txnid=" + Convert.ToString(Session["Student_id"]) + "&date=25/06/2012%2012:23:23&custacc=123456789012&ru=http://e-smarts.net";

        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

        request.ContentType = "application/x-www-form-urlencoded";

        request.ContentLength = byteArray.Length;
        request.AllowAutoRedirect = true;

        request.Proxy.Credentials = CredentialCache.DefaultCredentials;

        Stream dataStream = request.GetRequestStream();

        dataStream.Write(byteArray, 0, byteArray.Length);

        dataStream.Close();

        WebResponse response = request.GetResponse();

        XmlDocument objXML = new XmlDocument();

        dataStream = response.GetResponseStream();

        objXML.Load(dataStream);

        string TxnId = objXML.DocumentElement.ChildNodes[0].ChildNodes[0].ChildNodes[2].InnerText;

        string Token = objXML.DocumentElement.ChildNodes[0].ChildNodes[0].ChildNodes[3].InnerText;
        string txnData = "ttype=NBFundTransfer&txnStage=1&tempTxnId=" + TxnId + "&token=" + Token;

        dataStream.Close();
        response.Close();
        Response.Redirect("https://payment.atomtech.in/paynetz/epi/fts?" + txnData);
    }
    public void fillStudent()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_SchoolMakePayment @type='getStudents',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudent"]);

            }
           
        }
        catch
        {

        }
    }
    public void fillTotalFee()
    {
        try
        {
            strQry = "exec usp_SchoolMakePayment @type='getTotalFee',@intStandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtTotalFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalFee"]);
            }
            FillTransGrid();
        }
        catch
        {
        }
    }
    public void fillDurationType()
    {
        try
        {
            string qry = "exec usp_FeesAssignSTD @type='GetDuration',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlDurationType, qry, "vchDuration", "intDuration_Id");
        }
        catch
        {
        }
    }

    public void fillpartType()
    {
        try
        {
            string qry = "exec usp_FeesAssignSTD @type='GetDurType',@intTutionId='" + Convert.ToString(ddlFeeHead.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(qry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //txtDurationType.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["feeType"]);
            }
        }
        catch
        {
        }
    }

    public void fillMonths()
    {
        try
        {
            string qry = "exec usp_FeesAssignSTD @type='GetMonths',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlMonths, qry, "MonthName", "MonthNo");
            if (ddlMonths.Items.Count > 1)
                ddlMonths.Items.Add(new ListItem("All", "-1"));
            else
                ddlMonths.DataSource = null;
        }
        catch
        {
        }
    }
   
     public void fillHead()
    {
        try
        {
            strQry = "";
            int sum = 0;
            strQry = "exec usp_SchoolMakePayment @type='FillHeadAmt1',@intStandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@feeType='" + Convert.ToString(ddlDurationType.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                gvHead.DataSource = dsObj;
                gvHead.DataBind();
                for (int i = 0; i < gvHead.Rows.Count; i++)
                {
                    sum += int.Parse(gvHead.Rows[i].Cells[2].Text);
                }
                txtEnterAmt.Text = sum.ToString();
            }
            else
            {
                gvHead.DataSource = dsObj;
                gvHead.DataBind();
                for (int i = 0; i < gvHead.Rows.Count; i++)
                {
                    sum += int.Parse(gvHead.Rows[i].Cells[2].Text);
                }
                txtEnterAmt.Text = sum.ToString();
            }
           

        }
        catch
        {

        }
    }
     protected void ddlFeeHead_SelectedIndexChanged(object sender, EventArgs e)
     {
         fillpartType();
     }
     protected void btnSubmit_Click(object sender, EventArgs e)
     {
         try
         {
             SendPostRequestNew();
         }
         catch
         {

         }
     }
     public void FillTransGrid()
     {
         try
         {
             int sum = 0;
             strQry = "";
             strQry = "exec usp_SchoolMakePayment @type='FillTransGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
             dsObj = sGetDataset(strQry);
             grdTrans.DataSource = dsObj;
             grdTrans.DataBind();

             for (int i = 0; i < grdTrans.Rows.Count; i++)
             {
                 sum += int.Parse(grdTrans.Rows[i].Cells[4].Text);
             }
             lblTotal.Text = sum.ToString();           
         }
         catch
         {

         }
     }

  
     public void Clear()
     {
         try
         {             
             txtTotalFee.Text = "";
             ddlFeeHead.ClearSelection();           
             txtHeadAmt.Text = "";
             txtEnterAmt.Text = "";
           
         }
         catch
         {

         }
     }
     protected void btnReport_Click(object sender, EventArgs e)
     {
         DataSet dsObj = new DataSet();
         strQry = "";
         strQry = "exec usp_SchoolMakePayment @type='CReportFeeTrans',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstudent_id='" + Convert.ToString( Session["Student_id"]) + "'";
         dsObj = sGetDataset(strQry);
         Session["rptFee"] = dsObj;
         Response.Redirect("frmFeeReport.aspx", true);
     }
     protected void grdTrans_RowDeleting(object sender, GridViewDeleteEventArgs e)
     {
         try
         {
             Session["intID"] = Convert.ToString(grdTrans.DataKeys[e.RowIndex].Value);
             strQry = "";
             strQry = "exec [usp_SchoolMakePayment] @type='delete',@intID='" + Convert.ToString(Session["intID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
             if (sExecuteQuery(strQry) != -1)
             {
                 FillTransGrid();
                 MessageBox("Transaction Deleted Successfully!");
             }
         }
         catch
         {

         }
     }
     protected void ddlDurationType_SelectedIndexChanged(object sender, EventArgs e)
     {
         fillHead();
         lblMonths.Visible = true;
         ddlMonths.Visible = true;
         if (ddlDurationType.SelectedValue == "1" || ddlDurationType.SelectedValue == "5")
         {
             fillMonths();
         }
         if (ddlDurationType.SelectedValue == "2" || ddlDurationType.SelectedValue == "6")
         {
             fillQuarterly();
         }
         if (ddlDurationType.SelectedValue == "3" || ddlDurationType.SelectedValue == "7")
         {
             fillHalfYearly();
         }
         if (ddlDurationType.SelectedValue == "4" || ddlDurationType.SelectedValue == "8")
         {
             fillAnnualy();
         }
     }
     public void fillQuarterly()
     {
         try
         {
             string qry = "exec usp_FeesAssignSTD @type='fillQuarterly',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
             sBindDropDownList(ddlMonths, qry, "vchMonth", "intQuartarly_id");
         }
         catch
         {
         }
     }
     public void fillHalfYearly()
     {
         try
         {
             string qry = "exec usp_FeesAssignSTD @type='fillHalfYearly',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
             sBindDropDownList(ddlMonths, qry, "vchMonth", "int_half_yearly_id");

             if (ddlMonths.Items.Count > 1)
                 ddlMonths.Items.Add(new ListItem("All", "-1"));
             else
                 ddlMonths.DataSource = null;
         }
         catch
         {
         }
     }
     public void fillAnnualy()
     {
         try
         {
             string qry = "exec usp_FeesAssignSTD @type='fillAnnualy',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
             sBindDropDownList(ddlMonths, qry, "vchMonth", "intYearly_id");
         }
         catch
         {
         }
     }
    
     protected void ddlMonths_SelectedIndexChanged(object sender, EventArgs e)
     {
         if (ddlDurationType.SelectedValue == "1" || ddlDurationType.SelectedValue == "5")
         {
             string qry1 = "exec usp_FeesAssignSTD @type='GetMonths',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
             dsObj = sGetDataset(qry1);
             Session["AllMonth"] = dsObj;
             if (ddlMonths.SelectedValue == "-1")
             {
                 txtEnterAmt.Text = Convert.ToString(Convert.ToInt32(txtEnterAmt.Text) * Convert.ToInt32("12"));
             }
             else
             {
                 fillHead();
             }
             
         }
         if (ddlDurationType.SelectedValue == "2" || ddlDurationType.SelectedValue == "6")
         {
             string qry2 = "exec usp_FeesAssignSTD @type='fillQuarterly',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
             dsObj = sGetDataset(qry2);
             Session["AllQuarterly"] = dsObj;
             if (ddlMonths.SelectedValue == "-1")
             {
                 txtEnterAmt.Text = Convert.ToString(Convert.ToInt32(txtEnterAmt.Text) * Convert.ToInt32("4"));
             }
             else
             {
                 fillHead();
             }
         }
         if (ddlDurationType.SelectedValue == "3" || ddlDurationType.SelectedValue == "7")
         {
             string qry3 = "exec usp_FeesAssignSTD @type='fillHalfYearly',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
             dsObj = sGetDataset(qry3);
             Session["AllHalfYearly"] = dsObj;
             if (ddlMonths.SelectedValue == "-1")
             {
                 txtEnterAmt.Text = Convert.ToString(Convert.ToInt32(txtEnterAmt.Text) * Convert.ToInt32("2"));
             }
             else
             {
                 fillHead();
             }
         }
     }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text;
using System.Net;

public partial class frmDivisionWiseAllotment : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    string strStudent_id = string.Empty;
    string strMaxID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {
                    TabPanel1.Enabled = false;
                    //fillAcademicYear();
                    FillSTD();
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
    
    //public void fillAcademicYear()
    //{
    //    try
    //    {
    //        strQry = "";
    //        strQry = "exec usp_DivisionWiseAllotment @type='fillAcademicYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
    //        sBindDropDownList(ddlAcademiYear, strQry, "AcademicYear", "intAcademic_id");                
    //    }
    //    catch
    //    {

    //    }
    //}
    public void FillSTD()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_DivisionWiseAllotment @type='FillSTD',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");          
        }
        catch
        {

        }
    }
    protected void ddlAcademiYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillSTD();
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblDIV.Visible = true;
        ddlDivision.Visible = true;
        FillDiv();
        FillGrid();
    }
    public void FillDiv()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_DivisionWiseAllotment @type='FillDiv',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstandard_id='" + ddlSTD.SelectedValue + "' ";
            sBindDropDownList(ddlDivision, strQry, "vchDivisionName", "intDivision_id");
        }
        catch
        {

        }
    }    
    public void FillGrid()
    {
        try
        {
            strQry = "";
            //strQry = "exec usp_DivisionWiseAllotment @type='FillGrid',@intAcademic_id='" + Convert.ToString(ddlAcademiYear.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            strQry = "exec usp_DivisionWiseAllotment @type='FillGrid',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        catch
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlSTD.SelectedValue == "0")
        {
            MessageBox("Please Select Standard!");
            ddlSTD.Focus();
            return;
        }
        if (ddlDivision.SelectedValue == "0")
        {
            MessageBox("Please Select Division!");
            ddlDivision.Focus();
            return;
        }
        try
        {
            if (btnSubmit.Text == "Assign")
            {
                foreach (GridViewRow gvrow in grvDetail.Rows)
                {                   
                    CheckBox chkRow = (gvrow.Cells[2].FindControl("chkCtrl") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string strStudent_id = this.grvDetail.DataKeys[gvrow.RowIndex].Values[0].ToString();
                        string Standard_id = this.grvDetail.DataKeys[gvrow.RowIndex].Values[1].ToString();

                        strQry = "exec [usp_DivisionWiseAllotment] @type='UpdateDivision',@intStandard_id='" + Standard_id + "',@intDivision_id='" + Convert.ToString(ddlDivision.SelectedValue) + "',@intStudent_id='" + strStudent_id + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
                        sExecuteQuery(strQry);
                       // POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + txtFatherMobile.Text.Trim() + "&msg=Thank you for enquiry for your child " + txtCondidatename.Text.Trim() + " for " + drpStandard.Text.Trim() + "th Std. Your enquiry no : " + txtInquiryNo.Text.Trim() + ".you may collect registration form from school&alert=1", "");
                       // MessageBox("Thank you for Inquiry. School Administrator will contact you soon.");
                    }
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Division Alloted Successfully');window.location ='frmDivisionWiseAllotment.aspx';", true);
                            
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
}
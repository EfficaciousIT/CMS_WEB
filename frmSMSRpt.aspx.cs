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
using System.Collections.Generic;
using System.IO;
using System.Text;

public partial class frmSMSRpt : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strFromDate = string.Empty;
    string strToDate = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Text == "")
        {
            MessageBox("Please Select From Date!");
            txtFromDate.Focus();
            return;
        }
        if (txtToDate.Text == "")
        {
            MessageBox("Please Select To Date!");
            txtToDate.Focus();
            return;
        }

        strFromDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").Replace("-","/");
        strToDate = Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strQry = "usp_SMSReport @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@FromDate='" + strFromDate.Trim() + "',@ToDate='" + strToDate.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            int sum = 0;
            gvSMS.DataSource = dsObj;
            gvSMS.DataBind();
            for (int i = 0; i < gvSMS.Rows.Count; i++)
            {
                sum += int.Parse(gvSMS.Rows[i].Cells[2].Text);
            }
            lblTotal.Text = sum.ToString();
        }
        else
        {
            int sum = 0;
            gvSMS.DataSource = dsObj;
            gvSMS.DataBind();
            for (int i = 0; i < gvSMS.Rows.Count; i++)
            {
                sum += int.Parse(gvSMS.Rows[i].Cells[2].Text);
            }
            lblTotal.Text = sum.ToString();
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Text == "")
        {
            MessageBox("Please Select From Date!");
            txtFromDate.Focus();
            return;
        }
        if (txtToDate.Text == "")
        {
            MessageBox("Please Select To Date!");
            txtToDate.Focus();
            return;
        }
        btnSearch_Click(null, null);
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gvSMS.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
}

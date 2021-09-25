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

public partial class frmbuspaymentdisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = createDataTable();
        GridView1.DataBind();
    }
    private object createDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("route");
        dt.Columns.Add("Startpoint");
        dt.Columns.Add("endpoint");
        dt.Columns.Add("btype");
        dt.Columns.Add("amount");
        dt.Columns.Add("duedate");        


        DataRow dr = dt.NewRow();
        dr["route"] = "Vashi-Belapur";
        dr["Startpoint"] = "Vashi";
        dr["endpoint"] = "Belapur";
        dr["btype"] = "Monthly";
        dr["amount"] = "300";
        dr["duedate"] = "10/09/2014";        
        dt.Rows.Add(dr);
        return dt;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        tdpayment.Visible = true;
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        drppayment.Items.Clear();
        drppayment.Items.Insert(0, "---Select---");
        drppayment.Items.Insert(1, "SBI Debit card");
        drppayment.Items.Insert(2, "ICICI Debit card");
        drppayment.Items.Insert(3, "PBN Debit card");
        drppayment.Items.Insert(4, "HDFC Debit card");
        drppayment.Items.Insert(5, "AXIX Debit card");
        drppayment.Items.Insert(6, "INDIAN Debit card");        

    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        drppayment.Items.Clear();
        drppayment.Items.Insert(0, "---Select---");
        drppayment.Items.Insert(1, "Master credit card");
        drppayment.Items.Insert(2, "VISA credit card");        
    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        drppayment.Items.Clear();
        drppayment.Items.Insert(0, "---Select---");
        drppayment.Items.Insert(1, "Allahabad Bank");
        drppayment.Items.Insert(2, "Andhra Bank");
        drppayment.Items.Insert(3, "Bank of Baroda");
        drppayment.Items.Insert(4, "Bank of India");
        drppayment.Items.Insert(5, "Bank of Maharashtra");
        drppayment.Items.Insert(6, "Bhartiya Mahila Bank");
        drppayment.Items.Insert(7, "Canara Bank");
        drppayment.Items.Insert(8, "Central Bank of India");
        drppayment.Items.Insert(9, "Corporation Bank");
        drppayment.Items.Insert(10, "Dena Bank");
        drppayment.Items.Insert(11, "IDBI Bank");
        drppayment.Items.Insert(12, "State Bank of India");
        drppayment.Items.Insert(13, "Axix Bank");
        
    }
    protected void drppayment_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnproceed.Visible = true;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmAdmBusFeesPayment : DBUtility
{
    DataSet dsObj1 = new DataSet();
    RadioButton rb=new RadioButton();
    public string Disq11 = string.Empty;
    public string Disquery = string.Empty;
    public int grvDe11, grvDetail1, grvDe1, i, result1, id = 0;
    public string Disq1 = string.Empty;
    public string st = string.Empty;
   public string serviceid=string.Empty;
   
    public string display=string.Empty;
      
    public string stuname=string.Empty;
    public string BusserAre=string.Empty;
    public string feesV=string.Empty;
    public string Efffro=string.Empty;
    public string Effto=string.Empty;
    public string paymode=string.Empty;
    public string chkno=string.Empty;
    public string chkadte=string.Empty;
    public string cledt=string.Empty;
    public string amt=string.Empty;
    public string ipval=string.Empty;
    public string intst=string.Empty;
     public string DeleteIP=string.Empty;
     public string strQry11=string.Empty;
     public string strQry4=string.Empty;
    public string conval=string.Empty;
    public string chekval=string.Empty;
    public string payid=string.Empty;

    public string intUpdate_IP=string.Empty;
   
             DataSet dsObj = new DataSet();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            TabContainer1.ActiveTabIndex = 0;
            GetSelectedRecord();
            if (!IsPostBack)
            {Label lblTitle = new Label();
                    lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
                    lblTitle.Visible = true;
                    lblTitle.Text = "Bus Fee Payment";

                Update1.Visible = false;
                checksession();
                geturl();
                TabPanel2.Visible = false;
                fillgrid();
            }
        }
        catch 
        {
        
        }
        }
    protected void Buspay_RowEditing(object sender, GridViewEditEventArgs e)
    {
        

    }
    protected void fillgrid()
    {

      //  Disq11 = "Execute dbo.usp_BusFeesPayment @command='EditSelectSta',@intSchool_id='" + Session["School_id"] + "'";

            
      //  grvDe11 = sBindGrid(PayReport, Disq11);

        Disquery = "Execute dbo.usp_BusFeesMaster @command='pay_requ',@intSchool_id='" + Session["School_id"] + "'";
        grvDetail1 = sBindGrid(Buspay, Disquery);

        Disq1 = "Execute dbo.usp_BusFeesPayment @command='EditSelect',@intSchool_id='" + Session["School_id"] + "'";
        grvDe1 = sBindGrid(PayReport, Disq1);


        

}
    private void GetSelectedRecord()
    {
        for (i = 0; i < Buspay.Rows.Count; i++)
        {
            RadioButton rb = (RadioButton)Buspay.Rows[i].Cells[0].FindControl("Radi1");
            if (rb != null)
            {
                if (rb.Checked)
                {
                    HiddenField hf = (HiddenField)Buspay.Rows[i]
                                    .Cells[0].FindControl("HiddenField1");
                    if (hf != null)
                    {
                        ViewState["SelectedContact"] = hf.Value;
                        st = Convert.ToString(ViewState["SelectedContact"]);
                        txd1.Text = st;
                    }

                    break;
                }
            }
        }
    }
    protected void Buspay_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void paymentid_Click(object sender, EventArgs e)
    {
        try
        {

            for ( i = 0; i < Buspay.Rows.Count; i++)
            {
                rb = (RadioButton)Buspay.Rows[i].Cells[0].FindControl("Radi1");
                if (rb != null)
                {
                    if (rb.Checked)
                    {

                        Clear();
                        TabPanel2.Visible = true;
                        TabContainer1.ActiveTabIndex = 1;
                       
                       serviceid = Convert.ToString(txd1.Text);
                        strQry4 = "exec dbo.usp_BusFeesMaster @command='BusSer_payment',@intService_id='" + serviceid + "',@intschool_id='" + Session["School_id"] + "'";
                        dsObj1 = sGetDataset(strQry4);

                        if (dsObj1.Tables[0].Rows.Count > 0)
                        {
                            TabContainer1.ActiveTabIndex = 1;
                            b1.Visible = true;
                            Update1.Visible = false;
                            hid1.Value = Convert.ToString(dsObj1.Tables[0].Rows[0]["intStandard_id"]);
                            hid2.Value = Convert.ToString(dsObj1.Tables[0].Rows[0]["intdivision_id"]);
                            hid3.Value = Convert.ToString(dsObj1.Tables[0].Rows[0]["introllno"]);
                            hid4.Value = Convert.ToString(dsObj1.Tables[0].Rows[0]["intStudent_id"]);
                            hid5.Value = Convert.ToString(dsObj1.Tables[0].Rows[0]["intarea_id"]);
                            hid6.Value = Convert.ToString(dsObj1.Tables[0].Rows[0]["intService_id"]);


                            Lab2.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["StudentName"]);
                            Lab4.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["vchArea_Name"]);
                            Lab6.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["intBus_Amount"]);
                            Lab8.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["dtEffectiveFrom"]);
                            Lab10.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["dtEffectiveTo"]);
                            drop1.SelectedValue = "Select";
                            cheq1.Visible = false;
                            cheq2.Visible = false;
                            cheq3.Visible = false;
                            cheq4.Visible = false;
                       
                        }
                        else
                        {  
                          display = "Area Editing Not Allowed!";
                            MessageBox(display);
                            TabPanel2.Visible = false;
                            TabContainer1.ActiveTabIndex = 0;
                        }

                    }
                    else
                    {

                        MessageBox("Select Record First");
                    }
                }
            }
        }
        catch
        {

        }
    }

    protected void drop1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drop1.SelectedItem.Value == "Cash")
        {
            cheq1.Visible = false;
            cheq2.Visible = false;
            cheq3.Visible = true;
            cheq4.Visible = false;
        }
        else if(drop1.SelectedItem.Value == "Select") 
        {
            cheq1.Visible = false;
            cheq2.Visible = false;
            cheq3.Visible = false;
            cheq4.Visible = false;
        
        
        }
        else
        {
        cheq1.Visible=true;
        cheq2.Visible=true;
        cheq3.Visible=true;
        cheq4.Visible=true;

        ReqFVd1.ValidationGroup = "pp";
        Req1.ValidationGroup = "pp";

     
        
        }
        TabContainer1.ActiveTabIndex = 1;
   
    }
    protected void b1_Click(object sender, EventArgs e)
    {
      
         stuname=Convert.ToString(Lab2.Text);
         BusserAre = Convert.ToString(Lab4.Text);
         feesV = Convert.ToString(Lab6.Text);
        
         Efffro = Convert.ToDateTime(Lab8.Text).ToString("MM/dd/yyyy");
         Effto = Convert.ToDateTime(Lab10.Text).ToString("MM/dd/yyyy");
         paymode=Convert.ToString(drop1.SelectedItem.Value);
         
        if (paymode == "Cheque")
        {
            chkno = Convert.ToString(TEXT1.Text);
            chkadte = Convert.ToDateTime(TextBox1.Text).ToString("MM/dd/yyyy");
            cledt = Convert.ToDateTime(TextBox3.Text).ToString("MM/dd/yyyy");
        }
     
         amt=Convert.ToString(TextBox2.Text);
       

         ipval = GetSystemIP();

         intst = "Execute dbo.usp_BusFeesPayment @command='InsertUpdate',@intStandard_id='" + hid1.Value + "',@intDivision_id='" + hid2.Value + "',@intRollNo='" + hid3.Value + "',@intStudent_id='" + hid4.Value + "',@intarea_id='" + hid5.Value + "',@intamount='" + amt + "',@vchPayment_Mode='" + paymode + "',@dtCheque_delivery='" + chkadte + "',@vchCheck_No='" + chkno + "',@dtCheque_delivery='" + cledt + "',@intInsert_id='" + Session["user_id"] + "',@IntInsert_IP='" + ipval + "',@intSchool_id='" + Session["school_id"] + "',@intService_id='" + hid6.Value + "'";
             
             result1 = sExecuteQuery(intst);

            if (result1 != -1)
            {
                 display = "Fees Paid Successfully!";
                MessageBox(display);
          
                TabContainer1.ActiveTabIndex = 0;
                TabPanel2.Visible = false;
            }
            else
            {
                MessageBox("ooopppsss!Fees Payment Failed");

            }

    }
    protected void PayReport_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            

             id = Convert.ToInt32(PayReport.DataKeys[e.RowIndex].Value);
            Session["Deleteid"] = PayReport.DataKeys[e.RowIndex].Value;
             DeleteIP = GetSystemIP();
             strQry11 = "Execute dbo.usp_BusFeesPayment @command='DeletePayment',@intPayment_Id='" + id + "',@intschool_id='" + Session["School_id"] + "',@IntDelete_IP='" + DeleteIP + "',@intDelete_id='" + Session["user_id"] + "'";
            if (sExecuteQuery(strQry11) != -1)
            {
                MessageBox("Record Deleted Successfully");
                fillgrid();

            }

        }
        catch
        {


        }
    }
    protected void PayReport_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
           id = Convert.ToInt32(PayReport.DataKeys[e.NewEditIndex].Value);
            Session["id"] = PayReport.DataKeys[e.NewEditIndex].Value;
           
             strQry4 = "exec dbo.usp_BusFeesPayment @command='Editpay',@intPayment_Id='" + id + "',@intschool_id='" + Session["School_id"] + "'";
            dsObj1 = sGetDataset(strQry4);
           
            if (dsObj1.Tables[0].Rows.Count > 0)
            {
                TabContainer1.ActiveTabIndex = 1;
           
                Update1.Visible = true;
            
                hid1.Value= Convert.ToString(Session["id"]);
                 Lab2.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["Name"]);
                 Lab4.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["vcharea_name"]);
                 Lab6.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["intamount"]);
                 drop1.SelectedValue = Convert.ToString(dsObj1.Tables[0].Rows[0]["vchPayment_Mode"]);
                 if (drop1.SelectedValue == "Cash")
                 {
                     cheq1.Visible = false;
                     cheq2.Visible = false;
                     cheq3.Visible = true;
                     cheq4.Visible = false;
                 }
                 else if(drop1.SelectedValue == "Cheque")
                 {
                     cheq1.Visible = true;
                     cheq2.Visible = true;
                     cheq3.Visible = true;
                     cheq4.Visible = true;
                     ReqFVd1.ValidationGroup = "pp";
                     Req1.ValidationGroup = "pp";
                
                 
                 }
                  conval=Convert.ToString(dsObj1.Tables[0].Rows[0]["dtCheckDate"]);
                 if (conval == "01/01/1900 00:00:00")
                 {
                     TextBox1.Text = "";
                 }
                 else
                 {
                    TextBox1.Text = conval;
                 }
              
                 TEXT1.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["vchCheck_No"]);
                 TextBox2.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["intamount"]);
                chekval = Convert.ToString(dsObj1.Tables[0].Rows[0]["dtCheque_delivery"]);
                if (chekval == "01/01/1900 00:00:00")
                {
                    TextBox3.Text = "";
                }
                else
                {
                    TextBox3.Text = chekval;
                }


                eff1.Visible = false;
                eff2.Visible = false;
       

            TabContainer1.ActiveTabIndex = 1;
            TabPanel1.Visible = true;
            TabPanel2.Visible = true;
            TabPanel3.Visible = true;
            TabPanel3.Enabled = true;
        
               }

            }
            catch (Exception)
            {

                throw;
         
        }
    }

    protected void PayReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void PayReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    
    protected void Clear()
    {
        drop1.SelectedValue = "Select";
        TEXT1.Text = string .Empty;
        TextBox1.Text = string.Empty;
        TextBox2.Text = string .Empty;
        TextBox3.Text = string.Empty;
    
    }
    protected void Update1_Click(object sender, EventArgs e)
    {
        

         payid=hid1.Value;
     paymode=Convert.ToString(drop1.SelectedItem.Value);
         chkno=Convert.ToString(TEXT1.Text);
        chkadte = Convert.ToDateTime(TextBox1.Text).ToString("MM/dd/yyyy");
       amt=Convert.ToString(TextBox2.Text);
       cledt = Convert.ToDateTime(TextBox3.Text).ToString("MM/dd/yyyy");

  intUpdate_IP = GetSystemIP();

       intst = "Execute dbo.usp_BusFeesPayment @command='InsertUpdate',@intamount='" + amt + "',@vchPayment_Mode='" + paymode + "',@dtCheckDate='" + chkadte + "',@vchCheck_No='" + chkno + "',@dtCheque_delivery='" + cledt + "',@intUpdate_id='" + Session["user_id"] + "',@intUpdate_IP='" + intUpdate_IP + "',@intSchool_id='" + Session["school_id"] + "',@intpayment_id='" + payid + "'";
           
              
           result1 = sExecuteQuery(intst);

            if (result1 != -1)
            {
                 display = "Fees Paid Details Update Successfully!";
                MessageBox(display);
               
                fillgrid();
                TabContainer1.ActiveTabIndex = 0;
                TabPanel2.Visible = false;
            }
            else
            {
                MessageBox("ooopppsss!Fees Payment Updation Failed");

            }

    }
    protected void Drop11_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Drop12_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
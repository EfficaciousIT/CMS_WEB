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
using System.Data.SqlClient;

public partial class frmDriverDetails : DBUtility
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Label lblTitle = new Label();
            //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            //lblTitle.Visible = true;
            //lblTitle.Text = "Driver Detail";

            if (!IsPostBack)
            {
                checksession();
                geturl();
                visi2.Visible = false;

                string query2 = "Execute dbo.usp_DriverMaster @command='SelectDriver',@intSchool_id='" + Session["School_id"] + "'";
                bool st1 = sBindDropDownList(DrpContractorname, query2, "vchTransporter_name", "intTransporter_id");
            }

            gridfill();
        }
        catch 
        {
        
        
        }



    }

    public void gridfill()
    {
        string Disquery1 = "Execute dbo.usp_DriverMaster @command='DriverGrid',@intschool_id='" + Session["School_id"] + "'";
        int Leavegrid1 = sBindGrid(GridView1, Disquery1);
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //if (MessageBox.Show("Really delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //{ // a 'DialogResult.Yes' value was returned from the MessageBox // proceed with your deletion
       // }

       // ClientScriptManager CSM = Page.ClientScript;
       // if (!ReturnValue())
      //  {
      //      string strconfirm = "<script>if(!window.confirm('Are you sure yaaa?')){window.location.href='Default.aspx'}</script>";
      //      CSM.RegisterClientScriptBlock(this.GetType(), "Confirm", strconfirm, false);
      //  }


        try
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            Session["Deleteid"] = GridView1.DataKeys[e.RowIndex].Value;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "ConfirmMessage", " messageConfirm('Do you want to Delete this Record ?')", true);
            // string ans = Request.Form["confirm_value"].Substring(0, 3);

            //if (ans == "Yes")
            // {

            long intDeletedId = Convert.ToInt64(Session["User_id"]);

            string dtDeletedDate = DateTime.Now.ToString("MM/dd/yyyy");
            string vchDeletedIp = GetSystemIP();

            string strQry = "Execute dbo.usp_DriverMaster @command='DeleteDriver',@intDriver_id='" + Session["Deleteid"] + "',@intDeletedId='" + intDeletedId + "',@dtDeletedDate='" + dtDeletedDate + "',@vchDeletedIp='" + vchDeletedIp + "',@intschool_id='" + Session["School_id"] + "'";
          if (sExecuteQuery(strQry) != -1)
            {
              MessageBox("Record Deleted Successfully");
              gridfill();
                //      ans = "";
           }
           }
       
        catch
        {


        }
    }

    bool ReturnValue()
    {
        return false;
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
     
        TabContainer1.Focus();
        
        TabContainer1.ActiveTabIndex = 1;


        try
        {
            int Applicationid = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
            Session["Applicationid"] = GridView1.DataKeys[e.NewEditIndex].Value;
        
           DataSet dsObj = new DataSet();

           string strQry = "exec [usp_DriverMaster] @command='EditDriverGrid',@intDriver_id='" + Session["Applicationid"] + "',@intSchool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                hidden1.Text = Convert.ToString(Applicationid);
                txtDriverFName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDriverFirst_name"]);
                txtDriverMName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDriverMiddle_name"]);
                txtDriverLName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDriverLast_name"]);
                DrpContractorname.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intTranspoterId"]);
                txtTelNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intTelno"]);

                txtMobileNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intMobile_no"]);
                txtLicenceNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchLicence_no"]);
                txtIssueDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtLicenceIssue_Date"]);
                txtExpireDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtLicenceExpire_Date"]);
                DrpJobStatus.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPermanent"]);
                txtContFromDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtContractStartDate"]);
                txtComtToDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtContractEndDate"]);
               
                visi2.Visible = true;
                visi1.Visible = false;

                //FromLbl.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["FromDate"]).ToString("dd/MM/yyyy");
               // ToLbl.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["ToDate"]).ToString("dd/MM/yyyy");
              //  TotalLbl.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalLeaveDays"]);

            }

        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {
            string txtDriFN = txtDriverFName.Text;
            string txtDriMN = txtDriverMName.Text;
            string txtDriLN = txtDriverLName.Text;
            string DrpTrantn = Convert.ToString(DrpContractorname.SelectedItem.Value);
            string DrpTrantn1;
            if (DrpTrantn == "0")
            {
                DrpTrantn1 = "-1";
            }
            else 
            {
               DrpTrantn1 = Convert.ToString(DrpContractorname.SelectedItem.Value);
            }
                
       
           
              string  txtTN1 =  Convert.ToString(txtTelNo.Text);
           
           string txtMN1 = Convert.ToString(txtMobileNo.Text);
            string txtLicNo1 = Convert.ToString(txtLicenceNo.Text);
            string Issuedt = Convert.ToDateTime(txtIssueDate.Text).ToString("MM/dd/yyyy");
            string ExpireDt = Convert.ToDateTime(txtExpireDate.Text).ToString("MM/dd/yyyy");


            string DrpJobSta = DrpJobStatus.Text;
            string ContFromDt = Convert.ToDateTime(txtContFromDate.Text).ToString("MM/dd/yyyy");
            string ComtToDt = Convert.ToDateTime(txtComtToDate.Text).ToString("MM/dd/yyyy");

            long insertby = Convert.ToInt64(Session["User_id"]);

            string insertdt = DateTime.Now.ToString("MM/dd/yyyy");
            string ipval = GetSystemIP();


            string instrquery1 = "Execute dbo.usp_DriverMaster @command='insertDriver',@vchDriverFirst_name='" + txtDriFN + "'," +
                                 "@vchDriverMiddle_name='" + txtDriMN + "',@vchDriverLast_name='" + txtDriLN + "',@intTelno='" + txtTN1 + "'," +
                                 "@intMobile_no=" + txtMN1 + ",@vchLicence_no='" + txtLicNo1 + "',@dtLicenceIssue_Date='" + Issuedt + "'," +
                                 "@dtLicenceExpire_Date='" + ExpireDt + "',@vchPermanent='" + DrpJobSta + "',@dtContractStartDate='" + ContFromDt + "'," +
                                 "@dtContractEndDate='" + ComtToDt + "',@intSchool_id='" + Session["school_id"] + "',@intInsertedId='" + insertby + "'," +
                                 "@dtInsertedDate='" + insertdt + "',@intTranspoterId='" + DrpTrantn1 + "',@bitActiveFlg='1'," +
                                 "@vchInsertedIp='" + ipval + "'";

            int str = sExecuteQuery(instrquery1);

            if (str != -1)
            {
                string display = "Driver Details Submit!";
                MessageBox(display);
                clear();
                gridfill();


            }
            else
            {
                MessageBox("ooopppsss!Driver Details submission Failed");

            }


        }
        catch(Exception ex)
        { 
        
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        try
        {
            string txtDriFN = txtDriverFName.Text;
            string txtDriMN = txtDriverMName.Text;
            string txtDriLN = txtDriverLName.Text;
            string DrpTrantn = Convert.ToString(DrpContractorname.SelectedItem.Value);
            string DrpTrantn1;
            if (DrpTrantn == "0")
            {
                DrpTrantn1 = "-1";
            }
            else
            {
                DrpTrantn1 = Convert.ToString(DrpContractorname.SelectedItem.Value);
            }



            string txtTN1 = Convert.ToString(txtTelNo.Text);

            string txtMN1 = Convert.ToString(txtMobileNo.Text);
            string txtLicNo1 = Convert.ToString(txtLicenceNo.Text);
            string Issuedt = Convert.ToDateTime(txtIssueDate.Text).ToString("MM/dd/yyyy");
            string ExpireDt = Convert.ToDateTime(txtExpireDate.Text).ToString("MM/dd/yyyy");


            string DrpJobSta = DrpJobStatus.Text;
            string ContFromDt = Convert.ToDateTime(txtContFromDate.Text).ToString("MM/dd/yyyy");
            string ComtToDt = Convert.ToDateTime(txtComtToDate.Text).ToString("MM/dd/yyyy");

            long insertby = Convert.ToInt64(Session["User_id"]);

            string insertdt = DateTime.Now.ToString("MM/dd/yyyy");
            string ipval = GetSystemIP();
            string intDriver_id = hidden1.Text;

            string instrquery1 = "Execute dbo.usp_DriverMaster @command='updateDriver',@vchDriverFirst_name='" + txtDriFN + "'," +
                                 "@vchDriverMiddle_name='" + txtDriMN + "',@vchDriverLast_name='" + txtDriLN + "',@intTelno='" + txtTN1 + "'," +
                                 "@intMobile_no=" + txtMN1 + ",@vchLicence_no='" + txtLicNo1 + "',@dtLicenceIssue_Date='" + Issuedt + "'," +
                                 "@dtLicenceExpire_Date='" + ExpireDt + "',@vchPermanent='" + DrpJobSta + "',@dtContractStartDate='" + ContFromDt + "'," +
                                 "@dtContractEndDate='" + ComtToDt + "',@intSchool_id='" + Session["school_id"] + "',@intUpdatedId='" + insertby + "'," +
                                 "@dtUpdatedDate='" + insertdt + "',@intTranspoterId='" + DrpTrantn1 + "',@bitActiveFlg='1'," +
                                 "@vchUpdatedIp='" + ipval + "',@intDriver_id='" + intDriver_id + "'";

            int str = sExecuteQuery(instrquery1);

            if (str != -1)
            {
                string display = "Driver Details Update Successfully!";
                MessageBox(display);
                clear();
                gridfill();


            }
            else
            {
                MessageBox("ooopppsss!Driver Details Updation Failed");

            }


        }
        catch
        {

        }
    }
    public void clear()
    {
        txtDriverFName.Text="";
        txtDriverMName.Text="";
        txtDriverLName.Text="";
        DrpContractorname.SelectedValue="0";
        DrpJobStatus.SelectedValue = "select";
        txtTelNo.Text="";
        txtMobileNo.Text="";
        txtLicenceNo.Text="";
        txtIssueDate.Text="";
        txtExpireDate.Text = "";
        DrpJobStatus.Text="";
        txtContFromDate.Text = "";
        txtComtToDate.Text="";

    
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

     //<asp:TemplateField HeaderText="Delete">
//       ///                                     <ItemTemplate>
//                                                <asp:LinkButton OnClientClick="confirm('Are sure you want to delete this record')"
//                                                    ID="lnkBtndelete"  runat="server">
//                                                    <asp:Image ID="ImgDelete" runat="server" ImageUrl="images/delete.png" /></asp:LinkButton></ItemTemplate>
//                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
//                                        </asp:TemplateField>
    protected void Button2_Click(object sender, EventArgs e)
    {
        txtComtToDate.Text = "";
        txtContFromDate.Text = "";
        txtDriverFName.Text = "";
        txtDriverLName.Text = "";
        txtDriverMName.Text = "";
        txtExpireDate.Text = "";
        txtIssueDate.Text = "";
        txtLicenceNo.Text = "";
        txtMobileNo.Text = "";
        txtTelNo.Text = "";
        DrpContractorname.SelectedValue = "0";
        DrpJobStatus.SelectedValue = "0";
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

    }
}

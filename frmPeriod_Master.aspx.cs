using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class frmPeriod_Master :DBUtility
{
    DataSet dsObj1 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Button1.Visible = true;
                checksession();
                geturl();
                fillgrid();
                fillSession();
            }
        }
        catch 
        {
        
        }
    }

    protected void fillgrid()
    {
        string Disquery = "Execute dbo.usp_Area @command='DisplayPediod',@intSchool_id='" + Session["School_id"] + "'";
        int grvDetail1 = sBindGrid(PeriodReport, Disquery);
    }

    protected void fillSession()
    {
        string query = "Execute dbo.usp_Area @command='getSession',@intSchool_id='" + Session["School_id"] + "'";
        sBindDropDownList(drop1, query, "SessionName", "intSession_id");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string cheval;


        DateTime v1 = Convert.ToDateTime(TextBox1.Text);
        string Periodfrom = v1.ToString("HH:mm");
        DateTime v2 = Convert.ToDateTime(TextBox2.Text);
        string PeriodTo = v2.ToString("HH:mm"); ;
        string sessval = Convert.ToString(drop1.SelectedItem.Value);
        if (CheckBox1.Checked)
        {
            cheval = "1";
        }
        else
        {
            cheval = "0";
        }
        string CheRess = Convert.ToString(cheval);
        string instip = GetSystemIP();

        //if (Button1.Text == "Submit")
        //{
        //    string strQry = "";
        //    // strQry = "exec usp_Area  @type='CheckPeriodExist',@vchFloor_name='" + Convert.ToString(txtFloor.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "'";
        //    strQry = "usp_Area @command='CheckPeriodExist',@dtFromTime='" + Periodfrom + "',@dtToTime='" + PeriodTo + "',@intSession_id='" + sessval + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        //    dsObj1 = sGetDataset(strQry);
        //    if (dsObj1.Tables[0].Rows.Count > 0)
        //    {
        //        MessageBox("Entered Record Already Exist");
        //        return;
        //    }
        //    else
        //    {
                try
                {

                    string itrque1 = "Execute dbo.usp_Area @command='PediodMast',@dtFromTime='" + Periodfrom + "',@dtToTime='" + PeriodTo + "',@intSession_id='" + sessval + "',@btrecess='" + CheRess + "',@InsertIP='" + instip + "',@intschool_id='" + Session["School_id"] + "',@intInsertby='" + Session["user_id"] + "'";

                    int result1 = sExecuteQuery(itrque1);

                    if (result1 != -1)
                    {
                        string display = "Period Assigned Successfully!";
                        MessageBox(display);
                        fillgrid();
                        Clear();
                        Button1.Text = "Submit";
                    }
                    else
                    {
                        MessageBox("ooopppsss!Period Assignment Failed");

                    }

                }
                catch
                {

               // }
          //  }
        }
        
       
    }

    protected void Clear()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        CheckBox1.Checked = false;
        drop1.SelectedValue = "0";
    
    }
    protected void PeriodReport_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void PeriodReport_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(PeriodReport.DataKeys[e.RowIndex].Value);
            Session["Deleteid"] = PeriodReport.DataKeys[e.RowIndex].Value;
            string DeleteIP = GetSystemIP();
            string strQry11 = "Execute dbo.usp_Area @command='DeletePediod',@intPeriod_id='" + id + "',@intschool_id='" + Session["School_id"] + "',@deleteIP='" + DeleteIP + "',@intDeleteBy='" + Session["user_id"] + "'";
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
    protected void PeriodReport_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(PeriodReport.DataKeys[e.NewEditIndex].Value);
            Session["id"] = PeriodReport.DataKeys[e.NewEditIndex].Value;
            DataSet dsObj = new DataSet();
            //  string strQry4 = "exec dbo.usp_BusFeesPayment @command='Editpay',@intPayment_Id='" + id + "',@intschool_id='" + Session["School_id"] + "'";
            //  dsObj1 = sGetDataset(strQry4);

            //            if (dsObj1.Tables[0].Rows.Count > 0)
            //          {

            string strQry = "exec dbo.usp_Area @command='EditPediod',@intPeriod_id='" + id + "',@intschool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                TabContainer1.ActiveTabIndex = 1;
                hid1.Value = Convert.ToString(Session["id"]);
                DateTime var1 = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtFromTime"]);

                TextBox1.Text = var1.ToString("hh:mm tt");
                DateTime var2 = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtToTime"]);
                TextBox2.Text = var2.ToString("hh:mm tt");
                drop1.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intSession_id"]);

                string Check = Convert.ToString(dsObj.Tables[0].Rows[0]["btrecess"]);

                if (Check == "True")
                {
                    CheckBox1.Checked = true;
                }
                else
                {
                    CheckBox1.Checked = false;

                }

            }
            

            Button1.Visible = false;
            Button2.Visible = true;

        }
        catch (Exception)
        {

            throw;

        }
    }
    protected void PeriodReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        PeriodReport.PageIndex = e.NewPageIndex;
        PeriodReport.DataBind();
        fillgrid();
        
    }
    protected void PeriodReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void PeriodReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string cheval;


        DateTime v1 = Convert.ToDateTime(TextBox1.Text);
        string Periodfrom = v1.ToString("HH:mm");
        DateTime v2 = Convert.ToDateTime(TextBox2.Text);
        string PeriodTo = v2.ToString("HH:mm"); ;
        string sessval = Convert.ToString(drop1.SelectedItem.Value);
        if (CheckBox1.Checked)
        {
            cheval = "1";
        }
        else
        {
            cheval = "0";
        }
        string CheRess = Convert.ToString(cheval);
        string instip = GetSystemIP();
        //if (Button2.Text == "Update")
        //{
        //    string strQry = "";
        //    // strQry = "exec usp_Area  @type='CheckPeriodExist',@vchFloor_name='" + Convert.ToString(txtFloor.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "'";
        //    strQry = "usp_Area @command='CheckPeriodExist',@dtFromTime='" + Periodfrom + "',@dtToTime='" + PeriodTo + "'";
        //    dsObj1 = sGetDataset(strQry);
        //    if (dsObj1.Tables[0].Rows.Count > 0)
        //    {
        //        MessageBox("Entered Record Already Exist");
        //        return;
        //    }
        //    else
        //    {

                try
                {
                    //string cheval;
                    string intPeriod_id = hid1.Value;
                   // string Periodfrom = Convert.ToString(TextBox1.Text);
                    //string PeriodTo = Convert.ToString(TextBox2.Text);
                   // string sessval = Convert.ToString(drop1.SelectedItem.Value);
                    if (CheckBox1.Checked)
                    {
                        cheval = "1";
                    }
                    else
                    {
                        cheval = "0";
                    }
                   // string CheRess = Convert.ToString(cheval);
                    string Updateip = GetSystemIP();

                    string itrque1 = "Execute dbo.usp_Area @command='UpdatePediod',@dtFromTime='" + Periodfrom + "',@dtToTime='" + PeriodTo + "',@intSession_id='" + sessval + "',@btrecess='" + CheRess + "',@UpdateIP='" + Updateip + "',@intUpdatedBy='" + Session["user_id"] + "',@intPeriod_id='" + intPeriod_id + "',@intschool_id='" + Session["School_id"] + "'";

                    int result1 = sExecuteQuery(itrque1);

                    if (result1 != -1)
                    {
                        string display = "Period update Successfully!";
                        MessageBox(display);
                        fillgrid();
                        Clear();
                        Button1.Text = "Submit";
                    }
                    else
                    {
                        MessageBox("ooopppsss!Period updation Failed");

                    }

                }
                catch
                {

             //   }
           // }
        }
    }

    protected void drop1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
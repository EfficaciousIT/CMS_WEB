using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmFees_For_Bus : DBUtility
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTitle = new Label();
        lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
        lblTitle.Visible = true;
        lblTitle.Text = "Bus Fee Master";
       
        if (!IsPostBack)
        {
            try
            {
                if (!IsPostBack)
                {

                    checksession();
                    geturl();
                
                }



                string queryp1 = "Execute dbo.usp_Area @command='SelectArea',@intSchool_id='" + Session["School_id"] + "' ";
                bool stcardp = sBindDropDownList(DropDownList1, queryp1, "vcharea_name", "intarea_id");
                fillgrid();
            }
            catch 
            {
            
            }
        }
    }

    protected void FeesDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            DataSet dsObj = new DataSet();
         
            int id = Convert.ToInt32(FeesDetail.DataKeys[e.RowIndex].Value);
            Session["Deleteid"] = FeesDetail.DataKeys[e.RowIndex].Value;


            long Deleteby = Convert.ToInt64(Session["User_id"]);

            string deleteipval = GetSystemIP();

            string strQry = "Execute dbo.usp_BusFeesMaster @command='checkexist',@intbusfees_id='" + id + "',@intschool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);


            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Deleted");
            }
            else
            {

                string strQry1 = "Execute dbo.usp_BusFeesMaster @command='DeleteEntry',@intDelete_id='" + Deleteby + "',@intbusfees_id='" + id + "',@intschool_id='" + Session["School_id"] + "',@IntDelete_IP='" + deleteipval + "'";
                if (sExecuteQuery(strQry1) != -1)
                {
                    MessageBox("Record Deleted Successfully");
                    //fillgrid();
                }
                else
                {


                }
            }
        }
        catch (Exception)
        {


        }
    }
    protected void FeesDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void FeesDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void FeesDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(FeesDetail.DataKeys[e.NewEditIndex].Value);
            Session["id"] = FeesDetail.DataKeys[e.NewEditIndex].Value;
            DataSet dsObj1 = new DataSet();

            string strQry4 = "exec dbo.usp_BusFeesMaster @command='EditGridFees',@intbusfees_id='" + id + "',@intschool_id='" + Session["School_id"] + "'";
            dsObj1 = sGetDataset(strQry4);
           
            if (dsObj1.Tables[0].Rows.Count > 0)
            {
                TabContainer1.ActiveTabIndex = 0;
                labarea.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["intBusFees_Id"]);
                TextBox4.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["intArea_Id"]);
                TextBox1.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["intBus_Amount"]);
                TextBox2.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["dtEffectiveFrom"]);
                TextBox3.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["dtEffectiveTo"]);


                enara.Visible = true;
                enara1.Visible = false;
                submit.Visible = false;
                Update1.Visible = true;
            }
            else
            {
                string display = "Ara Editing Not Allowed!";
                MessageBox(display);

            }

        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void fillgrid()
    {
        try
        {
            string Disquery = "Execute dbo.usp_BusFeesMaster @command='GridFees',@intSchool_id='" + Session["School_id"] + "'";
            int grvDetail1 = sBindGrid(FeesDetail, Disquery);
        }
        catch 
        {
        
        }
        }
    protected void submit_Click(object sender, EventArgs e)
    {
        try
        {
        string are1=Convert.ToString(DropDownList1.SelectedItem.Value);
        string feesamt =Convert.ToString(TextBox1.Text).Trim();
        string efffrom = Convert.ToDateTime(TextBox2.Text).ToString("MM/dd/yyyy");

        string effTo = Convert.ToDateTime(TextBox3.Text).ToString("MM/dd/yyyy"); 
  
        

          string ipval = GetSystemIP();
            
          string instrquery1 = "Execute dbo.usp_FeesMaster @command='InsertFees',@intArea_Id='" + are1 + "',@intBus_Amount='"+ feesamt +"',@dtEffectiveFrom='"+ efffrom +"',@dtEffectiveTo='"+ effTo +"',@intInsert_id='" + Session["User_id"] + "',@IntInsert_IP='" + ipval + "',@intSchool_id='" + Session["School_id"] + "' ";



           int str = sExecuteQuery(instrquery1);
            if (str != -1)
            {
                string display = "Bus Fees Amount Saved Successfully!";
                MessageBox(display);

                TabContainer1.ActiveTabIndex = 1;
                Clear();
                fillgrid();


            }
            else
            {
                MessageBox("ooopppsss!Bus Fees Amount submission Failed");

            }

        }

        catch (Exception Ex)
        {


        }
    }
    protected void Update1_Click(object sender, EventArgs e)
    {
        try
        {
            int str;
            string feesamt1 = Convert.ToString(TextBox1.Text).Trim();
            string efffrom1 = Convert.ToDateTime(TextBox2.Text).ToString("MM/dd/yyyy");

            string effTo1 = Convert.ToDateTime(TextBox3.Text).ToString("MM/dd/yyyy");
            string  idvl=labarea.Text;
            string Upval = GetSystemIP();


            string intArea_Id = Convert.ToString(labarea.Text).Trim();
            string instrquery1 = "Execute dbo.usp_BusFeesMaster @command='EditGridFees1',@intBus_Amount='" + feesamt1 + "',@dtEffectiveFrom='" + efffrom1 + "',@dtEffectiveTo='" + effTo1 + "',@intUpdate_id='" + Session["User_id"] + "',@IntUpdate_IP='" + Upval + "',@intbusfees_id='" + idvl + "',@intSchool_id='" + Session["School_id"] + "' ";



            str = sExecuteQuery(instrquery1);
            if (str != -1)
            {
                string display = "Area Update Successfully!";
                MessageBox(display);

                TabContainer1.ActiveTabIndex = 1;
                Clear();
                fillgrid();


            }
            else
            {
                MessageBox("ooopppsss!Area Updation Failed");

            }

        }

        catch (Exception Ex)
        {


        }
    }
    protected void Clear()
    {
        DropDownList1.ClearSelection();
        
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }
    protected void FeesDetail_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
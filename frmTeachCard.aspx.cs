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

public partial class frmTeachCard : DBUtility
{
    DataSet dsObj = new DataSet();
    int dsgrid, dsgrid1;
    int dsTempgrid;
    SqlCommand cmd = new SqlCommand();
    string strQry = "";
    int i = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            if (IsPostBack)
            {
                checksession();
                geturl();
            
            }

            carddis.Visible = true;

            //Tr18.Visible = true;

            //Gridlistpendingtem.Visible = false;

            GridView2.Visible = false;

            GridView2.Columns[0].Visible = false;
            GridView2.Columns[1].Visible = false;
            GridView2.Columns[6].Visible = false;
            GridView2.Columns[7].Visible = false;



            TabPanelIdcard.Visible = Convert.ToBoolean("true");

            TabPanelcarddisplay.Visible = Convert.ToBoolean("true");
            TabPanellostcard.Visible = Convert.ToBoolean("true");
            TabPaneltempcardentry.Visible = Convert.ToBoolean("false");
            TabPaneltempcardt.Visible = Convert.ToBoolean("true");
            TabPanelpendingcard.Visible = Convert.ToBoolean("true");

            teachname.Visible = true;

            departid.Visible = true;

            //DropDownList32.Items[1].Enabled = true;
            //DropDownList32.Items[4].Enabled = true;



            if (!IsPostBack)
            {

                //Gridlistlostdetails.DataSource = createDataTable1();
                //Gridlistlostdetails.DataBind();

                //Gridlistpendingtem.DataSource = createDataTable3();
                //Gridlistpendingtem.DataBind();

                GetData();


            }
        }
        catch
        {

        }
    }

    protected void GetData()
    {


        string query1 = "Execute dbo.usp_idcard @command='TeachID' ,@intUser_id='" + Session["User_id"] + "'";
        string query4 = "Execute dbo.usp_Tempidcard @command='ListLostCardDetail' ,@intUser_id='" + Session["User_id"] + "'";
        string query2 = "Execute dbo.usp_Tempidcard @command='ListofTempGrid' ,@intUser_id='" + Session["User_id"] + "'";
        string query3 = "Execute dbo.usp_Tempidcard @command='ListofTempPending' ,@intUser_id='" + Session["User_id"] + "'";



        dsObj = sGetDataset(query1);

        dsgrid1 = sBindGrid(Gridlistlostdetails, query4);
        dsgrid = sBindGrid(GridViewTempDis, query2);
        dsTempgrid = sBindGrid(Gridlistpendingtem, query3);

        Session["Table"] = dsObj;
        try
        {
            if (((DataSet)Session["Table"] != null))
            {
                foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                {
                    TextBox1.Text = dr[0].ToString();
                    TextBox15.Text = dr[1].ToString();
                    TextBox16.Text = dr[2].ToString();
                    Label11.Text = dr[3].ToString();
                }
            }
        }
        catch (Exception ex)
        {


        }

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void Droptempcarstech_SelectedIndexChanged(object sender, EventArgs e)
    {


        string val1 = ((DropDownList)sender).SelectedValue;
        if (val1 == "student")
        {

            GridViewTempDis.Visible = true;

            GridViewTempDis.Columns[0].Visible = false;
            GridViewTempDis.Columns[1].Visible = false;
            GridViewTempDis.Columns[2].Visible = false;
            GridViewTempDis.Columns[3].Visible = true;
            GridViewTempDis.Columns[4].Visible = false;
            GridViewTempDis.Columns[5].Visible = false;
            GridViewTempDis.Columns[6].Visible = false;
            GridViewTempDis.Columns[7].Visible = false;
            GridViewTempDis.Columns[13].Visible = false;
            GridViewTempDis.Columns[14].Visible = false;
            GridViewTempDis.Columns[16].Visible = true;
            GridViewTempDis.Columns[17].Visible = false;


        }
        else
        {

            GridViewTempDis.Visible = true;
            GridViewTempDis.Columns[0].Visible = false;
            GridViewTempDis.Columns[1].Visible = false;
            GridViewTempDis.Columns[2].Visible = false;
            GridViewTempDis.Columns[3].Visible = false;
            GridViewTempDis.Columns[4].Visible = false;
            GridViewTempDis.Columns[5].Visible = false;
            GridViewTempDis.Columns[6].Visible = false;
            GridViewTempDis.Columns[7].Visible = false;

        }



    }

    protected void Droppendadmin_SelectedIndexChanged(object sender, EventArgs e)
    {


        string val1 = ((DropDownList)sender).SelectedValue;
        if (val1 == "student")
        {

            //Gridlistpendingtem.Visible = true;

            //Gridlistpendingtem.Columns[0].Visible = false;
            //Gridlistpendingtem.Columns[1].Visible = false;
            //Gridlistpendingtem.Columns[2].Visible = false;
            //Gridlistpendingtem.Columns[3].Visible = true;
            //Gridlistpendingtem.Columns[4].Visible = true;
            //Gridlistpendingtem.Columns[5].Visible = true;
            //Gridlistpendingtem.Columns[6].Visible = true;
            //Gridlistpendingtem.Columns[7].Visible = false;
            //Gridlistpendingtem.Columns[10].Visible = false;
            //Gridlistpendingtem.Columns[11].Visible = false;


        }
        else
        {

            //Gridlistpendingtem.Visible = true;
            //Gridlistpendingtem.Columns[0].Visible = false;
            //Gridlistpendingtem.Columns[1].Visible = false;
            //Gridlistpendingtem.Columns[2].Visible = false;
            //Gridlistpendingtem.Columns[3].Visible = true;
            //Gridlistpendingtem.Columns[4].Visible = false;
            //Gridlistpendingtem.Columns[5].Visible = false;
            //Gridlistpendingtem.Columns[6].Visible = false;
            //Gridlistpendingtem.Columns[7].Visible = true;

        }



    }
    protected void Droppendcarstech_SelectedIndexChanged(object sender, EventArgs e)
    {


        string val1 = ((DropDownList)sender).SelectedValue;
        if (val1 == "student")
        {

            //Gridlistpendingtem.Visible = true;

            //Gridlistpendingtem.Columns[0].Visible = false;
            //Gridlistpendingtem.Columns[1].Visible = false;
            //Gridlistpendingtem.Columns[2].Visible = false;
            //Gridlistpendingtem.Columns[3].Visible = true;
            //Gridlistpendingtem.Columns[4].Visible = false;
            //Gridlistpendingtem.Columns[5].Visible = false;
            //Gridlistpendingtem.Columns[6].Visible = false;
            //Gridlistpendingtem.Columns[7].Visible = false;


        }




    }
    protected void Droptempadmin_SelectedIndexChanged(object sender, EventArgs e)
    {


        string val1 = ((DropDownList)sender).SelectedValue;
        if (val1 == "student")
        {
            GridViewTempDis.Visible = true;
            GridViewTempDis.Columns[0].Visible = true;
            GridViewTempDis.Columns[1].Visible = true;
            GridViewTempDis.Columns[2].Visible = false;
            GridViewTempDis.Columns[3].Visible = true;
            GridViewTempDis.Columns[4].Visible = true;
            GridViewTempDis.Columns[5].Visible = true;
            GridViewTempDis.Columns[6].Visible = true;
            GridViewTempDis.Columns[7].Visible = false;

        }
        else
        {
            GridViewTempDis.Visible = true;
            GridViewTempDis.Columns[0].Visible = true;
            GridViewTempDis.Columns[1].Visible = true;
            GridViewTempDis.Columns[2].Visible = false;
            GridViewTempDis.Columns[3].Visible = true;
            GridViewTempDis.Columns[4].Visible = false;
            GridViewTempDis.Columns[5].Visible = false;
            GridViewTempDis.Columns[6].Visible = false;
            GridViewTempDis.Columns[7].Visible = true;
        }



    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {


        string val1 = ((DropDownList)sender).SelectedValue;
        if (val1 == "student")
        {


            Tr2.Visible = false;

            TempNo.Visible = true;
            Temp2.Visible = true;
            Temp3.Visible = true;
            Temp4.Visible = true;
            Temp7.Visible = false;

            Temp10.Visible = true;
            Temp11.Visible = true;
            Temp12.Visible = true;
            Temp15.Visible = true;

        }
        else
        {

            Tr2.Visible = true;

            TempNo.Visible = true;
            Temp2.Visible = true;
            Temp3.Visible = true;
            Temp4.Visible = true;
            Temp7.Visible = false;

            Temp10.Visible = true;
            Temp11.Visible = true;
            Temp12.Visible = true;
            Temp15.Visible = true;

        }



    }

    protected void Droplostcarstech_SelectedIndexChanged(object sender, EventArgs e)
    {
        string val1 = ((DropDownList)sender).SelectedValue;
        if (val1 == "student")
        {
            Gridlistlostdetails.Visible = true;
            Gridlistlostdetails.Columns[0].Visible = false;
            Gridlistlostdetails.Columns[1].Visible = false;
            Gridlistlostdetails.Columns[3].Visible = true;
            Gridlistlostdetails.Columns[2].Visible = false;
            Gridlistlostdetails.Columns[4].Visible = false;
            Gridlistlostdetails.Columns[5].Visible = false;
            Gridlistlostdetails.Columns[6].Visible = false;
            Gridlistlostdetails.Columns[7].Visible = false;


        }
        else
        {

            Gridlistlostdetails.Visible = true;
            Gridlistlostdetails.Columns[3].Visible = false;
            Gridlistlostdetails.Columns[2].Visible = false;
            Gridlistlostdetails.Columns[4].Visible = false;
            Gridlistlostdetails.Columns[5].Visible = false;
            Gridlistlostdetails.Columns[6].Visible = false;
            Gridlistlostdetails.Columns[7].Visible = false;

        }
    }
    protected void Droplostadmin_SelectedIndexChanged(object sender, EventArgs e)
    {
        string val1 = ((DropDownList)sender).SelectedValue;
        if (val1 == "student")
        {
            Gridlistlostdetails.Visible = true;
            Gridlistlostdetails.Columns[3].Visible = true;
            Gridlistlostdetails.Columns[2].Visible = false;
            Gridlistlostdetails.Columns[4].Visible = true;
            Gridlistlostdetails.Columns[5].Visible = true;
            Gridlistlostdetails.Columns[6].Visible = true;
            Gridlistlostdetails.Columns[7].Visible = false;


        }
        else
        {

            Gridlistlostdetails.Visible = true;
            Gridlistlostdetails.Columns[3].Visible = true;
            Gridlistlostdetails.Columns[2].Visible = false;
            Gridlistlostdetails.Columns[4].Visible = false;
            Gridlistlostdetails.Columns[5].Visible = false;
            Gridlistlostdetails.Columns[6].Visible = false;
            Gridlistlostdetails.Columns[7].Visible = true;

        }
    }

    protected void Dropcarddetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        string val1 = ((DropDownList)sender).SelectedValue;
        if (val1 == "student")
        {
            GridView2.Visible = true;
            GridView2.Columns[3].Visible = true;
            GridView2.Columns[2].Visible = false;
            GridView2.Columns[4].Visible = true;
            GridView2.Columns[5].Visible = true;
            GridView2.Columns[6].Visible = true;
            GridView2.Columns[7].Visible = false;
            GridView2.Columns[11].Visible = false;
        }
        else
        {
            GridView2.Visible = true;
            GridView2.Columns[3].Visible = true;
            GridView2.Columns[2].Visible = false;
            GridView2.Columns[4].Visible = false;
            GridView2.Columns[5].Visible = false;
            GridView2.Columns[6].Visible = false;
            GridView2.Columns[7].Visible = true;
        }
    }
    protected void Droptypeuser_SelectedIndexChanged(object sender, EventArgs e)
    {
        string val1 = ((DropDownList)sender).SelectedValue;
        if (val1 == "student")
        {


        }
        else
        {

        }

    }
    private object createDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("cardid");
        dt.Columns.Add("cardno");
        dt.Columns.Add("StudentId");

        dt.Columns.Add("RollNo");
        dt.Columns.Add("StandardId");
        dt.Columns.Add("DivisionId");

        dt.Columns.Add("StudentName");
        dt.Columns.Add("TeacherName");
        dt.Columns.Add("StaffName");

        dt.Columns.Add("DepartmentId");
        dt.Columns.Add("DateofIssue");

        dt.Columns.Add("DateofActivation");
        dt.Columns.Add("DateofExpire");

        dt.Columns.Add("FeePaidStatus");


        DataRow dr = dt.NewRow();

        dr["card id"] = "11";
        dr["card no"] = "C1001";
        dr["Student Id"] = "1001";
        dr["Standard Id"] = "2 nd";

        dr["Roll No"] = "2";
        dr["Division Id"] = "B";

        dr["Student Name"] = "Jivika";
        dr["Teacher Name"] = "Mr.Sharma";
        dr["Staff Name"] = "Mr.Giri";

        dr["Department Id"] = "ST255";
        dr["Date of Issue"] = "29-07-2014";

        dr["Date of Activation"] = "28-07-2014";
        dr["Date of Expire"] = "12-08-2016";

        dr["Fee Paid Status"] = "Paid";


        dt.Rows.Add(dr);


        return dt;
    }
    private object createDataTable1()
    {

        DataTable dt = new DataTable();
        dt.Columns.Add("card id");
        dt.Columns.Add("card no");
        dt.Columns.Add("Student Id");
        dt.Columns.Add("Standard Id");
        dt.Columns.Add("Division Id");
        dt.Columns.Add("Department Id");
        dt.Columns.Add("Roll No");
        dt.Columns.Add("Student Name");
        dt.Columns.Add("date of issue");
        dt.Columns.Add("date of activation");
        dt.Columns.Add("date of expire");
        dt.Columns.Add("lost status");
        dt.Columns.Add("Card lost Date");



        DataRow dr = dt.NewRow();
        dr["card id"] = "1001";
        dr["card no"] = "c1001";
        dr["Student Id"] = "0011";
        dr["Standard Id"] = "2 nd";
        dr["Division Id"] = "C";
        dr["Department Id"] = "100";
        dr["Roll No"] = "6";
        dr["Student Name"] = "Jivika";
        dr["date of issue"] = "11-jun-2014";
        dr["date of activation"] = "13-jun-2014";
        dr["date of expire"] = "15-jun-2015";

        dr["lost status"] = "Yes";
        dr["Card lost Date"] = "15-jun-2014";

        dt.Rows.Add(dr);

        return dt;
    }
    private object createDataTable2()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("card id");
        dt.Columns.Add("card no");
        dt.Columns.Add("Student Id");
        dt.Columns.Add("Standard Id");
        dt.Columns.Add("Division Id");
        dt.Columns.Add("Department Id");
        dt.Columns.Add("Roll no");
        dt.Columns.Add("Student Name");
        dt.Columns.Add("Date of Issue");
        dt.Columns.Add("Date of Activation");
        dt.Columns.Add("Date of Expire");
        dt.Columns.Add("Active Status");
        dt.Columns.Add("Lost Status");
        dt.Columns.Add("Temporary Status");
        dt.Columns.Add("Return Date");
        dt.Columns.Add("Given By");
        dt.Columns.Add("Received By");
        dt.Columns.Add("Fee Paid Status");
        dt.Columns.Add("Fee Amount");
        dt.Columns.Add("Fee Received By");
        dt.Columns.Add("Card Discarded Status");

        DataRow dr = dt.NewRow();
        dr["card id"] = "1001";
        dr["card no"] = "c1001";
        dr["Student Id"] = "2002";
        dr["Standard Id"] = "3 rd";
        dr["Division Id"] = "A";
        dr["Department Id"] = "D1001";
        dr["Roll no"] = "D1001";
        dr["Student Name"] = "Jivika";
        dr["Date of Issue"] = "29-07-2014";
        dr["Date of Expire"] = "01-08-2014";
        dr["Date of Activation"] = "29-07-2014";
        dr["Active Status"] = "Active";
        dr["Lost Status"] = "Lost Card";
        dr["Temporary Status"] = "Return";
        dr["Return Date"] = "02-08-2014";
        dr["Given By"] = "Mr.Shaha";
        dr["Received By"] = "C1001";
        dr["Fee Paid Status"] = "Paid";
        dr["Fee Amount"] = "100";
        dr["Fee Received By"] = "Mr.Shete";
        dr["Card Discarded Status"] = "Discarded";



        dt.Rows.Add(dr);


        return dt;
    }
    private object createDataTable3()
    {



        DataTable dt = new DataTable();

        dt.Columns.Add("Temp card id");
        dt.Columns.Add("card no");
        dt.Columns.Add("Student Id");
        dt.Columns.Add("Standard Id");
        dt.Columns.Add("Division Id");

        dt.Columns.Add("Department Id");
        dt.Columns.Add("Roll No");
        dt.Columns.Add("Student Name");

        dt.Columns.Add("date of issue");
        dt.Columns.Add("date of expire");


        DataRow dr = dt.NewRow();
        dr["Temp card id"] = "1001";
        dr["card no"] = "c1001";
        dr["Student Id"] = "2002";
        dr["Standard Id"] = "3 rd";
        dr["Division Id"] = "A";
        dr["Department Id"] = "D1001";

        dr["Roll No"] = "6";
        dr["Student Name"] = "Jivika shetty";
        dr["date of issue"] = "13-07-2014";
        dr["date of expire"] = "16-07-2014";

        dt.Rows.Add(dr);

        return dt;
    }
    protected void Gridlistpendingtem_PageIndexChanging(object sender, EventArgs e)
    {

    }
    protected void Gridlistpendingtem_RowCancelingEdit(object sender, EventArgs e)
    {

    }
    protected void Gridlistpendingtem_RowDeleting(object sender, EventArgs e)
    {

    }
    protected void Gridlistpendingtem_RowEditing(object sender, EventArgs e)
    {

    }
    protected void Gridlistlostdetails_PageIndexChanging(object sender, EventArgs e)
    {

    }
    protected void Gridlistlostdetails_RowCancelingEdit(object sender, EventArgs e)
    {

    }
    protected void Gridlistlostdetails_RowDeleting(object sender, EventArgs e)
    {

    }
    protected void Gridlistlostdetails_RowEditing(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtvchmake1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnsubmit_Click(object sender, ImageClickEventArgs e)
    {

    }


    protected void show(object sender, EventArgs e)
    {


    }
    protected void Drophovacat_SelectedIndexChanged(object sender, EventArgs e)
    {
        string val1 = ((DropDownList)sender).SelectedValue;
        if (val1 == "student")
        {


        }
        else if (val1 == "Teacher")
        {

        }
        else if (val1 == "Select")
        {

        }
        else if (val1 == "Self")
        {


            GridView2.Visible = true;
            GridView2.Columns[5].Visible = false;

        }
        else
        {

        }
    }
    protected void Search1_Click(object sender, EventArgs e)
    {
        GridView2.Visible = true;
        GridView2.Columns[2].Visible = false;
        GridView2.Columns[4].Visible = false;
        GridView2.Columns[6].Visible = false;
        GridView2.Columns[7].Visible = false;
        GridView2.Columns[8].Visible = false;
        GridView2.Columns[12].Visible = false;
    }
    protected void Drophovacat26_SelectedIndexChanged(object sender, EventArgs e)
    {
        string val1 = ((DropDownList)sender).SelectedValue;
        if (val1 == "student")
        {


        }
        else if (val1 == "Self")
        {

            Gridlistlostdetails.Visible = true;
            Gridlistlostdetails.Columns[0].Visible = false;
            Gridlistlostdetails.Columns[1].Visible = false;
            Gridlistlostdetails.Columns[3].Visible = false;
            Gridlistlostdetails.Columns[4].Visible = false;
            Gridlistlostdetails.Columns[5].Visible = false;
            Gridlistlostdetails.Columns[6].Visible = false;
            Gridlistlostdetails.Columns[7].Visible = false;
            Gridlistlostdetails.Columns[11].Visible = false;
            Gridlistlostdetails.Columns[13].Visible = false;
            Gridlistlostdetails.Columns[14].Visible = true;
        }
        else if (val1 == "Select")
        {

            Gridlistlostdetails.Visible = false;


        }
    }


    protected void PenBut1_Click(object sender, EventArgs e)
    {


        GridViewTempDis.Visible = true;

    }
    protected void DropDownList32_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {

    }
}
   
 
  

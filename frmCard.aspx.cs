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

public partial class frmCard : DBUtility
{
    DataSet dsObj = new DataSet();
    int dsgrid;
    int dsTempgrid;
    SqlCommand cmd=new SqlCommand();
    string strQry = "";
    int i = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            Label lblTitle = new Label();
            lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            lblTitle.Visible = true;
            lblTitle.Text = "Student Identity Card Detail";
                if (!IsPostBack)
                {

                    checksession();
                    geturl();

                    FillPersonlDetail();
                    checksession();
                    geturl();
                    GetData();
                }
  
        }
        catch
        { 
       
        }
    }
    public void FillPersonlDetail()
    {
        try
        {
            if (Convert.ToString(Session["UserType_id"]) == "1")
            {
                strQry = "exec [usp_StudentDashboard] @type='S_Detail',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
                dsObj = sGetDataset(strQry);
                fileImg.ImageUrl = "~\\images\\Profile\\Students\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
            }
            else if (Convert.ToString(Session["UserType_id"]) == "2")
            {
                strQry = "exec [usp_StudentDashboard] @type='P_Detail',@intParent_id='" + Convert.ToString(Session["User_Id"]) + "'";
                dsObj = sGetDataset(strQry);
                fileImg.ImageUrl = "~\\images\\Profile\\Father\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
            }
        }
        catch
        {

        }
    }
    
    protected void GetData()
    {


        string query1 = "Execute dbo.usp_idcard @command='Select' ,@intStudent_id='" + Session["Student_id"] + "'";
        string query2 = "Execute dbo.usp_idcard @command='SelectGrid' ,@intStudent_id='" + Session["Student_id"] + "'";
        //string query2 = "Execute dbo.usp_idcard @command='SelectGrid' ,@intUser_id='2'";

        string query3 = "Execute dbo.usp_Tempidcard @command='TempGridFill' ,@intStudent_id='" + Session["Student_id"] + "'";

        //fileImg.ImageUrl = "~/images/Penguins.jpg";
        dsObj = sGetDataset(query1);
        dsgrid = sBindGrid(GridView2,query2);
        dsTempgrid = sBindGrid(GridViewTempDis, query3);
        
        Session["Table"] = dsObj;
        try
        {
            if (((DataSet)Session["Table"] != null))
            {
                foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                {
                    txtvchmake1.Text = dr[0].ToString();
                    TextBox8.Text = dr[1].ToString();
                    TextBox16.Text = dr[2].ToString();
                    Label11.Text = dr[3].ToString();
                    String src11 = dr[4].ToString();
                    String savePath = "~/images/";
                    //fileImg1.ImageUrl = "abc";
                    //fileImg1.ImageUrl = savePath + src11;
                    //fileImg1.ImageUrl = "~/images/Penguins.jpg";
                   
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
 
   
    protected void Drophovacat15_SelectedIndexChanged(object sender, EventArgs e)
    {

        
    }
    protected void PenBut1_Click(object sender, EventArgs e)
    {

        
    }

 
   
    protected void Drophovacat19_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void Search1card_Click(object sender, EventArgs e)
    {   
        GridView2.Visible = true;
        GridView2.Columns[3].Visible = false;
        GridView2.Columns[4].Visible = false;
      
    }
}
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

public partial class frmAdmListParentsLog : DBUtility
{
    DataSet dsObj = new DataSet();
    
    DataSet dsObj1 = new DataSet();
    public string query1=string.Empty;
    public string query2=string.Empty;
    public string query3=string.Empty;
    public string Disquery=string.Empty;
    public string DeleteIP=string.Empty;
    public string strQry11=string.Empty;
    public string st1=string.Empty;
    public string Disquery1=string.Empty;
    bool st,st2,st3=true;
    int stat1,Div1,Leavegrid,intforumid,intforumid1,intfor3,stat,id=0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           
            if (!IsPostBack)
            {
             
                checksession();
                geturl();
                listparengrid.Visible = false;
                DropDownL1.ClearSelection();
                 query1 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
                 st = sBindDropDownListAll(DropDownL1, query1, "Standard_name", "intStandard_id");
                DropDownL1.SelectedItem.Value = "0";
                 query2 = "Execute dbo.usp_Profile @command='RemarkDivision1',@intSchool_id='" + Session["School_id"] + "' ";
                 st2 = sBindDropDownListAll(DropDownL2, query2, "vchDivisionName", "intDivision_id");

                 query3 = "Execute dbo.usp_Profile @command='AllRollNo',@intSchool_id='" + Session["School_id"] + "'";

                 st3 = sBindDropDownListAll(Droptypeuser, query3, "Name", "intStudent_id");
               
            }
        }
        catch (Exception ex)
        {
        
        }
    }



    protected void filldata()
    {
        try
        {

             stat1 = Convert.ToInt32(DropDownL1.SelectedItem.Value);
             Div1 = Convert.ToInt32(DropDownL2.SelectedItem.Value);
          
             query3 = "Execute dbo.usp_Profile @command='RemarkRollNo',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "' ";
           
             st3 = sBindDropDownListAll(Droptypeuser, query3, "Name", "intStudent_id");
            Droptypeuser.SelectedValue = "A";
             Disquery = "Execute dbo.usp_Profile @command='liststudAll',@intschool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "'";
             Leavegrid = sBindGrid(GridViewliststudvl, Disquery);
          
          
            GridViewliststudvl.Columns[0].Visible = false;
            GridViewliststudvl.Columns[1].Visible = false;
            GridViewliststudvl.Columns[2].Visible = true;
            GridViewliststudvl.Columns[3].Visible = true;
            GridViewliststudvl.Columns[4].Visible = false;
            GridViewliststudvl.Columns[5].Visible = false;
            GridViewliststudvl.Columns[6].Visible = false;
           
        }
        catch
        { 
        }
    }

    protected void GridViewliststud_RowEditing(object sender, GridViewEditEventArgs e)
    {
       
      
    }
    protected void GridViewliststud_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridViewliststud_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

             intforumid = Convert.ToInt32(GridViewliststudvl.DataKeys[e.Row.RowIndex].Value);
            Image img = (Image)e.Row.FindControl("btnDetails");
            img.Attributes.Add("onclick", "window.open('frmLiStudentProfile.aspx?successMessage=" + intforumid + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=500,top=150,left=500');return false");

             intforumid1 = Convert.ToInt32(GridViewliststudvl.DataKeys[e.Row.RowIndex].Value);
            Image img1 = (Image)e.Row.FindControl("btnpareDetails");
            img1.Attributes.Add("onclick", "window.open('frmAdmPareProDetai1.aspx?successMessage=" + intforumid + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=500,top=150,left=500');return false");

             intfor3 = Convert.ToInt32(GridViewliststudvl.DataKeys[e.Row.RowIndex].Value);
            Image img3 = (Image)e.Row.FindControl("ImgEdit");
            img3.Attributes.Add("onclick", "window.open('frmAdmLiStudentProfile.aspx?successMessage3=" + intfor3 + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=500,top=150,left=500');return false");
           
        }
    }
  
    protected void DropDownList37_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void DropDownList38_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownL1_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {

             stat = Convert.ToInt32(DropDownL1.SelectedItem.Value);
         
             query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "' ";
             st2 = sBindDropDownList(DropDownL2, query2, "vchDivisionName", "intDivision_id");
        }
        catch
        {

        }

    }
    protected void DropDownL2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            
               

             stat1 = Convert.ToInt32(DropDownL1.SelectedItem.Value);
             Div1 = Convert.ToInt32(DropDownL2.SelectedItem.Value);
            
             query3 = "Execute dbo.usp_Profile @command='RemarkRollNo',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "' ";

             st3 = sBindDropDownListAll(Droptypeuser, query3, "Name", "intStudent_id");
        }
        catch
        {

        }
    }

    protected void GridViewliststud_RowCancelingEdit(object sender, EventArgs e)
    {

    }
    protected void GridViewliststud_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
           

             id = Convert.ToInt32(GridViewliststudvl.DataKeys[e.RowIndex].Value);
            Session["Deleteid"] = GridViewliststudvl.DataKeys[e.RowIndex].Value;
             DeleteIP = GetSystemIP();
             strQry11 = "Execute dbo.usp_Profile @command='DeleteStudPro',@intStudent_id='" + id + "',@intschool_id='" + Session["School_id"] + "',@vchDeleted_IP='" + DeleteIP + "',@intDeleted_id='" + Session["user_id"] + "'";
            if (sExecuteQuery(strQry11) != -1)
            {
                MessageBox("Record Deleted Successfully");
                //filldata();
            }

        }
        catch
        {


        }
    
    }
    protected void Droptypeuser_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {


            GridViewliststudvl.Visible = true;
             stat1 = Convert.ToInt32(DropDownL1.SelectedItem.Value);
             Div1 = Convert.ToInt32(DropDownL2.SelectedItem.Value);


             st1 = Droptypeuser.SelectedItem.Value;
     

            if (st1 == "A")
            {

                 Disquery1 = "Execute dbo.usp_log @command='StudlogPARALL',@intschool_id='" + Session["School_id"] + "',@intStandard_id='" + stat1 + "',@intDivision_id='" + Div1 + "'";
                 Leavegrid = sBindGrid(GridViewliststudvl, Disquery1);
             

            }
            else if (st1 == "0")
            {
                GridViewliststudvl.Visible = false;
            }
            else
            {

                 Disquery1 = "Execute dbo.usp_log @command='StudlogPARSELE',@intschool_id='" + Session["School_id"] + "',@intStandard_id='" + stat1 + "',@intDivision_id='" + Div1 + "',@intStudent_id='" + st + "'";
                 Leavegrid = sBindGrid(GridViewliststudvl, Disquery1);

            }
        }
        catch 
        {
        
        }
    }
    protected void GridViewliststud_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewliststudvl.PageIndex = e.NewPageIndex;
        filldata();
    }
    protected void GridViewliststudvl_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridViewliststud_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewliststudvl.PageIndex = e.NewPageIndex;
        filldata();
    }

    protected void clear()
    {
        DropDownL1.ClearSelection();
        DropDownL2.ClearSelection();
        Droptypeuser.ClearSelection();
    }
}



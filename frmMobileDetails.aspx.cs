using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Net;
using System.IO;
using System.Configuration;
using System.Collections;

public partial class frmMobileDetails :DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    bool boolSTatus;
    string strStudent_id = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //admin
        if ( Convert.ToInt32(DropDownList1.SelectedIndex) ==4 )
        {
           
            strQry = "exec usp_searchmobile @command='5',@intmobileno='" + TextBox1.Text + "'";
            dsObj = sGetDataset(strQry);
            GridView4.DataSource = dsObj;
            GridView4.DataBind();
            GridView4.Visible = true;
            GridView1.Visible = false;
            GridView2.Visible = false;
            GridView3.Visible = false;

        }
        //Staff
        else if (Convert.ToInt32(DropDownList1.SelectedIndex) == 3)
        {

            strQry = "exec usp_searchmobile @command='4',@intmobileno='" + TextBox1.Text + "'";
            dsObj = sGetDataset(strQry);
            GridView3.DataSource = dsObj;
            GridView3.DataBind();
            GridView3.Visible = true;
            GridView1.Visible = false;
            GridView2.Visible = false;
            GridView4.Visible = false;
        }
        //Teacher
        else if (Convert.ToInt32(DropDownList1.SelectedIndex) == 2)
        {

            strQry = "exec usp_searchmobile @command='3',@intmobileno='" + TextBox1.Text + "'";
            dsObj = sGetDataset(strQry);
            GridView2.DataSource = dsObj;
            GridView2.DataBind();
            GridView2.Visible = true;
            GridView1.Visible = false;
            GridView3.Visible = false;
            GridView4.Visible = false;
        }
        //Student
        else if (Convert.ToInt32(DropDownList1.SelectedIndex) == 1)
        {

            strQry = "exec usp_searchmobile @command='1',@intmobileno='" + TextBox1.Text + "'";
            dsObj = sGetDataset(strQry);
            GridView1.DataSource = dsObj;
            GridView1.DataBind();
            GridView1.Visible = true;
            GridView2.Visible = false;
            GridView3.Visible = false;
            GridView4.Visible = false;
        }
    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
}
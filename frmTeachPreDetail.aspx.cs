using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;

public partial class frmTeachPreDetail :DBUtility
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                checksession();
                geturl();
        
            }

            GridViewPADe.DataSource = createDataTable();
            GridViewPADe.DataBind();
        }
        catch 
        {
        
        }
        }
    //dtDate,vchday,InTime,OutTime
    private object createDataTable()
    {
        DataTable dt = new DataTable();


        dt.Columns.Add("dtDate");
        dt.Columns.Add("vchday");
        dt.Columns.Add("InTime");
        dt.Columns.Add("OutTime");

        DataRow dr1 = dt.NewRow();

        dr1["dtDate"] = "02-08-2014";
        dr1["vchday"] = "Friday";
        dr1["InTime"] = "7:00AM";
        dr1["OutTime"] = "1:00PM";


        dt.Rows.Add(dr1);

        DataRow dr2 = dt.NewRow();

        dr2["dtDate"] = "02-08-2014";
        dr2["vchday"] = "Friday";
        dr2["InTime"] = "7:03AM";
        dr2["OutTime"] = "1:00PM";


        dt.Rows.Add(dr2);

        DataRow dr3 = dt.NewRow();

        dr3["dtDate"] = "03-08-2014";
        dr3["vchday"] = "Friday";
        dr3["InTime"] = "7:03AM";
        dr3["OutTime"] = "1:05PM";


        dt.Rows.Add(dr3);

        DataRow dr4 = dt.NewRow();

        dr4["dtDate"] = "04-08-2014";
        dr4["vchday"] = "Friday";
        dr4["InTime"] = "7:10AM";
        dr4["OutTime"] = "1:06PM";


        dt.Rows.Add(dr4);

        return dt;
    }

}
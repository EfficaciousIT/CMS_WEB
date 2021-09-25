using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Default4 : DBUtility
{
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    DataSet dsObj = new DataSet();
    string[] xAxis;
    int[] yAxis;
    DataTable dt = new DataTable();
    string strQry = "";
    string strCOn = System.Configuration.ConfigurationManager.ConnectionStrings["esmsCentralModel"].ConnectionString;
    SqlConnection sqlCon = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["School_id"] = "1";
        Session["UserType_id"] = "1";
        Session["User_id"] = "0";
        Session["Student_id"] = "372";
        Session["Standard_id"] = "5";
        Session["Division_id"] = "40";

        FillPersonlDetail();
    }
    public void FillPersonlDetail()
    {
        try
        {
            if (Convert.ToString(Session["UserType_id"]) == "1")
            {
                strQry = "exec [usp_StudentDashboard] @type='S_DetailNew',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
                dsObj = sGetDataset(strQry);                
                lblFullname.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Fullname"]);                
                ImgProfile.ImageUrl = "~\\images\\Profile\\Students\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
                

                strQry = "usp_welcomename @command='" + Convert.ToString(Session["UserType_id"]) + "',@UserID='" + Convert.ToString(Session["Student_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
                {
                    
                    lblSTDNm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["STD"]);
                    lblDIVNm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["DIV"]);
                    
                }
                else
                {
                    lblSTDNm.Text = Convert.ToString("");
                    lblDIVNm.Text = Convert.ToString("");
                }
            }
            
        }
        catch
        {

        }
    }
}
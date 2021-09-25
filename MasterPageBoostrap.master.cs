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

public partial class MasterPageBoostrap : System.Web.UI.MasterPage
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
        sqlCon = new SqlConnection(strCOn);
        if (!IsPostBack)
        {
            FillPersonlDetail();
        }
    }
    public void FillPersonlDetail()
    {
        try
        {
            if (Convert.ToString(Session["UserType_id"]) == "1")
            {
                strQry = "exec [usp_StudentDashboard] @type='S_DetailNew',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
                dsObj = sGetDataset(strQry);
                lblWelCome.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Personal"]);
                lblFullname.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Fullname"]);
                lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Fullname"]);
                ImgProfile.ImageUrl = "~\\images\\Profile\\Students\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
                imgProfileImage.ImageUrl = "~\\images\\Profile\\Students\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
            }
            else if (Convert.ToString(Session["UserType_id"]) == "2")
            {
                strQry = "exec [usp_StudentDashboard] @type='P_Detail',@intParent_id='" + Convert.ToString(Session["User_Id"]) + "'";
                dsObj = sGetDataset(strQry);
                lblWelCome.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Personal"]);
                ImgProfile.ImageUrl = "~\\images\\Profile\\Father\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
            }
        }
        catch
        {

        }
    }
    public DataSet sGetDataset(string sQuery)
    {
        DataSet Retds = new DataSet();
        try
        {

            SqlDataAdapter da = new SqlDataAdapter(sQuery, sqlCon);
            if (da != null)
            {
                da.Fill(Retds);
            }
            else
            {
                Retds = null;
            }
        }
        catch (Exception ex)
        {
            Retds = null;
            //MessageBox.Show(ex.ToString());
        }

        return Retds;
    }
}

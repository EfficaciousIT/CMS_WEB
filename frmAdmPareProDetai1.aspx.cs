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


public partial class frmAdmPareProDetai1 : DBUtility
{
    string query1;
    DataSet dsObj1 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Label96.Visible = false;
             try
            {



                if (!IsPostBack)
                {

                    checksession();
                    geturl();
                   
                }
                filldata();
            }

            catch(Exception ex)
            {
            
            }
    
    }

    protected void filldata()
    {

        string st = Request.QueryString["successMessage"];
        TabContainer1.ActiveTabIndex = 0;

        if (Convert.ToString(Session["UserType_id"]) == "3")
        {
            query1 = "Execute dbo.usp_Profile @command='ShowParentsProfileStu1' ,@intUser_id='" + st + "',@intschool_id='" + Session["School_id"] + "'";
        }
        else
        {

            query1 = "Execute dbo.usp_Profile @command='ShowParentsProfileStu' ,@intUser_id='" + st + "',@intschool_id='" + Session["School_id"] + "'";
        }
        dsObj1 = sGetDataset(query1);
        Session["Table"] = dsObj1;
        if (((DataSet)Session["Table"] != null))
        {
            if (dsObj1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                {

                    Label23.Text = dr[0].ToString();
                    Label24.Text = dr[1].ToString();
                    Label25.Text = dr[2].ToString();
                    Label32.Text = dr[3].ToString();

                    Label35.Text = dr[4].ToString();
                    Label39.Text = dr[5].ToString();
                    Label61.Text = dr[6].ToString();
                    Label63.Text = dr[7].ToString();

                    Label45.Text = dr[8].ToString();
                    Label46.Text = dr[9].ToString();
                    Label47.Text = dr[10].ToString();
                    Label48.Text = dr[11].ToString();

                    Label49.Text = dr[12].ToString();

                    Label65.Text = dr[13].ToString();
                    Label67.Text = dr[14].ToString();
                    Label69.Text = dr[15].ToString();

                    Label71.Text = dr[16].ToString();

                    Label91.Text = dr[17].ToString();
                    Label26.Text = dr[18].ToString();
                    Label27.Text = dr[19].ToString();
                    Label28.Text = dr[20].ToString();

                    Label33.Text = dr[21].ToString();
                    Label36.Text = dr[22].ToString();
                    Label40.Text = dr[23].ToString();
                    Label42.Text = dr[24].ToString();

                    Label43.Text = dr[25].ToString();
                    Label50.Text = dr[26].ToString();
                    Label51.Text = dr[27].ToString();
                    Label52.Text = dr[28].ToString();

                    Label53.Text = dr[29].ToString();
                    Label54.Text = dr[30].ToString();
                    Label73.Text = dr[31].ToString();

                    Label75.Text = dr[32].ToString();
                    Label77.Text = dr[33].ToString();


                    Label79.Text = dr[34].ToString();
                    Label93.Text = dr[35].ToString();
                    Label29.Text = dr[36].ToString();

                    Label30.Text = dr[37].ToString();
                    Label31.Text = dr[38].ToString();
                    Label38.Text = dr[39].ToString();
                    Label60.Text = dr[40].ToString();

                    Label44.Text = dr[41].ToString();
                    Label41.Text = dr[42].ToString();
                    Label55.Text = dr[43].ToString();

                    Label56.Text = dr[44].ToString();
                    Label57.Text = dr[45].ToString();

                    Label89.Text = dr[46].ToString();
                    Label58.Text = dr[47].ToString();
                    Label59.Text = dr[48].ToString();
                    Label81.Text = dr[49].ToString();

                    Label83.Text = dr[50].ToString();
                    Label85.Text = dr[51].ToString();
                    Label87.Text = dr[52].ToString();

                    Label95.Text = dr[53].ToString();

                    string srcf11 = dr[54].ToString();
                    String savePath = "~/images/";


                    imgfath1.ImageUrl = "~/images/Profile/Father/" + srcf11;

                    string srcf13 = dr[55].ToString();


                    imgMoth1.ImageUrl = "~/images/Profile/Mother/" + srcf13;
                    string srcf12 = dr[56].ToString();

                    imgGuar1.ImageUrl = "~/images/Profile/Guardian/" + srcf12;

                }
            }
            else
            {
               Label96.Visible = true;
               
               TabContainer1.Visible = false;
            }
        }

    }

}

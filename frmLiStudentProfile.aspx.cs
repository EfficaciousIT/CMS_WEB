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

public partial class frmLiStudentProfile : DBUtility
{
   DataSet dsObj= new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Label lblTitle = new Label();
            //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            //lblTitle.Visible = true;
            //lblTitle.Text = "List Of Student Profile";
            if (!IsPostBack)
            {
                checksession();
                geturl();
                GetData();
            }

           
        }
        catch (Exception ex)
        {
        
        }
        }


    protected void GetData()
    {
        try
        {
            TabContainer1.ActiveTabIndex = 0;
            //Session["Student_id"] = "1";
            string st = Request.QueryString["successMessage"];
            string query1;
            if (st != null)
            {

                query1 = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + st + "',@intschool_id='" + Session["School_id"] + "'";
            }
            else
            {
                query1 = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Session["Student_id"] + "',@intschool_id='" + Session["School_id"] + "'";
            }
            dsObj = sGetDataset(query1);
            if (dsObj.Tables[0].Rows.Count > 0)
            {

                Session["Table"] = dsObj;

                if (((DataSet)Session["Table"] != null))
                {


                    foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                    {

                        lblvn.Text = dr[0].ToString();
                        Label17.Text = dr[1].ToString();
                        Label23.Text = dr[2].ToString();
                        Label24.Text = dr[3].ToString();

                        Label25.Text = dr[4].ToString();
                        Label26.Text = dr[5].ToString();
                        Label27.Text = Convert.ToDateTime(dr[6].ToString()).ToString("dd/MM/yyyy");
                        Label28.Text = dr[7].ToString();

                        Label29.Text = dr[8].ToString();
                        Label30.Text = dr[9].ToString();
                        Label53.Text = dr[10].ToString();
                        Label31.Text = dr[11].ToString();

                        Label32.Text = dr[12].ToString();
                        Label33.Text = dr[13].ToString();
                        Label34.Text = dr[14].ToString();
                        Label58.Text = dr[15].ToString();
                        Label60.Text = dr[16].ToString();

                        Label62.Text = dr[17].ToString();

                        Label64.Text = dr[18].ToString();
                        Label66.Text = dr[19].ToString();
                        Label68.Text = dr[20].ToString();
                        Label70.Text = dr[21].ToString();

                        Label72.Text = dr[22].ToString();
                        Label74.Text = dr[23].ToString();
                        Label76.Text = dr[24].ToString();
                        Label78.Text = dr[25].ToString();

                        Label80.Text = dr[26].ToString();
                        Label82.Text = dr[27].ToString();
                        Label84.Text = dr[28].ToString();
                        Label86.Text = dr[29].ToString();

                        Label88.Text = dr[30].ToString();
                        Label90.Text = dr[31].ToString();
                        Label92.Text = dr[32].ToString();
                        //Label24.Text = dr[33].ToString();

                        Label35.Text = dr[33].ToString();
                        Label36.Text = dr[34].ToString();
                        Label4.Text = dr[35].ToString();
                        Label37.Text = dr[36].ToString();

                        Label38.Text = dr[37].ToString();
                        Label39.Text = dr[38].ToString();
                        Label40.Text = dr[39].ToString();
                        Label41.Text = dr[40].ToString();

                        Label42.Text = dr[41].ToString();
                        Label43.Text = dr[42].ToString();
                        LabelDrName.Text = dr[72].ToString();
                        LabelDrNu.Text = dr[73].ToString();

                        Label13.Text = dr[43].ToString();
                        Label44.Text = dr[44].ToString();

                        Label45.Text = dr[45].ToString();
                        Label46.Text = dr[46].ToString();
                        Label47.Text = dr[47].ToString();
                        Label48.Text = dr[48].ToString();
                        Label49.Text = dr[49].ToString();
                        Label50.Text = dr[50].ToString();
                        Label51.Text = dr[51].ToString();
                        string src11 = dr[52].ToString();

                  
                            String savePath = "~/images/";
                            fileImg.ImageUrl = "~/images/Profile/Students/" + src11;
                        
                        
                       
                        
                        string src13 = dr[53].ToString();



                        fileImg3.ImageUrl = "~/images/Profile/Mother/" + src13;
                        string src12 = dr[54].ToString();



                        fileImg2.ImageUrl = "~/images/Profile/Father/" + src12;

                        string src14 = dr[55].ToString();


                        fileImg4.ImageUrl = "~/images/Profile/Guardian/" + src14;
                        Label75.Text = dr[56].ToString();
                        Label85.Text = dr[57].ToString();
                        Label79.Text = dr[58].ToString();
                        Label89.Text = dr[59].ToString();
                        Label95.Text = dr[60].ToString();
                        Label104.Text = dr[61].ToString();
                        Label106.Text = dr[62].ToString();
                        Label108.Text = dr[63].ToString();
                                
                 

                    }


                }
            }
            else
            {
                Labnorecord.Text = "No Record Found";
                TabContainer1.Visible = false;
            }
        }

      
        catch (Exception ex)
        {


        }

    }
    protected void b1_Click(object sender, EventArgs e)
    {

    }

}

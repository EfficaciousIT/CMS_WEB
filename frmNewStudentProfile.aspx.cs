using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmNewStudentProfile : DBUtility
{
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           
            if (!IsPostBack)
            {
                TabContainer1.ActiveTabIndex = 0;
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
                        //Label17.Text = dr[1].ToString();
                        //Label23.Text = dr[2].ToString();
                        //Label24.Text = dr[3].ToString();

                        //Label25.Text = dr[4].ToString();
                        Label26.Text = dr[5].ToString();
                        Label27.Text = Convert.ToDateTime(dr[6].ToString()).ToString("dd/MM/yyyy");
                    

                        Label29.Text = dr[8].ToString();
                        Label30.Text = dr[9].ToString();
                        Label53.Text = dr[10].ToString();
                        Label31.Text = dr[11].ToString();

                      
                        Label33.Text = dr[36].ToString();
                        Label34.Text = dr[74].ToString();
                        Label58.Text = dr[15].ToString();
                        Label60.Text = dr[11].ToString();

                        Label62.Text = dr[17].ToString();

                      
                      
                        Label70.Text = dr[21].ToString();

                        Label72.Text = dr[36].ToString();
                    
                        //Label24.Text = dr[33].ToString();

                        Label35.Text = dr[74].ToString();
                        Label36.Text = dr[75].ToString();                       
                        string src11 = dr[52].ToString();


                        String savePath = "~/images/Profile/Students/";
                        fileImg.ImageUrl = "~/images/Profile/Students/" + src11;



                        string src13 = dr[53].ToString();



                        fileImg3.ImageUrl = "~/images/Profile/Mother/" + src13;
                        string src12 = dr[54].ToString();



                        fileImg2.ImageUrl = "~/images/Profile/Father/" + src12;

                        string src14 = dr[55].ToString();


                      
                        Label75.Text = dr[56].ToString();
                        Label85.Text = dr[57].ToString();
                        Label79.Text = dr[58].ToString();
                       // Label89.Text = dr[59].ToString();
                    
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
}
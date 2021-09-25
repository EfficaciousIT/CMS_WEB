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

public partial class frmAdmParentsProfile : DBUtility
{
    DataSet dsObj1 = new DataSet();
    DataSet dsObj= new DataSet();
    string id1;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {            
            if (!IsPostBack)
            {
                Button5.Visible = false;
                checksession();
                geturl();
                fGrid();
                string st3 = Request.QueryString["successMessage3"];
                if (st3 != null)
                {
                    query();
                }
                else
                {

                    if (!IsPostBack)
                    {

                        string query2 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
                        bool st = sBindDropDownList(DropDownList1, query2, "Standard_name", "intStandard_id");
                        bool stgrv = sBindDropDownList(ddlStandrd, query2, "Standard_name", "intStandard_id");
                    }
                    if (txtp5.Text != "")
                    {
                        ViewState["Dob"] = txtp5.Text;
                    }
                 
                }
            }

        }

        catch (Exception ex)
        {

        }
    
    }

    protected void query()
    {
        string st3 = Request.QueryString["successMessage3"];
        idvp1.Text = st3;
        TabContainer1.ActiveTabIndex = 0;
        string query1 = "Execute dbo.usp_Profile @command='ShowParentsProf11' ,@intUser_id='" + st3 + "',@intSchool_id='" + Session["School_id"] + "'";

        dsObj = sGetDataset(query1);
        if (dsObj.Tables[0].Rows.Count > 0)
        {

            Session["Table"] = dsObj;

            if (((DataSet)Session["Table"] != null))
            {

                foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                {
                    string qu1 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
                    bool st = sBindDropDownList(DropDownList1, qu1, "Standard_name", "intStandard_id");
                    string standcv1 = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
                    DropDownList1.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
                    string query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + standcv1 + "' ";
                    bool st2 = sBindDropDownList(DropDownList2, query2, "vchDivisionName", "intDivision_id");


                    DropDownList2.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                    string divval1 = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                    string query3 = "Execute dbo.usp_Profile @command='RemarkRollNo',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + standcv1 + "',@intDivision_id='" + divval1 + "' ";

                    bool stv3 = sBindDropDownList(DropDownList3, query3, "Name", "intStudent_id");
                    DropDownList3.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);
                    txtp1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchfatherFirst_name"]);
                    txtp2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchfatherMiddle_name"]);
                    txtp3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchfatherLast_name"]);
                    txtp4.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intFatherMobile"]);
                    txtp5.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtFatherDBO"]);
                    txtp6.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherEmail"]);
                    txtp7.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAddress"]);
                  

                    txtp19.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchmotherFirst_name"]);
                  
                    txtp22.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intMotherMobile"]);
                    txtp23.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtMotherDBO"]);
                    


                    string src11 = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherImageURL"]);

                    String savePath = "~/images/";

                    FatherImg.ImageUrl = savePath + src11;
                    string src12 = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherImageURL"]);


                    MotherImg.ImageUrl = savePath + src12;
                    string src13 = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGuardianImageURL"]);

                   
                   // ButP3.Visible = false;
                    ButN3.Visible = false;
                    Button5.Visible = true;

                }
            }
        }
        else
        {

           ivLab1.Text="No record Found";
           TabContainer1.Visible = false;
        }
    }

    protected void submit(object sender, EventArgs e)
    {
        
        try
        {
            string Fname = Convert.ToString(txtp1.Text);
          
            string FMname = Convert.ToString(txtp2.Text);
            string FLname = Convert.ToString(txtp3.Text);
            string mobiltno = Convert.ToString(txtp4.Text);
            
            string Dobnm = null;
            if (!String.IsNullOrEmpty(txtp5.Text))

                Dobnm = Convert.ToDateTime(txtp5.Text).ToString("MM/dd/yyyy");
           
            string Emailid = Convert.ToString(txtp6.Text);
            string address = Convert.ToString(txtp7.Text);
           
             string filnmn1 = null;
             if (ViewState["Filename1"] != null)
             {

                  filnmn1 = ViewState["Filename1"].ToString();
             }
             string Mothernm = Convert.ToString(txtp19.Text);


             string MMobileno = Convert.ToString(txtp22.Text);
          
             string DobMnm=null;
             if (!String.IsNullOrEmpty(txtp23.Text))

                DobMnm = Convert.ToDateTime(txtp23.Text).ToString("MM/dd/yyyy");


          
          
               
                  string Filename2 = null;
                  string filnmn2 = null;
             if (ViewState["Filename2"] != null)
             {
                  filnmn2 = ViewState["Filename2"].ToString();
             }
                

           

            string GDobnm=null;       


          
                string Filename3 = null;
                string filnmn3 = null;
                if (ViewState["Filename3"] != null)
                {
                    filnmn3 = ViewState["Filename3"].ToString();
                }

            int insertby = Convert.ToInt32(Session["User_id"]);

            string insertdt = DateTime.Now.ToString("MM/dd/yyyy");

            string ipval = GetSystemIP();


            string instrquery1 = "Execute dbo.usp_Profile @command='InsertParentsProfile',@intStudent_id='" + Convert.ToString(DropDownList3.SelectedValue.Trim()) + "',@vchfatherFirst_name='" + Fname + "',@vchfatherMiddle_name='" + FMname + "',@vchfatherLast_name='" + FLname + "',@intFatherMobile='" + mobiltno + "',@dtFatherDBO='" + Dobnm + "',@vchFatherEmail='" + Emailid + "',@vchAddress='" + address + "',@vchFatherImageURL='" + filnmn1 + "'," +
                                  "@vchmotherFirst_name='" + Mothernm + "',"+ 
            "@dtMotherDBO='" + DobMnm + "',@vchMotherImageURL='" + filnmn2 + "'," +
                                  "@vchGuardianImageURL='" + filnmn3 + "',@intInsert_id='" + insertby + "',@dtInsertedDate='" + insertdt + "',@InsertIP='" + ipval + "',@intschool_id='" + Session["school_id"] + "'";


           
            int str = sExecuteQuery(instrquery1);

            string instrquery2 = "Execute dbo.usp_Profile @command='MaxId'";

            dsObj = sGetDataset(instrquery2);
             if (dsObj.Tables[0].Rows.Count > 0)
             {
                 Session["Table"] = dsObj;

                 if (((DataSet)Session["Table"] != null))
                 {


                     foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                     {
                         id1 = dr[0].ToString();
                     }
                 }
             }


             string intstanderd_id = DropDownList1.SelectedItem.Value;
             string intDivision_id = DropDownList2.SelectedItem.Value;
             string intStudent_id = DropDownList3.SelectedItem.Value;

             string instrquery3 = "Execute dbo.usp_Profile @command='UpdateParProfile',@intstanderd_id='" + intstanderd_id + "',@intDivision_id='" + intDivision_id + "',@intStudent_id='" + intStudent_id + "',@intParent_id='" + id1 + "',@intschool_id='" + Session["school_id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "',@intAcademic_id='" + Session["AcademicID"] + "'";

            int str2 = sExecuteQuery(instrquery3);

            if (str2 != -1)
            {
                string display = "Parents Profile Inserted!";
                MessageBox(display);
         
            }
            else
            {
                MessageBox("ooopppsss!Parents Profile Updation Failed");

            }
               

        }

        catch (Exception Ex)
        {


        }

    }

    public void Clear()
    {
        TextBox[] txtp = new TextBox[54];
        int i;
        for (i = 1; i < 54; i++)
        {

            txtp[i].Text = "";

        }
    }

    protected void checknextval1(object sender, EventArgs e)
    {
               
    }
    protected void checknextval2(object sender, EventArgs e)
    {
               
    }
    protected void checkPrivious2(object sender, EventArgs e)
    {
             
    }

    protected void checkPrivious3(object sender, EventArgs e)
    {
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            String savePath = "~/images/";
         

            if (FileUpload1.HasFile)
            {

                FileUpload1.SaveAs("C:/Sneha Bhosle/$neha/e-SMS/images/" + FileUpload1.FileName);
                string file = FileUpload1.PostedFile.FileName;

                FatherImg.ImageUrl = savePath + file;
                Button1.Text = "Change Image";
               
            }

        }
        catch
        {

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {

            String savePath = "~/images/";

            if (FileUpload2.HasFile)
            {
               
                
                    FileUpload2.SaveAs(Server.MapPath("e-SMS/images/") + FileUpload2.FileName);
             //   FileUpload2.SaveAs("C:/Sneha Bhosle/$neha/e-SMS/images/" + FileUpload2.FileName);
                string file = FileUpload2.PostedFile.FileName;

                MotherImg.ImageUrl = savePath + file;
                Button1.Text = "Change Image";
                
            }           
           
        }
        catch
        {

        }
    }
   
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int stat = Convert.ToInt32(DropDownList1.SelectedItem.Value);

            string query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "' ";
            bool st2 = sBindDropDownList(DropDownList2, query2, "vchDivisionName", "intDivision_id");
         
        }
        catch
        {

        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int statv1 = Convert.ToInt32(DropDownList1.SelectedItem.Value);
   
            int Div1 = Convert.ToInt32(DropDownList2.SelectedItem.Value);

            string query3 = "Execute dbo.usp_Profile @command='RemarkRollNo',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + statv1 + "',@intDivision_id='" + Div1 + "' ";

            bool st3 = sBindDropDownList(DropDownList3, query3, "Name", "intStudent_id");     
         
        }
        catch
        {

        }

    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
           
    }
    protected void checknextval4(object sender, EventArgs e)
    {
       
    }
    protected void checkPrivious1(object sender, EventArgs e)
    {
       
     
    }
    protected void Updatev(object sender, EventArgs e)
    {
        try
        {
            string uid=Convert.ToString(idvp1.Text);
            string Fname = Convert.ToString(txtp1.Text);

            string FMname = Convert.ToString(txtp2.Text);
            string FLname = Convert.ToString(txtp3.Text);
            string mobiltno = Convert.ToString(txtp4.Text);

            string Dobnm = null;
            if (!String.IsNullOrEmpty(txtp5.Text))

                Dobnm = Convert.ToDateTime(txtp5.Text).ToString("MM/dd/yyyy");

            string Emailid = Convert.ToString(txtp6.Text);
            string address = Convert.ToString(txtp7.Text);
           
            string filnmn1 = null;
            if (ViewState["Filename1"] != null)
            {
                 filnmn1 = ViewState["Filename1"].ToString();
            }
            string Mothernm = Convert.ToString(txtp19.Text);


            string MMobileno = Convert.ToString(txtp22.Text);

            string DobMnm = null;
            if (!String.IsNullOrEmpty(txtp23.Text))

                DobMnm = Convert.ToDateTime(txtp23.Text).ToString("MM/dd/yyyy");


           

            
            string filnmn2 = null;
            if (ViewState["Filename2"] != null)
            {
                 filnmn2 = ViewState["Filename2"].ToString();
            }
          
            string GDobnm = null;
           

           
            string filnmn3 = null;
            if (ViewState["Filename3"] != null)
            {
                 filnmn3 = ViewState["Filename3"].ToString();
            }

            int intUpdate_id = Convert.ToInt32(Session["User_id"]);

            string dtUpdateDate = DateTime.Now.ToString("MM/dd/yyyy");

            string UpdateIP = GetSystemIP();


            string instrquery1 = "Execute dbo.usp_Profile @command='UpdateParentsProfile',@vchfatherFirst_name='" + Fname + "',@vchfatherMiddle_name='" + FMname + "',@vchfatherLast_name='" + FLname + "',@intFatherMobile='" + mobiltno + "',@dtFatherDBO='" + Dobnm + "',@vchFatherEmail='" + Emailid + "',@vchAddress='" + address + "'," +
                                  "@vchFatherImageURL='" + filnmn1 + "',@vchmotherFirst_name='" + Mothernm + "',@intMotherMobile='" + MMobileno + "',@dtMotherDBO='" + DobMnm + "',@vchMotherImageURL='" + filnmn2 + "',@dtGuardianDBO='" + GDobnm + "'," +
                                  "@vchGuardianImageURL='" + filnmn3 + "',@intUpdate_id='" + intUpdate_id + "',@UpdateIP='" + UpdateIP + "',@intParent_id='" + uid + "',@intschool_id='" + Session["school_id"] + "'";

            int str = sExecuteQuery(instrquery1);         

            if (str != -1)
            {
                string display = "Parent Profile Submit!";
                MessageBox(display);
               // ButN6.Visible = false;
                Clear();

            }
            else
            {
                MessageBox("ooopppsss!Parent Profile submission Failed");

            }

        }

        catch (Exception Ex)
        {


        }
    }


    protected void fGrid()
    {
        string strQry = "usp_Profile @command='SelectParents',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetails.DataSource = dsObj;
            grvDetails.DataBind();
        }
        else
        {
            grvDetails.DataSource = dsObj;
            grvDetails.DataBind();
        }

    }


    protected void ddlStandrd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + Convert.ToString(ddlStandrd.SelectedValue.Trim()) + "' ";
            bool st2 = sBindDropDownList(ddlDiv, query2, "vchDivisionName", "intDivision_id");
        }
        catch
        {

        }
        
    }
    protected void ddlDiv_SelectedIndexChanged(object sender, EventArgs e)
    {
        fStud();
    }
    protected void fStud()
    {
    try
        {
            string squery3 = "Execute dbo.usp_Profile @command='RemarkRollNo',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + Convert.ToString(ddlStandrd.SelectedValue.Trim()) + "',@intDivision_id='" + Convert.ToString(ddlDiv.SelectedValue.Trim()) + "' ";

            bool st3 = sBindDropDownList(ddlRoll, squery3, "Name", "intStudent_id");

        }
        catch
        {

        }
    }
    protected void ddlRoll_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strQry = "usp_Profile @command='SelectStuParents',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intStudent_id='" + Convert.ToString(ddlRoll.SelectedValue.Trim()) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetails.DataSource = dsObj;
            grvDetails.DataBind();
        }
        else
        {
            grvDetails.DataSource = dsObj;
            grvDetails.DataBind();
        }
    }
    protected void grvDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Button5.Visible = true;
            Session["intParent_id"] = Convert.ToString(grvDetails.DataKeys[e.NewEditIndex].Value);
            string strQry = "";
            strQry = "exec usp_Profile @command='editParent',@intParent_id='" + Convert.ToString(Session["intParent_id"]) + "',@intschool_id='" + Session["school_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                DropDownList1.Visible = false;
                Label26.Visible = false;
                Label27.Visible = false;
                DropDownList2.Visible = false;
                Label28.Visible = false;
                DropDownList3.Visible = false;
                txtp1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchfatherFirst_name"]);
                txtp2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchfatherMiddle_name"]);
                txtp3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchfatherLast_name"]);
                //txt4.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                txtp4.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intFatherMobile"]);
                txtp5.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtFatherDBO"]);
                txtp6.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherEmail"]);
                txtp7.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAddress"]);
                txtp19.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchmotherFirst_name"]);
                txtp22.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intMotherMobile"]);
                txtp23.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtMotherDBO"]);
                
                TabContainer1.ActiveTabIndex = 2;
                ButN3.Visible = false;
            }
        }
        catch
        {

        }
    }
}

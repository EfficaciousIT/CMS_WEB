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

public partial class frmLiAdmParentsProfile : DBUtility
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
                checksession();
                geturl();

                string st3 = Request.QueryString["successMessage3"];
                if (st3 != null)
                {
                    query();
                }
                else
                {

                    TabPanel4.Visible = true;
                    TabPanel4.Enabled = true;
                    TabPanel1.Visible = true;
                    TabPanel1.Enabled = false;
                    TabPanel2.Visible = true;
                    TabPanel2.Enabled = false;
                    TabPanel3.Visible = true;
                    TabPanel3.Enabled = false;

                    if (!IsPostBack)
                    {

                        string query2 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
                        bool st = sBindDropDownList(DropDownList1, query2, "Standard_name", "intStandard_id");
                    }
                    if (txtp5.Text != "")
                    {
                        ViewState["Dob"] = txtp5.Text;
                    }
                    if (FileUpload1.PostedFile.FileName != "")
                    {
                        ViewState["Filename1"] = FileUpload1.PostedFile.FileName;
                    }
                    if (FileUpload2.PostedFile.FileName != "")
                    {
                        ViewState["Filename2"] = FileUpload2.PostedFile.FileName;
                    }
                    if (FileUpload3.PostedFile.FileName != "")
                    {
                        ViewState["Filename3"] = FileUpload3.PostedFile.FileName;
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
                    txtp8.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherPassport_no"]);
                    txtp9.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherCompanyName"]);
                    txtp10.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherDesignation"]);
                    txtp11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherCompAdd"]);
                    txtp12.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intFatherTelNo"]);
                    txtp13.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["fltFatherIncomeDet"]);
                    txtp14.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFather_vehicleName"]);
                    txtp15.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFather_VehicleNo"]);
                    txtp16.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFather_PAN"]);
                    txtp17.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFather_BloodGrp"]);
                    txtp18.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherHighestQualification"]);

                    txtp19.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchmotherFirst_name"]);
                    txtp20.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchmotherMiddle_name"]);
                    txtp21.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchmotherLast_name"]);
                    txtp22.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intMotherMobile"]);
                    txtp23.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtMotherDBO"]);
                    txtp24.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherEmail"]);
                    txtp25.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPermanent"]);
                    txtp26.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherPassport_no"]);
                    txtp27.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherCompanyName"]);
                    txtp28.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherDesignation"]);
                    txtp29.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherCompAdd"]);
                    txtp30.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intMotherTelNo"]);
                    txtp31.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["fltMotherIncomeDet"]);
                    txtp32.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMother_vehicleName"]);
                    txtp33.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMother_VehicleNo"]);
                    txtp34.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchmother_PAN"]);
                    txtp35.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMother_BloodGrp"]);
                    txtp36.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherHighestQualification"]);


                    txtp37.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchguardianFirst_name"]);
                    txtp38.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchguardianMiddle_name"]);
                    txtp39.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchguardianLast_name"]);
                    txtp40.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intGuardianMobile"]);
                    txtp41.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtGuardianDBO"]);
                    txtp42.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGuardianAddress"]);
                    txtp43.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGuardianEmail"]);
                    txtp44.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGuardianCompanyName"]);
                    txtp45.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGuardianDesignation"]);
                    txtp46.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGuardianCompAdd"]);
                    txtp47.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGuardianPassport_no"]);
                    txtp48.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intGuardianTelNo"]);
                    txtp49.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["fltGuardianIncomeDet"]);
                    txtp50.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGuardian_vehicleName"]);
                    txtp51.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGuardian_VehicleNo"]);
                    txtp52.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGuardian_PAN"]);
                    txtp53.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGuardian_BloodGrp"]);
                    txtp54.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGuardianHighestQualification"]);


                    string src11 = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherImageURL"]);

                    String savePath = "~/images/";

                    FatherImg.ImageUrl = savePath + src11;
                    string src12 = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherImageURL"]);


                    MotherImg.ImageUrl = savePath + src12;
                    string src13 = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGuardianImageURL"]);


                    GuardianImg.ImageUrl = savePath + src13;


                    TabPanel1.Enabled = true;
                    TabPanel2.Enabled = true;
                    TabPanel3.Enabled = true;
                    TabPanel4.Enabled = true;
                    //TabPanel5.Enabled = true;
                    //ButN7.Visible = false;
                    ButN1.Visible = false;
                   
                    Button4.Visible = false;
                    ButN2.Visible = false;
                    ButP2.Visible = false;
                    ButP3.Visible = false;
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
            string passprt = Convert.ToString(txtp8.Text);
            string comnm = Convert.ToString(txtp9.Text);
            string Fathdesg = Convert.ToString(txtp10.Text);

            string compadd = Convert.ToString(txtp11.Text);
            
            string telepho = Convert.ToString(txtp12.Text);

            string incomdet = Convert.ToString(txtp13.Text);

            string fathvehinm = Convert.ToString(txtp14.Text);

            string vehicalno = Convert.ToString(txtp15.Text);
             string Panno = Convert.ToString(txtp16.Text);
             string bloodgp = Convert.ToString(txtp17.Text);

             string Highqualif = Convert.ToString(txtp18.Text);

             string filnmn1 = ViewState["Filename1"].ToString();
           
             string Mothernm = Convert.ToString(txtp19.Text);
             string MMname = Convert.ToString(txtp20.Text);
             string MLname = Convert.ToString(txtp21.Text);

             long MMobileno = Convert.ToInt64(txtp22.Text);
          
             string DobMnm=null;
             if (!String.IsNullOrEmpty(txtp23.Text))

                DobMnm = Convert.ToDateTime(txtp23.Text).ToString("MM/dd/yyyy");


             string MEmailId = Convert.ToString(txtp24.Text);


             string Maddress = Convert.ToString(txtp25.Text);

             string Mpassportno = Convert.ToString(txtp26.Text);

            
             string Mcompnm = Convert.ToString(txtp27.Text);

             string MDesig = Convert.ToString(txtp28.Text);
           
                
             string Mcomadd = Convert.ToString(txtp29.Text);
            long MTelephono = Convert.ToInt64(txtp30.Text);
          
                  string Mincomedetail = Convert.ToString(txtp31.Text);
                  string MVehicledetail = Convert.ToString(txtp32.Text);
                  string MVehicleno = Convert.ToString(txtp33.Text);
                  string MPanno = Convert.ToString(txtp34.Text);

            

                  string MBloodgp = Convert.ToString(txtp35.Text);
                  string MHighQlif = Convert.ToString(txtp36.Text);
            
                 string filnmn2 = ViewState["Filename2"].ToString();

                 string Gname = Convert.ToString(txtp37.Text);
                 string Gmname = Convert.ToString(txtp38.Text);
                 string Glname = Convert.ToString(txtp39.Text);
            long Gmobino = Convert.ToInt64(txtp40.Text);
           

            string GDobnm=null;
            if (!String.IsNullOrEmpty(txtp41.Text))

                GDobnm = Convert.ToDateTime(txtp41.Text).ToString("MM/dd/yyyy");

            string Gaddress = Convert.ToString(txtp42.Text);
            
            string GEmailid = Convert.ToString(txtp43.Text);
            string GCompnm = Convert.ToString(txtp44.Text);

            string GDesig = Convert.ToString(txtp45.Text);
            string GCompadd = Convert.ToString(txtp46.Text);
            string GPassport = Convert.ToString(txtp47.Text);
            long GTeleno = Convert.ToInt64(txtp48.Text);

            string GIncomeDetai = Convert.ToString(txtp49.Text);

            string GVehiclenm = Convert.ToString(txtp50.Text);
            string GVehicleno = Convert.ToString(txtp51.Text);
            string GPanno = Convert.ToString(txtp52.Text);
            string GBloodGrp = Convert.ToString(txtp53.Text);


            string Ghightquali = Convert.ToString(txtp54.Text);

            string filnmn3 = ViewState["Filename3"].ToString();


            int insertby = Convert.ToInt32(Session["User_id"]);

            string insertdt = DateTime.Now.ToString("MM/dd/yyyy");

            string ipval = GetSystemIP();


            string instrquery1 = "Execute dbo.usp_Profile @command='InsertParentsProfile',@vchfatherFirst_name='" + Fname + "',@vchfatherMiddle_name='" + FMname + "',@vchfatherLast_name='" + FLname + "',@intFatherMobile='" + mobiltno + "',@dtFatherDBO='" + Dobnm + "',@vchFatherEmail='" + Emailid + "',@vchAddress='" + address + "',@vchFatherPassport_no='" + passprt + "',@vchFatherCompanyName='" + comnm + "'," +
                                  "@vchFatherDesignation='" + Fathdesg + "',@vchFatherCompAdd='" + compadd + "',@intFatherTelNo='" + telepho + "',@fltFatherIncomeDet='" + incomdet + "',@vchFather_vehicleName='" + fathvehinm + "',@vchFather_VehicleNo='" + vehicalno + "',@vchFather_PAN='" + Panno + "',@vchFather_BloodGrp='" + bloodgp + "',@vchFatherHighestQualification='" + Highqualif + "',@vchFatherImageURL='" + filnmn1 + "'," +
                                  "@vchmotherFirst_name='" + Mothernm + "',@vchmotherMiddle_name='" + MMname + "',@vchmotherLast_name='" + MLname + "',@intMotherMobile='" + MMobileno + "',@dtMotherDBO='" + DobMnm + "',@vchMotherEmail='" + MEmailId + "',@vchPermanent='" + Maddress + "',@vchMotherPassport_no='" + Mpassportno + "',@vchMotherCompanyName='" + Mcompnm + "',@vchMotherDesignation='" + MDesig + "',@vchMotherCompAdd='" + Mcomadd + "',@intMotherTelNo='" + MTelephono + "'," +
                                  "@vchMother_vehicleName='" + Mincomedetail + "',@vchMother_VehicleNo='" + MVehicleno + "',@vchmother_PAN='" + MPanno + "',@vchMother_BloodGrp='" + MBloodgp + "',@vchMotherHighestQualification='" + MHighQlif + "',@vchMotherImageURL='" + filnmn2 + "',@vchguardianFirst_name='" + Gname + "',@vchguardianMiddle_name='" + Gmname + "',@vchguardianLast_name='" + Glname + "'," +
                                  "@intGuardianMobile='" + Gmobino + "',@dtGuardianDBO='" + GDobnm + "',@vchGuardianAddress='" + Gaddress + "',@vchGuardianEmail='" + GEmailid + "',@vchGuardianCompanyName='" + GCompnm + "',@vchGuardianDesignation='" + GDesig + "',@vchGuardianCompAdd='" + GCompadd + "',@vchGuardianPassport_no='" + GPassport + "',@intGuardianTelNo='" + GTeleno + "'," +
                                  "@fltGuardianIncomeDet='" + GIncomeDetai + "',@vchGuardian_vehicleName='" + GVehiclenm + "',@vchGuardian_VehicleNo='" + GVehicleno + "',@vchGuardian_PAN='" + GPanno + "',@vchGuardian_BloodGrp='" + GBloodGrp + "',@vchGuardianHighestQualification='" + Ghightquali + "',@vchGuardianImageURL='" + filnmn3 + "',@intInsert_id='" + insertby + "',@dtInsertedDate='" + insertdt + "',@InsertIP='" + ipval + "'";


           
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

             string instrquery3 = "Execute dbo.usp_Profile @command='UpdateParProfile',intstanderd_id='" + intstanderd_id + "',intDivision_id='" + intDivision_id + "',intStudent_id='" + intStudent_id + "',intParent_id='" + id1 + "'";

            int str2 = sExecuteQuery(instrquery2);

            if (str != -1)
            {
                string display = "Parents Profile Updated!";
                MessageBox(display);
         
            }
            else
            {
                MessageBox("ooopppsss!Parents Profile Updation Failed");

            }


            TabPanel2.Visible = false;
            TabPanel2.Enabled = false;


            TabPanel1.Visible = true;
            TabPanel1.Enabled = true;

            TabPanel3.Visible = false;
            TabPanel3.Enabled = false;

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
        TabPanel1.Visible = true;
        TabPanel1.Enabled = false;
        TabPanel2.Visible = true;
        TabPanel2.Enabled = true;
        TabPanel3.Visible = true;
        TabPanel3.Enabled = false;
        TabPanel4.Visible = true;
        TabPanel4.Enabled = false;
    }
    protected void checknextval2(object sender, EventArgs e)
    {
        TabPanel1.Visible = true;
        TabPanel1.Enabled = false;
        TabPanel2.Visible = true;
        TabPanel2.Enabled = false;
        TabPanel3.Visible = true;
        TabPanel3.Enabled = true;
        TabPanel4.Visible = true;
        TabPanel4.Enabled = false;
        
    }
    protected void checkPrivious2(object sender, EventArgs e)
    {
        TabPanel1.Visible = true;
        TabPanel1.Enabled = true;
        TabPanel2.Visible = true;
        TabPanel2.Enabled = false;
        TabPanel3.Visible = true;
        TabPanel3.Enabled = false;
        TabPanel4.Visible = true;
        TabPanel4.Enabled = false;
       
    }

    protected void checkPrivious3(object sender, EventArgs e)
    {
        TabPanel1.Visible = true;
        TabPanel1.Enabled = false;
        TabPanel2.Visible = true;
        TabPanel2.Enabled = true;
        TabPanel3.Visible = true;
        TabPanel3.Enabled = false;
        TabPanel4.Visible = true;
        TabPanel4.Enabled = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            String savePath = "~/images/";
            TabPanel1.Visible = true;
            TabPanel1.Enabled = true;

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
                TabPanel1.Visible = true;
                TabPanel1.Enabled = false;
                TabPanel2.Visible = true;
                TabPanel2.Enabled = true;
                
                    FileUpload2.SaveAs(Server.MapPath("e-SMS/images/") + FileUpload2.FileName);
             //   FileUpload2.SaveAs("C:/Sneha Bhosle/$neha/e-SMS/images/" + FileUpload2.FileName);
                string file = FileUpload2.PostedFile.FileName;

                MotherImg.ImageUrl = savePath + file;
                Button1.Text = "Change Image";
                
            }
            TabPanel1.Visible = true;
            TabPanel1.Enabled = false;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = true;

        }
        catch
        {

        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            String savePath = "~/images/";


            TabPanel1.Visible = true;
            TabPanel1.Enabled = false;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = false;
            TabPanel3.Visible = true;
            TabPanel3.Enabled = true;

            if (FileUpload3.HasFile)
            {

                FileUpload3.SaveAs("C:/Sneha Bhosle/$neha/e-SMS/images/" + FileUpload3.FileName);
                string file = FileUpload3.PostedFile.FileName;

                GuardianImg.ImageUrl = savePath + file;
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
            TabPanel1.Visible = true;
            TabPanel1.Enabled = false;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = false;
            TabPanel3.Visible = true;
            TabPanel3.Enabled = false;
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
            TabPanel1.Visible = true;
            TabPanel1.Enabled = false;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = false;
            TabPanel3.Visible = true;
            TabPanel3.Enabled = false;
        }
        catch
        {

        }

    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        TabPanel1.Visible = true;
        TabPanel1.Enabled = false;
        TabPanel2.Visible = true;
        TabPanel2.Enabled = false;
        TabPanel3.Visible = true;
        TabPanel3.Enabled = false;
    }
    protected void checknextval4(object sender, EventArgs e)
    {
        TabPanel4.Visible = true;
        TabPanel4.Enabled = false;
        TabPanel1.Visible = true;
        TabPanel1.Enabled = true;
    }
    protected void checkPrivious1(object sender, EventArgs e)
    {
        TabPanel4.Visible = true;
        TabPanel4.Enabled = true;
        TabPanel1.Visible = true;
        TabPanel1.Enabled = false;
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
            string passprt = Convert.ToString(txtp8.Text);
            string comnm = Convert.ToString(txtp9.Text);
            string Fathdesg = Convert.ToString(txtp10.Text);

            string compadd = Convert.ToString(txtp11.Text);

            string telepho = Convert.ToString(txtp12.Text);

            string incomdet = Convert.ToString(txtp13.Text);

            string fathvehinm = Convert.ToString(txtp14.Text);

            string vehicalno = Convert.ToString(txtp15.Text);
            string Panno = Convert.ToString(txtp16.Text);
            string bloodgp = Convert.ToString(txtp17.Text);

            string Highqualif = Convert.ToString(txtp18.Text);
            string filnmn1 = null;
            if (ViewState["Filename1"] != null)
            {
                 filnmn1 = ViewState["Filename1"].ToString();
            }
            string Mothernm = Convert.ToString(txtp19.Text);
            string MMname = Convert.ToString(txtp20.Text);
            string MLname = Convert.ToString(txtp21.Text);

            long MMobileno = Convert.ToInt64(txtp22.Text);

            string DobMnm = null;
            if (!String.IsNullOrEmpty(txtp23.Text))

                DobMnm = Convert.ToDateTime(txtp23.Text).ToString("MM/dd/yyyy");


            string MEmailId = Convert.ToString(txtp24.Text);


            string Maddress = Convert.ToString(txtp25.Text);

            string Mpassportno = Convert.ToString(txtp26.Text);


            string Mcompnm = Convert.ToString(txtp27.Text);

            string MDesig = Convert.ToString(txtp28.Text);


            string Mcomadd = Convert.ToString(txtp29.Text);
            long MTelephono = Convert.ToInt64(txtp30.Text);

            string Mincomedetail = Convert.ToString(txtp31.Text);
            string MVehicledetail = Convert.ToString(txtp32.Text);
            string MVehicleno = Convert.ToString(txtp33.Text);
            string MPanno = Convert.ToString(txtp34.Text);



            string MBloodgp = Convert.ToString(txtp35.Text);
            string MHighQlif = Convert.ToString(txtp36.Text);
            string filnmn2 = null;
            if (ViewState["Filename2"] != null)
            {
                 filnmn2 = ViewState["Filename2"].ToString();
            }
            string Gname = Convert.ToString(txtp37.Text);
            string Gmname = Convert.ToString(txtp38.Text);
            string Glname = Convert.ToString(txtp39.Text);
            long Gmobino = Convert.ToInt64(txtp40.Text);


            string GDobnm = null;
            if (!String.IsNullOrEmpty(txtp41.Text))

                GDobnm = Convert.ToDateTime(txtp41.Text).ToString("MM/dd/yyyy");

            string Gaddress = Convert.ToString(txtp42.Text);

            string GEmailid = Convert.ToString(txtp43.Text);
            string GCompnm = Convert.ToString(txtp44.Text);

            string GDesig = Convert.ToString(txtp45.Text);
            string GCompadd = Convert.ToString(txtp46.Text);
            string GPassport = Convert.ToString(txtp47.Text);
            long GTeleno = Convert.ToInt64(txtp48.Text);

            string GIncomeDetai = Convert.ToString(txtp49.Text);

            string GVehiclenm = Convert.ToString(txtp50.Text);
            string GVehicleno = Convert.ToString(txtp51.Text);
            string GPanno = Convert.ToString(txtp52.Text);
            string GBloodGrp = Convert.ToString(txtp53.Text);


            string Ghightquali = Convert.ToString(txtp54.Text);
            string filnmn3 = null;
            if (ViewState["Filename3"] != null)
            {
                 filnmn3 = ViewState["Filename3"].ToString();
            }

            int intUpdate_id = Convert.ToInt32(Session["User_id"]);

            string dtUpdateDate = DateTime.Now.ToString("MM/dd/yyyy");

            string UpdateIP = GetSystemIP();


            string instrquery1 = "Execute dbo.usp_Profile @command='UpdateParentsProfile',@vchfatherFirst_name='" + Fname + "',@vchfatherMiddle_name='" + FMname + "',@vchfatherLast_name='" + FLname + "',@intFatherMobile='" + mobiltno + "',@dtFatherDBO='" + Dobnm + "',@vchFatherEmail='" + Emailid + "',@vchAddress='" + address + "',@vchFatherPassport_no='" + passprt + "',@vchFatherCompanyName='" + comnm + "'," +
                                  "@vchFatherDesignation='" + Fathdesg + "',@vchFatherCompAdd='" + compadd + "',@intFatherTelNo='" + telepho + "',@fltFatherIncomeDet='" + incomdet + "',@vchFather_vehicleName='" + fathvehinm + "',@vchFather_VehicleNo='" + vehicalno + "',@vchFather_PAN='" + Panno + "',@vchFather_BloodGrp='" + bloodgp + "',@vchFatherHighestQualification='" + Highqualif + "',@vchFatherImageURL='" + filnmn1 + "'," +
                                  "@vchmotherFirst_name='" + Mothernm + "',@vchmotherMiddle_name='" + MMname + "',@vchmotherLast_name='" + MLname + "',@intMotherMobile='" + MMobileno + "',@dtMotherDBO='" + DobMnm + "',@vchMotherEmail='" + MEmailId + "',@vchPermanent='" + Maddress + "',@vchMotherPassport_no='" + Mpassportno + "',@vchMotherCompanyName='" + Mcompnm + "',@vchMotherDesignation='" + MDesig + "',@vchMotherCompAdd='" + Mcomadd + "',@intMotherTelNo='" + MTelephono + "'," +
                                  "@vchMother_vehicleName='" + Mincomedetail + "',@vchMother_VehicleNo='" + MVehicleno + "',@vchmother_PAN='" + MPanno + "',@vchMother_BloodGrp='" + MBloodgp + "',@vchMotherHighestQualification='" + MHighQlif + "',@vchMotherImageURL='" + filnmn2 + "',@vchguardianFirst_name='" + Gname + "',@vchguardianMiddle_name='" + Gmname + "',@vchguardianLast_name='" + Glname + "'," +
                                  "@intGuardianMobile='" + Gmobino + "',@dtGuardianDBO='" + GDobnm + "',@vchGuardianAddress='" + Gaddress + "',@vchGuardianEmail='" + GEmailid + "',@vchGuardianCompanyName='" + GCompnm + "',@vchGuardianDesignation='" + GDesig + "',@vchGuardianCompAdd='" + GCompadd + "',@vchGuardianPassport_no='" + GPassport + "',@intGuardianTelNo='" + GTeleno + "'," +
                                  "@fltGuardianIncomeDet='" + GIncomeDetai + "',@vchGuardian_vehicleName='" + GVehiclenm + "',@vchGuardian_VehicleNo='" + GVehicleno + "',@vchGuardian_PAN='" + GPanno + "',@vchGuardian_BloodGrp='" + GBloodGrp + "',@vchGuardianHighestQualification='" + Ghightquali + "',@vchGuardianImageURL='" + filnmn3 + "',@intUpdate_id='" + intUpdate_id + "',@UpdateIP='" + UpdateIP + "',@intParent_id='" + uid + "',@intschool_id='" + Session["school_id"] + "'";

            int str = sExecuteQuery(instrquery1);

           

            TabPanel2.Visible = false;
            TabPanel2.Enabled = false;


            TabPanel1.Visible = true;
            TabPanel1.Enabled = true;

            TabPanel3.Visible = false;
            TabPanel3.Enabled = false;

        }

        catch (Exception Ex)
        {


        }
    }


}

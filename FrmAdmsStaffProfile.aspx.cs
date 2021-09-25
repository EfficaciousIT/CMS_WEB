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

public partial class FrmAdmsStaffProfile : DBUtility
{
    DataSet dsObj1 = new DataSet();
    DataSet dsObj = new DataSet();
    string strQry;
    protected void Page_Load(object sender, EventArgs e)
    {         
        try
            {
            if (!IsPostBack)
            {
                TabContainer1.Visible = false;
                checksession();
                geturl();
                FillUserType();
                //filldata();
                CompareValidator3.ValueToCompare = DateTime.Now.ToString("dd/MM/yyyy");     
                string st = Request.QueryString["successMessage"];
                string st1 = Request.QueryString["successMessage1"];
       
                if (st!=null)
                {
                    //Detai();
                }
                else
                {
                    others();
                }

                if (st1 != null)
                {
                    Editv();  
                }            
                }
            }
        catch (Exception ex)
        {
        }
     }

    public void FillUserType()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_FillDropDown] @type='StaffUserType',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlType, strQry, "vchUser_name", "intUserType_id");
        }
        catch
        {
            MessageBox("Problem Found");
        }
    }
    protected void Detai()
    {
        try
        {
            string st = Request.QueryString["successMessage"];

            TabContainer1.ActiveTabIndex = 0;

            string query1 = "Execute dbo.usp_Profile @command='ShowStaffProfile' ,@intUser_id='" + Convert.ToString(ddlTeacher.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intUserType_id='" + Session["UserType_id"] + "'";

            dsObj = sGetDataset(query1);
            if (dsObj.Tables[0].Rows.Count > 0)
            {

                Session["Table"] = dsObj;

                if (((DataSet)Session["Table"] != null))
                {


                    foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                    {

                        //lab1.Text = st;
                        TextBox1.Visible = false;
                        TextBox2.Visible = false;
                        TextBox3.Visible = false;
                        TextBox4.Visible = false;
                        TextBox5.Visible = false;
                        ddlDesignation.Visible = false;
                        ddlAcademicYear.Visible = false;
                        TextBox6.Visible = false;
                        TextBox7.Visible = false;
                        TextBox8.Visible = false;
                        TextBox9.Visible = false;
                        TextBox10.Visible = false;
                        TextBox11.Visible = false;
                        TextBox12.Visible = false;
                        TextBox13.Visible = false;
                        TextBox14.Visible = false;
                        TextBox15.Visible = false;
                        TextBox16.Visible = false;
                        TextBox17.Visible = false;
                        //   bro1.Visible = false;
                        txtDegree1.Visible = false;
                        txtInstitution1.Visible = false;
                        txtUniversity1.Visible = false;
                        txtPassingYear1.Visible = false;
                        txtPercent1.Visible = false;
                        txtMajorSubject1.Visible = false;
                        txtDegree2.Visible = false;
                        txtInstitution2.Visible = false;
                        txtUniversity2.Visible = false;
                        txtPassingYear2.Visible = false;
                        txtPercent2.Visible = false;
                        txtMajorSubject2.Visible = false;
                        txtDegree3.Visible = false;
                        txtInstitution3.Visible = false;
                        txtUniversity3.Visible = false;
                        txtPassingYear3.Visible = false;
                        txtPercent3.Visible = false;
                        txtMajorSubject3.Visible = false;
                        txtDegree4.Visible = false;
                        txtInstitution4.Visible = false;
                        txtUniversity4.Visible = false;
                        txtPassingYear4.Visible = false;
                        txtPercent4.Visible = false;
                        txtMajorSubject4.Visible = false;
                        txtDegree5.Visible = false;
                        txtInstitution5.Visible = false;
                        txtUniversity5.Visible = false;
                        txtPassingYear5.Visible = false;
                        txtPercent5.Visible = false;
                        txtMajorSubject5.Visible = false;
                        Button4.Visible = false;
                        Button5.Visible = false;
                        Button6.Visible = false;
                        Button7.Visible = false;
                        Button3.Visible = false;
                        Button8.Visible = false;
                        ButP2.Visible = false;
                        TextBox18.Visible = false;

                        Label1.Text = dr[1].ToString();
                        Label2.Text = dr[2].ToString();
                        Label5.Text = dr[3].ToString();

                        Label6.Text = dr[4].ToString();
                        Label10.Text = dr[5].ToString();
                        Label11.Text = dr[6].ToString();
                        Label22.Text = dr[7].ToString();

                        Label23.Text = dr[8].ToString();
                        Label24.Text = dr[9].ToString();
                        Label25.Text = dr[10].ToString();
                        Label26.Text = dr[11].ToString();

                        Label27.Text = dr[12].ToString();
                        Label28.Text = dr[13].ToString();
                        Label29.Text = dr[14].ToString();
                        Label30.Text = dr[15].ToString();
                        Label31.Text = dr[16].ToString();
                        Label32.Text = dr[17].ToString();
                        Label33.Text = dr[49].ToString();
                        txtDegreev1.Text = dr[18].ToString();
                        txtInstitutionv1.Text = dr[19].ToString();
                        txtUniversityv1.Text = dr[20].ToString();
                        txtPassingYearv1.Text = dr[21].ToString();
                        txtPercentv1.Text = dr[22].ToString();
                        txtMajorSubjectv1.Text = dr[23].ToString();
                        if (dr[24].ToString() != "")
                        {
                            tr2.Visible = true;
                            txtDegreev2.Text = dr[24].ToString();
                            txtInstitutionv2.Text = dr[25].ToString();
                            txtUniversityv2.Text = dr[26].ToString();
                            txtPassingYearv2.Text = dr[27].ToString();
                            txtPercentv2.Text = dr[28].ToString();
                            txtMajorSubjectv2.Text = dr[29].ToString();
                        }
                        if (dr[30].ToString() != "")
                        {
                            tr3.Visible = true;
                            txtDegreev3.Text = dr[30].ToString();
                            txtInstitutionv3.Text = dr[31].ToString();
                            txtUniversityv3.Text = dr[32].ToString();
                            txtPassingYearv3.Text = dr[33].ToString();
                            txtPercentv3.Text = dr[34].ToString();
                            txtMajorSubjectv3.Text = dr[35].ToString();
                        }
                        if (dr[36].ToString() != "")
                        {
                            tr4.Visible = true;
                            txtDegreev4.Text = dr[36].ToString();
                            txtInstitutionv4.Text = dr[37].ToString();
                            txtUniversityv4.Text = dr[38].ToString();
                            txtPassingYearv4.Text = dr[39].ToString();
                            txtPercentv4.Text = dr[40].ToString();
                            txtMajorSubjectv4.Text = dr[41].ToString();
                        }
                        if (dr[36].ToString() != "")
                        {
                            tr5.Visible = true;
                            txtDegreev5.Text = dr[42].ToString();
                            txtInstitutionv5.Text = dr[43].ToString();
                            txtUniversityv5.Text = dr[44].ToString();
                            txtPassingYearv5.Text = dr[45].ToString();
                            txtPercentv5.Text = dr[46].ToString();
                            txtMajorSubjectv5.Text = dr[47].ToString();
                        }
                        Button2.Visible = false;
                        ButN1.Visible = false;
                        ButN2.Visible = false;


                        string src11 = dr[48].ToString();
                        String savePath = "~/images/";

                        TeacherImg.ImageUrl = savePath + src11;
                        lblDesignation.Text = dr[50].ToString();
                        lblAcademicYear.Text = dr[51].ToString();

                    }

                }
            }
            else
            {
                Labnorecord.Text = "No Data Found";
                TabContainer1.Visible = false;
            }
    
    
        }
        catch
        {
        }

        
    }

    protected void Editv()
    {

        try
        {
            string st1 = Request.QueryString["successMessage1"];
            TabPanel1.Visible = true;
            TabPanel1.Enabled = true;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = true;
            TabPanel3.Visible = true;
            TabPanel3.Enabled = true;
            ButN1.Visible = false;
            ButP2.Visible = false;
            ButN2.Visible = false;
            Button3.Visible = false;
            TabContainer1.ActiveTabIndex = 0;
            string query1 = "Execute dbo.usp_Profile @command='ShowStaffProfile' ,@intUser_id='" + st1 + "',@intSchool_id='" + Session["School_id"] + "',@intUserType_id='" + Session["UserType_id"] + "'";

            dsObj = sGetDataset(query1);
            if (dsObj.Tables[0].Rows.Count > 0)
            {

                Session["Table"] = dsObj;

                if (((DataSet)Session["Table"] != null))
                {


                    foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                    {
                        lab2.Text = st1;
                        
                        TextBox1.Text = dr[1].ToString();
                        TextBox2.Text = dr[2].ToString();
                        TextBox3.Text = dr[3].ToString();
                        TextBox4.Text = dr[4].ToString();
                        TextBox5.SelectedValue = dr[5].ToString();
                        TextBox6.Text = dr[6].ToString();
                        TextBox7.Text = dr[7].ToString();
                        TextBox8.Text = dr[8].ToString();
                        TextBox9.Text = dr[9].ToString();
                        TextBox10.Text = dr[10].ToString();
                        TextBox11.Text = dr[11].ToString();
                        TextBox12.Text = dr[12].ToString();
                        TextBox13.Text = dr[13].ToString();
                        TextBox14.Text = dr[14].ToString();
                        TextBox15.Text = dr[15].ToString();
                        TextBox16.Text = dr[16].ToString();
                        TextBox17.Text = dr[17].ToString();
                        if (dr[18].ToString() != "")
                        {

                            tr1.Visible = true;
                            Button4.Text = "-";
                            txtDegree1.Text = dr[18].ToString();
                            txtInstitution1.Text = dr[19].ToString();
                            txtUniversity1.Text = dr[20].ToString();
                            txtPassingYear1.Text = dr[21].ToString();
                            txtPercent1.Text = dr[22].ToString();
                            txtMajorSubject1.Text = dr[23].ToString();
                        }
                        if (dr[24].ToString() != "")
                        {
                            tr2.Visible = true;
                            Button5.Text = "-";
                            txtDegree2.Text = dr[24].ToString();
                            txtInstitution2.Text = dr[25].ToString();
                            txtUniversity2.Text = dr[26].ToString();
                            txtPassingYear2.Text = dr[27].ToString();
                            txtPercent2.Text = dr[28].ToString();
                            txtMajorSubject2.Text = dr[29].ToString();
                        }
                        if (dr[30].ToString() != "")
                        {
                            Button6.Text = "-";
                            tr3.Visible = true;
                            txtDegree3.Text = dr[30].ToString();
                            txtInstitution3.Text = dr[31].ToString();
                            txtUniversity3.Text = dr[32].ToString();
                            txtPassingYear3.Text = dr[33].ToString();
                            txtPercent3.Text = dr[34].ToString();
                            txtMajorSubject3.Text = dr[35].ToString();
                        }
                        if (dr[36].ToString() != "")
                        {
                            Button7.Text = "-";
                            tr4.Visible = true;
                            txtDegree4.Text = dr[36].ToString();
                            txtInstitution4.Text = dr[37].ToString();
                            txtUniversity4.Text = dr[38].ToString();
                            txtPassingYear4.Text = dr[39].ToString();
                            txtPercent4.Text = dr[40].ToString();
                            txtMajorSubject4.Text = dr[41].ToString();
                        }
                        if (dr[42].ToString() != "")
                        {
                            tr5.Visible = true;
                            txtDegree5.Text = dr[42].ToString();
                            txtInstitution5.Text = dr[43].ToString();
                            txtUniversity5.Text = dr[44].ToString();
                            txtPassingYear5.Text = dr[45].ToString();
                            txtPercent5.Text = dr[46].ToString();
                            txtMajorSubject5.Text = dr[47].ToString();
                        }

                        
                        Button8.Visible = true;
                        Button2.Visible = false;

                        TextBox18.Text = dr[49].ToString();
                        string src11 = dr[48].ToString();
                        String savePath = "~/images/";

                        TeacherImg.ImageUrl = savePath + src11;
                        lblDesignation.Text = dr[50].ToString();

                  
                    }
                }
            }
        }
        catch
        { 
        
        
        }
    
    }
    protected void others()
    {
        try
        {

            string st1 = Request.QueryString["successMessage1"];

            if (st1 == null)
            {
                TabContainer1.ActiveTabIndex = 0;
                TabPanel3.Visible = true;
                TabPanel3.Enabled = true;
                TabPanel2.Visible = true;
                TabPanel2.Enabled = true;
                TabPanel1.Visible = true;
                TabPanel1.Enabled = true;
                String dt = Request.Form[TextBox7.UniqueID];
                filldata();

                if (FileUpload1.FileName != "")
                {
                    ViewState["Filename1"] = FileUpload1.PostedFile.FileName;
                }

                if (dt != "")
                {
                    ViewState["mdob"] = dt;

                    TextBox7.Text = Convert.ToString(ViewState["mdob"]);
                }
            }
        }
        catch
        {
        }

    }
    protected void filldata()
    {
        try
        {

            string query1 = "Execute dbo.usp_Profile @command='ShowDepartment',@intSchool_id='" + Session["School_id"] + "' ";
            bool st = sBindDropDownList(TextBox5, query1, "vchDepartment_name", "intDepartment");
        }
        catch
        {
        }
    }
    public void fillAcademicYear()
    {
        try
        {
            string strQry = "";
            strQry = "exec usp_StudentAllotment @type='fillAcademicYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlAcademicYear, strQry, "AcademicYear", "intAcademic_id");
            ddlAcademicYear.SelectedValue = "1";
        }
        catch
        {

        }
    }
    protected void TextBox15_TextChanged(object sender, EventArgs e)
    {



    }
    protected void checkPrivious3(object sender, EventArgs e)
    {
        TabPanel3.Visible = false;
        TabPanel3.Enabled = false;
        TabPanel2.Visible = true;
        TabPanel2.Enabled = true;
        TabPanel1.Visible = true;
        TabPanel1.Enabled = false;
    }
    protected void checkPrivious2(object sender, EventArgs e)
    {
        TabPanel3.Visible = false;
        TabPanel3.Enabled = false;
        TabPanel2.Visible = false;
        TabPanel2.Enabled = false;
        TabPanel1.Visible = true;
        TabPanel1.Enabled = true;
    }
    protected void checknextval2(object sender, EventArgs e)
    {
        TabPanel3.Visible = true;
        TabPanel3.Enabled = true;
        TabPanel2.Visible = true;
        TabPanel2.Enabled = false;
        TabPanel1.Visible = true;
        TabPanel1.Enabled = false;
    }
    protected void checknextval1(object sender, EventArgs e)
    {
        TabPanel3.Visible = false;
        TabPanel3.Enabled = false;
        TabPanel2.Visible = true;
        TabPanel2.Enabled = true;
        TabPanel1.Visible = true;
        TabPanel1.Enabled = false;


       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            String savePath = "~/images/";
       

            if (FileUpload1.HasFile)
            {

                FileUpload1.SaveAs(Server.MapPath("e-SMS/images/") + FileUpload1.FileName);
                string file = FileUpload1.PostedFile.FileName;

                TeacherImg.ImageUrl = savePath + file;
                Button1.Text = "Change Image";
              
            }

        }
        catch
        {

        }
    }
    protected void submit(object sender, EventArgs e)
    {
        try
        {

            string txtDev1 = Convert.ToString(txtDegree1.Text);
            string txtInv1 = Convert.ToString(txtInstitution1.Text);
            string txtUnv1 = Convert.ToString(txtUniversity1.Text);
            string txtPaYv1 = Convert.ToString(txtPassingYear1.Text);
            string txtPe1 = Convert.ToString(txtPercent1.Text);
            string txtMaSv1 = Convert.ToString(txtMajorSubject1.Text);

            string txtDev2 = null, txtInv2 = null, txtUnv2 = null, txtPaYv2 = null, txtPe2 = null, txtMaSv2 = null, txtDev3 = null, txtInv3 = null;
            string txtUnv3 = null, txtPaYv3 = null, txtPe3 = null, txtMaSv3 = null, txtDev4 = null, txtInv4 = null, txtUnv4 = null, txtPaYv4 = null;
            string txtPe4 = null, txtMaSv4 = null, txtDev5 = null, txtInv5 = null, txtUnv5 = null, txtPaYv5 = null, txtPe5 = null, txtMaSv5 = null;
            if (tr2.Visible == true)
            {
                txtDev2 = Convert.ToString(txtDegree2.Text);
                txtInv2 = Convert.ToString(txtInstitution2.Text);
                txtUnv2 = Convert.ToString(txtUniversity2.Text);
                txtPaYv2 = Convert.ToString(txtPassingYear2.Text);
                txtPe2 = Convert.ToString(txtPercent2.Text);
                txtMaSv2 = Convert.ToString(txtMajorSubject2.Text);

            }
            if (tr3.Visible == true)
            {
                txtDev3 = Convert.ToString(txtDegree3.Text);
                txtInv3 = Convert.ToString(txtInstitution3.Text);
                txtUnv3 = Convert.ToString(txtUniversity3.Text);
                txtPaYv3 = Convert.ToString(txtPassingYear3.Text);
                txtPe3 = Convert.ToString(txtPercent3.Text);
                txtMaSv3 = Convert.ToString(txtMajorSubject3.Text);

            }
            if (tr4.Visible == true)
            {
                txtDev4 = Convert.ToString(txtDegree4.Text);
                txtInv4 = Convert.ToString(txtInstitution4.Text);
                txtUnv4 = Convert.ToString(txtUniversity4.Text);
                txtPaYv4 = Convert.ToString(txtPassingYear4.Text);
                txtPe4 = Convert.ToString(txtPercent4.Text);
                txtMaSv4 = Convert.ToString(txtMajorSubject4.Text);

            }
            if (tr5.Visible == true)
            {
                txtDev5 = Convert.ToString(txtDegree5.Text);
                txtInv5 = Convert.ToString(txtInstitution5.Text);
                txtUnv5 = Convert.ToString(txtUniversity5.Text);
                txtPaYv5 = Convert.ToString(txtPassingYear5.Text);
                txtMaSv5 = Convert.ToString(txtMajorSubject2.Text);

            }



            string tfname = Convert.ToString(TextBox1.Text);
            string tmname = Convert.ToString(TextBox2.Text);
            string tlname = Convert.ToString(TextBox3.Text);
            string tPSubject = Convert.ToString(TextBox4.Text);
            string tDepartnm = Convert.ToString(TextBox5.Text);
            string gender = Convert.ToString(TextBox6.SelectedItem.Value);
            string tDobnm = null;
            if (!String.IsNullOrEmpty(TextBox7.Text))

                tDobnm = Convert.ToDateTime(TextBox7.Text).ToString("MM/dd/yyyy");

            string Emailvl = Convert.ToString(TextBox8.Text);
            string Qualif = Convert.ToString(TextBox9.Text);
            long? TelePhone1 = null;
            if (TelePhone1.HasValue)
            {
                TelePhone1 = Convert.ToInt64(TextBox10.Text);
            }

            long? TelePhone2 = null;
            if (TelePhone2.HasValue)
            {
                TelePhone2 = Convert.ToInt64(TextBox11.Text);
            }

            long? Tmobino = null;
            if (Tmobino.HasValue)
            {
                Tmobino = Convert.ToInt64(TextBox12.Text);
            }
            string faceurl = Convert.ToString(TextBox13.Text);
            string Twiurl = Convert.ToString(TextBox14.Text);
            string otheurl = Convert.ToString(TextBox15.Text);
            string filnmn1 = null;
            if (ViewState["Filename1"] != null)
            {
                filnmn1 = ViewState["Filename1"].ToString();
            }
            string Preaddress = Convert.ToString(TextBox16.Text);
            string Paraddress = Convert.ToString(TextBox17.Text);

            long? insertby = null;
            if (insertby.HasValue)
            {
                insertby = Convert.ToInt64(Session["User_id"]);
            }
            string insertdt = DateTime.Now.ToString("MM/dd/yyyy");

            string ipval = GetSystemIP();

            string instrquery1 = "Execute dbo.usp_Profile @command='insertStaff',@vchFirst_name='" + tfname + "',@vchMiddle_name='" + tmname + "',@vchLast_name='" + tlname + "',@vchPreferedSubject='" + tPSubject + "',@intsubject_id='" + tDepartnm + "',@vchGender='" + gender + "',@dtDOB='" + tDobnm + "',@vchEmail='" + Emailvl + "',@vchHighestQualification='" + Qualif + "'," +
                                     "@intTelNo1='" + TelePhone1 + "',@intTelNo2='" + TelePhone2 + "',@intMobileNo='" + Tmobino + "',@vchFacebookURL='" + faceurl + "',@vchTwitterURL='" + Twiurl + "',@vchOtherURL='" + otheurl + "',@vchImageURL='" + filnmn1 + "',@vchAddress='" + Preaddress + "',@vchPermanent='" + Paraddress + "'," +
                                     "@intSchool_id='" + Session["School_id"] + "',@intInserted_id='" + insertby + "',@dtInserted_Date='" + insertdt + "',@vchInserted_IP='" + ipval + "'," +
                                     "@vchDegree1='" + txtDev1 + "',@vchInstitution1='" + txtInv1 + "',@vchtxtUniversity1='" + txtUnv1 + "',@intPassingYear1='" + txtPaYv1 + "',@vchPercent1='" + txtPe1 + "'," +
                                     "@vchMajorSubject1='" + txtMaSv1 + "',@vchDegree2='" + txtDev2 + "',@vchInstitution2='" + txtInv2 + "',@vchtxtUniversity2='" + txtUnv2 + "',@intPassingYear2='" + txtPaYv2 + "'," +
                                     "@vchPercent2='" + txtPe2 + "',@vchMajorSubject2='" + txtMaSv2 + "',@vchDegree3='" + txtDev3 + "',@vchInstitution3='" + txtInv3 + "',@vchtxtUniversity3='" + txtUnv3 + "'," +
                                     "@intPassingYear3='" + txtPaYv3 + "',@vchPercent3='" + txtPe3 + "',@vchMajorSubject3='" + txtMaSv3 + "',@vchDegree4='" + txtDev4 + "',@vchInstitution4='" + txtInv4 + "'," +
                                     "@vchtxtUniversity4='" + txtUnv4 + "',@intPassingYear4='" + txtPaYv4 + "',@vchPercent4='" + txtPe4 + "',@vchMajorSubject4='" + txtMaSv4 + "',@vchDegree5='" + txtDev5 + "'," +
                                     "@vchInstitution5='" + txtInv5 + "',@vchtxtUniversity5='" + txtUnv5 + "',@intPassingYear5='" + txtPaYv5 + "',@vchPercent5='" + txtPe5 + "',@vchMajorSubject5='" + txtMaSv5 + "'";
            int str = sExecuteQuery(instrquery1);

            if (str != -1)
            {
                string display = "Teacher Profile Saved!";
                MessageBox(display);
                Clear();
            }
            else
            {
                MessageBox("ooopppsss!Teacher Profile failed");

            }

        }
        catch
        { 
        
        
        }

    }
    protected void Clear()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.SelectedValue = "0";
       
       // TextBox6.SelectedValue = "select";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        TextBox13.Text = "";
        TextBox14.Text = "";
        TextBox15.Text = "";
        TextBox16.Text = "";
        TextBox17.Text = "";
     
    
    }
    protected void TextBox6_SelectedIndexChanged(object sender, EventArgs e)
    {

       
        if (TextBox6.SelectedIndex == 0)
        {
            MessageBox("Please select a Value");

        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

        if (Button4.Text == "+")
        {

            tr2.Visible = true;
        }
        else
        {
            Button4.Visible = false;
            tr2.Visible = false;
        }
        //TabPanel1.Visible = true;
        //TabPanel1.Enabled = false;
        //TabPanel2.Visible = true;
        //TabPanel2.Enabled = false;
        //TabPanel3.Visible = true;
        //TabPanel3.Enabled = true;
        //Button4.Visible = false;
       
        
        
        

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
   


        if (Button5.Text == "+")
        {

            tr3.Visible = true;
        }
        else
        {
            Button5.Visible = false;
            tr3.Visible = false;
        }
        //TabPanel1.Visible = true;
        //TabPanel1.Enabled = false;
        //TabPanel2.Visible = true;
        //TabPanel2.Enabled = false;
        //TabPanel3.Visible = true;
        //TabPanel3.Enabled = true;
        //Button4.Visible = false;
        //Button5.Visible = false;
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
       
        if (Button6.Text == "+")
        {

            tr4.Visible = true;
        }
        else
        {
            Button6.Visible = false;
            tr4.Visible = false;
        }
        //TabPanel1.Visible = true;
        //TabPanel1.Enabled = false;
        //TabPanel2.Visible = true;
        //TabPanel2.Enabled = false;
        //TabPanel3.Visible = true;
        //TabPanel3.Enabled = true;
        //Button4.Visible = false;
        //Button5.Visible = false;
        //Button6.Visible = false;
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        if (Button7.Text == "+")
        {

            tr5.Visible = true;
        }
        else
        {
            Button7.Visible = false;
            tr5.Visible = false;
        }
            //TabPanel1.Visible = true;
        //TabPanel1.Enabled = false;
        //TabPanel2.Visible = true;
        //TabPanel2.Enabled = false;
        //TabPanel3.Visible = true;
        //TabPanel3.Enabled = true;
        //Button4.Visible = false;
        //Button5.Visible = false;
        //Button6.Visible = false;
        //Button7.Visible = false;
    }
    protected void Updateval(object sender, EventArgs e)
    {
        try
        {

            string txtDev1 = Convert.ToString(txtDegree1.Text);
            string txtInv1 = Convert.ToString(txtInstitution1.Text);
            string txtUnv1 = Convert.ToString(txtUniversity1.Text);
            string txtPaYv1 = Convert.ToString(txtPassingYear1.Text);
            string txtPe1 = Convert.ToString(txtPercent1.Text);
            string txtMaSv1 = Convert.ToString(txtMajorSubject1.Text);

            string txtDev2 = null, txtInv2 = null, txtUnv2 = null, txtPaYv2 = null, txtPe2 = null, txtMaSv2 = null, txtDev3 = null, txtInv3 = null;
            string txtUnv3 = null, txtPaYv3 = null, txtPe3 = null, txtMaSv3 = null, txtDev4 = null, txtInv4 = null, txtUnv4 = null, txtPaYv4 = null;
            string txtPe4 = null, txtMaSv4 = null, txtDev5 = null, txtInv5 = null, txtUnv5 = null, txtPaYv5 = null, txtPe5 = null, txtMaSv5 = null;
            if (tr2.Visible == true)
            {
                txtDev2 = Convert.ToString(txtDegree2.Text);
                txtInv2 = Convert.ToString(txtInstitution2.Text);
                txtUnv2 = Convert.ToString(txtUniversity2.Text);
                txtPaYv2 = Convert.ToString(txtPassingYear2.Text);
                txtPe2 = Convert.ToString(txtPercent2.Text);
                txtMaSv2 = Convert.ToString(txtMajorSubject2.Text);

            }
            if (tr3.Visible == true)
            {
                txtDev3 = Convert.ToString(txtDegree3.Text);
                txtInv3 = Convert.ToString(txtInstitution3.Text);
                txtUnv3 = Convert.ToString(txtUniversity3.Text);
                txtPaYv3 = Convert.ToString(txtPassingYear3.Text);
                txtPe3 = Convert.ToString(txtPercent3.Text);
                txtMaSv3 = Convert.ToString(txtMajorSubject3.Text);

            }
            if (tr4.Visible == true)
            {
                txtDev4 = Convert.ToString(txtDegree4.Text);
                txtInv4 = Convert.ToString(txtInstitution4.Text);
                txtUnv4 = Convert.ToString(txtUniversity4.Text);
                txtPaYv4 = Convert.ToString(txtPassingYear4.Text);
                txtPe4 = Convert.ToString(txtPercent4.Text);
                txtMaSv4 = Convert.ToString(txtMajorSubject4.Text);

            }
            if (tr5.Visible == true)
            {
                txtDev5 = Convert.ToString(txtDegree5.Text);
                txtInv5 = Convert.ToString(txtInstitution5.Text);
                txtUnv5 = Convert.ToString(txtUniversity5.Text);
                txtPaYv5 = Convert.ToString(txtPassingYear5.Text);
                txtMaSv5 = Convert.ToString(txtMajorSubject2.Text);

            }



            string tfname = Convert.ToString(TextBox1.Text);
            string tmname = Convert.ToString(TextBox2.Text);
            string tlname = Convert.ToString(TextBox3.Text);
            string tPSubject = Convert.ToString(TextBox4.Text);
            string tDepartnm = Convert.ToString(TextBox5.Text);
            string gender = Convert.ToString(TextBox6.SelectedItem.Value);
            string tDobnm = null;
            if (!String.IsNullOrEmpty(TextBox7.Text))

                tDobnm = Convert.ToDateTime(TextBox7.Text).ToString("MM/dd/yyyy");

            string Emailvl = Convert.ToString(TextBox8.Text);
            string Qualif = Convert.ToString(TextBox9.Text);
            long? TelePhone1 = null;
            if (TextBox10.Text != null)
            {
                TelePhone1 = Convert.ToInt64(TextBox10.Text);
            }

            long? TelePhone2 = null;
            if (TextBox11.Text != null)
            {
                TelePhone2 = Convert.ToInt64(TextBox11.Text);
            }

            long? Tmobino = null;
            if (TextBox12.Text != null)
            {
                Tmobino = Convert.ToInt64(TextBox12.Text);
            }
            string faceurl = Convert.ToString(TextBox13.Text);
            string Twiurl = Convert.ToString(TextBox14.Text);
            string otheurl = Convert.ToString(TextBox15.Text);
            string filnmn1 = null;


            if (ViewState["Filename1"] != null)
            {
                filnmn1 = ViewState["Filename1"].ToString();
            }
            string Preaddress = Convert.ToString(TextBox16.Text);
            string Paraddress = Convert.ToString(TextBox17.Text);

            string TimeTocon = Convert.ToString(TextBox18.Text);

            //long? Updateby = null;
            //if (Updateby.HasValue)
            //{
            string Updateby = Convert.ToString(Session["User_id"]);
            // Updateby = Convert.ToInt64(Session["User_id"]);
            //}
            string Updatedt = DateTime.Now.ToString("MM/dd/yyyy");

            string Upval = GetSystemIP();

            string instrquery1 = "Execute dbo.usp_Profile @command='UpdateStaff',@vchFirst_name='" + tfname + "',@vchMiddle_name='" + tmname + "',@vchLast_name='" + tlname + "',@vchPreferedSubject='" + tPSubject + "',@intsubject_id='" + tDepartnm + "',@vchGender='" + gender + "',@dtDOB='" + tDobnm + "',@vchEmail='" + Emailvl + "',@vchHighestQualification='" + Qualif + "'," +
                                     "@intTelNo1='" + TelePhone1 + "',@intTelNo2='" + TelePhone2 + "',@intMobileNo='" + Tmobino + "',@vchFacebookURL='" + faceurl + "',@vchTwitterURL='" + Twiurl + "',@vchOtherURL='" + otheurl + "',@vchImageURL='" + filnmn1 + "',@vchAddress='" + Preaddress + "',@vchPermanent='" + Paraddress + "'," +
                                     "@intSchool_id='" + Session["School_id"] + "',@intUpdated_id='" + Updateby + "',@dtUpdated_Date='" + Updatedt + "',@vchUpdated_IP='" + Upval + "'," +
                                     "@vchDegree1='" + txtDev1 + "',@vchInstitution1='" + txtInv1 + "',@vchtxtUniversity1='" + txtUnv1 + "',@intPassingYear1='" + txtPaYv1 + "',@vchPercent1='" + txtPe1 + "'," +
                                     "@vchMajorSubject1='" + txtMaSv1 + "',@vchDegree2='" + txtDev2 + "',@vchInstitution2='" + txtInv2 + "',@vchtxtUniversity2='" + txtUnv2 + "',@intPassingYear2='" + txtPaYv2 + "'," +
                                     "@vchPercent2='" + txtPe2 + "',@vchMajorSubject2='" + txtMaSv2 + "',@vchDegree3='" + txtDev3 + "',@vchInstitution3='" + txtInv3 + "',@vchtxtUniversity3='" + txtUnv3 + "'," +
                                     "@intPassingYear3='" + txtPaYv3 + "',@vchPercent3='" + txtPe3 + "',@vchMajorSubject3='" + txtMaSv3 + "',@vchDegree4='" + txtDev4 + "',@vchInstitution4='" + txtInv4 + "'," +
                                     "@vchtxtUniversity4='" + txtUnv4 + "',@intPassingYear4='" + txtPaYv4 + "',@vchPercent4='" + txtPe4 + "',@vchMajorSubject4='" + txtMaSv4 + "',@vchDegree5='" + txtDev5 + "'," +
                                     "@vchInstitution5='" + txtInv5 + "',@vchtxtUniversity5='" + txtUnv5 + "',@intPassingYear5='" + txtPaYv5 + "',@vchPercent5='" + txtPe5 + "',@vchMajorSubject5='" + txtMaSv5 + "'," +
                                     "@intTeacher_id='" + lab2.Text + "',@dtTimeToContact='" + TimeTocon + "'";
            int str = sExecuteQuery(instrquery1);

            if (str != -1)
            {
                string display = "Teacher Profile Update Successfully!";
                MessageBox(display);
                Clear();
                Response.Redirect("frmAdmListTeacherDetails.aspx");
            }

            else
            {
                MessageBox("ooopppsss!Teacher Profile failed");

            }

        }
        catch
        {
        }

    }
    protected void TextBox5_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDesignation();
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDept();
        FillTeacher();
    }
    public void FillDesignation()
    {
        try
        {
            strQry = "exec usp_FillDropDown @type='FillDesignation',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intDepartment='" + Convert.ToString(ddlDept.SelectedValue) + "'";
            sBindDropDownList(ddlDesignation, strQry, "vchDesignation", "intDesignation_Id");

            //string strQrys = "exec usp_Profile  @command='FillDesignation',@intDepartment='" + Convert.ToString(TextBox5.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            //sBindDropDownList(ddlDesignation, strQrys, "vchDesignation", "intDesignation_Id");
        }
        catch (Exception)
        {
            MessageBox("Problem Found");
        }
    }
    public void FillDept()
    {
        try
        {
            strQry = "exec usp_FillDropDown @type='TrainingStaffDepartment',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intUserType='" + Convert.ToString(ddlType.SelectedValue) + "'";
            sBindDropDownList(ddlDept, strQry, "vchDepartment_name", "intDepartment");
        }
        catch (Exception)
        {
            MessageBox("Problem Found");
        }
    }
    public void FillTeacher()
    {
        try
        {
            strQry = "exec usp_FillDropDown @type='GetStaff',@intDept_id='" + Convert.ToString(ddlDept.SelectedValue) + "',@intUserType='" + Convert.ToString(ddlType.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlTeacher, strQry, "Name", "intStaff_id");

            //if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            //    ddlTeacher.Items.Add(new ListItem("All", "-1"));
        }
        catch
        {
            MessageBox("Problem Found");
        }
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillTeacher();
    }
    protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
    {
       // filldata();
        TabContainer1.Visible = true;
        Detai();
    }
}


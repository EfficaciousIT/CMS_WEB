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


public partial class frmAdmStudentProfile : DBUtility
{
    DataSet dsObj1 = new DataSet();
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
          
                //DateTime dat= DateTime.Now;
                //date1.Text = dat.AddYears(-1).ToString();
            date1.Text = (DateTime.Now).AddYears(-2).ToShortDateString();


            Label lblTitle = new Label();
            lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            lblTitle.Visible = true;
            lblTitle.Text = "Students Profile Entry";

            if (!IsPostBack)
            {

                
                checksession();
                geturl();
           //     DropDownList2.SelectedValue = "0";
                string query2 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
                bool st = sBindDropDownList(DropDownList2, query2, "Standard_name", "intStandard_id");

  

                string st3 = Request.QueryString["successMessage3"];
                if (st3 != null)
                {
                    query();
                }
                else
                {
                    TabContainer1.ActiveTabIndex = 0;
                    Update.Visible = false;

                    TabPanel1.Visible = true;
                    TabPanel1.Enabled = true;
                    TabPanel2.Visible = true;
                    TabPanel2.Enabled = false;
                    TabPanel3.Visible = true;
                    TabPanel3.Enabled = false;
                    TabPanel4.Visible = true;
                    TabPanel4.Enabled = false;
                    TabPanel5.Visible = true;
                    TabPanel5.Enabled = false;
                    TabPanel6.Visible = true;
                    TabPanel6.Enabled = false;
                    TabPanel7.Visible = true;
                    TabPanel7.Enabled = false;
                }
            }
            if (txt7.Text != "")
            {
                ViewState["Dob"] = txt7.Text;
            }
            if (FileUpload1.HasFile)
             
            {
                ViewState["Filename"] = FileUpload1.PostedFile.FileName;
            }
        }
        catch
        {


        }
    }

    protected void query()
    {
        string st3 = Request.QueryString["successMessage3"];
        idv1.Text = st3;
    TabContainer1.ActiveTabIndex = 0;
        string query1 = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + st3 + "',@intSchool_id='" + Session["School_id"] + "'";

        dsObj = sGetDataset(query1);
        if (dsObj.Tables[0].Rows.Count > 0)
        {

            Session["Table"] = dsObj;

            if (((DataSet)Session["Table"] != null))
            {

                foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                {
                   string  standcv1=Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
                    DropDownList2.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);

                    string que2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + standcv1 + "' ";
                    bool st2 = sBindDropDownList(DropDownList3, que2, "vchDivisionName", "intDivision_id");
                    DropDownList3.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                    TextBox1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);
                    txt1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                    txt2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentMiddle_name"]);
                    txt3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentLast_name"]);
                    txt4.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                    txt5.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                    txt6.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmail"]);
                    txt7.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
                    txt8.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchplaceofBirth"]);
                    txt9.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchCast"]);
                    txt10.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubcast"]);
                    txt11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGender"]);
                    txt12.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intHomePhoneNo1"]);
                    txt13.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intFatherMobile"]);
                    txt14.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intMotherMobile"]);
                    txt15.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAddress"]);
                    
                     string src11 = Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);

                            String savePath = "~/images/";

                                imgViewFile.ImageUrl = savePath + src11;
                                txt34.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAddress"]);
                                txt35.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPermanent"]);
                                txt36.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intHomePhoneNo1"]);
                                txt37.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intHomePhoneNo2"]);
                                txt38.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmergencyConPerson1"]);
                                txt39.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intEmergencyContat1"]);
                                txt40.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmergencyConPerson2"]);
                                txt41.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intEmergencyContat2"]);
                                txt42.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchNeighbour_name"]);
                                txt43.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intNeighborConNo"]);
                                txt44.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["chrBloodGrp"]);
                                DropDownList1.SelectedItem.Value=Convert.ToString(dsObj.Tables[0].Rows[0]["vchHandicapedStatus"]);
                                txt45.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDescription"]);
                                txt46.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchCast"]);
                                txt47.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubcast"]);
                                txt48.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPassport"]);
                                txt49.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtpassportissue"]);
                               txt50.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtexpiredate"]);
                               txt51.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMothertongue"]);
                               txt52.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["bus_alert_on1"]);
                               txt53.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["bus_alert_on2"]);
                               txt54.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPanCard"]);
                               txt55.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchaadhar_no"]);
                              
                               
                                TabPanel1.Enabled= true;
                               TabPanel2.Enabled = true;
                               TabPanel3.Enabled = true;
                               TabPanel4.Enabled = true;
                               TabPanel5.Enabled = true;
                               ButN7.Visible = false;
                               ButN2.Visible = false;
                               ButP2.Visible = false;
                               ButP3.Visible = false;
                               ButN3.Visible = false;
                               ButP4.Visible = false;
                               ButN4.Visible = false;
                               ButP5.Visible = false;
                               ButN5.Visible = false;
                               ButP6.Visible = false;
                               ButN6.Visible = false;
                               Update.Visible = true;
                }
            }
        }
    }
    protected void GetData()
    {

       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            String savePath = "~/images/";

            if (FileUpload1.HasFile)
            {

                FileUpload1.SaveAs(Server.MapPath("images/") + FileUpload1.FileName);
                string file = FileUpload1.PostedFile.FileName;

                imgViewFile.ImageUrl = savePath + file;
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
            ButN6.Enabled = false;

            string StandId = DropDownList2.SelectedItem.Value;
            string DiviId = DropDownList3.SelectedItem.Value;
            string rollno = Convert.ToString(TextBox1.Text);
            string Fname = Convert.ToString(txt1.Text);
            string Mname = Convert.ToString(txt2.Text);
            string lname = Convert.ToString(txt3.Text);
            string Fathername = Convert.ToString(txt4.Text);
            string Mothername = Convert.ToString(txt5.Text);
            string Emailid = Convert.ToString(txt6.Text);
            string Dobnm = null;
            if (!String.IsNullOrEmpty(txt7.Text))

                Dobnm = Convert.ToDateTime(txt7.Text).ToString("MM/dd/yyyy");

            string Placebt = Convert.ToString(txt8.Text);
            string cast = Convert.ToString(txt9.Text);
            string subcast = Convert.ToString(txt10.Text);
            string gender = Convert.ToString(txt11.SelectedItem.Value);
            string filnmn = null;
           // string filnmn = ViewState["Filename"].ToString();
            if (ViewState["Filename"] != null)
            {
                filnmn = ViewState["Filename"].ToString();
            }

            if (txt12.Text != "")
            {
                long Telno = Convert.ToInt64(txt12.Text);
            }
            if (txt13.Text != "")
            {
                long mothno = Convert.ToInt64(txt13.Text);
            }
            if (txt14.Text != "")
            {
                long fathno = Convert.ToInt64(txt14.Text);
            }

            string addressv = Convert.ToString(txt15.Text);
            string Preadd = Convert.ToString(txt34.Text);
            string paradd = Convert.ToString(txt35.Text);
            string homete1 = Convert.ToString(txt36.Text);
            string homete2 = Convert.ToString(txt37.Text);
            string cont1 = Convert.ToString(txt38.Text);
            string conno1 = Convert.ToString(txt39.Text);
            string con2 = Convert.ToString(txt40.Text);
            string conno2 = Convert.ToString(txt41.Text);
            string Neighnm = Convert.ToString(txt42.Text);
            string neino = Convert.ToString(txt43.Text);
            string Bloodgp = Convert.ToString(txt44.Text);
            string healthdis = Convert.ToString(DropDownList1.SelectedItem.Value);
            string Descip = Convert.ToString(txt45.Text);
            string castvl = Convert.ToString(txt46.Text);
            string subcastvl = Convert.ToString(txt47.Text);
            string passportno = Convert.ToString(txt48.Text);
            string Dateofissue = null;
            if (!String.IsNullOrEmpty(txt49.Text))
                Dateofissue = Convert.ToDateTime(txt49.Text).ToString("MM/dd/yyyy");

            string DateofExpire = null;
            if (!String.IsNullOrEmpty(txt50.Text))

                DateofExpire = Convert.ToDateTime(txt50.Text).ToString("MM/dd/yyyy");
            string mothertounge = Convert.ToString(txt51.Text);
            string alert1 = Convert.ToString(txt52.Text);
            string alert2 = Convert.ToString(txt53.Text);
            string Panno1 = Convert.ToString(txt52.Text);
            string aadhar2 = Convert.ToString(txt53.Text);
            
              
            long insertby = Convert.ToInt64(Session["User_id"]);

            string insertdt = DateTime.Now.ToString("MM/dd/yyyy");

            string ipval = GetSystemIP();

            string instrquery1 = "Execute dbo.usp_Profile @command='InsertStudentProfile',@intstanderd_id='" + StandId + "',@intDivision_id='" + DiviId + "',@intRollNo='" + rollno + "',@vchStudentFirst_name='" + Fname + "',@vchStudentMiddle_name='" + Mname + "'," +
                                  "@vchStudentLast_name='" + lname + "',@vchFatherName='" + Fathername + "',@vchMotherName='" + Mothername + "',@vchGender='" + gender + "',@dtDOB='" + Dobnm + "',@vchplaceofBirth='" + Placebt + "',@dtActivationDate='" + insertdt + "',@vchActivestatus=1,@intActivationBy='" + Session["User_id"] + "'," +
                                   "@vchCast='" + cast + "',@vchsubcast='" + subcast + "',@vchEmail='" + Emailid + "',@vchMothertongue='" + mothertounge + "',@vchpresentAddress='" + Preadd + "',@vchpermanentAddress='" + paradd + "',@vchImageURL='" + filnmn + "',@intHomePhoneNo1='" + homete1 + "',@intHomePhoneNo2='" + homete2 + "',@vchEmergencyConPerson1='" + cont1 + "',@intEmergencyContat1='" + conno1 + "',@vchEmergencyConPerson2='" + con2 + "'," +
                                    "@intEmergencyContat2='" + conno2 + "',@vchNeighbour_name='" + Neighnm + "',@intNeighborConNo='" + neino + "',@chrBloodGrp='" + Bloodgp + "',@vchPassport='" + passportno + "',@dtpassportissue='" + Dateofissue + "',@dtexpiredate='" + DateofExpire + "',@vchHandicapedStatus='" + healthdis + "',@vchDescription='" + Descip + "',@vchaadhar_no='" + aadhar2 + "',@vchPanCard='" + Panno1 + "',@intBusAlert1='" + alert1 + "',@intBusAlert2='" + alert2 + "'";


            int str = sExecuteQuery(instrquery1);

            if (str != -1)
            {
                string display = "Student Profile Submit!";
                MessageBox(display);
                ButN6.Visible = false;
                Clear();


            }
            else
            {
                MessageBox("ooopppsss!Student Profile submission Failed");

            }
            TabPanel2.Visible = false;
            TabPanel2.Enabled = false;


            TabPanel1.Visible = true;
            TabPanel1.Enabled = true;

            TabPanel3.Visible = false;
            TabPanel3.Enabled = false;

            TabPanel4.Visible = false;
            TabPanel4.Enabled = false;

            TabPanel5.Visible = false;
            TabPanel5.Enabled = false;

            TabPanel6.Visible = false;
            TabPanel6.Enabled = false;
        }

        catch (Exception Ex)
        {


        }

    }
    public void Clear()
    {
        TextBox[] textBoxArray = new TextBox[51];
        int i;
        for (i = 0; i < 52; i++)
        {

            textBoxArray[i].Text = "";

        }
    }

    protected void checknextval1(object sender, EventArgs e)
    {

        TabPanel1.Visible = true;
        TabPanel1.Enabled = false;
        TabPanel2.Visible = true;
        TabPanel2.Enabled = true;

    }


    protected void checknevl3(object sender, EventArgs e)
    {
        try
        {
            TabPanel1.Visible = true;
            TabPanel1.Enabled = false;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = false;
            TabPanel4.Visible = true;
            TabPanel4.Enabled = true;
            TabPanel3.Visible = true;
            TabPanel3.Enabled = false;
            TabPanel5.Visible = true;
            TabPanel5.Enabled = false;
        }
        catch 
        { }


    }

    protected void checknextval4(object sender, EventArgs e)
    {
        try
        {
            TabPanel1.Visible = true;
            TabPanel1.Enabled = false;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = false;

            TabPanel3.Visible = true;
            TabPanel3.Enabled = false;

            TabPanel4.Visible = true;
            TabPanel4.Enabled = false;
            TabPanel6.Visible = true;
            TabPanel6.Enabled = true;
            TabPanel5.Visible = true;
            TabPanel5.Enabled = false;
        }
        catch { }
    }



    protected void DroplistAtten_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //TextBox5.Text = TextBox5.SelectedItem.Text;
        }
        catch
        {

        }
    }
    protected void shwval_Click(object sender, EventArgs e)
    {

    }
    protected void checknextval5(object sender, EventArgs e)
    {
        try
        {
            TabPanel1.Visible = true;
            TabPanel1.Enabled = false;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = false;

            TabPanel3.Visible = true;
            TabPanel3.Enabled = false;

            TabPanel4.Visible = true;
            TabPanel4.Enabled = false;
            
            TabPanel6.Visible = true;
            TabPanel6.Enabled = false;
            TabPanel7.Visible = true;
            TabPanel7.Enabled = false;
            TabPanel5.Visible = true;
            TabPanel5.Enabled = true;
        }
        catch
        { }
    }
    protected void checknextval2(object sender, EventArgs e)
    {
        try
        {
            TabPanel1.Visible = true;
            TabPanel1.Enabled = false;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = false;
            TabPanel3.Visible = true;
            TabPanel3.Enabled = true;
        }
        catch
        { }

    }
    protected void checkPrivious6(object sender, EventArgs e)
    {
        try
        {
            TabPanel1.Visible = true;
            TabPanel1.Enabled = false;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = false;
            TabPanel3.Visible = true;
            TabPanel3.Enabled = false;
            TabPanel4.Visible = true;
            TabPanel4.Enabled = false;
            TabPanel5.Visible = false;
            TabPanel5.Enabled = false;
            TabPanel6.Visible = true;
            TabPanel6.Enabled = false;
            TabPanel7.Visible = true;
            TabPanel7.Enabled = true;
        }
        catch 
        {
        
        }
    }
    protected void checkPrivious5(object sender, EventArgs e)
    {
        try
        {
            TabPanel1.Visible = true;
            TabPanel1.Enabled = false;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = false;
            TabPanel3.Visible = true;
            TabPanel3.Enabled = false;
            TabPanel4.Visible = true;
            TabPanel4.Enabled = false;
            TabPanel5.Visible = false;
            TabPanel5.Enabled = false;
            TabPanel6.Visible = true;
            TabPanel6.Enabled = true;
            TabPanel7.Visible = false;
            TabPanel7.Enabled = false;
        }
        catch
        { 
        
        
        }


    }
    protected void checkPrivious4(object sender, EventArgs e)
    {
        try
        {
            TabPanel1.Visible = true;
            TabPanel1.Enabled = false;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = false;
            TabPanel3.Visible = true;
            TabPanel3.Enabled = true;
            TabPanel4.Visible = false;
            TabPanel4.Enabled = false;
        }
        catch
        { }
    }
    protected void checkPrivious3(object sender, EventArgs e)
    {

        try
        {
            TabPanel1.Visible = true;
            TabPanel1.Enabled = false;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = true;
            TabPanel3.Visible = false;
            TabPanel3.Enabled = false;
        }
        catch

        { }
        }
    protected void checkPrivious2(object sender, EventArgs e)
    {

        try
        {
            TabPanel1.Visible = true;
            TabPanel1.Enabled = true;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = false;
            TabPanel3.Visible = true;
            TabPanel3.Enabled = false;
            TabPanel4.Visible = true;
            TabPanel4.Enabled = false;
            TabPanel5.Visible = true;
            TabPanel5.Enabled = false;
            TabPanel6.Visible = true;
            TabPanel6.Enabled = false;
        }
        catch
        {
        
        
        }

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int stat = Convert.ToInt32(DropDownList2.SelectedItem.Value);

            string query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "' ";
            bool st2 = sBindDropDownList(DropDownList3, query2, "vchDivisionName", "intDivision_id");

        }
        catch
        {

        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int statv1 = Convert.ToInt32(DropDownList2.SelectedItem.Value);

            int Div1 = Convert.ToInt32(DropDownList3.SelectedItem.Value);



        }
        catch
        {

        }
    }

    protected void checknextval7(object sender, EventArgs e)
    {
        try
        {
            TabPanel1.Enabled = false;
            TabPanel1.Visible = true;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = true;

            TabPanel3.Visible = true;
            TabPanel3.Enabled = false;

            TabPanel4.Visible = true;
            TabPanel4.Enabled = false;
            TabPanel5.Visible = true;
            TabPanel5.Enabled = false;
        }
        catch
        {
        }
    }
    protected void checkroll(object sender, EventArgs e)
    {

        try
        {
            int stat = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            int Divi = Convert.ToInt32(DropDownList3.SelectedItem.Value);

            string query3 = "Execute dbo.usp_Profile @command='checkExiRollNo',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "',@intDivision_id='" + Divi + "',@introllno='" + TextBox1.Text + "'  ";
            string qucount = sExecuteScalar(query3);
            if (qucount == "1")
            {
                Label4.Text = "Student Record Already Exist";
                TextBox1.Text = string.Empty;
            }
            else
            {
                Label4.Text = "";
            }
        }
        catch
        {
        
        
        }
    }
   
    protected void txt8_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txt46_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Update1(object sender, EventArgs e)
    {
        try
        {


            string StandId = DropDownList2.SelectedItem.Value;
            string DiviId = DropDownList3.SelectedItem.Value;
            string rollno = Convert.ToString(TextBox1.Text);
            string Fname = Convert.ToString(txt1.Text);
            string Mname = Convert.ToString(txt2.Text);
            string lname = Convert.ToString(txt3.Text);
            string Fathername = Convert.ToString(txt4.Text);
            string Mothername = Convert.ToString(txt5.Text);
            string Emailid = Convert.ToString(txt6.Text);
            string Dobnm = null;
            if (!String.IsNullOrEmpty(txt7.Text))

                Dobnm = Convert.ToDateTime(txt7.Text).ToString("MM/dd/yyyy");

            string Placebt = Convert.ToString(txt8.Text);
            string cast = Convert.ToString(txt9.Text);
            string subcast = Convert.ToString(txt10.Text);
            string gender = Convert.ToString(txt11.SelectedItem.Value);
            string filnmn = null;
            if (ViewState["Filename"] != null)
            {
                 filnmn = ViewState["Filename"].ToString();
            }
                if (txt12.Text != "")
            {
                long Telno = Convert.ToInt64(txt12.Text);
            }
            if (txt13.Text != "")
            {
                long mothno = Convert.ToInt64(txt13.Text);
            }
            if (txt14.Text != "")
            {
                long fathno = Convert.ToInt64(txt14.Text);
            }


            string addressv = Convert.ToString(txt15.Text);
            string Preadd = Convert.ToString(txt34.Text);
            string paradd = Convert.ToString(txt35.Text);
            string homete1 = Convert.ToString(txt36.Text);
            string homete2 = Convert.ToString(txt37.Text);
            string cont1 = Convert.ToString(txt38.Text);
            string conno1 = Convert.ToString(txt39.Text);
            string con2 = Convert.ToString(txt40.Text);
            string conno2 = Convert.ToString(txt41.Text);
            string Neighnm = Convert.ToString(txt42.Text);
            long neino = Convert.ToInt64(txt43.Text);
            string Bloodgp = Convert.ToString(txt44.Text);
            string healthdis = Convert.ToString(DropDownList1.SelectedItem.Value);
            string Descip = Convert.ToString(txt45.Text);
            string castvl = Convert.ToString(txt46.Text);
            string subcastvl = Convert.ToString(txt47.Text);
            string passportno = Convert.ToString(txt48.Text);
            string Dateofissue = null;
            if (!String.IsNullOrEmpty(txt49.Text))
                Dateofissue = Convert.ToDateTime(txt49.Text).ToString("MM/dd/yyyy");

            string DateofExpire = null;
            if (!String.IsNullOrEmpty(txt50.Text))

                DateofExpire = Convert.ToDateTime(txt50.Text).ToString("MM/dd/yyyy");
            string mothertounge = Convert.ToString(txt51.Text);
            long intUpdate_id = Convert.ToInt64(Session["User_id"]);
            string vchUpdated_IP = GetSystemIP();
            string insertdt = DateTime.Now.ToString("MM/dd/yyyy");

            string instrquery1 = "Execute dbo.usp_Profile @command='UpdateStudentProfile',@intstanderd_id='" + StandId + "',@intDivision_id='" + DiviId + "',@intRollNo='" + rollno + "',@vchStudentFirst_name='" + Fname + "',@vchStudentMiddle_name='" + Mname + "'," +
                                  "@vchStudentLast_name='" + lname + "',@vchFatherName='" + Fathername + "',@vchMotherName='" + Mothername + "',@vchGender='" + gender + "',@dtDOB='" + Dobnm + "',@vchplaceofBirth='" + Placebt + "',@dtActivationDate='" + insertdt + "',@vchUser_name='" + Fname + "',@vchPassword='" + Fname + "',@vchActivestatus=1,@intActivationBy='" + Session["User_id"] + "'," +
                                   "@vchCast='" + cast + "',@vchsubcast='" + subcast + "',@vchEmail='" + Emailid + "',@vchMothertongue='" + mothertounge + "',@vchpresentAddress='" + Preadd + "',@vchpermanentAddress='" + paradd + "',@vchImageURL='" + filnmn + "',@intHomePhoneNo1='" + homete1 + "',@intHomePhoneNo2='" + homete2 + "',@vchEmergencyConPerson1='" + cont1 + "',@intEmergencyContat1='" + conno1 + "',@vchEmergencyConPerson2='" + con2 + "'," +
                                    "@intEmergencyContat2='" + conno2 + "',@vchNeighbour_name='" + Neighnm + "',@intNeighborConNo='" + neino + "',@chrBloodGrp='" + Bloodgp + "',@vchPassport='" + passportno + "',@dtpassportissue='" + Dateofissue + "',@dtexpiredate='" + DateofExpire + "',@vchHandicapedStatus='" + healthdis + "',@vchDescription='" + Descip + "',@intUpdate_id='" + intUpdate_id + "',@vchUpdated_IP='" + vchUpdated_IP + "',@intschool_id='" + Session["school_id"] + "',@intstudent_id='" + idv1.Text + "'";



            int str = sExecuteQuery(instrquery1);

            if (str != -1)
            {
                string display = "Student Profile Updated!";
                MessageBox(display);
                // Button1.Enabled = false;
                Clear();


            }
            else
            {
                MessageBox("ooopppsss!Student Profile updation Failed");

            }
        }
        catch
        { 
        
        
        }
    }
    protected void checknextval8(object sender, EventArgs e)
    {
        try
        {
            TabPanel1.Enabled = false;
            TabPanel1.Visible = true;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = false;

            TabPanel3.Visible = true;
            TabPanel3.Enabled = false;

            TabPanel4.Visible = true;
            TabPanel4.Enabled = false;
            TabPanel5.Visible = true;
            TabPanel5.Enabled = false;
            TabPanel6.Visible = true;
            TabPanel6.Enabled = false;
            TabPanel7.Visible = true;
            TabPanel7.Enabled = true;
        }
        catch
        {
        }
    }
    protected void checkPrivious8(object sender, EventArgs e)
    {
        try
        {
            TabPanel1.Visible = true;
            TabPanel1.Enabled = false;
            TabPanel2.Visible = true;
            TabPanel2.Enabled = false;
            TabPanel3.Visible = true;
            TabPanel3.Enabled = false;
            TabPanel4.Visible = true;
            TabPanel4.Enabled = true;

            TabPanel6.Visible = false;
            TabPanel6.Enabled = false;
            TabPanel5.Visible = false;
            TabPanel5.Enabled = false;
            TabPanel7.Visible = false;
            TabPanel7.Enabled = false;
        }
        catch
        {


        }
    }
}

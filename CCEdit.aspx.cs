using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

public partial class CCEdit : DBUtility
{
    ReportDocument crystalReport = new ReportDocument();
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    string strQry = "";
    DataSet dsObj;
    DataSet dsObjgrade;
    string exam = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserType_id"] != null && Session["User_id"] != null || Session["Student_id"] != null)
        {
            if (!IsPostBack)
            {
                if (Session["rptStudentdetail"] != null)
                {
                    dsObj = (DataSet)Session["rptStudentdetail"];

                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        btnUpdate.Visible = true;                      
                                try
                                {
                                    txtnameofpupil.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudent_name"]);
                                    txtnameofpupil.Text = Convert.ToString(txtnameofpupil.Text).ToUpper();
                                }
                                catch
                                { 
                                }
                                try
                                {
                                    txtfathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                                    txtfathername.Text = Convert.ToString(txtfathername.Text).ToUpper();
                                }
                                catch
                                { 
                                }
                                try
                                {
                                txtmothername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMontherName"]);
                                txtmothername.Text = Convert.ToString(txtmothername.Text).ToUpper();
                                     }
                                catch
                                { 
                                }
                                try
                                {
                                txtclass.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchclass"]);
                                txtclass.Text = Convert.ToString(txtclass.Text).ToUpper();
                                     }
                                catch
                                { 
                                }
                                try
                                {
                                txtSec.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchSec"]);
                                txtSec.Text = Convert.ToString(txtSec.Text).ToUpper();
                                     }
                                catch
                                { 
                                }
                                try
                                {
                               //vchStream.Text = Convert.ToString(ddlstream.Text);
                                    txtRollno.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollno"]);
                                //vchStudent_name.Text = Convert.ToString(vchStudent_name.Text).ToUpper();
                                     }
                                catch
                                { 
                                }
                                try
                                {
                                    txtyear.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchYear"]);
                                //vchStudent_name.Text = Convert.ToString(vchStudent_name.Text).ToUpper();
                                     }
                                catch
                                { 
                                }
                                try
                                {
                                    FillSTD();
                                    ddlappclass.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intappstandaredId"]);
                
                                     }
                                catch
                                { 
                                }
                                try
                                {
                                //string vchappSec = Convert.ToString(txtmothername.Text);
                               //vchappStream.Text = Convert.ToString(ddlappstream.Text);
                                    txtAISSCERollno.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intAISSCERollno"]);
                                     }
                                catch
                                { 
                                }
                                try
                                {
                                    txtappyear.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchappYear"]);
                                     }
                                catch
                                { 
                                }
                                try
                                {
                                    txtDOB.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtDOB"]).ToString("dd/MM/yyyy"); //Convert.ToString(txtDOBword.Text);
                                     }
                                catch
                                { 
                                }
                        

                    }

                }
                else
                {
                    btnSubmit.Visible = true;
                    //FillSTD();
                    //GetAutoSRNO();
                    //txtsrno.Text = Convert.ToString(ViewState["sesSRNo"]);
                }
            }
        }

    }

    public void FillSTD()
    {
        try
        {
            try
            {
                strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlappclass, strQry, "vchStandard_name", "intstandard_id");
                //sBindDropDownList(drpSTD, strQry, "vchStandard_name", "intstandard_id");
                // FillDIV();
                //FillExaminationType();
            }
            catch (Exception)
            {

                throw;
            }

        }
        catch
        {

        }
    }

    protected void show_Click(object sender, EventArgs e)
    {
    }

    protected void view_Click(object sender, EventArgs e)
    {
        if (Session["rptStudentdetail"] != null)
        {
            dsObj = (DataSet)Session["rptStudentdetail"];

            Session["rptStudentdetail"] = dsObj;

            if (dsObj.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("rptcharcertificate.aspx", true);
            }
        }
    }
      protected void Update_Click(object sender, EventArgs e)
    {
        try
        {

            string vchStudent_name = Convert.ToString(txtnameofpupil.Text);
            string vchFatherName = Convert.ToString(txtfathername.Text);
            string vchMotherName = Convert.ToString(txtmothername.Text);
            string vchclass = Convert.ToString(txtclass.Text);
            string vchSec = Convert.ToString(txtSec.Text);
            string vchStream = Convert.ToString(ddlstream.Text);
            string intRollno = Convert.ToString(txtRollno.Text);
            string vchYear = Convert.ToString(txtyear.Text);
            string vchappclass = Convert.ToString(ddlappclass.SelectedItem);
            string intappstandaredId = Convert.ToString(ddlappclass.SelectedValue);
            //string vchappSec = Convert.ToString(txtmothername.Text);
            string vchappStream = Convert.ToString(ddlappstream.Text);
            string intAISSCERollno = Convert.ToString(txtAISSCERollno.Text);
            string vchappYear = Convert.ToString(txtappyear.Text);
            string dtDOB = Convert.ToDateTime(txtDOB.Text).ToString("dd/MMMM/yyyy"); //Convert.ToString(txtDOBword.Text);
            //string vchDOBword = Convert.ToString(txtcharacter.Text);
            string vchPreparedby = Convert.ToString(txtpreparedby.Text);

            string intstudent_id = Convert.ToString(Session["intStudent_id"]);



            string instrquery1 = "Execute dbo.usp_CharCertificate @command='Updatecharcertificate',@intStudent_id='" + intstudent_id + "',@vchStudent_name='" + vchStudent_name + "',@vchFatherName='" + vchFatherName + "',@dtDOB='" + dtDOB + "'," +
                                  "@vchMotherName='" + vchMotherName + "',@vchclass='" + vchclass + "',@vchSec='" + vchSec + "',@vchStream='" + vchStream + "',@intRollno='" + intRollno + "',@vchYear='" + vchYear + "',@vchappclass='" + vchappclass + "'," +
                                  "@vchappStream='" + vchappStream + "',@intAISSCERollno='" + intAISSCERollno + "',@vchappYear='" + vchappYear + "',@vchPreparedby='" + vchPreparedby + "'," +
                                  "@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intappstandaredId='" + intappstandaredId + "'";



            int str = sExecuteQuery(instrquery1);

            if (str != -1)
            {

                //Code By Nikhil
                strQry = "exec usp_CharCertificate @command='Selectstudent',@intstudent_id='" + intstudent_id + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                Session["rptUPStudentdetail"] = dsObj;

                string display = "Updated Successfuly!";
                MessageBox(display);
                btnSubmit.Text = "Update";
                //ButN6.Visible = false;
                // Clear();
                //fGrid();

               // Response.Redirect("rptcharcertificate.aspx", true);

            }
            else
            {
                MessageBox("ooopppsss!TC certificate updation Failed");

            }


        }
        catch
        {
            MessageBox("ooopppsss!TC certificate updation Failed");
        }
    }

      protected void Submit_Click(object sender, EventArgs e)
      {
      }
}
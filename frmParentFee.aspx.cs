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

public partial class frmParentFee : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    int TutionFee = 0, LibraryFee = 0, Computer = 0, ClubActivity = 0, ActivityFee = 0, AdmissionFee = 0, RegistrationFee = 0, SecurityFee = 0;
    int AnnualFee = 0, DevelopmentFee = 0, IDCardFee = 0, MagazineFee = 0;
    int intTotal = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTile = new Label();
        lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        lblTile.Visible = true;
        lblTile.Text = "Fee Details";
        if(!IsPostBack)
        {            
            fillGrid();
        }        
    }
    protected void fillGrid()
    {
        strQry = "usp_parentFeeDet @command='Select',@intstudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
        //strQry = "usp_RPTEnquiry @command='Fee',@intStandard_id='" + Convert.ToString(Session[""]) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdReceived.DataSource = dsObj;
            grdReceived.DataBind();

            HiddenField1.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["Name"]);
            HiddenField2.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["Father"]);
            HiddenField4.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["receiptNo"]);
            

            ViewState["TutionFee"] = Convert.ToString(dsObj.Tables[0].Rows[0]["TutionFee"]);
            ViewState["LibraryFee"] = Convert.ToString(dsObj.Tables[0].Rows[0]["LibraryFee"]);
            ViewState["Computer"] = Convert.ToString(dsObj.Tables[0].Rows[0]["Computer"]);
            ViewState["ClubActivity"] = Convert.ToString(dsObj.Tables[0].Rows[0]["ClubActivity"]);
            ViewState["ActivityFee"] = Convert.ToString(dsObj.Tables[0].Rows[0]["ActivityFee"]);
            ViewState["AdmissionFee"] = Convert.ToString(dsObj.Tables[0].Rows[0]["AdmissionFee"]);
            ViewState["RegistrationFee"] = Convert.ToString(dsObj.Tables[0].Rows[0]["RegistrationFee"]);
            ViewState["SecurityFee"] = Convert.ToString(dsObj.Tables[0].Rows[0]["SecurityFee"]);
            ViewState["AnnualFee"] = Convert.ToString(dsObj.Tables[0].Rows[0]["AnnualFee"]);
            ViewState["DevelopmentFee"] = Convert.ToString(dsObj.Tables[0].Rows[0]["DevelopmentFee"]);
            ViewState["IDCardFee"] = Convert.ToString(dsObj.Tables[0].Rows[0]["IDCardFee"]);
            ViewState["MagazineFee"] = Convert.ToString(dsObj.Tables[0].Rows[0]["MagazineFee"]);
            ViewState["AmountRecive"] = Convert.ToString(dsObj.Tables[0].Rows[0]["AmountRecive"]);

            HiddenField5.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["AmountRecive"]);
            
        }
        else
        {
            grdReceived.DataSource = dsObj;
            grdReceived.DataBind();
        }
    }
    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Sr. No.", typeof(string));
        dt.Columns.Add("Particulars", typeof(string));        
        dt.Columns.Add("Amount", typeof(string));
    }
    protected void grdReceived_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Sr. No.", typeof(string));
        dt.Columns.Add("Particulars", typeof(string));
        dt.Columns.Add("Amount", typeof(string));

        dt.Rows.Add("1", "Tution", ViewState["TutionFee"]);
        dt.Rows.Add("2", "Library", ViewState["LibraryFee"]);
        dt.Rows.Add("3", "Computer", ViewState["Computer"]);
        dt.Rows.Add("4", "Club Activity", ViewState["ClubActivity"]);
        dt.Rows.Add("5", "Registration Fee", ViewState["RegistrationFee"]);
        dt.Rows.Add("6", "Admission Fee", ViewState["AdmissionFee"]);
        dt.Rows.Add("7", "Security Fee", ViewState["SecurityFee"]);

        dt.Rows.Add("8,", "Annual Fee", ViewState["AnnualFee"]);
        dt.Rows.Add("9", "Development Fee", ViewState["DevelopmentFee"]);
        dt.Rows.Add("10", "ID Card Fee", ViewState["IDCardFee"]);
        dt.Rows.Add("11", "Magazine Fee", ViewState["MagazineFee"]);

        grdFee.Visible = true;
        grdFee.DataSource = dt;
        grdFee.DataBind();

        ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "print()", true);

        grdFee.Visible = true;
    }
}

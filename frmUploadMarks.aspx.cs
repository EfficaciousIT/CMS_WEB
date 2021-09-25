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

public partial class frmUploadMarks : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lblTile = new Label();
        //lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        //lblTile.Visible = true;
        //lblTile.Text = "Upoload Marks";
        if (!IsPostBack)
        {
            FillStandard();
            btnSubmit1.Visible = false;
        }        
    }
    protected void FillStandard()
    {
        strQry = "usp_TestSchedule @command='selectStandard',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(drpStandard, strQry, "vchStandard_name", "intStandard_id");
        btnSubmit1.Visible = true;
    }

    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "spMarksUpload @command='student',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvMarks.DataSource = dsObj;
            grvMarks.DataBind();
            btnSubmit1.Visible = true;
        }
        else
        {
            grvMarks.DataSource = dsObj;
            grvMarks.DataBind();
            btnSubmit1.Visible = false;
        }
        
    }
    protected void grvMarks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 1; i < grvMarks.Columns.Count + 1; i++)
                {
                    //TextBox txtmark = (TextBox)grvMarks.Rows[e.Row.RowIndex - 1].FindControl("txtMarks" + i.ToString());
                    //txtmark.MaxLength = Convert.ToInt32(SubMaxMarks.Value.Length);
                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //  e.Row.Style.Add("height", "100px");
            }
        }
        catch(Exception ex)
        {

        }
    }
    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
        int k = 0;

        for (int i = 0; i < grvMarks.Rows.Count; i++)
        {          

            Label Label = (Label)grvMarks.Rows[i].Cells[0].FindControl("intTest_id");
            TextBox txtMarks1 = (TextBox)grvMarks.Rows[i].Cells[0].FindControl("txtMarks1");
            TextBox txtMarks2 = (TextBox)grvMarks.Rows[i].Cells[1].FindControl("txtMarks2");
            TextBox txtMarks3 = (TextBox)grvMarks.Rows[i].Cells[2].FindControl("txtMarks3");
            TextBox txtMarks4 = (TextBox)grvMarks.Rows[i].Cells[3].FindControl("txtMarks4");
            TextBox txtMarks5 = (TextBox)grvMarks.Rows[i].Cells[4].FindControl("txtMarks5");
            DropDownList drpCategory = (DropDownList)grvMarks.Rows[i].Cells[5].FindControl("drpCategory");

            strQry = "spMarksUpload @command='update',@marks1='" + txtMarks1.Text.Trim() + "',@marks2='" + txtMarks2.Text.Trim() + "',@marks3='" + txtMarks3.Text.Trim() + "',@marks4='" + txtMarks4.Text.Trim() + "',@marks5='" + txtMarks5.Text.Trim() + "',@castType='" + drpCategory.Text.Trim() + "',@TotalMarks='" + txtTotalMarks.Text.Trim() + "',@intTest_id='" + Label.Text.Trim() + "'";
            k = sExecuteQuery(strQry);
        }
        if (k > 0)
        {
            //MessageBox("Makrs Uploaded Successfully");

            for (int i = 0; i < grvMarks.Rows.Count; i++)
            {

                Label Label = (Label)grvMarks.Rows[i].Cells[0].FindControl("intTest_id");
                TextBox txtMarks1 = (TextBox)grvMarks.Rows[i].Cells[0].FindControl("txtMarks1");
                TextBox txtMarks2 = (TextBox)grvMarks.Rows[i].Cells[1].FindControl("txtMarks2");
                TextBox txtMarks3 = (TextBox)grvMarks.Rows[i].Cells[2].FindControl("txtMarks3");
                TextBox txtMarks4 = (TextBox)grvMarks.Rows[i].Cells[3].FindControl("txtMarks4");
                TextBox txtMarks5 = (TextBox)grvMarks.Rows[i].Cells[4].FindControl("txtMarks5");
                DropDownList drpCategory = (DropDownList)grvMarks.Rows[i].Cells[5].FindControl("drpCategory");

                txtMarks1.Text = "";
                txtMarks2.Text = "";
                txtMarks3.Text = "";
                txtMarks4.Text = "";
                txtMarks5.Text = "";
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Makrs Uploaded Successfully');window.location ='frmUploadMarks.aspx';", true);
        }

    }
    public void MessageBox(string msg)
    {
        try
        {
            string script = "alert(\"" + msg + "\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

        }
        catch (Exception)
        {
            // return msg;
        }
    }
    protected void btnClear1_Click(object sender, EventArgs e)
    {

    }
}

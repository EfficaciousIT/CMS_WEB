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

public partial class frmMarksEdit : DBUtility
{
    DataSet dsObj = new DataSet();
    string strQry = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillStandard();

        }
    }
    protected void FillStandard()
    {
        strQry = "usp_TestSchedule @command='selectStandard',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(drpStandard, strQry, "vchStandard_name", "intStandard_id");
    }

    protected void grdCandidate_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {   
        grdCandidate.EditIndex = -1;
        FillGrid();
    }
    //protected void grdCandidate_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //   DataRowView drv = e.Row.DataItem as DataRowView;
    //   if (e.Row.RowType == DataControlRowType.DataRow)
    //   {
    //       if ((e.Row.RowState & DataControlRowState.Edit) > 0)
    //       {
    //           //DropDownList dp = (DropDownList)e.Row.FindControl("DropDownList1");
    //           //DataTable dt = load_department();
    //           //for (int i = 0; i < dt.Rows.Count; i++)
    //           //{
    //           //    ListItem lt = new ListItem();
    //           //    lt.Text = dt.Rows[i][0].ToString();
    //           //    dp.Items.Add(lt);
    //           //}
    //           //dp.SelectedValue = drv[3].ToString();
    //           //RadioButtonList rbtnl = (RadioButtonList)e.Row.FindControl("RadioButtonList1");
    //           //rbtnl.SelectedValue = drv[5].ToString();
    //           //CheckBoxList chkb = (CheckBoxList)e.Row.FindControl("CheckBoxList2");
    //           //chkb.SelectedValue = drv[6].ToString();
    //       }
    //   }
    //}
   
    protected void grdCandidate_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdCandidate.EditIndex = e.NewEditIndex;
        FillGrid();
    }
    protected void grdCandidate_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //string id = grdCandidate.DataKeyNames[e.RowIndex].ToString();

        Label lblTest_id = (Label)grdCandidate.Rows[e.RowIndex].FindControl("lblTest_id");

        TextBox name = (TextBox)grdCandidate.Rows[e.RowIndex].FindControl("txtcandiateName");

        TextBox txtmarks1 = (TextBox)grdCandidate.Rows[e.RowIndex].FindControl("txtmarks1");

        TextBox txtmarks2 = (TextBox)grdCandidate.Rows[e.RowIndex].FindControl("txtmarks2");

        TextBox txtmarks3 = (TextBox)grdCandidate.Rows[e.RowIndex].FindControl("txtmarks3");

        TextBox txtmarks4 = (TextBox)grdCandidate.Rows[e.RowIndex].FindControl("txtmarks4");

        TextBox txtmarks5 = (TextBox)grdCandidate.Rows[e.RowIndex].FindControl("txtmarks5");

        strQry = "spMarksUpload @command='update',@marks1='" + txtmarks1.Text.Trim() + "',@marks2='" + txtmarks2.Text.Trim() + "',@marks3='" + txtmarks3.Text.Trim() + "',@marks4='" + txtmarks4.Text.Trim() + "',@marks5='" + txtmarks5.Text.Trim() + "',@intTest_id='" + lblTest_id.Text.Trim() + "'";
        int k = sExecuteQuery(strQry);
        if (k > 0)
        {
            grdCandidate.EditIndex = -1;
            FillGrid();

            MessageBox("Marks updated successfullu");
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
    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }

    protected void FillGrid()
    {        
        strQry = "spMarksUpload @command='student',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdCandidate.DataSource = dsObj;
            grdCandidate.DataBind();

            //GridView1.DataSource = dsObj;
            //GridView1.DataBind();
        }
        else
        {
            grdCandidate.DataSource = dsObj;
            grdCandidate.DataBind();
        }
    }

    //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    GridView1.EditIndex = e.NewEditIndex;
    //    this.FillGrid();
    //}
    //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    //string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
    //}
}

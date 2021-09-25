using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmViewGroupPeople : DBUtility
{
    string strQry="";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                Session["GrpId"] = Request.QueryString["intGroup_id"].ToString();
                createTable();
            }
            else
            {
                Response.Redirect("~\\Default.aspx", false);
            }
            
        }
        catch 
        {
            
        }
    }

    public void createTable()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_GroupMemberMsg_Mst @type='FillGrid',@intGroup_id='" + Session["GrpId"] + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvViewDetail.DataSource = dsObj;
                grvViewDetail.DataBind();
            }
        }
        catch
        {
            
        }
    }
    protected void grvViewDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvViewDetail.PageIndex = e.NewPageIndex;
        createTable();
    }
}
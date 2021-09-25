using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.UI;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;
public partial class frmTopScoresStudent : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["intstudent_id"] = "";
            Session["intStandard_id"] = "";
            FillSTD();
        }
    }
    public void FillSTD()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "3")
            {
                strQry = "exec [usp_getAttendance] @type='FillStd',@TeacherId='" + Convert.ToString(Session["User_id"]) + "',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
                //FillDIV();
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
                //FillDIV();
            }
        }
        catch
        {

        }
    }

    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {      
        strQry = "usp_TopScoresStudent  @command='select',@intStandard_id='" + ddlSTD.SelectedValue + "'";       
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdScores.DataSource = dsObj;
            grdScores.DataBind();
        }
        else
        {
            grdScores.DataSource = dsObj;
            grdScores.DataBind();
        }
    }
    protected void grdScores_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
          
        //    Session.Add("intstudent_id", Convert.ToString(grdScores.DataKeys[e.Row.RowIndex].Values[0]));
         
        //   // Label lblDate = Convert.ToString(grdScores.DataKeys[grdScores.SelectedRow.RowIndex].Value);

        //    LinkButton lnkButton = (LinkButton)e.Row.FindControl("lnkObtained");

        //    //lnkButton.Attributes.Add("onclick", "window.open('Result.aspx?intstudent_id=" + Session["intstudent_id"] + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");
        //    lnkButton.Attributes.Add("onclick", "window.open('ScoreDetails.aspx?intstudent_id=" + Session["intstudent_id"] + "&intStandard_id=" + Convert.ToString(ddlSTD.SelectedValue) + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");
           
        //}
       
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
            Session.Add("intstudent_id", Convert.ToString(grdScores.DataKeys[e.Row.RowIndex].Values[0]));
            Session.Add("intStandard_id", Convert.ToString(ddlSTD.SelectedValue));

            // Label lblDate = Convert.ToString(grdScores.DataKeys[grdScores.SelectedRow.RowIndex].Value);

            LinkButton lnkButton = (LinkButton)e.Row.FindControl("lnkObtained");
            //lnkButton.Attributes.Add("onclick", "window.open('Result.aspx?intstudent_id=" + Session["intstudent_id"] + "&intStandard_id=" + Session["intStandard_id"] + "','self','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");

            //lnkButton.Attributes.Add("onclick", "window.open('Result.aspx?intstudent_id=" + Session["intstudent_id"] + "&intStandard_id=" + Convert.ToString(ddlSTD.SelectedValue) + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");
            lnkButton.Attributes.Add("onclick", "window.open('ScoreDetails.aspx?intstudent_id=" + Session["intstudent_id"] + "&intStandard_id=" + Session["intStandard_id"] + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");
            //lnkButton.Attributes.Add("onclick", "Response.Redirect('Result.aspx?intstudent_id=" + Session["intstudent_id"] + "&intStandard_id=" + Session["intStandard_id"] + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");


        }
    }
   
}
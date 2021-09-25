using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

public partial class frmViewSyllabus : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillExam();
            fillSubject();
        }
    }
    protected void fillExam()
    {
        strQry = "exec usp_Syllabus_Master @type='ExamDet',@intSchool_id='" + Session["School_id"] + "'";
        bool flg = sBindDropDownList(drpExam, strQry, "vchExamination_name", "intExam_id");

    }
    protected void fillSubject()
    {
        strQry = "exec [usp_Syllabus_Master] @type='FillSubjectAll',@intStandard_id='" + Session["Standard_id"] + "'";
        bool flg = sBindDropDownList(drpSubject, strQry, "vchSubjectName", "intSubject_id");
    }

    protected void drpSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "exec [usp_Syllabus_Master] @type='FillGridSyllabus',@intExam_id='" + drpExam.SelectedValue.Trim() + "',@intSubject_id='" + drpSubject.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'  ";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
    }

    protected void grvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "View")
            {
                ImageButton View = (ImageButton)e.CommandSource;
                string id = Convert.ToString(Convert.ToString(e.CommandArgument.ToString()));
                Session["path"] = null;
                Session["path"] = Convert.ToString(id);

                //string path = "~//Documents/Holiday//";
                ////    //  string a =e.Row.c
                ////    View.Attributes.Add("onclick", "window.open('frmViewDoc.aspx?Path=" + path + "&DocName=" + Session["id"].ToString() + ",'_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=800,top=80,left=75');return false");
                ////    View.Attributes.Add("onclick", "window.open('frmTrainingDetail.aspx?TrainingId=12','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=800,top=80,left=75');return false");
                string FilePath = string.Empty;
                if (Convert.ToString(Session["path"]) != "")
                {
                    FilePath = Server.MapPath(Session["Path"].ToString());
                    WebClient User = new WebClient();
                    Byte[] FileBuffer = User.DownloadData(FilePath);
                    FileInfo file = new FileInfo(FilePath);
                    System.Diagnostics.Process.Start(file.ToString());
                    //Response.Redirect("frmviewSyllabusDoc.aspx?Path=" + Convert.ToString(Session["path"]).Replace("~","") + "");
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'frmviewSyllabusDoc.aspx?Path=" + Convert.ToString(Session["path"]).Replace("~", "") + "', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

                    //View.Attributes.Add("onclick", "window.open('frmviewSyllabusDoc.aspx?Path=" + Convert.ToString(Session["path"]).Replace("~", "") + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=800,top=80,left=75');return false");
                }
                else
                {
                    MessageBox("No Document found");
                }
            }
        }
        catch(Exception ex)
        {

        }
    }
}
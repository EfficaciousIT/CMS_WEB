using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Web.Script.Serialization;
using System.IO;
using Microsoft.Office.Interop;
using System.Data.SqlClient;
using AjaxControlToolkit;


public partial class Syllabus : DBUtility
{

    /// <summary>
    /// ///////////////////////////////////////Not use ths page m////////////////////////////////
    /// </summary>
    string strDate = string.Empty;
    DataSet dsObj = new DataSet();
    string strQry = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        string subject = Convert.ToString(Request.QueryString["intStandard_id"]);

        //if (strDate != "")
        //{
        //    strQry = "usp_GenderWiseAttendance  @command='selectName',@fromDate='" + strDate.Trim() + "',@vchGender='" + gender.Trim() + "'";
        //    //strQry = "usp_GenderWiseAttendance  @command='selectName',@fromDate='" + strDate.Trim() + "'";
        //    dsObj = sGetDataset(strQry);
        //    if (dsObj.Tables[0].Rows.Count > 0)
        //    {
        //        grdDet.DataSource = dsObj;
        //        grdDet.DataBind();
        //    }
        //}

        try
        {
            if (Convert.ToString(Session["UserType_id"]) == "5" || Convert.ToString(Session["UserType_id"]) == "6")
            {
                strQry = "exec [usp_Syllabus_Master] @type='FillGrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSubject_id='" + subject + "'";
                dsObj = sGetDataset(strQry);
            }
            else
            {
                strQry = "exec [usp_Syllabus_Master] @type='FillGrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSubject_id='" + subject + "'";
                dsObj = sGetDataset(strQry);
            }

            for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl p1 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                p1.ID = "div" + i.ToString();
                //p1.Style.Add(HtmlTextWriterStyle.Height,"300px");
                p1.Style.Add(HtmlTextWriterStyle.BackgroundImage, "~/images/panelBg.png");
                CollapsDiv.Controls.Add(p1);



                System.Web.UI.HtmlControls.HtmlGenericControl p2 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                p2.ID = "divv" + i.ToString();
                //p2.Style.Add(HtmlTextWriterStyle.Height, "10px");
                //p2.Style.Add(HtmlTextWriterStyle.BackgroundImage, "~/images/expandBd.jpg");
                CollapsDiv.Controls.Add(p2);


                Panel pnl = new Panel();
                pnl.ID = "pnl" + i.ToString();
                pnl.Width = 800;
                //pnl.Height = 40;
                pnl.BackImageUrl = "~/images/panelBg.png";

                Label lbl1 = new Label();
                lbl1.ID = "lbll" + i.ToString();
                lbl1.ForeColor = System.Drawing.Color.White;
                lbl1.Font.Bold = true;
                lbl1.Width = 700;
                lbl1.Text = (i + 1) + ". " + Convert.ToString(dsObj.Tables[0].Rows[i]["vchTopicName"]);

                Image Img = new Image();
                Img.ID = "Image" + i.ToString();


                Table tbl = new Table();
                TableRow tr = new TableRow();
                TableCell td = new TableCell();
                TableCell td2 = new TableCell();

                tbl.Width = 780;
                tbl.Height = 10;
                tbl.CaptionAlign = TableCaptionAlign.Top;
                // tbl.BorderWidth = 1;

                td.ColumnSpan = 2;
                td.VerticalAlign = VerticalAlign.Top;
                td2.VerticalAlign = VerticalAlign.Middle;
                td2.HorizontalAlign = HorizontalAlign.Left;
                td2.Width = 10;

                td2.HorizontalAlign = HorizontalAlign.Right;

                td.Controls.Add(lbl1);
                // td1.Controls.Add();
                td2.Controls.Add(Img);

                tr.Cells.Add(td);
                //tr.Cells.Add(td1);
                tr.Cells.Add(td2);

                tbl.Rows.Add(tr);

                pnl.Controls.Add(tbl);

                p1.Controls.Add(pnl);



                Panel pnl1 = new Panel();
                pnl1.ID = "pnll" + i.ToString();
                pnl1.Width = 800;
                pnl1.BorderStyle = BorderStyle.None;
                //pnl1.BackImageUrl = "~/images/pnl1Bg.jpg";
                pnl1.BackColor = System.Drawing.Color.White;

                GridView grv = new GridView();
                grv.ID = "grv" + i.ToString();
                grv.Width = 650;
                grv.HeaderStyle.HorizontalAlign = HorizontalAlign.Justify;
                grv.RowStyle.HorizontalAlign = HorizontalAlign.Justify;


                strQry = "exec [usp_Syllabus_Master] @type='FillSyllabus',@intTopic_id='" + Convert.ToString(dsObj.Tables[0].Rows[i]["intTopic_id"]) + "'";
                DataSet ds = new DataSet();
                ds = sGetDataset(strQry);
                grv.DataSource = ds;
                grv.DataBind();




                pnl1.Controls.Add(grv);


                p2.Controls.Add(pnl1);


                CollapsiblePanelExtender collapsiblePanelExtender = new CollapsiblePanelExtender();
                collapsiblePanelExtender.ID = "Collaps" + i.ToString();
                collapsiblePanelExtender.TargetControlID = pnl1.ID;//your panel id 
                collapsiblePanelExtender.ExpandControlID = pnl.ID;//your link button id
                collapsiblePanelExtender.CollapseControlID = pnl.ID;
                //your panel id collapsiblePanelExtender.ScrollContents = false;
                collapsiblePanelExtender.Collapsed = true;
                collapsiblePanelExtender.CollapsedSize = 0;
                //  collapsiblePanelExtender.ExpandedSize = 120;
                collapsiblePanelExtender.ExpandedImage = "~/images/Collapse.gif";
                collapsiblePanelExtender.CollapsedImage = "~/images/Expand.gif";
                collapsiblePanelExtender.ExpandDirection = CollapsiblePanelExpandDirection.Vertical;
                collapsiblePanelExtender.SuppressPostBack = true;
                collapsiblePanelExtender.ImageControlID = Img.ID;
                // collapsiblePanelExtender.TextLabelID = lbl.ID; //your label id
                collapsiblePanelExtender.CollapsedText = "Collapsed";
                collapsiblePanelExtender.ExpandedText = "Opended";
                //the name of panel that containt CollapsiblePanelExtender
                this.CollapsDiv.Controls.Add(collapsiblePanelExtender);
                // this.Page.Controls.Add(collapsiblePanelExtender);


                //TextBox txt = new TextBox();
                //txt.ID = "t";
                //CollapsDiv.Controls.Add(txt);
            }
        }
        catch
        {

        }
    }
   
}
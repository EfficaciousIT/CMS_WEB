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

public partial class frmAdmListParentsDetails : DBUtility
{
    DataSet dsObj = new DataSet();

    bool st, st2, st3, stp3 = true;
    int Leavegrid, id, intforumid, intfor3, stat, stat1, Div1, dsgrid = 0;
    public string query1 = string.Empty;
    public string query2 = string.Empty;
    public string query3 = string.Empty;
    public string strQry11 = string.Empty;
    public string stvc1 = string.Empty;
    public string stvD1 = string.Empty;
    public string qup3 = string.Empty;
    public string Disquery = string.Empty;
    public string val1 = string.Empty;
    public string DeleteIP = string.Empty;

    public string queryParentgrid = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            listparengrid.Visible = false;
            listparengrid1.Visible = false;

            Label lblTitle = new Label();
            lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            lblTitle.Visible = true;
            lblTitle.Text = "Parents Detail";

            if (!IsPostBack)
            {

                checksession();
                geturl();
                DropDownL1.ClearSelection();
                listparengrid.Visible = false;
                query1 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
                st = sBindDropDownList(DropDownL1, query1, "Standard_name", "intStandard_id");
                DropDownL1.SelectedValue = "0";
                query2 = "Execute dbo.usp_Profile @command='RemDiviWiSt',@intSchool_id='" + Session["School_id"] + "' ";
                st2 = sBindDropDownList(DropDownL2, query2, "vchDivisionName", "intDivision_id");
                query3 = "Execute dbo.usp_Profile @command='ReRoNoWisd',@intSchool_id='" + Session["School_id"] + "'";

                st3 = sBindDropDownListAll(Droptypeuser, query3, "Name", "intStudent_id");

                Droptypeuser.SelectedValue = "0";
                if (Convert.ToString(Session["UserType_id"]) == "3")
                {
                    strQry11 = "Execute dbo.usp_Profile @command='RetriveStaDiv',@intTeacher_id='" + Session["User_id"] + "',@intschool_id='" + Session["School_id"] + "' ";
                    dsObj = sGetDataset(strQry11);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {

                        Session["Table"] = dsObj;

                        if (((DataSet)Session["Table"] != null))
                        {

                            foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                            {

                                stvc1 = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
                                stvD1 = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);

                                qup3 = "Execute dbo.usp_Profile @command='ReRoNoWisd1',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stvc1 + "',@intDivision_id='" + stvD1 + "'";
                                stp3 = sBindDropDownListAll(Droptypeuser, qup3, "Name", "intStudent_id");


                                DropDownL1.SelectedValue = stvc1;
                                drophide1.Visible = false;
                                DropDownL2.SelectedValue = stvD1;
                                drophide2.Visible = false;
                              //  Droptypeuser.SelectedValue = "A";
                                listparengrid.Visible = true;
                                listparengrid1.Visible = true;
                                GridViewlistpare.Visible = true;

                                Disquery = "Execute dbo.usp_Profile @command='listparentAll',@intschool_id='" + Session["School_id"] + "',@intstanderd_id='" + stvc1 + "',@intDivision_id='" + stvD1 + "'";
                                Leavegrid = sBindGrid(GridViewlistpare, Disquery);

                                GridViewlistpare.Columns[0].Visible = false;
                                GridViewlistpare.Columns[1].Visible = false;
                            }//for
                        }//if1
                    }//if2

                    Td129.Visible = true;
                    studid.Visible = true;


                }//if3
                else
                {
                    drophide1.Visible = true;
                    drophide2.Visible = true;
                }

            }
        }

        catch
        {

        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {


        try
        {

            val1 = ((DropDownList)sender).SelectedValue;

            if (val1 == "A")
            {

                listparengrid.Visible = true;
                listparengrid1.Visible = true;

                fillgridpare();

                GridViewlistpare.Columns[0].Visible = false;
                GridViewlistpare.Columns[1].Visible = false;
                GridViewlistpare.Columns[2].Visible = true;
                GridViewlistpare.Columns[3].Visible = false;
                GridViewlistpare.Columns[4].Visible = false;
            }
            else
            {

                listparengrid.Visible = false;
                listparengrid1.Visible = false;

            }
        }
        catch
        {


        }
    }
    protected void GridViewlistpare_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            id = Convert.ToInt32(GridViewlistpare.DataKeys[e.RowIndex].Value);
            Session["Deleteid"] = GridViewlistpare.DataKeys[e.RowIndex].Value;
            DeleteIP = GetSystemIP();
            strQry11 = "Execute dbo.usp_Profile @command='DeleteParePro',@intParent_id='" + id + "',@intschool_id='" + Session["School_id"] + "',@DeleteIP='" + DeleteIP + "',@intDelete_id='" + Session["user_id"] + "'";
            if (sExecuteQuery(strQry11) != -1)
            {
                MessageBox("Record Deleted Successfully");
                //filldata();

            }

        }
        catch
        {


        }


    }
    protected void fillgridpare()
    {
        try
        {
            stvc1 = DropDownL1.SelectedItem.Value;
            stvD1 = DropDownL2.SelectedItem.Value;
            queryParentgrid = "Execute dbo.usp_Profile @command='listparentv1' ,@intschool_id='" + Session["School_id"] + "',@intstanderd_id='" + stvc1 + "',@intDivision_id='" + stvD1 + "'";
            dsgrid = sBindGrid(GridViewlistpare, queryParentgrid);
        }
        catch
        {

        }


    }


    protected void GridViewlistpare_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewlistpare.PageIndex = e.NewPageIndex;

        GridViewlistpare.DataBind();
        fillgridpare();
        listparengrid.Visible = true;
        listparengrid1.Visible = true;

        GridViewlistpare.Visible = true;


    }
    protected void GridViewlistpare_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GridViewlistpare_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridViewlistpare_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                intforumid = Convert.ToInt32(GridViewlistpare.DataKeys[e.Row.RowIndex].Value);
                Image img = (Image)e.Row.FindControl("btnDetails");
                img.Attributes.Add("onclick", "window.open('frmAdmPareProDetai1.aspx?successMessage=" + intforumid + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=500,top=150,left=500');return false");

                intfor3 = Convert.ToInt32(GridViewlistpare.DataKeys[e.Row.RowIndex].Value);
                Image img3 = (Image)e.Row.FindControl("ImgEdit");
                img3.Attributes.Add("onclick", "window.open('frmLiAdmParentsProfile.aspx?successMessage3=" + intfor3 + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=500,top=150,left=500');return false");


            }
        }
        catch
        {


        }
    }


    protected void GridViewlistpare_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownL1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            stat = Convert.ToInt32(DropDownL1.SelectedItem.Value);
            Td129.Visible = true;
            query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "' ";
            st2 = sBindDropDownList(DropDownL2, query2, "vchDivisionName", "intDivision_id");
        }
        catch
        {

        }
    }
    protected void DropDownL2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            stat1 = Convert.ToInt32(DropDownL1.SelectedItem.Value);
            Div1 = Convert.ToInt32(DropDownL2.SelectedItem.Value);

            studid.Visible = true;

            qup3 = "Execute dbo.usp_Profile @command='ReRoNoWisd1',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "'";
            stp3 = sBindDropDownListAll(Droptypeuser, qup3, "Name", "intStudent_id");

        }
        catch
        {

        }
    }
    protected void Droptypeuser_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            stat1 = Convert.ToInt32(DropDownL1.SelectedItem.Value);
            Div1 = Convert.ToInt32(DropDownL2.SelectedItem.Value);
            if (stat1 == 0)
            {
                MessageBox("Please Enter standard ");

            }
            else
            {

                if (Div1 == 0)
                {
                    MessageBox("Please Enter Division ");
                }
                else
                {
                    GridViewlistpare.Visible = true;
                    listparengrid.Visible = true;
                    listparengrid1.Visible = true;

                    string st = Droptypeuser.SelectedItem.Value;
                    string Disquery;

                    if (st == "A")
                    {
                        Disquery = "Execute dbo.usp_Profile @command='listparentAll',@intschool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "'";
                        Leavegrid = sBindGrid(GridViewlistpare, Disquery);
                        if (Convert.ToString(Session["UserType_id"]) == "3")
                        {
                            GridViewlistpare.Columns[0].Visible = false;
                            GridViewlistpare.Columns[1].Visible = false;
                        }
                    }
                    else if (st == "0")
                    {
                        listparengrid.Visible = false;
                        GridViewlistpare.Visible = false;
                    }
                    else
                    {
                        Disquery = "Execute dbo.usp_Profile @command='listparent1',@intschool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "',@intStudent_id='" + st + "'";
                        Leavegrid = sBindGrid(GridViewlistpare, Disquery);
                        if (Convert.ToString(Session["UserType_id"]) == "3")
                        {
                            GridViewlistpare.Columns[0].Visible = false;
                            GridViewlistpare.Columns[1].Visible = false;
                        }
                    }
                }

            }
        }

        catch
        {

        }
    }




}
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmMonthlyAttendance.aspx.cs" Inherits="frmMonthlyAttendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1 input, form.winner-inside textarea, select {
            display: block;
            border: 1px solid #3498db;
            width: 50%;
            padding: 5px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-top: 10px;
            margin-bottom: 10px;
        }
        .Leave {
    background: #D800FF;
    width: 8px;
    height: 8px;
    margin-right: 5px;
    margin-top: 6px;
    display: block;
    float: left;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head>
    </head>
    <div class="clearfix">
    </div>
    <div class="content-header">
        <h1>
            Attendance
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Attendance</li>
        </ol>
    </div>
    <section class="content">

          <div class="row">
            <div class="col-md-3">

              <!-- Profile Image -->
              <div class="box box-primary">
                <div class="box-body box-profile">
                  <%--<img class="profile-user-img img-responsive img-circle" src="img/photos/school-boy.jpg" alt="User profile picture">--%>
                  <asp:Image ID="ImgProfile" runat="server" class="profile-user-img img-responsive img-circle" />
                  <h3 class="profile-username text-center"><asp:Label ID="lblFullname" runat="server" Text ="20"></asp:Label></h3>
                  
                  <asp:Panel ID="Panel1" runat="server">
 <p class="text-muted text-center">STD / DIV : <asp:Label ID="lblSTDNm" runat="server" Text="Label"></asp:Label> / <asp:Label ID="lblDIVNm" runat="server" Text="Label"></asp:Label></p>
</asp:Panel>
                  
                                    <ul class="list-group list-group-unbordered">
                    <li class="list-group-item">
                      <b>Present</b> <%--<a class="pull-right">20</a>--%><asp:Label ID="lblPresent" runat="server" Text ="20" CssClass="pull-right"></asp:Label>
                    </li>
                    <li class="list-group-item">
                      <b>Absent</b> <%--<a class="pull-right">2</a>--%><asp:Label ID="lblAbsent" runat="server" Text ="1" CssClass="pull-right"></asp:Label>
                    </li>
                    <li class="list-group-item" style="display:none">
                      <b>Late</b> <%--<a class="pull-right">4</a>--%><asp:Label ID="lbllate" runat="server" Text ="4" CssClass="pull-right"></asp:Label>
                    </li>
                  </ul>

                  
                </div><!-- /.box-body -->
              </div><!-- /.box -->

              <!-- About Me Box -->
              <div class="box box-primary" runat="server" id="topFive">
                <div class="box-header with-border">
                  <h3 class="box-title">Attendance top 5</h3>
                </div><!-- /.box-header -->
                <div class="box-body">
                <div class="top-five">Student Name<span class="pull-right">Present\Total</span></div>
                  <ul class="list-group list-group-unbordered">
                    <li class="list-group-item">
                      <b><asp:Label ID="lblTop1" runat="server" CssClass="pull-left"></asp:Label></b> <a class="pull-right"><asp:Label ID="lblTop11" runat="server" CssClass="pull-right"></asp:Label></a>
                    </li>
                    <li class="list-group-item">
                      <b><asp:Label ID="lblTop2" runat="server" CssClass="pull-left"></asp:Label></b> <a class="pull-right"><asp:Label ID="lblTop12" runat="server" CssClass="pull-right"></asp:Label></a>
                    </li>
                    <li class="list-group-item">
                      <b><asp:Label ID="lblTop3" runat="server" CssClass="pull-left"></asp:Label></b> <a class="pull-right"><asp:Label ID="lblTop13" runat="server" CssClass="pull-right"></asp:Label></a>
                    </li>
                     <li class="list-group-item">
                      <b><asp:Label ID="lblTop4" runat="server" CssClass="pull-left"></asp:Label></b> <a class="pull-right"><asp:Label ID="lblTop14" runat="server" CssClass="pull-right"></asp:Label></a>
                    </li>
                     <li class="list-group-item">
                      <b><asp:Label ID="lblTop5" runat="server" CssClass="pull-left"></asp:Label></b> <a class="pull-right"><asp:Label ID="lblTop15" runat="server" CssClass="pull-right"></asp:Label></a>
                    </li>
                  </ul>
                </div><!-- /.box-body -->
              </div><!-- /.box -->
            </div><!-- /.col -->
            <div class="col-md-9">

            <div class="nav-tabs-custom">
                <ul class="nav nav-tabs">
                  <li class="active"><a href="#Calendar" data-toggle="tab"> Calendar</a></li>
                  <li><a href="#Tabular" data-toggle="tab">Tabular</a></li>
                  <li><a href="#Summary" data-toggle="tab">Summary</a></li>
                </ul>
                <div class="tab-content">
                  <div class="active tab-pane no-padding" id="Calendar">
                  
                  
                  <!-- calendar-->
             <asp:Calendar ID="CalAttendance" runat="server"  Height="500px"  Font-Size="14px" DayNameFormat="Short"
                SelectMonthText="»" SelectWeekText="›" CssClass="fc-body CalAttendance" OnDayRender="Calendar1_DayRender"
                CellPadding="4">                                                                                
            </asp:Calendar>
                  <ul class="color-code">
                  <li><span class="color-box Absent"></span>Absent </li>
                   <li><span class="color-box Present1"> </span>Present </li>       
                  <%-- <li> <span class="color-box Holiday"> </span>Holiday</li>--%>
                   <li> <span class="color-box Leave"> </span>Holiday</li>
                  
                  </ul>
                  
                  <div class="clearfix"></div>
                    <!-- calendar end--> 
                  </div><!-- /.tab-pane -->
                  <div class="tab-pane" id="Tabular">
                    <!-- Tabular -->
                    
                    
                   <table width="100%" class="tabular">
                                                                                <tr>
                                                                                    <td align="right" valign="top" width="10%">
                                                                                        <asp:ImageButton ID="lnkPrevious" OnClick="lnkPrevious_Click" runat="server" ImageUrl="~\images\previous.png"
                                                                                            ToolTip="Previous" Width="30px" />
                                                                                    </td>
                                                                                    <td align="center" width="80%" >
                                                                                        <asp:DropDownList ID="ddlMonth" runat="server"
                                                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                                                                            <asp:ListItem>--Select Month--</asp:ListItem>
                                                                                            <asp:ListItem Value="1">Jan</asp:ListItem>
                                                                                            <asp:ListItem Value="2">Feb</asp:ListItem>
                                                                                            <asp:ListItem Value="3">Mar</asp:ListItem>
                                                                                            <asp:ListItem Value="4">Apr</asp:ListItem>
                                                                                            <asp:ListItem Value="5">May</asp:ListItem>
                                                                                            <asp:ListItem Value="6">June</asp:ListItem>
                                                                                            <asp:ListItem Value="7">July</asp:ListItem>
                                                                                            <asp:ListItem Value="8">Aug</asp:ListItem>
                                                                                            <asp:ListItem Value="9">Sep</asp:ListItem>
                                                                                            <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                                            <asp:ListItem Value="11">Nov</asp:ListItem>
                                                                                            <asp:ListItem Value="12">Dec</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td align="left" valign="top" width="10%">
                                                                                        <asp:ImageButton ID="lnkNext" OnClick="lnkNext_Click" runat="server" ImageUrl="~\images\next.png"
                                                                                            ToolTip="Next" Width="30px" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>

                                                                            <div class="clearfix"></div>
                                                                            <asp:GridView ID="grvAttendance" runat="server" AllowPaging="True" AllowSorting="True"
                                                                            AutoGenerateColumns="False" CssClass="table  tabular-table" EmptyDataText="Record not Found."
                                                                            Width="90%" OnRowDataBound="grvAttendance_RowDataBound" OnPageIndexChanging="grvAttendance_PageIndexChanging" PageSize="31">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="dtDate" HeaderText="Date" ReadOnly="True">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="vchday" HeaderText="Day" ReadOnly="True">
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="dtinTime" HeaderText="In-Time " ReadOnly="True" Visible = "false">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="dtoutTime" HeaderText="Out-Time" ReadOnly="True" Visible = "false">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="vchlatestatus" HeaderText="Status" ReadOnly="True" Visible="false">
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField HeaderText="Status">
                                                                                <ItemTemplate>
                                                                                <asp:Label ID="lblStatus" Text='<%#Eval("vchlatestatus") %>' runat="server">0</asp:Label>
                                                                                </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Working Hrs" Visible="false" >
                                                                                <ItemTemplate>
                                                                                <asp:Label ID="lblLate" Text='<%#Eval("Latetime") %>' runat="server">0</asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="Latetime" HeaderText="Late (HH:MM)" ReadOnly="True" Visible="false">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="AttendanceMode" HeaderText="Attendance Mode" ReadOnly="True">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                            <RowStyle HorizontalAlign="Left"></RowStyle>
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                            <PagerStyle CssClass="pgr" />
                                                                        </asp:GridView>
                    
                    
                    
                    
                    
                    <div class="clearfix"></div>
                    
                  </div><!-- /.Tabular -->

                  <div class="tab-pane" id="Summary">
                  <!-- summary-->
                   
                   <ul class="attendance-summary">
                   
                   <li>January-<asp:Label ID="lblJanYear" runat="server" Text ="0"></asp:Label>
                   <ul>
                   <li>Absent <span class="badge bg-red"><asp:Label ID="lblJanAbsent" runat="server" Text ="0"></asp:Label></span></li>        
                   <li>Present <span class="badge bg-green"><asp:Label ID="lblJanPresent" runat="server" Text ="0"></asp:Label></span></li>
                   <li><h4></h4></li>         
                   <%--<li>Late  <span class="badge bg-yellow">1</span></li>        
                   <li>Leave <span class="badge bg-light-blue">2</span></li>--%> 
                   </ul>
                   
                   </li>
                   <li>February-<asp:Label ID="lblFebYear" runat="server" Text ="0"></asp:Label>                   
                   <ul>  
                   <li>Absent <span class="badge bg-red"><asp:Label ID="lblFebAbsent" runat="server" Text ="0"></asp:Label></span></li>        
                   <li>Present <span class="badge bg-green"><asp:Label ID="lblFebPresent" runat="server" Text ="0"></asp:Label></span></li>
                   </ul>
                   
                   </li>
                   <li>March-<asp:Label ID="lblmarchYear" runat="server" Text ="0"></asp:Label>                   
                   <ul>                   
                   <li>Absent <span class="badge bg-red"><asp:Label ID="lblMarchAbsent" runat="server" Text ="0"></asp:Label></span></li>        
                   <li>Present <span class="badge bg-green"><asp:Label ID="lblMarchPresent" runat="server" Text ="0"></asp:Label></span></li>
                   </ul>                   
                   </li>
                   <li>April-<asp:Label ID="lblAprilYear" runat="server" Text ="0"></asp:Label>                   
                   <ul>
                   <li>Absent <span class="badge bg-red"><asp:Label ID="lblAprilAbsent" runat="server" Text ="0"></asp:Label></span></li>                              
                   <li>Present <span class="badge bg-green"><asp:Label ID="lblAprilPresent" runat="server" Text ="0"></asp:Label></span></li>        
                   
                   </ul>
                   </li>
                   <li>May-<asp:Label ID="lblMayYear" runat="server" Text ="0"></asp:Label>                   
                   <ul>
                   <li>Absent <span class="badge bg-red"><asp:Label ID="lblMayAbsent"  runat="server" Text ="0"></asp:Label></span></li>        
                   <li>Present <span class="badge bg-green"><asp:Label ID="lblMayPresent" runat="server" Text ="0"></asp:Label></span></li>                              
                   </ul>                   
                   </li>
                   <li>June-<asp:Label ID="lblJuneYear" runat="server" Text ="0"></asp:Label>                   
                   <ul>
                   <li>Absent <span class="badge bg-red"><asp:Label ID="lblJuneAbsent" runat="server" Text ="0"></asp:Label></span></li>        
                   <li>Present <span class="badge bg-green"><asp:Label ID="lblJunePresent" runat="server" Text ="0"></asp:Label></span></li>                              
                   </ul>  
                   </li>
                   <li>July-<asp:Label ID="lbljulyYear" runat="server" Text ="0"></asp:Label>                   
                   <ul>
                   <li>Absent <span class="badge bg-red"><asp:Label ID="lblJulyAbsent" runat="server" Text ="0"></asp:Label></span></li>        
                   <li>Present <span class="badge bg-green"><asp:Label ID="lblJulyPresent" runat="server" Text ="0"></asp:Label></span></li>                              
                   </ul>
                   </li>
                   <li>August-<asp:Label ID="lblAugustYear" runat="server" Text ="0"></asp:Label>                   
                   <ul>
                   <li>Absent <span class="badge bg-red"><asp:Label ID="lblAugustAbsent" runat="server" Text ="0"></asp:Label></span></li>        
                   <li>Present <span class="badge bg-green"><asp:Label ID="lblAugustPresent" runat="server" Text ="0"></asp:Label></span></li>                              
                   </ul>
                   </li>
                   <li>September-<asp:Label ID="lblSeptemberYear" runat="server" Text ="0"></asp:Label>                   
                   <ul>
                   <li>Absent <span class="badge bg-red"><asp:Label ID="lblSeptemberAbsent" runat="server" Text ="0"></asp:Label></span></li>        
                   <li>Present <span class="badge bg-green"><asp:Label ID="lblSeptemberPresent" runat="server" Text ="0"></asp:Label></span></li>
                   </ul>
                   </li>
                   <li>October-<asp:Label ID="lblOctoberYear" runat="server" Text ="0"></asp:Label>                   
                   <ul>
                   <li>Absent <span class="badge bg-red"><asp:Label ID="lblOctoberAbsent" runat="server" Text ="0"></asp:Label></span></li>        
                   <li>Present <span class="badge bg-green"><asp:Label ID="lblOctoberPresent" runat="server" Text ="0"></asp:Label></span></li>
                   </ul>
                   </li>
                   <li>November-<asp:Label ID="lblNovemberYear" runat="server" Text ="0"></asp:Label>                   
                   <ul>
                   <li >Absent <span class="badge bg-red"><asp:Label ID="lblNovemberAbsent" runat="server" Text ="0"></asp:Label></span></li>        
                   <li>Present <span class="badge bg-green"><asp:Label ID="lblNovemberPresent" runat="server" Text ="0"></asp:Label></span></li>
                   </ul>
                   </li>
                   <li>December-<asp:Label ID="lblDecemberYear" runat="server" Text ="0"></asp:Label>                   
                   <ul>
                   <li>Absent <span class="badge bg-red"><asp:Label ID="lblDecemberAbsent" runat="server" Text ="0"></asp:Label></span></li>        
                   <li>Present <span class="badge bg-green"><asp:Label ID="lblDecemberPresent" runat="server" Text ="0"></asp:Label></span></li>
                   </ul>
                   </li>
                   
                   </ul>
                    
                    
                    <div class="clearfix"></div>
                    <!-- summary-->
                  </div><!-- /.tab-pane -->
                </div><!-- /.tab-content -->
              </div>



              <!-- /.nav-tabs-custom -->
            </div><!-- /.col -->
          </div><!-- /.row -->

        </section>
</asp:Content>

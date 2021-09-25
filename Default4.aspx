<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBoos.master" AutoEventWireup="true"
    CodeFile="Default4.aspx.cs" Inherits="Default4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                  <p class="text-muted text-center">STD / DIV : <asp:Label ID="lblSTDNm" runat="server" Text="Label"></asp:Label> / <asp:Label ID="lblDIVNm" runat="server" Text="Label"></asp:Label></p>

                  <ul class="list-group list-group-unbordered">
                    <li class="list-group-item">
                      <b>Present</b> <%--<a class="pull-right">20</a>--%><asp:Label ID="lblPresent" runat="server" Text ="20" CssClass="pull-right"></asp:Label>
                    </li>
                    <li class="list-group-item">
                      <b>Absent</b> <%--<a class="pull-right">2</a>--%><asp:Label ID="lblAbsent" runat="server" Text ="1" CssClass="pull-right"></asp:Label>
                    </li>
                    <li class="list-group-item">
                      <b>Late</b> <%--<a class="pull-right">4</a>--%><asp:Label ID="lbllate" runat="server" Text ="4" CssClass="pull-right"></asp:Label>
                    </li>
                  </ul>

                  
                </div><!-- /.box-body -->
              </div><!-- /.box -->

              <!-- About Me Box -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Attendance top 5</h3>
                </div><!-- /.box-header -->
                <div class="box-body">
                <div class="top-five">Student Name     <span class="pull-right">Present\Total</span></div>
                  <ul class="list-group list-group-unbordered">
                    <li class="list-group-item">
                      <b>Adeepa More</b> <a class="pull-right">143\145</a>
                    </li>
                    <li class="list-group-item">
                      <b>Shrivardhan Iyer</b> <a class="pull-right">120\145</a>
                    </li>
                    <li class="list-group-item">
                      <b>Jaidev Kaur</b> <a class="pull-right">120\145</a>
                    </li>
                     <li class="list-group-item">
                      <b>Samhit Yadav</b> <a class="pull-right">119\145</a>
                    </li>
                     <li class="list-group-item">
                      <b>Urugay Gupta</b> <a class="pull-right">119\145</a>
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
              <div id='calendar'></div>
                  <ul class="color-code">
                  <li><span class="color-box Absent"></span>Absent </li>
                   <li><span class="color-box Present"> </span>Present </li>
                   <li> <span class="color-box Late"> </span>Late</li>  
                   <li> <span class="color-box Leave"> </span> Leave </li>       
                   <li><span class="color-box Sunday"> </span>Sunday  </li>         
                   <li> <span class="color-box Holiday"> </span>Holiday</li>
                  
                  </ul>
                  
                  <div class="clearfix"></div>
                    <!-- calendar end--> 
                  </div><!-- /.tab-pane -->
                  <div class="tab-pane" id="Tabular">
                    <!-- Tabular -->
                    
                    
                    <select class="pull-right attendance-list">
 <option value="--Select Month--">--Select Month--</option>
				<option selected="selected" value="1">Jan</option>
				<option value="2">Feb</option>
				<option value="3">Mar</option>
				<option value="4">Apr</option>
				<option value="5">May</option>
				<option value="6">June</option>
				<option value="7">July</option>
				<option value="8">Aug</option>
				<option value="9">Sep</option>
				<option value="10">Oct</option>
				<option value="11">Nov</option>
				<option value="12">Dec</option>

</select>


<div class="clearfix"></div>
                    
                    <div class="box-body table-responsive no-padding">
                  <table class="table table-hover">
                    <tbody><tr >
                      <th>Date</th>
                      <th>Day</th>
                      <th>In-Time</th>
                      <th>Out-Time</th>
                      <th>Status</th>
                      <th>Late (HH:MM)</th>
                      <th>Attendance Mode</th>
                    </tr>
               <tr >
						<td>01/08/2015</td><td >Saturday</td><td>07:30</td><td>12:30</td><td >Present</td><td>02:30</td><td>&nbsp;</td>
					</tr><tr class="alt" >
						<td>03/08/2015</td><td >Monday</td><td>07:30</td><td>12:30</td><td >Present</td><td>02:30</td><td>&nbsp;</td>
					</tr><tr >
						<td>04/08/2015</td><td >Tuesday</td><td>07:30</td><td>12:30</td><td >Present</td><td>02:30</td><td>&nbsp;</td>
					</tr><tr class="alt" >
						<td>05/08/2015</td><td >Wednesday</td><td>07:30</td><td>12:30</td><td >Present</td><td>02:30</td><td>&nbsp;</td>
					</tr><tr >
						<td>06/08/2015</td><td >Thursday</td><td>07:30</td><td>12:30</td><td >Present</td><td>02:30</td><td>&nbsp;</td>
					</tr><tr class="alt" >
						<td>07/08/2015</td><td >Friday</td><td>07:30</td><td>12:30</td><td >Present</td><td>02:30</td><td>&nbsp;</td>
					</tr><tr >
						<td>08/08/2015</td><td >Saturday</td><td>07:30</td><td>12:30</td><td >Present</td><td>02:30</td><td>&nbsp;</td>
					</tr><tr class="alt" >
						<td>10/08/2015</td><td >Monday</td><td>07:30</td><td>12:30</td><td >Present</td><td>02:30</td><td>&nbsp;</td>
					</tr><tr >
						<td>11/08/2015</td><td >Tuesday</td><td>07:30</td><td>12:30</td><td >Present</td><td>02:30</td><td>&nbsp;</td>
					</tr><tr class="alt" >
						<td>12/08/2015</td><td >Wednesday</td><td>07:30</td><td>12:30</td><td >Present</td><td>02:30</td><td>&nbsp;</td>
					</tr><tr >
						<td>13/08/2015</td><td >Thursday</td><td>07:30</td><td>12:30</td><td >Present</td><td>02:30</td><td>&nbsp;</td>
					</tr><tr class="alt" >
						<td>14/08/2015</td><td >Friday</td><td>07:30</td><td>12:30</td><td >Present</td><td>02:30</td><td>&nbsp;</td>
					</tr><tr >
						<td>17/08/2015</td><td >Monday</td><td>07:30</td><td>12:30</td><td >Present</td><td>02:30</td><td>&nbsp;</td>
					</tr><tr class="alt" >
						<td>18/08/2015</td><td >Tuesday</td><td>09:03</td><td>09:03</td><td >Absent</td><td>23:03</td><td>&nbsp;</td>
					</tr><tr >
						<td>19/08/2015</td><td >Wednesday</td><td>20:38</td><td>21:14</td><td >Late</td><td>10:38</td><td>&nbsp;</td>
					</tr><tr class="alt" >
						<td>20/08/2015</td><td >Thursday</td><td>12:05</td><td>12:05</td><td >Present</td><td>02:05</td><td>&nbsp;</td>
					</tr><tr >
						<td>21/08/2015</td><td >Friday</td><td>&nbsp;</td><td>&nbsp;</td><td >Leave</td><td>&nbsp;</td><td>&nbsp;</td>
					</tr><tr class="alt" >
						<td>22/08/2015</td><td >Saturday</td><td>&nbsp;</td><td>&nbsp;</td><td >Leave</td><td>&nbsp;</td><td>&nbsp;</td>
					</tr><tr >
						<td>23/08/2015</td><td >Sunday</td><td>&nbsp;</td><td>&nbsp;</td><td >Leave</td><td>&nbsp;</td><td>&nbsp;</td>
					</tr><tr class="alt" >
						<td>24/08/2015</td><td >Monday</td><td>&nbsp;</td><td>&nbsp;</td><td >Leave</td><td>&nbsp;</td><td>&nbsp;</td>
					</tr><tr >
						<td>25/08/2015</td><td >Tuesday</td><td>&nbsp;</td><td>&nbsp;</td><td >Leave</td><td>&nbsp;</td><td>&nbsp;</td>
					</tr><tr class="alt" >
						<td>27/08/2015</td><td >Thursday</td><td>&nbsp;</td><td>&nbsp;</td><td >Leave</td><td>&nbsp;</td><td>&nbsp;</td>
					</tr><tr >
						<td>28/08/2015</td><td >Friday</td><td>&nbsp;</td><td>&nbsp;</td><td >Leave</td><td>&nbsp;</td><td>&nbsp;</td>
					</tr><tr class="alt" >
						<td>29/08/2015</td><td >Saturday</td><td>&nbsp;</td><td>&nbsp;</td><td >Leave</td><td>&nbsp;</td><td>&nbsp;</td>
					</tr><tr >
						<td>30/08/2015</td><td >Sunday</td><td>&nbsp;</td><td>&nbsp;</td><td >Leave</td><td>&nbsp;</td><td>&nbsp;</td>
					</tr><tr class="alt" >
						<td>31/08/2015</td><td >Monday</td><td>&nbsp;</td><td>&nbsp;</td><td >Leave</td><td>&nbsp;</td><td>&nbsp;</td>
					</tr>
				
                    
                  </tbody></table>
                </div>
                    
                    
                    
                    
                    
                    
                  </div><!-- /.Tabular -->

                  <div class="tab-pane" id="Summary">
                  <!-- summary-->
                   
                   <ul class="attendance-summary">
                   
                   <li>January   
                   
                   <ul>
                   <li>Absent <span class="badge bg-red">2</span></li>        
                   <li>Present <span class="badge bg-green">20</span></li>         
                   <li>Late  <span class="badge bg-yellow">1</span></li>        
                   <li>Leave <span class="badge bg-light-blue">2</span></li> 
                   </ul>
                   
                   </li>
                   <li>February
                   
                    <ul>
                   <li>Absent <span class="badge bg-red">2</span></li>        
                   <li>Present <span class="badge bg-green">20</span></li>         
                   <li>Late  <span class="badge bg-yellow">1</span></li>        
                   <li>Leave <span class="badge bg-light-blue">2</span></li> 
                   </ul>
                   
                   </li>
                   <li>March
                   
                    <ul>
                   <li>Absent <span class="badge bg-red">2</span></li>        
                   <li>Present <span class="badge bg-green">20</span></li>         
                   <li>Late  <span class="badge bg-yellow">1</span></li>        
                   <li>Leave <span class="badge bg-light-blue">2</span></li> 
                   </ul>
                   
                   </li>
                   <li>April</li>
                   <li>May</li>
                   <li>June</li>
                   <li>July</li>
                   <li>August</li>
                   <li>September</li>
                   <li>October</li>
                   <li>November</li>
                   <li>December</li>
                   
                   </ul>
                    
                    
                    <div class="clearfix"></div>
                    <!-- summary-->
                  </div><!-- /.tab-pane -->
                </div><!-- /.tab-content -->
              </div><!-- /.nav-tabs-custom -->
            </div><!-- /.col -->
          </div><!-- /.row -->

        </section>
</asp:Content>

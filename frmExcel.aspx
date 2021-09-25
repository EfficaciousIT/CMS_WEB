<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmExcel.aspx.cs" Inherits="frmExcel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <asp:Button ID="Button1" runat="server" Text="Button" 
        onclick="Button1_Click1" />
   

     <asp:GridView ID="GridViewliststud" runat="server" designer:wfdid="w36"
                                                                AllowSorting="True" OnRowEditing="GridViewliststud_RowEditing" OnDataBound="GridViewliststud_DataBound"
                                                                OnRowDataBound="GridViewliststud_RowDataBound" OnRowDeleting="GridViewliststud_RowDeleting"
                                                                AutoGenerateColumns="False" CssClass="table  tabular-table"
                                                                DataKeyNames="intStudent_id" EmptyDataText="Record not Found." 
                                                                Width="100%">
                                                                <AlternatingRowStyle CssClass="alt" />
                                                                <Columns>
                                                                  
                                                                    <asp:TemplateField HeaderText="Details" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="btnDetails" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                ImageUrl="images/icon_edit.png" Text="Delete" AlternateText="Details" ToolTip="Click"
                                                                                Style="width: 20px !important;" ForeColor="#CC0000" /></ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Parents Details" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="btnpareDetails" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                ImageUrl="images/icon_edit.png" align="center" Text="parets" AlternateText="Details"
                                                                                ToolTip="Click" Style="width: 20px !important;" ForeColor="#CC0000" /></ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="intStudent_id" HeaderText="Student Id" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intstanderd_id" HeaderText="Standard" Visible="false" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intDivision_id" HeaderText="Division" Visible="false" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intRollNo" HeaderText="Roll No" ReadOnly="True" />
                                                                    <asp:BoundField DataField="name" HeaderText="Student Name" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchEmail" HeaderText="Email ID" ReadOnly="True" />
                                                                    <asp:BoundField DataField="dtDOB" HeaderText="Date of Birth" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchGender" HeaderText="Gender" ReadOnly="True"  />
                                                                    <asp:BoundField DataField="chrBloodGrp" HeaderText="Blood Group" ReadOnly="True"  />
                                                                    <asp:BoundField DataField="vchReligion" HeaderText="Religion" ReadOnly="True"  Visible="false"  />
                                                                    <asp:BoundField DataField="vchPlaceofBirth" HeaderText="Place Of Birth" ReadOnly="True" Visible="false" />
                                                                     <asp:BoundField DataField="vchFatherName" HeaderText="Father Name" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchMotherName" HeaderText="Mother Name" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intFatherMobile" HeaderText="Father Mobile No" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchpresentAddress" HeaderText="Present Address" ReadOnly="True" />
                                                                    <asp:BoundField DataField="MandatorySubject" HeaderText="Mandatory Subject" ReadOnly="True"   />
                                                                    <asp:BoundField DataField="OptionalSubject" HeaderText="Optional Subject" ReadOnly="True"  />
                                                                     
                                                                    <asp:TemplateField HeaderText="Edit" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" Style="width: 18px !important;" ImageUrl="~/images/edit.png"
                                                                                CommandName="Edit" CausesValidation="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Delete" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" Style="width: 22px !important;" ImageUrl="~/images/delete.png"
                                                                                CommandName="Delete" OnClientClick="return confirm(&quot;Are you sure you want delete the user?&quot;);"
                                                                                CausesValidation="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerStyle CssClass="pgr" />
                                                            </asp:GridView>

                 <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="99%"
                                                                DataKeyNames="intBookDetails_id"
                                                                >
                                                                <Columns>
                                                                <asp:BoundField DataField="intStandard_id" HeaderText="Standard" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchAccessionNo" HeaderText="Accessio No." ReadOnly="True" />
                                                                <asp:BoundField DataField="intCategory_id" HeaderText="Category" ReadOnly="True" />
                                                                <asp:BoundField DataField="intBookEdition_id" HeaderText="Edition" ReadOnly="True" />
                                                                <asp:BoundField DataField="intBook_publication_id" HeaderText="Publication" ReadOnly="True" />
                                                                <asp:BoundField DataField="intBook_Author_id" HeaderText="Author" ReadOnly="True" />
                                                                <asp:BoundField DataField="intBookLanguage_id" HeaderText="Subject" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchBookDetails_bookName" HeaderText="Book Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchBookDetails_Status" HeaderText="Status" ReadOnly="True" />
                                                                <asp:BoundField DataField="intBookQuantity" HeaderText="Qty" ReadOnly="True" 
                                                                        Visible="False" />
                                                                <asp:BoundField DataField="intBookPrice" HeaderText="Price" ReadOnly="True"  
                                                                        Visible="False"/>                                                                     
                                                                    
                                                                   
                                                                </Columns>
                                                            </asp:GridView>

        <asp:GridView ID="grdBookHistory" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            CssClass="table  tabular-table " PageSize="20" Width="99%"
            >
            <Columns>
                    <asp:BoundField DataField="Role" HeaderText="Role" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                    <asp:BoundField DataField="Standard" HeaderText="Standard" ReadOnly="True" />
                    <asp:BoundField DataField="Division" HeaderText="Division" ReadOnly="True" />
                    <asp:BoundField DataField="Department" HeaderText="Department" ReadOnly="True" />
                    <asp:BoundField DataField="Designation" HeaderText="Designation" ReadOnly="True" />
                    <asp:BoundField DataField="BookName" HeaderText="Book Name" ReadOnly="True" />
                    <asp:BoundField DataField="IssuedDate" HeaderText="Issued Date" ReadOnly="True" />
                    <asp:BoundField DataField="ExpectedReturnDate" HeaderText="Expected Return Date" ReadOnly="True" />
                    <asp:BoundField DataField="ReturnedDate" HeaderText="Returned Date" ReadOnly="True" />
                    <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True"  />                                                                     
                                                                   
            </Columns>
        </asp:GridView>

        <asp:GridView ID="grdBookDetailsReport" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            CssClass="table  tabular-table " PageSize="20" Width="99%">
            <Columns>
                <asp:BoundField DataField="intStandard_id" HeaderText="Standard" ReadOnly="True" />
                <asp:BoundField DataField="vchAccessionNo" HeaderText="Accessio No." ReadOnly="True" />
                <asp:BoundField DataField="intCategory_id" HeaderText="Category" ReadOnly="True" />
                <asp:BoundField DataField="intBookEdition_id" HeaderText="Edition" ReadOnly="True" />
                <asp:BoundField DataField="intBook_publication_id" HeaderText="Publication" ReadOnly="True" />
                <asp:BoundField DataField="intBook_Author_id" HeaderText="Author" ReadOnly="True" />
                <asp:BoundField DataField="intBookLanguage_id" HeaderText="Subject" ReadOnly="True" />
                <asp:BoundField DataField="vchBookDetails_bookName" HeaderText="Book Name" ReadOnly="True" />
                <asp:BoundField DataField="vchBookDetails_Status" HeaderText="Status" ReadOnly="True" />
                <asp:BoundField DataField="vchBookDetails_Remark" HeaderText="Remark" ReadOnly="True" />
                <asp:BoundField DataField="intBookQuantity" HeaderText="Qty" ReadOnly="True" 
                        Visible="False" />
                <asp:BoundField DataField="intBookPrice" HeaderText="Price" ReadOnly="True"  
                        Visible="False"/>                                                                       
                                                                   
            </Columns>
        </asp:GridView>
         <asp:GridView runat="server" ID="grdtemp"></asp:GridView>

         
                                                                 <asp:GridView ID="GridView2" runat="server" 
                                                                AllowSorting="True" 
                                                                AutoGenerateColumns="False" CssClass="table  tabular-table" 
                                                                 EmptyDataText="Record not Found." 
                                                                Width="100%" Visible="True">
                                                                <AlternatingRowStyle CssClass="alt" />
                                                                <Columns>
                                                                    
                                                                    <asp:BoundField DataField="int_ID" HeaderText="int_ID" ReadOnly="True" Visible="false" />
                                                                    <asp:BoundField DataField="Student_name" HeaderText="Student Name" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchStandard_name" HeaderText="Standard" ReadOnly="True"/>
                                                                    <asp:BoundField DataField="vchDivisionName" HeaderText="Division"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="EmailID" HeaderText="Email ID"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchBank_name" HeaderText="Bank Name" ReadOnly="True" />
                                                                    <asp:BoundField DataField="FeeAmount" HeaderText="Amount To be Paid " ReadOnly="True" />
                                                                    <asp:BoundField DataField="PaidAmt" HeaderText="Paid Amount" ReadOnly="True" />
                                                                    <asp:BoundField DataField="PaymentRefNo" HeaderText="Payment Reference Number" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Remarks" HeaderText="Remark" ReadOnly="True"  />
                                                                    <asp:BoundField DataField="dtInsertDate" HeaderText="Date" ReadOnly="True"  />
                                                                  
                                                                </Columns>
                                                                <PagerStyle CssClass="pgr" />
                                                            </asp:GridView>


</asp:Content>


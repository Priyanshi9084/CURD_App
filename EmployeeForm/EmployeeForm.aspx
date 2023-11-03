<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" CodeBehind="EmployeeForm.aspx.cs" Inherits="EmployeeForm.EmployeeForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <center>
                 <h1 style="background-color:blue">Employee Details</h1>
            <table>
                <tr>
                    <td>Name :</td>
                    <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Status :</td>
                    <td><asp:RadioButtonList ID="rblstatus" runat="server" RepeatColumns="3"></asp:RadioButtonList></td>
                </tr>
                 <tr>
                    <td>Hobbies :</td>
                    <td><asp:CheckBoxList ID="cblhobbies" runat="server" RepeatColumns="3"></asp:CheckBoxList></td>
                </tr>
                <tr>
                    <td>Department :</td>
                    <td><asp:DropDownList ID="ddldepartment" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Qualification:</td>

                   <td><asp:DropDownList ID="ddlqualification" runat="server"></asp:DropDownList></td>
                </tr>

                 <tr>
                    <td>Country :</td>
                   <td><asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                </tr>

                
                 <tr>
                    <td>State :</td>
                   <td><asp:DropDownList ID="ddlstate" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>City :</td>
                   <td><asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList></td>
                </tr>

                <tr>
                    <td></td>
                    <td><asp:TextBox ID="txtsearch" runat="server"></asp:TextBox>
                        <asp:Button ID="btnsearch" runat="server" BackColor="Red" ForeColor="White" Width="80px" Height="30px" Text="Search" OnClick="btnsearch_Click" /></td>
                </tr>

                <tr>
                    <td></td>
                    <td><asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></td>
                </tr>


                <tr>
                    <td></td>
                    <td><asp:Button ID="btnsubmit" runat="server" BackColor="DarkOliveGreen" ForeColor="White" Width="70px" Height="27px" Text="Submit" OnClick="btnsubmit_Click" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:GridView ID="gvemployee" runat="server" AutoGenerateColumns="False" OnRowCommand="gvemployee_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" >
                        <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Employee ID">
                            <ItemTemplate>
                                <%#Eval("empid")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Name">
                            <ItemTemplate>
                                <%#Eval("ename")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Status">
                            <ItemTemplate>
                                <%#Eval("sname")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Hobbies">
                            <ItemTemplate>
                                <%#Eval("ehobbies")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Department">
                            <ItemTemplate>
                                <%#Eval("dname")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Qualification">
                            <ItemTemplate>
                                <%#Eval("qname")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee Country ">
                            <ItemTemplate>
                                <%#Eval("cname")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee State">
                            <ItemTemplate>
                                <%#Eval("stname")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee City">
                            <ItemTemplate>
                                <%#Eval("cityname")%>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField>
                            <ItemTemplate>
                               <asp:Button ID="btndelete" runat="server" BackColor="DarkOliveGreen" ForeColor="White" Width="70px" Height="27px"  Text="Delete" CommandName="A" CommandArgument='<%#Eval("empid")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                               <asp:Button ID="btnedit" runat="server" BackColor="DarkOliveGreen" ForeColor="White" Width="70px" Height="27px"  Text="Edit" CommandName="B" CommandArgument='<%#Eval("empid")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView></td>
                </tr>
            </table>
       </asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EmployeeForm.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <h1>Welcome <asp:Label ID="lblname" runat="server"></asp:Label></h1>
    <table>
        <tr>
            <td>
                <asp:GridView ID="gvmregistration" runat="server" AutoGenerateColumns="false" OnRowCommand="gvmregistration_RowCommand" CellPadding="4" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Register ID">
                            <ItemTemplate>
                                <%#Eval("rid")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Register Name">
                            <ItemTemplate>
                                <%#Eval("rname")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gender">
                            <ItemTemplate>
                                <%#Eval("gname")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="R_Email">
                            <ItemTemplate>
                                <%#Eval("remail")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="R_State">
                            <ItemTemplate>
                                <%#Eval("stname")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="R_City">
                            <ItemTemplate>
                                <%#Eval("cityname")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Password">
                            <ItemTemplate>
                                <%#Eval("rpassword")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date of Birth">
                            <ItemTemplate>
                                <%#Eval("dob")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField>
                            <ItemTemplate>
                               <asp:Button ID="btndelete" runat="server" BackColor="DarkOliveGreen" ForeColor="White" Width="70px" Height="27px"  Text="Delete" CommandName="A" CommandArgument='<%#Eval("rid")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                               <asp:Button ID="btnedit" runat="server" BackColor="DarkOliveGreen" ForeColor="White" Width="70px" Height="27px"  Text="Edit" CommandName="B" CommandArgument='<%#Eval("rid")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                        </asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>

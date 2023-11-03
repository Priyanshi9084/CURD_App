<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.Master" CodeBehind="UserForm1.aspx.cs" Inherits="EmployeeForm.ImageForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <center>
                 <h1 style="background-color:blueviolet">User Information </h1>
            <table>
                <tr>
                    <td>Name :</td>
                    <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Age :</td>
                    <td><asp:TextBox ID="txtage" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Image Upload :</td>
                    <td><asp:FileUpload ID="fuimage" runat="server"></asp:FileUpload></td>
                </tr>

                <tr>
                    <td></td>
                    <td><asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:GridView ID="gvimage" runat="server" AutoGenerateColumns="false" OnRowCommand="gvimage_RowCommand" >
                    <Columns>
                        <asp:TemplateField HeaderText="User ID">
                            <ItemTemplate>
                                <%#Eval("uid")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Name">
                            <ItemTemplate>
                                <%#Eval("uname")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Age">
                            <ItemTemplate>
                                <%#Eval("uage")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="User Image">
                            <ItemTemplate>
                             <asp:Image ID="imguser" runat="server" Width="50px" Height="40px" ImageUrl='<%#Eval("uimaage","~/Userpics/{0}")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField>
                            <ItemTemplate>
                             <asp:Button ID="btndelete" runat="server"  Text="Delete" CommandName="A" CommandArgument='<%#Eval("uid")+ ","+Eval("uimaage")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                             <asp:Button ID="btnedit" runat="server"  Text="Edit" CommandName="B" CommandArgument='<%#Eval("uid")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    </asp:GridView></td>
                </tr>
            </table>
                </asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="EmployeeForm.LoginForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <tr>
            <td>Email :</td>
            <td>
               <asp:TextBox ID="txtemail" runat="server"></asp:TextBox> </td>
        </tr>
        <tr>
         <td>Password :</td>
            <td>
                <asp:TextBox ID="txtpass" runat="server"></asp:TextBox></td>
        </tr> 
        <tr>
            <td></td>
            <td><asp:Button ID="btnlogin" runat="server" BackColor="DarkOliveGreen" ForeColor="White" Width="70px" Height="27px" Text="Login" OnClick="btnlogin_Click1"></asp:Button> </td>
        </tr>
        <tr>
            <td>
            </td>
            <td><asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true" ></asp:Label></td>
        </tr>
    </table>
</asp:Content>

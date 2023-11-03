<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="EmployeeForm.RegistrationForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Name :</td>
            <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox> </td>
        </tr>

         <tr>
            <td>Gender :</td>
            <td><asp:RadioButtonList ID="rblgender" runat="server"></asp:RadioButtonList></> </td>
        </tr>

         <tr>
            <td>State :</td>
            <td><asp:DropDownList ID="ddlstate" runat="server" ></asp:DropDownList> </td>
        </tr>
         <tr>
            <td>City :</td>
            <td><asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList> </td>
        </tr>
         <tr>
            <td></td>
            <td><asp:Button ID="btnregister" runat="server"  Text="Register" OnClick="btnregister_Click"></asp:Button> </td>
        </tr>
    </table>
</asp:Content>

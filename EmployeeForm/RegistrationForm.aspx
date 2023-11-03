<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="EmployeeForm.RegistrationForm" %>
<%@ Register Assembly="AjaxControlToolKit" Namespace="AjaxControlToolKit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="mng" runat="server"></asp:ScriptManager>
    
    <center>
                 <h1 style="background-color:blue">  Registration  </h1>
    <table>
        <tr>
            <td>Name :</td>
            <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox> </td>
        </tr>

         <tr>
    <td>Status :</td>
    <td><asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3"></asp:RadioButtonList></td>
</tr>
         <tr>
            <td>Email :</td>
            <td>
               <asp:TextBox ID="txtemail" runat="server"></asp:TextBox> </td>
        </tr>
          <tr>
              <td>State :</td>
             <td><asp:DropDownList ID="ddlstate" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged1" AutoPostBack="true" ></asp:DropDownList></td>
             </tr>
                  <tr>
               <td>City :</td>
               <td><asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList></td>
               </tr>
          
             <tr>
            <td>Password :</td>
            <td>            
                <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr> 
           <tr>
            <td>Date of Birth :</td>
            <td><asp:TextBox ID="txtdob" runat="server"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="caldob" runat="server" PopupButtonID="txtdob" PopupPosition="TopRight" TargetControlID="txtdob"/>
            </td>
             </tr>
              <tr>
               <td></td>
               <td><asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></td>
                </tr>
         <tr>
            <td></td>
            <td><asp:Button ID="btnregister" runat="server" BackColor="DarkOliveGreen" ForeColor="White" Width="70px" Height="27px" Text="Register" OnClick="btnregister_Click"></asp:Button> </td>
        </tr>
         <tr>
                    <td></td>
                    <td><asp:GridView ID="gvmregistration" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333">
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
                       
                    </Columns>
                        </asp:GridView>
                        </tr>
    </table>
</asp:Content>

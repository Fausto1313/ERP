<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default5.aspx.cs" Inherits="Default5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
 <div class="tab-pane active" id="tab_d1">
             <h4  style="text-align:center; color:azure" >Sala de Capacitación</h4>                
              <p class="text-center"> Luces LED</p>
                <div style="text-align:center">   
                   <asp:Image ID="LEDON" runat="server" ImageUrl="~/iconos/green.png" Visible="false" />                            
                   <asp:Image ID="LEDOFF" runat="server" ImageUrl="~/iconos/red.png" Visible="false"  /> 
                <div class="btn-group" role="group"  style='padding-left: 3em' >                   
                   <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="on" onclick="Button1_Click" />  
                   <asp:Button ID="Button2" runat="server" CssClass="btn btn-default" Text="Off" onclick="Button2_Click"  />                  
                </div>
                </div>
              <br /><br />
     </div>
</asp:Content>


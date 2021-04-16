<%@ Page Title="Inicio de Sesión" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
       <style type="text/css">
      body 
      {
         background: url("../recursos/fondo.jpeg") repeat 0 0;
      }
    </style>

  <h2 style="margin-left:40%;margin-right:0px; color:white"><%: Title %></h2>
 
    <div class="container" >
  <div class="row" style="margin-left:25%;margin-right:0%">
        <div class="col-md-6" style="">
            <section id="loginForm">
              
                <div class="alert alert-info " role="alert" style="width:450px;border-color:aquamarine">
                    
                <div class="form-horizontal" style="">
                     <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         Bienvenido al Sistema Addar</h3> 
                    
                    <img src="../iconos/risc.jpeg" style="width:27%;height:27%; margin-left:35%; margin-right:0%"/>
                    <hr />
                  
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                   
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">Usuario</asp:Label>
                        <div class="col-md-10">
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-user"></span>
                                </span>
                                <asp:TextBox runat="server" placeholder="UserName" ID="UserName" CssClass="form-control" MaxLength="20" BorderColor=#0c4566 />
                            </div>                            
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                CssClass="text-danger" ErrorMessage="Se requiere de un nombre de usuario." />
                        </div>
                    </div>
                        
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-asterisk"></span>
                                </span>
                                <asp:TextBox runat="server" placeholder="Contraseña" ID="Password" TextMode="Password" CssClass="form-control" BorderColor=#0c4566 />
                            </div>                            
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="Se requiere de una contraseña." />
                        </div>
                    </div>
                        </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-12">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button runat="server" OnClick="LogIn" Text="Iniciar Sesión" CssClass="btn btn-primary" Width="162px" />
                       
                        </div>
                    </div>
                    <br />
                    
                </div>
     
                </section>
                </div>
 
        </div>
     
    </div>
 
</asp:Content>
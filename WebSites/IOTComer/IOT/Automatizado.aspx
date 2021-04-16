<%@ Page Title="Automatizado de dispositivos" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="Automatizado.aspx.cs" Inherits="Automatizado" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <LoggedInTemplate>
           
            <div class="row">
                <div class="col-xs-3 col-sm-4 col-lg-4 col-sm-offset-1 col-md-offset-1">
                    <h2>Revisar registro de automatización</h2>
                        <a class="btn btn-default" href="/IOT/registroAuto.aspx" style="background-image: url('/recursos/registro.jpg'); height: 260px; width: 260px;"></a>
                </div>
                <div class="col-xs-3 col-sm-4 col-lg-4 col-sm-offset-2 col-md-offset-3">
                    <h2>Añadir nueva tarea de automatizado</h2>
                   
                        <a class="btn btn-default" href="/IOT/nuevoAuto.aspx" style="background-image: url('/recursos/automatización.jpg');  height: 260px; width: 280px; background-repeat: no-repeat; text-align: right;"></a>
                </div>
            </div>
       
       </LoggedInTemplate>
   </asp:LoginView>
    <br />
    <br />
    <br />
    <br />
    <div>
        <a class="btn btn-danger" href="CatalogoSeguridad.aspx" runat="server" role="button">Volver</a>
    </div>
</asp:Content>


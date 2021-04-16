<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog.master" CodeFile="SubirImgPlano.aspx.cs" Inherits="IOT_SubirImgPlano" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
<div class="MiLabel">
   <asp:Label ID="Label1" runat="server" 
    CssClass="MiLabel"  Text="Subir Plano Arquitectónico"></asp:Label>
    </div>
         <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">En este cátalogo se podrá dar de alta el plano de acuerdo al sitio correspondiente.</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <hr />
   <br />
                    
     
                    
       <div class="container">
            <div class="row">
              <div class="col-md-4 col-md-offset-4">
                  Cliente
                  <asp:DropDownList ID="Clientes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ClienteSelecionado"></asp:DropDownList>
                   <br /><br />
                  Sitio
                  <asp:DropDownList ID="Sitios" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SitioSeleccionado"></asp:DropDownList>
                   <br /><br />
                  Piso
                  <asp:DropDownList ID="Nilveles" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Nivel_Seleccionado"></asp:DropDownList>
                   <br /><br />
                  Imagen Agregada:
                  <br />
                  <asp:Image ID="imgPreview"  ImageUrl="~/recursos/subirimg_01.png" Width="200"  runat="server" />
                  <br /><br />
                  Elegir Imagen: 
                  <asp:FileUpload ID="fuploadimagen" accept=".jpg" runat="server" CssClass="form-control"/>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  Display="Dynamic" ErrorMessage="El Mapa es obligatorio" ControlToValidate="fuploadimagen" ForeColor="Red">
                  </asp:RequiredFieldValidator>
                  <br /><br />
                  Titulo para Imagen
                  <asp:TextBox ID="txttitulo" runat="server" CssClass="form-control"></asp:TextBox>
                  <br /><br />
                  <asp:Button ID="btnSubir" runat="server" Text="Guardar Imagen" CssClass="btn btn-success" OnClick="BtnSubir"/>
                  <asp:Button ID="btnUpdatw" runat="server" Text="Actulizar Imagen" CssClass="btn btn-info" OnClick="BtnUpdate"/>

              </div>
            </div>
        </div>
      <div>
        <a class="btn btn-danger" href="Configuraciones.aspx" runat="server" role="button">Volver</a>
    </div>
           
               
     
   <style>
       
       .MiLabel
{
text-align:center;
color: #0D3685;
font-family: Arial; 
font-size:50px; 
}

</style>
</asp:Content>

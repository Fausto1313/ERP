<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog2.master" AutoEventWireup="true" CodeFile="AdministracionIconos.aspx.cs" Inherits="IOT_AdministracionCatalogos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
    <div class="col-md-2">
                    <asp:Label runat="server" AssociatedControlID="txtCategoria">Categoria</asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtCategoria" placeholder="Insertar Texto" CssClass="form-control" BorderColor="#0c4566" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCategoria" CssClass="text-danger" ErrorMessage="Ingresar texto." ValidationGroup="groupInsert"/>
                </div>
<div class="col-md-2">
                <asp:FileUpload runat="server" accept=".jpg,.png" ID="Imagen" />

    <asp:Button runat="server" ID="Guardar" Text ="Guardar" OnClick="Guardar_Click" />
</div>
</asp:Content>


<%@ Page Title="Registrar Tarea" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="nuevoAuto.aspx.cs" Inherits="nuevoAuto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
   <br />
     <nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
  <div class="container-fluid">
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#" style="color:azure">Registro de Tareas</a>

    </div>
      </div>
</nav>
    <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">INSTRUCCIONES: Para realizar una tarea repetida deberá seleccionarse las 4 listas desplegables y dar click en el botón de Registrar Tarea.
       <p>
        Para realizar una tarea única deberá seleccionar las 4 listas, darle click al recuadro de Tarea única, seleccionar la fecha del calendario y dar click 
        en el botón de Registrar Tarea.</p>
    <p>
        Podrás consultar los registros en la Bitacora de Revisar registro de automatización.
    </p>
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
    <br />
    <div class="form-horizontal" runat="server" >
       
        <br />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
        <div class="row" runat="server">
            <asp:Label runat="server" AssociatedControlID="DARS" CssClass="col-md-2">Nombre y acción del DAR</asp:Label>
            <div class="col-md-3">

               <asp:DropDownList runat="server" ID="DARS"  class="btn btn-info dropdown-toggle"  AutoPostBack="true" OnSelectedIndexChanged="nomD_SelectedIndexChanged" BorderColor=#0c4566 width="200px"/>
            </div>
            <asp:Label runat="server"></asp:Label>
            <div class="col-md-3">
                 <asp:DropDownList runat="server"  class="btn btn-info dropdown-toggle" BorderColor="#0c456" ID="Accion" AutoPostBack="true" width="200px"/>
            </div>
		</div>
        <br />
       
        <div class="row">
            <asp:Label runat="server" AssociatedControlID="horaD" CssClass="col-md-2">Hora y minutos de activacion</asp:Label>
            <div class="col-md-3">
                <asp:DropDownList ID="horaD" runat="server" class="btn btn-info dropdown-toggle" DataTextField="Url" DataValueField="horaD" BorderColor=#2eb6ab width="200px">
                    <asp:ListItem>Seleccionar Hora</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>0</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="minD" runat="server" DataTextField="Url" DataValueField="minD" class="btn btn-info dropdown-toggle" BorderColor=#2eb6ab width="200px">
                    <asp:ListItem>Seleccionar Minuto</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>31</asp:ListItem>
                    <asp:ListItem>32</asp:ListItem>
                    <asp:ListItem>33</asp:ListItem>
                    <asp:ListItem>34</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>36</asp:ListItem>
                    <asp:ListItem>37</asp:ListItem>
                    <asp:ListItem>38</asp:ListItem>
                    <asp:ListItem>39</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>41</asp:ListItem>
                    <asp:ListItem>42</asp:ListItem>
                    <asp:ListItem>43</asp:ListItem>
                    <asp:ListItem>44</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>46</asp:ListItem>
                    <asp:ListItem>47</asp:ListItem>
                    <asp:ListItem>48</asp:ListItem>
                    <asp:ListItem>49</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>51</asp:ListItem>
                    <asp:ListItem>52</asp:ListItem>
                    <asp:ListItem>53</asp:ListItem>
                    <asp:ListItem>54</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                    <asp:ListItem>56</asp:ListItem>
                    <asp:ListItem>57</asp:ListItem>
                    <asp:ListItem>58</asp:ListItem>
                    <asp:ListItem>59</asp:ListItem>
                    <asp:ListItem>00</asp:ListItem>
                </asp:DropDownList>
            </div>
            </div>
        <br />
        <div class="row">
            <asp:Label runat="server" AssociatedControlID="TareaR" ID="Label1" Text="¿La tarea es única?" />
            <asp:checkbox runat="server" ID="TareaR" OnCheckedChanged="TareaR_CheckedChanged" AutoPostBack="true"  />
            <asp:Calendar runat="server" ID="Fecha" Visible="false" />
            
            </div>
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Button runat="server" OnClick="crearTarea" Text="Registrar tarea" CssClass="btn btn-danger" Height="35px" />

            </div>
              <div>
        <a class="btn btn-danger" href="Automatizado.aspx" runat="server" role="button">Volver</a>
    </div>
            <div class="col-md-3">
                 <asp:Label runat="server" ID="estatusOK" Visible="false"  CssClass="label label-success" Text="Tarea programada"/>
                 <asp:Label runat="server" ID="estatusF" Visible="false"  CssClass="label label-danger" Text="Error al programar la tarea"/>
            </div>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
       
</asp:Content>


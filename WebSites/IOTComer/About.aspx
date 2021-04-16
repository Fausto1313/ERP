<%@ Page Title="Acerca del Internet de las Cosas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="row">
        <div class="col-xs-6 col-md-6">
             <h3>Definicion</h3>
            <p>Se trata una revolución en las relaciones entre los objetos y las personas, incluso entre los objetos directamente, que se conectaran 
                entre ellos y con la Red y ofrecerán datos en tiempo real. O dicho de otro modo, se acerca la digitalización del mundo físico.</p>
        </div>
        
        <div class="col-xs-6 col-md-6">
            <h3>Ventajas</h3>
            <p> - Automatización de tareas. Permite controlar las tareas que se realizan a diario, evitando la intervención humana. La 
                comunicación dispositivo a dispositivo ayuda a mantener la transparencia en los procesos.
                </p>
            <p>- Eficiencia y ahorro de tiempo. La interacción de dispositivo a dispositivo proporciona una mayor eficiencia, por lo tanto, resultados
                 exactos se pueden obtener rápidamente. 
               </p>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-6 col-md-6">
            <p>Según Hans Vestberg , CEO de Ericsson, las repercusiones serán considerables: «Si una persona se conecta a la red, le cambia la vida. 
                Pero si todas las cosas y objetos se conectan, es el mundo el que cambia.»</p>
            <p>Incluso se llega a considerar que será una de las grandes revoluciones que han existido a través de la historia de la humanidad,
                junto a otras grandes como la Revolución Industrial, por las grandes repercusiones que este nuevo concepto conlleva y que va de la mano
                con el desarrollo de tecnología. Esto es, simplificando lo anterior, que de una forma literal "Conectaremos hasta lo imposible por hacerlo inteligente".
            </p>
        </div>
       
       <div class="col-xs-6 col-md-6">
           <p>
                - Ahorro de dinero. El aprovechamiento óptimo de la energía y los recursos que puede lograrse mediante la adopción de esta tecnología y del mantenimiento de 
                los dispositivos bajo vigilancia influirán directamente en los costos.
                - Mejorar la calidad de vida. Todas las aplicaciones del Internet de la cosas culminan en un aumento de confort, comodidad y 
                una mejor gestión; mejorando así la calidad de vida.
           </p>
       </div>
    </div>
    <div class="row">
        <div class="col-xs-5 col-md-5">
            <asp:Image runat="server" CssClass="img-responsive"  ImageAlign="Middle" ImageUrl="~/recursos/fin.jpg" Width="300" Height="300" />
        </div>
        <div class="col-xs-2 col-md-2"></div>
        <div class="col-xs-5 col-md-5">
            <asp:Image runat="server" CssClass="img-responsive" ImageUrl="~/recursos/fin2.jpg" Width="300" Height="250" />
        </div>

    </div>
</asp:Content>

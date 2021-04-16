using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;

public partial class RestaurantService : System.Web.UI.Page
{
    protected static string conection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    public SqlConnection con = new SqlConnection(conection);
    protected void Page_Load(object sender, EventArgs e)
    {
        string cu = string.Empty;

        cu = Request["cu"];
        switch (cu) {
            case "1":
                returnMenu();
                break;
            case "2":
                doReservacion();
                break;
            case "2a":
                doReservacion2();
                break;
            case "3":
                returnName();
                break;
            case "4":
                returnMenuPedido();
                break;
            case "5":
                insertPedidoFirst();
                break;
            case "6":
                insertPedidoDetail();
                break;
            case "7":
                returnPedidoTable();
                break;
            case "8":
                returnPedidoEdit();
                break;
            case "9":
                updateOrden();
                break;
            case "10":
                returnTotal();
                break;
            case "11":
                makeOrden();
                break;
            case "12":
                consultaSolicitudAdm();
                break;
            case "13":
                consultaSolicitudUsuario();
                break;
            case "14":
                consultaNumeroSolicitudAdm();
                break;
            case "15":
                consultaNumeroSolicitudUsuario();
                break;
            case "16":
                consultaReservacionAdm();
                break;
            case "17":
                consultaReservacionUsuario();
                break;
            case "18":
                actualizaReservacion();
                break;
            case "19":
                consultaCategorias();
                break;
            case "20":
                consultaSubcategorias();
                break;
            case "21":
                consultaProducto();
                break;
            case "22":
                consultaPaquete();
                break;
            case "23":
                insertOrdenDetalleProducto();
                break;
            case "24":
                consultaSubPaquete();
                break;
            case "25":
                consultaCategoriaNombre();
                break;
            case "26":
                consultaSubCategoriaNombre();
                break;
            case "27":
                consultaProductoNombre();
                break;
            case "28":
                consultaExtraNombre();
                break;
            case "29":
                consultaPrecioUnitarioProducto();
                break;
            case "30":
                insertOrdenDetallePaquete();
                break;
            case "31":
                consultaProductoPaquete();
                break;
            case "32":
                consultaPreorden();
                break;
            case "33":
                actualizaPreordenPaquete();
                break;
            case "34":
                finalizarPedido();
                break;
            case "35":
                actualizaFinalizarPedido();
                break;
            case "36":
                consultaPedidoAdm();
                break;
            case "37":
                estatusPedidoDomicilio();
                break;
            case "38":
                consultaPedidoUsuario();
                break;
        }
    }
    /*-------------------------------------------------FUNCIONES---------------------------------------------------------
     -------------------------------------------------------------------------------------------------------------------*/
    protected void returnMenu() {
        string categoria = string.Empty, usuario = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        categoria = Request["categoria"];
        Response.ContentType = "application/json; charset=utf-8";
        json = returnMenuSearch(usuario,categoria);
        Response.Write(json);
    }
    protected void returnName() {
        string usuario = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        json = returnNameSearch(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void doReservacion()
    {
        string usuario = string.Empty, nombre = string.Empty, coment = string.Empty;
        int hora = 0, minuto = 0, personas = 0;
        DateTime fecha = DateTime.Now, fecha2;
        usuario = Request["usuario"];
        nombre = Request["nombre"];
        hora = Convert.ToInt32(Request["hora"]);
        minuto = Convert.ToInt32(Request["minuto"]);
        personas = Convert.ToInt32(Request["personas"]);
        coment = Request["comentario"]; 
        fecha2 = new DateTime(fecha.Year, fecha.Month, fecha.Day, hora, minuto, 0);
        insertReservacion(usuario, nombre, fecha2, personas, coment);
        Response.Write("True");

    }
    protected void doReservacion2()
    {
        string usuario = string.Empty, nombre = string.Empty, coment = string.Empty, horas = string.Empty;
        int personas = 0;
        DateTime fecha = DateTime.Now, fecha2, fecha3 = DateTime.Now;
        usuario = Request["usuario"];
        nombre = Request["nombre"];
        fecha = Convert.ToDateTime(Request["fecha"], new CultureInfo("es-MX"));
        fecha3 = Convert.ToDateTime(Request["horas"]); 
        personas = Convert.ToInt32(Request["personas"]);
        coment = Request["comentario"];
        fecha2 = new DateTime(fecha.Year, fecha.Month, fecha.Day, fecha3.Hour, fecha3.Minute, 0);
        insertReservacion(usuario, nombre, fecha2, personas, coment);
        Response.Write("True");

    }
    protected void returnMenuPedido() {
        string usuario = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        List<PedidoDomicilio> pedidoDom = new List<PedidoDomicilio>();
        for (int i = 0; i < 3; i++) {
            PedidoDomicilio ped = new PedidoDomicilio();
            if (i == 0)
            {
                ped.Categoria = "Sopa";
                ped.Productos = returnProductos(usuario, "Sopa");
            }
            else if (i == 1) {
                ped.Categoria = "Plato Fuerte";
                ped.Productos = returnProductos(usuario, "Plato Fuerte");
            }
            else if (i == 2)
            {
                ped.Categoria = "Aguas";
                ped.Productos = returnProductos(usuario, "Aguas");
            }
            pedidoDom.Add(ped);
        }
        Response.ContentType = "application/json; charset=utf-8";
        json = JsonConvert.SerializeObject(pedidoDom);
        Response.Write(json);
    }
    protected void insertPedidoFirst() {
        string usuario = string.Empty, nombre = string.Empty, domicilio=string.Empty, tel = string.Empty, tipo = string.Empty;
        DateTime fecha = DateTime.Today;
        usuario = Request["usuario"];
        nombre = Request["nombre"];
        domicilio = Request["domicilio"];
        tel = Request["telefono"];
        tipo = Request["tipo"];
        if(tipo =="Nuevo")
            insertPedidoFirstSQL(usuario, nombre, domicilio,tel,fecha, "Nuevo");
        else
            insertPedidoFirstSQL(usuario, nombre, domicilio, tel, fecha, "Registrado");
        Response.Write("True");
    }
    protected void insertPedidoDetail() {
        string usuario = string.Empty, sopa = string.Empty, plat = string.Empty, agua = string.Empty, comentario = string.Empty;
        DateTime fecha = DateTime.Now;
        usuario = Request["usuario"];
        sopa = Request["sopa"];
        plat = Request["plato"];
        agua = Request["agua"];
        comentario = Request["comentario"];
        insertPedidoDetailSQL(usuario,sopa,plat,agua,comentario,fecha);
        Response.Write("True");
    }
    protected void returnPedidoTable() {
        string usuario = string.Empty, json = string.Empty ;
        usuario = Request["usuario"];
        json = returnPedidoTableSQL(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void returnPedidoEdit() {
        string usuario = string.Empty, json = string.Empty;
        int id = 0;
        DateTime fecha = DateTime.Today;
        usuario = Request["usuario"];
        id = Convert.ToInt32(Request["id"]);
        List<PedidoDomicilio> pedidoDom = new List<PedidoDomicilio>();
        for (int i = 0; i < 3; i++)
        {
            PedidoDomicilio ped = new PedidoDomicilio();
            if (i == 0)
            {
                List<Producto> prodi = new List<Producto>();
                prodi.Add(returnProductCatergorySQL(id, "IDSopa"));
                prodi.AddRange(returnProductosExcept(usuario, id, "Sopa", "IDSopa"));
                ped.Productos = prodi;
                ped.Categoria = "Sopa";
                ped.Comentario = returnComment(id);
            }
            else if (i == 1)
            {
                List<Producto> prodi = new List<Producto>();
                prodi.Add(returnProductCatergorySQL(id, "IDPlato"));
                prodi.AddRange(returnProductosExcept(usuario, id, "Plato Fuerte", "IDPlato"));
                ped.Productos = prodi;
                ped.Categoria = "Plato Fuerte";
                ped.Comentario = returnComment(id);
            }
            else if (i == 2)
            {
                List<Producto> prodi = new List<Producto>();
                prodi.Add(returnProductCatergorySQL(id, "IDAgua"));
                prodi.AddRange(returnProductosExcept(usuario, id, "Aguas", "IDAgua"));
                ped.Productos = prodi;
                ped.Categoria = "Aguas";
                ped.Comentario = returnComment(id);
            }
            pedidoDom.Add(ped);
        }
        Response.ContentType = "application/json; charset=utf-8";
        json = JsonConvert.SerializeObject(pedidoDom);
        Response.Write(json);
    }
    protected void updateOrden() {
        string sopa = string.Empty, usuario = string.Empty, plato = string.Empty, agua = string.Empty, nota = string.Empty;
        int id = 0;
        id = Convert.ToInt32(Request["id"]);
        usuario = Request["usuario"];
        sopa = Request["sopa"];
        plato = Request["plato"];
        agua = Request["agua"];
        nota = Request["nota"];
        updatePedidoSQL(id,usuario, sopa,plato, agua, nota);
        Response.Write("True");
    }
    protected void returnTotal() {
        string usuario = string.Empty, json = string.Empty;
        DateTime fecha = DateTime.Today;
        usuario = Request["usuario"];
        Response.ContentType = "application/json; charset=utf-8";
        json = returnOrdenAll(usuario, fecha);
        Response.Write(json);
    }
    protected void makeOrden() {
        string usuario = string.Empty;
        int total = 0;
        usuario = Request["usuario"];
        total = Convert.ToInt32(Request["total"]);
        updateTotal(usuario, total);
        Response.Write("True");
    }
    protected void consultaNumeroSolicitudAdm() {
        string usuario = string.Empty, res = string.Empty;
        usuario = Request["usuario"];
        res = consultaNumeroSolicitudAdmSQL(usuario);
        Response.Write(res);
    }
    protected void consultaNumeroSolicitudUsuario() {
        string usuario = string.Empty, res = string.Empty;
        usuario = Request["usuario"];
        res = consultaNumeroSolicitudUsuarioSQL(usuario);
        Response.Write(res);
    }
    protected void consultaSolicitudAdm() {
        string usuario = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        json = consultaSolicitudAdmSQL(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void consultaSolicitudUsuario() {
       
    }
    protected void consultaReservacionAdm() {
        string usuario = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        json = consultaReservacionAdmSQL(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void consultaReservacionUsuario() {
        string usuario = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        json = consultaReservacionUsuarioSQL(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void actualizaReservacion()
    {
        string ID = string.Empty, estatus = string.Empty;
        ID = Request["ID"];
        estatus = Request["estatus"];
        actualizaReservacionSQL( ID, estatus);
        Response.Write(estatus);
    }
    protected void consultaCategorias() {
        string usuario = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        json = consultarCategoriasSQL(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void consultaCategoriaNombre() {
        string usuario = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        json = consultarCategoriasNombreSQL(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void consultaSubcategorias() {
        string usuario = string.Empty, json = string.Empty;
        int cat = 0;
        usuario = Request["usuario"];
        cat = Convert.ToInt32(Request["categoria"]);
        json = consultaSubCategoriasSQL(usuario, cat);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void consultaSubCategoriaNombre() {
        string usuario = string.Empty, cat = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        cat = Request["cat"];
        json = consultaSubCategoriasNombreSQL(usuario, cat);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void consultaProducto() {
        string usuario = string.Empty, json = string.Empty;
        int sub = 0;
        sub = Convert.ToInt32(Request["id"]);
        json = consultaProductoSQL(sub);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void consultaProductoNombre() {
        string usuario = string.Empty, json = string.Empty, cat = string.Empty, sub = string.Empty;
        usuario = Request["usuario"];
        cat = Request["cat"];
        sub = Request["sub"];
        json = consultarProductosNombreSQL(usuario, cat, sub);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void consultaPaquete() {
        string usuario = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        json = consultaPaqueteSQL(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void consultaSubPaquete() {
        string id = string.Empty, json = string.Empty;
        id = Request["id"];
        json = consultaSubPaqueteSQL(id);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void insertOrdenDetalleProducto() {
        string usuario = string.Empty, cat = string.Empty, sub = string.Empty, prod=string.Empty, comen = string.Empty;
        usuario = Request["usuario"];
        cat = Request["cat"];
        sub = Request["sub"];
        prod = Request["prod"];
        comen = Request["com"];
        insertOrdenDetalleProductoSQL(usuario, cat, sub, prod, comen);
        Response.Write("True");
    }
    protected void consultaExtraNombre() {
        string usuario = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        json = consultaExtraNombreSQL(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void consultaPrecioUnitarioProducto() {
        string usuario = string.Empty, cat = string.Empty, sub = string.Empty, prod = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        cat = Request["cat"];
        sub = Request["sub"];
        prod = Request["prod"];
        json = consultaPrecioUnitarioSQL(usuario, cat, sub, prod);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void insertOrdenDetallePaquete() {
        string usuario = string.Empty, comen = string.Empty;
        int paq = 0, prod = 0;
        usuario = Request["usuario"];
        paq = Convert.ToInt32(Request["paq"]);
        prod = Convert.ToInt32(Request["prod"]);
        comen = Request["comen"];
        insertOrdenDetallePaqueteSQL(usuario, paq);
        insertOrdenDetallePaqueteProductoSQL(usuario, paq, prod, comen);
        Response.Write("True");
    }
    protected void consultaProductoPaquete() {
        string json = string.Empty;
        int sub = 0, id = 0;
        id = Convert.ToInt32(Request["id"]);
        sub = Convert.ToInt32(Request["sub"]);
        json = consultaProductoPaqueteSQL(id, sub);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void consultaPreorden() {
        string usuario = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        json = consultaPreordenSQL(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void actualizaPreordenPaquete() {
        string usuario = string.Empty;
        int id = 0;
        usuario = Request["usuario"];
        id = Convert.ToInt32(Request["id"]);
        actualizaPreordenPaqueteSQL(usuario, id);
        Response.Write("True");
    }
    protected void finalizarPedido() {
        string usuario = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        json = finalizaPedidoSQL(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void actualizaFinalizarPedido() {
        string usuario = string.Empty;
        int id = 0;
        float total = 0;
        usuario = Request["usuario"];
        id = Convert.ToInt32(Request["id"]);
        total = Convert.ToInt64(Request["total"]);
        actualizaFinalizarPedidoSQL(usuario, id, total);
        Response.Write("True");
    }
    protected void consultaPedidoAdm() {
        string json = string.Empty;
        int id = 0;
        id = Convert.ToInt32(Request["id"]);
        json = consultaPedidoAdmSQL(id);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void estatusPedidoDomicilio() {
        int id = 0;
        string estatus = string.Empty;
        id = Convert.ToInt32(Request["id"]);
        estatus = Request["estatus"];
        if (estatus == "Confirmado")
            estatus = "En preparación";
        else
            estatus = "Rechazado";
        estatusPedidoDomicilioSQL(id, estatus);
        Response.Write("True");
    }
    protected void consultaPedidoUsuario() {
        string usuario = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        json = consultaPedidoUsuarioSQL(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }

    /*-------------------------------------------------SQL----------------------------------------------------------------
     -------------------------------------------------------------------------------------------------------------------*/
    protected string returnMenuSearch(string usuario, string categoria) {
        string json = string.Empty;
        DateTime fecha = DateTime.Today;
        List<Producto> produc = new List<Producto>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select Nombre, Descripcion from Productos where Categoria = @categoria and " +
            "Sitio = (select Sitio from UsuarioRestaurant where Usuario = @usuario)", con);
            //"and Fecha = @fecha", con);
        cmd.Parameters.AddWithValue("@categoria",categoria);
        cmd.Parameters.AddWithValue("@usuario",usuario);
        cmd.Parameters.AddWithValue("@fecha",fecha);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            Producto p = new Producto();
            p.Nombre = Convert.ToString(dr[0]);
            p.Descripcion = Convert.ToString(dr[1]);
            produc.Add(p);
        }
        con.Close();
        json = JsonConvert.SerializeObject(produc);
        return json;
    }
    protected void insertReservacion(string usuario, string nombre, DateTime fecha, int personas, string comentario) {
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into Reservacion (IDUSuario, Nombre, Fecha, Personas, Comentario, Estatus) values" +
            "((select ID from UsuarioRestaurant where Usuario = @usuario),@nombre, @fecha, @personas, @comen, 'En Espera')",con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@nombre", nombre);
        cmd.Parameters.AddWithValue("@fecha", fecha);
        cmd.Parameters.AddWithValue("@comen", comentario);
        cmd.Parameters.AddWithValue("@personas",personas);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected string returnNameSearch(string usuario) {
        string json = string.Empty;
        DateTime fecha = DateTime.Today;
        con.Open();
        DatosReservacion datos = new DatosReservacion();
        SqlCommand cmd = new SqlCommand("if(select COUNT(ID) from PedidoDomicilio where IDUsuario = " +
            "(select ID from UsuarioRestaurant where Usuario = @usuario) and Fecha = @fecha and Estatus = 'Ordenando') = 1 " +
            "begin select 'Registrado', Nombre, Domicilio, Telefono from PedidoDomicilio where " +
            "IDUsuario = (select ID from UsuarioRestaurant where Usuario = @usuario) and Fecha = @fecha " +
            "end else begin select 'Nuevo', ur.Nombre, ur.ApePat, ur.Direccion, ur.Telefono from " +
            "UsuarioRestaurant ur where ur.Usuario = @usuario end ",con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@fecha", fecha);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            if (Convert.ToString(dr[0]) == "Registrado")
            {
                datos.tipoDatos = Convert.ToString(dr[0]);
                datos.NombrePersona = Convert.ToString(dr[1]);
                datos.direccion = Convert.ToString(dr[2]);
                datos.telefono = Convert.ToString(dr[3]);
            }
            else {
                datos.tipoDatos = Convert.ToString(dr[0]);
                datos.NombrePersona = Convert.ToString(dr[1]) + " " + Convert.ToString(dr[2]);
                datos.direccion = Convert.ToString(dr[3]);
                datos.telefono = Convert.ToString(dr[4]);
                //datos.Restaurant = Convert.ToString(dr[3]);
            }
        }
        con.Close();
        json = JsonConvert.SerializeObject(datos);
        return json;
    }
    protected string returnPedidoTableSQL(string usuario) {
        string json = string.Empty;
        List<Orden> listOrden = new List<Orden>();
        DateTime fecha = DateTime.Today;
        con.Open();
        SqlCommand cmd = new SqlCommand("select pd.ID, p.Nombre as Sopa, p1.Nombre as Plato, p2.Nombre as Agua from " +
            "PedidoDetalle pd inner join Productos p on pd.IDSopa = p.ID inner join Productos p1 on pd.IDPlato = " +
            "p1.ID inner join Productos p2 on pd.IDAgua = p2.ID inner join PedidoDomicilio pd1 on pd1.ID = " +
            "pd.IDPedido where pd1.Estatus = 'Ordenando' and pd1.Fecha = @fecha and pd1.IDUsuario = " +
            "(select ID from UsuarioRestaurant where Usuario = @usuario)", con);
        cmd.Parameters.AddWithValue("@fecha",fecha);
        cmd.Parameters.AddWithValue("@usuario",usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            Orden orden = new Orden();
            orden.IDOrden = Convert.ToInt32(dr[0]);
            orden.pedido = Convert.ToString(dr[1])+", "+ Convert.ToString(dr[2])+" y agua de "+Convert.ToString(dr[3]);
            listOrden.Add(orden);
        }
        con.Close();
        json = JsonConvert.SerializeObject(listOrden);
        return json;
    }
    protected List<Producto> returnProductos(string usuario, string categoria) {
        List<Producto> productList = new List<Producto>();
        DateTime fecha = DateTime.Today;
        con.Open();
        SqlCommand cmd = new SqlCommand("select Nombre from Productos where Categoria = @categoria and Sitio = " +
            "(select Sitio from UsuarioRestaurant where Usuario = @usuario) and Fecha = @fecha", con);
        cmd.Parameters.AddWithValue("@categoria", categoria);
        cmd.Parameters.AddWithValue("@usuario",usuario);
        cmd.Parameters.AddWithValue("@fecha",fecha);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            Producto producto = new Producto();
            producto.Nombre = Convert.ToString(dr[0]);
            productList.Add(producto);
        }
        con.Close();
        return productList;
    }
    protected List<Producto> returnProductosExcept(string usuario, int id, string categoria, string cat) {
        List<Producto> productList = new List<Producto>();
        con.Open();
        DateTime fecha = DateTime.Today;
        SqlCommand cmd = new SqlCommand("select Nombre from Productos where Categoria = @categoria and Sitio = " +
            "(select Sitio from UsuarioRestaurant where Usuario = @usuario) except(select Nombre from " +
            "Productos where ID = (select "+cat+" from PedidoDetalle where ID = @id)) and Fecha = @fecha", con);
        cmd.Parameters.AddWithValue("@categoria", categoria);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@fecha",fecha);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Producto producto = new Producto();
            producto.Nombre = Convert.ToString(dr[0]);
            productList.Add(producto);
        }
        con.Close();
        return productList;
    }
    protected void insertPedidoFirstSQL(string usuario, string nombre, string domicilio, string telefono, DateTime fecha, string tipo) {
        con.Open();
        SqlCommand cmd;
        if (tipo == "Nuevo")
            cmd = new SqlCommand("insert into PedidoDomicilio (IDUsuario, Nombre, Domicilio, Telefono, Fecha, Estatus)" +
               " values((select ID from UsuarioRestaurant where Usuario =@usuario), @nombre, @domicilio, @telefono, @fecha,'Ordenando')", con);
        else {
            cmd = new SqlCommand("update PedidoDomicilio set Nombre = @nombre, Domicilio = @domicilio, " +
                "Telefono = @telefono where IDUsuario = (select ID from UsuarioRestaurant where Usuario = @usuario) " +
                "and Fecha = @fecha and Estatus = 'Ordenando'",con);
        }
        cmd.Parameters.AddWithValue("@usuario",usuario);
        cmd.Parameters.AddWithValue("@nombre",nombre);
        cmd.Parameters.AddWithValue("@domicilio",domicilio);
        cmd.Parameters.AddWithValue("@telefono",telefono);
        cmd.Parameters.AddWithValue("@fecha",fecha);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void insertPedidoDetailSQL(string usuario, string sopa, string plato, string agua, string comentario, DateTime fecha) {
        con.Open();
        fecha = DateTime.Today;
        //Response.Write(usuario);
        SqlCommand cmd = new SqlCommand("insert into pedidoDetalle (IDPedido, IDSopa, IDPlato, IDAgua, Comentarios) values " +
            "((select top 1 ID from PedidoDomicilio where IDUsuario = (select ID from UsuarioRestaurant where Usuario = @usuario) " +
            "and Estatus = 'Ordenando' and Fecha = @fecha order by ID desc), (select ID from Productos where Nombre = @sopa and Sitio = " +
            "(select Sitio from UsuarioRestaurant where Usuario = @usuario)), (select ID from Productos where Nombre = @plato " +
            "and Sitio = (select Sitio from UsuarioRestaurant where Usuario = @usuario)),(select ID from Productos where Nombre = " +
            "@agua and Sitio = (select Sitio from UsuarioRestaurant where Usuario = @usuario)), @comentario)",con);
        cmd.Parameters.AddWithValue("@usuario",usuario);
        cmd.Parameters.AddWithValue("@sopa", sopa);
        cmd.Parameters.AddWithValue("@plato",plato);
        cmd.Parameters.AddWithValue("@agua",agua);
        cmd.Parameters.AddWithValue("@comentario",comentario);
        cmd.Parameters.AddWithValue("@fecha",fecha);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected Producto returnProductCatergorySQL(int id, string categoria) {
        Producto prod = new Producto();
        con.Open();
        SqlCommand cmd = new SqlCommand("select Nombre from Productos where ID=(select "+categoria+" from " +
            "PedidoDetalle where ID=@id)", con);
        cmd.Parameters.AddWithValue("@id",id);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
            prod.Nombre = Convert.ToString(dr[0]);
        con.Close();
        return prod;
    }
    protected string returnComment(int id) {
        string comentario = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select comentarios from pedidoDetalle where ID = @id",con);
        cmd.Parameters.AddWithValue("@id",id);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
            comentario = Convert.ToString(dr[0]);
        con.Close();
        return comentario;
    }
    protected void updatePedidoSQL(int id, string usuario, string sopa, string plato, string agua, string comentario) {
        con.Open();
        SqlCommand cmd = new SqlCommand("update PedidoDetalle set IDSopa = (select ID from Productos where Nombre = " +
            "@sopa and Sitio = (select Sitio from UsuarioRestaurant where Usuario = @usuario)), IDPlato = " +
            "(select ID from Productos where Nombre = @plato and Sitio = (select Sitio from UsuarioRestaurant " +
            "where Usuario = @usuario)), IDAgua = (select ID from Productos where Nombre = @agua and Sitio = " +
            "(select Sitio from UsuarioRestaurant where Usuario = @usuario)), Comentarios = @comentario where ID = @id",con);
        cmd.Parameters.AddWithValue("@id",id);
        cmd.Parameters.AddWithValue("@sopa", sopa);
        cmd.Parameters.AddWithValue("@plato",plato);
        cmd.Parameters.AddWithValue("@agua", agua);
        cmd.Parameters.AddWithValue("@comentario", comentario);
        cmd.Parameters.AddWithValue("@usuario",usuario);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected string returnOrdenAll(string usuario, DateTime fecha) {
        string json = string.Empty;
        DatosReservacion datos = new DatosReservacion();
        con.Open();
        SqlCommand cmd = new SqlCommand("select pd.ID, pd.Nombre, pd.Domicilio, pd.Telefono, pd.Fecha, a1.Cuenta, Costos.Costo, Costos.Servicio," +
            "(a1.cuenta * Costos.Costo + Costos.Servicio) as Total from PedidoDomicilio pd,  " +
            "(select COUNT(ID) as cuenta from PedidoDetalle where IDPedido = (select top 1 ID from PedidoDomicilio where " +
            "IDUsuario = (select ID from UsuarioRestaurant where Usuario = @usuario) and Estatus = 'Ordenando' order by ID desc)) as a1, " +
            "(select v1.ValorVariable as Costo, v2.ValorVariable as Servicio from VariablesRestaurant v1, " +
            "VariablesRestaurant v2 where((v1.TipoVariable = 'CostoComida' and v2.TipoVariable = 'CostoServicioDom') " +
            "and v1.Sitio = v2.Sitio and v1.Sitio = (select Sitio from UsuarioRestaurant where Usuario = @usuario))) as " +
            "Costos where pd.IDUsuario = (select ID from UsuarioRestaurant where Usuario = @usuario) and " +
            "pd.Fecha = @fecha and pd.Estatus = 'Ordenando'",con);
        cmd.Parameters.AddWithValue("@usuario",usuario);
        cmd.Parameters.AddWithValue("@fecha",fecha);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            DateTime aux = DateTime.Today;
            datos.IDOrdenPedido = Convert.ToInt32(dr[0]);
            datos.NombrePersona = Convert.ToString(dr[1]);
            datos.direccion = Convert.ToString(dr[2]);
            datos.telefono = Convert.ToString(dr[3]);
            datos.fechaPedido = Convert.ToString(dr[4]);
            aux = Convert.ToDateTime(dr[4]);
            datos.fechaPedido = aux.ToString("dd/MM/yyyy");
            datos.totalOrdenes = Convert.ToInt32(dr[5]);
            datos.costoUnitario = Convert.ToInt32(dr[6]);
            datos.costoDomicilio = Convert.ToInt32(dr[7]);
            datos.total = Convert.ToInt32(dr[8]);
        }
        con.Close();
        json = JsonConvert.SerializeObject(datos);
        return json;
    }
    protected void updateTotal(string usuario, int total) {
        DateTime fecha = DateTime.Today;
        con.Open();
        SqlCommand cmd = new SqlCommand("update pedidoDomicilio set Estatus = 'En Espera', Total = @total where IDUsuario = " +
            "(select ID from UsuarioRestaurant where Usuario = @usuario) and Fecha = @fecha and Estatus = 'Ordenando'",con);
        cmd.Parameters.AddWithValue("@usuario",usuario);
        cmd.Parameters.AddWithValue("@total",total);
        cmd.Parameters.AddWithValue("@fecha",fecha);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected string consultaNumeroSolicitudAdmSQL(string usuario) {
        string numero = string.Empty;
        numero = "0";
        con.Open();
        SqlCommand cmd = new SqlCommand("select COUNT(ID) from Reservacion where IDUsuario in (select ID from " +
            "UsuarioRestaurant where Sitio = (select C_Sitio from AspNetUsers where UserName = @usuario)) and Estatus = 'En Espera'",con);
        cmd.Parameters.AddWithValue("@usuario",usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            numero = Convert.ToString(dr[0]);
        }
        con.Close();
        return numero;
    }
    protected string consultaNumeroSolicitudUsuarioSQL(string usuario) {
        string numero = string.Empty;
        numero = "0";
        con.Open();
        SqlCommand cmd = new SqlCommand("select COUNT(ID) from Reservacion where IDUsuario = (select ID from " +
            "UsuarioRestaurant where Usuario = @usuario)",con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            numero = Convert.ToString(dr[0]);
        }
        con.Close();
        return numero;
    }
    protected string consultaReservacionAdmSQL(string usuario)
    {
        con.Open();
        List<NotificacionesAdm> notificacion = new List<NotificacionesAdm>();
        string json = string.Empty;
        SqlCommand cmd = new SqlCommand("select r.ID, ur.Usuario, r.Fecha, r.Personas, r.Comentario, r.Estatus from Reservacion r " +
            "inner join UsuarioRestaurant ur on r.IDUsuario = ur.ID where ur.Sitio = (select C_Sitio from " +
            "AspNetUsers where UserName = @usuario) and Estatus = 'En Espera' ", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            NotificacionesAdm noti = new NotificacionesAdm();
            noti.ID = Convert.ToInt32(dr["ID"]);
            noti.Usuario = Convert.ToString(dr["Usuario"]);
            DateTime temporal = Convert.ToDateTime(dr["Fecha"]);
            noti.Fecha = temporal.ToString("dd/mm/yyyy HH:mm");
            noti.Personas = Convert.ToInt32(dr["Personas"]);
            noti.Nota = Convert.ToString(dr["Comentario"]);
            noti.Estatus = Convert.ToString(dr["Estatus"]);
            notificacion.Add(noti);
        }
        con.Close();
        json = JsonConvert.SerializeObject(notificacion);
        return json;
    }
    protected string consultaReservacionUsuarioSQL(string usuario)
    {
        con.Open();
        List<NotificacionesUsuario> notificacion = new List<NotificacionesUsuario>();
        string json = string.Empty;
        SqlCommand cmd = new SqlCommand("select r.ID, r.Fecha, r.Personas ,r.Estatus from Reservacion r where " +
            "IDUsuario = (select ID from UsuarioRestaurant where Usuario = @usuario)", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            NotificacionesUsuario noti = new NotificacionesUsuario();
            noti.ID = Convert.ToInt32(dr["ID"]);
            DateTime temporal = Convert.ToDateTime(dr["Fecha"]);
            noti.Fecha = temporal.ToString("dd/MM/yyyy HH:mm");
            noti.Personas = Convert.ToInt32(dr["Personas"]);
            noti.Estatus = Convert.ToString(dr["Estatus"]);
            notificacion.Add(noti);
        }
        con.Close();
        json = JsonConvert.SerializeObject(notificacion);
        return json;
    }
    protected void actualizaReservacionSQL( string id, string estatus)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("update Reservacion set estatus = @estatus where ID = @id", con);
        cmd.Parameters.AddWithValue("@estatus", estatus);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected string consultarCategoriasSQL(string usuario)
    {
        string json = string.Empty;
        con.Open();
        List<categoria> cat = new List<categoria>();
        SqlCommand cmd = new SqlCommand("select c.ID, c.NombreCategoria, ri.Icono from Categoria c inner join RepoIconos " +
            "ri on ri.ID=c.Icono where c.Sitio = (select Sitio from UsuarioRestaurant where Usuario = @usuario) order" +
            " by c.Orden", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            categoria ca = new categoria();
            byte[] icon;
            object result = dr[2];
            icon = (byte[])result;
            ca.nombreCategoria = Convert.ToString(dr[1]);
            ca.IDCategoria = Convert.ToInt32(dr[0]);
            ca.iconoCategoria = Convert.ToBase64String(icon);
            cat.Add(ca);
        }
        con.Close();
        json = JsonConvert.SerializeObject(cat);
        return json;
    }
    protected string consultarCategoriasNombreSQL(string usuario)
    {
        string json = string.Empty;
        con.Open();
        List<Producto> cat = new List<Producto>();
        SqlCommand cmd = new SqlCommand("select NombreCategoria from Categoria where Sitio = (select Sitio from " +
            "UsuarioRestaurant where Usuario = @usuario) order by Orden", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Producto ca = new Producto();
            ca.Nombre = Convert.ToString(dr[0]);
            cat.Add(ca);
        }
        con.Close();
        json = JsonConvert.SerializeObject(cat);
        return json;
    }
    protected string consultaSubCategoriasSQL(string usuario, int id) {
        string json = string.Empty;
        con.Open();
        List<categoria> cat = new List<categoria>();
        SqlCommand cmd = new SqlCommand("select sc.ID, sc.NombreSub, ri.Icono from Subcategoria sc inner join Categoria c on " +
            "sc.ID_Categoria = c.ID inner join RepoIconos ri on ri.ID = sc.Icono where sc.ID_Categoria = " +
            "@categoria and  c.Sitio = (select Sitio from UsuarioRestaurant where Usuario = @usuario) order by sc.Orden", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@categoria", id);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            categoria ca = new categoria();
            byte[] icon;
            object result = dr[2];
            icon = (byte[])result;
            ca.nombreCategoria = Convert.ToString(dr[1]);
            ca.IDCategoria = Convert.ToInt32(dr[0]);
            ca.iconoCategoria = Convert.ToBase64String(icon);
            cat.Add(ca);
        }
        con.Close();
        json = JsonConvert.SerializeObject(cat);
        return json;
    }
    protected string consultaSubCategoriasNombreSQL(string usuario, string cate)
    {
        string json = string.Empty;
        con.Open();
        List<Producto> cat = new List<Producto>();
        SqlCommand cmd = new SqlCommand("select NombreSub from SubCategoria where ID_Categoria=(select ID from " +
            "Categoria where NombreCategoria = @cate and Sitio = (select Sitio from UsuarioRestaurant where Usuario = @usuario)) order by Orden", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@cate", cate);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Producto ca = new Producto();
            ca.Nombre = Convert.ToString(dr[0]);
            cat.Add(ca);
        }
        con.Close();
        json = JsonConvert.SerializeObject(cat);
        return json;
    }
    protected string consultaProductoSQL(int id) {
        string json = string.Empty;
        List<Producto2> produ = new List<Producto2>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select ID, Nombre, Descripcion, Tamaño, Precio from Producto where ID_Sub = @id",con);
        cmd.Parameters.AddWithValue("@id",id);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            Producto2 prod = new Producto2();
            prod.ID = Convert.ToInt32(dr["ID"]);
            prod.Nombre = Convert.ToString(dr["Nombre"]);
            prod.Desc = Convert.ToString(dr["Descripcion"]);
            prod.Tamaño = Convert.ToString(dr["Tamaño"]);
            prod.Precio = Convert.ToInt64(dr["Precio"]);
            produ.Add(prod);
        }
        con.Close();
        json = JsonConvert.SerializeObject(produ);
        return json;
    }
    protected string consultaProductoPaqueteSQL(int id, int sub)
    {
        string json = string.Empty;
        List<Producto2> produ = new List<Producto2>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select p.ID, p.Nombre from Producto p inner join ProductoPaquete pp on p.ID = " +
            "pp.ID_Producto inner join SubCategoria sc on sc.ID = p.ID_Sub where pp.ID_Paquete = @id and sc.ID = @sub", con);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@sub",sub);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Producto2 prod = new Producto2();
            prod.ID = Convert.ToInt32(dr["ID"]);
            prod.Nombre = Convert.ToString(dr["Nombre"]);
            produ.Add(prod);
        }
        con.Close();
        json = JsonConvert.SerializeObject(produ);
        return json;
    }
    protected string consultaPaqueteSQL(string usuario) {
        string json = string.Empty;
        List<Paquete> paq = new List<Paquete>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select ID, Nombre, Precio from Paquete where ID_Sitio = (select Sitio from" +
            " UsuarioRestaurant where Usuario = @usuario)", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Paquete prod = new Paquete();
            prod.ID = Convert.ToInt32(dr["ID"]);
            prod.Nombre = Convert.ToString(dr["Nombre"]);
            prod.Precio = Convert.ToInt64(dr["Precio"]);
            prod.Opciones = consultaOpciones(prod.ID);
            paq.Add(prod);
        }
        con.Close();
        json = JsonConvert.SerializeObject(paq);
        return json;
    }
    protected string consultaOpciones(int id) {
        string opciones = string.Empty;
        SqlCommand cmd = new SqlCommand("select ', '+ p.Nombre from ProductoPaquete pp inner join Producto p on p." +
            "ID=pp.ID_Producto where pp.ID_Paquete = @id union(select ', ' + e.Nombre from ExtraPaquete ep inner " +
            "join Paquete p on p.ID = ep.ID_Paquete inner join Extra e on e.ID = ep.ID_Extra where " +
            "ep.ID_Paquete = @id) for xml path ('')");
        cmd.Parameters.AddWithValue("@id",id);
        DBIOT db = new DBIOT();
        opciones = db.consultaUnDato(cmd);
        if(opciones.Length>0)
        opciones = opciones.Substring(1,opciones.Length-1);
        return opciones;
    }
    protected string consultaSubPaqueteSQL(string id) {
        string res = string.Empty;
        con.Open();
        List<Categ> cat = new List<Categ>();
        SqlCommand cmd = new SqlCommand("select sc.ID, sc.NombreSub from SubCategoria sc inner join " +
            "Producto p on sc.ID = p.ID_Sub inner join ProductoPaquete pp on p.ID = pp.ID_Producto where pp.ID_Paquete = @id " +
            "group by sc.NombreSub, sc.Orden, sc.ID order by sc.Orden", con);
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            Categ c = new Categ();
            c.ID = Convert.ToInt32(dr["ID"]);
            c.Nombre = Convert.ToString(dr["NombreSub"]);
            cat.Add(c);
        }
        res = JsonConvert.SerializeObject(cat);
        con.Close();
        return res;
    }
    protected string consultarProductosNombreSQL(string usuario, string cat, string sub) {
        string json = string.Empty;
        con.Open();
        List<Producto2> pro = new List<Producto2>();
        SqlCommand cmd = new SqlCommand("select Nombre, Precio from Producto where ID_Sub = (select ID from SubCategoria" +
            " where NombreSub = @sub and ID_Categoria = (select ID from Categoria where NombreCategoria = @cat and" +
            " Sitio = (select Sitio from UsuarioRestaurant where Usuario = @usuario)))", con);
        cmd.Parameters.AddWithValue("@sub",sub);
        cmd.Parameters.AddWithValue("@cat",cat);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            Producto2 pr = new Producto2();
            pr.Nombre = Convert.ToString(dr["Nombre"]);
            pr.Precio = Convert.ToInt64(dr["Precio"]);
            pro.Add(pr);
        }
        con.Close();
        json = JsonConvert.SerializeObject(pro);
        return json;
    }
    protected string consultaPrecioUnitarioSQL(string usuario, string cat, string sub, string prod) {
        string json = string.Empty;
        con.Open();
        Producto2 pro = new Producto2();
        SqlCommand cmd = new SqlCommand("select Precio from Producto where Nombre=@nombre and ID_Sub = (select ID from SubCategoria" +
            " where NombreSub = @sub and ID_Categoria = (select ID from Categoria where NombreCategoria = @cat and" +
            " Sitio = (select Sitio from UsuarioRestaurant where Usuario = @usuario)))", con);
        cmd.Parameters.AddWithValue("@sub", sub);
        cmd.Parameters.AddWithValue("@cat", cat);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@nombre",prod);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            pro.Precio = Convert.ToInt64(dr["Precio"]);
        }
        con.Close();
        json = JsonConvert.SerializeObject(pro);
        return json;
    }
    protected string consultaExtraNombreSQL(string usuario) {
        string json = string.Empty;
        con.Open();
        List<Producto> pr = new List<Producto>();
        SqlCommand cmd = new SqlCommand("select nombre from Extra where ID_Sitio = (select Sitio from UsuarioRestaurant " +
            "where Usuario = @usuario)",con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            Producto p = new Producto();
            p.Nombre = Convert.ToString(dr["nombre"]);
            pr.Add(p);
        }
        con.Close();
        json = JsonConvert.SerializeObject(pr);
        return json;
    }
    protected void insertOrdenDetalleProductoSQL(string usuario, string cat, string sub, string prod, string comen) {
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into OrdenDetalle (IDPedido, IDProducto, Tipo, Comentario, SubTotal, Estatus) " +
            "values ((select top 1 ID from PedidoDomicilio where IDUsuario = (select ID from UsuarioRestaurant where " +
            "Usuario = @usuario) and Estatus = 'Ordenando' order by ID desc), (select ID from Producto where Nombre = @prod and ID_Sub = (select ID from " +
            "SubCategoria where NombreSub = @sub and  ID_Categoria = (select ID from Categoria where NombreCategoria " +
            "= @cat and Sitio = (select Sitio from UsuarioRestaurant where Usuario = @usuario)))), 1, @comen, " +
            "(select Precio from Producto where Nombre = @prod and ID_Sub = (select ID from SubCategoria where " +
            "NombreSub = @sub and ID_Categoria = (select ID from Categoria where NombreCategoria = @cat and " +
            "Sitio = (select Sitio from UsuarioRestaurant where Usuario = @usuario)))), 'Listo')", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@cat", cat);
        cmd.Parameters.AddWithValue("@sub", sub);
        cmd.Parameters.AddWithValue("@prod", prod);
        cmd.Parameters.AddWithValue("@comen", comen);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void insertOrdenDetallePaqueteSQL(string usuario, int id) {
        con.Open();
        SqlCommand cmd = new SqlCommand("if(select Count(ID) from OrdenDetalle where IDPaquete = @id and IDPedido = " +
            "(select top 1 ID from PedidoDomicilio where IDUsuario = (select ID from UsuarioRestaurant where " +
            "Usuario = @usuario) and Estatus = 'Ordenando' order by ID desc) and Estatus = 'Seleccion') = 0 " +
            "begin insert into OrdenDetalle(IDPedido, IDPaquete, Tipo, SubTotal, Estatus) values((select top 1 ID from " +
            "PedidoDomicilio where IDUsuario = (select ID from UsuarioRestaurant where Usuario = @usuario) and " +
            "Estatus = 'Ordenando' order by ID desc), @id, 2, (select Precio from Paquete where ID = @id), 'Seleccion') end", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void insertOrdenDetallePaqueteProductoSQL(string usuario, int id, int prod, string comen) {
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into OrdenDetalleProducto (ID_OrdenDetalle, ID_Producto, Comentario) " +
            "values((select top 1 ID from OrdenDetalle where IDPaquete = @id and IDPedido = (select top 1 ID from " +
            "PedidoDomicilio where IDUsuario = (select ID from UsuarioRestaurant where Usuario = @usuario) order by ID desc) and " +
            "Estatus = 'Seleccion' order by ID desc), @prod, @comentario) ", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@prod", prod);
        cmd.Parameters.AddWithValue("@comentario",comen);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected string consultaPreordenSQL(string usuario) {
        string json = string.Empty;
        List<Producto2> produ = new List<Producto2>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select od.ID, p.Nombre, p.Descripcion, p.Tamaño, p.Precio, od.Tipo from OrdenDetalle " +
            "od inner join Producto p on p.ID = od.IDProducto where od.IDPedido = (select top 1 ID from " +
            "PedidoDomicilio where IDUsuario = (select ID from UsuarioRestaurant where Usuario = @usuario) and " +
            "Estatus = 'Ordenando' order by ID desc) union(select od1.ID, pa.Nombre, '', 'Unico', pa.Precio, " +
            "od1.Tipo from OrdenDetalle od1 inner join Paquete pa on pa.ID = od1.IDPaquete where od1.IDPedido = " +
            "(select top 1 ID from PedidoDomicilio where IDUsuario = (select ID from UsuarioRestaurant where " +
            "Usuario = @usuario) and Estatus = 'Ordenando' order by ID desc) and od1.Estatus = 'Preordenado')",con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            int i = 0;
            Producto2 pr = new Producto2();
            pr.ID = Convert.ToInt32(dr["ID"]);
            pr.Nombre = Convert.ToString(dr["Nombre"]);
            i = Convert.ToInt32(dr["Tipo"]);
            if (i == 2)
            {
                SqlCommand consulta = new SqlCommand("select ', '+ p.Nombre from Producto p inner join " +
                    "OrdenDetalleProducto odp on p.ID = odp.ID_Producto where odp.ID_OrdenDetalle " +
                    "= @id for XML PATH('')");
                consulta.Parameters.AddWithValue("@id", pr.ID);
                DBIOT db = new DBIOT();
                pr.Desc = db.consultaUnDato(consulta);
                pr.Desc = pr.Desc.Substring(1,pr.Desc.Length-1);
            }
            else
                pr.Desc = Convert.ToString(dr["Descripcion"]);
            pr.Tamaño = Convert.ToString(dr["Tamaño"]);
            pr.Precio = Convert.ToInt64(dr["Precio"]);
            produ.Add(pr);
        }
        con.Close();
        json = JsonConvert.SerializeObject(produ);
        return json;
    }
    protected void actualizaPreordenPaqueteSQL(string usuario, int id) {
        con.Open();
        SqlCommand cmd = new SqlCommand("update OrdenDetalle set Estatus = 'Preordenado' where IDPedido = " +
            "(select top 1 ID from PedidoDomicilio where IDUsuario = (select ID from UsuarioRestaurant " +
            "where Usuario = @usuario) order by ID desc) and IDPaquete = @id and Estatus = 'Seleccion'",con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@id",id);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected string finalizaPedidoSQL(string usuario) {
        string json = string.Empty;
        DatosReservacion datos = new DatosReservacion();
        con.Open();
        SqlCommand cmd = new SqlCommand("select pd.ID, pd.Nombre, pd.Domicilio, pd.Telefono, pd.Fecha, COUNT(od.ID) as Cuenta,  " +
            "domicilio.ValorVariable as Servicio, SUM(od.SubTotal) + domicilio.ValorVariable as Total from(select " +
            "ValorVariable from VariablesRestaurant where Sitio = (select sitio from UsuarioRestaurant where Usuario = @usuario) " +
            "and TipoVariable = 'CostoServicioDom') as domicilio, PedidoDomicilio pd inner join OrdenDetalle od on " +
            "od.IDPedido = pd.ID where pd.IDUsuario = (select ID from UsuarioRestaurant where Usuario = @usuario)  " +
            "and pd.Estatus = 'Ordenando' group by pd.ID, pd.Nombre, pd.Telefono, pd.Fecha, pd.Domicilio, " +
            "domicilio.ValorVariable", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            DateTime aux = DateTime.Today;
            datos.IDOrdenPedido = Convert.ToInt32(dr[0]);
            datos.NombrePersona = Convert.ToString(dr[1]);
            datos.direccion = Convert.ToString(dr[2]);
            datos.telefono = Convert.ToString(dr[3]);
            datos.fechaPedido = Convert.ToString(dr[4]);
            aux = Convert.ToDateTime(dr[4]);
            datos.fechaPedido = aux.ToString("dd/MM/yyyy");
            datos.totalOrdenes = Convert.ToInt32(dr[5]);
            datos.costoDomicilio = Convert.ToInt32(dr[6]);
            datos.total = Convert.ToInt32(dr[7]);
        }
        con.Close();
        json = JsonConvert.SerializeObject(datos);
        return json;
    }
    protected void actualizaFinalizarPedidoSQL(string usuario, int id, float total) {
        con.Open();
        SqlCommand cmd = new SqlCommand("update pedidoDomicilio set Estatus = 'En Espera', Total = @total " +
            "where IDUsuario = (select ID from UsuarioRestaurant where Usuario = @usuario) and ID = @id", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@total", total);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected string consultaSolicitudAdmSQL(string usuario) {
        string json = string.Empty;
        List<Pedido> ped = new List<Pedido>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select ID, Nombre, Domicilio, Telefono, Total from PedidoDomicilio " +
            "where IDUsuario in (select ID from UsuarioRestaurant where Sitio = (select C_Sitio from AspNetUsers " +
            "where UserName = @usuario)) and Estatus = 'En Espera'",con);
        cmd.Parameters.AddWithValue("@usuario",usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            Pedido pe = new Pedido();
            pe.ID = Convert.ToInt32(dr["ID"]);
            pe.Nom = Convert.ToString(dr["Nombre"]);
            pe.Direccion = Convert.ToString(dr["Domicilio"]);
            pe.Tel = Convert.ToString(dr["Telefono"]);
            pe.Precio = Convert.ToInt64(dr["Total"]);
            ped.Add(pe);
        }
        json = JsonConvert.SerializeObject(ped);
        con.Close();
        return json;
    }
    protected string consultaPedidoAdmSQL(int id) {
        string json = string.Empty;
        int ide = 0;
        List<Producto3> produ = new List<Producto3>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select od.ID, p.Nombre, p.Descripcion, p.Tamaño, p.Precio, od.Comentario, od.Tipo " +
            "from OrdenDetalle od inner join Producto p on p.ID = od.IDProducto where od.IDPedido = @id " +
            "union(select od1.ID, pa.Nombre, '', 'Unico', pa.Precio, '', od1.Tipo from OrdenDetalle od1 inner " +
            "join Paquete pa on pa.ID = od1.IDPaquete where od1.IDPedido = @id)", con);
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            int i = 0;
            Producto3 pr = new Producto3();
            ide = Convert.ToInt32(dr["ID"]);
            pr.Nombre = Convert.ToString(dr["Nombre"]);
            i = Convert.ToInt32(dr["Tipo"]);
            if (i == 2)
            {
                SqlCommand consulta = new SqlCommand("select ', '+ p.Nombre from Producto p inner join " +
                    "OrdenDetalleProducto odp on p.ID = odp.ID_Producto where odp.ID_OrdenDetalle " +
                    "= @id for XML PATH('')");
                consulta.Parameters.AddWithValue("@id", ide);
                DBIOT db = new DBIOT();
                pr.Desc = db.consultaUnDato(consulta);
                pr.Desc = pr.Desc.Substring(1, pr.Desc.Length - 1);
                SqlCommand consu = new SqlCommand("select CONCAT(p.Nombre,', ', odp.Comentario) from Producto p " +
                    "inner join OrdenDetalleProducto odp on p.ID = odp.ID_Producto where odp.ID_OrdenDetalle = @ide" +
                    " and odp.Comentario !=''");
                consu.Parameters.AddWithValue("@ide", ide);
                pr.Nota = db.consultaUnDato(consu);
            }
            else
            {
                pr.Desc = Convert.ToString(dr["Descripcion"]);
                pr.Nota = Convert.ToString(dr["Comentario"]);
            }
            pr.Tamaño = Convert.ToString(dr["Tamaño"]);
            pr.Precio = Convert.ToInt64(dr["Precio"]);
            produ.Add(pr);
        }
        con.Close();
        json = JsonConvert.SerializeObject(produ);
        return json;
    }
    protected void estatusPedidoDomicilioSQL(int id, string estatus) {
        con.Open();
        SqlCommand cmd = new SqlCommand("update PedidoDomicilio set Estatus = @estatus where ID = @id",con);
        cmd.Parameters.AddWithValue("@estatus", estatus);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected string consultaPedidoUsuarioSQL(string usuario) {
        string json = string.Empty;
        con.Open();
        List<Pedido2> pedi = new List<Pedido2>();
        SqlCommand cmd = new SqlCommand("select top 5 ID, Nombre, Fecha, Estatus from PedidoDomicilio " +
            "where IDUsuario = (select ID from UsuarioRestaurant where Usuario = @usuario) AND Estatus != 'Ordenando'", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            DateTime aux = new DateTime();
            Pedido2 ped = new Pedido2();
            ped.ID = Convert.ToInt32(dr["ID"]);
            ped.Nombre = Convert.ToString(dr["Nombre"]);
            aux = Convert.ToDateTime(dr["Fecha"]);
            ped.Fecha = aux.ToString("dd/MM/yyyy");
            ped.Estatus = Convert.ToString(dr["Estatus"]);
            pedi.Add(ped);
        }
        con.Close();
        json = JsonConvert.SerializeObject(pedi);
        return json;
    }

    /*-------------------------------------------------OBJETOS------------------------------------------------------------
     -------------------------------------------------------------------------------------------------------------------*/
    public class Producto {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
    public class DatosReservacion {
        public string tipoDatos { get; set; }
        public string NombrePersona { get; set; }
        //public string Restaurant { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string fechaPedido { get; set; }
        public int totalOrdenes { get; set; }
        public int costoUnitario { get; set; }
        public int costoDomicilio { get; set; }
        public int total { get; set; }
        public int IDOrdenPedido { get; set; }
    }
    public class Producto2 {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Desc { get; set; }
        public string Tamaño { get; set; }
        public float Precio { get; set; }
    }
    public class PedidoDomicilio{
        public string Categoria { get; set; }
        public List<Producto> Productos { get; set; }
        public string Comentario { get; set; }
    }
    public class Orden {
        public int IDOrden { get; set; }
        public string pedido { get; set; }
    }
    public class NotificacionesAdm
    {
        public int ID { get; set; }
        public string Usuario { get; set; }
        public string Estatus { get; set; }
        public int Personas { get; set; }
        public string Fecha { get; set; }
        public string Nota { get; set; }
    }
    public class NotificacionesUsuario { 
        public int ID { get; set; }
        public string Estatus { get; set; }
        public int Personas { get; set; }
        public string Fecha { get; set;  }
    }
    public class categoria
    {
        public int IDCategoria { get; set; }
        public string nombreCategoria { get; set; }
        public string iconoCategoria { get; set; }
    }
    public class Categ { 
        public int ID { get; set; }
        public string Nombre { get; set; }
    }
    public class Paquete { 
        public int ID { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public string Opciones { get; set; }
    }
    public class Control { 
        public string Estatus { get; set; }
        public int ID { get; set; }
    }
    public class Pedido { 
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Direccion { get; set; }
        public string Tel { get; set; }
        public float Precio { get; set; }
    }
    public class Pedido2 {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string Estatus { get; set; }
    }
    public class Producto3 { 
        public string Nombre { get; set; }
        public string Desc { get; set; }
        public string Tamaño { get; set; }
        public float Precio { get; set; }
        public string Nota { get; set; }
    }

}
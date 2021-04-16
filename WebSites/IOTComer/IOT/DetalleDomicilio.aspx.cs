using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_DetalleDomicilio : System.Web.UI.Page
{
    DataTable dt;
    string ide = string.Empty;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    private SqlConnection con = new SqlConnection(conString);
    private SqlConnection con2 = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 55;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Restaurant")
        {
            ide = Request.QueryString["rol"];
            BindGrid(ide);

        }
        else
        {
            Response.Redirect("~/IOT/Home");
        }
    }
    protected void BindGrid(string id)
    {
        DataSet ds = new DataSet();
        if (id != null)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select ID, Nombre from PedidoDomicilio where ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            conn.Close();
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                DetallePedido.DataSource = ds;
                DetallePedido.DataBind();
                BindGrid2(id);
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                DetallePedido.DataSource = ds;
                DetallePedido.DataBind();
                int columncount = DetallePedido.Rows[0].Cells.Count;
                DetallePedido.Rows[0].Cells.Clear();
                DetallePedido.Rows[0].Cells.Add(new TableCell());
                DetallePedido.Rows[0].Cells[0].ColumnSpan = columncount;
                DetallePedido.Rows[0].Cells[0].Text = "No se encontraron Registros";
            }
        }
    }
    protected void BindGrid2(string id)
    {
        DetalleOrden.DataSource = llenado(Convert.ToInt32(ide));
        DetalleOrden.DataBind();
        
    }
    protected void DetalleComida_PageIndexChanged(object sender, GridViewPageEventArgs e)
    {
        DetalleOrden.PageIndex = e.NewPageIndex;
        this.BindGrid(ide);
    }
    //protected void Volver_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/IOT/PedidoDomic");
    //}

    protected List<Producto3> llenado(int id) {
        int ider = 0;
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
                pr.Descripcion = db.consultaUnDato(consulta);
                pr.Descripcion = pr.Descripcion.Substring(1, pr.Descripcion.Length - 1);
                SqlCommand consu = new SqlCommand("select CONCAT(p.Nombre,', ', odp.Comentario) from Producto p " +
                    "inner join OrdenDetalleProducto odp on p.ID = odp.ID_Producto where odp.ID_OrdenDetalle = @ide" +
                    " and odp.Comentario !=''");
                consu.Parameters.AddWithValue("@ide", ide);
                pr.Comentario = db.consultaUnDato(consu);
            }
            else
            {
                pr.Descripcion = Convert.ToString(dr["Descripcion"]);
                pr.Comentario = Convert.ToString(dr["Comentario"]);
            }
            pr.Tamaño = Convert.ToString(dr["Tamaño"]);
            pr.Precio = Convert.ToInt64(dr["Precio"]);
            produ.Add(pr);
        }
        con.Close();
        return produ;
    }

    public class Producto3
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tamaño { get; set; }
        public float Precio { get; set; }
        public string Comentario { get; set; }
    }
}
    
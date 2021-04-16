using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using TaskScheduler;
using System.Net;
using System.IO;

public partial class IOT_registroAuto : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        Permisos permiso = new Permisos();
        int pantalla = 11;
        if (permiso.returnPermiso(usuario, pantalla) == "Programacion de Tareas")
        {
            BindGrid2();
        }
        else
            Response.Redirect("~/IOT/Home");
    }
    protected void BindGrid()
    {
        string id = User.Identity.GetUserId();
        string usuario = User.Identity.Name;

        conn.Open();
        SqlCommand cmd = new SqlCommand("select a.id, d.Descripcion, a.dispositivo, a.evento, a.hora,a.minuto,a.fecha,a.status, d.RISCEI,  a.Tipo from automatizado a " +
            "inner join (select d1.RISCEI, d1.Descripcion from DARS d1 inner join UbiDis u on d1.UbiDis=u.Id where u.Cl_Sitio=(select C_Sitio from AspNetUsers " +
            "where UserName = @usuario)) as d on a.Dispositivo=d.RISCEI where a.Status != 'Inactivo'", conn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GridView1.DataSource = ds;
            GridView1.DataBind();
            int columncount = GridView1.Rows[0].Cells.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
            GridView1.Rows[0].Cells[0].Text = "No se encontraron Registros";
        }

    }
    public void BindGrid2()
    {
        string id = User.Identity.GetUserId();
        string usuario = User.Identity.Name;
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select a.id, d.Descripcion, a.dispositivo, a.evento, a.hora,a.minuto,a.fecha,a.status, d.RISCEI,  a.Tipo from automatizado a " +
            "inner join (select d1.RISCEI, d1.Descripcion from DARS d1 inner join UbiDis u on d1.UbiDis=u.Id where u.Cl_Sitio=(select C_Sitio from AspNetUsers " +
            "where UserName = @usuario)) as d on a.Dispositivo=d.RISCEI ";
                cmd.Parameters.AddWithValue("@usuario", usuario);
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    sql += "Where ( A.Id LIKE '%' + @Busqueda + '%' OR d.Descripcion LIKE '%' + @Busqueda + '%' OR a.dispositivo LIKE '%' + @Busqueda + '%' OR a.evento LIKE '%' + @Busqueda + '%' OR a.hora LIKE '%' + @Busqueda + '%' OR a.minuto LIKE '%' + @Busqueda + '%' OR a.fecha LIKE '%' + @Busqueda + '%' OR a.status LIKE '%' + @Busqueda + '%' AND a.Status != 'Inactivo')";
                    cmd.Parameters.AddWithValue("@Busqueda", txtSearch.Text.Trim());
                }
                cmd.CommandText = sql;
                cmd.Connection = con;

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }
    protected void Search(object sender, EventArgs e)
    {
        this.BindGrid2();
    }
    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("detail"))

        {
            string id = GridView1.DataKeys[index].Value.ToString();
            IEnumerable<DataRow> query = from Fabricantes in dt.AsEnumerable()
                                         where Fabricantes.Field<String>("ID").Equals(id)
                                         select Fabricantes;

            DataTable GridView1Table = query.CopyToDataTable<DataRow>();
            GridView1.DataSource = GridView1Table;
            GridView1.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type= 'text/javascript'>");
            sb.Append("$('detailmodal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DetailmodalScript", sb.ToString(), false);
        }

        else if (e.CommandName.Equals("deleteRecord"))
        {
            string id = GridView1.DataKeys[index].Value.ToString();
            hfID.Value = id;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        string id = hfID.Value;
        string[] tarea = new string[2];
        tarea = datosTarea(id);
        if (Desprogramar(tarea))
        {
            updateStatus(id);
            BindGrid();
            sb.Append("alert('Registo Eliminado');");
            sb.Append("$('#eliminaModal').modal('hide');");
            sb.Append(@"</script>");
        }
        else
        {
            sb.Append("alert('Problema al eliminar tarea, vuelve a intentar.');");
            sb.Append("$('#eliminaModal').modal('hide');");
            sb.Append(@"</script>");
        }

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
    }

    protected void updateStatus(string id) {
        conn.Open();
        string updateCmd = "update automatizado set Status='Inactivo' where Id = @id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, conn);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.ExecuteNonQuery();
        conn.Close();
    }

    public bool Desprogramar(string[] tareas)
    {
        string peticion = string.Empty, url = string.Empty;
        string tarea = string.Empty;
        tarea = tareas[0].Trim();
        peticion = "http://" + tareas[1] + "/cronPhp/eliminarTarea.php?eliminar=" + tarea;
        try
        {
            url = returnResponseValue(peticion);
            return true;
        }
        catch   
        {
            return false;
        }
    }

    protected string[] datosTarea(string id) {
        string[] datos = new string[2];
        conn.Open();
        SqlCommand cmd = new SqlCommand("select a1.Url, a2.NOIP from (select Url from automatizado where Id = @id) as a1, " +
            "(select NOIP from Sitios where ID = (select Cl_Sitio from UbiDis u inner join DARS d on u.Id = d.UbiDis " +
            "where RISCEI = (select dispositivo from automatizado where Id = @id)))as a2",conn);
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            datos[0] = Convert.ToString(dr[0]);
            datos[1] = Convert.ToString(dr[1]);
        }
        conn.Close();
        return datos;
    }

    protected string returnResponseValue(string url)
    {
        HttpWebRequest peticion = (HttpWebRequest)WebRequest.Create(url);
        //peticion.KeepAlive= false;
        string json2 = string.Empty;
        //peticion = WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)peticion.GetResponse();
        Stream stream = response.GetResponseStream();
        StreamReader reader = new StreamReader(stream);

        json2 = reader.ReadToEnd();
        reader.Close();
        stream.Close();
        response.Close();
        //peticion.Abort();
        return json2;
    }

    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid2();
    }
}
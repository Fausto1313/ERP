﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Eventos : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 22;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, 0) == "RISC")
        {
            if (!IsPostBack)
            {
                cargaModelos();
                cargaModelos2();
            }
            else if (permiso.returnPermiso(usuario, pantalla) == "Eventos")
            {

            }

            BindGrid2();
        }
        else
            Response.Redirect("~/IOT/Home");
    }

    public void BindGrid2()
    {

        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "SELECT * from Eventos ";
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    sql += "Where ( Id LIKE '%' + @Busqueda + '%' OR Evento LIKE '%' + @Busqueda + '%' OR Comando LIKE '%' + @Busqueda + '%' OR Descripcion LIKE '%' + @Busqueda + '%' OR Modelo LIKE '%' + @Busqueda + '%')";
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
    public void BindGrid()
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from Eventos", conn);

            //SqlCommand cmd = new SqlCommand("SELECT E.Evento, E.Comando, E.Descripcion, R.AutorizacionEvento, E.Tipo_DAR FROM Eventos E, Dars D, Roles R WHERE E.NivelAutorizacion=R.AutorizacionEvento AND E.Tipo_DAR=D.Tipo", conn);
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

        catch (SqlException e)
        {
            Console.WriteLine("Excepcion Ocurrida: ", e);
        }

    }
    /*Metodo que contiene la vista, actualizacion y o eliminacion de una fila segun sea el evento, atraves de un modal.*/
    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("detail"))
        {
            string id = GridView1.DataKeys[index].Value.ToString();
            IEnumerable<DataRow> query = from Eventos in dt.AsEnumerable()
                                         where Eventos.Field<String>("ID").Equals(id)
                                         select Eventos;
            DataTable GridView1Table = query.CopyToDataTable<DataRow>();
            GridView1.DataSource = GridView1Table;
            GridView1.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type= 'text/javascript'>");
            sb.Append("$('detailmodal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DetailmodalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("updRecord"))
        {


            GridViewRow gvrow = GridView1.Rows[index];

            txtID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            txtEvento.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            txtComando.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
            txtDescripcion.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            //txtModelo.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);


            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        }/*

        else if (e.CommandName.Equals("deleteRecord"))
        {
            string id = GridView1.DataKeys[index].Value.ToString();
            hfID.Value = id;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#deleteModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }*/

    }
    /*Recoge el id donde se da click en el evento actualizar lo guarda y envia*/
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string id = txtID.Text;
        string Evento = txtEvento.Text;
        string Comando = txtComando.Text;
        string Descripcion = txtDescripcion.Text;
        string Modelo = modelos2.Text;

        ExecuteUpdate(id, Evento, Comando, Descripcion, Modelo);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

    }
    /*Ejecuta el evento de actualizado a la base de datos*/
    private void ExecuteUpdate(string id, string Evento, string Comando, string Descripcion, string Modelo)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE Eventos SET ID=@ID, Evento=@Evento, Comando=@Comando, Descripcion=@descripcion, Modelo=@Modelo WHERE ID='" + id + "'";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@ID", id);
        updatecmd.Parameters.AddWithValue("@Evento", Evento);
        updatecmd.Parameters.AddWithValue("@Comando", Comando);
        updatecmd.Parameters.AddWithValue("@descripcion", Descripcion);
        updatecmd.Parameters.AddWithValue("@Modelo", Modelo);

        updatecmd.ExecuteNonQuery();
        con.Close();

    }

    
   
    /*Metodo para agregar nuevo dispositivo*/
    protected void BtnAddClick(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

    }
    /*Metodo para insertar*/
    protected void BtnAddRecordClick(object sender, EventArgs e)
    {
        string id = txtID1.Text;
        string Evento = txtEvento1.Text;
        string Comando = txtComando1.Text;
        string Descripcion = txtDescripcion1.Text;
        string Modelo = modelos.Text;
        DateTime Fecha = DateTime.Now;
        ExecuteAdd(id, Evento, Comando, Descripcion, Modelo);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);


    }
    private void ExecuteAdd(string id, string Evento, string Comando, string Descripcion, string Modelo)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "insert into Eventos (ID, Evento, Comando, Descripcion,Modelo) values (@ID,@Evento,@Comando,@Descripcion,@Modelo)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@ID", id);
        addCmd.Parameters.AddWithValue("@Evento", Evento);
        addCmd.Parameters.AddWithValue("@Comando", Comando);
        addCmd.Parameters.AddWithValue("@Descripcion", Descripcion);
        addCmd.Parameters.AddWithValue("@Modelo", Modelo);
        addCmd.ExecuteNonQuery();
        con.Close();


    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)

    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
    public void cargaModelos()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT Modelo FROM Modelos", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        modelos.DataSource = dr;
        modelos.DataTextField = "Modelo";
        modelos.DataValueField = "Modelo";
        modelos.DataBind();
    }

    public void cargaModelos2()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT Modelo FROM Modelos", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        modelos2.DataSource = dr;
        modelos2.DataTextField = "Modelo";
        modelos2.DataValueField = "Modelo";
        modelos2.DataBind();
    }

}



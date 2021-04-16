using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using IOTComer;
using Microsoft.AspNet.Identity.EntityFramework;
using TaskScheduler;

public partial class IOT_SimuladorPresencia : System.Web.UI.Page
{
   
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected int us = 0;
    protected string dar = null;
    protected string ev = null;
  

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 13;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Simulacion de Presencia")
        {
            if (!IsPostBack)
            {
                CargaSitios();
            }
            BindGrid();
        }
        else
        {
            Response.Redirect("~/IOT/Home");
        }
    }

    public void CargaSitios()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        string usuario = User.Identity.Name;
        SqlCommand cmd = new SqlCommand("if(select 1 from PermisoRol where ID_Permiso = 36 and ID_Rol = (select ID_Rol from AspNetUsers where UserName = @usuario)) = 1 " +
                                        "select id, C_Sitio from sitios where ID_cliente = (select id_cliente from AspNetUsers where UserName = @usuario) " +
                                        "else select id, C_Sitio from sitios where ID = (select C_Sitio from AspNetUsers where UserName = @usuario)", cn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        Sitios.DataSource = dr;
        Sitios.DataTextField = "C_Sitio";
        Sitios.DataValueField = "ID";
        Sitios.DataBind();
        if (Sitios.Items.Count != 0)
        {
            Sitios.Items.Insert(0, new ListItem("Seleccionar sitio", "0"));
            us = Convert.ToInt32(Sitios.SelectedValue);   
        }
        else
        {
            Sitios.Items.Clear();          
        }

    }

    private void ExecuteAdd()
    {
        string nom = Nombre.Text;
        string lugar = Sitios.SelectedValue;
        string hor =Convert.ToString( hora.SelectedItem);
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);
        conn.Open();
        string updatecmd = "insert into Simulador (Nombre,Horario,ID_Sitio) values (@nom,@hor,@lugar)";
        SqlCommand addCmd = new SqlCommand(updatecmd, conn);
        addCmd.Parameters.AddWithValue("@nom", nom);
        addCmd.Parameters.AddWithValue("@hor", hor);
        addCmd.Parameters.AddWithValue("@lugar", lugar);
        addCmd.ExecuteNonQuery();
        conn.Close();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Tarea agregada');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
        BindGrid();      
    }


    protected void CreaTarea_Click(object sender, EventArgs e)
    {
        ExecuteAdd();
        Nombre.Text="";
        hora.SelectedValue = "0";
        Sitios.SelectedValue = "0";
        Response.Redirect("~/IOT/SimuladorPresencia.aspx");

    }


    protected void BindGrid()
    {
        string id = User.Identity.GetUserId();
        string usuario = User.Identity.Name;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select s.id, s.nombre, s.horario, sit.C_Sitio from Simulador s, Sitios sit where s.ID_Sitio=sit.ID and sit.ID_Cliente = (select ID_Cliente from AspNetUsers where username=@usuario)", conn);
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

    private void ExecuteDelete(string id)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updatecmd = "delete from Simulador where Id=@id";
            SqlCommand addCmd = new SqlCommand(updatecmd, con);
            addCmd.Parameters.AddWithValue("@id", id);
            addCmd.ExecuteNonQuery();
            con.Close();

        }
        catch (SqlException e)
        {
            Console.WriteLine("Excepcion Ocurrida: ", e);
        }
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string id = hfID.Value;
        ExecuteDelete(id);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registo Eliminado');");
        sb.Append("$('#eliminaModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
    }

    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("delRecord"))
        {
            string id = GridView1.DataKeys[index].Value.ToString();
            hfID.Value = id;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("Asignar"))
        {
            GridViewRow gvrow2 = GridView1.Rows[index];
            string id = HttpUtility.HtmlDecode(gvrow2.Cells[0].Text).ToString();
            string sitio = HttpUtility.HtmlDecode(gvrow2.Cells[2].Text).ToString();
            Response.Redirect("~/IOT/AsignarSimulador?ID=" + id + "&Sitio=" + sitio);
        }
        else if (e.CommandName.Equals("diaRecord"))
        {
            GridViewRow gvrow2 = GridView1.Rows[index];
            string id = HttpUtility.HtmlDecode(gvrow2.Cells[0].Text).ToString();
            Label1.Text = id;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#addDay').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("ConsultaDias"))
        {
            GridViewRow gvrow2 = GridView1.Rows[index];
            string id = HttpUtility.HtmlDecode(gvrow2.Cells[0].Text).ToString();
            Label1.Text = id;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo from simulador where ID=@id", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@id", id);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView2.DataSource = ds;
                GridView2.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView2.DataSource = ds;
                GridView2.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView2.Rows[0].Cells.Clear();
                GridView2.Rows[0].Cells.Add(new TableCell());
                GridView2.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView2.Rows[0].Cells[0].Text = "No se encontraron Registros";
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ConsultaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ConsultaModalScript", sb.ToString(), false);

        }

    }


    protected void BtnAddRecordClick1(object sender, EventArgs e)
    {
        
        string Lunes = chLunes.Checked ? "1" : "0";
        string Martes = chMartes.Checked ? "2" : "0";
        string Miercoles = chMiercoles.Checked ? "3" : "0";
        string Jueves = chJueves.Checked ? "4" : "0";
        string Viernes = chViernes.Checked ? "5" : "0";
        string Sabado = chSabado.Checked ? "6" : "0";
        string Domingo = chDomingo.Checked ? "7" : "0";
        string query = null;

        if (Lunes == "1")

        {
            int valor = 1;
            query = "update Simulador set Lunes=@valor where ID=@id";
            ExecuteAddDay(query, valor);
        }
        else
        {
            int valor = 0;
            query = "update Simulador set Lunes=@valor where ID=@id";
            ExecuteAddDay(query, valor);
        }
        if (Martes == "2")

        {
            int valor = 2;
            query = "update Simulador set Martes=@valor where ID=@id";
            ExecuteAddDay(query, valor);

        }
        else
        {
            int valor = 0;
            query = "update Simulador set Martes=@valor where ID=@id";
            ExecuteAddDay(query, valor);
        }

        if (Miercoles == "3")

        {
            int valor = 3;
            query = "update Simulador set Miercoles=@valor where ID=@id";
            ExecuteAddDay(query, valor);
        }
        else
        {
            int valor = 0;
            query = "update Simulador set Miercoles=@valor where ID=@id";
            ExecuteAddDay(query, valor);
        }

        if (Jueves == "4")

        {
            int valor = 4;
            query = "update Simulador set Jueves=@valor where ID=@id";
            ExecuteAddDay(query, valor);

        }
        else
        {
            int valor = 0;
            query = "update Simulador set Jueves=@valor where ID=@id";
            ExecuteAddDay(query, valor);
        }
        if (Viernes == "5")

        {
            int valor = 5;
            query = "update Simulador set Viernes=@valor where ID=@id";
            ExecuteAddDay(query, valor);
        }
        else
        {
            int valor = 0;
            query = "update Simulador set Viernes=@valor where ID=@id";
            ExecuteAddDay(query, valor);
        }
        if (Sabado == "6")

        {
            int valor = 6;
            query = "update Simulador set Sabado=@valor where ID=@id";
            ExecuteAddDay(query, valor);

        }
        else
        {
            int valor = 0;
            query = "update Simulador set Sabado=@valor where ID=@id";
            ExecuteAddDay(query, valor);
        }
        if (Domingo == "7")

        {
            int valor = 7;
            query = "update Simulador set Domingo=@valor where ID=@id";
            ExecuteAddDay(query, valor);
        }
        else
        {
            int valor = 0;
            query = "update Simulador set Domingo=@valor where ID=@id";
            ExecuteAddDay(query, valor);
        }
      

    }

    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.BindGrid();

    }

    private void ExecuteAddDay(string query, int valor)
    {
        int id = Convert.ToInt32(Label1.Text);
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand addCmd = new SqlCommand(query, con);     
        addCmd.Parameters.AddWithValue("@valor", valor);
        addCmd.Parameters.AddWithValue("@id", id);
        addCmd.ExecuteNonQuery();
        con.Close();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Dias asignados');");
        sb.Append("$('#addModals').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
    }

    private void DeleteTarea(int nom, int valor)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "delete from dbo.PermisoRol where ID_Rol=@nom and ID_Permiso=@valor";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@nom", nom);
        addCmd.Parameters.AddWithValue("@valor", valor);
        addCmd.ExecuteNonQuery();
        con.Close();
    }


}
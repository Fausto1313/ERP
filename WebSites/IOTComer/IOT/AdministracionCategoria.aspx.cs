using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Specialized;

public partial class IOT_AdministracionCategoria : System.Web.UI.Page
{
	DataTable dt;
	static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
	MemoryStream ms = new MemoryStream();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            cargarCombo();
            cargaOrden();
			cargaOrden2();
			cargarCombo2();
		}
		bindgrid();
            
    }

	protected void bindgrid()
	{
		string ord = Orden.SelectedValue;
		string imagen = string.Empty;
		byte[] im;
		con.Open();
		SqlCommand sql = new SqlCommand("select c.ID,c.NombreCategoria, i.Icono,c.Orden from Categoria as c INNER JOIN RepoIconos as i ON c.Icono=i.ID WHERE c.Icono=i.ID and c.Sitio = " +
            "(select C_Sitio from AspNetUsers where UserName = @usuario)", con);
        sql.Parameters.AddWithValue("@usuario", User.Identity.Name);
		SqlDataAdapter da = new SqlDataAdapter(sql);
		DataSet ds = new DataSet();
		da.Fill(ds);
		//object result = sql.ExecuteScalar();
		SqlDataReader DataReader = sql.ExecuteReader();
        DataReader.Read();
            try
            {
                im = (byte[])DataReader["Icono"];
                imagen = Convert.ToBase64String(im);
            }
            catch {
            }

		DataReader.Close();
		//Imagenes.ImageUrl = "data:image/jpg;base64," + imagen;
		con.Close();
		dt = ds.Tables[0];
		if(ds.Tables[0].Rows.Count > 0)
		{
			GridView1.DataSource = ds;
			GridView1.DataBind();
		}
		else
		{
            GridView1.DataSource = null;
            GridView1.DataBind();
            //GridView1.Rows[0].Cells.Clear();
            /*ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GridView1.DataSource = ds;
            GridView1.DataBind();
            int columncount = GridView1.Rows[0].Cells.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
            GridView1.Rows[0].Cells[0].Text = "No se encontraron Registros";*/

        }

	}

	protected void OnRowCommand(object sender,GridViewCommandEventArgs e)
	{
		int index = Convert.ToInt32(e.CommandArgument);
		if (e.CommandName.Equals("updCat"))
		{
			GridViewRow gvrow = GridView1.Rows[index];
			
			txtID.Text= HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
			txtNombreCate.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString();
			//txtOrden.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString();
			lblResult.Visible = false;
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append(@"<script type='text/javascript'>");
			sb.Append("$('#updModal').modal('show');");
			sb.Append(@"</script>");
			ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

		}else if (e.CommandName.Equals("delCat"))
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

	protected void BtnSave_Click(object sender, EventArgs e)
	{

	    string  id = txtID.Text;
		string nomCat = txtNombreCate.Text;
		int orden = Int32.Parse(Orden2.Text);
		int icono = Int32.Parse(Icono2.Text);

		//string modelo = Modelo2.Text;
	
		ExecuteUpdate(id, nomCat, icono, orden);
		bindgrid();
		//System.Text.StringBuilder sb = new System.Text.StringBuilder();
		//sb.Append(@"<script type='text/javascript'>");
		//sb.Append("alert('Registro actualizado exitosamente');");
		//sb.Append("$('#updModal').modal('hide');");
		//sb.Append(@"</script>");
		//ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

	}

	private void ExecuteUpdate(string id, string nomcat,int icono, int orden)
	{
		string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

		SqlConnection con = new SqlConnection(conString);
		con.Open();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        string updateCmd = "UPDATE Categoria SET  NombreCategoria=@nomcat,Icono=@icono, Orden=@orden WHERE ID=@id";
		SqlCommand updatecmd = new SqlCommand(updateCmd, con);
		
		updatecmd.Parameters.AddWithValue("@nomcat", nomcat);
		updatecmd.Parameters.AddWithValue("@icono", Icono2.SelectedValue);
		updatecmd.Parameters.AddWithValue("@orden", orden);
		updatecmd.Parameters.AddWithValue("@id", id);
		updatecmd.ExecuteNonQuery();
        sb.Append("$('#updModal').modal('hide');");
        sb.Append("swal(\"Actualización!\", \"Categoria actualizado de forma correcta.\", \"success\");");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);
        con.Close();

	}

	private void ExecuteDelete(string id)
	{
		string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
		try
		{
			SqlConnection con = new SqlConnection(conString);
			con.Open();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
            sb.Append("<script type='text/javascript'>");
            string updatecmd = "delete from Categoria where ID = @id";
			SqlCommand addCmd = new SqlCommand(updatecmd, con);
			addCmd.Parameters.AddWithValue("@id", id);
			addCmd.ExecuteNonQuery();
            sb.Append("$('#eliminaModal').modal('hide');");
            sb.Append("swal(\"Eliminado!\", \"Categoria eliminada de forma correcta.\", \"success\");");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
            con.Close();
            bindgrid();
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
		
		//System.Text.StringBuilder sb = new System.Text.StringBuilder();
		//sb.Append(@"<script type='text/javascript'>");
		//sb.Append("alert('Registo Eliminado');");
		//sb.Append("$('#eliminaModal').modal('hide');");
		//sb.Append(@"</script>");
		//ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
	}

	protected void Icono_SelectedIndexChanged(object sender, EventArgs e)
    {
        string imagen = string.Empty;
        byte[] im;
        con.Open();
        SqlCommand cmd = new SqlCommand("select icono from RepoIconos where ID=@id",con);
        cmd.Parameters.AddWithValue("@id", Icono.SelectedValue);
        object result = cmd.ExecuteScalar();
        con.Close();
        im = (byte[])result;
        imagen = Convert.ToBase64String(im);
        Imagen.ImageUrl = "data:image/jpg;base64," + imagen;
        con.Close();
    }

	protected void Icono_SelectedIndexChanged2(object sender, EventArgs e)
	{
		string imagenes = string.Empty;
		byte[] im;
		con.Open();
		SqlCommand cmd = new SqlCommand("select icono from RepoIconos where ID=@id", con);
		cmd.Parameters.AddWithValue("@id", Icono2.SelectedValue);
		object result = cmd.ExecuteScalar();
		con.Close();
		im = (byte[])result;
		imagenes = Convert.ToBase64String(im);
		Image2.ImageUrl = "data:image/jpg;base64," + imagenes;
		con.Close();
	}

	protected void cargarCombo() {
        Icono.DataSource = Consultar("SELECT ID,Nombre FROM repoIconos");
        Icono.DataValueField = "ID";
        Icono.DataTextField = "Nombre";
        Icono.DataBind();
        Icono.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }
	protected void cargarCombo2()
	{
		Icono2.DataSource = Consultar("SELECT ID,Nombre FROM repoIconos");
		Icono2.DataValueField = "ID";
		Icono2.DataTextField = "Nombre";
		Icono2.DataBind();
		Icono2.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
	}


	protected void cargaOrden() {
        Orden.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        for (int i = 1; i < 10; i++) {
            Orden.Items.Insert(i,new ListItem("#"+i,i.ToString()));
        }
    }

	protected void cargaOrden2()
	{
	
		Orden2.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
		for (int i = 1; i < 10; i++)
		{
			Orden2.Items.Insert(i, new ListItem("#" + i, i.ToString()));
		}
	}


    protected DataSet Consultar(string consulta)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand(consulta, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds;
    }

	protected void BtnAddRecordClick(object sender, EventArgs e)
	{

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        
        int ic = 0, orden = 0;
        ic = Convert.ToInt32(Icono.SelectedValue);
        orden = Convert.ToInt32(Orden.SelectedValue);
        if (ic > 0 && orden > 0)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Categoria(NombreCategoria, Icono, Sitio, Orden) values(@nombre, @icono, " +
                "(select C_Sitio from AspNetUsers where UserName=@usuario), @orden)", con);
            cmd.Parameters.AddWithValue("@nombre", txtCategoria.Text);
            cmd.Parameters.AddWithValue("@icono", ic);
            cmd.Parameters.AddWithValue("@usuario", Context.User.Identity.Name);
            cmd.Parameters.AddWithValue("@orden", orden);
            cmd.ExecuteNonQuery();
            con.Close();
            sb.Append("$('#addModal').modal('hide');");
            sb.Append("swal(\"Guardado!\", \"Categoria agregada de forma correcta.\", \"success\");");
            sb.Append(@"</script>");
            txtCategoria.Text = "";
            Imagen.ImageUrl = "";
        }
        else {
            sb.Append("swal(\"Alerta!\", \"Debes seleccionar el orden y/o un icono.\", \"warning\");");
            sb.Append(@"</script>");
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
        bindgrid();

    }
	protected void BtnAddClick(object sender, EventArgs e)
	{
		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		sb.Append(@"<script type='text/javascript'>");
		sb.Append("$('#addModal').modal('show');");
		sb.Append(@"</script>");
		ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

	}
}
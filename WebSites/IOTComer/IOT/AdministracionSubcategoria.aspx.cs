using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_AdministracionSubcategoria : System.Web.UI.Page
{
	DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            cargarCombo();
			cargarCombo2();
            cargaCategorias();
			cargaCategorias2();
			cargaCategorias3();
            cargaOrden();
			cargaOrden2();
        }
		
    }

	protected void bindGrid()
	{
		string cat= Cat.SelectedValue;
		//string= Orden.SelectedValue;
		string ord = Orden.SelectedValue;
		string imagen = string.Empty;
		byte[] im;
		con.Open();
		SqlCommand sql = new SqlCommand("SELECT s.ID,s.NombreSub, i.Icono,s.Orden from Subcategoria as s INNER JOIN RepoIconos as i  ON s.Icono=i.ID  INNER JOIN Categoria as c ON s.ID_Categoria=c.ID WHERE s.Icono=i.ID " +
			"and s.ID_Categoria=@cat " , con);
		sql.Parameters.AddWithValue("@cat", cat);	
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
		catch (Exception)
		{

		}
		DataReader.Close();	
		//Imagenes.ImageUrl = "data:image/jpg;base64," + imagen;
		con.Close();
		dt = ds.Tables[0];
		if (ds.Tables[0].Rows.Count > 0)
		{
			GridView1.DataSource = ds;
			GridView1.DataBind();
		}
		else
		{

			GridView1.DataSource = null;
			GridView1.DataBind();
			//ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
			//GridView1.DataSource = ds;
			//GridView1.DataBind();
			//int columncount = GridView1.Rows[0].Cells.Count;
			//GridView1.Rows[0].Cells.Clear();
			//GridView1.Rows[0].Cells.Add(new TableCell());
			//GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
			//GridView1.Rows[0].Cells[0].Text = "No se encontraron Registros";
		}
	}

	protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
	{
		int index = Convert.ToInt32(e.CommandArgument);
		if (e.CommandName.Equals("updCat"))
		{
			GridViewRow gvrow = GridView1.Rows[index];

			txtID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
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

	protected void BtnAddClick(object sender, EventArgs e)
	{
		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		sb.Append(@"<script type='text/javascript'>");
		sb.Append("$('#addModal').modal('show');");
		sb.Append(@"</script>");
		ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

	}

	protected void BtnAddRecordClick(object sender, EventArgs e)
	{
		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
		sb.Append("<script type='text/javascript'>");
        int cat = 0, ic =0, ord = 0;
        cat = Convert.ToInt32(Categoria.SelectedValue);
        ic = Convert.ToInt32(Icono.SelectedValue);
        ord = Convert.ToInt32(Orden.SelectedValue);
        if (cat > 0 && ic > 0 && ord > 0)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Subcategoria(NombreSub, Icono, ID_Categoria, Orden) values(@nombre, @icono, @categoria, @orden)", con);
            cmd.Parameters.AddWithValue("@nombre", txtCategoria.Text);
            cmd.Parameters.AddWithValue("@icono", Icono.SelectedValue);
            cmd.Parameters.AddWithValue("@categoria", Categoria.SelectedValue);
            cmd.Parameters.AddWithValue("@orden", Orden.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
            sb.Append("swal(\"Guardado!\", \"Subcategoria agregada de forma correcta.\", \"success\");");
            sb.Append("$('#addModal').modal('hide');");
        }
        else {
            sb.Append("swal(\"Aviso.\", \"Ingresa todos los datos para continuar.\", \"warning\");");
        }
		sb.Append(@"</script>");
		ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
		txtCategoria.Text = "";
		bindGrid();
	}

	protected void BtnSave_Click(object sender, EventArgs e)
	{

		string id = txtID.Text;
		string nomCat = txtNombreCate.Text;
		int icono = Int32.Parse(Icono2.SelectedValue);
		int cate = Int32.Parse(Categoria2.Text);
		int orden = Int32.Parse(Orden2.Text);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        if (icono > 0 && cate > 0 && orden > 0) {

            ExecuteUpdate(id, nomCat, icono, cate, orden);
            sb.Append("swal(\"Guardado!\", \"Subcategoria actualizada de forma correcta.\", \"success\");");
            sb.Append("$('#updModal').modal('hide');");
            bindGrid();
            
        }
        else
        {
            sb.Append("swal(\"Aviso.\", \"Ingresa todos los datos para continuar.\", \"warning\");");
        }
        sb.Append(@"</script>");
		ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

	}

	private void ExecuteUpdate(string id, string nomcat,int icono, int cate, int orden)
	{
		string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

		SqlConnection con = new SqlConnection(conString);
		con.Open();
		string updateCmd = "UPDATE subcategoria SET  NombreSub=@nomcat,Icono=@icono,ID_Categoria=@cate, Orden=@orden WHERE ID=@id";
		SqlCommand updatecmd = new SqlCommand(updateCmd, con);

		updatecmd.Parameters.AddWithValue("@nomcat", nomcat);
		updatecmd.Parameters.AddWithValue("@icono", icono);
		updatecmd.Parameters.AddWithValue("@cate", cate);
		updatecmd.Parameters.AddWithValue("@orden", orden);
		updatecmd.Parameters.AddWithValue("@id", id);
		updatecmd.ExecuteNonQuery();
		con.Close();

	}

	private void ExecuteDelete(string id)
	{
		string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
		try
		{
			SqlConnection con = new SqlConnection(conString);
			con.Open();
			string updatecmd = "delete from subcategoria where ID = @id";
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
		bindGrid();
		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		sb.Append(@"<script type='text/javascript'>");
		sb.Append("alert('Registo Eliminado');");
		sb.Append("$('#eliminaModal').modal('hide');");
		sb.Append(@"</script>");
		ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
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


	protected void cargaCategorias() {
        Categoria.DataSource = Consultar2("select ID, NombreCategoria from Categoria where Sitio = (select C_Sitio from AspNetUsers where UserName = @usuario)");
        Categoria.DataValueField = "ID";
        Categoria.DataTextField = "NombreCategoria";
        Categoria.DataBind();
        Categoria.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }

	protected void cargaCategorias2()
	{
		Categoria2.DataSource = Consultar2("select ID, NombreCategoria from Categoria where Sitio = (select C_Sitio from AspNetUsers where UserName = @usuario)");
		Categoria2.DataValueField = "ID";
		Categoria2.DataTextField = "NombreCategoria";
		Categoria2.DataBind();
		Categoria2.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
	}
	protected void cargaCategorias3()
	{
		SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
		cn.Open();
		SqlCommand cmd = new SqlCommand("select ID, NombreCategoria from Categoria where Sitio = (select C_Sitio from AspNetUsers where UserName = @usuario)", cn);
        cmd.Parameters.AddWithValue("@usuario", User.Identity.Name);
        SqlDataReader dr = cmd.ExecuteReader();
		Cat.DataSource = dr;
		Cat.DataSource = dr;
		Cat.DataTextField = "NombreCategoria";
		Cat.DataValueField = "ID";
		Cat.DataBind();
		Cat.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
	}


	protected DataSet Consultar2(string consulta)
    {
        string usuario = Context.User.Identity.Name;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand(consulta, con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds;
    }
    protected void Icono_SelectedIndexChanged(object sender, EventArgs e)
    {
        string imagen = string.Empty;
        byte[] im;
        con.Open();
        SqlCommand cmd = new SqlCommand("select icono from RepoIconos where ID=@id", con);
        cmd.Parameters.AddWithValue("@id", Icono.SelectedValue);
        object result = cmd.ExecuteScalar();
        con.Close();
        im = (byte[])result;
        imagen = Convert.ToBase64String(im);
        Image1.ImageUrl = "data:image/jpg;base64," + imagen;
        con.Close();
    }

    protected void cargarCombo()
    {
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

	protected void cargaOrden()
    {
        Orden.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        for (int i = 1; i < 10; i++)
        {
            Orden.Items.Insert(i, new ListItem("#" + i, i.ToString()));
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

	protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		
	}

	protected void PageIndexChanging(object sender, GridViewPageEventArgs e)

	{

		GridView1.PageIndex = e.NewPageIndex;


	}
	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{



	}



	protected void Cat_SelectedIndexChanged(object sender, EventArgs e)
	{
		bindGrid();
	}
}
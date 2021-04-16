using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class IOT_Instalados : System.Web.UI.Page
{

    DataTable dt;
    protected int sit = 0;
    protected int nivel1 = 0;
    protected int nivel2 = 0;
    protected int nivel3 = 0;
    protected int nivel4 = 0;
    protected int nivel5 = 0;
   
    private SqlConnection conn = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=multicliente;User ID=sa;Password=sa+LANSA!;Pooling=False");
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();
        if (!IsPostBack)
            Sitios();
    }
    public void BindGrid()
    {

        string usuario = User.Identity.Name;
        conn.Open();
        string algo = null;
        string clientes = ("Select u.ID_Cliente from Clientes c, dbo.AspNetUsers u  where c.ID=u.ID_Cliente and u.UserName=@usuario");
        SqlCommand cmsd = new SqlCommand(clientes, conn);
        cmsd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmsd.ExecuteReader();
        //Response.Write(clientes);
        if (dr.Read())
        {
            algo = Convert.ToString(dr[0]);
        }
        conn.Close();
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT D.RISCEI, D.Descripcion, M.Modelo, C.RazonSocial FROM DARS D, Clientes C, Modelos M WHERE  D.ID_Cliente=C.ID AND M.Modelo=D.Modelo And D.ID_Cliente='" + algo + "'", conn);
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
    public void CNivel5(int id)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID,Nombre FROM Nivel5 where ID_nivel4=@id", cn);
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader dr = cmd.ExecuteReader();
        Nivel5.DataSource = dr;
        Nivel5.DataTextField = "Nombre";
        Nivel5.DataValueField = "ID";
        Nivel5.DataBind();
        if (Nivel5.Items.Count != 0)
        {
            nivel5 = Convert.ToInt32(Nivel5.SelectedValue);
            CNivel5(nivel5);
        }
        else
        {
            Nivel5.Items.Clear();
        }
    }

    public void CNivel4(int id)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID,Nombre FROM Nivel4 where ID_nivel3=@id", cn);
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader dr = cmd.ExecuteReader();
        Nivel4.DataSource = dr;
        Nivel4.DataTextField = "Nombre";
        Nivel4.DataValueField = "ID";
        Nivel4.DataBind();
        if (Nivel4.Items.Count != 0)
        {
            nivel4 = Convert.ToInt32(Nivel4.SelectedValue);
            CNivel4(nivel4);
        }
        else
        {
            Nivel5.Items.Clear();
            Nivel4.Items.Clear();
        }
    }

    public void CNivel3(int id)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID,Nombre FROM Nivel3 where ID_nivel2=@id", cn);
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader dr = cmd.ExecuteReader();
        Nivel3.DataSource = dr;
        Nivel3.DataTextField = "Nombre";
        Nivel3.DataValueField = "ID";
        Nivel3.DataBind();
        if (Nivel3.Items.Count != 0)
        {
            nivel3 = Convert.ToInt32(Nivel3.SelectedValue);
            CNivel3(nivel3);
        }
        else
        {
            Nivel4.Items.Clear();
            Nivel3.Items.Clear();
        }
    }

    public void CNivel2(int id)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID,Nombre FROM Nivel2 where ID_nivel1=@id", cn);
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader dr = cmd.ExecuteReader();
        Nivel2.DataSource = dr;
        Nivel2.DataTextField = "Nombre";
        Nivel2.DataValueField = "ID";
        Nivel2.DataBind();
        if (Nivel1.Items.Count != 0)
        {
            nivel2 = Convert.ToInt32(Nivel2.SelectedValue);
            CNivel3(nivel2);
        }
        else
        {
            Nivel3.Items.Clear();
            Nivel2.Items.Clear();
        }
    }

    public void CNivel1(int id)
    {
        string usuario = User.Identity.Name;
        conn.Open();
        string algo = null;
        string clientes = ("Select u.ID_Cliente from Clientes c, dbo.AspNetUsers u  where c.ID=u.ID_Cliente and u.UserName=@usuario");
        SqlCommand cmsd = new SqlCommand(clientes, conn);
        cmsd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader drs = cmsd.ExecuteReader();
        //Response.Write(clientes);
        if (drs.Read())
        {
            algo = Convert.ToString(drs[0]);
        }
        conn.Close();
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID,Nombre FROM dbo.Nivel1 where UbiDispo='" + id + "'", cn);
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader dr = cmd.ExecuteReader();
        Nivel1.DataSource = dr;
        Nivel1.DataTextField = "nombre";
        Nivel1.DataValueField = "ID";
        Nivel1.DataBind();
        if (Nivel1.Items.Count != 0)
        {
            nivel1 = Convert.ToInt32(Nivel1.SelectedValue);
            CNivel2(nivel1);
        }
        else
        {
            Nivel2.Items.Clear();
            Nivel1.Items.Clear();
        }
    }
    public void Sitios()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        string usuario = User.Identity.Name;
        string algo = null;
        string cliente = User.Identity.Name;
        string clientes = ("Select u.ID_Cliente from Clientes c, dbo.AspNetUsers u  where c.ID=u.ID_Cliente and u.UserName=@usuario");
        SqlCommand cmd = new SqlCommand(clientes, cn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            algo = Convert.ToString(dr[0]);
        }
        cn.Close();
        cn.Open();

        SqlCommand cms = new SqlCommand("select distinct ID, C_Sitio FROM Sitios where ID_Cliente='" + algo + "'", cn);
        cms.Parameters.AddWithValue("@algo", algo);
        SqlDataReader drs = cms.ExecuteReader();

        Sitio.DataSource = drs;
        Sitio.DataTextField = "C_Sitio";
        Sitio.DataValueField = "ID";
        Sitio.DataBind();
        if (Sitio.Items.Count != 0)
        {
            sit = Convert.ToInt32(Sitio.SelectedValue);
            CNivel1(sit);
        }
        else
        {
            Nivel1.Items.Clear();
            Sitio.Items.Clear();
        }
    }
    protected void Sitio_SelectedIndexChanged(object sender, EventArgs e)
    {
        sit = Convert.ToInt32(Sitio.Text);
        CNivel1(sit);
    }
    protected void Nivel1_SelectedIndexChanged(object sender, EventArgs e)
    {
        nivel1 = Convert.ToInt32(Nivel1.Text);
        CNivel2(nivel1);
    }
    protected void Nivel2_SelectedIndexChanged(object sender, EventArgs e)
    {
        nivel2 = Convert.ToInt32(Nivel2.Text);
        CNivel3(nivel2);
    }
    protected void Nivel3_SelectedIndexChanged(object sender, EventArgs e)
    {
        nivel3 = Convert.ToInt32(Nivel3.Text);
        CNivel4(nivel3);
    }
    protected void Nivel4_SelectedIndexChanged(object sender, EventArgs e)
    {
        nivel4 = Convert.ToInt32(Nivel4.Text);
        CNivel5(nivel4);
    }
    protected void Consulta(object sender, EventArgs e)
    {
        string sitio = Sitio.Text;
        string nivel1 = Nivel1.Text;
        string nivel2 = Nivel2.Text;
        string nivel3= Nivel3.Text;
        string nivel4 = Nivel4.Text;
        string nivel5 = Nivel5.Text;
        string nn = Nivel1.Text;
        string n = Nivel1.Text;
        if ((nivel1 !=null) && (nivel2 == "") && (nivel3 == "") && (nivel4 == "") && (nivel5 == ""))
        {
            SqlCommand cmd = new SqlCommand("select  D.Descripcion From DARS D, Nivel1 N, UbiDis U, Sitios S Where N.ID ='" + nivel1 +"' And U.nivel1 = N.ID And U.Cl_Sitio = S.ID And D.UbiDis = U.Id and S.ID ='" + sitio + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
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
                GridView2.Rows[0].Cells[0].Text = "No se encont  raron Registros";
            }
        }
     
        else if ((nivel1 != null) && (nivel2 != null) && (nivel3 == "") && (nivel4 == "") && (nivel5 == ""))
        {

            SqlCommand cmd = new SqlCommand("select  D.Descripcion From DARS D, Nivel1 N, UbiDis U, Sitios S,Nivel2 N2 Where N.ID='" + nivel1 +"' And U.nivel1=N.ID And U.Cl_Sitio=S.ID And D.UbiDis=U.Id and N2.ID='" + nivel2 + "' and S.ID='" + sitio + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
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
                GridView2.Rows[0].Cells[0].Text = "No se encont  raron Registros";
            }
        }
        else if ((nivel1 != null) && (nivel2 != null) && (nivel3 != null) && (nivel4 == "") && (nivel5 == ""))
        {

            SqlCommand cmd = new SqlCommand("select  D.Descripcion From DARS D, Nivel1 N, UbiDis U, Sitios S,Nivel2 N2,Nivel3 N3 Where N.ID='" + nivel1 + "' And U.nivel1=N.ID And U.Cl_Sitio=S.ID And D.UbiDis=U.Id and N2.ID='" + nivel2 +"' And N3.ID='" + nivel3 + "' and S.ID='" + sitio + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
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
        }
        else if ((nivel1 != null) && (nivel2 != null) && (nivel3 != null) && (nivel4 != "") && (nivel5 == ""))
        {

            SqlCommand cmd = new SqlCommand("select  D.Descripcion From DARS D, Nivel1 N, UbiDis U, Sitios S,Nivel2 N2,Nivel3 N3, Nivel4 N4 Where N.ID='" + nivel1 + "' And U.nivel1=N.ID And U.Cl_Sitio=S.ID And D.UbiDis=U.Id and N2.ID='" + nivel2 + "' And N3.ID='" + nivel3 +"' And N4.ID= '" + nivel4 + "' and S.ID='" + sitio + "' ", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
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
        }
        else if ((nivel1 != null) && (nivel2 != null) && (nivel3 != null) && (nivel4 != null) && (nivel5 != null))
        {

            SqlCommand cmd = new SqlCommand("select  D.Descripcion From DARS D, Nivel1 N, UbiDis U, Sitios S,Nivel2 N2,Nivel3 N3, Nivel4 N4, Nivel5 N5 Where N.ID='" + nivel1 + "' And U.nivel1=N.ID And U.Cl_Sitio=S.ID And D.UbiDis=U.Id and N2.ID='" + nivel2 + "' And N3.ID='" + nivel3 + "' And N4.ID='" + nivel4 + "' And N5.ID='" + nivel5 + "' and S.ID='" + sitio + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
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
                GridView1.DataSource = ds;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView2.Rows[0].Cells.Clear();
                GridView2.Rows[0].Cells.Add(new TableCell());
                GridView2.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView2.Rows[0].Cells[0].Text = "No se encontraron Registros";
            }
        }
    }
}

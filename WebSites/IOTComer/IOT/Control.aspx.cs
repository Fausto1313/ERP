using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class IOT_Control : System.Web.UI.Page
{
    public string onoffswitch;
    
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Response.AppendHeader("Cache-Control", "no-store");
        Response.AppendHeader("Pragma", "no-cache");
        Button1_Click1();
        if (this.IsPostBack)
        {
            TabName.Value = Request.Form[TabName.UniqueID];
        }
        //AddControls();


    }
    /*public void AddControls()
    {
        Button btn2 = new Button();
        btn2.ID = "btnEdit";
        btn2.Text = "Edit Member";

        btn2.Click += new EventHandler(Button1_Click);

        Controls.Add(btn2);
    }*/
    protected void Button1_Click(object sender, EventArgs e)
    {
        String variable = "http://risc-iot.ddns.net:4041/1710LE2005/ON";
        irServicio(variable);

        Button1.Enabled = false;
        Button2.Enabled = true;
        LEDON.Visible = true;
        LEDOFF.Visible = false;

        int btn1 = 1;
        //Bloquear(btn1);
        insertarD(variable);
        //Update("SLED", "ON", 1);
    }
    protected void Button10_Click(object sender, EventArgs e)
    {

        Button1.Enabled = true;
        Button2.Enabled = true;
        Button3.Enabled = true;
        Button4.Enabled = true;
        Button5.Enabled = true;
        Button6.Enabled = true;
    }
    protected void Button11_Click(object sender, EventArgs e)
    {

        // System.Diagnostics.Process.Start("IEXPLORE.EXE", );
        String variable = "http://risc-iot.ddns.net:4045/1710HW2006/POWER";
        //ProcessStartInfo startInfo = new ProcessStartInfo("C:\\inetpub\\wwwroot\\IOT\\tareas\\hony.bat");
        //startInfo.WindowStyle = ProcessWindowStyle.Minimized;
        //startInfo.Arguments = variable;
        //Process.Start(startInfo);
        irServicio(variable);
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        String variable = "http://risc-iot.ddns.net:4045/1710HW2006/OSC";
        irServicio(variable);

    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        String variable = "http://risc-iot.ddns.net:4045/1710HW2006/TIEMPO";
        irServicio(variable);

    }
    protected void Button14_Click(object sender, EventArgs e)
    {

        String variable = "http://risc-iot.ddns.net:4045/1710HW2006/FRIO";
        irServicio(variable);
    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        String variable = "http://risc-iot.ddns.net:4045/1710HW2006/DORMIR";
        irServicio(variable);

    }

    protected void encenderTodos(object sender, EventArgs e)
    {
        String variable = "http://risc-iot.ddns.net:4041/1710LE2005/ON";
        irServicio(variable);
        String variable2 = "http://risc-iot.ddns.net:4040/1710LU2002/ON";
        irServicio(variable2);
        String variable3 = "http://risc-iot.ddns.net:4042/1710VA2001/ON";
        irServicio(variable3);
    }
    protected void ApagarTodos(object sender, EventArgs e)
    {
        String variable = "http://risc-iot.ddns.net:4041/1710LE2005/OFF";
        irServicio(variable);
        String variable2 = "http://risc-iot.ddns.net:4040/1710LU2002/OFF";
        irServicio(variable2);
        String variable3 = "http://risc-iot.ddns.net:4042/1710VA2001/Off";
        irServicio(variable3);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        String variable = "http://risc-iot.ddns.net:4041/1710LE2005/OFF";
        irServicio(variable);
        Button2.Enabled = false;
        Button1.Enabled = true;
        LEDON.Visible = false;
        LEDOFF.Visible = true;
        int btn2 = 2;

        insertarD(variable);
       // Update("SLED", "OFF", 1);
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        String variable = "http://risc-iot.ddns.net:4040/1710LU2002/ON";
        irServicio(variable);
        Button3.Enabled = false;
        Button4.Enabled = true;
        LUZON.Visible = true;
        LUZOFF.Visible = false;
        int btn3 = 3;
       // Bloquear(btn3);

        insertarD(variable);
        //Update("LSJU", "ON", 2);
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        String variable = "http://risc-iot.ddns.net:4040/1710LU2002/OFF";
        irServicio(variable);
        Button4.Enabled = false;
        Button3.Enabled = true;
        LUZON.Visible = false;
        LUZOFF.Visible = true;
        int btn4 = 4;
        //Bloquear(btn4);
        insertarD(variable);
        //Update("LSJU", "OFF", 2);
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        /*SqlConnection conn = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=IOTComer;User ID=sa;Password=sa+LANSA!;Pooling=False");
        string variable = null;
        SqlCommand cmd = new SqlCommand("SELECT evento FROM estadoD where macID=@macID", cn);
        cmd.Parameters.AddWithValue("@macID", macID);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            variable = Convert.ToString(dr[0]);
        }
        conn.Close();
        */
        String variable = "http://risc-iot.ddns.net:4042/1710VA2001/ON";
        irServicio(variable);
        Button5.Enabled = false;
        Button6.Enabled = true;
        VENTION.Visible = true;
        VENTIOFF.Visible = false;
        int btn5 = 5;
        //Bloquear(btn5);

        insertarD(variable);
        //Update("V427", "ON", 3);
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        String variable = "http://risc-iot.ddns.net:4042/1710VA2001/OFF";
        irServicio(variable);
        // Response.Write("<script language=\"JavaScript\">alert(\"OFF\");</script>");

        Button6.Enabled = false;
        Button5.Enabled = true;
        VENTION.Visible = false;
        VENTIOFF.Visible = true;
        int btn6 = 6;
        //Bloquear(btn6);
        insertarD(variable);
        //Update("V427", "OFF", 3);
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        String variable = "http://risc-iot.ddns.net:4044/1710P12004/OPEN";

        irServicio(variable);

        insertarD(variable);
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        String variable = "http://risc-iot.ddns.net:4043/1710P12003/OPEN";

        irServicio(variable);

        insertarD(variable);
    }

    protected void irServicio(String variable)
    {
        // Create a request using a URL that can receive a post. 
        /*WebRequest request = WebRequest.Create(variable);
        request.GetResponseAsync();
        request.Abort();*/

        WebRequest Peticion = default(WebRequest);
        Peticion = WebRequest.Create(variable);
        Peticion.GetResponseAsync();
        
    }

    protected void insertarD(String variable)
    {

        System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=IOT;User ID=sa;Password=sa+LANSA!");
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        DateTime std = DateTime.Now;
        String evento = null;
        evento = eventoT(variable);
        cmd.CommandText = "INSERT acceso5 (fechaEvento, nombreEvento, direccionIP) VALUES (@std, @evento, @variable)";
        cmd.Parameters.AddWithValue("@std", std);
        cmd.Parameters.AddWithValue("@evento", evento);
        cmd.Parameters.AddWithValue("@variable", variable);
        cmd.Connection = sqlConnection1;
        sqlConnection1.Open();
        cmd.ExecuteNonQuery();
        sqlConnection1.Close();

    }
    /*protected void Update(string variable1, string variable2, int variable3)
    {

        System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=IOT;User ID=sa;Password=sa+LANSA!");
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        string std = variable1;
        string variable = variable2;
        int evento = variable3;
        cmd.CommandText = "UPDATE dbo.estadoD SET macID = @std, evento = @variable Where id = @evento";
        cmd.Parameters.AddWithValue("@std", std);
        cmd.Parameters.AddWithValue("@variable", variable);
        cmd.Parameters.AddWithValue("@evento", evento);
        cmd.Connection = sqlConnection1;
        sqlConnection1.Open();
        cmd.ExecuteNonQuery();
        sqlConnection1.Close();

    }*/

    protected string eventoT(String variable)
    {
        String evento = null;
        //BLOQUE DE LEDS
        if (variable == "http://risc-iot.ddns.net:4041/1710LE2005/ON")
            evento = "Evento: Encendido de LEDS";
        else if (variable == "http://risc-iot.ddns.net:4041/1710LE2005/OFF")
            evento = "Evento: Apagado de LEDS";
        //BLOQUE DE SALA DE CAPACITACION
        else if (variable == "http://risc-iot.ddns.net:4040/1710LU2002/ON")
            evento = "Evento: Encendido de luces sala";
        else if (variable == "http://risc-iot.ddns.net:4040/1710LU2002/OFF")
            evento = "Evento: Apagado de luces sala";
        //BLOQUE DE VENTILADOR
        else if (variable == "http://risc-iot.ddns.net:4042/1710VA2001/ON")
            evento = "Evento: Encendido de ventilador sala";
        else if (variable == "http://risc-iot.ddns.net:4042/1710VA2001/OFF")
            evento = "Evento: Apagado de ventilador sala";
        //BLOQUE DE PUERTAS 
        else if (variable == "http://risc-iot.ddns.net:4043/1710P12003/OPEN")
            evento = "Evento: Apertura de puerta de vestíbulo";
        else if (variable == "http://risc-iot.ddns.net:4044/1710P12004/OPEN")
            evento = "Evento: Apertura de puerta de entrada principal";
        return evento;
    }

    protected void Button1_Click1()
    {
        inicial();
        String[] r = new String[5];
        String[] d = { "1710LE2005", "1710LU2002", "1710VA2001", "SMag", "SMov" };
        for (int i = 0; i < d.Length; i++)
        {
            r[i] = estadoD(d[i]);
        }
        if (r[0] == "OFF")
        {
            Button2.Enabled = false;
            Button1.Enabled = true;
            LEDOFF.Visible = true;


        }
        else if (r[0] == "ON")
        {
            Button2.Enabled = true;
            Button1.Enabled = false;
            LEDON.Visible = true;



        }
        if (r[1] == "OFF")
        {
            Button4.Enabled = false;
            Button3.Enabled = true;
            LUZOFF.Visible = true;
        }
        else if (r[1] == "ON")
        {
            Button4.Enabled = true;
            Button3.Enabled = false;
            LUZON.Visible = true;

        }
        if (r[2] == "OFF")
        {
            Button6.Enabled = false;
            Button5.Enabled = true;
            VENTIOFF.Visible = true;
        }
        else if (r[2] == "ON")
        {
            Button6.Enabled = true;
            Button5.Enabled = false;
            VENTION.Visible = true;
        }

    }
    
    protected String estadoD(String macID)
    {
        String stat = null;
        SqlConnection cn = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=IOT;User ID=sa;Password=sa+LANSA!");
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT evento FROM estadoD where macID=@macID", cn);
        cmd.Parameters.AddWithValue("@macID", macID);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            stat = Convert.ToString(dr[0]);
        }
        cn.Close();
        return stat;
    }

   protected void inicial()
    {
        Button1.Enabled = true;


        //.Enabled = true;
        Button2.Enabled = true;
        Button3.Enabled = true;
        Button4.Enabled = true;
        Button5.Enabled = true;
        Button6.Enabled = true;
        LEDOFF.Visible = false;
        LEDON.Visible = false;
        LUZON.Visible = false;
        LUZOFF.Visible = false;
        VENTION.Visible = false;
        VENTIOFF.Visible = false;

    }
    
    /*protected void Bloquear(int boton)
    {
        if (boton == 1 || boton == 2)
        {

            Button3.Enabled = false;
            Button4.Enabled = false;
            Button5.Enabled = false;
            Button6.Enabled = false;
        }

        else if (boton == 3 || boton == 4)
        {
            Button1.Enabled = false;
            Button2.Enabled = false;

            Button5.Enabled = false;
            Button6.Enabled = false;
        }

        else if (boton == 5 || boton == 6)
        {
            Button1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;

        }



    }
    public void bloq(object source, EventArgs e)
    {
        int boton = 1;


        if (boton == 1 || boton == 2)
        {

            Button3.Enabled = true;
            Button4.Enabled = true;
            Button5.Enabled = true;
            Button6.Enabled = true;
        }

        else if (boton == 3 || boton == 4)
        {

            Button1.Enabled = true;
            Button2.Enabled = true;

            Button5.Enabled = true;
            Button6.Enabled = true;
        }

        else if (boton == 5 || boton == 6)
        {

            Button1.Enabled = true;
            Button2.Enabled = true;
            Button3.Enabled = true;
            Button4.Enabled = true;

        }
    }*/
}
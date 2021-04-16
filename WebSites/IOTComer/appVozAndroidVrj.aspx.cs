using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class appVozAndroidVrj : System.Web.UI.Page
{
    private SqlConnection con = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=IOTComer;User ID=sa;Password=sa+LANSA!;Pooling=False");
    protected void Page_Load(object sender, EventArgs e)
    {
        string comando = Request["v1"];        
        if(comando=="encender todo"){
            string ip = "risc-iot.ddns.net:4041";
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip + "&v2=1710LE2005&v3=ON");
            Peticion.GetResponseAsync();
            //Dispositivo 2
            string ip2 = "risc-iot.ddns.net:4040";
            WebRequest Peticion2 = default(WebRequest);
            Peticion2 = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip2 + "&v2=1710LU2002&v3=ON");
            Peticion2.GetResponseAsync();
            //Dispositivo 3
            string ip3 = "risc-iot.ddns.net:4042";
            WebRequest Peticion3 = default(WebRequest);
            Peticion3 = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip3 + "&v2=1710VA2001&v3=ON");
            Peticion3.GetResponseAsync();
            //Dispositivo 4
            string ip4 = "risc-iot.ddns.net:4045";
            WebRequest Peticion4 = default(WebRequest);
            Peticion4 = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip4 + "&v2=1710HW2006&v3=POWER");
            Peticion4.GetResponseAsync();
            Response.Write("True");
        }
        else if(comando=="Apagar todo"){
            string ip = "risc-iot.ddns.net:4041";
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip + "&v2=1710LE2005&v3=OFF");
            Peticion.GetResponseAsync();
            //Dispositivo 2
            string ip2 = "risc-iot.ddns.net:4040";
            WebRequest Peticion2 = default(WebRequest);
            Peticion2 = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip2 + "&v2=1710LU2002&v3=OFF");
            Peticion2.GetResponseAsync();
            //Dispositivo 3
            string ip3 = "risc-iot.ddns.net:4042";
            WebRequest Peticion3 = default(WebRequest);
            Peticion3 = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip3 + "&v2=1710VA2001&v3=OFF");
            Peticion3.GetResponseAsync();
            //Dispositivo 4
            string ip4 = "risc-iot.ddns.net:4045";
            WebRequest Peticion4 = default(WebRequest);
            Peticion4 = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip4 + "&v2=1710HW2006&v3=POWER");
            Peticion4.GetResponseAsync();
            Response.Write("True");
        }
        else{
            string[] datos = new string[2];
            datos = returnComm(comando);
            if (datos[0] == null){
                Response.Write("False");
            }
            else {
                if (datos[0] == "1710LE2005")
                {
                    string ip = "risc-iot.ddns.net:4041";
                    WebRequest Peticion = default(WebRequest);
                    Peticion = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip + "&v2=" + datos[0] + "&v3=" + datos[1]);
                    Peticion.GetResponseAsync();
                }
                else if (datos[0] == "1710LU2002")
                {
                    string ip = "risc-iot.ddns.net:4040";
                    WebRequest Peticion = default(WebRequest);
                    Peticion = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip + "&v2=" + datos[0] + "&v3=" + datos[1]);
                    Peticion.GetResponseAsync();
                }
                else if (datos[0] == "1710VA2001")
                {
                    string ip = "risc-iot.ddns.net:4042";
                    WebRequest Peticion = default(WebRequest);
                    Peticion = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip + "&v2=" + datos[0] + "&v3=" + datos[1]);
                    Peticion.GetResponseAsync();
                }
                else if (datos[0] == "1710HW2006") {
                    string ip = "risc-iot.ddns.net:4045";
                    WebRequest Peticion = default(WebRequest);
                    Peticion = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip + "&v2=" + datos[0] + "&v3=" + datos[1]);
                    Peticion.GetResponseAsync();
                }
                Response.Write("True");
            }
        }
    }

    protected string[] returnComm(string comando) {
        string[] com = new string[2];
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT RISCEI, Accion FROM Comandos where Comando=@comando", con);
        cmd.Parameters.AddWithValue("@comando", comando);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            com[0] = Convert.ToString(dr[0]);
            com[1] = Convert.ToString(dr[1]);
        }
        con.Close();
        return com;
    }
}
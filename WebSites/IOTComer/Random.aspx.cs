using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler;

public partial class IOT_Random : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection con = new SqlConnection(conString);
    private SqlConnection con2 = new SqlConnection(conString);
    private SqlConnection con3 = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        int mañanaI = 6, mañanaF = 11, tardeI = 12, tardeF = 19, nocheI = 20, nocheF = 23;
        DateTime std = DateTime.Today;
        DateTime[] activador = new DateTime[2];
        string t = std.DayOfWeek.ToString(), dar = string.Empty, url = string.Empty, comando = string.Empty, descripcion = string.Empty, nombre = string.Empty;
        con.Open();
        string day = returnDia(t);
        SqlCommand cmd = new SqlCommand("select ID, Horario, Nombre from Simulador where "+day+" > 0",con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            int id = Convert.ToInt32(dr[0]), i = 0;
            string horario = Convert.ToString(dr[1]);
            descripcion = Convert.ToString(dr[2])+" "+horario;
            if (horario == "Matutino")
            {
                activador = returnFechas(mañanaI, mañanaF);
            }
            else if (horario == "Vespertino")
            {
                activador = returnFechas(tardeI, tardeF);
            }
            else
            {
                activador = returnFechas(nocheI, nocheF);
            }
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("select distinct dr.ID_Dispositivo, b.URL, b.Comando from DispositivoRegla dr inner join Bat b " +
                "on dr.ID_Dispositivo = b.RISCEI where dr.ID_Simulador = @id",con2);
            cmd2.Parameters.AddWithValue("@id", id);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read()) {
                if (i == 2) {
                    if (horario == "Matutino")
                    {
                        activador = returnFechas(mañanaI, mañanaF);
                    }
                    else if (horario == "Vespertino")
                    {
                        activador = returnFechas(tardeI, tardeF);
                    }
                    else
                    {
                        activador = returnFechas(nocheI, nocheF);
                    }
                    i = 0;
                }
                dar = Convert.ToString(dr2[0]);
                url = Convert.ToString(dr2[1]);
                comando = Convert.ToString(dr2[2]);
                if (comando == "ON" || comando == "POWER" || comando == "PLAY")
                {
                    nombre = dar + Convert.ToString(activador[0].Hour)+ Convert.ToString(activador[0].Minute)+comando;
                    Response.Write(nombre + "----" + Convert.ToString(std.ToShortDateString()) + "|");
                    //insertRegister(nombre, std.ToShortDateString());
                    //crearTareaUnica(nombre, activador[0], url);
                    //Response.Write("|| Resultado: DAR= " + dar + " URL= " + url + " Comando= " + comando + " Encendido= " + activador[0]);
                }
                else
                {
                    nombre = dar + Convert.ToString(activador[1].Hour) + Convert.ToString(activador[1].Minute) + comando;
                    Response.Write(nombre + "----" + Convert.ToString(std.ToShortDateString()) + "|");
                    //insertRegister(nombre, std.ToShortDateString());
                    //crearTareaUnica(nombre, activador[1], url);
                    //Response.Write("|| Resultado: DAR= " + dar + " URL= " + url + " Comando= " + comando + " Apagado= " + activador[1]);
                }
                i++;
            }
            con2.Close();

        }
        con.Close();
    }

    protected void insertRegister(string nombre, string fecha)
    {
        con3.Open();
        SqlCommand cmd3 = new SqlCommand("insert into SimuladorDiario (Nombre, Fecha) values(@nombre, @fecha)", con3);
        cmd3.Parameters.AddWithValue("@nombre", nombre);
        cmd3.Parameters.AddWithValue("@fecha", fecha);
        cmd3.ExecuteNonQuery();
        con3.Close();
    }

    protected DateTime[] returnFechas(int inicio, int fin) {
        DateTime[] res = new DateTime[2];
        int[] ON = new int[2];
        int[] OFF = new int[2];
        ON[0] = Random(inicio, fin);
        ON[1] = Random(0, 59);
        OFF[0] = Random(ON[0], fin);
        if (ON[0] == OFF[0])
        {
            OFF[1] = Random(ON[1] + 1, 59);
        }
        res[0] = DateTime.Today;
        res[0] = res[0].AddHours(ON[0]);
        res[0] = res[0].AddMinutes(ON[1]);
        res[1] = DateTime.Today;
        res[1] = res[1].AddHours(OFF[0]);
        res[1] = res[1].AddMinutes(OFF[1]);
        return res;
    }

    public int Random(int inicial, int final)
    {
        Random r = new Random();
        int valor = 0;
        valor = r.Next(inicial, final);
        return valor;
    }

    protected string returnDia(string dia) {
        string day = string.Empty;

        switch (dia) {
            case "Monday":
                day = "Lunes";
                break;
            case "Tuesday":
                day = "Martes";
                break;
            case "Wednesday":
                day = "Miercoles";
                break;
            case "Thursday":
                day = "Jueves";
                break;
            case "Friday":
                day = "Viernes";
                break;
            case "Saturday":
                day = "Sabado";
                break;
            case "Sunday":
                day = "Domingo";
                break;
        }
        return day;
    }

    protected void crearTareaUnica(string nombre, DateTime tiempo, string url)
    {
        ScheduledTasks Tareas = new ScheduledTasks();
        Task tarea = Tareas.CreateTask(nombre);
        tarea.ApplicationName = @"" + url + "";
        tarea.Comment = "Tarea de prueba";
        tarea.SetAccountInformation("Administrator", "addar-18");
        tarea.Creator = "RISC-ADDAR";
        // prioridad de la tarea
        tarea.Priority = System.Diagnostics.ProcessPriorityClass.Normal;
        // agregamos el disparador, la tarea se ejecutara diariamente a las 6 y 15 pm
        tarea.Triggers.Add(new RunOnceTrigger(tiempo));
        tarea.Save();
    }

}
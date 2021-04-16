using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Drawing;
using Microsoft.AspNet.Identity;
using ClosedXML.Excel;

public partial class Reportes_Reporte : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 30;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Huella Dactilar")
        {
            if (!IsPostBack)
            {
                CargaSitio();
            }
            bindgrid();
        }
        else
            Response.Redirect("~/IOT/Home");
    }

    protected void bindgrid()
    {
        //DateTime an, nueva, actual = DateTime.Now;
        string sit = Sitio.SelectedValue;
        //an = new DateTime(actual.Year, actual.Month, actual.Day, 0, 0, 0);
        //nueva = new DateTime(actual.Year, actual.Month, actual.Day, 23, 59, 59);
        conn.Open();
        SqlCommand cmd = new SqlCommand("select top 10 E.ID, E.Nombre, E.Apellidos, D.Fecha, D.Estatus from controlDactilar D," +
            "Empleado E where(D.IDEmpleado = E.ID and E.Sitio = @sitio) order by D.ID desc", conn);
        cmd.Parameters.AddWithValue("@sitio", sit);
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

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.bindgrid();
    }

    protected void CargaSitio()
    {
        Sitio.DataSource = Consultar("select id, C_Sitio from sitios where ID_cliente in (select id_cliente from AspNetUsers where UserName = @usuario)");
        Sitio.DataValueField = "ID";
        Sitio.DataTextField = "C_Sitio";
        Sitio.DataBind();
        Sitio.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccionar]", "0"));

    }
    protected DataSet Consultar(string consulta)
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

    protected void genera_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable("Reporte de asistencia");
        //dt.Columns.Add("Logo");
        //DataRow pp = dt.NewRow();
        //pp[0] = "Holis";
        //dt.Rows.Add(pp);
        //dt.Columns.Add("Holi");
        int j = 0;
        foreach (TableCell cell in GridView1.HeaderRow.Cells)
        {
            //dt.Columns.Add(cell.Text);
            if (j == 4)
            {
                dt.Columns.Add("Hora");
            }
            else if (j < 4)
            {
                dt.Columns.Add(cell.Text);
            }
            j++;
        }
        foreach (GridViewRow row in GridView1.Rows)
        {
            //dt.Rows.Add();
            //dt.Rows[0][4] = "Holi";
            dt.Rows.Add();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                if (i == 3)
                {
                    DateTime date = Convert.ToDateTime(row.Cells[i].Text);
                    dt.Rows[dt.Rows.Count - 1][i] = date.ToShortDateString();
                    i++;
                    dt.Rows[dt.Rows.Count - 1][i] = date.ToShortTimeString();
                }
                else
                    dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
            }
        }
        //using  (XLWorkbook wb = new XLWorkbook())
        using (var wb = new XLWorkbook())
        {

            //var worksheet = wb.Worksheets.Add("");

            //wb.Cell("A1").Value = "Control de Huellas";
            //wb.Cell("A1").Value = "../recursos/casa.png";
            //worksheet.Cell("A1:B2").Style.Fill.BackgroundColor = XLColor.Orange;


            var vv = wb.Worksheets.Add("Reporte de Asistencia");
          

            vv.Cell("G1").Value = "Reporte de Asistencia";
            vv.Cells("G1:J1").Style.Fill.BackgroundColor = XLColor.BallBlue;
            vv.Cells("G1:J1").Style.Font.FontSize = 20;
            //vv.Cells("G1:J1").Style.Alignment.RelativeInd;
            vv.Cell(6, 6).InsertTable(dt);
            //vv.Cell(6, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string filename = "Reporte-" + DateTime.Now.ToShortDateString();
            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xlsx");
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
    }

    protected void generaPDF_Click(object sender, EventArgs e)
    {
        ExportGridToPDF();
    }

    private void ExportGridToPDF()
    {
        string nombre = "Reporte-" + DateTime.Now.ToShortDateString();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename="+nombre+".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //GridView1.RenderControl(hw);

        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 35f, 0f);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);


        //TABLA//
        // creating datatable and adding dumy data
        //DataTable dt = GridView1.DataSource as DataTable;
        // creating document object
        iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);
        rec.BackgroundColor = new BaseColor(Color.Olive);
        //Document doc = new Document(rec);
        pdfDoc.SetPageSize(PageSize.A4);
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();

        //LOGO DEL PDF//
        iTextSharp.text.Font times = FontFactory.GetFont(FontFactory.TIMES_BOLD, 20, BaseColor.BLUE);
        var logo = iTextSharp.text.Image.GetInstance(ConsultarIcono());
        logo.SetAbsolutePosition(40, 760);
        logo.ScaleAbsoluteHeight(50);
        logo.ScaleAbsoluteWidth(50);

        pdfDoc.Add(logo);
        //TITULO PRINCIPAL//
        Paragraph twainBibText = new Paragraph("Control de Huellas", times);
        twainBibText.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(twainBibText);

        //Adding paragraph for report generated by
        Paragraph prgGeneratedBY = new Paragraph();
        BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 8, 3, iTextSharp.text.BaseColor.DARK_GRAY);
        prgGeneratedBY.Alignment = Element.ALIGN_RIGHT;
        string usuario = User.Identity.Name;
        prgGeneratedBY.Add(new Chunk("Reporte Generado: " +usuario, fntAuthor));
        prgGeneratedBY.Add(new Chunk("\nFecha Creada : " + DateTime.Now.ToShortDateString(), fntAuthor));
        pdfDoc.Add(prgGeneratedBY);
        //LINEA//
        Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
        pdfDoc.Add(p);

        //Adding line break
        pdfDoc.Add(new Chunk("\n"));
        //Adding  PdfPTable

        PdfPTable table = new PdfPTable(dt.Columns.Count);
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            string cellText = null;
            if (i == 4)
            {
               cellText  = "Hora";
            }
            else {
                cellText = Server.HtmlDecode(dt.Columns[i].ColumnName);
            }
            PdfPCell cell = new PdfPCell();
            cell.Phrase = new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))));
            cell.BackgroundColor = new BaseColor(ColorTranslator.FromHtml("#0c4566"));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.PaddingBottom = 5;
            table.AddCell(cell);
        }
        //writing table Data
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                if (j == 3)
                {
                    DateTime sd = DateTime.Today;
                    try
                    {
                        sd = Convert.ToDateTime(dt.Rows[i][j]);

                    }
                    catch {

                    }
                    table.AddCell(sd.ToShortDateString().ToString());
                    j++;
                    table.AddCell(sd.ToShortTimeString().ToString());
                    j++;
                }
                else {
                    table.AddCell(dt.Rows[i][j].ToString());
                }
            }
        }
        pdfDoc.Add(table);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
        GridView1.AllowPaging = true;
        GridView1.DataBind();
    }

    protected byte[] ConsultarIcono()
    {

        string usuario = Context.User.Identity.GetUserName();
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT  icono FROM Clientes Where ID=(select ID_Cliente from AspNetUsers where username = @usuario)";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Connection = con;
        con.Open();
        //objCmd.CommandType = CommandType.Text;
        object result = cmd.ExecuteScalar();
        con.Close();
        return (byte[])result;
    }

}
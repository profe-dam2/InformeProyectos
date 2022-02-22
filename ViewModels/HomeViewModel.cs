using Microsoft.Reporting.WinForms;
using InformeProyectos.Services.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace InformeProyectos.ViewModels
{
    public class HomeViewModel:ViewModelBase
    {
        public string pdfData { set; get; }
        ReportViewer myReport { set; get; }
        ReportDataSource rds { set; get; }
        
        //public int idDpto;
        public HomeViewModel()
        {
            myReport = new ReportViewer();
            rds = new ReportDataSource();

        }

        public bool GenerarInforme(int idDpto)
        {
            rds.Name = "InformeDpto";
            DataTable informeDataTable = DataSetHandler.GetByIdDpto(idDpto);
            if (informeDataTable.Rows.Count > 0)
            {
                rds.Value = informeDataTable;
                myReport.LocalReport.DataSources.Add(rds);
                myReport.LocalReport.ReportPath = "../../Reports/InformeDpto.rdlc";
                byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
                pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
                return true;
            }
            else
            {
                MessageBox.Show("No hay datos suficientes para generar el informe");
                return false;
            }
            
            //pdfData = "data:application/pdf;base64," + "JVBERi0xLjMNCjEgMCBvYmoNClsvUERGIC9UZXh0IC9JbWFnZUIgL0ltYWdlQyAvSW1hZ2VJXQ0KZW5kb2JqDQo1IDAgb2JqDQo8PCAvTGVuZ3RoIDcwNCAvRmlsdGVyIC9GbGF0ZURlY29kZSA + PiBzdHJlYW0NClgJvVdNb9pAEL1H4j / Mse1hs9 / 2HtMWqkohIcRSDlUPFLsVVcCpiRSlv76zNp6sYxNioBESRoPnzZu3z7PrwckfMJZZp0DIuLzqWLDYgYk1M1xDkcENrAb + vup / GylmpANtNeMgDeM8prs + JnA6QizHnHOQ / ARefopf4LhhWhlIzkGYiCntwMYcQxEkKbz7ejG6nI6H8Hk4OZsmZ + PhRXL5HpLfkHyAYTI4ufIMBFfMcgUmMkxGDilLFlsLQrVJaGhz0EaySMQlBw + FtU3kmOSm5LDKlz8QY7i8u81mad4qLxXyte4Y5T2U4aJRPl0U2Xy + yFfbGSivHIp4BAYllDVdAkyK / DGb37fLk / 5oBRmJo + hvJZNCleVHxWw1X6znOUyyIvu7Xf / Dy5P + QflPp + PZY16AlNt1P7wy6R5UrgWHm8UqzR / W24XXgkmrjiK8RgtJUdYfz4r7GZzndy + JfnhpEj0o7UVPi0UKSm9X / fDSpHpQeofqnMUygvB7 + gV / GHiAb9 + xQIpS4qQ0uCqOM46SLtE6MTNOU + QWrvcDoggOW2H0C0ACh3AbCNP8fAgYbSKvBPJp5ao3WquG3y5GjdZ8mtI6AFIGNwL7ComORqgFVBIiiWpC / RTyWaU5G41Vw7mXQj4NHfmE4zdgZ2RfhQ4h1ALyhEggIrRToUZjz / toAr2Rq7ufM0zTeLYJnjM8BAk0QV9GmOb3g4DRJtLX1sSIIv0YhUBPGtVAFSPyQztCOq7 / s0O6LUvdhxR7dF8TouUgQjuXo9uyRCgEeiODdFsW05SzoWWVYwYPEH2BNmkBo51A3U4jRhTpD1ROYtKonsR7PkN7EOreq0iimlC / xkITV4Qo0h9oT1sfjVDnXkUCEaF + OGEfFaFOoPIUuHk93Vw2b6eRxP7qA2B4W4SHQ + Ginfc9h4sbL7tX / wAUPSY6DQplbmRzdHJlYW0NCmVuZG9iag0KMiAwIG9iag0KPDwgL1R5cGUgL1BhZ2UgL1BhcmVudCA2IDAgUiAvTWVkaWFCb3ggWzAgMCA1OTUuMjc2IDg0MS44OV0gL0NvbnRlbnRzIDUgMCBSIC9SZXNvdXJjZXMgPDwgL1Byb2NTZXQgMSAwIFIgL1hPYmplY3QgPDwgPj4gL0ZvbnQgPDwgL0YzIDMgMCBSIC9GNCA0IDAgUiA + PiA + PiA + Pg0KZW5kb2JqDQozIDAgb2JqDQo8PCAvVHlwZSAvRm9udCAvU3VidHlwZSAvVHlwZTEgL0Jhc2VGb250IC9IZWx2ZXRpY2EtQm9sZCAvRW5jb2RpbmcgL1dpbkFuc2lFbmNvZGluZyA + Pg0KZW5kb2JqDQo0IDAgb2JqDQo8PCAvVHlwZSAvRm9udCAvU3VidHlwZSAvVHlwZTEgL0Jhc2VGb250IC9IZWx2ZXRpY2EgL0VuY29kaW5nIC9XaW5BbnNpRW5jb2RpbmcgPj4NCmVuZG9iag0KNiAwIG9iag0KPDwgL1R5cGUgL1BhZ2VzIC9LaWRzIFsgMiAwIFIgXSAvQ291bnQgMSA + Pg0KZW5kb2JqDQo3IDAgb2JqDQo8PCAvVHlwZSAvQ2F0YWxvZyAvUGFnZXMgNiAwIFIgPj4NCmVuZG9iag0KOCAwIG9iag0KPDwgL1RpdGxlIDxmZWZmMDA0OTAwNmUwMDY2MDA2ZjAwNzIwMDZkMDA2NTAwNDQwMDcwMDA3NDAwNmY + DQovQXV0aG9yIDw + DQovU3ViamVjdCA8Pg0KL0NyZWF0b3IgKE1pY3Jvc29mdCBSZXBvcnRpbmcgU2VydmljZXMgMTUuMC4wLjApDQovUHJvZHVjZXIgKE1pY3Jvc29mdCBSZXBvcnRpbmcgU2VydmljZXMgUERGIFJlbmRlcmluZyBFeHRlbnNpb24gMTUuMC4wLjApDQovQ3JlYXRpb25EYXRlIChEOjIwMjIwMjA0MTIwMjQxKzAxJzAwJykNCj4 + DQplbmRvYmoNCnhyZWYNCjAgOQ0KMDAwMDAwMDAwMCA2NTUzNSBmDQowMDAwMDAwMDEwIDAwMDAwIG4NCjAwMDAwMDA4NDYgMDAwMDAgbg0KMDAwMDAwMTAyMiAwMDAwMCBuDQowMDAwMDAxMTI3IDAwMDAwIG4NCjAwMDAwMDAwNjUgMDAwMDAgbg0KMDAwMDAwMTIyNyAwMDAwMCBuDQowMDAwMDAxMjg5IDAwMDAwIG4NCjAwMDAwMDEzNDEgMDAwMDAgbg0KdHJhaWxlciA8PCAvU2l6ZSA5IC9Sb290IDcgMCBSIC9JbmZvIDggMCBSID4 + DQpzdGFydHhyZWYNCjE2MTUNCiUlRU9G";
        }

        public void GenerarInformeFechas(string fecha1, string fecha2)
        {
            rds.Name = "InformeFechas";
            rds.Value = DataSetHandler.GetByFechas(fecha1, fecha2);
            myReport.LocalReport.DataSources.Add(rds);
            myReport.LocalReport.ReportPath = "../../Reports/InformeFechas.rdlc";
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
        }

        public void GenerarInformeDptoProyecto(int idDpto, int idProyecto)
        {
            rds.Name = "InformeProyecto";
            rds.Value = DataSetHandler.GetByDptoProyecto(idDpto, idProyecto);
            myReport.LocalReport.DataSources.Add(rds);
            myReport.LocalReport.ReportPath = "../../Reports/InformeProyecto.rdlc";
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
        }


    }
    
}

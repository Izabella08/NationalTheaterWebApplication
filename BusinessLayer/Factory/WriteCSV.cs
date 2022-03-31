using BusinessLayer.Contracts;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Factory
{
    public class WriteCSV : IWriter
    {
        private readonly ITicketService ticketService;

        public WriteCSV(ITicketService ticketService)
        {
            this.ticketService = ticketService;

        }

        public void ExportTickets(int showID)
        {
            List<TicketModel> tickets = ticketService.GetAllTickets();
            MemoryStream mem = new MemoryStream();
            StreamWriter writer = new StreamWriter(mem);
            var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture);

            csvWriter.WriteField("Ticket ID");
            csvWriter.WriteField("Seat Row");
            csvWriter.WriteField("Seat Number");
            csvWriter.NextRecord();

            foreach (var t in tickets)
            {
                if (t.Show.Id == showID)
                {
                    csvWriter.WriteField(t.Id);
                    csvWriter.WriteField(t.SeatRow);
                    csvWriter.WriteField(t.SeatNumber);
                    csvWriter.NextRecord();
                }
            }
            writer.Flush();

            var res = Encoding.UTF8.GetString(mem.ToArray());
            File.WriteAllText("D:\\AN3\\an3_sem2\\PS Proiectare Software\\UTCNSoftwareDesignLab\\lab3\\C#\\LayersOnWeb\\tickets.csv", res);
            Console.WriteLine(res);
        }
    }
}

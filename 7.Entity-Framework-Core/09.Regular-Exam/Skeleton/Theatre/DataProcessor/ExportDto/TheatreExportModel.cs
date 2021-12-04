using System.Collections.Generic;

namespace Theatre.DataProcessor.ExportDto
{
    public class TheatreExportModel
    {
        public string Name { get; set; }

        public int Halls { get; set; }

        public decimal TotalIncome { get; set; }

        public ICollection<TicketExportModel> Tickets { get; set; }
    }
}

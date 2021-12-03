using System.Collections.Generic;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class UserOutputModel
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public List<PurchaseOutputModel> Purchases { get; set; }

        public decimal TotalSpent { get; set; }
    }
}
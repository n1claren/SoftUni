using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchaseInputModel
    {
        [Required]
        [XmlAttribute("title")]
        public string Game { get; set; }

        [Required]
        [XmlElement("Type")]
        public string Type { get; set; }

        [Required]
        [XmlElement("Key")]
        [RegularExpression("([A-z]*[0-9]*){4}-([A-z]*[0-9]*){4}-([A-z]*[0-9]*){4}")]
        [StringLength(14, MinimumLength = 14)]
        public string ProductKey { get; set; }

        [Required]
        [XmlElement("Card")]
        [RegularExpression("[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}")]
        public string Card { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }
    }
}

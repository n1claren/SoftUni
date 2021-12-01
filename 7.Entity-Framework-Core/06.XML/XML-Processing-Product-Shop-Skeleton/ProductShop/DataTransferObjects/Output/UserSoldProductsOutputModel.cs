using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Output
{
    [XmlType("User")]
    public class UserSoldProductsOutputModel
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public SoldProducts[] SoldProducts { get; set; }
    }
}

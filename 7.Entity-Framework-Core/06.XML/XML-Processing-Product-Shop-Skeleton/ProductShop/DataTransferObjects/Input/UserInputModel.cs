using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Input
{
    [XmlType("User")]
    public class UserInputModel
    {
        [XmlAttribute("firstName")]
        public string FirstName { get; set; }

        [XmlAttribute("lastName")]
        public string LastName { get; set; }

        [XmlAttribute("age")]
        public int Age { get; set; }
    }
}
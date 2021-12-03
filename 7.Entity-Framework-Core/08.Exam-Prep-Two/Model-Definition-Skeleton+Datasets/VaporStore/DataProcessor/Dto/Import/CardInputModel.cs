using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class CardInputModel
    {
        [Required]
        [RegularExpression("[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}")]
        public string Number { get; set; }

        [Required]
        [RegularExpression("[0-9]{3}")]
        [StringLength(3, MinimumLength = 3)]
        public string CVC { get; set; }

        [Required]
        public string Type { get; set; }
    }
}

//{
//	"FullName": "",
//		"Username": "invalid",
//		"Email": "invalid@invalid.com",
//		"Age": 20,
//		"Cards": [
//			{
//		"Number": "1111 1111 1111 1111",
//				"CVC": "111",
//				"Type": "Debit"
//			}
//		]
//	}
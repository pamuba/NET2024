using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebApplication.Security
{
    public class DomainModel
    {
        public int BankId { get; set; }

        [NotMapped]
        public string DecodeId { get; set; }
    }
}

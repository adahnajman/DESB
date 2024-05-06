using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Exercise.Entities
{
    public class tblLogin
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public string? SessionID { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}

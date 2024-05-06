using System.ComponentModel.DataAnnotations;

namespace Exercise.Entities
{
    public class TblUser
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? userFullName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}

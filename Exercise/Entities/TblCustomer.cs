using System.ComponentModel.DataAnnotations;

namespace Exercise.Entities
{
    public class TblCustomer
    {
        [Key]
        public int? Id { get; set; }
        public string? CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAddress1 { get; set; }
        public string? CustomerAddress2 { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? Language { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

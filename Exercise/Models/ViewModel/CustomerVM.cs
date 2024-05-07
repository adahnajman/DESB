using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace Exercise.Models.ViewModel
{
    public class CustomerVM
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Required Text")]
        public string? CustomerID { get; set; }

        [Required(ErrorMessage = "Required Text")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Required Text")]
        public string? CustomerAddress1 { get; set; }
        public string? CustomerAddress2 { get; set;}

        [Required(ErrorMessage = "Required Text")]
        public string? PhoneNo { get; set; }

        [Required(ErrorMessage = "Required Text")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Required Text")]
        public List<string>? Language { get; set; }

        [Required(ErrorMessage = "Required Text")]
        public double? Height { get; set; }

        [Required(ErrorMessage = "Required Text")]
        public double? Weight { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set;}
    }

    public class SearchVM
    {
        public string data { get; set; }
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

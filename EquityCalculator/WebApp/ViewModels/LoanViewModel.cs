using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class LoanViewModel
    {
        [Required(ErrorMessage="Please enter valid Selling Price")]
        public decimal? sellingPrice { get; set; }

        [Required(ErrorMessage="Please enter valid Reservation Date")]
        public DateOnly? reserveDate { get; set; }

        [Required(ErrorMessage="Please enter valid Equity Term")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter an Equity Term bigger than {1}")]
        public int? equityTerm { get; set; }
    }
}

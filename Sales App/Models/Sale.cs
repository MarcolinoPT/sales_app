namespace SalesApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    class Sale : BaseModel
    {
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual SalesPerson Person { get; set; }

        [Required]
        public int PersonId { get; set; }

        public virtual SalesRegion Region { get; set; }

        [Required]
        public int RegionId { get; set; }
    }
}

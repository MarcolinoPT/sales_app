namespace SalesApp.Models
{
    using SalesApp.Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    class SalesRegion : BaseModel, IActive
    {
        [Index(IsUnique = true)]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(3)]
        public string Code { get; set; }

        [Required]
        public bool Active { get; set; }

        public virtual ObservableListSource<SalesPerson> People { get; set; }

        public virtual ObservableListSource<Sale> Sales { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal SalesTarget { get; set; }
    }
}

namespace SalesApp.Models
{
    using SalesApp.Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    class SalesPerson : BaseModel, IActive
    {
        [Index(name: nameof(FullName), Order = 2)]
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Index(name: nameof(FullName), Order = 1)]
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        public bool Active { get; set; }

        public virtual SalesRegion Region { get; set; }

        [Required]
        public int RegionId { get; set; }

        public virtual ObservableListSource<Sale> Sales { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal SalesTarget { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}".Trim();
            }
        }

    }
}

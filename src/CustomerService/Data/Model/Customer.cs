using System;
using System.Collections.Generic;
using CustomerService.Data.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerService.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class Customer: ILoggable
    {
        public int Id { get; set; }
        
		[ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        
		[Index("NameIndex", IsUnique = false)]
        [Column(TypeName = "VARCHAR")]        
		public string Name { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string PostalCode { get; set; }

        public string EmailAddress { get; set; }

        public string Mobile { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedOn { get; set; }
        
		public DateTime LastModifiedOn { get; set; }
        
		public string CreatedBy { get; set; }
        
		public string LastModifiedBy { get; set; }

        public ICollection<PhotoGalleryRef> PhotoGalleryRefs { get; set; } = new HashSet<PhotoGalleryRef>();

        public ICollection<QuoteRef> QuoteRefs { get; set; } = new HashSet<QuoteRef>();

        public ICollection<OrderRef> OrderRefs { get; set; } = new HashSet<OrderRef>();
        
        public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}

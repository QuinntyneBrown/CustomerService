using CustomerService.Data.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomerService.Features.Customers
{
    public class CustomerApiModel
    {        
        public int Id { get; set; }

        public int? TenantId { get; set; }

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

        public ICollection<QuoteRefApiModel> QuoteRefs { get; set; } = new HashSet<QuoteRefApiModel>();

        public ICollection<OrderRefApiModel> OrderRefs { get; set; } = new HashSet<OrderRefApiModel>();

        public ICollection<PhotoGalleryRefApiModel> PhotoGalleryRefs { get; set; } = new HashSet<PhotoGalleryRefApiModel>();

        public static TModel FromCustomer<TModel>(Customer customer) where
            TModel : CustomerApiModel, new()
        {
            var model = new TModel();

            model.Id = customer.Id;

            model.TenantId = customer.TenantId;

            model.Name = customer.Name;

            model.Firstname = customer.Firstname;

            model.Lastname = customer.Lastname;

            model.Address = customer.Address;

            model.City = customer.City;

            model.Province = customer.Province;

            model.PostalCode = customer.PostalCode;

            model.Mobile = customer.Mobile;

            model.PhoneNumber = customer.PhoneNumber;

            model.QuoteRefs = customer.QuoteRefs.Select(x => QuoteRefApiModel.FromQuoteRef(x)).ToList();

            model.OrderRefs = customer.OrderRefs.Select(x => OrderRefApiModel.FromOrderRef(x)).ToList();

            model.PhotoGalleryRefs = customer.PhotoGalleryRefs.Select(x => PhotoGalleryRefApiModel.FromPhotoGalleryRef(x)).ToList();

            return model;
        }

        public static CustomerApiModel FromCustomer(Customer customer)
            => FromCustomer<CustomerApiModel>(customer);

    }
}

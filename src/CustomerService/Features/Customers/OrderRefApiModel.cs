using CustomerService.Data.Model;

namespace CustomerService.Features.Customers
{
    public class OrderRefApiModel
    {        
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public int? CustomerId { get; set; }

        public static TModel FromOrderRef<TModel>(OrderRef orderRef) where
            TModel : OrderRefApiModel, new()
        {
            var model = new TModel();
            model.Id = orderRef.Id;
            model.TenantId = orderRef.TenantId;
            model.Name = orderRef.Name;
            model.CustomerId = orderRef.CustomerId;
            return model;
        }

        public static OrderRefApiModel FromOrderRef(OrderRef orderRef)
            => FromOrderRef<OrderRefApiModel>(orderRef);

    }
}

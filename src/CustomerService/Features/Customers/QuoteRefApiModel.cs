using CustomerService.Data.Model;

namespace CustomerService.Features.Customers
{
    public class QuoteRefApiModel
    {        
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string Name { get; set; }

        public static TModel FromQuoteRef<TModel>(QuoteRef quoteRef) where
            TModel : QuoteRefApiModel, new()
        {
            var model = new TModel();
            model.Id = quoteRef.Id;
            model.TenantId = quoteRef.TenantId;
            model.Name = quoteRef.Name;
            return model;
        }

        public static QuoteRefApiModel FromQuoteRef(QuoteRef quoteRef)
            => FromQuoteRef<QuoteRefApiModel>(quoteRef);

    }
}

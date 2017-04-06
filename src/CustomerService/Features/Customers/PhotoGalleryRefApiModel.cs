using CustomerService.Data.Model;

namespace CustomerService.Features.Customers
{
    public class PhotoGalleryRefApiModel
    {        
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string Name { get; set; }

        public static TModel FromPhotoGalleryRef<TModel>(PhotoGalleryRef photoGalleryRef) where
            TModel : PhotoGalleryRefApiModel, new()
        {
            var model = new TModel();
            model.Id = photoGalleryRef.Id;
            model.TenantId = photoGalleryRef.TenantId;
            model.Name = photoGalleryRef.Name;
            return model;
        }

        public static PhotoGalleryRefApiModel FromPhotoGalleryRef(PhotoGalleryRef photoGalleryRef)
            => FromPhotoGalleryRef<PhotoGalleryRefApiModel>(photoGalleryRef);

    }
}

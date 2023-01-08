using ProductAPI.ModelRequest;
using ProductAPI.Repository;
using ProductAPI.ViewModel;

namespace ProductAPI.Service
{
    public interface IProductService
    {
        ResponsePostView CreateProduct(CreateProductRequest request);
        ResponsePostView UpdateProduct(CreateProductRequest request);
        ResponsePostView DeleteProduct(int productId);
        ResponseViewModel GetListProductByCategoryId(int categoryId);

    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productrepository;

        public ProductService(IProductRepository productrepository)
        {
            _productrepository = productrepository;
        }
        public ResponsePostView CreateProduct(CreateProductRequest request)
        {
            var result = _productrepository.CreateProduct(request);
            return result;
        }

        public ResponsePostView DeleteProduct(int productId)
        {
            var result = _productrepository.DeleteProduct(productId);
            return result;
        }

        public ResponseViewModel GetListProductByCategoryId(int categoryId)
        {
            var result = _productrepository.GetListProductByCategoryId(categoryId);
            return result;
        }

        public ResponsePostView UpdateProduct(CreateProductRequest request)
        {
            var result = _productrepository.UpdateProduct(request);
            return result;
        }
    }
}

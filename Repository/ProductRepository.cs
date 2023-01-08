using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.ModelRequest;
using ProductAPI.Models;
using ProductAPI.ViewModel;
using System.Linq;
namespace ProductAPI.Repository
{
    public interface IProductRepository
    {
        ResponsePostView CreateProduct(CreateProductRequest request);
        ResponsePostView UpdateProduct(CreateProductRequest request);
        ResponsePostView DeleteProduct(int productId);
        ResponseViewModel GetListProductByCategoryId(int categoryId);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly ILogger<ProductRepository> _logger;
        private readonly DataDbcontext _context;
        public ProductRepository(DataDbcontext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public ResponsePostView CreateProduct(CreateProductRequest request)
        {
            try
            {
                _logger.LogInformation("{@input}", request);
                var checkExist = _context.Product.FirstOrDefault(c => c.Name == request.Name && request.Price == c.Price);
                if (checkExist != null)
                {
                    return new ResponsePostView("Sản phẩm đã tồn tại", 400, false);
                }
                _context.Product.Add(new Product
                {
                    Name = request.Name,
                    Price = request.Price,
                    imageUrl = request.imageUrl,
                    Desc = request.Desc,
                    CategoryId = request.CategoryId
                });
                _context.SaveChanges();
                return new ResponsePostView("Tạo sản phẩm thành công", 200, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("{@error}", ex);
                return new ResponsePostView("Lỗi trong quá trình Thêm dữ liệu", 400, false);
            }

        }
        public ResponsePostView UpdateProduct(CreateProductRequest request)
        {
            try
            {
                _logger.LogInformation("{@input}", request);
                var checkExist = _context.Product.FirstOrDefault(c => c.ProductId == request.Id);
                if (checkExist == null)
                {
                    return new ResponsePostView("Sản phẩm chưa tồn tại", 400, false);
                }
                checkExist.Name = request.Name;
                checkExist.Price = request.Price;
                checkExist.imageUrl = request.imageUrl;
                checkExist.Desc = request.Desc;
                checkExist.CategoryId = request.CategoryId;
                _context.SaveChanges();
                return new ResponsePostView("Cập nhật sản phẩm thành công", 200, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("{@error}", ex);
                return new ResponsePostView("Lỗi trong quá trình cập nhật dữ liệu", 400, false);
            }

        }
        public ResponsePostView DeleteProduct(int productId)
        {
            try
            {
                if(productId == null)
                {
                    return new ResponsePostView("Id không được null", 400, false);
                }    
                _logger.LogInformation("{@input}", productId);
                var checkExist = _context.Product.FirstOrDefault(c => c.ProductId == productId);
                if (checkExist == null)
                {
                    return new ResponsePostView("Sản phẩm chưa tồn tại", 400, false);
                }
                _context.Product.Remove(checkExist);
                _context.SaveChanges();
                return new ResponsePostView("Xóa Sản phẩm thành công", 200, true);
            }
            catch (Exception e)
            {
                _logger.LogError("{@error}", e);
                return new ResponsePostView("Có lỗi khi thực hiện xóa", 400, false);
            }
        }
        public ResponseViewModel GetListProductByCategoryId(int categoryId)
        {
            try 
            {
                _logger.LogInformation("{@input}", categoryId);
                if (categoryId == null)
                {
                    return new ResponseViewModel("Id không được null", 400,null, false);
                }
                var listResult = (from c in _context.Product.Where(c => c.CategoryId == categoryId)
                                 join b in _context.Category.AsNoTracking() on c.CategoryId equals categoryId
                                 select new ProductViewModel
                                 {
                                     CategoryId = b.CategoryId,
                                     ProductId = c.ProductId,
                                     Name = c.Name,
                                     Desc = c.Desc,
                                     imageUrl = c.imageUrl,
                                     Price = c.Price,
                                     CategoryStatus = b.Status,
                                     CategoryTitle = b.Title
                                 }).ToList();
                
                return new ResponseViewModel("Lấy dữ liệu thành công", 200, listResult.OrderBy(c => c.Name), true);
            }
            catch(Exception ex)
            {
                _logger.LogError("Lỗi:", ex);
                return new ResponseViewModel("Lỗi quá trình lấy dữ liệu", 400, null, false);
            }
        }
    }
}

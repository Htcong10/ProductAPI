using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data;
using ProductAPI.ModelRequest;
using ProductAPI.Models;
using ProductAPI.ViewModel;

namespace ProductAPI.Repository
{
    public interface ICategoryRepository
    {
        ResponsePostView CreateCategory(CreateCategoryModel request);
        ResponsePostView UpdateCategory(CreateCategoryModel request);
        ResponsePostView DeleteCategory(int categoryId);
        ResponseViewModel GetAllCategory();
    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataDbcontext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductRepository> _logger;
        public CategoryRepository(DataDbcontext product,IMapper mapper, ILogger<ProductRepository> logger)
        {
            _context = product;
            _mapper = mapper;
            _logger = logger;
        }
        public ResponsePostView CreateCategory(CreateCategoryModel request)
        {
            try
            {
                _logger.LogInformation("{@input}", request);
                var checkExist = _context.Category.FirstOrDefault(c => c.Title == request.Title);
                if (checkExist != null)
                {
                    return new ResponsePostView("Dữ liệu đã tồn tại đã tồn tại", 400, false);
                }
                var reviewerCategory = _mapper.Map<Category>(request);
                _context.Category.Add(reviewerCategory);
                _context.SaveChanges();
                return new ResponsePostView("Tạo dữ liệu thành công", 200, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("{@error}", ex);
                return new ResponsePostView("Lỗi trong quá trình thêm dữ liệu", 400, false);
            }
        }
        public ResponsePostView UpdateCategory(CreateCategoryModel request)
        {
            try
            {
                _logger.LogInformation("{@input}", request);
                var checkExist = _context.Category.FirstOrDefault(c => c.CategoryId == request.Id);
                if (checkExist == null)
                {
                    return new ResponsePostView("Dữ liệu chưa tồn tại", 400, false);
                }
                checkExist.Title = request.Title;
                checkExist.Status = request.Status;
                _context.SaveChanges();
                return new ResponsePostView("Cập nhật dữ liệu thành công", 200, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("{@error}", ex);
                return new ResponsePostView("Lỗi trong quá trình cập nhật dữ liệu", 400, false);
            }

        }
        public ResponsePostView DeleteCategory(int categoryId)
        {
            try
            {
                if (categoryId == null)
                {
                    return new ResponsePostView("Id không được null", 400, false);
                }
                _logger.LogInformation("{@input}", categoryId);
                var checkExist = _context.Category.FirstOrDefault(c => c.CategoryId == categoryId);
                if (checkExist == null)
                {
                    return new ResponsePostView("Dữ liệu chưa tồn tại", 400, false);
                }
                _context.Category.Remove(checkExist);
                _context.SaveChanges();
                return new ResponsePostView("Xóa dữ liệu thành công", 200, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("{@error}", ex);
                return new ResponsePostView("Có lỗi khi thực hiện xóa", 400, false);
            }
        }
        public ResponseViewModel GetAllCategory()
        {
            try
            {
                var listCategory = _context.Category.ToList();
                if (listCategory.Count() == 0)
                {
                    return new ResponseViewModel("Không có dữ liệu", 400,null, false);
                }
                return new ResponseViewModel("Lấy dữ liệu thành công", 200, listCategory, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("{@error}", ex);
                return new ResponseViewModel("Có lỗi khi thực hiện lấy dữ liệu", 400,null, false);
            }
        }
    }
}

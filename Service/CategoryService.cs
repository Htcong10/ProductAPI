using ProductAPI.ModelRequest;
using ProductAPI.Repository;
using ProductAPI.ViewModel;

namespace ProductAPI.Service
{
    public interface ICategoryServivce
    {
        ResponsePostView CreateCategory(CreateCategoryModel request);
        ResponsePostView UpdateCategory(CreateCategoryModel request);
        ResponsePostView DeleteCategory(int categoryId);
        ResponseViewModel GetAllCategory();
    }
    public class CategoryService : ICategoryServivce
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public ResponsePostView CreateCategory(CreateCategoryModel request)
        {
            var result = _repository.CreateCategory(request);
            return result;
        }

        public ResponsePostView DeleteCategory(int categoryId)
        {
            var result = _repository.DeleteCategory(categoryId);
            return result;
        }

        public ResponseViewModel GetAllCategory()
        {
            var result = _repository.GetAllCategory();
            return result;
        }

        public ResponsePostView UpdateCategory(CreateCategoryModel request)
        {
            var result = _repository.UpdateCategory(request);
            return result;
        }
    }
}

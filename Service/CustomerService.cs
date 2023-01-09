using ProductAPI.ModelRequest;
using ProductAPI.Repository;
using ProductAPI.ViewModel;

namespace ProductAPI.Service
{
    public interface ICustomerService
    {
        ResponsePostView CreateCustomer(CreateCustomerRequest request);
        ResponsePostView UpdateCustomer(CreateCustomerRequest request);
        ResponsePostView DeleteCustomer(CreateCustomerRequest request);
        ResponseViewModel GetAllCustomer();
        ResponseViewModel GetCustomerBy(GetCustomerRequest request);
        ResponseViewModel GetBillByCustomer(GetBillByCustomerRequest request);
    }
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public ResponsePostView CreateCustomer(CreateCustomerRequest request)
        {
            var result = _repository.CreateCustomer(request);
            return result;
        }

        public ResponsePostView DeleteCustomer(CreateCustomerRequest request)
        {
            var result = _repository.DeleteCustomer(request);
            return result;
        }

        public ResponseViewModel GetAllCustomer()
        {
            var result = _repository.GetAllCustomer();
            return result;
        }

        public ResponseViewModel GetBillByCustomer(GetBillByCustomerRequest request)
        {
            var result = _repository.GetBillByCustomer(request);
            return result;
        }

        public ResponseViewModel GetCustomerBy(GetCustomerRequest request)
        {
            var result = _repository.GetCustomerBy(request);
            return result;
        }

        public ResponsePostView UpdateCustomer(CreateCustomerRequest request)
        {
            var result = _repository.UpdateCustomer(request);
            return result;
        }
    }
}

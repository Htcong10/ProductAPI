using ProductAPI.Data;
using ProductAPI.ModelRequest;
using ProductAPI.ViewModel;

namespace ProductAPI.Repository
{
    public interface ICustomerRepository
    {
        ResponsePostView CreateCustomer(CreateCustomerRequest request);
        ResponsePostView UpdateCustomer(CreateCustomerRequest request);
        ResponsePostView DeleteCustomer(CreateCustomerRequest request);
        ResponseViewModel GetAllCustomer();
        ResponseViewModel GetCustomerBy(GetCustomerRequest request);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ILogger<ProductRepository> _logger;
        private readonly DataDbcontext _context;
        public CustomerRepository(DataDbcontext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public ResponsePostView CreateCustomer(CreateCustomerRequest request)
        {
            try 
            { 
            }
            catch (Exception ex)
            {

            }
        }

        public ResponsePostView DeleteCustomer(CreateCustomerRequest request)
        {
            throw new NotImplementedException();
        }

        public ResponseViewModel GetAllCustomer()
        {
            throw new NotImplementedException();
        }

        public ResponseViewModel GetCustomerBy(GetCustomerRequest request)
        {
            throw new NotImplementedException();
        }

        public ResponsePostView UpdateCustomer(CreateCustomerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

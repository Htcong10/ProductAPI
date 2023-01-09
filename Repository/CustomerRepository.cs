using AutoMapper;
using ProductAPI.Data;
using ProductAPI.ModelRequest;
using ProductAPI.Models;
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
        ResponseViewModel GetBillByCustomer(GetBillByCustomerRequest request);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ILogger<ProductRepository> _logger;
        private readonly DataDbcontext _context;
        private readonly IMapper _mapper;
        public CustomerRepository(DataDbcontext context, ILogger<ProductRepository> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        public ResponsePostView CreateCustomer(CreateCustomerRequest request)
        {
            try 
            {
                _logger.LogInformation("{@input}", request);
                var checkExist = _context.Customer.FirstOrDefault(c => c.number == request.number && c.Name == request.Name);
                if (checkExist != null)
                {
                    return new ResponsePostView("Dữ liệu đã tồn tại", 400, false);
                }
                var revieweCustomer= _mapper.Map<Customer>(request);
                _context.Customer.Add(revieweCustomer);
                _context.SaveChanges();
                return new ResponsePostView("Tạo dữ liệu thành công", 200, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("{@error}", ex);
                return new ResponsePostView("Lỗi trong quá trình thêm dữ liệu", 400, false);

            }
        }

        public ResponsePostView DeleteCustomer(CreateCustomerRequest request)
        {
            try
            {
                _logger.LogInformation("{@input}", request);
                var checkExist = _context.Customer.FirstOrDefault(c => c.number == request.number && c.Name == request.Name);
                if (checkExist == null)
                {
                    return new ResponsePostView("Dữ liệu chưa tồn tại", 400, false);
                }
                _context.Customer.Remove(checkExist);
                _context.SaveChanges();
                return new ResponsePostView("Xóa dữ liệu thành công", 200, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("{@error}", ex);
                return new ResponsePostView("Lỗi trong quá trình xóa dữ liệu", 400, false);

            }
        }

        public ResponseViewModel GetAllCustomer()
        {
            try
            {
                var listCustomer = _context.Customer.ToList();
                if (listCustomer.Count() == 0)
                {
                    return new ResponseViewModel("Không có dữ liệu", 400, null, false);
                }
                return new ResponseViewModel("Lấy dữ liệu thành công", 200, listCustomer.OrderBy(c => c.Name), true);
            }
            catch (Exception ex)
            {
                _logger.LogError("{@error}", ex);
                return new ResponseViewModel("Có lỗi khi thực hiện lấy dữ liệu", 400, null, false);
            }
        }

        public ResponseViewModel GetCustomerBy(GetCustomerRequest request)
        {
            var listCustomer = _context.Customer.AsEnumerable();
            if (listCustomer == null)
            {
                return new ResponseViewModel("Không có dữ liệu", 400, null, false);
            }
            else
            {
                if (request.Name != null)
                {
                    listCustomer = listCustomer.Where(c => c.Name == request.Name);
                }
                if (request.number != null)
                {
                    listCustomer = listCustomer.Where(c => c.number == request.number);
                }
                if (request.Name != null)
                {
                    listCustomer = listCustomer.Where(c => c.email == request.email);
                }
                return new ResponseViewModel("Lấy dữ liệu thành công", 200, listCustomer.OrderBy(c => c.Name), true);
            }
        }

        public ResponsePostView UpdateCustomer(CreateCustomerRequest request)
        {
            
            try
            {
                _logger.LogInformation("{@input}", request);
                var checkExist = _context.Customer.FirstOrDefault(c => c.Name == request.Name && c.number == request.number);
                if (checkExist == null)
                {
                    return new ResponsePostView("Dữ liệu chưa tồn tại", 400, false);
                }
                var customerMap = _mapper.Map<Customer>(request);
                _context.Customer.Update(customerMap);
                _context.SaveChanges();
                return new ResponsePostView("Cập nhật dữ liệu thành công", 200, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("{@error}", ex);
                return new ResponsePostView("Lỗi trong quá trình cập nhật dữ liệu", 400, false);
            }
        }
        public ResponseViewModel GetBillByCustomer(GetBillByCustomerRequest request)
        {
            _logger.LogInformation("{@input}", request);
            var checkExist = _context.Customer.FirstOrDefault(c => c.number == request.number && c.Name == request.Name);
            if (checkExist == null)
            {
                return new ResponseViewModel("Không có dữ liệu", 400, null, false);
            }
            else
            {
                var listBill = _context.CustomerBill.Where(c => c.customerId == checkExist.CustomerId);
                if(request.fromDate.HasValue)
                {
                    listBill = listBill.Where(c => c.billDate >= request.fromDate);
                }
                if (request.toDate.HasValue)
                {
                    listBill = listBill.Where(c => c.billDate <= request.toDate);
                }
                return new ResponseViewModel("Lấy dữ liệu thành công", 200, listBill.OrderBy(c => c.billDate), true);
            }
        }
    }
}

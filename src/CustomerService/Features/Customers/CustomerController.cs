using CustomerService.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

using static CustomerService.Features.Customers.AddOrUpdateCustomerCommand;
using static CustomerService.Features.Customers.GetCustomersQuery;
using static CustomerService.Features.Customers.GetCustomerByIdQuery;
using static CustomerService.Features.Customers.RemoveCustomerCommand;
using static CustomerService.Features.Customers.RegisterCustomerCommand;
using static CustomerService.Features.Customers.CreateCustomerIfDoesNotExistCommand;
using static CustomerService.Features.Customers.GetCustomerByEmailQuery;

namespace CustomerService.Features.Customers
{
    [Authorize]
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateCustomerResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateCustomerRequest request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("createifdoesnotexist")]
        [HttpPost]
        [AllowAnonymous]
        [ResponseType(typeof(CreateCustomerIfDoesNotExistResponse))]
        public async Task<IHttpActionResult> CreateIfDoesNotExist(CreateCustomerIfDoesNotExistRequest request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("register")]
        [HttpPost]
        [ResponseType(typeof(RegisterCustomerResponse))]
        public async Task<IHttpActionResult> Register(RegisterCustomerRequest request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateCustomerResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateCustomerRequest request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetCustomersResponse))]
        public async Task<IHttpActionResult> Get()
        {
            var request = new GetCustomersRequest();
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetCustomerByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetCustomerByIdRequest request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [AllowAnonymous]
        [Route("getByEmail")]
        [HttpGet]
        [ResponseType(typeof(GetCustomerByEmailResponse))]
        public async Task<IHttpActionResult> GetByEmail([FromUri]GetCustomerByEmailRequest request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveCustomerResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveCustomerRequest request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        protected readonly IMediator _mediator;
    }
}
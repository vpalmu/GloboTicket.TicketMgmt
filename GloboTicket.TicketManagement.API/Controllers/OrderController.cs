using GloboTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/getpagedordersformonth", Name = "GetPagedOrdersForMonth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetAuthenticationCredentialsResponse>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            var getOrdersForMonthQuery = new GetOrdersForMonthQuery() { Date = date, Page = page, Size = size };
            var response = await _mediator.Send(getOrdersForMonthQuery);

            return Ok(response);
        }
    }
}

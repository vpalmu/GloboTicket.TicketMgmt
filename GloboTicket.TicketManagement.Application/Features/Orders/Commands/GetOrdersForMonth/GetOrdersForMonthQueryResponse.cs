using GloboTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth;
using GloboTicket.TicketManagement.Application.Responses;

namespace GloboTicket.TicketManagement.Application.Features.Orders.Commands.GetOrdersForMonth
{
    public class GetOrdersForMonthQueryResponse : BaseResponse
    {
        public GetOrdersForMonthQueryResponse() : base()
        {

        }

        public PagedOrdersForMonthVm PagedOrdersForMonth { get; set; } = default!;
    }
}

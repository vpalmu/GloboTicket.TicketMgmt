using GloboTicket.TicketManagement.Application.Features.Orders.Commands.GetOrdersForMonth;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth
{
    public class GetOrdersForMonthQuery : IRequest<GetOrdersForMonthQueryResponse>
    {
        public DateTime Date { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}

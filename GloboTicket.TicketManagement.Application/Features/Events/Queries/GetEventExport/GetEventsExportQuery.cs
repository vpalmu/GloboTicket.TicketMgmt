using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventExport
{
    public class GetEventsExportQuery : IRequest<EventExportFileVm>
    {
    }
}

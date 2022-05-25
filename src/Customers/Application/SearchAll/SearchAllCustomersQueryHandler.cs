using Mapster;
using Rusell.Customers.Domain;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Customers.Application.SearchAll;

public class SearchAllCustomersQueryHandler : IQueryHandler<SearchAllCustomersQuery, IEnumerable<CustomerResponse>>
{
    private readonly ICustomerRepository _repository;

    public SearchAllCustomersQueryHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CustomerResponse>> Handle(SearchAllCustomersQuery query, CancellationToken cancellationToken)
    {
        var customers = await _repository.SearchAll();
        return customers.Adapt<IEnumerable<CustomerResponse>>();
    }
}
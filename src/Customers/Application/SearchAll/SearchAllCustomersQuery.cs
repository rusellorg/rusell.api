using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Customers.Application.SearchAll;

public record SearchAllCustomersQuery() : Query<IEnumerable<CustomerResponse>>;

using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Customers.Application.Find;

public record FindCustomerQuery(string Id) : Query<CustomerResponse?>;

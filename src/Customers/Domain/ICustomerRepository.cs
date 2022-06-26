using Rusell.Shared.Domain.Repository;

namespace Rusell.Customers.Domain;

public interface ICustomerRepository : IRepository<Customer, string>
{
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Rusell.Customers.Domain;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Customers.Application.Find
{
    public class FindCustomerQueryHandler : IQueryHandler<FindCustomerQuery, CustomerResponse?>
    {
        private readonly ICustomerRepository _repository;

        public FindCustomerQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<CustomerResponse?> Handle(FindCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.Find(request.Id);
            return customer?.Adapt<CustomerResponse>();
        }
    }
}

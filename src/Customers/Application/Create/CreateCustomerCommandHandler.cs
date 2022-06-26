using Mapster;
using Rusell.Customers.Domain;
using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Customers.Application.Create;

public class CreateCustomerCommandHandler : CommandHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    protected override async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = request.Adapt<Customer>();

        await _repository.Save(customer);
    }
}

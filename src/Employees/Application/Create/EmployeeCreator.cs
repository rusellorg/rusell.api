using Rusell.Employees.Domain;
using Mapster;
namespace Rusell.Employees.Application.Create;

public class EmployeeCreator
{
    private readonly IEmployeeRepository _repository;
    
    public EmployeeCreator(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    
    public async Task Create(CreateEmployeeCommand command)
    {
        var employee = command.Adapt<Employee>();
        await _repository.Save(employee);
    }
}

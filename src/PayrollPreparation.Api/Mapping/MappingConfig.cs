using Mapster;
using PayrollPreparation.Api.ViewModels.Employee;
using PayrollPreparation.Domain;

namespace PayrollPreparation.Api.Mapping
{
    public static class MappingConfig
    {
        public static void LoadMapping()
        {
            TypeAdapterConfig<Employee, EmployeeViewModel>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Address, src => src.Address);
        }
    }
}
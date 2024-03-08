using AutoMapper;
using Rentadora.Rental.Domain.Dto;
using Rentadora.Rental.Domain.Models;

namespace Rentadora.Rental.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BranchOffice, BranchOfficeDto>();
            CreateMap<BranchOfficeDto, BranchOffice>();
            CreateMap<VehicleBranchOffice, VehicleBranchOfficeDto>();
            CreateMap<VehicleBranchOfficeDto, VehicleBranchOffice>();
            CreateMap<Vehicle, VehicleDto>();
            CreateMap<VehicleDto, Vehicle>();
        }
    }
}

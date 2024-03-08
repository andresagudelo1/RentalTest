using AutoMapper;
using Rentadora.Rental.Application.Interfaces;
using Rentadora.Rental.Domain.Dto;
using Rentadora.Rental.Domain.Interfaces;
using Rentadora.Rental.Domain.Models;
using Rentadora.Rental.Infrastructure.Repositories;

namespace Rentadora.Rental.Application.Services
{
    public class VehicleApplication : IVehicleApplication
    {
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleApplication(
            IMapper mapper,
            IVehicleRepository vehicleRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// Método que recibe la solicitud del controlador para obtener todos los registros de locales
        /// </summary>
        /// <returns>Type: IEnumerable<VehicleDto> - Lista con la información solicitada de la tabla Vehicle </returns>
        public IEnumerable<VehicleDto> GetAll()
        {
            try
            {
                var requests = _vehicleRepository.GetAll();
                var response = _mapper.Map<IEnumerable<VehicleDto>>(requests);
                return response;
            }
            catch (Exception ex)
            {
                Exception exception = new("Failed" + ex.InnerException + "\n" + ex.Message);
                throw exception;
            }
        }

        /// <summary>
        /// Método que recibe la solicitud del controlador para obtener un Vehicle por id
        /// </summary>
        /// <param name="id">Type: int - Identificador del Vehicle a buscar</param>
        /// <returns>Type: VehicleDto - entidad con la información solicitada</returns>
        public async Task<VehicleDto> GetById(int id)
        {
            try
            {
                var branchData = await _vehicleRepository.GetById(id);
                var response = _mapper.Map<VehicleDto>(branchData);
                return response;
            }
            catch (Exception ex)
            {
                Exception exception = new("Failed" + ex.InnerException + "\n" + ex.Message);
                throw exception;
            }

        }

        /// <summary>
        /// Método que recibe la solicitud del controlador y crea un nuevo registro en la tabla Vehicle
        /// </summary>
        /// <param name="entity">Type: VehicleDto - Entidad con la información a guardar</param>
        /// <returns>Type: int - id del registro creado</returns>
        public async Task<int> Create(VehicleDto entity)
        {
            try
            {
                var BranchOfficeIdNew = 0;
                var BranchOfficeData = _mapper.Map<Vehicle>(entity);
                var lastId = await _vehicleRepository.GetSequence(BranchOfficeData);
                if (lastId == null) lastId = new Vehicle();
                BranchOfficeData.VehicleId = lastId.VehicleId + 1;
                BranchOfficeIdNew = BranchOfficeData.VehicleId;
                await _vehicleRepository.Add(BranchOfficeData);
                return BranchOfficeIdNew;
            }
            catch (Exception ex)
            {
                Exception exception = new("Failed" + ex.InnerException + "\n" + ex.Message);
                throw exception;
            }
        }

        /// <summary>
        /// Método que recibe la solicitud del controlador y actualiza un registro en la tabla Vehicle
        /// </summary>
        /// <param name="entity">Type: VehicleDto - Entidad con la información a actualizar </param>
        /// <returns></returns>
        public async Task<bool> Update(VehicleDto entity)
        {
            try
            {
                var branchOfficeData = await _vehicleRepository.GetById(entity.VehicleId);
                if (branchOfficeData != null)
                {
                    var dataMapper = _mapper.Map<Vehicle>(entity);
                    dataMapper.Color = branchOfficeData.Color;
                    dataMapper.FuelType = branchOfficeData.FuelType;
                    dataMapper.IsAvailable = branchOfficeData.IsAvailable;
                    dataMapper.Model = branchOfficeData.Model;
                    dataMapper.PlateNumber = branchOfficeData.PlateNumber;
                    dataMapper.SeatNumber = branchOfficeData.SeatNumber;
                    dataMapper.Price = branchOfficeData.Price;
                    await _vehicleRepository.UpdateAsync(dataMapper);

                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                Exception exception = new("Failed" + ex.InnerException + "\n" + ex.Message);
                throw exception;
            }
        }

        /// <summary>
        /// Método que recibe la solicitud del controlador y elimina un registro de la tabla Vehicle
        /// </summary>
        /// <param name="id">Type: Int - Id del Vehicle a eliminar </param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {
            try
            {
                var branchData = await _vehicleRepository.GetById(id);
                if (branchData == null) return false;
                await _vehicleRepository.Delete(branchData);
                return true;
            }
            catch (Exception ex)
            {
                Exception exception = new("Failed" + ex.InnerException + "\n" + ex.Message);
                throw exception;
            }
        }
    }
}

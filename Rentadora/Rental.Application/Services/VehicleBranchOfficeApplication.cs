using AutoMapper;
using Rentadora.Rental.Application.Interfaces;
using Rentadora.Rental.Domain.Dto;
using Rentadora.Rental.Domain.Interfaces;
using Rentadora.Rental.Domain.Models;
using Rentadora.Rental.Infrastructure.Repositories;

namespace Rentadora.Rental.Application.Services
{
    public class VehicleBranchOfficeApplication : IVehicleBranchOfficeApplication
    {
        private readonly IMapper _mapper;
        private readonly IVehicleBranchOfficeRepository _vehicleBranchOfficeRepository;

        public VehicleBranchOfficeApplication(IMapper mapper, IVehicleBranchOfficeRepository vehicleBranchOfficeRepository)
        {
            _mapper = mapper;
            _vehicleBranchOfficeRepository = vehicleBranchOfficeRepository;
        }
        /// <summary>
        /// Método que recibe la solicitud del controlador para obtener todos los registros de locales
        /// </summary>
        /// <returns>Type: IEnumerable<VehicleBranchOfficeDto> - Lista con la información solicitada de la tabla Vehicle </returns>
        public IEnumerable<VehicleBranchOfficeDto> GetAll()
        {
            try
            {
                var requests = _vehicleBranchOfficeRepository.GetAll();
                var response = _mapper.Map<IEnumerable<VehicleBranchOfficeDto>>(requests);
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
        /// <returns>Type: VehicleBranchOfficeDto - entidad con la información solicitada</returns>
        public async Task<VehicleBranchOfficeDto> GetById(int id)
        {
            try
            {
                var branchData = await _vehicleBranchOfficeRepository.GetById(id);
                var response = _mapper.Map<VehicleBranchOfficeDto>(branchData);
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
        /// <param name="entity">Type: VehicleBranchOfficeDto - Entidad con la información a guardar</param>
        /// <returns>Type: int - id del registro creado</returns>
        public async Task<int> Create(VehicleBranchOfficeDto entity)
        {
            try
            {
                var BranchOfficeIdNew = 0;
                var BranchOfficeData = _mapper.Map<VehicleBranchOffice>(entity);
                var lastId = await _vehicleBranchOfficeRepository.GetSequence(BranchOfficeData);
                if (lastId == null) lastId = new VehicleBranchOffice();
                BranchOfficeData.BranchOfficeVehicleId = lastId.BranchOfficeVehicleId + 1;
                BranchOfficeIdNew = BranchOfficeData.BranchOfficeVehicleId;
                await _vehicleBranchOfficeRepository.Add(BranchOfficeData);
                return BranchOfficeIdNew;
            }
            catch (Exception ex)
            {
                Exception exception = new("Failed" + ex.InnerException + "\n" + ex.Message);
                throw exception;
            }
        }

        /// <summary>
        /// Método que recibe la solicitud del controlador y actualiza un registro en la tabla BranchOfficeVehicleId
        /// </summary>
        /// <param name="entity">Type: VehicleBranchOfficeDto - Entidad con la información a actualizar </param>
        /// <returns></returns>
        public async Task<bool> Update(VehicleBranchOfficeDto entity)
        {
            try
            {
                var branchOfficeData = await _vehicleBranchOfficeRepository.GetById(entity.VehicleId);
                if (branchOfficeData != null)
                {
                    var dataMapper = _mapper.Map<VehicleBranchOffice>(entity);
                    dataMapper.BranchOfficeVehicleId = branchOfficeData.BranchOfficeVehicleId;
                    dataMapper.BranchOfficeId = branchOfficeData.BranchOfficeId;
                    dataMapper.VehicleId = branchOfficeData.VehicleId;
                    await _vehicleBranchOfficeRepository.UpdateAsync(dataMapper);

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
        /// Método que recibe la solicitud del controlador y elimina un registro de la tabla VehicleBranchOffice
        /// </summary>
        /// <param name="id">Type: Int - Id del VehicleBranchOffice a eliminar </param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {
            try
            {
                var branchData = await _vehicleBranchOfficeRepository.GetById(id);
                if (branchData == null) return false;
                await _vehicleBranchOfficeRepository.Delete(branchData);
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

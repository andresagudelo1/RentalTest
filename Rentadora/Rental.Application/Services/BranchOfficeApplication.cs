using AutoMapper;
using Rentadora.Rental.Application.Interfaces;
using Rentadora.Rental.Domain.Dto;
using Rentadora.Rental.Domain.Interfaces;
using Rentadora.Rental.Domain.Models;

namespace Rentadora.Rental.Application.Services
{
    public class BranchOfficeApplication : IBranchOfficeApplication
    {
        private readonly IMapper _mapper;
        private readonly IBranchOfficeRepository _branchOfficeRepository;

        public BranchOfficeApplication(IMapper mapper, IBranchOfficeRepository branchOfficeRepository)
        {
            _mapper = mapper;
            _branchOfficeRepository = branchOfficeRepository;
        }

        /// <summary>
        /// Método que recibe la solicitud del controlador para obtener todos los registros de locales
        /// </summary>
        /// <returns>Type: IEnumerable<BranchOfficeDto> - Lista con la información solicitada de la tabla BranchOffice </returns>
        public IEnumerable<BranchOfficeDto> GetAll()
        {
            try
            {
                var requests = _branchOfficeRepository.GetAll();
                var response = _mapper.Map<IEnumerable<BranchOfficeDto>>(requests);
                return response;
            }
            catch (Exception ex)
            {
                Exception exception = new("Failed" + ex.InnerException + "\n" + ex.Message);
                throw exception;
            }
        }

        /// <summary>
        /// Método que recibe la solicitud del controlador para obtener un BranchOffice por id
        /// </summary>
        /// <param name="id">Type: int - Identificador del BranchOffice a buscar</param>
        /// <returns>Type: BranchOfficeDto - entidad con la información solicitada</returns>
        public async Task<BranchOfficeDto> GetById(int id)
        {
            try
            {
                var branchData = await _branchOfficeRepository.GetById(id);
                var response = _mapper.Map<BranchOfficeDto>(branchData);
                return response;
            }
            catch (Exception ex)
            {
                Exception exception = new("Failed" + ex.InnerException + "\n" + ex.Message);
                throw exception;
            }

        }

        /// <summary>
        /// Método que recibe la solicitud del controlador y crea un nuevo registro en la tabla BranchOffice
        /// </summary>
        /// <param name="entity">Type: BranchOfficeDto - Entidad con la información a guardar</param>
        /// <returns>Type: int - id del registro creado</returns>
        public async Task<int> Create(BranchOfficeDto entity)
        {
            try
            {
                var BranchOfficeIdNew = 0;
                var BranchOfficeData = _mapper.Map<BranchOffice>(entity);
                var lastId = await _branchOfficeRepository.GetSequence(BranchOfficeData);
                if (lastId == null) lastId = new BranchOffice();
                BranchOfficeData.BranchOfficeId = lastId.BranchOfficeId + 1;
                BranchOfficeIdNew = BranchOfficeData.BranchOfficeId;
                await _branchOfficeRepository.Add(BranchOfficeData);
                return BranchOfficeIdNew;
            }
            catch (Exception ex)
            {
                Exception exception = new("Failed" + ex.InnerException + "\n" + ex.Message);
                throw exception;
            }
        }

        /// <summary>
        /// Método que recibe la solicitud del controlador y actualiza un registro en la tabla BranchOffice
        /// </summary>
        /// <param name="entity">Type: BranchOfficeDto - Entidad con la información a actualizar </param>
        /// <returns></returns>
        public async Task<bool> Update(BranchOfficeDto entity)
        {
            try
            {
                var branchOfficeData = await _branchOfficeRepository.GetById(entity.BranchOfficeId);
                if (branchOfficeData != null)
                {
                    var dataMapper = _mapper.Map<BranchOffice>(entity);
                    dataMapper.Addres = branchOfficeData.Addres;
                    dataMapper.City = branchOfficeData.City;
                    dataMapper.Country = branchOfficeData.Country;
                    dataMapper.Email = branchOfficeData.Email;
                    dataMapper.PostalCode = branchOfficeData.PostalCode;
                    dataMapper.IsRetired = branchOfficeData.IsRetired;
                    await _branchOfficeRepository.UpdateAsync(dataMapper);

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
        /// Método que recibe la solicitud del controlador y elimina un registro de la tabla BranchOffice
        /// </summary>
        /// <param name="id">Type: Int - Id del BranchOffice a eliminar </param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {
            try
            {
                var branchData = await _branchOfficeRepository.GetById(id);
                if (branchData == null) return false;
                await _branchOfficeRepository.Delete(branchData);
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

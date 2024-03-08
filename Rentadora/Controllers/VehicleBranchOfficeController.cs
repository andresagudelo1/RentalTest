using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rentadora.Rental.Application.Interfaces;
using Rentadora.Rental.Application.Services;
using Rentadora.Rental.Domain.Dto;
using Rentadora.Rental.Domain.Responses;

namespace Rentadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleBranchOfficeController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IVehicleBranchOfficeApplication _vehicleBranchOfficeApplication;
        private readonly IValidator<VehicleBranchOfficeDto> _vehicleBranchOfficeValidator;

        public VehicleBranchOfficeController(ILogger<VehicleBranchOfficeController> log,
            IVehicleBranchOfficeApplication vehicleBranchOfficeApplication,
            IValidator<VehicleBranchOfficeDto> vehicleBranchOfficeValidator)
        {
            _logger = log;
            _vehicleBranchOfficeApplication = vehicleBranchOfficeApplication;
            _vehicleBranchOfficeValidator = vehicleBranchOfficeValidator;
        }

        [HttpGet(Name = "GetAllVehicleBranch")]
        public ActionResult<IEnumerable<VehicleBranchOfficeDto>> GetAllVehicleBranch()
        {
            _logger.LogInformation("GetAllVehicleBranch");

            try
            {
                var response = _vehicleBranchOfficeApplication.GetAll();
                if (response != null && response.Any())
                {
                    _logger.LogInformation("Termino el metodo GetAllVehicleBranch correctamente .");
                    return new ObjectResult(new ResponseApi
                    {
                        IsSuccess = true,
                        Message = "Ok",
                        Result = response
                    });
                }
                else
                {
                    _logger.LogInformation("Termino el metodo GetAllVehicleBranch sin datos.");
                    return new ObjectResult(new ResponseApi
                    {
                        IsSuccess = false,
                        Message = "Tabla vacia.",
                        Result = response
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error con excepcion: " + ex.InnerException + "\n mensaje:" + ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetAllVehicleBranchById(int id)
        {
            _logger.LogInformation("GetAllVehicleBranchById");

            try
            {
                var response = await _vehicleBranchOfficeApplication.GetById(id);
                if (response != null)
                {
                    _logger.LogInformation("Termino el metodo GetAllVehicleBranchById correctamente .");
                    return new ObjectResult(new ResponseApi
                    {
                        IsSuccess = true,
                        Message = "Ok",
                        Result = response
                    });
                }
                else
                {
                    _logger.LogInformation("Termino el metodo GetAllVehicleBranchById sin datos.");
                    return new ObjectResult(new ResponseApi
                    {
                        IsSuccess = false,
                        Message = "Tabla vacia.",
                        Result = response
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error con excepcion: " + ex.InnerException + "\n mensaje:" + ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost(Name = "CreateVehicleBranch")]
        public async Task<IActionResult> CreateVehicleBranch([FromBody] VehicleBranchOfficeDto entity)
        {
            _logger.LogInformation("Create Vehicle");

            try
            {
                var validate = _vehicleBranchOfficeValidator.Validate(entity);
                if (!validate.IsValid)
                {
                    _logger.LogInformation("Termino el metodo CreateVehicleBranch no paso el validador de datos.");
                    return new BadRequestObjectResult(validate.Errors.Select(e => new
                    {
                        Field = e.PropertyName,
                        Error = e.ErrorMessage
                    }));
                }

                var response = await _vehicleBranchOfficeApplication.Create(entity);

                if (response == 0)
                {
                    _logger.LogInformation("Termino el metodo CreateVehicleBranch sin datos.");
                    return new OkObjectResult(new ResponseApi
                    {
                        IsSuccess = false,
                        Message = "La asociacion del local con el vehiculo no fue creada.",
                        Result = response
                    });
                }
                else
                {
                    _logger.LogInformation("Termino el metodo CreateVehicleBranch correctamente.");
                    return new OkObjectResult(new ResponseApi
                    {
                        IsSuccess = true,
                        Message = "La asociacion del local con el vehiculo fue creada exitosamente.",
                        Result = response
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error con excepcion: " + ex.InnerException + "\n mensaje:" + ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPut(Name = "UpdateVehicleBranch")]
        public async Task<IActionResult> UpdateVehicle([FromBody] VehicleBranchOfficeDto entity)
        {
            _logger.LogInformation("UpdateVehicleBranch");

            try
            {
                var validate = _vehicleBranchOfficeValidator.Validate(entity);
                if (!validate.IsValid)
                {
                    _logger.LogInformation("Termino el metodo UpdateVehicleBranch no paso el validador de datos.");
                    return new BadRequestObjectResult(validate.Errors.Select(e => new
                    {
                        Field = e.PropertyName,
                        Error = e.ErrorMessage
                    }));
                }

                var response = await _vehicleBranchOfficeApplication.Update(entity);

                if (!response)
                {
                    _logger.LogInformation("Termino el metodo UpdateVehicleBranch sin datos.");
                    return new OkObjectResult(new ResponseApi
                    {
                        IsSuccess = false,
                        Message = "La asociacion del local con el vehiculo no fue actualizada.",
                        Result = response
                    });
                }
                else
                {
                    _logger.LogInformation("Termino el metodo UpdateVehicleBranch correctamente.");
                    return new OkObjectResult(new ResponseApi
                    {
                        IsSuccess = true,
                        Message = "La asociacion del local con el vehiculo fue actualizada exitosamente.",
                        Result = response
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error con excepcion: " + ex.InnerException + "\n mensaje:" + ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteVehicleBranch(int id)
        {
            _logger.LogInformation("DeleteVehicle");

            try
            {
                var response = await _vehicleBranchOfficeApplication.Delete(id);
                if (response)
                {
                    _logger.LogInformation("Termino el metodo DeleteVehicleBranch correctamente .");
                    return new ObjectResult(new ResponseApi
                    {
                        IsSuccess = true,
                        Message = "Ok",
                        Result = response
                    });
                }
                else
                {
                    _logger.LogInformation("Termino el metodo DeleteVehicleBranch sin datos.");
                    return new ObjectResult(new ResponseApi
                    {
                        IsSuccess = false,
                        Message = "Tabla vacia.",
                        Result = response
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error con excepcion: " + ex.InnerException + "\n mensaje:" + ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}

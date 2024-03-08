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
    public class VehicleController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IVehicleApplication _vehicleApplication;
        private readonly IValidator<VehicleDto> _vehicleValidator;

        public VehicleController(ILogger<VehicleController> log,
            IVehicleApplication vehicleApplication,
            IValidator<VehicleDto> vehicleValidator)
        {
            _logger = log;
            _vehicleApplication = vehicleApplication;
            _vehicleValidator = vehicleValidator;
        }

        [HttpGet(Name = "GetAllVehicle")]
        public ActionResult<IEnumerable<VehicleDto>> GetAllVehicle()
        {
            _logger.LogInformation("GetAllVehicle");

            try
            {
                var response = _vehicleApplication.GetAll();
                if (response != null && response.Any())
                {
                    _logger.LogInformation("Termino el metodo GetAllVehicle correctamente .");
                    return new ObjectResult(new ResponseApi
                    {
                        IsSuccess = true,
                        Message = "Ok",
                        Result = response
                    });
                }
                else
                {
                    _logger.LogInformation("Termino el metodo GetAllVehicle sin datos.");
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
        public async Task<IActionResult> GetAllVehicleById(int id)
        {
            _logger.LogInformation("GetAllVehicleById");

            try
            {
                var response = await _vehicleApplication.GetById(id);
                if (response != null)
                {
                    _logger.LogInformation("Termino el metodo GetAllVehicleById correctamente .");
                    return new ObjectResult(new ResponseApi
                    {
                        IsSuccess = true,
                        Message = "Ok",
                        Result = response
                    });
                }
                else
                {
                    _logger.LogInformation("Termino el metodo GetAllVehicleById sin datos.");
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

        [HttpPost(Name = "CreateVehicle")]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleDto entity)
        {
            _logger.LogInformation("Create Vehicle");

            try
            {
                var validate = _vehicleValidator.Validate(entity);
                if (!validate.IsValid)
                {
                    _logger.LogInformation("Termino el metodo CreateVehicle no paso el validador de datos.");
                    return new BadRequestObjectResult(validate.Errors.Select(e => new
                    {
                        Field = e.PropertyName,
                        Error = e.ErrorMessage
                    }));
                }

                var response = await _vehicleApplication.Create(entity);

                if (response == 0)
                {
                    _logger.LogInformation("Termino el metodo CreateVehicle sin datos.");
                    return new OkObjectResult(new ResponseApi
                    {
                        IsSuccess = false,
                        Message = "El vehiculo no fue creado.",
                        Result = response
                    });
                }
                else
                {
                    _logger.LogInformation("Termino el metodoCreateBranchOffice correctamente.");
                    return new OkObjectResult(new ResponseApi
                    {
                        IsSuccess = true,
                        Message = "El vehiculo fue creado exitosamente.",
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

        [HttpPut(Name = "UpdateVehicle")]
        public async Task<IActionResult> UpdateVehicle([FromBody] VehicleDto entity)
        {
            _logger.LogInformation("UpdateVehicle");

            try
            {
                var validate = _vehicleValidator.Validate(entity);
                if (!validate.IsValid)
                {
                    _logger.LogInformation("Termino el metodo UpdateVehicle no paso el validador de datos.");
                    return new BadRequestObjectResult(validate.Errors.Select(e => new
                    {
                        Field = e.PropertyName,
                        Error = e.ErrorMessage
                    }));
                }

                var response = await _vehicleApplication.Update(entity);

                if (!response)
                {
                    _logger.LogInformation("Termino el metodo UpdateVehicle sin datos.");
                    return new OkObjectResult(new ResponseApi
                    {
                        IsSuccess = false,
                        Message = "El vehiculo no fue actualizado.",
                        Result = response
                    });
                }
                else
                {
                    _logger.LogInformation("Termino el metodoCreateBranchOffice correctamente.");
                    return new OkObjectResult(new ResponseApi
                    {
                        IsSuccess = true,
                        Message = "El vehiculo fue actualizado exitosamente.",
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
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            _logger.LogInformation("DeleteVehicle");

            try
            {
                var response = await _vehicleApplication.Delete(id);
                if (response)
                {
                    _logger.LogInformation("Termino el metodo DeleteVehicle correctamente .");
                    return new ObjectResult(new ResponseApi
                    {
                        IsSuccess = true,
                        Message = "Ok",
                        Result = response
                    });
                }
                else
                {
                    _logger.LogInformation("Termino el metodo DeleteVehicle sin datos.");
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

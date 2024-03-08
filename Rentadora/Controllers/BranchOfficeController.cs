using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rentadora.Rental.Application.Interfaces;
using Rentadora.Rental.Application.Services;
using Rentadora.Rental.Domain.Dto;
using Rentadora.Rental.Domain.Responses;
using System.Net;

namespace Rentadora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchOfficeController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IBranchOfficeApplication _branchOfficeApplication;
        private readonly IValidator<BranchOfficeDto> _branchOfficeValidator;

        public BranchOfficeController(ILogger<BranchOfficeController> log, 
            IBranchOfficeApplication branchOfficeApplication,
            IValidator<BranchOfficeDto> branchOfficeValidator)
        {
            _logger = log;
            _branchOfficeApplication = branchOfficeApplication;
            _branchOfficeValidator = branchOfficeValidator;
        }

        [HttpGet(Name = "GetAllBranchOffice")]
        public ActionResult<IEnumerable<BranchOfficeDto>> GetAllBranchOffice()
        {
            _logger.LogInformation("GetAllBranchOffice");

            try
            {
                var response = _branchOfficeApplication.GetAll();
                if (response != null && response.Any())
                {
                    _logger.LogInformation("Termino el metodo GetAllBranchOffice correctamente .");
                    return new ObjectResult(new ResponseApi
                    {
                        IsSuccess = true,
                        Message = "Ok",
                        Result = response
                    });
                }
                else
                {
                    _logger.LogInformation("Termino el metodo GetAllBranchOffice sin datos.");
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
        public async Task<IActionResult> GetBranchOfficeById(int id)
        {
            _logger.LogInformation("GetBranchOfficeById");

            try
            {
                var response = await _branchOfficeApplication.GetById(id);
                if (response != null)
                {
                    _logger.LogInformation("Termino el metodo GetBranchOfficeById correctamente .");
                    return new ObjectResult(new ResponseApi
                    {
                        IsSuccess = true,
                        Message = "Ok",
                        Result = response
                    });
                }
                else
                {
                    _logger.LogInformation("Termino el metodo GetBranchOfficeById sin datos.");
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

        [HttpPost(Name = "CreateBranchOffice")]
        public async Task<IActionResult> CreateBranchOffice([FromBody] BranchOfficeDto entity)
        {
            _logger.LogInformation("Create Branch Office");

            try
            {
                var validate = _branchOfficeValidator.Validate(entity);
                if (!validate.IsValid)
                {
                    _logger.LogInformation("Termino el metodo CreateBranchOffice no paso el validador de datos.");
                    return new BadRequestObjectResult(validate.Errors.Select(e => new
                    {
                        Field = e.PropertyName,
                        Error = e.ErrorMessage
                    }));
                }

                var response = await _branchOfficeApplication.Create(entity);

                if (response == 0)
                {
                    _logger.LogInformation("Termino el metodo CreateBranchOffice sin datos.");
                    return new OkObjectResult(new ResponseApi
                    {
                        IsSuccess = false,
                        Message = "El local de retiro o devolucion no fue creado.",
                        Result = response
                    });
                }
                else
                {
                    _logger.LogInformation("Termino el metodoCreateBranchOffice correctamente.");
                    return new OkObjectResult(new ResponseApi
                    {
                        IsSuccess = true,
                        Message = "El local de retiro o devolucion fue creado exitosamente.",
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

        [HttpPut(Name = "UpdateBranchOffice")]
        public async Task<IActionResult> UpdateBranchOffice([FromBody] BranchOfficeDto entity)
        {
            _logger.LogInformation("UpdateBranchOffice");

            try
            {
                var validate = _branchOfficeValidator.Validate(entity);
                if (!validate.IsValid)
                {
                    _logger.LogInformation("Termino el metodo UpdateBranchOffice no paso el validador de datos.");
                    return new BadRequestObjectResult(validate.Errors.Select(e => new
                    {
                        Field = e.PropertyName,
                        Error = e.ErrorMessage
                    }));
                }

                var response = await _branchOfficeApplication.Update(entity);

                if (!response)
                {
                    _logger.LogInformation("Termino el metodo UpdateBranchOffice sin datos.");
                    return new OkObjectResult(new ResponseApi
                    {
                        IsSuccess = false,
                        Message = "El local de retiro o devolucion no fue actualizado.",
                        Result = response
                    });
                }
                else
                {
                    _logger.LogInformation("Termino el metodoCreateBranchOffice correctamente.");
                    return new OkObjectResult(new ResponseApi
                    {
                        IsSuccess = true,
                        Message = "El local de retiro o devolucion fue actualizado exitosamente.",
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
        public async Task<IActionResult> DeleteOfficeById(int id)
        {
            _logger.LogInformation("DeleteOfficeById");

            try
            {
                var response = await _branchOfficeApplication.Delete(id);
                if (response)
                {
                    _logger.LogInformation("Termino el metodo DeleteOfficeById correctamente .");
                    return new ObjectResult(new ResponseApi
                    {
                        IsSuccess = true,
                        Message = "Ok",
                        Result = response
                    });
                }
                else
                {
                    _logger.LogInformation("Termino el metodo DeleteOfficeById sin datos.");
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

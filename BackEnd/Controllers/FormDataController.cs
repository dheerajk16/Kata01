using FillForm.Data.Repositories;
using FillForm.Models;
using FillForm.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FillForm.Controllers
{
    [ApiController]
    [Route("api/formdata")]
    public class FormDataController : ControllerBase
    {
        private readonly ILogger<FormDataController> _logger;
        private readonly ILoggingService _loggingService;
        private readonly IFormDataRepository _formDataRepository;

        public FormDataController(ILogger<FormDataController> logger, ILoggingService loggingService, IFormDataRepository formDataRepository)
        {
            _logger = logger;
            _loggingService = loggingService;
            _formDataRepository = formDataRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostFormData(FormData formData)
        {
            try
            {
                await _formDataRepository.AddFormDataAsync(formData);

                _logger.LogInformation("Form data persisted: {@FormData}", formData);

                return Created("", formData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during form submission");
                _loggingService.LogException(ex);

                return StatusCode(500, "An error occurred during form submission. Please try again later.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetFormData()
        {
            var result = await _formDataRepository.GetFormDataAsync();
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteFormData()
        {
            _formDataRepository.DeleteFormDataAsync();

            return NoContent();
        }
    }
}

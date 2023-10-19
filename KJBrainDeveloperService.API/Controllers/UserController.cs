using KJBrainDeveloperService.API.Extensions;
using KJBrainDeveloperService.API.Helpers;
using KJBrainDeveloperService.Business;
using KJBrainDeveloperService.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;

namespace KJBrainDeveloperService.API.Controllers
{
    [Description("User management")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _service;

        public UserController(IUserService service, ErrorLogger logger) : base(logger)
        {
            _service = service;
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var response = await _service.ReadById(id);
            if (response.HasError)
            {
                LogError("Id: " + id, response);
                return this.CreateErrorResponse(response);
            }
            return Ok(response.Result);
        }

        /// <summary>
        /// Update user
        /// </summary>
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
        {
            var response = await _service.Update(request);
            if (response.HasError)
            {
                LogError(JsonConvert.SerializeObject(request), response);
                return this.CreateErrorResponse(response);
            }
            return NoContent();
        }

        /// <summary>
        /// Delete user
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _service.Delete(id);
            if (response.HasError)
            {
                LogError("Id: " + id, response);
                return this.CreateErrorResponse(response);
            }
            return NoContent();
        }
    }
}
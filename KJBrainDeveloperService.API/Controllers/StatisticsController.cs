using KJBrainDeveloperService.API.Extensions;
using KJBrainDeveloperService.API.Helpers;
using KJBrainDeveloperService.Business;
using KJBrainDeveloperService.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;

namespace KJBrainDeveloperService.API.Controllers
{

    [Description("Statistics management")]
    public class StatisticsController : BaseApiController
    {
        private readonly IStatisticsService _service;

        public StatisticsController(IStatisticsService service, ErrorLogger logger) : base(logger)
        {
            _service = service;
        }

        /// <summary>
        /// Get User's Training statistics by logined user id.
        /// </summary>
        [HttpGet("ListTraining")]
        public async Task<IActionResult> ListTraining()
        {
            var userId = GetLoginedUserId();

            var response = await _service.ListTraining(userId);
            if (response.HasError)
            {
                LogError("userId: " + userId, response);
                return this.CreateErrorResponse(response);
            }
            return Ok(response.Result);
        }

        /// <summary>
        /// Get User's Training statistics by logined user id and filter for chart diagram.
        /// </summary>
        [HttpGet("ListTrainingForChart")]
        public async Task<IActionResult> ListTrainingForChart([FromQuery] ListTrainingStatisticsChartRequest request)
        {
            var userId = GetLoginedUserId();

            var response = await _service.ListTrainingForChart(request, userId);
            if (response.HasError)
            {
                LogError("userId: " + userId, response);
                return this.CreateErrorResponse(response);
            }
            return Ok(response.Result);
        }

        /// <summary>
        /// Create Training statistics by logined user id
        /// </summary>
        [HttpPost("CreateTraining")]
        public async Task<IActionResult> CreateTraining([FromBody] CreateTrainingStatisticsRequest request)
        {
            var userId = GetLoginedUserId();

            var response = await _service.CreateTraining(request, userId);
            if (response.HasError)
            {
                LogError(JsonConvert.SerializeObject(request), response);
                return this.CreateErrorResponse(response);
            }
            return CreatedAtAction("CreateTraining", new { id = response.Result.Id }, response.Result);
        }


        /// <summary>
        /// Delete All Training by logined user id
        /// </summary>
        [HttpDelete("DeleteAllTraining")]
        public async Task<IActionResult> DeleteTraining()
        {
            var userId = GetLoginedUserId();

            var response = await _service.DeleteAllTraining(userId);
            if (response.HasError)
            {
                LogError("UserId: " + userId, response);
                return this.CreateErrorResponse(response);
            }
            return NoContent();
        }



        /// <summary>
        /// Get User's MemoryCard statistics by logined user id.
        /// </summary>
        [HttpGet("ListMemoryCard")]
        public async Task<IActionResult> ListMemoryCard()
        {
            var userId = GetLoginedUserId();

            var response = await _service.ListMemoryCard(userId);
            if (response.HasError)
            {
                LogError("userId: " + userId, response);
                return this.CreateErrorResponse(response);
            }
            return Ok(response.Result);
        }

        /// <summary>
        /// Get User's MemoryCard statistics by logined user id and filter for chart diagram.
        /// </summary>
        [HttpGet("ListMemoryCardForChart")]
        public async Task<IActionResult> ListMemoryCardForChart([FromQuery] ListMemoryCardStatisticsChartRequest request)
        {
            var userId = GetLoginedUserId();

            var response = await _service.ListMemoryCardForChart(request, userId);
            if (response.HasError)
            {
                LogError("userId: " + userId, response);
                return this.CreateErrorResponse(response);
            }
            return Ok(response.Result);
        }

        /// <summary>
        /// Create MemoryCard statistics by logined user id
        /// </summary>
        [HttpPost("CreateMemoryCard")]
        public async Task<IActionResult> CreateMemoryCard([FromBody] CreateMemoryCardStatisticsRequest request)
        {
            var userId = GetLoginedUserId();

            var response = await _service.CreateMemoryCard(request, userId);
            if (response.HasError)
            {
                LogError(JsonConvert.SerializeObject(request), response);
                return this.CreateErrorResponse(response);
            }
            return CreatedAtAction("CreateMemoryCard", new { id = response.Result.Id }, response.Result);
        }


        /// <summary>
        /// Delete All MemoryCard by logined user id
        /// </summary>
        [HttpDelete("DeleteAllMemoryCard")]
        public async Task<IActionResult> DeleteMemoryCard()
        {
            var userId = GetLoginedUserId();

            var response = await _service.DeleteAllMemoryCard(userId);
            if (response.HasError)
            {
                LogError("UserId: " + userId, response);
                return this.CreateErrorResponse(response);
            }
            return NoContent();
        }
    }
}
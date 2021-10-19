using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sales.API.DataContracts.Responses;
using Sales.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using S = Sales.Services.Model;

namespace Sales.API.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<SalesController> _logger;

#pragma warning disable CS1591
        public SalesController(ISalesService service, IMapper mapper, ILogger<SalesController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }


        /// <summary>
        /// Gets the sales data.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="country">The country.</param>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="itemType">Type of the item.</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SalesResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(SalesResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{region}/{country}")]
        public async Task<IActionResult> Get(string region, string country, int page, int limit, string itemType)
        {
            var salesData = await _service.GetSalesDataAsync(region, country, itemType, page, limit);
            if (salesData == null)
            {
                return this.NoContent();
            }

            return this.Ok(salesData);
        }

        /// <summary>
        /// Gets the regions.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegionResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(RegionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("getRegions")]
        public async Task<IActionResult> GetRegions()
        {
            var result = await _service.GetRegionsAsync();
            if (result == null)
            {
                return this.NoContent();
            }

            return this.Ok(result);
        }

        /// <summary>
        /// Gets the countries.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountryResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CountryResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("getCountries/{region}")]
        public async Task<IActionResult> GetCountries(string region)
        {
            var result = await _service.GetCountriesAsync(region);
            if (result == null)
            {
                return this.NoContent();
            }

            return this.Ok(result);
        }

        /// <summary>
        /// Gets the item types.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="country">The country.</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ItemTypeResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ItemTypeResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("getItemTypes/{region}/{country}")]
        public async Task<IActionResult> GetItemTypes(string region, string country)
        {
            var result = await _service.GetItemTypesAsync(region, country);
            if (result == null)
            {
                return this.NoContent();
            }

            return this.Ok(result);
        }
    }
}

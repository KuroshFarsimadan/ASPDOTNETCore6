using System.Text.Json;
using ASPNET6Tutorial.Models;
using ASPNET6Tutorial.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET6Tutorial.Controllers
{
    [ApiController]
    [Authorize(Policy = "MustBeFromTehran")]
    // [controller] = api/cities
    // [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/cities")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class CitiesController : ControllerBase
    {

        // public readonly CitiesDataStore _citiesDataStore;

        //public CitiesController(CitiesDataStore citiesDataStore)
        //{
        //    _citiesDataStore = citiesDataStore ?? throw new ArgumentNullException(nameof(citiesDataStore));
        //}

        public readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
        const int maxCitiesPageSize = 20;

        public CitiesController(ICityInfoRepository cityInfoRepository, 
            IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Summary test
        /// </summary>
        /// <param name="name"></param>
        /// <param name="searchQuery"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public  async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCities(
             string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10
            ) // GetCitiesAsync()
        {
            /* JsonResult */
            //var temp = new JsonResult(CitiesDataStore.Current.Cities);
            //// temp.StatusCode = 200;
            //return Ok(temp);
            if(pageSize > maxCitiesPageSize)
            {
                pageSize = maxCitiesPageSize;
            }

            var (cityEntities, paginationMetadata) = await _cityInfoRepository
                .GetCitiesAsync(name, searchQuery, pageNumber, pageSize);

            //var results = new List<CityWithoutPointsOfInterestDto>();
            //foreach(var city in cities)
            //{
            //    results.Add(
            //        new CityWithoutPointsOfInterestDto
            //        {
            //            Id = city.Id,
            //            Description = city.Description,
            //            Name = city.Name

            //        });
            //}

            // Add pagination metadata as a header to response
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));
        }

        /// <summary>
        /// Summary test
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includePointsOfInterest"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async /* JsonResult */ Task<ActionResult<CityDto>> GetCity(int id, bool includePointsOfInterest = false)
        {

            var city = await _cityInfoRepository.GetCityAsync(id, includePointsOfInterest);
            //var temp = _cityInfoRepository.Cities.FirstOrDefault(c => c.Id == id);

            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                return Ok(_mapper.Map<CityDto>(city));
            }

            return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(city));
           
            //return new JsonResult(
            //        CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id));
        }
    }
}

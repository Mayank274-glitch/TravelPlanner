using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using TravelPlannerService.Models;
using TravelPlannerService.Services;

namespace TravelPlannerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService _placeService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
       // private readonly ILogger<PlacesController> _logger; // Inject a logger

        public PlacesController(
            IPlaceService placeService,
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration
          ) // Inject the logger
        {
            _placeService = placeService;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
           
        }


        [HttpGet]
        public IEnumerable<Place> GetAll()
        {
            return _placeService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Place> GetById(int id)
        {
            var place = _placeService.GetById(id);

            if (place == null)
            {
                return NotFound();
            }

            return place;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PlaceResult>>> SearchCityAsync([FromQuery] string cityName)
        {
            try
            {
                if (string.IsNullOrEmpty(cityName))
                {
                    return BadRequest("City name is required.");
                }

                // Fetch Google API key from configuration
                var googleApiKey = _configuration["GoogleApi:ApiKey"];

                // Perform a text search for the given city name
                var searchResults = await GetPlaceSearchResultsFromGoogleApiAsync(cityName, googleApiKey);

                return Ok(searchResults);
            }
            catch (Exception ex)
            {
                // Log the exception
                // _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        private async Task<IEnumerable<PlaceResult>> GetPlaceSearchResultsFromGoogleApiAsync(string cityName, string apiKey)
        {
            try
            {
                // Perform a text search for the given city name
                var apiUrl = $"https://maps.googleapis.com/maps/api/place/textsearch/json?query={cityName}&key={apiKey}";

                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetStringAsync(apiUrl);
                    var result = JsonConvert.DeserializeObject<GoogleTextSearchResponse>(response);

                    // Extract relevant information from the API response
                    var places = result?.Results?.Select(place => new PlaceResult
                    {
                        Name = place.Name,
                        FormattedAddress = place.FormattedAddress,
                        // Add other properties based on the response structure
                    });

                    return places ?? Enumerable.Empty<PlaceResult>();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // _logger.LogError(ex, "An error occurred while fetching place search results from Google API.");
                throw; // Rethrow the exception for the calling code to handle
            }
        }


        [HttpGet("top-10")]
        public async Task<ActionResult<IEnumerable<PlaceResult>>> GetTopPlacesAsync([FromQuery] string cityName)
        {
            try
            {
                if (string.IsNullOrEmpty(cityName))
                {
                    return BadRequest("City name is required.");
                }

                // Fetch Google API key from configuration
                var googleApiKey = _configuration["GoogleApi:ApiKey"];

                // Perform additional logic to get the top 10 places in the given city
                var topPlaces = await GetTopPlacesFromGoogleApiAsync(cityName, googleApiKey);

                return Ok(topPlaces);
            }
            catch (Exception ex)
            {
                // Log the exception
                // _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        private async Task<IEnumerable<PlaceResult>> GetTopPlacesFromGoogleApiAsync(string cityName, string apiKey)
        {
            try
            {
                // Perform a text search for points of interest in the given city
                var apiUrl = $"https://maps.googleapis.com/maps/api/place/textsearch/json?query={cityName}+point+of+interest&language=en&key={apiKey}";

                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetStringAsync(apiUrl);
                    var result = JsonConvert.DeserializeObject<GoogleTextSearchResponse>(response);

                    // Extract relevant information from the API response
                    var places = result?.Results?.Take(10).Select(place => new PlaceResult
                    {
                        Name = place.Name,
                        FormattedAddress = place.FormattedAddress,
                        // Add other properties based on the response structure
                    });

                    return places ?? Enumerable.Empty<PlaceResult>();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // _logger.LogError(ex, "An error occurred while fetching top places from Google API.");
                throw; // Rethrow the exception for the calling code to handle
            }
        }



        [HttpPost]
        public async Task<ActionResult<Place>> CreateAsync([FromBody] Place place)
        {
            try
            {
                // Check if GooglePlaceId is provided
                if (string.IsNullOrEmpty(place.GooglePlaceId))
                {
                    return BadRequest("GooglePlaceId is required.");
                }

                // Fetch Google API key from configuration
                var googleApiKey = _configuration["GoogleApi:ApiKey"];

                // Perform additional logic for integrating with Google Places API
                var placeResult = await GetPlaceDetailsFromGoogleApiAsync(place.GooglePlaceId, googleApiKey);

                if (placeResult != null)
                {
                    place.Name = placeResult.Name;
                    place.Address = placeResult.FormattedAddress;
                    // Set other properties based on the response from Google Places API
                }

                // Add additional validation checks if needed

                // Save to the database
                _placeService.Create(place);

                return CreatedAtAction(nameof(GetById), new { id = place.Id }, place);
            }
            catch (Exception ex)
            {
                // Log the exception
              //  _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        private async Task<PlaceResult> GetPlaceDetailsFromGoogleApiAsync(string placeId, string apiKey)
        {
            var apiUrl = $"https://maps.googleapis.com/maps/api/place/details/json?place_id={placeId}&key={apiKey}";

            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var response = await httpClient.GetStringAsync(apiUrl);
                return JsonConvert.DeserializeObject<PlaceResult>(response);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Place place)
        {
            if (id != place.Id)
            {
                return BadRequest();
            }

            _placeService.Update(place);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _placeService.Delete(id);
            return NoContent();
        }
    }
}

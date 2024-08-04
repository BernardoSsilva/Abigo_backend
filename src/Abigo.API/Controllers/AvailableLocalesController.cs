using Abigo.Application.UseCases.AvailableLocales.Delete.Interfaces;
using Abigo.Application.UseCases.AvailableLocales.get.Interfaces;
using Abigo.Application.UseCases.AvailableLocales.Post.Interfaces;
using Abigo.Application.UseCases.AvailableLocales.Put.Interfaces;
using Abigo.Communication.Requests;
using Abigo.Communication.Responses.AvailableLocales;
using Abigo.Communication.Responses.DisponibleLocales;
using Abigo.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Abigo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableLocales : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(AvailableLocalesShortResponseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterNewAvailableLocale([FromServices] IRegisterNewAvailableLocale useCase, [FromBody] AvailableLocalesRequestJson request, [FromHeader] string AuthToken)
        {
            var response = await useCase.Execute(request, AuthToken);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(MultipleLocalesResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ListAllAvailablesLocales([FromServices] IFIndAllAvailableLocalesUseCase useCase)
        {
            var result = await useCase.Execute();
            if (result.Locales.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("select/{id}")]
        [ProducesResponseType(typeof(AvailableLocalesDetailedResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindAvailableLocaleById([FromServices] IFindLocaleByIdUseCase useCase, [FromRoute] string id)
        {
            var result = await useCase.Execute(id);

            if(result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("locale/select/city/")]
        [ProducesResponseType(typeof(MultipleLocalesResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> FindAvailableLocaleByCity([FromServices] IFindAllLocalesInACityUseCase useCase, [FromQuery(Name = "cityName")] string cityName)
        {
            var result = await useCase.Exectue(cityName);
            if(result.Locales.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);        
        }

        [HttpGet]
        [Route("locale/find/locale/name")]
        [ProducesResponseType(typeof(AvailableLocalesDetailedResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindAvailableLocaleByName([FromServices] IFindLocaleByNameUseCase useCase, [FromQuery(Name = "localeName")] string localeName)
        {
            var result = await useCase.Execute(localeName);
            if(result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("locale/find/category")]
        [ProducesResponseType(typeof(AvailableLocalesDetailedResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> FindAvailableLocalesByCategory([FromServices] IFindAllLocalesByCategoryUseCase useCase, [FromQuery(Name = "localeCategory")] LocalesCategories localeCategory)
        {
            var result = await useCase.Execute(localeCategory);
            if(result.Locales.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }


        [HttpGet]
        [Route("locale/org/{id}")]
        [ProducesResponseType(typeof(AvailableLocalesDetailedResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> FindAvailableLocaleByAccountId([FromServices] IFindLocalesByAccountUseCase useCase, [FromRoute] string id)
        {
            var result = await useCase.Execute(id);
            if (result.Locales.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("locale/neighborhood/")]
        [ProducesResponseType(typeof(AvailableLocalesDetailedResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> FindAvailableLocaleByNeighborhood([FromServices] IFindAllLocalesByNeighborhoodUseCase useCase, [FromQuery(Name = "neighborhoodName")] string neighborhoodName) {
            var result = await useCase.Execute(neighborhoodName);
            if (result.Locales.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);

        }

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(AvailableLocalesDetailedResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteAvailableLocale([FromServices] IDeleteAvailableLocaleUseCase useCase, [FromHeader] string AuthToken, [FromRoute] string id)
        {
            try
            {

            await useCase.Execute(id, AuthToken);
            return Ok();
            } catch(Exception ex)
            {
                if(ex.GetType() == typeof(UnauthorizedAccessException)){
                    return Unauthorized();
                }
                return NotFound();
            }

        }

        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(typeof(AvailableLocalesDetailedResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateAvailableLocale([FromServices] IUpdateAvailableLocaleUseCase useCase, [FromHeader] string AuthToken, [FromRoute] string id, [FromBody] AvailableLocalesRequestJson requestJson)
        {
            try
            {
                await useCase.Execute(id, AuthToken, requestJson);
                return Ok();
            }
            catch (Exception ex) {
                if (ex.GetType() == typeof(UnauthorizedAccessException))
                {
                    return Unauthorized();
                }
                return NotFound();
            }

        }
    }
}
using Abigo.Application.UseCases.Accountables.Delete.interfaces;
using Abigo.Application.UseCases.Accountables.Get.interfaces;
using Abigo.Application.UseCases.Accountables.Post.Interfaces;
using Abigo.Application.UseCases.Accountables.Put.Interfaces;
using Abigo.Communication.Requests;
using Abigo.Communication.Responses.Accountable;
using Microsoft.AspNetCore.Mvc;

namespace Abigo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Accounts : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(AccountableShortResponseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> RegisterNewUser([FromServices] IRegisterNewAccountUseCase useCase, [FromBody] AccountableRequestJson requestJson)
        {
            try
            {

                var response = await useCase.Execute(requestJson);
                return Created(string.Empty, response);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AuthenticateUser([FromServices] IAuthenticateAccountUseCase useCase, [FromBody] AuthenticateAccountRequestJson requestJson)
        {
            try
            {
                var token = await useCase.Execute(requestJson);
                var response = new
                {
                    token = token.ToString()
                };
                return Ok(response);
            }
            catch
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(MultiplleAccountablesResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> FindAllAccounts([FromServices] IListAllAccountablesUseCase useCase)
        {
            var resposne = await useCase.Execute();

            if (resposne.accounts.Count == 0)
            {
                return NoContent();
            }
            return Ok(resposne);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(AccountableDetailedResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindAccountById([FromServices] ISearchAccountableByIdUseCase useCase, [FromRoute] string id)
        {
            var result = await useCase.Execute(id);
            return Ok(result);
        }

        [HttpGet("find/")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(AccountableDetailedResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindAccountableByName([FromServices] IFindAccoutableByNameUseCase useCase, [FromQuery(Name = "accountName")] string accountName)
        {
            var result = await useCase.Execute(accountName);
            if(result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAccount([FromHeader] string authToken, [FromServices] IUpdateAccountableUseCase useCase, [FromBody] AccountableRequestJson requestBody)
        {
            try {
                var result = await useCase.Execute(requestBody,  authToken);

                return Ok(result);

            }
            catch(Exception ex)
            {
                if(ex.GetType() == typeof(UnauthorizedAccessException))
                {
                    return Unauthorized();
                }
                return NotFound();
            }
            
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAccount([FromHeader] string authToken, [FromServices] IDeleteAccountableUseCase useCase)
        {
            try
            {
                var result = await useCase.Execute(authToken);
                return NoContent();

            }catch(Exception ex)
            {
                if(ex.GetType() == typeof(UnauthorizedAccessException))
                {
                    return Unauthorized();
                }
                return NotFound();
            }
        }


    }
}

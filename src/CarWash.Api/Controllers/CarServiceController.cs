using CarWash.Application.UseCase.CarService.Delete;
using CarWash.Application.UseCase.CarService.GetAll;
using CarWash.Application.UseCase.CarService.GetById;
using CarWash.Application.UseCase.CarService.Register;
using CarWash.Application.UseCase.CarService.Update;
using CarWash.Communication.Request;
using CarWash.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarServiceController : ControllerBase
{
    [HttpPost] //create/register car service.
    [ProducesResponseType(typeof(ResponseRegisterCarServiceJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterCarServicesUseCase useCase,
        [FromBody] RequestCarServiceJson request)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpPut] //Update car service.
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateCarServiceUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestCarServiceUpdateJson request)
    {
        await useCase.Execute(id, request);
        return NoContent();
    }

    [HttpGet]
    [Route("{id}")] //get car service by id.
    [ProducesResponseType(typeof(ResponseCarServiceJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task <IActionResult> GetById(
        [FromServices] IGetCarServiceByIdUseCase useCase,
        [FromRoute] long id)
    {
        var response = await useCase.Execute(id);
        return Ok(response);
    }

    [HttpGet] //get all car services.
    [ProducesResponseType(typeof(ResponseAllCarServicesJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task <IActionResult>GetAllCarServices(
        [FromServices] IGetAllCarServicesUseCase useCase)
    {
        var response = await useCase.Execute();
        if (response.CarServices.Count != 0)
            return Ok(response);

        return NoContent();

    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete (
        [FromServices] IDeleteCarServiceUseCase useCase,
        [FromRoute] long id)
    {
        await useCase.Execute(id);
        return NoContent();

    }


}

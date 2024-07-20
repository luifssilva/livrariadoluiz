using LivrariaDoLuiz.Application.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaDoLuiz.Controllers.Base;
public abstract class BaseController : ControllerBase
{
    public BaseController() { }

    protected Response ResponseBase { get; set; } = null!;

    protected new static IActionResult Response(Response? response)
    {
        if (OperationIsValid(response!))
        {
            if (response!.Value == null)
            {
                return new NoContentResult();
            }

            return new OkObjectResult(new
            {
                success = true,
                data = response.Value
            });
        }

        return new BadRequestObjectResult(new
        {
            success = false,
            erros = response!.Message
        });
    }
    private static bool OperationIsValid(Response response)
    {
        return !response.AnyMessage;
    }
}
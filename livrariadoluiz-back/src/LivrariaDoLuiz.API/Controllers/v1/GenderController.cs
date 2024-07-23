using LivrariaDoLuiz.Application.Entity;
using LivrariaDoLuiz.Application.Interface;
using LivrariaDoLuiz.Controllers.Base;
using LivrariaDoLuiz.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LivrariaDoLuiz.API.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class GenderController(ILogger<IGenderAppService> logger,  IGenderAppService GenderAppService) : BaseController
{
    private readonly ILogger _logger = logger;
    private readonly IGenderAppService _genderAppService = GenderAppService;
    
    /// <summary>
    /// Retorna Lista de Gêneros
    /// </summary>
    /// <returns></returns>    
    [HttpGet]    
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]    
    public async Task<IActionResult> Get()
    {           
        ResponseBase = new();
        try 
        {
            _logger.LogInformation("||GenderController||Get");
            return Response(await _genderAppService.GetAsync());
        }
        catch (Exception ex)
        {
            _logger.LogError("||GenderController||Get");
            ResponseBase.AddNotifications(new Notification() { Message = ex.Message });
        }
        return Response(ResponseBase);
    }    

    /// <summary>
    /// Pesquisa um Gênero através do Id
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>    
    [HttpGet("{id}")]    
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(Response))]   
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]    
    public async Task<IActionResult> GetById(Guid Id)
    {           
        ResponseBase = new();
        try 
        {
            _logger.LogInformation("||GenderController||GetById");
            return Response(await _genderAppService.GetAsync(Id));
        }
        catch (Exception ex)
        {
            _logger.LogError("||GenderController||GetById");
            ResponseBase.AddNotifications(new Notification() { Message = ex.Message });
        }
        return Response(ResponseBase);
    }  

    /// <summary>
    /// Salva um novo Gênero na base de dados
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>    
    [HttpPost("add")]    
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]    
    public async Task<IActionResult> Post(GenderRequest req)
    {           
        ResponseBase = new();
        try 
        {
            _logger.LogInformation("||GenderController||Post");
            return Response(await _genderAppService.Post(req));
        }
        catch (Exception ex)
        {
            _logger.LogError("||GenderController||Post");
            ResponseBase.AddNotifications(new Notification() { Message = ex.Message });
        }
        return Response(ResponseBase);
    } 

    /// <summary>
    /// Atualiza um Gênero na base de dados
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    [HttpPut("update")]    
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]    
    public async Task<IActionResult> Put(GenderRequest req)
    {           
        ResponseBase = new();
        try 
        {
            _logger.LogInformation("||GenderController||Put");
            return Response(await _genderAppService.Put(req));
        }
        catch (Exception ex)
        {
            _logger.LogError("||GenderController||Put");
            ResponseBase.AddNotifications(new Notification() { Message = ex.Message });
        }
        return Response(ResponseBase);
    }  

    /// <summary>
    /// Exclui um Gênero da base de dados
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>  
    [HttpDelete("delete/{id}")]    
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]    
    public async Task<IActionResult> Delete(Guid Id)
    {           
        ResponseBase = new();
        try 
        {
            _logger.LogInformation("||GenderController||Delete");
            return Response(await _genderAppService.Delete(Id));
        }
        catch (Exception ex)
        {
            _logger.LogError("||GenderController||Delete");
            ResponseBase.AddNotifications(new Notification() { Message = ex.Message });
        }
        return Response(ResponseBase);
    }                     
}    
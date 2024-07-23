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
public class AuthorController(ILogger<IAuthorAppService> logger,  IAuthorAppService authorAppService) : BaseController
{
    private readonly ILogger _logger = logger;
    private readonly IAuthorAppService _authorAppService = authorAppService;
    
    /// <summary>
    /// Retorna Lista de Autores
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
            _logger.LogInformation("||AuthorController||Get");
            return Response(await _authorAppService.GetAsync());
        }
        catch (Exception ex)
        {
            _logger.LogError("||AuthorController||Get");
            ResponseBase.AddNotifications(new Notification() { Message = ex.Message });
        }
        return Response(ResponseBase);
    }    

    /// <summary>
    /// Pesquisa um Autor através do Id
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
            _logger.LogInformation("||AuthorController||GetById");
            return Response(await _authorAppService.GetAsync(Id));
        }
        catch (Exception ex)
        {
            _logger.LogError("||AuthorController||GetById");
            ResponseBase.AddNotifications(new Notification() { Message = ex.Message });
        }
        return Response(ResponseBase);
    }  

    /// <summary>
    /// Salva um novo Autor na base de dados
    /// </summary>    
    /// <param name="req"></param>
    /// <returns></returns>    
    [HttpPost("add")]    
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]    
    public async Task<IActionResult> Post(AuthorRequest req)
    {           
        ResponseBase = new();
        try 
        {
            _logger.LogInformation("||AuthorController||Post");
            return Response(await _authorAppService.Post(req));
        }
        catch (Exception ex)
        {
            _logger.LogError("||AuthorController||Post");
            ResponseBase.AddNotifications(new Notification() { Message = ex.Message });
        }
        return Response(ResponseBase);
    } 

    /// <summary>
    /// Atualiza um Autor na base de dados
    /// </summary>
    /// <returns></returns>    
    [HttpPut("update")]    
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]    
    public async Task<IActionResult> Put(AuthorRequest req)
    {           
        ResponseBase = new();
        try 
        {
            _logger.LogInformation("||AuthorController||Put");
            return Response(await _authorAppService.Put(req));
        }
        catch (Exception ex)
        {
            _logger.LogError("||AuthorController||Put");
            ResponseBase.AddNotifications(new Notification() { Message = ex.Message });
        }
        return Response(ResponseBase);
    }  

    /// <summary>
    /// Exclui um Autor da base de dados
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
            _logger.LogInformation("||AuthorController||Delete");
            return Response(await _authorAppService.Delete(Id));
        }
        catch (Exception ex)
        {
            _logger.LogError("||AuthorController||Delete");
            ResponseBase.AddNotifications(new Notification() { Message = ex.Message });
        }
        return Response(ResponseBase);
    }                     
}    
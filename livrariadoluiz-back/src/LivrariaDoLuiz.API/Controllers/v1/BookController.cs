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
public class BookController(ILogger<IBookAppService> logger,  IBookAppService BookAppService) : BaseController
{
    private readonly ILogger _logger = logger;
    private readonly IBookAppService _bookAppService = BookAppService;
    
    /// <summary>
    /// Retorna Lista de Livros
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
            _logger.LogInformation("||BookController||Get");
            return Response(await _bookAppService.GetAsync());
        }
        catch (Exception ex)
        {
            _logger.LogError("||BookController||Get");
            ResponseBase.AddNotifications(new Notification() { Message = ex.Message });
        }
        return Response(ResponseBase);
    }    

    /// <summary>
    /// Pesquisa um Livro através do Id
    /// </summary>
    /// <returns></returns>    
    [HttpGet("{id}")]    
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(Response))]   
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]    
    public async Task<IActionResult> GetById(Guid id)
    {           
        ResponseBase = new();
        try 
        {
            _logger.LogInformation("||BookController||GetById");
            return Response(await _bookAppService.GetAsync(id));
        }
        catch (Exception ex)
        {
            _logger.LogError("||BookController||GetById");
            ResponseBase.AddNotifications(new Notification() { Message = ex.Message });
        }
        return Response(ResponseBase);
    }  

    /// <summary>
    /// Salva um novo Livro na base de dados
    /// </summary>
    /// <returns></returns>    
    [HttpPost]    
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]    
    public async Task<IActionResult> Post(BookRequest req)
    {           
        ResponseBase = new();
        try 
        {
            _logger.LogInformation("||BookController||Post");
            return Response(await _bookAppService.Post(req));
        }
        catch (Exception ex)
        {
            _logger.LogError("||BookController||Post");
            ResponseBase.AddNotifications(new Notification() { Message = ex.Message });
        }
        return Response(ResponseBase);
    } 

    /// <summary>
    /// Atualiza um Livro na base de dados
    /// </summary>
    /// <returns></returns>    
    [HttpPut]    
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]    
    public async Task<IActionResult> Put(BookRequest req)
    {           
        ResponseBase = new();
        try 
        {
            _logger.LogInformation("||BookController||Put");
            return Response(await _bookAppService.Put(req));
        }
        catch (Exception ex)
        {
            _logger.LogError("||BookController||Put");
            ResponseBase.AddNotifications(new Notification() { Message = ex.Message });
        }
        return Response(ResponseBase);
    }  

    /// <summary>
    /// Exclui um Autor da base de dados
    /// </summary>
    /// <returns></returns>    
    [HttpDelete]    
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(Response))]    
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]    
    public async Task<IActionResult> Delete(Guid Id)
    {           
        ResponseBase = new();
        try 
        {
            _logger.LogInformation("||BookController||Delete");
            return Response(await _bookAppService.Delete(Id));
        }
        catch (Exception ex)
        {
            _logger.LogError("||BookController||Delete");
            ResponseBase.AddNotifications(new Notification() { Message = ex.Message });
        }
        return Response(ResponseBase);
    }                     
}    
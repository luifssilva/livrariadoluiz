using AutoMapper;
using LivrariaDoLuiz.Application.Entity;
using LivrariaDoLuiz.Application.Interface;
using LivrariaDoLuiz.Application.Notifications;
using LivrariaDoLuiz.Domain.DTO;
using LivrariaDoLuiz.Domain.Entity;
using LivrariaDoLuiz.Domain.Interface.Service;

namespace LivrariaDoLuiz.Application.Service;
public class AuthorAppService(IMapper Mapper, IAuthorService AuthorService) : IAuthorAppService
{
    private readonly IMapper _mapper = Mapper;
    private readonly IAuthorService _authorService = AuthorService;
    private Response response { get; set; } = null!;

    public async Task<Response> GetAsync()
    {
        try 
        {
            response = new();
            var authors = _mapper.Map<IEnumerable<AuthorResponse>>(await _authorService.GetAsync());
            if (authors.Any())
                response.AddValue(authors);
            else
                response.AddNotifications(new Notification() 
                { 
                    Error = nameof(CommonNotifications.DataNotFound),
                    Message = CommonNotifications.DataNotFound
                }); 
        }
        catch
        {
            response.AddNotifications(new Notification() 
            { 
                Error = nameof(CommonNotifications.InternalServerError),
                Message = CommonNotifications.InternalServerError
            }); 
        }
        return response;
    }

    public async Task<Response> GetAsync(Guid Id)
    {
        try 
        {
            response = new();
            var author = _mapper.Map<AuthorResponse>(await _authorService.GetAsync(Id));
            if (author is not null)
                response.AddValue(author);
            else
                response.AddNotifications(new Notification() 
                { 
                    Error = nameof(CommonNotifications.DataNotFound),
                    Message = CommonNotifications.DataNotFound
                }); 
        }
        catch
        {
            response.AddNotifications(new Notification() 
            { 
                Error = nameof(CommonNotifications.InternalServerError),
                Message = CommonNotifications.InternalServerError
            }); 
        }
        return response;
    }

    public async Task<Response> Post(AuthorRequest req)
    {
        try 
        {
            response = new();
            var author = _mapper.Map<Author>(req);

            await _authorService.AddAsync(author);

            await _authorService.BeginTransactionAsync();
            await _authorService.SaveAsync();
            await _authorService.CommitTransactionAsync();

            response.AddValue(new Notification() 
            { 
                Error = nameof(CommonNotifications.DataCreatedSuccessfuly),
                Message = CommonNotifications.DataCreatedSuccessfuly
            }); 
        }
        catch
        {
            await _authorService.RollbackTransactionAsync();
            response.AddNotifications(new Notification() 
            { 
                Error = nameof(CommonNotifications.InternalServerError),
                Message = CommonNotifications.InternalServerError
            }); 
        }

        return response;
    }

    
    public async Task<Response> Put(AuthorRequest req)
    {
        try 
        {
            response = new();
            var author = _mapper.Map<Author>(req);

            var authorOnDB = await _authorService.GetAsync(author.Id);
            author.CreatedAt = authorOnDB!.CreatedAt;
            
            await _authorService.EditAsync(author);

            await _authorService.BeginTransactionAsync();
            await _authorService.SaveAsync();
            await _authorService.CommitTransactionAsync();

            response.AddValue(new Notification() 
            { 
                Error = nameof(CommonNotifications.DataUpdatedSuccessfuly),
                Message = CommonNotifications.DataUpdatedSuccessfuly
            }); 
        }
        catch
        {
            await _authorService.RollbackTransactionAsync();
            response.AddNotifications(new Notification() 
            { 
                Error = nameof(CommonNotifications.InternalServerError),
                Message = CommonNotifications.InternalServerError
            }); 
        }

        return response;
    }

    public async Task<Response> Delete(Guid Id)
    {
        try 
        {
            response = new();

            var authorOnDB = await _authorService.GetAsync(Id);            
            
            await _authorService.DeleteAsync(authorOnDB!);

            await _authorService.BeginTransactionAsync();
            await _authorService.SaveAsync();
            await _authorService.CommitTransactionAsync();

            response.AddValue(new Notification() 
            { 
                Error = nameof(CommonNotifications.DataDeletedSuccessfuly),
                Message = CommonNotifications.DataDeletedSuccessfuly
            }); 
        }
        catch 
        {
            await _authorService.RollbackTransactionAsync();
            response.AddNotifications(new Notification() 
            { 
                Error = nameof(CommonNotifications.InternalServerError),
                Message = CommonNotifications.InternalServerError
            }); 
        }

        return response;
    }    
}
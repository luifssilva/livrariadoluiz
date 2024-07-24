using AutoMapper;
using LivrariaDoLuiz.Application.Entity;
using LivrariaDoLuiz.Application.Interface;
using LivrariaDoLuiz.Application.Notifications;
using LivrariaDoLuiz.Domain.DTO;
using LivrariaDoLuiz.Domain.Entity;
using LivrariaDoLuiz.Domain.Interface.Service;

namespace LivrariaDoLuiz.Application.Service;
public class BookAppService(IMapper Mapper, IBookService BookService) : IBookAppService
{
    private readonly IMapper _mapper = Mapper;
    private readonly IBookService _bookService = BookService;
    private Response response { get; set; } = null!;

    public async Task<Response> GetAsync()
    {
        try 
        {
            response = new();
            var books = _mapper.Map<IEnumerable<BookResponse>>(await _bookService.GetBooksAsync());
            if (books.Any())
                response.AddValue(books);
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
            var book = _mapper.Map<BookResponse>(await _bookService.GetBookAsync(Id));
            if (book is not null)
                response.AddValue(book);
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

    public async Task<Response> Post(BookRequest req)
    {
        try 
        {
            response = new();
            var book = _mapper.Map<Book>(req);

            await _bookService.AddAsync(book);

            await _bookService.BeginTransactionAsync();
            await _bookService.SaveAsync();
            await _bookService.CommitTransactionAsync();

            response.AddValue(new Notification() 
            { 
                Error = nameof(CommonNotifications.DataCreatedSuccessfuly),
                Message = CommonNotifications.DataCreatedSuccessfuly
            }); 
        }
        catch
        {
            await _bookService.RollbackTransactionAsync();
            response.AddNotifications(new Notification() 
            { 
                Error = nameof(CommonNotifications.InternalServerError),
                Message = CommonNotifications.InternalServerError
            }); 
        }

        return response;
    }

    
    public async Task<Response> Put(BookRequest req)
    {
        try 
        {
            response = new();
            var book = _mapper.Map<Book>(req);

            var bookOnDB = await _bookService.GetBookAsync(book.Id);
            book.CreatedAt = bookOnDB!.CreatedAt;           
                        
            await _bookService.EditAsync(book);
            
            await _bookService.BeginTransactionAsync();
            await _bookService.SaveAsync();
            await _bookService.CommitTransactionAsync();

            response.AddValue(new Notification() 
            { 
                Error = nameof(CommonNotifications.DataUpdatedSuccessfuly),
                Message = CommonNotifications.DataUpdatedSuccessfuly
            }); 
        }
        catch
        {
            await _bookService.RollbackTransactionAsync();
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

            var bookOnDB = await _bookService.GetAsync(Id);            
            
            await _bookService.DeleteAsync(bookOnDB!);

            await _bookService.BeginTransactionAsync();
            await _bookService.SaveAsync();
            await _bookService.CommitTransactionAsync();

            response.AddValue(new Notification() 
            { 
                Error = nameof(CommonNotifications.DataDeletedSuccessfuly),
                Message = CommonNotifications.DataDeletedSuccessfuly
            }); 
        }
        catch
        {
            await _bookService.RollbackTransactionAsync();
            response.AddNotifications(new Notification() 
            { 
                Error = nameof(CommonNotifications.InternalServerError),
                Message = CommonNotifications.InternalServerError
            }); 
        }

        return response;
    }    
}
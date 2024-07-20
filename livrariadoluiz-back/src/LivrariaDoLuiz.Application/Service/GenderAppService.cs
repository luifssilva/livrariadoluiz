using AutoMapper;
using LivrariaDoLuiz.Application.Entity;
using LivrariaDoLuiz.Application.Interface;
using LivrariaDoLuiz.Application.Notifications;
using LivrariaDoLuiz.Domain.DTO;
using LivrariaDoLuiz.Domain.Entity;
using LivrariaDoLuiz.Domain.Interface.Service;

namespace LivrariaDoLuiz.Application.Service;
public class GenderAppService(IMapper Mapper, IGenderService GenderService) : IGenderAppService
{
    private readonly IMapper _mapper = Mapper;
    private readonly IGenderService _genderService = GenderService;
    private Response response { get; set; } = null!;

    public async Task<Response> GetAsync()
    {
        try 
        {
            response = new();
            var genders = _mapper.Map<IEnumerable<AuthorResponse>>(await _genderService.GetAsync());
            if (genders.Any())
                response.AddValue(genders);
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
            var gender = _mapper.Map<GenderResponse>(await _genderService.GetAsync(Id));
            if (gender is not null)
                response.AddValue(gender);
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

    public async Task<Response> Post(GenderRequest req)
    {
        try 
        {
            response = new();
            var gender = _mapper.Map<Gender>(req);

            await _genderService.AddAsync(gender);

            await _genderService.BeginTransactionAsync();
            await _genderService.SaveAsync();
            await _genderService.CommitTransactionAsync();

            response.AddValue(new Notification() 
            { 
                Error = nameof(CommonNotifications.DataCreatedSuccessfuly),
                Message = CommonNotifications.DataCreatedSuccessfuly
            }); 
        }
        catch
        {
            await _genderService.RollbackTransactionAsync();
            response.AddNotifications(new Notification() 
            { 
                Error = nameof(CommonNotifications.InternalServerError),
                Message = CommonNotifications.InternalServerError
            }); 
        }

        return response;
    }

    
    public async Task<Response> Put(GenderRequest req)
    {
        try 
        {
            response = new();
            var gender = _mapper.Map<Gender>(req);

            var genderOnDB = await _genderService.GetAsync(gender.Id);
            gender.CreatedAt = genderOnDB!.CreatedAt;
            
            await _genderService.EditAsync(gender);

            await _genderService.BeginTransactionAsync();
            await _genderService.SaveAsync();
            await _genderService.CommitTransactionAsync();

            response.AddValue(new Notification() 
            { 
                Error = nameof(CommonNotifications.DataUpdatedSuccessfuly),
                Message = CommonNotifications.DataUpdatedSuccessfuly
            }); 
        }
        catch
        {
            await _genderService.RollbackTransactionAsync();
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

            var authorOnDB = await _genderService.GetAsync(Id);            
            
            await _genderService.DeleteAsync(authorOnDB!);

            await _genderService.BeginTransactionAsync();
            await _genderService.SaveAsync();
            await _genderService.CommitTransactionAsync();

            response.AddValue(new Notification() 
            { 
                Error = nameof(CommonNotifications.DataDeletedSuccessfuly),
                Message = CommonNotifications.DataDeletedSuccessfuly
            }); 
        }
        catch
        {
            await _genderService.RollbackTransactionAsync();
            response.AddNotifications(new Notification() 
            { 
                Error = nameof(CommonNotifications.InternalServerError),
                Message = CommonNotifications.InternalServerError
            }); 
        }

        return response;
    }    
}
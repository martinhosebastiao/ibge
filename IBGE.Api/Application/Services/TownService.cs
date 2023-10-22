using IBGE.Api.Application.Interfaces;
using IBGE.Api.Application.Models;
using IBGE.Api.Domain.Entities;
using IBGE.Api.Domain.Interfaces.Repositores;

namespace IBGE.Api.Application.Services
{
    public class TownService : ITownService
    {
        protected readonly ILogger logger;
        protected readonly ITownRepository townRepository;
        protected readonly IStateRepository stateRepository;
        public TownService(ITownRepository townRepository, IStateRepository stateRepository)
        {
            // this.logger = logger;
            this.townRepository = townRepository;
            this.stateRepository = stateRepository;

        }


        public async Task<DefaultResult> GetAllAsync()
        {
            try
            {
                var result = await townRepository.GetAllAsync();

                if (result != null)
                    return new DefaultResult(Success: true, Data: result);

                return new DefaultResult(Success: false, Message: "Notefound");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex?.Message);
                return new DefaultResult(Message: "An error occurred, tryagain later.!");
            }
        }

        public async Task<DefaultResult> GetByCodeAsync(int code)
        {
            try
            {
                var result = await townRepository.GetByCodeAsync(code);

                if (result != null)
                    return new DefaultResult(Success: true, Data: result);

                return new DefaultResult(Success: false, Message: "Notefound");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex?.Message);
                return new DefaultResult(Message: "An error occurred, tryagain later.!");
            }
        }

        public async Task<DefaultResult> GetByNameAsync(string name)
        {
            try
            {
                var result = await townRepository.GetByNameAsync(name);

                if (result != null)
                    return new DefaultResult(Success: true, Data: result);

                return new DefaultResult(Success: false, Message: "Notefound");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex?.Message);
                return new DefaultResult(Message: "An error occurred, tryagain later.!");
            }
        }

        public async Task<DefaultResult> CreateAsync(TownModel model)
        {
            try
            {
                var town = model.ConvertToTown();

                if (town.HasValid)
                {
                    var _town = await GetByCodeAsync(model.Code);
                    var state = await stateRepository.GetByCodeAsync(model.StateCode);

                    if (_town.Success == false && state != null)
                    {
                        town.ChangeState(state.StateId);
                        var result = await townRepository.CreateAsync(town);

                        await townRepository.CompleteAsync();

                        var data = new TownResult(result!.TownId, result.StateId, result.Code,result.Name.Value);

                        return new DefaultResult(true, Message: $"Town created successfully, name", Data: data);
                    }
                    return new DefaultResult(Message: "The Town code already exists or the State is not valid");
                }
                return new DefaultResult(Notifications: town.Notifications.ToList());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex?.Message);
                return new DefaultResult(Message: "An error occurred, tryagain later.!");
            }
        }

        public async Task<DefaultResult> UpdateAsync(TownModel model)
        {
            try
            {
                var town = model.ConvertToTown();

                if (town.HasValid)
                {
                    var _town = await townRepository.GetByIdAsync(model.TownId);
                    var state = await stateRepository.GetByCodeAsync(model.StateCode);

                    if (_town != null && state != null)
                    {
                        _town.ChangeState(state.StateId);
                        _town.ChangeCode(model.Code);
                        _town.ChangeName(model.Name);

                        var result = townRepository.Update(_town);

                        await townRepository.CompleteAsync();

                        var data = new TownResult(result!.StateId, result.StateId, result.Code, Name: result.Name.Value);

                        return new DefaultResult(true, Message: $"Town update success", Data: data);
                    }
                    return new DefaultResult(Message: "The Town code already exists or the State is not valid");
                }
                return new DefaultResult(Notifications: town.Notifications.ToList());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex?.Message);
                return new DefaultResult(Message: "An error occurred, tryagain later.!");
            }
        }

        public async Task<DefaultResult> DeleteAsync(byte c)
        {
            try
            {
                var state = await townRepository.GetByIdAsync(townRepository);

                if (state != null)
                {
                    var result = townRepository.Delete(state);

                    await townRepository.CompleteAsync();

                    return new DefaultResult(true, Message: $"The Town {state.Name.Value} was Deleted", Data: result);
                }

                return new DefaultResult(Message: "The Town not exist or invalid");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex?.Message);
                return new DefaultResult(Message: "An error occurred, tryagain later.!");
            }
        }
    }
}


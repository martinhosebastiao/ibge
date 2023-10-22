using IBGE.Api.Application.Interfaces;
using IBGE.Api.Application.Models;
using IBGE.Api.Domain.Entities;
using IBGE.Api.Domain.Interfaces.Repositores;

namespace IBGE.Api.Application.Services
{
    public class StateService : IStateService
    {
        protected readonly ILogger logger;
        protected readonly IStateRepository stateRepository;
        public StateService(IStateRepository stateRepository)
        {
            // this.logger = logger;
            this.stateRepository = stateRepository;
        }

        public async Task<DefaultResult> GetAllAsync()
        {
            try
            {
                var result = await stateRepository.GetAllAsync();

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

        public async Task<DefaultResult> GetByAcronymAsync(string acronym)
        {
            try
            {
                var result = await stateRepository.GetByAcronymAsync(acronym);

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

        public async Task<DefaultResult> GetByCodeAsync(byte code)
        {
            try
            {
                var result = await stateRepository.GetByCodeAsync(code);

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
                var result = await stateRepository.GetByNameAsync(name);

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

        public async Task<DefaultResult> CreateAsync(StateModel model)
        {
            try
            {
                var state = model.ConvertToState();

                if (state.HasValid)
                {
                    var _state = await stateRepository.GetByAcronymAsync(state.Acronym);

                    if (_state == null)
                    {
                        var result = await stateRepository.CreateAsync(state);

                        await stateRepository.CompleteAsync();

                        var data = new StateResult(result!.StateId, result.Code, result.Acronym, Name: result.Name.Value);

                        return new DefaultResult(true, Message: $"State id {result?.StateId} created successfully, name {result?.Name.Value}", Data: data);
                    }
                    return new DefaultResult(Message: "The Acronym or State is already in use");
                }
                return new DefaultResult(Notifications: state.Notifications.ToList());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex?.Message);
                return new DefaultResult(Message: "An error occurred, tryagain later.!");
            }
        }

        public async Task<DefaultResult> UpdateAsync(StateModel model)
        {
            try
            {
                var state = model.ConvertToState();

                if (state.HasValid)
                {
                    var _state = await stateRepository.GetByIdAsync(model.StateId);

                    if (_state != null)
                    {
                        _state.ChangeAcronym(model.Acronym);
                        _state.ChangeCode(model.Code);
                        _state.ChangeName(model.Name);

                        var result = stateRepository.Update(_state);

                        await stateRepository.CompleteAsync();

                        var data = new StateResult(result!.StateId, result.Code, result.Acronym, Name: result.Name.Value);

                        return new DefaultResult(true, Message: $"State id {result?.StateId} updates successfully, name {result?.Name.Value}", Data: data);
                    }
                    return new DefaultResult(Message: "The State not exist or invalid");
                }
                return new DefaultResult(Notifications: state.Notifications.ToList());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex?.Message);
                return new DefaultResult(Message: "An error occurred, tryagain later.!");
            }
        }


        public async Task<DefaultResult> DeleteAsync(byte stateId)
        {
            try
            {
                var state = await stateRepository.GetByIdAsync(stateId);

                if (state != null)
                {
                    var result = stateRepository.Delete(state);

                    await stateRepository.CompleteAsync();

                    return new DefaultResult(true, Message: $"The state {state.Name.Value} was Deleted", Data: result);
                }

                return new DefaultResult(Message: "The State not exist or invalid");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex?.Message);
                return new DefaultResult(Message: "An error occurred, tryagain later.!");
            }
        }
    }
}


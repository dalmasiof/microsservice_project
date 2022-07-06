using FluentValidation;
using UserService.Model;
using UserService.Service.Interface;
using UserService.Service.Validator;
using UserService.Requisitions;
using AutoMapper;

namespace UserService.Service
{
    public class User_Service : IUserService
    {
        private readonly IReqs _reqs;
        private readonly IMapper _mapper;


        public User_Service(IReqs reqs, IMapper mapper)
        {
            _reqs = reqs;
            _mapper = mapper;
        }
        public async Task<UserDTO> Create(UserDTO entity)
        {
            Validate(entity);
            var userToCreate = _mapper.Map<UserData>(entity);
            var userVMCreated= _mapper.Map<UserDTO>(await _reqs.Post(userToCreate));
            return userVMCreated;

        }

        public async Task<bool> Delete(long Id)
        {
            return (await _reqs.Delete(Id));
        }

        public async Task<IEnumerable<UserDTO>> Get()
        {
            var userDto = _mapper.Map<IEnumerable<UserDTO>>(await _reqs.Get()) ;
            return userDto;
        }

        public async Task<UserDTO> Get(long Id)
        {
            var userToGet = _mapper.Map<UserDTO>(await _reqs.Get(Id));
            return userToGet;
        }

        public async Task<UserDTO> Update(UserDTO entity)
        {
            Validate(entity);
            var userToUpdate = _mapper.Map<UserData>(entity);
            var userTdUpdated = _mapper.Map<UserDTO>(await _reqs.Put(userToUpdate));
            return userTdUpdated;
        }

        public void Validate(UserDTO obj)
        {
            UserValidator  validationRules = new UserValidator();
            validationRules.ValidateAndThrow(obj);
        }

        
    }
}

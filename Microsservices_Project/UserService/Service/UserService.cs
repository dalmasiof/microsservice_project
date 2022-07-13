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
        private readonly IUserRequest _reqs;
        private readonly IMapper _mapper;


        public User_Service(IUserRequest reqs, IMapper mapper)
        {
            _reqs = reqs;
            _mapper = mapper;
        }
        public async Task<UserVM> Create(UserVM entity)
        {
            Validate(entity);
            var userToCreate = _mapper.Map<UserData>(entity);
            var userVMCreated= _mapper.Map<UserVM>(await _reqs.Create(userToCreate));
            return userVMCreated;

        }

        public async Task<bool> Delete(long Id)
        {
            return (await _reqs.Delete(Id));
        }

        public async Task<IEnumerable<UserVM>> Get()
        {
            var userDto = _mapper.Map<IEnumerable<UserVM>>(await _reqs.Get()) ;
            return userDto;
        }

        public async Task<UserVM> Get(long Id)
        {
            var user = await _reqs.Get(Id);

            var userToGet = _mapper.Map<UserVM>(user);
            return userToGet;
        }

        public async Task<UserVM> Update(UserVM entity)
        {
            Validate(entity);
            var userToUpdate = _mapper.Map<UserData>(entity);
            var userTdUpdated = _mapper.Map<UserVM>(await _reqs.Update(userToUpdate));
            return userTdUpdated;
        }

        public void Validate(UserVM obj)
        {
            UserValidator  validationRules = new UserValidator();
            validationRules.ValidateAndThrow(obj);
        }

        
    }
}

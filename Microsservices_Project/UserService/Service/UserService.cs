using FluentValidation;
using UserService.Model;
using UserService.Service.Interface;
using UserService.Service.Validator;
using UserService.Requisitions;

namespace UserService.Service
{
    public class User_Service : IUserService
    {
        private readonly IReqs _reqs;

        public User_Service(IReqs reqs)
        {
            _reqs = reqs;
        }
        public UserDTO Create(UserDTO entity)
        {
            Validate(entity);
            throw new NotImplementedException();
        }

        public UserDTO Delete(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDTO>> Get()
        {
            var teste = await _reqs.Get();
            
            throw new NotImplementedException();
        }

        public UserDTO Get(int Id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public UserDTO Update(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Validate(UserDTO obj)
        {
            UserValidator  validationRules = new UserValidator();
            validationRules.ValidateAndThrow(obj);
        }

        
    }
}

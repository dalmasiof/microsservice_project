using FluentValidation;
using UserService.Model;
using UserService.Service.Interface;
using UserService.Service.Validator;

namespace UserService.Service
{
    public class User_Service : IUserService
    {

    

        public UserDTO Create(UserDTO entity)
        {
            Validate(entity);
            throw new NotImplementedException();
        }

        public UserDTO Delete(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> Get(UserDTO entity)
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

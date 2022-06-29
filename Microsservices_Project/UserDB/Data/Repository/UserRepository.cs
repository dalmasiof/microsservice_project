using Microsoft.EntityFrameworkCore;
using UserDB.Data.Context;


namespace UserDB.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextOptions<UserContext> _context;

        public UserRepository(DbContextOptions<UserContext> context)
        {
            _context = context;
        }


        public UserData Create(UserData entity)
        {
             using var _userctx = new UserContext(_context);

                _userctx.Add(entity);
            _userctx.SaveChanges();

            return entity;
        }

        public UserData Delete(UserData entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserData> Get(UserData entity)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            using var _userctx = new UserContext(_context);

            if (_userctx.SaveChanges() > 0)
                return true;

            return false;
        }

        public UserData Update(UserData entity)
        {
            throw new NotImplementedException();
        }
    }
}

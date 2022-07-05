using UserDB.Data.Context;


namespace UserDB.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public UserData Create(UserData entity)
        {

            _context.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Delete(UserData entity)
        {
            _context.UserDatas.Remove(entity);
             return SaveChanges();

        }

        public IEnumerable<UserData> Get()
        {
            return _context.UserDatas;
        }

        public UserData GetById(long Id) => _context.UserDatas.Where(x => x.Id == Id).FirstOrDefault();

        public bool SaveChanges()
        {
            if (_context.SaveChanges() > 0)
                return true;

            return false;
        }

        public UserData Update(UserData entity)
        {
            _context.UserDatas.Update(entity);
            SaveChanges();
            return entity;
        }
    }
}

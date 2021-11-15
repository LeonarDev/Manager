namespace Manager.Infra.Repositories
{
    public class UserRepository : BaseRepository<UserRepository>, IUserRepository
    {
        private readonly ManagerContext _context;

    public UserRepository(ManagerContext context)
    {
      _context = context;
    }

    public async Task<UserRepository> GetByEmail(string email){
        var user = await _context.Users
                                 .Where(x => x.Email.ToLower() == email.ToLower())
                                 .AsNoTracking()
                                 .ToListAsync();
        return user.FirstOrDefault();
    }

    public async Task<List<User>> SearchByEmail(string email){
        var allUsers = await _context.Users
                                     .Where(x => x.Email.ToLower().Contains(email.ToLower()))
                                     .AsNoTracking()
                                     .ToListAsync();
        return allUsers;
    }

    public async Task<List<User>> SearchByName(string name){
        var allUsers = await _context.Users
                                     .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                                     .AsNoTracking()
                                     .ToListAsync();
        return allUsers;
    }
  }
}
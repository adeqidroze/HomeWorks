using AutoMapper;
using Database.Data;
using System.Linq;
using webApiWithDb.DTOs;

namespace webApiWithDb.Services
{
    public interface IUserInterface
    {
        CredentialsDto Login(CredentialsDto model);
        CredentialsDto GetById(int id);
        CredentialsDto GetAll();

    }
    public class UserService : IUserInterface
    {
        private readonly IMapper _mapper;

        private readonly PersonContext _context;
        public UserService(PersonContext personContext, IMapper mapper)
        {
            _mapper = mapper;
            _context = personContext;
        }

        public CredentialsDto GetAll()
        {
            var myCreds = _context.Credentials.ToList();
            return _mapper.Map<CredentialsDto>(myCreds);
        }

        public CredentialsDto GetById(int id)
        {
            var myCreds = _context.Credentials.Where(x => x.Id == id);
            return _mapper.Map<CredentialsDto>(myCreds);
        }

        public CredentialsDto Login(CredentialsDto loginModel)
        {
            if(string.IsNullOrEmpty(loginModel.Username) || string.IsNullOrEmpty(loginModel.Password))
            {
                return null;
            }
            var userCreds = _context.Credentials.SingleOrDefault(x => x.Username == loginModel.Username);
            if(userCreds == null)
            {
                return null;
            }
            if(userCreds.Password != loginModel.Password)
            {
                return null;
            }
            return _mapper.Map<CredentialsDto>(userCreds);
        }
    }
}

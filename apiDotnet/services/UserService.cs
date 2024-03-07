using apiDotnet.data;
using apiDotnet.models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.OpenApi.Any;

namespace apiDotnet.services
{
    public class UserService : IUserService
    {

        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<int> CreateUser(User user)
        {
            var userBody = new User { Address = user.Address, Email = user.Email, Age = user.Age, FatherLastName = user.FatherLastName, FirstName = user.FirstName, Genre = user.Genre, MotherLastName = user.MotherLastName, Phone = user.Phone, SecondName = user.SecondName };

            await _context.Users.AddAsync(userBody);

            return await _context.SaveChangesAsync();
        }

        public Genre CountGenre(string genre)
        {
            var list = _context.Users.Where(user => user.Genre == genre);
            var count = list.Count();

            return new Genre{Count = count, UserList = new List<User>(list)};
        }

        public User? FindMaxAge()
        {
            return _context.Users.OrderBy(user => user.Age).Last();
        }

        public async Task<Average> AverageAge()
        {
            var res = await _context.Users.AverageAsync(user => user.Age);

            return new Average{Data=res};
        }

        public async Task<List<User>> FindUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
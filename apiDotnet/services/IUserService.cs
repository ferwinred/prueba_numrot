using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiDotnet.models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.OpenApi.Any;

namespace apiDotnet.services
{
    public interface IUserService
    {
        Task<List<User>> FindUsers();

        Genre CountGenre(string genre);

        Task<int> CreateUser(User user);

        User? FindMaxAge();

        Task<Average> AverageAge();
    }
}
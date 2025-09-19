using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Toska.Data;
using Toska.DTOs.User;
using Toska.Models;

namespace Toska.Services.Users
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(CreateUserDto dto);
        // later:  GetAll, GetById, Update, Delete
        //Task<User?> GetUserByIdAsync(int id);
        //Task<IEnumerable<User>> GetAllUsersAsync();
        //Task<User?> UpdateUserAsync(User user);
        //Task<bool> DeleteUserAsync(int id);
    }
}

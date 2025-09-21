using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Toska.Data;
using Toska.DTOs.User;
using Toska.Models;

namespace Toska.Services.Users
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IPasswordHasher<User> passwordHasher, IMapper mapper)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }



        public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
        {

            //1. Normalize Email Before Checking
            dto.Email = dto.Email.Trim().ToLower();


            //2. Email Uniqueness Check
            var exists = await _context.Users.AnyAsync(u => u.Email.ToLower() == dto.Email);
            if (exists)
            {
                throw new InvalidOperationException("Email is already in use.");
            }



            //3.
            //Map CreateUserDTO → UserDto
            //Create User Entity
            var user = _mapper.Map<User>(dto);

            user.PublicId = Guid.NewGuid();
            user.CreateDate = DateTime.UtcNow;
            user.IsActive = true;
            user.IsDeleted = false;
            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);



            //4. Save to DB
            _context.Users.Add(user);
            await _context.SaveChangesAsync();



            //5. Map User to UserDTO and return
            return _mapper.Map<UserDto>(user);



        }
    }
}
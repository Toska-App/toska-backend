using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Toska.Data;
using Toska.DTOs.User;
using Toska.Exceptions;
using Toska.Models;
using Toska.Utility;

namespace Toska.Services.Users
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(AppDbContext context, IPasswordHasher<User> passwordHasher, IMapper mapper, ILogger<UserService> logger)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _logger = logger;
        }



        public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
        {

            //1. Normalize Email Before Checking
            dto.Email = dto.Email.Trim().ToLower();
            _logger.LogDebug("Creating user with email {Email}", dto.Email);



            //2. Email Uniqueness Check
            var exists = await _context.Users.IgnoreQueryFilters().AnyAsync(u => u.Email.ToLower() == dto.Email);
            if (exists)
            {
                _logger.LogWarning("User creation failed. Email already exists");
                throw new DuplicateEmailException(dto.Email);
            }



            //3.
            //Map CreateUserDTO → UserDto
            //Create User Entity
            var user = _mapper.Map<User>(dto);

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);



            //4. Save to DB
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            _logger.LogInformation("User created successfully with PublicId {PublicId}", user.PublicId);



            //5. Map User to UserDTO and return
            return _mapper.Map<UserDto>(user);


        }
    }
}
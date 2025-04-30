using UserManagementAPI.Models;
using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDTO>> GetAllUsersAsync();
        Task<UserResponseDTO?> GetUserByIdAsync(int id);
        Task<UserResponseDTO> CreateUserAsync(CreateUserDTO userDto);
        Task<UserResponseDTO?> UpdateUserAsync(int id, UpdateUserDTO userDto);
        Task<bool> DeleteUserAsync(int id);
    }

    public class UserService : IUserService
    {
        private readonly List<User> _users = new();
        private int _nextId = 1;

        public async Task<IEnumerable<UserResponseDTO>> GetAllUsersAsync()
        {
            return _users.Select(u => MapToResponseDTO(u));
        }

        public async Task<UserResponseDTO?> GetUserByIdAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return user != null ? MapToResponseDTO(user) : null;
        }

        public async Task<UserResponseDTO> CreateUserAsync(CreateUserDTO userDto)
        {
            var user = new User
            {
                Id = _nextId++,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password,
                CreatedAt = DateTime.UtcNow
            };

            _users.Add(user);
            return MapToResponseDTO(user);
        }

        public async Task<UserResponseDTO?> UpdateUserAsync(int id, UpdateUserDTO userDto)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return null;

            if (userDto.FirstName != null) user.FirstName = userDto.FirstName;
            if (userDto.LastName != null) user.LastName = userDto.LastName;
            if (userDto.Email != null) user.Email = userDto.Email;
            if (userDto.Password != null) user.Password = userDto.Password;
            
            user.UpdatedAt = DateTime.UtcNow;
            return MapToResponseDTO(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;

            _users.Remove(user);
            return true;
        }

        private static UserResponseDTO MapToResponseDTO(User user)
        {
            return new UserResponseDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }
    }
} 
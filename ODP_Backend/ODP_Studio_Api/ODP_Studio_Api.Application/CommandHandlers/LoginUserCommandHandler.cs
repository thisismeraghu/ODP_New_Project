using AutoMapper;
using MediatR;
using ODP_Studio_Api.Application.Commands;
using ODP_Studio_Api.Application.DTOs;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.Exceptions;
using ODP_Studio_Api.Domain.Interfaces;

namespace ODP_Studio_Api.Application.CommandHandlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserLoginInfoDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenService tokenService, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<UserLoginInfoDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //var user = await _userRepository.GetByUsernameAsync(request.Username);
            //if (user == null || !user.VerifyPassword(request.Password, _passwordHasher))
            //    //if (user == null)
            //    throw new AuthenticationException("Invalid username or password");
            //var token = _tokenService.GenerateToken(user);

            //var responseDto = _mapper.Map<LoginResponseDto>(user);
            //responseDto.Token = token;
            //return responseDto;

            var user = await _userRepository.GetUserWithRolesAndOrgAsync(request.Username);
            if (user == null || !user.VerifyPassword(request.Password, _passwordHasher))
                throw new AuthenticationException("Invalid username or password");
            var token = _tokenService.GenerateToken(user);
            var userDto = _mapper.Map<UserLoginInfoDto>(user);
            userDto.Token = token;
            return userDto;
        }
    }
}
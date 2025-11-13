using AutoMapper;
using FluentValidation;
using MediatR;
using ODP_Studio_Api.Application.Commands;
using ODP_Studio_Api.Application.DTOs.ResponseDTOs;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.Exceptions;
using ODP_Studio_Api.Domain.Interfaces;

namespace ODP_Studio_Api.Application.CommandHandlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponseDto>
    {
        private readonly IValidator<LoginResponseDto> _responseValidator;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher,
            ITokenService tokenService, IMapper mapper, IValidator<LoginResponseDto> responseValidator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _mapper = mapper;
            _responseValidator = responseValidator;
        }

        public async Task<LoginResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
           
            var user = await _userRepository.GetUserWithRolesAndOrgAsync(request.Username);
            if (user == null || !user.VerifyPassword(request.Password, _passwordHasher))
                throw new AuthenticationException("Invalid username or password");
            var token = _tokenService.GenerateToken(user.UserProfile);
            var responseDto = _mapper.Map<LoginResponseDto>(user);
            responseDto.Token = token;
            var validationResult = await _responseValidator.ValidateAsync(responseDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                // Extract error messages as strings
                var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage);

                // Throw your custom ValidationException with error messages
                throw new Domain.Exceptions.ValidationException("Validation failed", errorMessages);
            }

            return responseDto;
        }
    }
}
﻿namespace CupAPI.Application.Dtos.AuthDtos;

public sealed class LoginDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
﻿using CupAPI.Application.Common.Helpers.PasswordHasher.Abstract;

namespace CupAPI.Application.Common.Helpers.PasswordHasher.Concrete;

public sealed class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
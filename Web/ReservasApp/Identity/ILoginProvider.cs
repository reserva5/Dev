﻿using System.Security.Claims;

namespace ReservasApp.Identity
{
    public interface ILoginProvider
    {
        bool ValidateCredentials(string userName, string password, out ClaimsIdentity identity);
    }
}

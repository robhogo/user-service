using RoBHo_UserService.Models;
using RoBHo_UserService.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoBHo_UserService.Services
{
    public interface IAuthLogic
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        bool Register(RegisterRequest model);
    }
}

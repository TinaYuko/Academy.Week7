using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.Core.Repositories;
using Avanade.Allocation.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Allocation.Core.BL
{
    public class AuthenticationBusinessLayer
    {
        private IUserRepository userRepo;

        public AuthenticationBusinessLayer(IUserRepository repo)
        {
            userRepo = repo;
        }
        public Response SignIn(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return new Response() { Success = false, Message="Invalid Username" };
            }
            if (string.IsNullOrEmpty(password))
            {
                return new Response() { Success = false, Message = "Invalid Password" };
            }
            //Verifico se esiste l'utente
            User existingUser = GetUserByUsername(userName);
            //Se l'utente non esiste, non vado oltre
            if (existingUser == null)
            {
                return new Response() { Success = false, Message = "Inexhistent user" };
            }
            //verifico la password
            if (!existingUser.Password.Equals(password))
            {
                return new Response { Success = false, Message = "Incorrect password" };
            }
            return new Response() { Success = true, Message = "User authenticated" };
        }

        public async Task<Response> SignInAsync(string userName, string password)
        {
            //validazione argomenti
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            //richiamo login
            var response= SignIn(userName, password);

            //Simulo un ritardo
            await Task.Delay(5000);

            return response;
        }

        private User GetUserByUsername(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }
            return userRepo.GetByUserName(userName);
        }
    }
}

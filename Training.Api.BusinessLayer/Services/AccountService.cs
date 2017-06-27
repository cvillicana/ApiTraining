namespace Training.Api.BusinessLayer.Services
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Training.Api.DataLayer.Models;
    using Training.Api.BusinessLayer.DTO;
    using System.Linq;
    using System.Collections.Generic;

    public class AccountService
    {
        private DbContextOptionsBuilder _optionsBuilder;

        public AccountService(string connectionString)
        {
            _optionsBuilder = new DbContextOptionsBuilder();
            _optionsBuilder.UseSqlServer(connectionString);
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            try
            {
                using (var db = new ApiTrainingContext(_optionsBuilder.Options))
                {
                    return db.User.Select(query => new UserDTO
                    {
                        Id = query.Id,
                        Name = query.Name
                    }).ToList();
                }

            }
            catch(Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }


        }

        public UserDTO AddUser(UserDTO newUser)
        {
            try
            {
                using (var db = new ApiTrainingContext(_optionsBuilder.Options))
                {
                    var userExist = db.User.FirstOrDefault(query => query.Email == newUser.Email);
                    if(userExist == null)
                    {
                        var user = new User()
                        {
                            Id = Guid.NewGuid(),
                            Name = newUser.Name,
                            Email = newUser.Email
                        };
                        db.User.Add(user);
                        db.SaveChanges();
                        return new UserDTO { Name = user.Name, Email = user.Email};
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}

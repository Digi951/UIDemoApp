using DemoApp.WPF.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Net;

namespace DemoApp.WPF.Repositories;
public class UserRepository : RepositoryBase, IUserRepository
{
    public void Add(UserModel userModel)
    {
        
    }

    public bool AuthenticateUser(NetworkCredential credential)
    {
        Boolean validUser;

        using (var connection = GetConnection())
        using (var command = new SQLiteCommand())
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "select * from User where username = @username and password = @password";
            command.Parameters.Add(new SQLiteParameter("@username", credential.UserName));
            command.Parameters.Add(new SQLiteParameter("@password", credential.Password));
            var result = command.ExecuteNonQuery();

            validUser = result == 0 ? false : true;
        }

        return validUser;
    }

    public void Edit(UserModel userModel)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UserModel> GetByAll()
    {
        throw new NotImplementedException();
    }

    public UserModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public UserModel GetByUsername(string username)
    {
        UserModel user = null;

        using (var connection = GetConnection())
        using (var command = new SQLiteCommand())
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "select * from User where username = @username";
            command.Parameters.Add(new SQLiteParameter("@username", username));          
            using (var reader = command.ExecuteReader())
            {
                if(reader.Read())
                {
                    user = new UserModel
                    {
                        Id = reader[0].ToString(),
                        Username = reader[1].ToString(),
                        Password = String.Empty,
                        Name = reader[3].ToString(),
                        LastName = reader[4].ToString(),
                        Email = reader[5].ToString(),
                    };
                }
            }
        }

        return user;
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }
}

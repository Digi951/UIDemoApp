using System;
using System.Collections.Generic;
using System.Net;

namespace DemoApp.WPF.MVVM.Model;

public interface IUserRepository
{
    Boolean AuthenticateUser(NetworkCredential credential);
    void Add(UserModel userModel);
    void Edit(UserModel userModel);
    void Remove(Int32 id);
    UserModel GetById(Int32 id);
    UserModel GetByUsername(String username);
    IEnumerable<UserModel> GetByAll();
}

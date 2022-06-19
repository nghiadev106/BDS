using BDS.Model;
using BDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BDS.Services
{
    public interface IUserService
    {
        int Login(string userName, string passWord);
        User GetUserDetail(string userName, string passWord);
        User Add(RegisterRequest userModel);
        User Delete(int id);
        List<User> GetListUser();
        User GetUserDetail(int Id);
        User GetUserName(string UserName);
    }
    public class UserService : IUserService
    {
        private readonly BDSContext _context;

        public UserService(BDSContext context)
        {
            _context = context;
        }

        public User GetUserDetail(string userName, string passWord)
        {
            return _context.Users.SingleOrDefault(x => x.Username == userName && x.Password == passWord);
        }

        public int Login(string userName, string passWord)
        {
            var result = _context.Users.Where(x => x.Status == 1).SingleOrDefault(x => x.Username == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status != 1)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                        return 1;
                    else
                        return -2;
                }

            }
        }

        public User Add(RegisterRequest userModel)
        {
            var newUser = new User();
            newUser.Username = userModel.Username;
            newUser.Password = userModel.Password;
            newUser.FullName = userModel.FullName;
            newUser.Status = 1;
            newUser.CreateDate = DateTime.Now;

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public User Delete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public List<User> GetListUser()
        {
            var lst = _context.Users.ToList();
            return lst;
        }

        public User GetUserName(string UserName)
        {
            var lst = _context.Users.SingleOrDefault(x => x.Username == UserName);
            return lst;
        }

        public User GetUserDetail(int Id)
        {
            var lst = _context.Users.SingleOrDefault(x => x.Id == Id);
            return lst;
        }
    }
}

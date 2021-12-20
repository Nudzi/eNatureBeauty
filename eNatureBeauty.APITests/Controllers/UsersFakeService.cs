using eNatureBeauty.Model.Requests;
using eNatureBeauty.Model;
using eNatureBeauty.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace eNatureBeauty.APITests.Controllers
{
    public class UsersFakeService : IUsersService
    {
        private readonly List<Users> _list;
        public UsersFakeService()
        {
            _list = new List<Users>()
            {
                new Users()
                {
                    Id = 12,
                    FirstName = "Ime12",
                    LastName = "Prezime12",
                    UserAddressId = 1,
                    Email = "",
                    Telephone = "",
                    UserName = ""
                },
                new Users()
                {
                    Id = 123,
                    FirstName = "Ime123",
                    LastName = "Prezime123",
                    UserAddressId = 1,
                    Email = "",
                    Telephone = "",
                    UserName = "Ime123"
                },
                new Users()
                {
                    Id = 1234,
                    FirstName = "Ime1234",
                    LastName = "Prezime1234",
                    UserAddressId = 1,
                    Email = "",
                    Telephone = "",
                    UserName = ""
                }
            };
        }

        public Model.Users Authentication(string username, string pass)
        {
            var user = _list.FirstOrDefault(x => x.UserName == username);

            if (user != null)
            {
                var hashedPass = GenerateHash("Test", pass);

                Model.Users newUser = new Model.Users();

                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.UserName = user.UserName;
                newUser.Email = user.Email;
                newUser.Id = user.Id;
                newUser.Telephone = user.Telephone;

                return newUser;
            }
            return null;
        }

        public List<Model.Users> Get(UsersSearchRequest request)
        {
            if (request != null)
            {
                return _list.Where(x => x.FirstName == request?.FirstName || x.LastName == request?.LastName).ToList();
            }
            else
            {
                return _list;
            }
        }

        public Model.Users GetById(int id)
        {
            return _list.Where(user => user.Id == id).FirstOrDefault();
        }

        public Model.Users Insert(UsersInsertRequest request)
        {
            var user = new Users
            {
                Id = request.Id,
                UserAddressId = request.UserAddressId,
                Email = request.Email,
                LastName = request.LastName,
                FirstName = request.FirstName,
                Telephone = request.Telephone,
                UserName = request.UserName,
                Status = request.Status
            };

            _list.Add(user);
            return user;
        }

        public Model.Users Update(int id, UsersInsertRequest request)
        {
            var existing = _list.Find(a => a.Id == id);
            _list.Remove(existing);
            var user = new Users
            {
                Id = request.Id,
                UserAddressId = request.UserAddressId,
                Email = request.Email,
                LastName = request.LastName,
                FirstName = request.FirstName,
                Telephone = request.Telephone,
                UserName = request.UserName,
                Status = request.Status
            };

            _list.Add(user);
            return user;
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);//raandom number based on our cores and time...
            return Convert.ToBase64String(buf);//change it to 64base because it is the most simply converter bytes to string
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");//sha512
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}
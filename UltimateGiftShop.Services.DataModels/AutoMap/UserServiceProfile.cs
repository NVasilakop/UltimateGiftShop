using AppDataModels.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGiftShop.Services.DataModels.AutoMap
{
    public class UserServiceProfile : Profile
    {
        public UserServiceProfile()
        {
                CreateMap<SubscribeUser, User>(MemberList.Destination)
                    .ForMember(us => us.Password,
                     opt => opt.MapFrom(src => EncryptKey(src.Password,src.UserName)));
                // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
         
        }

        private string EncryptKey(string pass,string username)
        {
            Guid salt = Guid.NewGuid();
            string EncryptionKey = pass+ username + $".{salt}";
            byte[] clearBytes = Encoding.Unicode.GetBytes(pass);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    pass = Convert.ToBase64String(ms.ToArray());
                }
            }
            return pass;
        }


    }
}

using AppDataModels.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGiftShop.Services.DataModels.AutoMap
{
    public class UserServiceProfile : Profile
    {
        private Guid Salt { get; set; } = Guid.NewGuid();
        public UserServiceProfile()
        {
            CreateMap<SubscribeUser, UltimateGiftShop.Repositories.DataModels.User>(MemberList.Destination)
                .ForMember(us => us.UserKey,
                    opt =>
                        opt.MapFrom(src => EncryptKey(src.Password, src.UserName , Salt)))
                .ForMember(us => us.CreationDate, opt 
                    => opt.MapFrom( o => DateTime.Now))
                .ForMember(us => us.LastLoginDate, opt
                    => opt.MapFrom(o => DateTime.Now))
                .ForMember(us => us.LastUpdateDate, opt
                    => opt.MapFrom(o => DateTime.Now))
                .ForMember(us => us.Salt, opt
                    => opt.MapFrom(o => Salt))
                .ForMember(us => us.UserKey,
                    opt =>
                        opt.MapFrom(src => EncryptKey(src.Password, src.UserName, Salt)));

            CreateMap<UltimateGiftShop.Repositories.DataModels.User, LoginUser>()
                .ForMember(us => us.LoggedIn ,
                    opt =>
                        opt.MapFrom(src => src.UserId != 0))
                .ForMember(us => us.UserName, opt
                    => opt.MapFrom(o => o.UserId));

        }
        private string EncryptKey(string pass, string username, Guid salt)
        {
            string EncryptionKey = username ;
            byte[] clearBytes = Encoding.Unicode.GetBytes(pass);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, salt.ToByteArray());
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

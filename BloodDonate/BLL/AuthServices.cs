using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AuthServices
    {
        public static TokenDTO Login(LoginDTO login)
        {
            var user = DataAccessFectory.AuthDataAccess().Authenticate(login.Username, login.Password);

            if (user != null)
            {
                var token = new TokenDTO()
                {
                    Username = login.Username,
                    Token1 = Guid.NewGuid().ToString(),
                    CreationTime = DateTime.Now,
                };

                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Token, TokenDTO>();
                    cfg.CreateMap<TokenDTO, Token>();

                });
                var mapper = new Mapper(config);
                var rtdata = DataAccessFectory.TokenDataAccess().Add(mapper.Map<Token>(token));
                if (rtdata != null)
                {
                    return mapper.Map<TokenDTO>(rtdata);
                }
            }
            return null;
        }
    }
}

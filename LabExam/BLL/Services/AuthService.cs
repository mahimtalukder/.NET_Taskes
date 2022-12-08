using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string uname, string pass)
        {
            var user = DataAccessFectory.AuthDataAccess().Authenticate(uname, pass);
            if (user != null)
            {
                var tk = new Token();
                tk.UserId = user.Id;
                tk.Exp = null;
                tk.LoginToken = Guid.NewGuid().ToString();
                var rttk = DataAccessFectory.TokenDataAccess().Add(tk);
                if (rttk != null)
                {
                    var cfg = new MapperConfiguration(c => {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    var data = mapper.Map<TokenDTO>(rttk);
                    return data;
                }
            }
            return null;
        }
        public static TokenDTO IsTokenValid(string token)
        {
            var tk = DataAccessFectory.TokenDataAccess().Get(token);
            if (tk != null && tk.Exp == null)
            {
                var cfg = new MapperConfiguration(c => {
                    c.CreateMap<Token, TokenDTO>();
                });
                var mapper = new Mapper(cfg);
                var data = mapper.Map<TokenDTO>(tk);
                return data;
            }
            return null;


        }

        public static bool ExpToken(string token)
        {
            var tk = DataAccessFectory.TokenDataAccess().Get(token);
            if(tk != null && tk.Exp == null)
            {
                tk.Exp = DateTime.Now;
                var uptk = DataAccessFectory.TokenDataAccess().Update(tk);
                if(uptk != null)
                {
                    return true;
                }
                return false;

            }
            return false;


        }
    }
}

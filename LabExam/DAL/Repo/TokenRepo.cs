using DAL.EF;
using DAL.EF.Models;
using DAL.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TokenRepo : Repo, IRepo<Token, string, Token>
    {
        
        public Token Add(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(string token)
        {
            var dbToken = Get(token);
            db.Tokens.Remove(dbToken);
            return db.SaveChanges() > 0;
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(string token)
        {
            var dbToken= (from tk in db.Tokens
                    where tk.LoginToken == token
                    select tk).FirstOrDefault();
            return dbToken;
        }

        public Token Update(Token obj)
        {
            var dbToken = Get(obj.LoginToken);
            db.Entry(dbToken).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}

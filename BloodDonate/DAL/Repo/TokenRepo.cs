using DAL.DB;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TokenRepo : IRepo<Token, string, Token>
    {
        BloodBankEntities db;
        internal TokenRepo()
        {
            db = new BloodBankEntities();
        }
        public Token Add(Token obj)
        {
           db.Tokens.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Token> Get()
        {
            throw new NotImplementedException();
        }

        public Token Get(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Token obj)
        {
            throw new NotImplementedException();
        }
    }
}

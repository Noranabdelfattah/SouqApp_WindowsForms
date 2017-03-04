using SouqApp;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouqApp
{
    public class UserRepository
    {
        public SouqEntities1 Context { set; get; }
        public UserRepository()
        {
            Context = new SouqEntities1();
        }

        public User Find( string Givenname, string Givenpass)
        {
           User result =
                this.Context.Users
                            .Find( new object[] { Givenname } ) ;
            return result;
        }

        public IEnumerable <User> Get()
        {
            return this.Context.Users;
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.Context.Products;
        }

        public IEnumerable< User> Get(string Givenname, string Givenpass)
        {
            IEnumerable< User> result =
                 this.Context.Users
                             .Where(P=>P.Username== Givenname && P.Password==Givenpass) ;
            

            return result;
        }




        public void Save()
        {
            this.Context.SaveChanges();
        }

        public User Add(User entity)
        {
            this.Context.Users.Add(entity);
            return entity;
        }

    }
}

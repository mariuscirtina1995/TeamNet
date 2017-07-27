using Countries.Entities;
using Countries.Nh;
using Countries.Nh.Respositories;
using Countries.Web.Models;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Countries.Web.Controllers
{
    public class CountriesController : ApiController
    {
        private static string connectionString =
            @"Data Source=INTERN2017-12;Initial Catalog=Countries;User ID=sa;Password=1234%asd;";

        private static ISessionFactory sessionFactory;

        static CountriesController()
        {
            var config = new NhConfig(connectionString);
            sessionFactory = config.Create();
        }

        public IEnumerable<Country> Get()
        {
            using(var session = sessionFactory.OpenSession())
            {
                var repository = new Repository<Country>(session);

                return repository.GetAll();
            }
        }

        public IEnumerable<Country> GetPage(int pageNumber, int pageSize)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var query = session.Query<Country>()
                                .Skip(pageNumber * pageSize)
                                .Take(pageSize);

                return query.ToList();
            }
        }

        public int GetNumberOfPages(int pageSize)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var total = session.Query<Country>().Count();
                var shouldAddOne = !(total % pageSize == 0);

                if (shouldAddOne)
                    return total / pageSize + 1;

                return total / pageSize;
            }
        }

        public PageData<Country> GetPageSmart(int pageNumber, int pageSize)
        {
            using (var session = sessionFactory.OpenSession())
            {
                PageData<Country> pageCountry = new PageData<Country>();

                var query = session.Query<Country>()
                                .Skip(pageNumber * pageSize)
                                .Take(pageSize);

                pageCountry.Data = query.ToList();

                var total = session.Query<Country>().Count();
                var shouldAddOne = !(total % pageSize == 0);

                if (shouldAddOne)
                    pageCountry.Total = total / pageSize + 1;
                else
                    pageCountry.Total = total / pageSize;

                return pageCountry;
            }
        }
    }
}
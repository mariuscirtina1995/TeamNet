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


        public PageData<Country> GetOrderedPageSmart(int pageNumber, int pageSize, string orderBy)
        {
            using (var session = sessionFactory.OpenSession())
            {
                PageData<Country> pageCountry = new PageData<Country>();

                var query = session.Query<Country>();

                switch (orderBy)
                {
                    case "Code":
                        query = query.OrderBy(a => a.Code);
                        break;

                    case "Name":
                        query = query.OrderBy(a => a.Name);
                        break;

                    case "Lat":
                        query = query.OrderBy(a => a.Latitude);
                        break;

                    case "Long":
                        query = query.OrderBy(a => a.Longitude);
                        break;
                }

                query = query.Skip(pageNumber * pageSize)
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

        public PageData<Country> GetFilteredPageSmart(
            int pageNumber
            , int pageSize
            , string orderBy
            , string filterfield
            , string operation
            , string valoare)
        {
            using (var session = sessionFactory.OpenSession())
            {
                PageData<Country> pageCountry = new PageData<Country>();

                var query = session.Query<Country>();

                switch (filterfield)
                {
                    case "Code":

                        switch (operation)
                        {
                            case "StartsWith":       
                                query = query.Where(c => c.Name.StartsWith(valoare));
                                break;

                            case "Equals":
                                query = query.Where(c => c.Name == valoare);
                                break;
                        }
                        break;

                    case "Name":

                        switch (operation)
                        {
                            case "StartsWith":
                                query = query.Where(c => c.Name.StartsWith(valoare));
                                break;

                            case "Equals":
                                query = query.Where(c => c.Name == valoare);
                                break;
                        }
                        break;

                    case "Longitude":

                        switch (operation)
                        {
                            
                            case "greaterthan":
                                query = query.Where(c => c.Longitude > Convert.ToDecimal(valoare));
                                break;

                            case "lesserthan":
                                query = query.Where(c => c.Longitude < Convert.ToDecimal(valoare));
                                break;

                            case "Equals":
                                query = query.Where(c => c.Latitude == Convert.ToDecimal(valoare));
                                break;
                           
                        }
                        break;

                    case "Latitude":

                        switch (operation)
                        {

                            case "greaterthan":
                                query = query.Where(c => c.Longitude > Convert.ToDecimal(valoare));
                                break;

                            case "lesserthan":
                                query = query.Where(c => c.Longitude < Convert.ToDecimal(valoare));
                                break;

                            case "Equals":
                                query = query.Where(c => c.Latitude == Convert.ToDecimal(valoare));
                                break;

                        }
                        break;
                }

                switch (orderBy)
                {
                    case "Code":
                        query = query.OrderBy(a => a.Code);
                        break;

                    case "Name":
                        query = query.OrderBy(a => a.Name);
                        break;

                    case "Lat":
                        query = query.OrderBy(a => a.Latitude);
                        break;

                    case "Long":
                        query = query.OrderBy(a => a.Longitude);
                        break;
                }

                var total = query.Count();

                query = query.Skip( (pageNumber-1) * pageSize)
                               .Take(pageSize);

                pageCountry.Data = query.ToList();

                var shouldAddOne = !(total % pageSize == 0);

                if (shouldAddOne)
                    pageCountry.Total = total / pageSize + 1;
                else
                    pageCountry.Total = total / pageSize;

                return pageCountry;
            }
        }

        [HttpPost]
        public Country Save(Country country)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var repository = new Repository<Country>(session);

                repository.Insert(country);

                return country;
            }

        }

        [HttpPost]
        public Country Edit(Country country)
        {
            using (var session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(country);

                return country;
            }

        }

        public Country GetCountry(string name)
        {
            using(var session = sessionFactory.OpenSession())
            { 
                return session.Query<Country>().SingleOrDefault(c => c.Name == name);
            }

        }
    }
}
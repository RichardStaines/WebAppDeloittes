using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDeloittes.city.model;

namespace WebAppDeloittes.city.dao
{
    public interface ICityRepository
    {
        List<City> SearchCitiesByName(string name);
        string AddCity(City city);
        string UpdateCity(City city);
        string DeleteCity(int id);
    }
}

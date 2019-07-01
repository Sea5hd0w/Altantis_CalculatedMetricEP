using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altantis_CalculatedMetricEP.Mapper
{
    public static class MapperCalculType
    {
        public static Business.CalculType DAOToBusiness(DAO.CalculType dao)
        {
            return new Business.CalculType(dao.Id, dao.Name, dao.Description, dao.Unit, dao.Period, dao.PeriodSecondCount, dao.SensorType);
        }

        public static IEnumerable<Business.CalculType> EnumDAOToEnumBusiness(IEnumerable<DAO.CalculType> dao)
        {
            List<Business.CalculType> business = new List<Business.CalculType>();
            foreach (DAO.CalculType c in dao) business.Add(DAOToBusiness(c));
            return business;
        }
    }
}

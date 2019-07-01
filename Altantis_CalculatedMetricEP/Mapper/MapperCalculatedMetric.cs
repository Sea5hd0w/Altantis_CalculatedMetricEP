using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altantis_CalculatedMetricEP.Mapper
{
    public class MapperCalculatedMetric
    {
        public static Business.CalculatedMetric DAOToBusiness(DAO.CalculatedMetric dao)
        {
            return new Business.CalculatedMetric(dao.Id, dao.DeviceId, dao.CreatedAt, dao.Value);
        }

        public static IEnumerable<Business.CalculatedMetric> EnumDAOToEnumBusiness(IEnumerable<DAO.CalculatedMetric> dao)
        {
            List<Business.CalculatedMetric> business = new List<Business.CalculatedMetric>();
            foreach (DAO.CalculatedMetric c in dao) business.Add(DAOToBusiness(c));
            return business;
        }
    }
}

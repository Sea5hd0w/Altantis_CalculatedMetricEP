using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Altantis_CalculatedMetricEP.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Altantis_CalculatedMetricEP.Controllers
{
    [Produces("application/json")]
    [Route("api/CalculatedMetric")]
    public class CalculatedMetricController : Controller
    {
        // GET api/CalculatedMetric/GetMetrics
        [HttpGet("GetMetrics")]
        public IEnumerable<Business.CalculatedMetric> GetMetrics(int id, string start, string end, int idCalculType)
        {
            DateTime startTime = DateTime.ParseExact(start, "yyyy-MM-dd HH:mm", null);
            DateTime endTime = DateTime.ParseExact(end, "yyyy-MM-dd HH:mm", null);

            ServiceCalculatedMetrics svc = new ServiceCalculatedMetrics(id, startTime, endTime, idCalculType);

            return svc.GetCalculedMetrics();
        }

        // GET api/CalculatedMetric
        [HttpGet("GetTypesMetric")]
        public IEnumerable<Business.CalculType> GetTypesMetric()
        {
            return ServiceTypeMetrics.Instance.GetCalculTypes();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altantis_CalculatedMetricEP.Business
{
    public class CalculatedMetric
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Value { get; set; }

        public CalculatedMetric(int id, string deviceId, DateTime createdAt, decimal value)
        {
            Id = id;
            DeviceId = deviceId;
            CreatedAt = createdAt;
            Value = value;
        }
    }
}

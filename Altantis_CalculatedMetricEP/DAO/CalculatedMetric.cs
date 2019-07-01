using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altantis_CalculatedMetricEP.DAO
{
    public class CalculatedMetric
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Value { get; set; }
        public int CalculTypeId { get; set; }
        public string DeviceId { get; set; }

        public CalculatedMetric(int id, DateTime createdAt, decimal value, int calculTypeId, string deviceId)
        {
            Id = id;
            DeviceId = deviceId;
            CreatedAt = createdAt;
            Value = value;
            CalculTypeId = calculTypeId;
        }
    }
}

using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Altantis_CalculatedMetricEP.Service
{
    public class ServiceCalculatedMetrics
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int IdCalculType { get; set; }

        private string ConnectionString { get; set; }

        public ServiceCalculatedMetrics(int id, DateTime startTime, DateTime endTime, int idCalculType)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            IdCalculType = idCalculType;

            LoadConfig();
        }

        private void LoadConfig()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("config.json")
                .Build();
            ConnectionString = configuration.GetConnectionString("DataBase");
        }

        public IEnumerable<Business.CalculatedMetric> GetCalculedMetrics()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                IEnumerable<DAO.CalculatedMetric> ECalculatedMetrics = connection.Query<DAO.CalculatedMetric>(
                    "SELECT * " +
                    "FROM [Atlantis_CalculatedMetrics].[dbo].[CalculatedMetric] " +
                    "WHERE DeviceId = '" + Id + "'" +
                    " AND CalculTypeId = " + IdCalculType +
                    " AND CreatedAt BETWEEN convert(datetime,'" + StartTime.ToString("dd/MM/yyyy HH:mm:ss") +
                    "',105) AND convert(datetime,'" + EndTime.ToString("dd/MM/yyyy HH:mm:ss") + "',105)");
                    connection.Close();
                return Mapper.MapperCalculatedMetric.EnumDAOToEnumBusiness(ECalculatedMetrics);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                Console.WriteLine("Error : Fail to connect to the DataBase");
                return null;
            }

        }
    }
}

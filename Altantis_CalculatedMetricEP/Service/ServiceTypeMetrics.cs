using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Altantis_CalculatedMetricEP.Service
{
    public class ServiceTypeMetrics
    {
        private string ConnectionString { get; set; }

        private static readonly Lazy<ServiceTypeMetrics> _lazy = new Lazy<ServiceTypeMetrics>(() => new ServiceTypeMetrics());
        public static ServiceTypeMetrics Instance { get { return _lazy.Value; } }

        private ServiceTypeMetrics()
        {
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


        public IEnumerable<Business.CalculType> GetCalculTypes()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    IEnumerable<DAO.CalculType> ECalculTypes = connection.Query<DAO.CalculType>("SELECT *  FROM [Atlantis_CalculatedMetrics].[dbo].[CalculType]");
                    connection.Close();
                    return Mapper.MapperCalculType.EnumDAOToEnumBusiness(ECalculTypes);
                }
            }
            catch
            {
                Console.WriteLine("Error : Fail to connect to the DataBase");
                return null;
            }
        }
    }
}

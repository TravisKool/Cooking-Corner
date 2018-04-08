using RecipeServiceApi.Common.Contract.Factory;
using RecipeServiceApi.Common.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace RecipeServiceApi.Concrete.Repository
{
    public class StoreSettingsRepository : IStoreSettingsRepository
    {
        private readonly IStoreSettingsFactory _storeSettingsFactory;

        public StoreSettingsRepository(IStoreSettingsFactory storeSettingsFactory)
        {
            _storeSettingsFactory = storeSettingsFactory;
        }

        public IStoreSettings FetchStoreSettings()
        {
            var sql = @"
                SELECT		TaxRatePercent,
			                RoundingInCents,
			                WellnessDiscountPercent
                FROM		StoreSettings
            ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(sql, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    var storeSettings = _storeSettingsFactory.Create();
                    while (reader.Read())
                    {
                        storeSettings.TaxRatePercent = decimal.Parse(reader["TaxRatePercent"].ToString());
                        storeSettings.RoundingInCents = int.Parse(reader["RoundingInCents"].ToString());
                        storeSettings.WellnessDiscountPercent = decimal.Parse(reader["WellnessDiscountPercent"].ToString());
                    }
                    return storeSettings;
                }
                catch (Exception ex)
                {
                    // Log error
                    return null;
                }
            }
        }
    }
}

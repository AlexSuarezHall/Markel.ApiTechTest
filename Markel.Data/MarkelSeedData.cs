namespace Markel.Data
{
    public class MarkelSeedData
    {
        public static void MarkelSeed(MarkelContext context)
        {
            context.Database.EnsureCreated();

            context.Companies.Add(new Models.Company()
            {
                Name = "Test Company",
                Address1 = "Test Address 1",
                Address2 = "Test Address 2",
                Address3 = "Test Address 3",
                Postcode = "LS1 1TU",
                Country = "England",
                InsuranceDate = DateTime.Now,
                Active = true
            });

            context.Companies.Add(new Models.Company()
            {
                Name = "Test Company 2",
                Address1 = "Test Address_1",
                Address2 = "Test Address_2",
                Address3 = "Test Address_3",
                Postcode = "LS26 5FN",
                Country = "Scotland",
                InsuranceDate = DateTime.Now,
                Active = false
            });

            context.Companies.Add(new Models.Company()
            {
                Name = "Test Company 3",
                Address1 = "Address_1",
                Address2 = "Address_2",
                Address3 = "Address_3",
                Postcode = "LS11 6JY",
                Country = "Wales",
                InsuranceDate = DateTime.Now,
                Active = false
            });

            context.ClaimTypes.Add(new Models.ClaimType()
            {
                Id = 1,
                Name = "Holiday"
            });

            context.ClaimTypes.Add(new Models.ClaimType()
            {
                Id = 2,
                Name = "Home"
            });

            context.ClaimTypes.Add(new Models.ClaimType()
            {
                Id = 3,
                Name = "Pet"
            });

            context.Claims.Add(new Models.Claim()
            {
                UCR = "UCR_1",
                AssuredName = "TEST_NAME",
                ClaimDate = DateTime.Now.AddDays(-37),
                CompanyId = 1,
                ClaimTypeId = 1,
                Closed = false,
                IncurredLoss = 0.1m,
                LossDate = DateTime.Now,
            });

            context.Claims.Add(new Models.Claim()
            {
                UCR = "UCR_2",
                AssuredName = "TEST_NAME_2",
                ClaimDate = DateTime.Now.AddDays(-7),
                CompanyId = 1,
                ClaimTypeId = 2,
                Closed = false,
                IncurredLoss = 0.4m,
                LossDate = DateTime.Now,
            });

            context.Claims.Add(new Models.Claim()
            {
                UCR = "UCR_3",
                AssuredName = "TEST_NAME_3",
                ClaimDate = DateTime.Now.AddDays(-4),
                CompanyId = 2,
                ClaimTypeId = 3,
                Closed = false,
                IncurredLoss = 0.1m,
                LossDate = DateTime.Now,
            });

            context.SaveChanges();
        }
    }
}

using NUnit.Framework;
using RestSharp;

namespace TestPasswordValidate
{
    public class UnitTestPasswordValidate
    {

        [Test]
        public void ValidateUserPasswordWithSuccess()
        {
            var client = new RestClient("http://localhost:37019");
            var request = new RestRequest("api/user-access/password-validate", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                userName = "teste@email.com",
                password = "v@DS098765432"
            });
           
            var response = client.ExecutePostAsync(request).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void ValidateUserPasswordWithFailValidations()
        {
            var client = new RestClient("http://localhost:37019");
            var request = new RestRequest("api/user-access/password-validate", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                userName = "teste@email.com",
                password = "  "
            });

            var response = client.ExecutePostAsync(request).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                Assert.Pass();
            else
                Assert.Fail();
        }
    }
}
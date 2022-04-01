using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Mail;

namespace DemoFunctions
{
    public static class EmailLicenseFile
    {
        [FunctionName("EmailLicenseFile")]
        public static void Run(
            [BlobTrigger("licenses/{name}", Connection = "AzureWebJobsStorage")]string  licenseFileContents, 
            [SendGrid(ApiKey = "SenGridApiKey")] out SendGridMessage message,
            string name, 
            ILogger log)
        {
            message = new SendGridMessage();

            log.LogInformation($"");
        }
    }
}

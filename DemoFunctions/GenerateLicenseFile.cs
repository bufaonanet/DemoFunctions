using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace DemoFunctions
{
    public static class GenerateLicenseFile
    {
        [FunctionName("GenerateLicenseFile")]
        public static void Run(
            [QueueTrigger("orders")] Order order,
            [Blob("licenses/{rand-guid}.lic")] TextWriter outputBlob,
            ILogger log)
        {
            outputBlob.WriteLine($"OrderId: {order.OrderId}");
            outputBlob.WriteLine($"Email: {order.Email}");
            outputBlob.WriteLine($"Product: {order.ProductId}");
            outputBlob.WriteLine($"Price: {order.Price}");
            outputBlob.WriteLine($"PurchaseDate: {order.OrderId}");

            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(order.Email + "secret"));

            outputBlob.WriteLine($"Secret: {BitConverter.ToString(hash).Replace("-", "")}");

            log.LogInformation($"C# Queue trigger function processed: {order}");
        }
    }
}

using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure;
namespace AzureFunctionLear1
{
    public static class Function2
    {
       public static CloudQueueClient cloudQueueClient;
       
        [FunctionName("Function2")]
         public static void timer1([TimerTrigger("*/3 * * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse("AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;");

            cloudQueueClient = cloudStorageAccount.CreateCloudQueueClient();
            CloudQueue cloudQueue = cloudQueueClient.GetQueueReference("dev");
            cloudQueue.CreateIfNotExistsAsync();

            CloudQueueMessage cloudQueueMessage = new CloudQueueMessage("Dcs");
            cloudQueue.AddMessageAsync(cloudQueueMessage);

            log.Info("HI I am runnig every 3 seconds hhahah");
            log.Info($"C# Timer trigg er function executed at: {DateTime.Now}");
        }
    }
}

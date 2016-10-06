using Contoso.Events.Data;
using Contoso.Events.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Linq;

namespace Contoso.Events.ViewModels
{
    public class SignInSheetViewModel
    {
        private const string PROCESSING_URI = "uri://processing";

        public SignInSheetViewModel()
        { }

        public SignInSheetViewModel(string eventKey)
        {
            this.SignInSheetState = default(SignInSheetState);

            using (EventsContext context = new EventsContext())
            {
                var eventItem = context.Events.SingleOrDefault(e => e.EventKey == eventKey);

                this.Event = eventItem;

                if (this.Event.SignInDocumentUrl == PROCESSING_URI)
                {
                    this.SignInSheetState = SignInSheetState.SignInDocumentProcessing;
                }
                else if (!String.IsNullOrEmpty(this.Event.SignInDocumentUrl))
                {
                    this.SignInSheetState = SignInSheetState.SignInDocumentAlreadyExists;
                }
                else
                {
                    QueueMessage message = new QueueMessage
                    {
                        EventId = eventItem.Id,
                        MessageType = QueueMessageType.SignIn
                    };
                    string messageString = JsonConvert.SerializeObject(message);

                    GenerateSignInSheetStorageQueues(context, eventItem, messageString);
                }
            }
        }

        public Event Event { get; set; }

        public SignInSheetState SignInSheetState { get; set; }

        private string storageConnectionString = ConfigurationManager.ConnectionStrings["Microsoft.WindowsAzure.Storage.ConnectionString"].ConnectionString;
        private string signInQueueName = ConfigurationManager.AppSettings["SignInQueueName"];
        

        private void GenerateSignInSheetStorageQueues(EventsContext context, Event eventItem, string message)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference(signInQueueName);
            queue.CreateIfNotExists();

            CloudQueueMessage queueMessage = new CloudQueueMessage(message);
            queue.AddMessage(queueMessage);

            eventItem.SignInDocumentUrl = PROCESSING_URI;

            context.SaveChanges();

            this.Event = eventItem;

            this.SignInSheetState = SignInSheetState.SignInDocumentProcessing;
        }
    }

    public enum SignInSheetState
    {
        Unknown = 0,
        SignInDocumentProcessing,
        SignInDocumentAlreadyExists
    }
}
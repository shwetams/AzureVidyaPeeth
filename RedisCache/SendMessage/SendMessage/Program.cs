using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System.IO;


namespace SendMessage
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public string qty { get; set; }
        
    }
    

 public class ShoppingCart
    {
        public string userid { get; set; }
        public List<Product> product { get; set; }
        
    }


    
    class Program
    {
        static void Main(string[] args)
        {
            var shoppingcart = JsonConvert.DeserializeObject<List<ShoppingCart>>(File.ReadAllText("..\\SampleData\\sample4.json"));
            var connString = "Endpoint=sb://<service bus name>.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=<service bus key>";
            var queuename = "shoppingcart";
            var client = QueueClient.CreateFromConnectionString(connString,queuename);
           // var product = "{\"id\":10,\"name\":\"Microsoft Mouse\",\"qty\":3}";
            //var msg = "{\"userid\":\"u101\",\"product\":{\"id\":10,\"name\":\"Microsoft Mouse\",\"qty\":3}}";
            foreach (var items in shoppingcart)
            {

                
                    Console.WriteLine("Sending item details : " + items.userid + "...");
                    BrokeredMessage brokerMsg = new BrokeredMessage(JsonConvert.SerializeObject(items));
                    client.Send(brokerMsg);
                    Console.WriteLine("Message sent successfully.");
                

            }
            Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace GetRedisCacheDetails
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            string userId = txtUserId.Text.Trim();
            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("<cache name>.redis.cache.windows.net:6380,password=<cache key>,ssl=True,abortConnect=False");
            IDatabase cache = connection.GetDatabase();
            
            var products = cache.SetMembers(userId).ToStringArray();
            string output = " ";
            bool isFirst = true;
            bool isNotEmpty = false;
            foreach (var product in products)
            {
                output = output + "\n" + product;
                /*
                isNotEmpty = true;
                if (isFirst)
                {
                    dynamic p = JsonConvert.SerializeObject(product);
                    output = "<table><tr><th>ID</th><th>Name</th><th>Model</th><th>Quantity</th></tr>";
                    output = output + "<tr><td>"+ p.id + "</td><td>" + p.name + "</td><td>" + p.model  +"</td><td>" + p.qty +"</td></tr>";
                    isFirst = false;
                    
                }
                else
                {
                    dynamic p = JsonConvert.SerializeObject(product);
                    output = output + "<tr><td>" + p.id + "</td><td>" + p.name + "</td><td>" + p.model + "</td><td>" + p.qty + "</td></tr>";

                }
                */

            }
            /*
            if(isNotEmpty)
            { output = output + "</table>"; }
            */
            if (output.Trim().Length > 0)
            {
                lblResults.Text = output;
            }
            else
            {
                lblResults.Text = "Shopping cart empty!";
            }
           

        }
    }
}
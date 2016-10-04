module.exports = function(context, mySbMsg) {
    var redis = require("redis");
    var client = redis.createClient(6380,'<cache name>.redis.cache.windows.net',{auth_pass: '<cache key>', tls: {servername: '<cache name>.redis.cache.windows.net'}});   
    var products = mySbMsg.product;
    products.forEach(function(product){
        context.log(product);
        var p = "{'id':" + product.id + ", 'name':'" + product.name + "', 'model':'" + product.model + "','qty':" + product.qty +"}";
        //context.log(p);
        client.sadd(mySbMsg.userid,p);
    });
    
    

        
    context.log('Node.js ServiceBus queue trigger function processed message', mySbMsg.userid);
    context.done();
};
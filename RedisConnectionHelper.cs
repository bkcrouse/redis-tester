using StackExchange.Redis;

namespace redistester;

public class RedisConnectorHelper  
{                  
    static RedisConnectorHelper()  
    {  
        RedisConnectorHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>  
        {  
            return ConnectionMultiplexer.Connect("redis");  
        });  
    }  
      
    private static Lazy<ConnectionMultiplexer> lazyConnection;          
  
    public static ConnectionMultiplexer Connection  
    {  
        get  
        {  
            return lazyConnection.Value;  
        }  
    }  
}  
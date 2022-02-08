using CommandLine;
using redistester;

class Program  
{  
    private const string Item = "ITEM";
    public class Options
    {
        [Option('i', "items", Required = false, HelpText = "Number of items to set")]
        public int Items { get; set; } = 10;
    }
    
    static void Main(string[] args)  
    {  
        var program = new Program();

        Parser.Default.ParseArguments<Options>(args)
            .WithParsed<Options>(o =>
            {
                Console.WriteLine("Saving random data in cache");
                program.WriteToRedis(o.Items);

                Console.WriteLine("Reading data from cache");
                program.ReadFromRedis(o.Items);
            });

    }  
  
    private void ReadFromRedis(int count)  
    {  
        var cache = RedisConnectorHelper.Connection.GetDatabase();  
        for (int i = 0; i < count; i++)  
        {  
            var value = cache.StringGet($"{Item}:{i}");  
            Console.WriteLine($"{Item}={value}");  
        }  
    }  
  
    private void WriteToRedis(int count)  
    {  
        var rnd = new Random();  
        var cache = RedisConnectorHelper.Connection.GetDatabase();  
  
        for (int i = 0; i < count; i++)  
        {  
            var value = rnd.Next(0, Int32.MaxValue);  
            cache.StringSet($"{Item}:{i}", value);  
        }  
    }  
}
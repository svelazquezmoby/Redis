using System;
using StackExchange.Redis;



namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            var redisDB = RedisDB.Connection.GetDatabase();
            redisDB.StringSet("1", "cerveza");

            var valor = redisDB.StringGet("1");
            Console.WriteLine(valor);
        }
    }

    public class RedisDB
    {
        private static Lazy<ConnectionMultiplexer> _lazyconnection;
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return _lazyconnection.Value;
            }

        }
        static RedisDB()
        {
            _lazyconnection = new Lazy<ConnectionMultiplexer>(() =>
            ConnectionMultiplexer.Connect("localhost")
            ); 
        }
    }
}

using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using ZodiacSignsService;

namespace ZodiacClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ZodiacSign.ZodiacSignClient(channel);
            string birthday;
            while (true)
            {
                Console.WriteLine("Data de nastere: ");
                birthday = Console.ReadLine();

                try
                {
                    DateTime.ParseExact(birthday, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                    var reply = client.GetZodiacSign(
                        new ZodiacSignRequest { Birthday = birthday });
                    Console.WriteLine($"REPLY: ZODIE: {reply.ZodiacSign}");
                } catch
                {
                    Console.WriteLine("[CLIENT VALIDATION] Invalid date format.");
                }
            }
            
        }
    }
}

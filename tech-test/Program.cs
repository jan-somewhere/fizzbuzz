using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace tech_test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

        public static string[] getFizzBuzz(int a, int b) {

            if (b < a) {
                throw new CustomException("Error: End number smaller than start number"); ;
            }

            string[] values = new string[b - a + 1];

            for (int i = a; i <= b; i++) {
                if (i % 3 == 0 && i % 5 == 0) {
                    values[i - a] = "fizzbuzz";
                } else if (i % 3 == 0) {
                    values[i - a] = "fizz";
                } else if (i % 5 == 0) {
                    values[i - a] = "buzz";
                } else {
                    values[i - a] = i.ToString();
                }
            }

            return values;
        }
    }
}

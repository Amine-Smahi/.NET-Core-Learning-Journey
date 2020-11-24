using System;
using Application;
using Application.Helpers;
using Common;
using Domain.Entities;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            ResolverDependencies.Resolve();
            var user = new Patient("amine smahi", "amine@gmai.com");
            Console.ReadKey();
        }
    }
}

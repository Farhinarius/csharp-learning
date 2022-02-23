using System;

namespace EnvironmentInteraction
{
    public static class Program
    {
        private static int Main(string[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine("Arg: {0}", arg);
            }
            
            ShowEnvironmentDetails();
            return 0;
        }

        private static void ShowEnvironmentDetails()
        {
            foreach (var drive in Environment.GetLogicalDrives())
            {
                Console.WriteLine("Drive: {0}", drive);    
            }
            
            Console.WriteLine("OS: {0}", Environment.OSVersion);
            
            Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount);
            
            Console.WriteLine(".NET version: {0}", Environment.Version);
        }
    }
}

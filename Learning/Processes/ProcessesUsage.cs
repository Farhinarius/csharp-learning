using System;
using System.Diagnostics;
using System.Linq;

namespace Learning.Processes
{
    public static class ProcessesUsage
    {
        public static void ListAllRunningProcesses()
        {

            // string "." means local pc
            var runningProcesses = Process.GetProcesses(".").OrderBy(p => p.Id);
            foreach (var runningProcess in runningProcesses)
            {
                var info = $"PID: {runningProcess.Id}\tName: {runningProcess.ProcessName}";
                Console.WriteLine(info);
            }
            Console.WriteLine();
        }

        public static void GetSpecificProcess()
        {
            try
            {
                var process = Process.GetProcessById(11580);
                Console.WriteLine($"{process.ProcessName}");


                Console.WriteLine($"Main module: {process.MainModule}");

                Console.WriteLine($"\nList of {process.ProcessName} modules:");
                foreach (ProcessModule module in process.Modules)
                {
                    Console.WriteLine(module.ModuleName);
                }

                Console.WriteLine($"\nList of {process.ProcessName} threads:");
                foreach (ProcessThread processThread in process.Threads)
                {
                    Console.WriteLine($"Thread id: {processThread.Id}" +
                        $"\tStart time: {processThread.StartTime.ToShortTimeString()}" +
                        $"\tPriority: {processThread.PriorityLevel}");
                }

                Console.WriteLine($"Process machine name: {process.MachineName}");
                Console.WriteLine($"Process start time {process.StartTime}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ShowCurrentProcess() =>
            Console.WriteLine($"Current process: {Process.GetCurrentProcess()}");

        public static void ProcessIsRunning(string processName = "Workspace") =>
            Console.WriteLine("Process {0} is running: {1}",
                processName,
                Process.GetProcessesByName(processName).Length > 0);

        public static void StartNewProcess(
            string processName = "C:\\WINDOWS\\system32\\notepad.exe") =>
            Process.Start(processName);

        public static void StartAndKillProcess(
            string processName = "C:\\WINDOWS\\system32\\notepad.exe")
        {
            try
            {
                var process = Process.Start(processName);

                Console.WriteLine($"Press enter to kill {process.ProcessName}:");
                Console.ReadLine();
                process.Kill(true);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public static void UseApplicationVerbs()
        {
            int i = 0;
            var processStartInfo
                = new ProcessStartInfo("..\\..\\..\\Learning\\Processes\\Resources\\Test.docx");
            foreach (var verb in processStartInfo.Verbs)
            {
                Console.WriteLine($" {i++}: {verb}");
            }

            processStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            processStartInfo.Verb = "Edit";
            processStartInfo.UseShellExecute = true;
            Process.Start(processStartInfo);
        }

    }
}

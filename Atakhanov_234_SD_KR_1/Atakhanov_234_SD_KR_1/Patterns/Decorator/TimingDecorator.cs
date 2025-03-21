using System.Diagnostics;
using Patterns.Command;

namespace Patterns.Decorator
{
    /// <summary>
    /// Декоратор, который меряет время выполнения команды.
    /// </summary>
    public class TimingDecorator : ICommand
    {
        private readonly ICommand _command;

        public TimingDecorator(ICommand command)
        {
            _command = command;
        }

        public void Execute()
        {
            var stopwatch = Stopwatch.StartNew();
            _command.Execute();
            stopwatch.Stop();
            Console.WriteLine($"[TimingDecorator] Execution time: {stopwatch.Elapsed.TotalMilliseconds} ms");
        }
    }
}
using System.Diagnostics;
using System.Text;

namespace Assignment6.Services
{
	/*
	* This class times how long passes between events.
	*/
	public class StopwatchService
    {
		private Stopwatch stopwatch = new Stopwatch();

		private StringBuilder builder = new StringBuilder();

        private IConsoleLogger loggingService;

        public StopwatchService(IConsoleLogger loggingService)
        {
            this.loggingService = loggingService;
        }

        public void Start(string name)
		{
			this.loggingService.Log("Starting a new stopwatch");
			Lap(name);
			stopwatch.Start();
		}

		public void Lap(string name)
		{
			builder.Append("{").Append(name).Append(" ").Append(stopwatch.ElapsedTicks).Append("}");
		}

		public override string ToString()
		{
			return builder.ToString();
		}
	}
}

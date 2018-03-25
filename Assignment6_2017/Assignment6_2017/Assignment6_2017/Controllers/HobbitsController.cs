using Assignment6.Filters;
using Assignment6.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Assignment6.Controllers
{
	/*
	* The main endpoint controller. Stores and allows updates to a list of strings (hobbit names).
	*/
	[Route("api/[controller]")]
	[TypeFilter(typeof(StopwatchFilter))]
	[TypeFilter(typeof(RequestIdFilter))]
	public class HobbitsController : Controller
	{
        /*
		* TODO: Get the MemoryDatabase from DependencyInjection instead.
		*/
        private IDatabase database;
        private IConsoleLogger loggingService;

        public HobbitsController(IDatabase database, StopwatchService watchService, IConsoleLogger loggingService)
        {
            this.database = database;
            this.watchService = watchService;
            this.loggingService = loggingService;
        }

        /*
		* TODO: Get the StopwatchService from DependencyInjection instead.
		*/
        private StopwatchService watchService;

		[HttpGet]
		public IEnumerable<string> Get()
		{
			/*
			* TODO: Shouldn't be using ConsoleLogger directly. What if we wanted to use a different type of logger?
			*/
			loggingService.Log("GET hobbits returning " + database.Size());
			watchService.Lap("Controller");

			return database.GetData("Hobbit");
		}

		[HttpPost]
		public string Post([FromQuery] string hobbit)
		{
			/*
			* TODO: Shouldn't be using ConsoleLogger directly. What if we wanted to use a different type of logger?
			*/
			this.loggingService.Log("POST hobbits adding " + hobbit);
			watchService.Lap("Controller");

			database.AddString("Hobbit", hobbit);

			return hobbit;
		}
	}
}

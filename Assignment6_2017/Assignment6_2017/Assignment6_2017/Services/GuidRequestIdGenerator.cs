using System;

namespace Assignment6.Services
{
	/*
	* A class that generates unique request ids.
	*/
	public class GuidRequestIdGenerator : IRequestGenerator
    {
		public string Generate { get { return Guid.NewGuid().ToString(); } }

        string IRequestGenerator.Generate()
        {
            return this.Generate;
        }
    }
}

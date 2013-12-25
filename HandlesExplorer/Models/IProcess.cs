using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HandlesExplorer.Models
{
	public interface IProcess
	{
		string ProcessName { get; }

		int ProcessId { get; }
	}
}

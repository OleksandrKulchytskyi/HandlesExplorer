using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HandlesExplorer.Models
{
	public class ProcessModel : GalaSoft.MvvmLight.ObservableObject, IProcess
	{
		public ProcessModel(Process proc)
		{
			if (proc == null)
				throw new ArgumentNullException("Parameter proc cannot be a null.");

			ProcessId = proc.Id;
			ProcessName = proc.ProcessName;
		}

		private string pName;
		public string ProcessName
		{
			get { return pName; }
			private set { pName = value; this.RaisePropertyChanged(() => ProcessName); }
		}

		int pId;
		public int ProcessId
		{
			get { return pId; }
			private set { pId = value; this.RaisePropertyChanged(() => ProcessId); }
		}
	}
}

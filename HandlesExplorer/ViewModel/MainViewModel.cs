using GalaSoft.MvvmLight;
using HandlesExplorer.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace HandlesExplorer.ViewModel
{
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// <para>
	/// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
	/// </para>
	/// <para>
	/// You can also use Blend to data bind with the tool's support.
	/// </para>
	/// <para>
	/// See http://www.galasoft.ch/mvvm
	/// </para>
	/// </summary>
	public class MainViewModel : ViewModelBase
	{
		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel()
		{
			////if (IsInDesignMode)
			////{
			////    // Code runs in Blend --> create design time data.
			////}
			////else
			////{
			////    // Code runs "for real"
			////}

			Processes = new ObservableCollection<IProcess>(System.Diagnostics.Process.GetProcesses().Select(x => new ProcessModel(x)));
			Files = new ObservableCollection<IFileData>();
		}

		private IProcess selected;

		public IProcess SelectedProcess
		{
			get { return selected; }
			set
			{
				selected = value;
				RaisePropertyChanged(() => SelectedProcess);
				InvokeEnumeration(SelectedProcess);
			}
		}

		private void InvokeEnumeration(IProcess SelectedProcess)
		{
			Files.Clear();

			var enumerator = Services.DetectOpenFiles.GetOpenFilesEnumerator(SelectedProcess.ProcessId);
			while (enumerator.MoveNext())
			{
				Files.Add(new FileData(enumerator.Current));
			}
		}


		private ObservableCollection<IProcess> processes;
		public ObservableCollection<IProcess> Processes
		{
			get { return processes; }
			set
			{
				processes = value;
				this.RaisePropertyChanged(() => Processes);
			}
		}

		private ObservableCollection<IFileData> files;
		public ObservableCollection<IFileData> Files
		{
			get { return files; }
			set
			{
				files = value;
				this.RaisePropertyChanged(() => Files);
			}
		}
	}
}
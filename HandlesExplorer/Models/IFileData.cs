using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HandlesExplorer.Models
{
	public interface IFileData
	{
		string Name { get; }
		string FullPath { get; }
		bool IsFileSelected { get; set; }
	}

	public class FileData : GalaSoft.MvvmLight.ObservableObject, IFileData
	{

		public FileData(FileSystemInfo file)
		{
			if (file == null)
				throw new ArgumentNullException("Parameter file cannot be a null.");

			Name = file.Name;
			FullPath = file.FullName;
		}

		private string name;
		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				RaisePropertyChanged(() => Name);
			}
		}

		private string fullPath;
		public string FullPath
		{
			get { return fullPath; }
			set
			{
				fullPath = value;
				RaisePropertyChanged(() => FullPath);
			}
		}

		private bool selected;
		public bool IsFileSelected
		{
			get { return selected; }
			set
			{
				if (selected == value) return;
				selected = value;
				RaisePropertyChanged(() => IsFileSelected);
			}
		}

	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HandlesExplorer
{
	public class RelayCommand : ICommand
	{
		#region Fields
		readonly Action<Object> _execute;
		readonly Predicate<Object> _canExecute;
		#endregion // Fields

		#region Constructors
		public RelayCommand(Action<Object> execute) : this(execute, null) { }
		public RelayCommand(Action<Object> execute, Predicate<Object> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute");
			_execute = execute;
			_canExecute = canExecute;
		}
		#endregion // Constructors

		#region ICommand Members
		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute(parameter);
		}
		public event EventHandler CanExecuteChanged
		{
			add
			{
				CommandManager.RequerySuggested += value;
			}
			remove
			{
				CommandManager.RequerySuggested -= value;
			}
		}
		public void Execute(object parameter)
		{
			_execute(parameter);
		}
		#endregion // ICommand Members
	}
}

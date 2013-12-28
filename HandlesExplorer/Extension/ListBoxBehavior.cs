using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HandlesExplorer.Extension
{
	public class ListBoxBehavior
	{
		private static DependencyProperty _property;
		private static readonly RoutedEvent _focusChangedEvent = FocusManager.GotFocusEvent;

		public static readonly DependencyProperty FocusChangedCommandProperty =
			DependencyProperty.RegisterAttached("FocusChangedCommand",
			typeof(ICommand), typeof(ListBoxBehavior),
			new PropertyMetadata(new PropertyChangedCallback(FocusChangedCallBack)));

		public static void SetFocusChangedCommand(UIElement obj, ICommand value)
		{
			obj.SetValue(FocusChangedCommandProperty, value);
		}

		public static ICommand GetFocusChangedCommand(UIElement obj)
		{
			return (ICommand)obj.GetValue(FocusChangedCommandProperty);
		}

		static void FocusChangedCallBack(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			UIElement element = obj as UIElement;
			_property = args.Property;

			if (element != null)
			{
				if (args.OldValue != null)
				{
					element.AddHandler(_focusChangedEvent, new RoutedEventHandler(EventHandler));
				}

				if (args.NewValue != null)
				{
					element.AddHandler(_focusChangedEvent, new RoutedEventHandler(EventHandler));
				}
			}
		}

		public static void EventHandler(object sender, RoutedEventArgs e)
		{
			DependencyObject obj = sender as DependencyObject;

			if (obj != null)
			{
				ICommand command = obj.GetValue(_property) as ICommand;

				if (command != null)
				{
					if (command.CanExecute(e))
					{
						command.Execute(obj);
					}
				}
			}
		}
	}
}

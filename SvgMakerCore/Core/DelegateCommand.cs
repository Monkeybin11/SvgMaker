﻿using System;
using System.Windows.Input;

namespace SvgMakerCore.Core.Operation
{
    public class DelegateCommand : ICommand
    {        
        public bool CanExecute(object parameter)
            => CanExecuteFunc?.Invoke() ?? true;

        public void Execute(object parameter)
            => Action?.Invoke();

        public event EventHandler CanExecuteChanged;

        private Action Action { get; }


        public DelegateCommand(Action action)
            => Action = action;

        private Func<bool> CanExecuteFunc { get; }
        public DelegateCommand(Action action,Func<bool> canExecute):this(action)
            => CanExecuteFunc = canExecute;

        public void OnCanExecuteChanged()
            => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public class DelegateCommand<T> : ICommand 
    {
        public bool CanExecute(object parameter)
            => CanExecuteFunc?.Invoke((T)parameter) ?? true;

        public void Execute(object parameter)
            => Action?.Invoke((T)parameter);

        public event EventHandler CanExecuteChanged;

        private Action<T> Action { get; }

        public DelegateCommand(Action<T> action)
            => Action = action;

        private Func<T, bool> CanExecuteFunc { get; }
        public DelegateCommand(Action<T> action, Func<T,bool> canExecute) : this(action)
            => CanExecuteFunc = canExecute;

        public void OnCanExecuteChanged()
            => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

}

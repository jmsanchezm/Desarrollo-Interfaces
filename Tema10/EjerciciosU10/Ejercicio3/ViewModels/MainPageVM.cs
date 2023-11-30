
using System.ComponentModel;
using System.Windows.Input;

namespace Ejercicio3.ViewModels
{
    public class MainPageVM : INotifyPropertyChanged
    {

        string entry = "0";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Entry
        {
            private set
            {
                if (entry != value)
                {
                    entry = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Entry"));
                }
            }
            get
            {
                return entry;
            }
        }

        public ICommand ClearCommand { private set; get; }
        public ICommand BackspaceCommand { private set; get; }
        public ICommand DigitCommand { private set; get; }

        public DecimalKeypadViewModel()
        {
            ClearCommand = new Command(
                execute: () =>
                {
                    Entry = "0";
                    RefreshCanExecutes();
                });
        
        }

        void RefreshCanExecutes()
        {
            ((Command)BackspaceCommand).ChangeCanExecute();
            ((Command)DigitCommand).ChangeCanExecute();
        }

        public DecimalKeypadViewModel()
        {
      
        BackspaceCommand = new Command(
            execute: () =>
            {
                Entry = Entry.Substring(0, Entry.Length - 1);
                if (Entry == "")
                {
                    Entry = "0";
                }
                RefreshCanExecutes();
            },
            canExecute: () =>
            {
                return Entry.Length > 1 || Entry != "0";
            });
       
        }

        public DecimalKeypadViewModel()
        {
            DigitCommand = new Command<string>(
            execute: (string arg) =>
            {
                Entry += arg;
                if (Entry.StartsWith("0") && !Entry.StartsWith("0."))
                {
                    Entry = Entry.Substring(1);
                }
                RefreshCanExecutes();
            },
            canExecute: (string arg) =>
            {
                return !(arg == "." && Entry.Contains("."));
            });
        }
    }
}

using Microsoft.Win32;
using System.Windows.Input;

namespace FlightChecklist.Creator.Wpf
{
    internal class MainWindowViewModel
    {
        private const string DialogFilter = "JSON File (*.json)|*.json";

        public MainWindowViewModel()
        {
            Model = new ObjectModel.Checklist();
        }

        public ObjectModel.Checklist Model { get; private set; }

        public ICommand NewCommand {  get { return new DelegateCommand(OnNew); } }
        public ICommand OpenCommand { get { return new DelegateCommand(OnOpen); } }
        public ICommand SaveCommand { get { return new DelegateCommand(OnSave); } }
        public ICommand SaveAsCommand { get { return new DelegateCommand(OnSaveAs); } }
        public ICommand ExitCommand { get { return new DelegateCommand(OnExit); } }

        public void OnNew(object obj)
        {
            Model = new ObjectModel.Checklist();
        }

        public void OnOpen(object obj)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = DialogFilter
            };
            if (ofd.ShowDialog() == true)
            {
                Model = ObjectModel.Checklist.Load(ofd.FileName);
                Model.Filename = ofd.FileName;
            }
        }

        public void OnSave(object obj)
        {
            if(string.IsNullOrEmpty(Model?.Filename))
            {
                OnSaveAs(obj);
            }
            else
            {
                Model.Save(Model.Filename);
            }
        }

        public void OnSaveAs(object obj)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = DialogFilter
            };
            if(sfd.ShowDialog() == true)
            {
                Model.Filename = sfd.FileName;
                Model.Save(Model.Filename);
            }
        }

        public void OnExit(object obj)
        {
            App.Current.Shutdown();
        }
    }
}

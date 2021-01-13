using HeatMap.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Squirrel;

namespace HeatMap.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Heat Map";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
           CheckForUpdate();
        }

        private string _csvPath;

        public string CsvPath
        {
            get => _csvPath;
            set
            {
                SetProperty(ref _csvPath, value);
                ConvertCommand.RaiseCanExecuteChanged();
            }
        }

        private DelegateCommand _getCsvPathCommand;

        public DelegateCommand GetCsvPathCommand =>
            _getCsvPathCommand ?? (_getCsvPathCommand = new DelegateCommand(ExecuteGetCsvPathCommand));

        void ExecuteGetCsvPathCommand()
        {
            CsvPath = FileExtension.GetFilePathWithExtension("csv", "csv");
        }

        private DelegateCommand _convertCommand;

        public DelegateCommand ConvertCommand =>
            _convertCommand ?? (_convertCommand = new DelegateCommand(ExecuteConvertCommand, CanExecuteConvertCommand));

        void ExecuteConvertCommand()
        {

        }

        bool CanExecuteConvertCommand()
        {

            return !string.IsNullOrWhiteSpace(CsvPath);
        }

        private async void CheckForUpdate()
        {
            using (var mgr = new UpdateManager("D:\\HeatMap"))
            {
                await mgr.UpdateApp();
            }
            //try
            //{
            //    using (var mgr = UpdateManager.GitHubUpdateManager("https://github.com/Witte030/HeatMapTest"))
            //    {
            //        await mgr.Result.UpdateApp();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message + System.Environment.NewLine;
            //    if (ex.InnerException != null)
            //        message += ex.InnerException.Message;
            //    MessageBox.Show(message);
            //}
        }

    }
}


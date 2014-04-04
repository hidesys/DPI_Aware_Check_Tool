using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DPI_Aware_Check_Tool
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TransformFromDevice_Reload_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new MainWindowModel(PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new MainWindowModel(PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice);
        }
    }

    public partial class MainWindowModel : System.ComponentModel.INotifyPropertyChanged 
    {
        public MainWindowModel(Matrix transformFromDevice)
        {
            TransformFromDevice = transformFromDevice;
        }

        public const string TransformFromDevicePropertyName = "TransformFromDevice";
        private Matrix _TransformFromDevice;
        public Matrix TransformFromDevice
        {
            get { return _TransformFromDevice; }
            set { if (value != _TransformFromDevice || true) { _TransformFromDevice = value; OnPropertyChanged(TransformFromDevicePropertyName); } }
        }

        public Version Version
        { get { return Environment.OSVersion.Version; } }

        public string Title
        { get { return "DPI Aware Check Tool, " + TitleAdditional; } }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(name));
            }
        }
    }
}

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
            this.DataContext = new MainWindowModel(PresentationSource.FromVisual(this));

        }

        private void TransformFromDevice_Reload_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new MainWindowModel(PresentationSource.FromVisual(this));
        }
    }

    public partial class MainWindowModel
    {
        public MainWindowModel(PresentationSource presentationSource)
        {
            if (presentationSource != null)
            {
                _TransformFromDevice = presentationSource.CompositionTarget.TransformFromDevice;
            }
        }

        private Matrix _TransformFromDevice;
        public Matrix TransformFromDevice
        { get { return _TransformFromDevice; } }

        public Version Version
        { get { return Environment.OSVersion.Version; } }

        public string Title
        { get { return "DPI Aware Check Tool, " + TitleAdditional; } }
    }
}

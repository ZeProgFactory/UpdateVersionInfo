using System.Windows;
using Microsoft.VisualStudio.PlatformUI;

namespace XamlDialogInVSExtensionDemo
{
    /// <summary>
    /// Interaction logic for XamlDialog.xaml
    /// </summary>
    public partial class XamlDialog : DialogWindow
    {
        public XamlDialog(string helpTopic) : base(helpTopic)
        {
            InitializeComponent();
        }

        public XamlDialog()
        {
            InitializeComponent();
        }
    }
}

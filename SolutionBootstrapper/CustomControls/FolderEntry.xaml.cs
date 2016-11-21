using System.Windows;
using System.Windows.Forms;

namespace SolutionBootstrapper.CustomControls
{
    public partial class FolderEntry : System.Windows.Controls.UserControl
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(FolderEntry),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register(
                "Description",
                typeof(string),
                typeof(FolderEntry), new PropertyMetadata(null));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }
        
        public FolderEntry()
        {
            InitializeComponent();
        }

        private void BrowseFolderContent(object sender, RoutedEventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = Description;
                folderDialog.SelectedPath = Text;
                folderDialog.ShowNewFolderButton = true;

                var dialogResult = folderDialog.ShowDialog();
                if (dialogResult != DialogResult.OK) return;

                Text = folderDialog.SelectedPath;
                var textBindingExpression = GetBindingExpression(
                    TextProperty);
                if (textBindingExpression == null) return;

                textBindingExpression.UpdateSource();
            }
        }
    }
}

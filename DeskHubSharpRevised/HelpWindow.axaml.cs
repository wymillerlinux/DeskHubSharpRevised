$HEADER$using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace $NAMESPACE$
{
    public partial class $CLASS$ : Window
    {
        public $CLASS$()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

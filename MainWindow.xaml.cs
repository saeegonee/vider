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

namespace vider;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>

public partial class MainWindow : Window
{
    private bool _isPlaying = false;

    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void Move(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed) 
        {
            DragMove(); 
            log.Text = $"({this.Top}, {this.Left})";
        }
    }

    private void UserControl(object sender, RoutedEventArgs e)
    {
        var win = Window.GetWindow(this);
        win.KeyDown += PlayToggle;
        win.KeyDown += Volume;
    }
    
    private void PlayToggle(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Space)
        {
            _isPlaying = !_isPlaying;
        }

        if (_isPlaying)
        {
            mediaElement.Play();
            mediaElement.Volume = 0.1;
        }
        else
        {
            mediaElement.Pause();
        }
    }

    private void Volume(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.U)
        {
            mediaElement.Volume += 0.02f;
            log.Text = "Volume +2";
        }

        if (e.Key == Key.I)
        {
            mediaElement.Volume -= 0.02f;
            log.Text = "Volume -2";
        }
    }
}

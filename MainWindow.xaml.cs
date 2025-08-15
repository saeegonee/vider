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
        
        // mediaElement.Source = new Uri("D:/_Others/vider/video.mp4");
        mediaElement.Source = new Uri("https://v5-dtln.1internet.tv/video/multibitrate/video/2025/08/14/9e2f1922-569f-4075-a851-56506acb3ff5_HD-news-2025_08_14-23_09_33_,350,950,3800,8000,.mp4.urlset/index-f4-v1-a1.m3u8", UriKind.Absolute);
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

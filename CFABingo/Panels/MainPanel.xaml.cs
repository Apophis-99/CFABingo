using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace CFABingo.Panels;

public partial class MainPanel
{
    private bool _showButton;
    
    public bool ShowButton
    {
        get => _showButton;
        set { 
            _showButton = value;
            RollButton.Visibility = _showButton ? Visibility.Visible : Visibility.Collapsed;
            //UpdateBallSize();
        }
    }


    private int _displayNumber;

    public int DisplayNumber
    {
        get => _displayNumber;
        set
        {
            _displayNumber = value;
            DisplayNumberText.Text = (_displayNumber == 0) ? "?" : _displayNumber.ToString();
        }
    }
    
    public MainPanel()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, RoutedEventArgs e)
    {
        MainWindow.Manager.CurrentGame.GetNext();
    }

    private void UpdateBallSize()
    {
        var ball = (Ellipse)Ball.Children[0];
        var margin = ball.Margin.Top * 2;
            
        ball.Width = (Ball.ActualHeight < Ball.ActualWidth) ? Ball.ActualHeight - margin : Ball.ActualWidth - margin;
        ball.Height = (Ball.ActualHeight < Ball.ActualWidth) ? Ball.ActualHeight - margin : Ball.ActualWidth - margin;

        Ball.Children[0] = ball;

        ((TextBlock)Ball.Children[1]).FontSize = Ball.ActualHeight / 2 - 2;
    }

    private void Panel_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        UpdateBallSize();
    }
}

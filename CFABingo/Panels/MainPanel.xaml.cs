using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;

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

    private readonly DispatcherTimer _dispatcherTimer;
    
    private int _displayNumber;

    public int DisplayNumber
    {
        get => _displayNumber;
        set
        {
            _displayNumber = value;
            DisplayNumberText.Text = (_displayNumber == 0) ? "?" : _displayNumber.ToString();
            if (MainWindow.Manager == null) return;
            if (!MainWindow.Manager.CurrentSettings.MainPanelBallDoIdleAnimation) return;
            
            if (DisplayNumber == 0)
            {
                _dispatcherTimer.Start();
            }
            else
            {
                _dispatcherTimer.Stop();
            }
        }
    }

    public MainPanel()
    {
        InitializeComponent();

        _dispatcherTimer = new DispatcherTimer();
        _dispatcherTimer.Tick += TextIdleAnim;
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
    
    private void TextIdleAnim(object? sender, EventArgs e)
    {
        if (!MainWindow.Manager.CurrentSettings.MainPanelBallDoIdleAnimation) return;
        _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, MainWindow.Manager.CurrentSettings.MainPanelIdleAnimationDelay);
        DisplayNumberText.Text = DisplayNumberText.Text switch
        {
            "|" => "/",
            "/" => "-",
            "-" => "\\",
            "\\" => "|",
            "?" => "|",
            _ => DisplayNumberText.Text
        };
    }
}

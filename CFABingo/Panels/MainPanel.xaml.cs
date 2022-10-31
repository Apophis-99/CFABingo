using System.Windows;

namespace CFABingo.Panels;

public partial class MainPanel
{
    private int _displayNumber = 32;
    public int DisplayNumber
    {
        get => _displayNumber;
        set { _displayNumber = value;
            NumberDisplay.Text = _displayNumber == 0 ? "?" : _displayNumber.ToString();
        }
    }

    private bool _buttonEnabled = true;
    public bool ButtonEnabled
    {
        get => _buttonEnabled;
        set { 
            _buttonEnabled = value;
            RollButton.IsEnabled = _buttonEnabled;
        }
    }


    private bool _showButton = true;
    public bool ShowButton
    {
        get => _showButton;
        set { 
            _showButton = value;
            RollButton.Visibility = Visibility.Collapsed;
        }
    }
    
    public MainPanel()
    {
        InitializeComponent();
    }

    private void RollButton_OnClick(object sender, RoutedEventArgs e)
    {
        MainWindow.CurrentGame.GetNext();
        DisplayNumber = MainWindow.CurrentGame.CurrentNumber;
    }
}

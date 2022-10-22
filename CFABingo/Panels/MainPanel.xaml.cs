using System.Windows.Controls;

namespace CFABingo.Panels;

public partial class MainPanel : UserControl
{
    public int DisplayNumber;
    public bool ButtonEnabled;
    
    public MainPanel()
    {
        InitializeComponent();

        DisplayNumber = 0;
        ButtonEnabled = true;
    }
}

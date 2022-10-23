using System.Windows.Controls;

namespace CFABingo.Controls;

public partial class PanelHeader
{
    private string _title = "<PanelTitle>";

    public string Title
    {
        get => _title;
        set 
        { 
            _title = value;
            TitleText.Text = _title;
        }
    }
    public Orientation Orientation { get; set; }

    public PanelHeader()
    {
        InitializeComponent();
    }
}

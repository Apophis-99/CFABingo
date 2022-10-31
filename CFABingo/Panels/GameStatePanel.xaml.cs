using System.Windows.Controls;

namespace CFABingo.Panels;

public partial class GameStatePanel
{
    private Orientation _orientation;
    
    public Orientation Orientation
    {
        get => _orientation;
        set
        { _orientation = value; SetupOrientation(); }
    }
    
    public GameStatePanel()
    {
        InitializeComponent();
    }

    private void SetupOrientation()
    {
        if (Orientation == Orientation.Horizontal)
        {
            // Redraw grid in different format
        }
        else
        {
            // This will be standard orientation
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Media;
using CFABingo.Panels;
using Newtonsoft.Json;

namespace CFABingo.Utilities;

public class Settings
{
    #region Theme

    public Brush PrimaryColour;
    public Brush SecondaryColour;
    public Brush TertiaryColour;

    #endregion

    #region Constraints

    

    #endregion

    #region Panels

    public bool MainPanelShowButton;

    #endregion

    #region Methods

    public Settings()
    {
        // TODO read in Settings.json file

        using var r = new StreamReader("/Assets/Themes.json");
        var json = r.ReadToEnd();
        var themes = JsonConvert.DeserializeObject<Theme>(json);
        
    }
    
    public void UpdateSettings()
    {
        ApplyTheme();
        UpdatePanels();
    }
    
    private void ApplyTheme()
    {
        Application.Current.Resources["PrimaryColour"] = PrimaryColour;
        Application.Current.Resources["SecondaryColour"] = SecondaryColour;
        Application.Current.Resources["TertiaryColour"] = TertiaryColour;
    }

    private void UpdatePanels()
    {
        
    }

    #endregion

}

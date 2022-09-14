using System;
using UnityEngine;

public abstract class PanelController : MonoBehaviour
{
    public string currentPanel = "";

    private string param = "";    

    /// <summary>
    /// Go to previous panel
    /// </summary>
    public void GoBack()
    {
        Panel panel = GetPanel(currentPanel);
        GoToPanel(panel.GetPreviousPanelName());
    }

    /// <summary>
    /// Go to panel by given name, reset param
    /// </summary>
    /// <param name="panelName"></param>
    public void GoToPanel(string panelName)
    {
        this.param = "";
        GoToPanelBase(panelName);
    }

    /// <summary>
    /// Go to panel by given name and param
    /// </summary>
    /// <param name="panel"></param>
    public void GoToPanel(string panelName, string param)
    {
        this.param = param;
        GoToPanelBase(panelName);       
    }    

    /// <summary>
    /// Go to panel by given name
    /// </summary>
    /// <param name="panel"></param>
    private void GoToPanelBase(string panelName)
    {
        //Hide current panel
        if (currentPanel != "") {
            Panel currPanel = GetPanel(currentPanel);
            currPanel.Hide();
        }

        //Show required panel        
        Panel panel = GetPanel(panelName);
        panel.Show(param);

        //Update current panel name
        currentPanel = panelName;
    }

    

    /// <summary>
    /// Get panel script by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private Panel GetPanel(string name)
    {
        // Get panel class type
        Type type = Type.GetType(name + "Panel");
        if (type == null) {
            return null;
        }

        // Instantiate new panel
        return Activator.CreateInstance(type) as Panel;

    }


}

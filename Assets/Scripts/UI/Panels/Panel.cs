public abstract class Panel
{
    public virtual void Show(string param = null)
    {

    }
    public abstract void Hide();
    public abstract string GetPreviousPanelName();
}

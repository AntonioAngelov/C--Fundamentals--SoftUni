public delegate void NameChangeEventHandler(object receiver, NameChangeEventArgs args);

public class Dispatcher
{
    private string name;
    public event NameChangeEventHandler NameChange;

    public string Name
    {
        get { return this.name; }
        set
        {
            this.name = value;
            OnNameChange(new NameChangeEventArgs(value));
        }
    }

    public void OnNameChange(NameChangeEventArgs args)
    {
        if (this.NameChange != null)
        {
            NameChange(this, args);
        }
    }

}


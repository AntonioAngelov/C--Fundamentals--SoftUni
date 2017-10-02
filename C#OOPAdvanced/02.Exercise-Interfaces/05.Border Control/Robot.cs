public class Robot : IIdentifiable
{
    private string id;
    private string model;

    public Robot(string model, string id)
    {
        this.Id = id;
        this.Model = model;
    }

    public string Id
    {
        get { return this.id; }
        private set { this.id = value; }
    }

    public string Model
    {
        get { return this.model; }
        private set { this.model = value; }
    }
}


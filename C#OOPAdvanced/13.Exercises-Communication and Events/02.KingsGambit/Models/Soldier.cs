using System;

public abstract class Soldier
{
    protected int health;

    protected Soldier(string name)
    {
        this.Name = name;
    }

    public bool SurviveAttack()
    {
        this.health -= 1;

        if (this.health <= 0)
        {
            return false;
        }

        return true;
    }
    
    public string Name { get; set; }

    public abstract void KingUnderAttack(object sender, EventArgs args);
}

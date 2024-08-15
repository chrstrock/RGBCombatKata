namespace RGBCombatKata;

public class Character
{
    public double Health { get; private set; } = 1000;

    public bool IsAlive { get; private set; } = true;

    public int Level { get; private set; } = 1;

    public int MaxHealth { get; private set; } = 1000;

    public void TakeDamage(double damage)
    {
        if(damage > Health)
        {
            damage = Health;
        }
        Health -= damage;
        if (Health <= 0)
        {
            IsAlive = false;
        }
    }
    
    //characters can deal damage to other characters
    public void DealDamage(Character target, double damage)
    {
        //character can not be damaged by itself
        if (this == target)
        {
            return;
        }
        if(Level - target.Level >= 5)
        {
            damage *= 1.5;
        }
        
        target.TakeDamage(damage);
        
    }

    public void Heal(int healthPoints)
    {
        //dead characters can not be healed
        if (!IsAlive)
        {
            return;
        }
        //health can't go beyond 1000 when adding healthPoints if level is less than 6
        if (Health + healthPoints > 1000 && Level < 6)
        {
            Health = 1000;
        }
        else
        {
            Health += healthPoints;
        }
        
    }
    
    public void LevelUp()
    {
        Level++;
        if (Level == 6)
        {
            MaxHealth = 1500;
        }
    }
    
    
}
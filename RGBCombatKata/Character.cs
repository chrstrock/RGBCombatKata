namespace RGBCombatKata;

public class Character
{
    private int Health = 1000;
    private bool IsAlive  = true;
    
    public int GetHealth()
    {
        return Health;
    }
    
    public bool IsCharacterAlive()
    {
        return IsAlive;
    }
    
    public void TakeDamage(int damage)
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
    public void dealDamage(Character target, int damage)
    {
        //character can not be damaged by itself
        if (this == target)
        {
            return;
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
        Health += healthPoints;
        
    }
}
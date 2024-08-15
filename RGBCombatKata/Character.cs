namespace RGBCombatKata;

public class Character
{
    private double _health = 1000;
    private bool _isAlive = true;
    private int _level = 1;
    private int _maxHealth = 1000;

    public double Health
    {
        get => _health;
        private set => _health = value;
    }

    public bool IsAlive
    {
        get => _isAlive;
        private set => _isAlive = value;
    }

    public int Level
    {
        get => _level;
        private set => _level = value;
    }

    public int MaxHealth
    {
        get => _maxHealth;
        private set => _maxHealth = value;
    }

    public void TakeDamage(double damage)
    {
        if (damage > Health)
        {
            damage = Health;
        }
        Health -= damage;
        if (Health <= 0)
        {
            IsAlive = false;
            Health = 0;
        }
    }

    public void DealDamage(Character target, double damage)
    {
        if (this == target)
        {
            return;
        }
        
        damage *= Level - target.Level >= 5 ? 1.5 : target.Level - Level >= 5 ? 0.5 : 1;
        target.TakeDamage(damage);
    }

    public void Heal(int healthPoints)
    {
        if (!IsAlive)
        {
            return;
        }
        if (Health + healthPoints > MaxHealth)
        {
            Health = MaxHealth;
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
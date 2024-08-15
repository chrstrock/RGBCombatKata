using NuGet.Frameworks;
using RGBCombatKata;

namespace RGBCombatKataTests;

public class Tests
{
    private Character _character;
    [SetUp]
    public void Setup()
    {
        _character = new Character();
    }

    [Test]
    public void CharacterHas1000HealthToStart()
    {
        Assert.That(_character.Health, Is.EqualTo(1000));
    }
    
    [Test]
    public void CharacterDefaultsToAlive()
    {
        Assert.That(_character.IsAlive, Is.True);
    }
    
    [Test]
    public void CharacterIsDeadWhenHealthIsZero()
    {
        _character.TakeDamage(1000);
        Assert.That(_character.IsAlive, Is.False);
    }
    
    [Test]
    public void CharacterCannotDealDamageToItself()
    {
        _character.DealDamage(_character, 200);
        Assert.That(_character.Health, Is.EqualTo(1000));
    }
    
    [Test]
    public void CharacterCanDealDamageToAnotherCharacter()
    {
        var target = new Character();
        _character.DealDamage(target, 200);
        Assert.That(target.Health, Is.EqualTo(800));
    }
    
    [Test]
    public void CharacterCanDealDamageToAnotherCharacterUntilDead()
    {
        var target = new Character();
        _character.DealDamage(target, 1000);
        Assert.That(target.IsAlive, Is.False);
    }
    
    [Test]
    public void CharacterCanDealDamageToAnotherCharacterMultipleTimes()
    {
        var target = new Character();
        _character.DealDamage(target, 200);
        _character.DealDamage(target, 200);
        Assert.That(target.Health, Is.EqualTo(600));
    }
    
    [Test]
    public void CharacterCanDealDamageToAnotherCharacterMultipleTimesUntilDead()
    {
        var target = new Character();
        _character.DealDamage(target, 200);
        _character.DealDamage(target, 200);
        _character.DealDamage(target, 200);
        _character.DealDamage(target, 200);
        _character.DealDamage(target, 200);
        Assert.That(target.IsAlive, Is.False);
    }
    
    [Test]
    public void CharacterCanHealItself()
    {
        _character.TakeDamage(500);
        _character.Heal(200);
        Assert.That(_character.Health, Is.EqualTo(700));
    }
    
    [Test]
    public void DeadCharacterCannotBeHealed()
    {
        _character.TakeDamage(1000);
        _character.Heal(200);
        Assert.That(_character.Health, Is.EqualTo(0));
    }
    
    [Test]
    public void HealthCannotBeNegative()
    {
        _character.TakeDamage(2000);
        Assert.That(_character.Health, Is.EqualTo(0));
    }

    [Test]
    public void AllCharactersHaveLevelStartingAt1()
    {
        Assert.That(_character.Level, Is.EqualTo(1));
    }

    [Test]
    public void CharacterCannotHaveHealthGreaterThan1000UnlessLevelGreaterThan5()
    {
        _character.Heal(200);
        Assert.That(_character.Health, Is.EqualTo(1000));
    }

    [Test]
    public void MaxHealthIncreasesTo1500AtLevel6()
    {
        for(var i = 0; i < 5; i++)
        {
            _character.LevelUp();
        }
        
        _character.Heal(200);
        Assert.That(_character.MaxHealth, Is.EqualTo(1500));
    }

    [Test]
    public void DamageIncreasedByFiftyPercentWhen5OrMoreLevelsAboveTarget()
    {
        var target = new Character();
        for(var i = 0; i < 5; i++)
        {
            _character.LevelUp();
        }
        
        _character.DealDamage(target, 200);
        Assert.That(target.Health, Is.EqualTo(700));
    }


}
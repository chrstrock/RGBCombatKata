using NuGet.Frameworks;
using RGBCombatKata;

namespace RGBCombatKataTests;

public class Tests
{
    private Character character;
    [SetUp]
    public void Setup()
    {
        character = new Character();
    }

    [Test]
    public void CharacterHas1000HealthToStart()
    {
        Assert.That(character.GetHealth(), Is.EqualTo(1000));
    }
    
    [Test]
    public void CharacterDefaultsToAlive()
    {
        Assert.That(character.IsCharacterAlive(), Is.True);
    }
    
    [Test]
    public void CharacterIsDeadWhenHealthIsZero()
    {
        character.TakeDamage(1000);
        Assert.That(character.IsCharacterAlive(), Is.False);
    }
    
    [Test]
    public void CharacterCannotDealDamageToItself()
    {
        character.dealDamage(character, 200);
        Assert.That(character.GetHealth(), Is.EqualTo(1000));
    }
    
    [Test]
    public void CharacterCanDealDamageToAnotherCharacter()
    {
        var target = new Character();
        character.dealDamage(target, 200);
        Assert.That(target.GetHealth(), Is.EqualTo(800));
    }
    
    [Test]
    public void CharacterCanDealDamageToAnotherCharacterUntilDead()
    {
        var target = new Character();
        character.dealDamage(target, 1000);
        Assert.That(target.IsCharacterAlive(), Is.False);
    }
    
    [Test]
    public void CharacterCanDealDamageToAnotherCharacterMultipleTimes()
    {
        var target = new Character();
        character.dealDamage(target, 200);
        character.dealDamage(target, 200);
        Assert.That(target.GetHealth(), Is.EqualTo(600));
    }
    
    [Test]
    public void CharacterCanDealDamageToAnotherCharacterMultipleTimesUntilDead()
    {
        var target = new Character();
        character.dealDamage(target, 200);
        character.dealDamage(target, 200);
        character.dealDamage(target, 200);
        character.dealDamage(target, 200);
        character.dealDamage(target, 200);
        Assert.That(target.IsCharacterAlive(), Is.False);
    }
    
    [Test]
    public void CharacterCanHealItself()
    {
        character.TakeDamage(500);
        character.Heal(200);
        Assert.That(character.GetHealth(), Is.EqualTo(700));
    }
    
    [Test]
    public void DeadCharacterCannotBeHealed()
    {
        character.TakeDamage(1000);
        character.Heal(200);
        Assert.That(character.GetHealth(), Is.EqualTo(0));
    }
    
    [Test]
    public void HealthCannotBeNegative()
    {
        character.TakeDamage(2000);
        Assert.That(character.GetHealth(), Is.EqualTo(0));
    }
    
    
}
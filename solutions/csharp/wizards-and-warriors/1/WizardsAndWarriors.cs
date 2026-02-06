abstract class Character
{
    private string characterType;
    
    protected Character(string characterType)
    {
        this.characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() => $"Character is a {characterType}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;
}

class Wizard : Character
{
    public Wizard() : base("Wizard")
    {
    }

    private bool Spell = false;

    public override bool Vulnerable() => !Spell;

    public override int DamagePoints(Character target) => Spell ? 12 : 3;
    
    public void PrepareSpell() => Spell = true;
}

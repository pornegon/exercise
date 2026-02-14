using System;
using System.Linq;

public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    public byte real;
    
    public Allergies(int mask)
    {
        real = (byte)(mask & 0xFF);
    }

    public bool IsAllergicTo(Allergen allergen) => (real & (byte)allergen) >= (byte)allergen;

    public Allergen[] List() => Enum.GetValues(typeof(Allergen)).Cast<Allergen>().Where(p => IsAllergicTo(p)).ToArray();
}
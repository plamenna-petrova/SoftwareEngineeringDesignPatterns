using System;
using System.Text;

namespace CharacterBuild
{
    public abstract class CharacterBuild
    {
        public int Health { get; set; }

        public int Stamina { get; set; }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Endurance { get; set; }

        public int Attunement { get; set; }

        public virtual void ShowStats()
        {
            StringBuilder stringBuilder = new StringBuilder()
                .AppendLine($"Health: {Health}")
                .AppendLine($"Stamina: {Stamina}")
                .AppendLine($"Strength: {Strength}")
                .AppendLine($"Dexterity: {Dexterity}")
                .AppendLine($"Endurance: {Endurance}")
                .AppendLine($"Attunement: {Attunement}");

            Console.WriteLine(stringBuilder.ToString());
        }
    }

    public class Knight : CharacterBuild
    {
        public Knight()
        {
            Health = 120;
            Stamina = 110;
            Strength = 15;
            Dexterity = 10;
            Endurance = 12;
            Attunement = 3;
        }
    }

    public class Wanderer : CharacterBuild
    {
        public Wanderer()
        {
            Health = 100;
            Stamina = 120;
            Strength = 10;
            Dexterity = 15;
            Endurance = 12;
            Attunement = 4;
        }
    }

    public abstract class CharacterBuildDecorator : CharacterBuild
    {
        protected CharacterBuild characterBuild;

        public CharacterBuildDecorator(CharacterBuild characterBuild)
        {
            this.characterBuild = characterBuild;
        }

        public virtual void IncreaseHealth(int points) => characterBuild.Health += points;

        public virtual void IncreaseStrength(int points) => characterBuild.Strength += points;

        public virtual void IncreaseDexterity(int points) => characterBuild.Dexterity += points;

        public virtual void IncreaseEndurance(int points) => characterBuild.Endurance += points;

        public virtual void IncreaseAttunement(int points) => characterBuild.Attunement += points;

        public override void ShowStats() => characterBuild.ShowStats();
    }

    public class StrengthBuild : CharacterBuildDecorator
    {
        public StrengthBuild(CharacterBuild characterBuild) : base(characterBuild)
        {
            characterBuild.Strength += 10;
            characterBuild.Health -= 10;
        }
    }

    public class DexterityBuild : CharacterBuildDecorator
    {
        public DexterityBuild(CharacterBuild characterBuild) : base(characterBuild)
        {
            characterBuild.Dexterity += 10;
            characterBuild.Strength -= 2;
        }
    }

    public class MagicKnightBuild : CharacterBuildDecorator
    {
        public MagicKnightBuild(CharacterBuild characterBuild) : base(characterBuild)
        {
            if (characterBuild is CharacterBuildDecorator characterBuildDecorator)
            {
                characterBuildDecorator.IncreaseAttunement(15);
            }
            else
            {
                characterBuild.Attunement += 15;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            CharacterBuild knight = new Knight();
            Console.WriteLine("Base Knight Stats:");
            knight.ShowStats();

            CharacterBuild strengthenedKnight = new StrengthBuild(knight);
            Console.WriteLine("Knight Stats After Strength Build: ");
            strengthenedKnight.ShowStats();

            CharacterBuild wanderer = new Wanderer();
            Console.WriteLine("Base Wanderer Stats: ");
            wanderer.ShowStats();

            CharacterBuild dexterousWanderer = new DexterityBuild(wanderer);
            Console.WriteLine("Wanderer Stats After Dexterity Build: ");
            dexterousWanderer.ShowStats();

            CharacterBuild magicKnight = new MagicKnightBuild(strengthenedKnight);
            Console.WriteLine("Strengthened Knight After Magic Build: ");
            magicKnight.ShowStats();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Characters
{
    public abstract class Character
    {
        protected char symbol;

        protected int width;

        protected int height;

        protected int ascent;

        protected int descent;

        protected int pointSize;

        public abstract void Display(int pointSize);
    }

    public class CharacterA : Character
    {
        public CharacterA()
        {
            symbol = 'A';
            height = 100;
            width = 120;
            ascent = 70;
            descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Console.WriteLine($"symbol (pointsize {this.pointSize})");
        }
    }

    public class CharacterB : Character
    {
        public CharacterB()
        {
            symbol = 'B';
            height = 100;
            width = 140;
            ascent = 72;
            descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Console.WriteLine($"symbol (pointsize {this.pointSize})");
        }
    }

    public class CharacterZ : Character
    {
        public CharacterZ()
        {
            symbol = 'Z';
            height = 100;
            width = 100;
            ascent = 68;
            descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Console.WriteLine($"symbol (point size {this.pointSize})");
        }
    }

    public class CharacterFactory
    {
        private Dictionary<char, Character> characters = new Dictionary<char, Character>();

        public Character GetCharacter(char key)
        {
            Character character = null;

            if (characters.ContainsKey(key))
            {
                character = characters[key];
            }
            else
            {
                switch (key)
                {
                    case 'A':
                        character = new CharacterA();
                        break;
                    case 'B':
                        character = new CharacterB();
                        break;
                    case 'Z':
                        character = new CharacterZ();
                        break;
                }

                characters.Add(key, character);
            }

            return character;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string documentText = "AAZZBBZB";
            char[] documentTextCharacters = documentText.ToCharArray();

            CharacterFactory characterFactory = new CharacterFactory();

            int pointSize = 10;

            foreach (char documentTextCharacter in documentTextCharacters)
            {
                pointSize++;
                Character character = characterFactory.GetCharacter(documentTextCharacter);
                character.Display(pointSize);
            }
        }
    }
}

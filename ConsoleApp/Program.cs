using System;

namespace ConsoleApp
{
    abstract class Character
    {
        protected string _characterType;
        protected bool _vulnerable = false;

        protected Character(string characterType) => _characterType = characterType;

        public abstract int DamagePoints(Character target);

        public virtual bool Vulnerable() => _vulnerable;

        public override string ToString() => $"Character is a {_characterType}";
    }

    class Warrior: Character
    {
        public Warrior() : base("Warrior") => _vulnerable = false;

        public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;
    }

    class Wizard: Character
    {
        public Wizard() : base("Wizard") => _vulnerable = true;

        public override int DamagePoints(Character target) => _vulnerable ? 3 : 12;

        public void PrepareSpell() => _vulnerable = false;
    }

    public class Program
    {
        private static void T1()
        {
        }

        private static void RunTests()
        {
            Console.WriteLine("Running tests");

            T1();

            Console.WriteLine("Finished tests");
        }

        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}
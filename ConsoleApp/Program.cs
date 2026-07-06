using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class FacialFeatures
    {
        public string EyeColor { get; }
        public decimal PhiltrumWidth { get; }

        public FacialFeatures(string eyeColor, decimal philtrumWidth)
        {
            EyeColor = eyeColor;
            PhiltrumWidth = philtrumWidth;
        }

        public override bool Equals(object o) => o != null && o is FacialFeatures f && EyeColor == f.EyeColor && PhiltrumWidth == f.PhiltrumWidth;

        public override int GetHashCode() => (int)((long)EyeColor.GetHashCode() * PhiltrumWidth.GetHashCode() % int.MaxValue);
    }
    public class Identity
    {
        public string Email { get; }
        public FacialFeatures FacialFeatures { get; }

        public Identity(string email, FacialFeatures facialFeatures)
        {
            Email = email;
            FacialFeatures = facialFeatures;
        }

        public override bool Equals(object o) => o != null && o is Identity i && Email == i.Email && FacialFeatures.Equals(i.FacialFeatures);

        public override int GetHashCode() => (int)((long)Email.GetHashCode() * FacialFeatures.GetHashCode() % int.MaxValue);
    }

    public class Authenticator
    {
        private readonly HashSet<Identity> _registered = new();

        public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

        public bool IsAdmin(Identity identity) => identity.Equals(new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m)));

        public bool Register(Identity identity) => _registered.Add(identity);

        public bool IsRegistered(Identity identity) => _registered.Contains(identity);

        public static bool AreSameObject(Identity identityA, Identity identityB) => identityA == identityB;
    }

    public class Program
    {

        private static void RunTests()
        {
            Console.WriteLine("Running tests");

            Console.WriteLine("Finished tests");
        }

        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}
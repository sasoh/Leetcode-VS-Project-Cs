using System;
using System.Text;

namespace ConsoleApp
{
    public class SecurityPassMaker
    {
        public string GetDisplayName(TeamSupport support)
        {
            var sb = new StringBuilder();
            sb.Append("Too Important for a Security Pass");
            if (support is Staff)
            {
                sb.Clear();
                sb.Append(support.Title);

                if (support is Security)
                {
                    if (support is not (SecurityJunior or SecurityIntern or PoliceLiaison))
                    {
                        sb.Append(" Priority Personnel");
                    }
                }
            }

            return sb.ToString();
        }
    }

    /**** Please do not alter the code below ****/

    public interface TeamSupport { string Title { get; } }

    public abstract class Staff: TeamSupport { public abstract string Title { get; } }

    public class Manager: TeamSupport { public string Title { get; } = "The Manager"; }

    public class Chairman: TeamSupport { public string Title { get; } = "The Chairman"; }

    public class Physio: Staff { public override string Title { get; } = "The Physio"; }

    public class OffensiveCoach: Staff { public override string Title { get; } = "Offensive Coach"; }

    public class GoalKeepingCoach: Staff { public override string Title { get; } = "Goal Keeping Coach"; }

    public class Security: Staff { public override string Title { get; } = "Security Team Member"; }

    public class SecurityJunior: Security { public override string Title { get; } = "Security Junior"; }

    public class SecurityIntern: Security { public override string Title { get; } = "Security Intern"; }

    public class PoliceLiaison: Security { public override string Title { get; } = "Police Liaison Officer"; }

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
namespace ConsoleApp;

public class GradeSchool
{
    private readonly Dictionary<int, List<string>> _students = [];

    public bool Add(string student, int grade)
    {
        var r = !_students.Any(x => x.Value.Contains(student));
        if (!_students.ContainsKey(grade))
        {
            _students.Add(grade, []);
        }

        if (!_students.Any(x => x.Value.Contains(student)))
        {
            _students[grade].Add(student);
        }

        return r;
    }

    public IEnumerable<string> Roster()
    {
        var orderedGrades = _students.Keys.OrderBy(x => x);
        foreach (var grade in orderedGrades)
        {
            var orderedStudents = _students[grade].OrderBy(x => x);
            foreach (var student in orderedStudents)
            {
                yield return student;
            }
        }
    }

    public IEnumerable<string> Grade(int grade)
    {
        if (!_students.TryGetValue(grade, out var students)) yield break;
        var orderedStudents = _students[grade].OrderBy(x => x);
        foreach (var student in orderedStudents)
        {
            yield return student;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
    }
}
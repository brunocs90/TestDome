using System;

namespace TestDome.Tests
{
    //https://www.testdome.com/questions/32673
    //Each account on a website has a set of access flags that represent a users access.
    //Update and extend the enum so that it contains three new access flags:
    //
    //   1 - A Writer access flag that is made up of the Submit and Modify flags.
    //   2 - An Editor access flag that is made up of the Delete, Publish and Comment flags.
    //   3 - An Owner access that is made up of the Writer and Editor flags.

    //   For example, the code below should print "False" as the Writer flag does not contain the Delete flag.
    //   Console.WriteLine(Access.Writer.HasFlag(Access.Delete))
    public class Account
    {
        [Flags]
        public enum Access
        {
            Delete = 1,  // 00001
            Publish = 2, // 00010
            Submit = 4,  // 00100
            Comment = 8, // 01000
            Modify = 16, // 10000
            Writer = Submit | Modify, // 00100 + 10000 = 10100
            Editor = Delete | Publish | Comment, //00001 + 00010 + 01000 = 01011
            Owner = Writer | Editor, //10100 + 01011 = 11111
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(Access.Writer.HasFlag(Access.Delete)); //Should print: "False"
            Console.ReadKey();
            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.hasflag?view=net-5.0 and https://riptutorial.com/csharp/example/3075/enum-as-flags
        }
    }
}

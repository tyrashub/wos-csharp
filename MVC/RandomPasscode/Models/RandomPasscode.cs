
using System.Text;

namespace RandomPasscode.Models
{
    public class RandomPasscodeModel
    {
        private static int _count = 0;
        private static readonly Random _random = new();

        public int Count { get; private set; }
        public string? Passcode { get; private set; }

        public void GenerateNewPasscode()
        {

            {
                _count++;
                Count = _count;
            }
            Passcode = NewPasscode(14);
        }

        private static string NewPasscode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var passcode = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                passcode.Append(chars[_random.Next(chars.Length)]);
            }
            return passcode.ToString();
        }
    }
}

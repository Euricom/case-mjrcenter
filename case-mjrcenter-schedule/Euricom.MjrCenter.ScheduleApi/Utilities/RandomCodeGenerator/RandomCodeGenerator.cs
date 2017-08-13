using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.ScheduleApi.Utilities.RandomCodeGenerator
{
    public class RandomCodeGenerator : IRandomCodeGenerator
    {
        private static readonly Random _random = new Random();
        private static char[] _validCharacters = "ABCDEFGHJKLMNPQRSTUVWXY123456789".ToCharArray();
        private static int _validCharactersLength = _validCharacters.Length;
        private static int _length = 8;

        private static HashSet<long> debugValues = new HashSet<long>();

        public RandomCodeGenerator()
        {
        }

        public RandomCodeGenerator(int length)
            : this(length, _validCharacters)
        {
            if (length > 12)
            {
                throw new ArgumentException("length must be smaller or equal to 12");
            }
            _length = length - 1;
        }

        public RandomCodeGenerator(int length, char[] validCharacters)
        {
            if (length > 12)
            {
                throw new ArgumentException("length must be smaller or equal to 12");
            }
            _length = length - 1;
            _validCharacters = validCharacters;
            _validCharactersLength = _validCharacters.Length;
        }

        public string Next()
        {
            var rndVal = _random.NextDouble();
            var value = (long)(rndVal * (Math.Pow(_validCharactersLength, _length) - 1));
            var code = Format(value);

            return code;
        }

        private string Format(long value)
        {
            var code = new StringBuilder();
            var rest = value;

            for (int i = _length - 1; i >= 0; i--)
            {
                var quotient = (long)Math.Pow(_validCharactersLength, i);
                var digit = rest / quotient;
                rest = value % quotient;
                code.Append(_validCharacters[digit]);
            }

            //Add UPC Verification
            //https://en.wikipedia.org/wiki/Check_digit
            code.Append(GetCheckDigit(code.ToString()));

            return code.ToString();
        }

        private char GetCheckDigit(string upc)
        {
            var upcParts = System.Text.Encoding.ASCII.GetBytes(upc);
            var sum = upcParts.Select((b, i) => Convert.ToInt32(b * ((i % 2 == 0) ? 1 : 3))).Sum();
            var rMod = sum % _validCharactersLength;

            return _validCharacters[rMod];
        }
    }
}

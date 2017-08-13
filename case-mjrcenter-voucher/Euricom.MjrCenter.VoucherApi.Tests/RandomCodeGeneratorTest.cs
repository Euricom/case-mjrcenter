using Euricom.MjrCenter.VoucherApi.Utilities.RandomCodeGenerator;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Euricom.MjrCenter.VoucherApi.Tests
{
    public class RandomCodeGeneratorTest
    {
        [Fact]
        public void RandomCodeGenerator_Should_Generate_Unique_Codes()
        {
            IRandomCodeGenerator r = new RandomCodeGenerator();
            HashSet<string> codes = new HashSet<string>();
            for (int i = 0; i < 1000; i++)
            {
                var code = r.Next();
                AddCodeOrThrowException(codes, code);
                Thread.Sleep(1);
            }

            Assert.NotEmpty(codes);
        }

        [Fact]
        public void RandomCodeGenerator_Length_10_Should_Generate_Unique_Codes_With_Length_10()
        {
            IRandomCodeGenerator r = new RandomCodeGenerator(10);
            HashSet<string> codes = new HashSet<string>();
            for (int i = 0; i < 1000; i++)
            {
                var code = r.Next();
                AddCodeOrThrowException(codes, code);
                Thread.Sleep(1);
            }

            foreach (var c in codes)
            {
                Assert.Equal(c.Length, 10);
            }
        }

        private static void AddCodeOrThrowException(HashSet<string> codes, string code)
        {
            if (!codes.Add(code))
            {
                throw new System.Exception("Code werd reeds toegevoegd");
            }
        }
    }
}

using Business.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Test.Buisness
{
    public class UniqueIdentifierGeneratorTests
    {
        [Fact]
        public void Generate_Should_Return_Valid_Unique_Id()
        {
            // Act
            var result = UniqueIdentifierGenerator.Genrate();

            // Assert
            Assert.False(string.IsNullOrEmpty(result));
            Assert.True(result.Length > 0);
        }

        [Fact]
        public void Generate_Should_Return_Different_Ids()
        {
            // Act
            var id1 = UniqueIdentifierGenerator.Genrate();
            var id2 = UniqueIdentifierGenerator.Genrate();

            // Assert
            Assert.NotEqual(id1, id2);
        }
    }
}

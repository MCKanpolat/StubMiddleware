using System.Globalization;
using System.Linq;
using StubGenerator.Caching;
using StubGenerator.Core;
using StubGenerator.Defaults;
using StubGenerator.Test.Models;
using Xunit;

namespace StubGenerator.Test
{
    public class StubManagerTests
    {
        private readonly StubManager _stubManager;
        public StubManagerTests()
        {
            var stubManagerOptions = new StubManagerOptions() { AutoGenerateUnknown = true, AutoResolveByNaming = true };
            _stubManager = new StubManager(stubManagerOptions,
                new StubTypeCacheManager(new StubTypeMemoryCache(new DefaultStubTypeCacheKeyGenerator())),
                new DefaultStubDataMappingProfile());
        }

        [Fact(DisplayName = "Mapping_Check_By_Naming_Default_Conventions")]
        public void Naming_Mapping_Check()
        {
            var stubDto = _stubManager.CreateNew<PersonDto>();
            Assert.NotNull(stubDto.FirstName);
            Assert.NotNull(stubDto.LastName);
            Assert.NotNull(stubDto.Email);
        }


        [Fact(DisplayName = "Mapping_Check_By_Naming_Default_Conventions_List_Of")]
        public void Naming_Mapping_Check_List_Of()
        {
            var listOfDto = _stubManager.CreateListOfSize<PersonDto>(10);
            var stubDto = listOfDto.First();
            Assert.NotNull(stubDto.FirstName);
            Assert.NotNull(stubDto.LastName);
            Assert.NotNull(stubDto.Email);
            Assert.Equal(10, listOfDto.Count);
        }

        [Fact(DisplayName = "Mapping_Check_By_Naming_Default_Conventions_Big_List")]
        public void Naming_Mapping_Check_Big_List()
        {
            var listOfDto = _stubManager.CreateListOfSize<PersonDto>(100);
            var stubDto = listOfDto.First();
            Assert.NotNull(stubDto.FirstName);
            Assert.NotNull(stubDto.LastName);
            Assert.NotNull(stubDto.Email);
            Assert.Equal(100, listOfDto.Count);
        }


        [Fact(DisplayName = "Mapping_Check_By_Naming_Default_Conventions_DE_Culture")]
        public void Naming_Mapping_Check_Culture()
        {
            var deCulture = new CultureInfo("de-DE");
            System.Threading.Thread.CurrentThread.CurrentCulture = deCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = deCulture;
            var stubDto = _stubManager.CreateNew<PersonDto>();
            Assert.NotNull(stubDto.FirstName);
            Assert.NotNull(stubDto.LastName);
            Assert.NotNull(stubDto.Email);
        }
    }
}

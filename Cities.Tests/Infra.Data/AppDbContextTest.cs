using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Tests.Infra.Data
{
    public class AppDbContextTest : AppTestContext
    {
        [Fact]
        public async Task DatabaseIsAvaiableAndCanBeConnectedTo() => 
            Assert.True(await _context.Database.CanConnectAsync());
    }
}

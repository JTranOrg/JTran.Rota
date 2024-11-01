using Moq;

namespace Rota.Service.UnitTests
{
    [TestClass]
    public class ShipServiceTests
    {
        private readonly Mock<IShipRepository> _repo = new();
        private readonly IShipService _svc;

        public ShipServiceTests()
        {
            _svc = new ShipService(_repo.Object);
        }

        [TestMethod]
        public async Task ShipService_Get()
        {
            _repo.Setup( (r)=> r.GetAll() ).ReturnsAsync("{ 'bob': 'bob'}");

            var result = await _svc.GetAll();

            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
        }
    }
}
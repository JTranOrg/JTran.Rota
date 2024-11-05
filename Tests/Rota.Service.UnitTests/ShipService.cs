using JTran;
using Moq;

namespace Rota.Service.UnitTests
{
    [TestClass]
    public class ShipServiceTests
    {
        private readonly Mock<IRepository<Ship>> _repo = new();
        private readonly Mock<IRepository<Person>> _personRepo = new();
        private readonly Mock<ITransformer<Ship>> _transform = new();
        private readonly IService<Ship> _svc;

        public ShipServiceTests()
        {
            _svc = new ShipService(_repo.Object, _personRepo.Object, _transform.Object);
        }

        [TestMethod]
        public async Task ShipService_Get()
        {
            _repo.Setup( (r)=> r.GetAll() ).ReturnsAsync(new List<Ship> { new Ship { Name = "bob"} });

            var result = await _svc.GetAll();

            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
        }
    }
}
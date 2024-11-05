using Moq;

namespace Rota.Service.UnitTests
{
    [TestClass]
    public class PersonServiceTests
    {
        private readonly Mock<IRepository<Person>> _repo = new();
        private readonly IService<Person> _svc;

        public PersonServiceTests()
        {
            _svc = new Service<Person>(_repo.Object);
        }

        [TestMethod]
        public async Task PersonService_GetAll()
        {
            _repo.Setup( (r)=> r.GetAll() ).ReturnsAsync(new List<Person> { new Person { GivenName = "bob"} });

            var result = await _svc.GetAll();

            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
        }

        [TestMethod]
        public async Task PersonService_Get()
        {
            _repo.Setup( (r)=> r.Get(It.IsAny<Guid>()) ).ReturnsAsync( new Person { GivenName = "bob"} );

            var result = await _svc.Get(Guid.NewGuid());

            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
        }
    }
}
using MondoCore.Data;

namespace Rota.Service
{
    public class Person : IIdentifiable<Guid>
    {
        public Guid   Id          { get; set; } = Guid.NewGuid();
        public int    MaritimeId  { get; set; }
        public string GivenName   { get; set; } = "";
        public string Surname     { get; set; } = "";
        public string DOB         { get; set; } = "";
        public string POB         { get; set; } = "";
    }
}

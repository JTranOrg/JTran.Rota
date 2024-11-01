using MondoCore.Data;

namespace Rota.Service
{
    public class Ship : IIdentifiable<Guid>
    {
        public Guid   Id               { get; set; } = Guid.NewGuid();
        public string name             { get; set; } = "";
        public string classname        { get; set; } = "";
        public string registration     { get; set; } = "";
        public double year_built       { get; set; }
        public double length           { get; set; }
        public double width            { get; set; }
        public double height           { get; set; }
        public int    numengines       { get; set; } = 2;
        public double maxwarp          { get; set; } = 9.5;
        public string pod_attachment   { get; set; } = "";
        public int    maxpods          { get; set; } = 20;
    }
}

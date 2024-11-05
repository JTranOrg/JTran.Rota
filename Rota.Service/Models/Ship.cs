using MondoCore.Data;

namespace Rota.Service
{
    public class Ship : IIdentifiable<Guid>
    {
        public Guid   Id               { get; set; } = Guid.NewGuid();
        public string Name             { get; set; } = "";
        public string ClassName        { get; set; } = "";
        public string Registration     { get; set; } = "";
        public double YearBuilt        { get; set; }
        public double Length           { get; set; }
        public double Width            { get; set; }
        public double Height           { get; set; }
        public int    NumEngines       { get; set; } = 2;
        public double MaxWarp          { get; set; } = 9.5;
        public string PodAttachment    { get; set; } = "";
        public int    MaxPods          { get; set; } = 20;
        public string Status           { get; set; } = "In-flight";

        public  List<CrewMember> Crew { get; set; } = new();
    }

    public class CrewMember 
    {
        public string CrewId            { get; set; } = "";
        public string Position          { get; set; } = "";
        public int    PositionWeight    { get; set; }
        public string Started           { get; set; } = "";
    }
}

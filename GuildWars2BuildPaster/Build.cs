using SQLite;


namespace GuildWars2BuildPaster
{
    internal class Build
    {


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Profession { get; set; }
        public string Specialization { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Code} - {Profession} - {Specialization}";
        }
    }
}
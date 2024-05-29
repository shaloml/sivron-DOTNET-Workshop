namespace Configuration.Demo.Settings
{
    public class GeneralSettings
    {
        public SubsectionSettings Subsection { get; set; }
        public string KeyString { get; set; }
        public int KeyInt { get; set; }
        public double KeyDouble { get; set; }
        public bool KeyBool { get; set; }


        public class SubsectionSettings
        {
            public string Suboption1 { get; set; }
            public int Suboption2 { get; set; }
        }
    }
}

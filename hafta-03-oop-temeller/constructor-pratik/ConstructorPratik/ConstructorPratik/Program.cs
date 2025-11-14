namespace Yapicimethod
{
    class Baby
    {
        private string _name;
        private string _surname;
        private string _birthDay;

        public Baby(string name, string surName)
        {
            _name = name;
            _surname = surName;
            _birthDay = DateTime.Today.ToShortDateString();
            Console.WriteLine($"ıngaaaaa {_birthDay} bebek adı:{_name} soy adı:{_surname}");
        }

        public Baby()
        {
            _birthDay = DateTime.Today.ToShortDateString();
            Console.WriteLine($"ıngaaaaa {_birthDay}");
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string BirthDay
        {
            get { return _birthDay; }
            
            private set { _birthDay = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Baby baby = new Baby("Ali", "yılmaz");
            Baby baby2 = new Baby();
            baby2.Name = "Mehmet";
            baby2.Surname = "şeker";
            Console.WriteLine($"bebek adı:{baby2.Name} soy adı:{baby2.Surname}  ");
        }
    }
}
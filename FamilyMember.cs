namespace ConsoleApp1
{
    class FamilyMember
    {
        public string Member;
        public string Name;
        public DateTime BirthDate;
        public Gender Gender;
        public List<FamilyMember> Children1gen;
        public List<FamilyMember> Children2gen;
        public List<FamilyMember> Relatives;

        public FamilyMember(string member, string name, DateTime birthDate, Gender gender)
        {
            Member = member;
            Name = name;
            BirthDate = birthDate;
            Children1gen = new List<FamilyMember>();
            Children2gen = new List<FamilyMember>();
            Relatives = new List<FamilyMember>();
        }
    }


    enum Gender
    {
        Male,
        Female
    }


    class Programm
        {
            static void Main()
            {
                //Added members
                FamilyMember fatherGrandfather = new FamilyMember("Дед","Женя", new DateTime(1940, 1, 1), Gender.Male);
                FamilyMember fatherGrandmother = new FamilyMember("Бабушка","Маша", new DateTime(1945, 5, 10), Gender.Female);
                FamilyMember motherGrandfather = new FamilyMember("Дед", "Николай", new DateTime(1940, 1, 1), Gender.Male);
                FamilyMember motherGrandmother = new FamilyMember("Бабушка", "Марина", new DateTime(1945, 5, 10), Gender.Female);
                FamilyMember father = new FamilyMember("Отец","Миша", new DateTime(1970, 8, 15), Gender.Male);
                FamilyMember mother = new FamilyMember("Мама","Луиза", new DateTime(1975, 2, 20), Gender.Female);
                FamilyMember child1 = new FamilyMember("Сын","Саша", new DateTime(2000, 4, 5), Gender.Male);
                FamilyMember child2 = new FamilyMember("Дочь","Ксюша", new DateTime(2005, 7, 12), Gender.Female);


                //Filling tree
                fatherGrandfather.Children1gen.Add(father);
                fatherGrandmother.Children1gen.Add(father);
                motherGrandfather.Children1gen.Add(mother);
                motherGrandmother.Children1gen.Add(mother);
                father.Children2gen.Add(child1);
                father.Children2gen.Add(child2);
                mother.Children2gen.Add(child1);
                mother.Children2gen.Add(child2);

                //Filling relatives
                father.Relatives.Add(fatherGrandfather);
                father.Relatives.Add(fatherGrandmother);
                mother.Relatives.Add(motherGrandfather);
                mother.Relatives.Add(motherGrandmother);


                Console.WriteLine("Генеалогическое дерево:");
                PrintFamilyTree(fatherGrandmother);
                PrintFamilyRelatives(mother);

        }


        static void PrintFamilyTree(FamilyMember person)
        {
            Console.WriteLine(person.Member + " " + person.Name + " (" + person.BirthDate.ToShortDateString() + ")");

                foreach (var child in person.Children1gen)
                {
                    Console.Write(" | ".PadLeft(5));
                    PrintFamilyTree(child);
            }

                Console.Write(" | ".PadLeft(5));

                foreach (var child2 in person.Children2gen)
                {
                    Console.Write(" | ".PadLeft(5));
                    PrintFamilyTree(child2);
            }
        }
        
        static void PrintFamilyRelatives(FamilyMember person)
        {
            Console.WriteLine(person.Member + " " + person.Name + " (" + person.BirthDate.ToShortDateString() + ")");

                foreach (var relatives in person.Relatives)
                {
                    Console.Write(" | ".PadLeft(5));
                    Console.WriteLine(relatives.Member + " " + relatives.Name + " (" + relatives.BirthDate.ToShortDateString() + ")");
            }

        }


    }
}

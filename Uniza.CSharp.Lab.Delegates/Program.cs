using Uniza.CSharp.Lab.Delegates;

var people = new[]
            {
                new Person("Jana", "Nova", new DateOnly(1991, 1, 2)),
                new Person("Frantisek", "Zeleny", new DateOnly(1995, 1, 1)),
                new Person("Jan", "Testovy", new DateOnly(1989, 12, 24)),
                new Person("Eleonora", "Testova", new DateOnly(1991, 1, 3)),
                new Person("Jozef", "Mrkvicka", new DateOnly(1985, 4, 1)),
            };

var peopleDatabase = new PeopleDatabase(people);

// TODO: Úloha 1.00 - oboznámte sa s metódou WriteToConsole a delegátom Action<Person>, ktorý sa nachádza vo vnútri metódy
peopleDatabase.WriteToConsole();
Console.WriteLine();

peopleDatabase.WriteToConsole(false);
Console.WriteLine();

// TODO: Úloha 1.03 - vypíšte pomocou metódy WriteToConsole(PersonFormatting) osoby naformátované v tvare: prvé písmeno mena, priezvisko a rok narodenia (príklad: "J. Nová (1991)") - použite lambda výraz, ktorý bude argumentom metódy WriteToConsole 
//peopleDatabase.WriteToConsole( ??? );
//Console.WriteLine();

// TODO: Úloha 1.06 - utrieďte osoby podľa dátumu narodenia (p1.Birthdate.CompareTo(p2.Birthdate)) a vypíšte ich na obrazovku
//peopleDatabase.Sort( ??? );
//peopleDatabase.WriteToConsole();
//Console.WriteLine();

// TODO: Úloha 1.07 - utrieďte osoby podľa priezviska (string.Compare(p1.LastName, p2.LastName)) a vypíšte ich na obrazovku
//peopleDatabase.Sort( ??? );
//peopleDatabase.WriteToConsole();
//Console.WriteLine();

// TODO: Úloha 1.09 - odkomentujte nasledujúci kód, ktorý na konzolu vypíše zoznam osôb, ktorých priezvisko začína na reťazec "Test"
//foreach (var person in peopleDatabase.FindByLastName("Test"))
//{
//    Console.WriteLine(person);
//}

// TODO: Úloha 1.11 - odkomentujte nasledujúci kód, ktorý na konzolu vypíše priemerný vek všetkých osôb v databáze
//Console.WriteLine($"\nAverage age: {peopleDatabase.GetAverageAge()}\n");

// TODO: Úloha 1.13 - odkomentujte nasledujúci kód, ktorý na konzolu vypíše zoznam osôb utriedených podľa priezviska zostupne a podľa mena vzostupne
//foreach (var person in peopleDatabase.GetSortedPeopleByName())
//{
//    Console.WriteLine(person);
//}

// TODO: Úloha 1.15 - odkomentujte nasledujúci kód, ktorý na konzolu vypíše zoznam osôb utriedených podľa priezviska zostupne a podľa mena vzostupne
//Console.WriteLine();
//peopleDatabase.GetSortedPeopleByName().ForEach(p => Console.WriteLine(p.FullName));

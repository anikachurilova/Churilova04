using System;
using System.Collections.Generic;
using System.IO;
using Churilova02.Models;
using Churilova02.Tools.Managers;

namespace Churilova02.Tools.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private readonly List<Person> _users;

        internal SerializedDataStorage()
        {
            try
            {
                _users = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _users = new List<Person>();
                string[] names =
                {
                    "Anika",
                    "Adam",
                    "Anatolii",
                    "Anastasia",
                    "Bogdan",
                    "Borys",
                    "Volodymyr",
                    "Vira",
                    "Daria",
                    "Danylo",
                    "Denis",
                    "Eva",
                    "Eugene",
                    "Iryna",
                    "Igor",
                    "Kateryna",
                    "Kostyantyn",
                    "Kyrylo",
                    "Kseniia",
                    "Lilia",
                    "Lubov",
                    "Ludmyla",
                    "Maria",
                    "Mykyta",
                    "Myhailo",
                    "Myroslava",
                    "Nadiia",
                    "Oleksandr",
                    "Olena",
                    "Oleg",
                    "Olga",
                    "Oleksii",
                    "Petro",
                    "Pavlo",
                    "Roman",
                    "Sophiya",
                    "Semen",
                    "Sergii",
                    "Stepan",
                    "Karla",
                    "Stephani",
                    "Sergii",
                    "Tetyana",
                    "Valerie",
                    "Yaroslava",
                    "Anna",
                    "Uliana",
                    "Alina",
                    "Svitlana",
                    "Dmytro"
                };
                string[] surnames =
                {
                    "Zadorozhko",
                    "Vlasenko",
                    "Stepovenko",
                    "Kuzmenko",
                    "Palienko",
                    "Cherepanko",
                    "Petrenko",
                    "Ivanenko",
                    "Olenyn",
                    "Maidachenko",
                    "Skrypnyk",
                    "Redko",
                    "Masenko",
                    "Makarenko",
                    "Ostash",
                    "Booblyk",
                    "Hlybovets",
                    "Getman",
                    "Yermolenko",
                    "Mischenko",
                    "Chernenko",
                    "Romanenko",
                    "Korol",
                    "Shpak",
                    "Kotsukon",
                    "Shvorak",
                    "Zharenko",
                    "Melnyk",
                    "Shevchenko",
                    "Boyko",
                    "Bondarenko",
                    "Oliiynyk",
                    "Polischuk",
                    "Moroz",
                    "Lysenko",
                    "Marchenko",
                    "Klymenko",
                    "Pudenko",
                    "Gavryliuk",
                    "Khomenko",
                    "Karpenko",
                    "Didenko",
                    "Kushnyr",
                    "Sydorenko",
                    "Panchenko",
                    "Humeniuk",
                    "Kovtun",
                    "Pryhodko",
                    "Ischenko",
                    "Yatsenko"
                };
                string[] mails =
                {
                  
                    "zadorozhko",
                    "vlasenko",
                    "stepovenko",
                    "kuzmenko",
                    "palienko",
                    "cherepanko",
                    "petrenko",
                    "ivanenko",
                    "olenyn",
                    "maidachenko",
                    "skrypnyk",
                    "redko",
                    "masenko",
                    "makarenko",
                    "ostash",
                    "booblyk",
                    "hlybovets",
                    "hetman",
                    "yermolenko",
                    "mischenko",
                    "chernenko",
                    "romanenko",
                    "korol",
                    "shpak",
                    "kotsukon",
                    "shvorak",
                    "zharenko",
                    "melnyk",
                    "shevchenko",
                    "boiko",
                    "bondarenko",
                    "oliinyk",
                    "polischuk",
                    "moroz",
                    "lysenko",
                    "marchenko",
                    "klymenko",
                    "rudenko",
                    "gavryliuk",
                    "khomenko",
                    "karpenko",
                    "didenko",
                    "kushnir",
                    "sydorenko",
                    "panchenko",
                    "humeniuk",
                    "kovtun",
                    "pryhodko",
                    "ischenko",
                    "iatsenko"
                };
                Random random = new Random();
                for (int i = 0; i < 50; ++i)
                {
                    Person person = new Person(names[i], surnames[i], mails[i] + "@gmail.com");
                    _users.Add(person);
                }

                SaveChanges();
            }
        }



        public void Add(Person person)
        {
            _users.Add(person);
            SaveChanges();
        }

        public void Remove(Person person)
        {
            _users.Remove(person);
            SaveChanges();
        }

        public void DoChanges()
        {
            SaveChanges();
        }

        public List<Person> PersonsList
        {
            get { return _users; }
        }

        private void SaveChanges()
        {
            SerializationManager.Serialize(_users, FileFolderHelper.StorageFilePath);
        }
    }
}

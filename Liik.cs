using System;
using System.Collections.Generic;

namespace Grupp_ja_liikmed
{
    class Liik
    {
        public string Name { get; }
        public int Age { get; }

        public Liik(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}

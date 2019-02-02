using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public class PadelDb
    {
        public static List<Bro> GetBros()
        {
            using (var context = new PadelContext())
                 return context.Bros.ToList();
        }

        public static void AddBro(string name)
        {
            using (var context = new PadelContext())
                context.Add(new Bro { Name = name });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RybyWPFMVVM.Model
{
    class Czas
    {
        string[] poryRoku = new string[] {"wczesna wiosna", "wiosna", "pozna wiosna", "wczesne latp", "lato", "pozne lato",
                                            "wczesna jesien", "jesien", "pozna jesien", "wczesna zima", "zima", "pozna zima"};
        static string[] poryDnia = new string[] { "swit", "wczesny ranek", "ranek", "poludnie", "popoludnie", "wieczor", "pozny wieczor", "noc","polnoc"};

        public static string[] PoryDnia
                { get; set; }
        public string[] PoryRoku
                { get; set; }

    }
}

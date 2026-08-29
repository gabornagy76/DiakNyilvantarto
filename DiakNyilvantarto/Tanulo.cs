using System;
using System.Collections.Generic;
using System.Text;

namespace DiakNyilvantarto
{
    public class Tanulo
    {
        public string Nev {  get; set; } = string.Empty;

        public int Eletkor { get; set; }

        public string Osztaly { get; set; } = string.Empty;

        public double Atlag {  get; set; }

        public string Megjegyzes {  get; set; } = string.Empty;

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Megjegyzes))
            {
                return $"{Nev} - {Eletkor} év - {Osztaly} - átlag: {Atlag:F2}";
            }

            return $"{Nev} - {Eletkor} év - {Osztaly} - átlag: {Atlag:F2} - Megjegyzés: {Megjegyzes}";
        }
    }
}

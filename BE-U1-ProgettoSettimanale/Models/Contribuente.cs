using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_U1_ProgettoSettimanale.Models
{
    public class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataDiNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public char Sesso { get; set; }
        public string ComuneDiResidenza { get; set; }
        public decimal Ral {  get; set; }

    public Contribuente (string nome, string cognome, DateTime datadinascita, string codicefiscale, char sesso, string comunediresidenza, decimal ral)
        {
            Nome = nome;
            Cognome = cognome;
            DataDiNascita = datadinascita;
            CodiceFiscale = codicefiscale;
            Sesso = sesso;
            ComuneDiResidenza = comunediresidenza;
            Ral = ral;
        }
        public decimal CalcoloImposta()
        {
            decimal imposta = 0;

            switch (Ral)
            {
                case <= 15000:
                    imposta = Ral * 0.23m;
                    break;
                case <= 28000:
                    imposta = 3450 + (Ral - 15000) * 0.27m;
                    break;
                case <= 55000:
                    imposta = 6960 + (Ral - 28000) * 0.38m;
                    break;
                case <= 75000:
                    imposta = 17220 + (Ral - 55000) * 0.41m;
                    break;
                default:
                    imposta = 25420 + (Ral - 75000) * 0.43m;
                    break;
            }

            return imposta;
        }
        public override string ToString()
        {
            return $"Dati del contribuente:\n" +
                   $"Contribuente: {Nome} {Cognome},\n" +
                   $"Nato il {DataDiNascita:dd/MM/yyyy} ({Sesso}),\n" +
                   $"Residente a {ComuneDiResidenza},\n" +
                   $"Codice fiscale: {CodiceFiscale}\n\n" +
                   $"Reddito dichiarato: {Ral.ToString("N2")}\n" +
                   $"IMPOSTA DA VERSARE: Euro {CalcoloImposta().ToString("N2")}";

        }

    }

}

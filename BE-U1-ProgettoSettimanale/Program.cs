using System.Globalization;
using BE_U1_ProgettoSettimanale.Models;

while (true)
{
    Console.Clear();
    Console.WriteLine("==================================================");
    Console.WriteLine("BENVENUTO NEL CALCOLATORE D'IMPOSTA");
    Console.WriteLine("==================================================\n");
    Console.WriteLine("Inserisci i dati del contribuente per calcolare l'imposta da versare:\n");

    Console.Write("Inserisci il nome del Contribuente: ");
    string nome;
    do
    {
        nome = Console.ReadLine();

             if (string.IsNullOrWhiteSpace(nome) || nome.Length <= 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Il nome deve contenere almeno 3 caratteri!");
            Console.ResetColor();
            Console.Write("Inserisci il nome del Contribuente: ");
        }
        
        else if (!ContainsOnlyLetters(nome))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Il nome può contenere solo lettere (A-Z, a-z).");
            Console.ResetColor();
            Console.Write("Inserisci il nome del Contribuente: ");
        }

    } while (string.IsNullOrWhiteSpace(nome) || nome.Length <= 2 || !ContainsOnlyLetters(nome));

       
    static bool ContainsOnlyLetters(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLetter(c))  
            {
                return false;  
            }
        }

        return true;  
    }

    Console.Write("Inserisci il cognome del Contribuente: ");
    string cognome;
    do
    {        
        cognome = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(cognome) || cognome.Length <= 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Inserisci un cognome valido che abbia 2 o più caratteri!");
            Console.ResetColor();
            Console.Write("Inserisci il cognome del Contribuente: ");
        } else if (!ContainsOnlyLetters(cognome))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Il cognome può contenere solo lettere(A - Z, a - z).");
            Console.ResetColor();
            Console.Write("Inserisci il cognome del Contribuente: ");
        }

    }while (string.IsNullOrWhiteSpace(cognome) || cognome.Length <= 1 || !ContainsOnlyLetters(cognome));

    DateTime dataDiNascita;
    while (true)
    {
        Console.Write("Inserisci la tua data di nascita del Contribuente (gg-mm-yyyy): ");
        if (DateTime.TryParse(Console.ReadLine(), out dataDiNascita) && dataDiNascita.Year >= 1900)
        {
            break;
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Data non valida! Assicurati che sia in formato corretto (gg-mm-yyyy) e che l'anno sia dal 1900 in poi.");
        Console.ResetColor();
    }

    char sesso;

    while (true)
    {
        Console.Write("Inserisci il sesso del Contribuente (M/F): ");
        if (char.TryParse(Console.ReadLine().ToUpper(), out sesso) && (sesso == 'M' || sesso == 'F'))
        {
            break;
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Sesso non valido, inserire M o F.");
        Console.ResetColor();
    }

    Console.Write("Inserisci il codice fiscale del Contribuente: ");
    string codiceFiscale;
    do
    {
        
        codiceFiscale = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(codiceFiscale) || codiceFiscale.Length != 16 || !char.IsLetter(codiceFiscale[15]))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Errore! Il codice fiscale deve essere di 16 caratteri e terminare con una lettera (A-Z).");
            Console.ResetColor();
            Console.Write("Inserisci il codice fiscale del Contribuente: ");
        }

    } while (string.IsNullOrWhiteSpace(codiceFiscale) || codiceFiscale.Length != 16 || !char.IsLetter(codiceFiscale[15]));

    Console.Write("Inserisci il comune di residenza del Contribuente: ");
    string comuneResidenza;
    do
    {
        comuneResidenza = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(comuneResidenza) || comuneResidenza.Length <= 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Inserire un comune di residenza che abbia 2 o più caratteri!");
            Console.ResetColor();
            Console.Write("Inserisci il comune di residenza del Contribuente: ");
        }
    } while (string.IsNullOrWhiteSpace(comuneResidenza) || comuneResidenza.Length <= 1);

    decimal ral;

    while (true)
    {
        Console.Write("Inserisci il reddito annuale del Contribuente (i centesimi separati da una virgola): ");
        if (decimal.TryParse(Console.ReadLine(), out ral) && ral > 0)
        {
            break;
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Reddito non valido, riprova.");
        Console.ResetColor();
    }

    Contribuente contribuente = new Contribuente(nome, cognome, dataDiNascita, codiceFiscale, sesso, comuneResidenza, ral);

    Console.WriteLine("==================================================");
    Console.WriteLine("\nCALCOLO DELL'IMPOSTA DA VERSARE:\n");
    Console.WriteLine(contribuente);

    Console.WriteLine("\n==================================================");
    Console.Write("\nVuoi effettuare un nuovo calcolo? (S/N): ");
    string risposta = Console.ReadLine().ToUpper();
    switch (risposta)
    {
        case "S":
            continue;
        case "N":
            Console.WriteLine("Grazie per averci scelto!");
            return;
        default:
            Console.WriteLine("Scelta non valida");
            continue;

    }

}
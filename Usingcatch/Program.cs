//using System.Text.RegularExpressions;
//Moyenne();
//void Moyenne()
//{
//    do
//    {
//        Console.WriteLine("tapez une série de nombre ex : 18, 42, 85, 59 ou 'q' pour quitter");
//        string split = Console.ReadLine();
//        split = Regex.Replace(split, @" ", "");
//        if (split == "q")
//        {
//            Console.WriteLine("Merci pour votre passage a bientôt !");
//            return; // fermer le programme
//        }

//        string[] tableau = split.Split(",");
//        int total = 0;
//        float moyenne;

//        foreach (var item in tableau)
//        {
//            try
//            {
//                total += Int32.Parse(item);
//            }
//            catch (FormatException)
//            {
//                Console.WriteLine("Erreur veuillez taper uniquement des chiffres et ne pas finir avec une virgule");

//            }
//            catch (OverflowException)
//            {
//                Console.WriteLine("Erreur nombre trop grand pas plus de 100.000 thanks.");
//                continue;
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("Erreur inconnue, veuillez téléphoner au Help Desk");
//                Console.WriteLine($"Le message est : {e.Message}");
//                Console.WriteLine("Veuillez taper enter pour continuer");
//                Console.Read();
//                continue;
//            }
//        }

//        moyenne = (float)total / tableau.Length;


//        Console.WriteLine($"Votre moyenne est de : {moyenne}");
//        Console.WriteLine($"Vous avez tappez {tableau.Length} nombres");
//    } while (true);
//}

using System.Text.RegularExpressions;
using System.Text;

StringBuilder sb = new StringBuilder();

Console.WriteLine("Veuillez rentrez des nombres séparés par des virgules, ex: 5,18,25,60");
string[] chaineNombre = Regex.Replace(Console.ReadLine(), @" ", "").Split(",");
bool isCatched = false;
float total;

while (chaineNombre[0] != "q")
{
    total = 0;

    try
    {
        foreach (var item in chaineNombre)
        {
            total += Int32.Parse(item);
        }
    }
    catch (FormatException ex)
    {
        sb = new StringBuilder("Format incorrect, veuillez tapez à nouveau ou tapez q pour quitter.");
        isCatched = true;
    }
    catch (OverflowException ex)
    {
        sb = new StringBuilder("It's over nine thousand !!!!, veuillez tapez à nouveau ou tapez q pour quitter.");
        isCatched = true;
    }
    catch (Exception ex)
    {
        sb = new StringBuilder($"{ex.Message} , veuillez tapez à nouveau ou tapez q pour quitter.");
        isCatched = true;
    }

    if (!isCatched)
    {
        Console.WriteLine($"Voici la moyenne de la liste [{string.Join(",", chaineNombre)}] : {total / chaineNombre.Length}");
        Console.WriteLine("Encore ? Sinon tapez q pour quitter");
        chaineNombre = Regex.Replace(Console.ReadLine(), @" ", "").Split(",");
    }
    else
    {
        Console.WriteLine(sb.ToString());
        sb.Clear();
        isCatched = false;
        chaineNombre = Regex.Replace(Console.ReadLine(), @" ", "").Split(",");
    }
}
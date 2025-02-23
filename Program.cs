using System;
using System.IO;
namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();

            Console.WriteLine("Password Generator : ");
            System.Console.WriteLine("Veuillez saisir la longueur du mot de passe souhaité :");

            int pass_length = pwd_lenght();
            string a = GenPassword(pass_length);
            SuccesMessage();
            WriteCentered($"Votre mot de passe est : {a}");
            WritePassInTXT(a,"password.txt");
            Console.ResetColor();
        }

        static int pwd_lenght(){
            int lenght = 0;
            while(lenght<1){
                
                try{
                string user_lenght = Console.ReadLine();
                
                lenght = int.Parse(user_lenght);

                if(lenght<0){
                    System.Console.WriteLine("La longueur du mot de passe ne peut pas être négative...");
                }
                if(lenght==0){
                    System.Console.WriteLine("La longueur du mot de passe ne peut pas être égale à 0 ...");
                }
                }
                catch{
                    ErrorMessage();
                    Console.Write("erreur, merci de rentrer un nombre entier ");
                    Console.ResetColor();
                    Console.WriteLine("");

                }
            
            }
            return lenght;
        }

    static void WritePassInTXT(string pwd, string filePath)
    {
        // Utilise File.WriteAllText pour écrire une seule chaîne de caractères dans le fichier
        File.WriteAllText(filePath, pwd);
    }        static void Menu(){
            string menu = @"
    0000             0000        7777777777777777/========___________
   00000000         00000000      7777^^^^^^^7777/ || ||   ___________
  000    000       000    000     777       7777/=========//
 000      000     000      000             7777// ((     //
0000      0000   0000      0000           7777//   \\   //
0000      0000   0000      0000          7777//========//
0000      0000   0000      0000         7777
0000      0000   0000      0000        7777
 000      000     000      000        7777
  000    000       000    000       77777
   00000000         00000000       7777777
     0000             0000        777777777
            
            
            ";
            System.Console.Write(menu);
        }
        static string GenPassword(int lenght){
            int i = 0;
            string[] letters = {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
            "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
            "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_",
            "=", "+", "[", "]", "{", "}", "|", ";", ":", "'", "\"", ",", ".", "<", ">", "/", "?"
        };

            List<string> pwd = new List<string>();
            Random random = new Random();

            while(i<lenght){
                int indice_random = random.Next(0,letters.Length);
                string random_character = letters[indice_random];
                pwd.Add(random_character);
                i+=1;
            }

            string str_password = string.Join("", pwd);

            return str_password;
        }
        // Couleur des messages affichés dans le terminal // // mettre un console.resetcolor() à chaque fois ! // 
        static void ErrorMessage(){
            Console.ForegroundColor = ConsoleColor.Red;
            
        }
        static void SuccesMessage(){
            Console.ForegroundColor = ConsoleColor.Green;
            
        }
        static void WarningMessage(){
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            
        }

        static void WriteCentered(string text){
        // Obtenir la largeur de la console
        int windowWidth = Console.WindowWidth;

        // Calculer la position de départ pour centrer le texte
        int textLength = text.Length;
        int spacesBeforeText = (windowWidth - textLength) / 2;

        // Assurer que les espaces ne sont pas négatifs
        if (spacesBeforeText < 0)
        {
            spacesBeforeText = 0;
        }

        // Créer une chaîne avec les espaces nécessaires
        string padding = new string(' ', spacesBeforeText);

        // Afficher le texte avec les espaces devant
        Console.WriteLine(padding + text);
    }

    }
}
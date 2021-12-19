using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace N_Club_Pakkelegs_Assistent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "N-Club - Pakkelegs-assistent v1.1";
            int desiredOccurences = 0;
            AssistantController assistantController;

            Console.Write("Brugernavn: ");
            string username = Console.ReadLine();

            while(desiredOccurences == 0)
            {
                Console.Write("Antal ønskede gaver: ");
                string userinput = Console.ReadLine();
                if (!userinput.Contains("-") && !userinput.Contains("0"))
                {
                    int.TryParse(userinput, out desiredOccurences);
                    if (desiredOccurences == 0)
                        Console.WriteLine("Ugyldigt input...\n");
                }
                else
                    Console.WriteLine("Ugyldigt input...\n");
            }

            Console.Clear();


            assistantController = new AssistantController(username, desiredOccurences);

            while (true)
            {
                Console.WriteLine(assistantController.GetCurrentStatus());

                if (assistantController.GeneralMessage != "")
                {
                    assistantController.UpdateTextColour(-1);
                    Console.WriteLine(assistantController.GeneralMessage);
                    assistantController.NotifyUser(2);
                    assistantController.ClearGeneralMessage();
                }
                else if (assistantController.UserGifts < assistantController.DesiredGifts)
                {
                    assistantController.NotifyUser(1);
                    
                }

                Thread.Sleep(60000);
            }
        }
    }
}

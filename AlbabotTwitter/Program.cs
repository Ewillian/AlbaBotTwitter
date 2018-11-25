using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace AlbabotTwitter
{
    class Program
    {

        static void Main(string[] args)
        {
            Auth.SetUserCredentials("lMaG58UfxHCxyHsBsUTxu8Vax", "bGlCo0fbGT35gDahju3AXw0Zzk2ibIf60NgFzbP8snMrL0qC8Y", "999557557285982208-5niNCKrMeYF4AMLxKrADRDHhaX9Fbt4", "6ifWjuQIdNjhXKQMGDvTDEA0P8e1dxaMayEZs5BGfq9x6");
            var user = User.GetAuthenticatedUser();
            Console.WriteLine("Veuillez saisir une phrase et valider avec la touche \"Entrée\"");
            string saisie = Console.ReadLine();
            Console.WriteLine("Vous avez saisi : " + saisie + "\r\n");
            Console.WriteLine("Le programme se ferme dans 5 secondes");
            System.Threading.Thread.Sleep(5000);
        }

        // Function Publish tweetcontent on Twitter
        public static void plublishTweet(string tweetcontent)
        {
            var tweet = Tweet.PublishTweet(tweetcontent);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Tweet published !");
            Console.WriteLine("");
            Console.ResetColor();
        }

        //Function print in console the user timeline
        public static void userTimeline(IUserIdentifier myuser)
        {
            var timelinetweets = Timeline.GetUserTimeline(myuser, 5);

            foreach (var timeline in timelinetweets)
            {
                Console.WriteLine(myuser.ScreenName + "'s timeline:");
                Console.WriteLine(timeline);
                Console.WriteLine("");
            }
        }
    }
}

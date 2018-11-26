using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace AlbabotTwitter
{
    class Program
    {

        static void Main(string[] args)
        {
            // List of Keywords
            List<string> keywordlist = new List<string>();
            keywordlist.Add("Concours");

            //Twitter Apps Keys
            Auth.SetUserCredentials("lMaG58UfxHCxyHsBsUTxu8Vax", "bGlCo0fbGT35gDahju3AXw0Zzk2ibIf60NgFzbP8snMrL0qC8Y", "999557557285982208-5niNCKrMeYF4AMLxKrADRDHhaX9Fbt4", "6ifWjuQIdNjhXKQMGDvTDEA0P8e1dxaMayEZs5BGfq9x6");
            var user = User.GetAuthenticatedUser();
            userTimeline(user);

            foreach (string key in keywordlist)
            {
                var searchParameter = new SearchTweetsParameters(key)
                {
                    Lang = LanguageFilter.French,
                    SearchType = SearchResultType.Popular,
                    MaximumNumberOfResults = 1,
                    Until = new DateTime(2018, 11, 26),
                };

                var tweets = Search.SearchTweets(searchParameter);
                Console.WriteLine(tweets);
            }

            Console.Write("Le programme se ferme dans 5 secondes");
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
            Console.Write(".");
            System.Threading.Thread.Sleep(3000);
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(myuser.ScreenName + "'s timeline:");
                Console.WriteLine(timeline);
            }
        }

        //Function follow with UserScreenName
        public static void followUser(string targetuser)
        {
            User.FollowUser(targetuser);
        }
    }
}

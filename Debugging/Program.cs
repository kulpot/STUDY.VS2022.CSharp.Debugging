using System.Collections.Generic;

namespace Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            var friends = new List<string> { "Frank", "Joe", "Michelle", "Andy", "Maria", "Carlos", "Angelina" };
            //var partyFriends = GetPartyFriend(friends, 3);

            /////DEFENSIVE DEBUGGINE---------------------- ex. for database
           
            /*
            var friends = new List<string>();
            var partyFriends = GetPartyFriend(null, 3);//null reference exception
            */
            /*catch exception here earlier example
            if(friends.Count < 10)*/
            var partyFriends = GetPartyFriend(friends, 10); //excemtion unhandled ---outofrange
            //var partyFriends = GetPartyFriend(friends, -1); //no bug but no valueble info

            //foreach (var name in partyFriends)
            /* foreach (var name in friends) //checking the list of friends
                 Console.WriteLine(name);*/

            foreach (var name in partyFriends) // checks the list of partyFriends
                Console.WriteLine(name);
        }

        public static List<string> GetPartyFriend(List<string> list, int count)
        {
            
            //check list (DEFENSIVE DEBUG)

            //Catch Exception - means to prevent change in database in the program and not cause problems
            //catching null reference exception
            /*if(list == null)
                throw new ArgumentNullException("list", "The list is empty");
            */
            //if(count > list.Count)
           // if (count > list.Count || count <=0)//for -1 bug
                //ex. //print("Dont do that");

                //catching exception
               // throw new ArgumentOutOfRangeException("count", "Count cannot be greater than elements in the list");
            
            //for -1 bug catch exception
               // throw new ArgumentOutOfRangeException("count", "Count cannot be greater than elements in the list or lower 0");
            


            var buffer = new List<string>(list);//new list for list.Remove(currentFriend);
            var partyFriends = new List<string>();

            while(partyFriends.Count < count)
            {
                //var currentFriend = GetPartyFriend(list);
                var currentFriend = GetPartyFriend(buffer);//to get the GetPartyFriend
                partyFriends.Add(currentFriend);
                buffer.Remove(currentFriend);
                //list.Remove(currentFriend); //Bug--beginner bug
            }
            return partyFriends;
        }

        /// <summary>
        /// This is the logic to figure out who is a party friends
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        // the algorithm which decides who is invited/not invited
        public static string GetPartyFriend(List<string> list)
        {
            string shortestName = list[0]; //outofrange exception --use callstack
            for(var i = 0; i<list.Count; i++)
            {
                //logical bug --- longest name
                //if (list[i].Length > shortestName.Length)
                if (list[i].Length < shortestName.Length)
                {
                    shortestName = list[i];
                }
            }
            return shortestName;
        }
    }
}
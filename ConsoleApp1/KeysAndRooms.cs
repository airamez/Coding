using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    /// <summary>
    /// There are N rooms and you start at room 0. Each room has a distinct number in 0, 1, 2, ... N - 1.
    /// Each room may have a list of keys to access others rooms.
    /// Only the room 0 is unlocked.
    /// Check if it is possible to open all rooms
    /// </summary>
    public class KeysAndRooms
    {
        public static void Main (string[] args)
        {
            List<List<int>> rooms = GenerateRooms();
            Console.Write(CanVisitAllRooms(rooms));
        }

        public static bool CanVisitAllRooms(List<List<int>> rooms)
        {
            bool[] visited = new bool[rooms.Count];
            visited[0] = true;
            Queue<int> toVisit = new Queue<int>();
            foreach (int key in rooms[0])
                toVisit.Enqueue(key);
            while (toVisit.Count != 0) {
                int key = toVisit.Dequeue();
                visited[key] = true;
                foreach (int newKey in rooms[key]) {
                    if (!visited[newKey]) {
                        toVisit.Enqueue(newKey);
                    }
                }
            }
            foreach(bool v in visited) {
                if (!v)
                    return false;
            }
            return true;
        }

        private static List<List<int>> GenerateRooms()
        {
            List<List<int>> rooms = new List<List<int>>();
            List<int> room = new List<int>();

            // Room 0
            room.AddRange(new int[] { 2, 4, 5 });
            rooms.Add(room);

            // Room 1
            rooms.Add(new List<int>());

            // Room 2
            room = new List<int>();
            room.Add(1);
            rooms.Add(room);

            // Room 3
            rooms.Add(new List<int>());

            // Room 4
            room = new List<int>();
            room.Add(3);
            rooms.Add(room);

            // Room 5
            room = new List<int>();
            room.AddRange(new int[] { 3, 6 });
            rooms.Add(room);

            // Room 6
            room = new List<int>();
            room.Add(4);
            rooms.Add(room);
            return rooms;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPE_361_Final_Project
{
    public class Room
    {
        // creates room object to hold which doors are where for the room
        public int TopDoor { get; set; }
        public int BottomDoor { get; set; }
        public int LeftDoor { get; set; }
        public int RightDoor { get; set; }
        public int RoomNumber { get; set; }

        public Room()
        {

        }

        public Room(int roomNumber, int leftDoor, int topDoor, int rightDoor, int bottomDoor)
        {
            RoomNumber = roomNumber;
            TopDoor = topDoor;
            BottomDoor = bottomDoor;
            LeftDoor = leftDoor;
            RightDoor = rightDoor;
        }
    }
}

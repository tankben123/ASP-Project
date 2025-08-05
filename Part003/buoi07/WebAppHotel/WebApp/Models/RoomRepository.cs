using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class RoomRepository:BaseRepository
    {
        public RoomRepository(StoreContext context) : base(context)
        {
        }
        public  IEnumerable<Room> GetAllRooms()
        {
            return  _context.Rooms.ToList();
        }
        public  Room? GetRoom(int roomId)
        {
            return  _context.Rooms.FirstOrDefault(r => r.RoomId == roomId);
        }


    }
}

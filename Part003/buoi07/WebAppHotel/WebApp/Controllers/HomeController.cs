using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public RoomRepository _roomRepository;
        public ReservationRepository _reservationRepository;
        public TransitionRepository _transitionRepository;

        public HomeController(StoreContext context)
        {
            _roomRepository = new RoomRepository(context);
            _reservationRepository = new ReservationRepository(context);
            _transitionRepository = new TransitionRepository(context);
        }

        public IActionResult Index()
        {
            return View(_roomRepository.GetAllRooms());
        }

        public IActionResult Details(int id)
        {
            var room = _roomRepository.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            room.Reservations = _reservationRepository.GetReservations(id);

            foreach (var item in room.Reservations)
            {
                if (item.State != null)
                {
                    item.State.Transitions = _transitionRepository.GetTransitions(item.StateId);
                }
            }
            return View(room);
        }


        [Route("/home/state/{id}/{stateId}")]
        public IActionResult State(int id, int stateId)
        {
            Reservation? reservation = _reservationRepository.GetReservation(id);
            if (reservation == null)
            {
                return NotFound();
            }

            reservation.StateId = stateId;
            int ret = _reservationRepository.Edit(reservation);
            if (ret > 0)
            {
                return Redirect($"/home/details/{reservation.RoomId}");
            }

            return View(reservation);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeIOT.Models;

namespace HomeIOT.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Home _demoHome;
    public HomeController(ILogger<HomeController> logger, Home demoHome)
    {
        _logger = logger;
        _demoHome = demoHome;
    }

    public IActionResult GetHomeStatus()
    {

        List<string> status = _demoHome.GetStatus();
        return Json(status);
    }

    public IActionResult GetTemperatures()
    {
        List<string> temperatures = _demoHome.GetAllRoomTemperatures();
        return Json(temperatures);
    }

    public IActionResult GetRooms()
    {
        List<string> rooms = new();
        foreach (Room r in _demoHome.Rooms)
        {
            rooms.Add(r.Name);
        }
        return Json(rooms);

    }

     public IActionResult GetDoors()
    {
        List<string> doors = new();
        foreach (Door d in _demoHome.Doors)
        {
            doors.Add(d.Name);
        }
        return Json(doors);

    }

     public IActionResult GetHeaters()
    {
        List<string> heaters = _demoHome.GetAllHeaters();

        return Json(heaters);

    }

    public IActionResult GetRoomsWOHeater()
    {
        List<string> rooms = new();
        foreach (Room r in _demoHome.Rooms)
        {
            if (r.Heater == null)
                rooms.Add(r.Name);
        }
        return Json(rooms);
    }

    public IActionResult GetHome()
    {
        return Json(_demoHome);
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

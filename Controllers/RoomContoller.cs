using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeIOT.Models;

namespace HomeIOT.Controllers;

public class RoomController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Home _demoHome;
    public RoomController(ILogger<HomeController> logger, Home demoHome)
    {
        _logger = logger;
        _demoHome = demoHome;
    }
    
    [HttpPost]
    public IActionResult AddRoom(string roomName)
    {
        Room newRoom = new(roomName, _demoHome);
        var status = _demoHome.GetStatus();
        return Json(status);
    }

    public IActionResult RemoveRoom(string roomName)
    {
        Room room = _demoHome.Rooms.Find(r => r.Name == roomName);
        _demoHome.Rooms.Remove(room);
        var status = _demoHome.GetStatus();
        return Json(status);
    }

    public IActionResult GetLights(string roomName)
    {
        Room room = _demoHome.Rooms.Find(r => r.Name == roomName);
        var lights = room.Lights;
        return Json(lights);
    }

    public IActionResult GetAppliences(string roomName)
    {
        Room room = _demoHome.Rooms.Find(r => r.Name == roomName);
        var appliences = room.Appliences;
        return Json(appliences);
    }

    public IActionResult GetBlinds(string roomName)
    {
        Room room = _demoHome.Rooms.Find(r => r.Name == roomName);
        var blinds = room.Blinds;
        return Json(blinds);
    }

    public IActionResult GetHeater(string roomName)
    {
        Room room = _demoHome.Rooms.Find(r => r.Name == roomName);
        var heater = room.Heater;
        return Json(heater);
    }


}
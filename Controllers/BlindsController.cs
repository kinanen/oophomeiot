using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeIOT.Models;

namespace HomeIOT.Controllers;

public class BlindsController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Home _demoHome;
    public BlindsController(ILogger<HomeController> logger, Home demoHome)
    {
        _logger = logger;
        _demoHome = demoHome;
    }
    
    [HttpPost]
    public IActionResult AddBlinds(string roomName,string windowName)
    {
        Blinds newBlinds;
        Room room = _demoHome.Rooms.Find(r => r.Name == roomName);
        newBlinds = new Blinds(room, windowName);
        var status = _demoHome.GetStatus();
        return Json(status);
    }

    [HttpPost]
    public IActionResult Open(string roomName, string windowName)
    {
        Room room = _demoHome.Rooms.Find(r => r.Name == roomName);
        room.Blinds.Find(b => b.Window == windowName).Open();
        var status = _demoHome.GetStatus();
        return Json(status);
    }

    [HttpPost]
    public IActionResult Close(string roomName, string windowName)
    {
        Room room = _demoHome.Rooms.Find(r => r.Name == roomName);
        room.Blinds.Find(b => b.Window == windowName).Close();
        var status = _demoHome.GetStatus();
        return Json(status);
    }

    [HttpPost]
    public IActionResult SetPrecent(string roomName, string windowName, int precentage)
    {
        Room room = _demoHome.Rooms.Find(r => r.Name == roomName);
        room.Blinds.Find(b => b.Window == windowName).SetBlinds(precentage);
        var status = _demoHome.GetStatus();
        return Json(status);
    }


}
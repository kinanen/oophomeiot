using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeIOT.Models;

namespace HomeIOT.Controllers;

public class DoorController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Home _demoHome;

    public DoorController(ILogger<HomeController> logger, Home demoHome)
    {
        _logger = logger;
        _demoHome = demoHome;
    }

    [HttpPost]
    public IActionResult AddDoor(string doorName)
    {
        Door newDoor = new(doorName, _demoHome);
        var status = _demoHome.GetStatus();
        return Json(status);
    }

    [HttpPost]
    public IActionResult LockDoor(string doorName)
    {
        Door door = _demoHome.Doors.Find(r => r.Name == doorName);
        door.Lock();
        var status = _demoHome.GetStatus();
        return Json(status);
    }

    [HttpPost]
    public IActionResult UnlockDoor(string doorName)
    {
        Door door = _demoHome.Doors.Find(r => r.Name == doorName);
        door.Unlock();
        var status = _demoHome.GetStatus();
        return Json(status);
    }


}
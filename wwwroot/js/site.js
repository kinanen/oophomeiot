// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

fetch('/Home/GetHomeStatus')
    .then(response => response.json())
    .then(data => {
        const statusElement = document.getElementById('status');
        statusElement.innerHTML = data.join('<br>');
    });

fetch('/Home/GetTemperatures')
    .then(response => response.json())
    .then(data => {
        const statusElement = document.getElementById('temperature');
        statusElement.innerHTML = data.join('<br>');
    });

document.getElementById('addSelected').addEventListener('click', addSelected);

function addForm(selectedValue) {
    var form = document.getElementById('new');

    switch (selectedValue) {
        case 'room': addRoom();
            break;
        case 'applience': addAppliance();
            break;
        case 'door': addDoor();
            break;
        case 'heater':
            form.innerHTML += '<select name="heaterName"><option value="heater1">Heater 1</option><option value="heater2">Heater 2</option></select>';
            break;
        case 'light':
            form.innerHTML += '<input type="select" name="lightName" placeholder="Room">';
            break;
        case 'blinds':
            form.innerHTML += '<input type="select" name="Room" placeholder="Room">';
            break;
    }
}

function addSelected() {
    event.preventDefault();
    var selectElement = document.getElementById('class-select');
    var selectedValue = selectElement.value;
    addForm(selectedValue);
}

function addRoom() {
    var form = document.getElementById('new');

    form.innerHTML += '<input type="text" name="roomName" placeholder="Room Name">';
    form.innerHTML += '<button id="addRoom">submit</button>';
    form.innerHTML += '<button id="cancel">cancel</button>';

    document.getElementById('addRoom').addEventListener('click', () => {
        event.preventDefault();
        var form = document.getElementById('new');
        var roomName = form.roomName.value;
        var url = '/Home/AddRoom?roomName=' + roomName;
        var newRoom = {
            Name: roomName
        };

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(newRoom),
        })
            .then(response => response.json())
            .then(data => {
                const statusElement = document.getElementById('status');
                statusElement.innerHTML = data.join('<br>');
                form.innerHTML = '';
            });
    })

    document.getElementById('cancel').addEventListener('click', () => {
        event.preventDefault();
        form.innerHTML = '';
    });
}

async function addAppliance() {
    var form = document.getElementById('new');
    
    var rooms;

    await fetch('/Home/GetRooms')
    .then(response => response.json())
    .then(data => {
        rooms = data;
    });
    form.innerHTML += '<select name="roomSelect" id="roomSelect">';
    var roomSelect = document.getElementById('roomSelect');
    rooms.forEach(function(room) {
        roomSelect.innerHTML += '<option value="' + room + '">' + room + '</option>';
    })
    roomSelect.innerHTML += '<option value="HouseAppliance">Portable Device</option>';
    form.innerHTML += '<br/>';

    form.innerHTML += '<select name="applianceType" id="applianceType">';
    var appTypeSelect = document.getElementById('applianceType');
    appTypeSelect.innerHTML += '<option value="appliance">Appliance</option>';
    appTypeSelect.innerHTML += '<option value="kitchen">Kitchen Appliance</option>';
    appTypeSelect.innerHTML += '<option value="cold">Cold Appliance</option>';
    form.innerHTML += '<br/>';

    form.innerHTML += '<input type="text" name="ApplianceName" placeholder="Appliance name">';
    form.innerHTML += '<br/>';

    form.innerHTML += '<button id="addAppliance">submit</button>';
    form.innerHTML += '<button id="cancel">cancel</button>';

    document.getElementById('addAppliance').addEventListener('click', () => {
        event.preventDefault();
        var form = document.getElementById('new');
        var roomName = form.roomSelect.value;
        var applianceType = form.applianceType.value;
        var applianceName = form.ApplianceName.value;
        var url = '/Home/AddAppliance?roomName=' + roomName + '&applianceType=' + applianceType + '&applianceName=' + applianceName;
        var newAppliance = {
            Room: roomName,
            Type: applianceType
        };

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(newAppliance),
        })
            .then(response => response.json())
            .then(data => {
                const statusElement = document.getElementById('status');
                statusElement.innerHTML = data.join('<br>');
                form.innerHTML = '';
            });
    });

    document.getElementById('cancel').addEventListener('click', () => {
        event.preventDefault();
        form.innerHTML = '';
    });
}

function addDoor() {
    var form = document.getElementById('new');

    form.innerHTML += '<input type="text" name="doorName" placeholder="Door Name">';
    form.innerHTML += '<button id="addDoor">submit</button>';
    form.innerHTML += '<button id="cancel">cancel</button>';

    document.getElementById('addDoor').addEventListener('click', () => {
        event.preventDefault();
        var form = document.getElementById('new');
        var doorName = form.doorName.value;
        var url = '/Home/AddDoor?doorName=' + doorName;
        var newDoor = {
            Name: doorName
        };

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(newDoor),
        })
            .then(response => response.json())
            .then(data => {
                const statusElement = document.getElementById('status');
                statusElement.innerHTML = data.join('<br>');
                form.innerHTML = '';
            });
    })

    document.getElementById('cancel').addEventListener('click', () => {
        event.preventDefault();
        form.innerHTML = '';
    });
}

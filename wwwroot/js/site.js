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
        case 'room': addRoom()
            break;
        case 'applience':
            form.innerHTML += '<input type="text" name="applianceName" placeholder="Appliance Name">';
            break;
        case 'door':
            form.innerHTML += '<input type="text" name="doorName" placeholder="Door Name">';
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
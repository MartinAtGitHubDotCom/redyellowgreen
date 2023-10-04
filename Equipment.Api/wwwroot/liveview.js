var connection = new signalR.HubConnectionBuilder().withUrl("/live").build();

connection.on("ReceiveStatusUpdate", function (equipmentId, status) {
    let elem = document.getElementById(equipmentId);
    if (elem == null)
    {
        elem = document.createElement('div');
        elem.setAttribute('id', equipmentId);
        elem.setAttribute('class', 'status');
        document.body.append(elem);
    }
    
    elem.textContent = equipmentId;
    elem.style.background = status;
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});
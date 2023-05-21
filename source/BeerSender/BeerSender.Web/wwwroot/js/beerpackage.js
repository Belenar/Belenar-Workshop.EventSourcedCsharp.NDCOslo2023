"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/event-hub").build();

connection.on("publish_event", function (aggregate_id, event) {
    var li = document.createElement("li");
    document.getElementById("eventList").appendChild(li);
    var eventContent = JSON.stringify(event);
    li.textContent = `${aggregate_id}: ${eventContent}`;
});

connection.start().then(function () {
    document.getElementById("package_id_input").value = crypto.randomUUID();
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("createPackage").addEventListener("click", function (event) {
    var aggregate_id = document.getElementById("package_id_input").value;
    connection.invoke("subscribe_to_aggregate", aggregate_id).catch(function (err) {
        return console.error(err.toString());
    });

    var command = {
        "$type": "CreatePackage",
        "command": {
            "Aggregate_id": aggregate_id
        }
    }
    postCommand(command);

    event.preventDefault();
});

document.getElementById("addLabel").addEventListener("click", function (event) {
    var aggregate_id = document.getElementById("package_id_input").value;
    var package_label = document.getElementById("label_input").value;

    var command = {
        "$type": "AddLabel",
        "command": {
            "Aggregate_id": aggregate_id,
            "Label": package_label
        }
    }
    postCommand(command);

    event.preventDefault();
});

function postCommand(command) {
    fetch("/api/Command", {
        method: "POST",
        body: JSON.stringify(command),
        headers: {
            "Content-type": "application/json; charset=UTF-8"
        }
    });
}
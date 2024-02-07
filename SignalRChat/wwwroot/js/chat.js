"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("chatHub").build();

// Disable the send button until connection is established.
document.getElementById('sendButton').disabled = true;

connection.on('ReceivePrivateMessage', function (message) {
    var li = document.createElement('li');
    document.getElementById("messagesList").appendChild(li);    
    li.textContent = `${message}`;
});

connection.start().then(function () {
    document.getElementById('sendButton').disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById('sendButton').addEventListener('click', function (event) {
    var user = document.getElementById('To').value;
    var message = document.getElementById('Message').value;
    connection.invoke("SendPrivateMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
})


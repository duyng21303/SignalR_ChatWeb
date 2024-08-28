var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
connection.on("ReceiveMessage" , function (fromUser, massage) {
    var msg = fromUser + ": " + massage;
    var li = document.createElement("li");
    li.textContent = msg;
    $("#list").prepend(li);
});
connection.start();
$("#btnSend").on("click", function () {
    var fromUser = $("#txtUser").val();
    var message = $("#txtMsg").val();
    connection.invoke("SendMessage", fromUser, message);
});
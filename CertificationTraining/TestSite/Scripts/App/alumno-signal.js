var dataSource = [];

var testHub = $.connection.testHub;
//Nos da info extra de la conexión en la consola
$.connection.hub.logging = true;
//Comienza la comunicación, estable el enlace, y dtermina que tipo de comunición es mejor (websockets, long polling, etc)
//es async
$.connection.hub.start();

//Cuando el Hub envie un mensaje se invocara esta función
testHub.client.newMessage = function (message) {
    addMessage(message);
};

//Cuando el Hub envie una coordenada se invocara esta función
testHub.client.newCoordinate = function (coordinate) {
    updateChart(coordinate);
};


//JS Functions
function onSendMessage() {
    var message = $('#message-id').val();
    sendMessage(message);
    $('#message-id').val('');
}

function sendMessage(message) {
    testHub.server.send(message);
}

function addMessage(message) {
    $('#messages-container').append("<div>" + message + "</div>");
}

//Real Time Chart
var plot;
$(function () {
    plot = $.plot("#placeholder", [], {
        series: {
            shadowSize: 0	// Drawing is faster without shadows
        },
        yaxis: {
            min: 0,
            max: 100
        },
        xaxis: {
            show: false
        }
    });
});

function updateChart(coordinate) {

    if (dataSource.length > 300) {
        dataSource = [];
    }
    dataSource.push([dataSource.length, coordinate]);

    if (dataSource.length < 300)
        return;

    plot.setData([dataSource]);
    plot.draw();
}


window.onload = inicializaEventos;

function inicializaEventos() {

    document.getElementById("palante").addEventListener("click", pedirHtml), false;
}

function pedirHtml() {

    var llamada = new XMLHttpRequest();

    llamada.open("GET", "http://localhost:55433/Server/index.html");

    llamada.onreadystatechange = function () {
        if (llamada.readyState < 4) {

        } else if (llamada.readyState == 4 && llamada.status == 200) {

            var textoServidor = llamada.responseText;
            var divDestino = document.getElementById("respuesta");
            divDestino.innerHTML = textoServidor;

        }
    };

    llamada.send();

}
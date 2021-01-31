//window.onload = assignEventListeners;

function setUpListeners() {
    
}

//Carga la página y los scripts

function loadUpdatePage() {

    var llamada = new XMLHttpRequest();
    var script;

    llamada.open("GET", "../pages/update.html", false);
    llamada.onreadystatechange = function () {
        if (llamada.readyState == 4 && llamada.status == 200) {
            //Al body de index.html le asignamos el body de update.html
            document.getElementById("idBody").innerHTML = llamada.responseText;

            //Adding

        }
    };

    llamada.send();

}

function loadInsertPage() {

}

function loadListPage() {

}



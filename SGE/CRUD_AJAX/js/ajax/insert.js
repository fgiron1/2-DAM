window.onload = assignEventListeners;

function assignEventListeners() {
    document.getElementById("btnDesplegarInsertar").addEventListener("click", showInsertPanel);
    showPersonList();
}


function showInsertPanel() {

    var request = new XMLHttpRequest();

    request.open("GET", ".../htmlFragments/insert.html", false);

    request.onreadystatechange = function () {
        if (request.readyState == 4 && request.status == 200) {
            document.getElementById("divInsertarPersona").innerHTML = request.responseText;
        }
    };

    request.send();

}
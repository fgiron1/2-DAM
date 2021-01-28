window.onload = inicializarEventos;

function inicializarEventos() {
    document.getElementById("recorrer").addEventListener("click", recorrer);
    document.getElementById("anadir").addEventListener("click", anadir);
    document.getElementById("eliminar").addEventListener("click", eliminar);
}

function recorrer(){

    var tabla = document.getElementById("tabla");
    var resultado = "";

    for (var i = 0; i < tabla.rows.length; i++) {
        //Si no es la primera fila
        if (i != 0) {
            resultado += " y "
        }
        for (var j = 0; j < tabla.rows[i].cells.length; j++) {
            resultado += tabla.rows[i].cells[j].innerText;
        }
    }

    alert(resultado);


}
function anadir(){

    var tabla = document.getElementById("tabla");

    //Creamos una nueva fila y la almacenamos
    var nuevaFila = tabla.insertRow(-1);

    //Extraemos el numero de filas
    //Hay que sumarle 1 porque solo tiene en cuenta los nodos del DOM
    var numeroFilas = tabla.rows.length;

    //Extraemos el numero de columnas de la primera fila de la tabla
    var numeroColumnas = tabla.rows[0].cells.length;

    //La string vacía evita que el + sea interpretado como el operador de la suma
    for (var k = 0; k < numeroColumnas; k++) {
        nuevaFila.insertCell(-1).innerHTML = numeroFilas + "" + (k + 1);
       // nuevaFila.innerHTML += "<td>" +numeroFilas+" "+(k+1)+ "</td>";
    }

}

function eliminar(){
    document.getElementById("tabla").deleteRow(-1);
}

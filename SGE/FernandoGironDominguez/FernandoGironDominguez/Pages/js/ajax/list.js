window.onload = assignEventListeners;

/*
 * Asigna los event listeners y carga contenido inicial
 */
function assignEventListeners() {

    //Cargamos la lista de persona al empezar
    showMisionList();
}


/*
 * Carga la lista de personas de forma as�ncrona, llamando a la API
 * y llama al m�todo rellenarTabla con la informaci�n obtenida, construyendo
 * visualmente la tabla
 */

async function showMisionList() {

    //Todo lo que necesite hacer con personCollection lo tengo que hacer aqu�
    //No puedo devolver el valor
    getMisionList().then((misionListAsync) => {

        //C�digo de estado 204: No content
        if (misionListAsync === null) {
            document.createElement(h1).innerHtml = "No content";
        } else {
            rellenarTabla(misionListAsync);
        }
        
    });

}



/*
 * Esta funci�n se encarga de generar las filas en la tabla y rellenarlas con la informaci�n de cada mision,
 * pasada por par�metros
 * 
 * El event listener del boton de guardado se asigna en el cuerpo de esta funcion por la necesidad
 * de pasarle la lista de misiones sin realizar una llamada adicional a la API (innecesaria)

 *
 * @param  {Array<Object>} misionCollection   Un array de misiones. Con la informaci�n de cada objeto rellenaremos una fila
 */
    
async function rellenarTabla(misionCollection) {

    var table = document.getElementById("listTable");
    var tbody = document.getElementsByTagName('tbody')[0];

    //Limpiamos la tabla por si ya est� llena de previas iteraciones de esta funci�n
    table.removeChild(tbody);


    //Por cada persona, creamos una nueva fila, 9 celdas, y las rellenamos con sus datos.
    //Las primeras 7 celdas se destinan para los datos y las �ltimas 2 celdas contendr�n
    //un bot�n de actualizar y otro de eliminar, respectivamente

    var id = 0;
    for (var mision of misionCollection) {

        
        let misionID = mision.id;
        let misionBlockScope = mision;
        let idBlockScope = id;

        var newRow = table.insertRow(table.rows.length);

        //Le asignamos un id a la nueva fila, diferente en cada iteraci�n
        newRow.id = "tr - " + id;

        //Aumentamos el contador para la proxima fila
        id++;

        //Insertamos 8 celdas en la nueva fila
        for (var i = 0; i < 6; i++) {
            newRow.insertCell(i);
        }

        newRow.cells[0].classList.add("negro");

        //Rellenamos las celdas

        newRow.cells[1].innerHTML = "<p>" + mision.id + "</p>";

        newRow.cells[2].innerHTML = "<p>" + mision.nombre + "</p>";

        newRow.cells[3].innerHTML = "<p>" + mision.descripcion + "</p>";

        newRow.cells[4].innerHTML = "<p>" + booleanoLegible(mision.completada) + "</p>";


        //A�adimos un campo para editar la cantidad de cr�ditos de la misi�n
        //cuyo valor por defecto es el almacenado en la bbdd

        var txtInput = document.createElement("input");
        txtInput.id = "inputCreditos - " + id;
        txtInput.type = "text";
        txtInput.value = mision.creditos;

        newRow.cells[5].appendChild(txtInput);
    }

    //Le asignamos al bot�n de guardado su funci�n callback
    document.getElementById("btnGuardar").addEventListener("click", function () { btnGuardar(misionCollection) });

    //A�adimos una fila m�s al inicio para 
    var nuevaFila = table.insertRow(0);

    for(var i = 0; i < 6; i++) {
        nuevaFila.insertCell(i);
    }

    nuevaFila.cells[0].classList.add("negro");
    nuevaFila.cells[1].innerHTML = "<b>Id</b>";
    nuevaFila.cells[2].innerHTML = "<b>Nombre</b>";
    nuevaFila.cells[3].innerHTML = "<b>Descripcion</b>";
    nuevaFila.cells[4].innerHTML = "<b>Completada</b>";
    nuevaFila.cells[5].innerHTML = "<b>Creditos</b>";

}


function booleanoLegible(completada) {

    if (completada) {
        return "Completada";
    } else {
        return "No completada";
    }

}

/*
 * Funci�n callback para el bot�n de guardado. Se encarga de comprobar si existen
 * deferencias entre el valor introducido en el campo de texto (nuevo valor) y el valor
 * original almacenado en la bbdd. De ser as�, la actualiza con el nuevo valor y notifica
 * al usuario.
 * 
 * @param  {Array<Object>} misionCollection    La colecci�n de misiones 
 */

async function btnGuardar(misionCollection) {

    var tabla = document.getElementById("listTable");

    //Habr� tantas celdas como misiones; podemos usar un contador
    //junto con un foreach
    var i = 0;
    for (var mision of misionCollection) {

        var creditosIntroducidos = tabla.rows[i+1].cells[5].firstChild.value;

        //Si el valor de cr�ditos introducido y el que guarda la base de datos no coinciden,
        //esta se actualiza con el nuevo valor.

        if (creditosIntroducidos != mision.creditos) {

            //Le asignamos al objeto mision correspondiente su nuevo valor de cr�ditos
            mision.creditos = creditosIntroducidos;
            updateMision(mision).then((exitoso) => {
                if (exitoso) {
                    alert("Cambios guardados");
                }
            })
        }

        i++;

    }
    

}


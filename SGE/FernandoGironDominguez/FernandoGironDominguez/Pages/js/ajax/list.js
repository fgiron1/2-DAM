window.onload = assignEventListeners;

/*
 * Asigna los event listeners y carga contenido inicial
 */
function assignEventListeners() {

    //Cargamos la lista de persona al empezar
    showMisionList();
}


/*
 * Carga la lista de personas de forma asíncrona, llamando a la API
 * y llama al método rellenarTabla con la información obtenida, construyendo
 * visualmente la tabla
 */

async function showMisionList() {

    //Todo lo que necesite hacer con personCollection lo tengo que hacer aquí
    //No puedo devolver el valor
    getMisionList().then((misionListAsync) => {

        //Código de estado 204: No content
        if (misionListAsync === null) {
            document.createElement(h1).innerHtml = "No content";
        } else {
            rellenarTabla(misionListAsync);
        }
        
    });

}



/*
 * Esta función se encarga de generar las filas en la tabla y rellenarlas con la información de cada mision,
 * pasada por parámetros
 * 
 * El event listener del boton de guardado se asigna en el cuerpo de esta funcion por la necesidad
 * de pasarle la lista de misiones sin realizar una llamada adicional a la API (innecesaria)

 *
 * @param  {Array<Object>} misionCollection   Un array de misiones. Con la información de cada objeto rellenaremos una fila
 */
    
async function rellenarTabla(misionCollection) {

    var table = document.getElementById("listTable");
    var tbody = document.getElementsByTagName('tbody')[0];

    //Limpiamos la tabla por si ya está llena de previas iteraciones de esta función
    table.removeChild(tbody);


    //Por cada persona, creamos una nueva fila, 9 celdas, y las rellenamos con sus datos.
    //Las primeras 7 celdas se destinan para los datos y las últimas 2 celdas contendrán
    //un botón de actualizar y otro de eliminar, respectivamente

    var id = 0;
    for (var mision of misionCollection) {

        
        let misionID = mision.id;
        let misionBlockScope = mision;
        let idBlockScope = id;

        var newRow = table.insertRow(table.rows.length);

        //Le asignamos un id a la nueva fila, diferente en cada iteración
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


        //Añadimos un campo para editar la cantidad de créditos de la misión
        //cuyo valor por defecto es el almacenado en la bbdd

        var txtInput = document.createElement("input");
        txtInput.id = "inputCreditos - " + id;
        txtInput.type = "text";
        txtInput.value = mision.creditos;

        newRow.cells[5].appendChild(txtInput);
    }

    //Le asignamos al botón de guardado su función callback
    document.getElementById("btnGuardar").addEventListener("click", function () { btnGuardar(misionCollection) });

    //Añadimos una fila más al inicio para 
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
 * Función callback para el botón de guardado. Se encarga de comprobar si existen
 * deferencias entre el valor introducido en el campo de texto (nuevo valor) y el valor
 * original almacenado en la bbdd. De ser así, la actualiza con el nuevo valor y notifica
 * al usuario.
 * 
 * @param  {Array<Object>} misionCollection    La colección de misiones 
 */

async function btnGuardar(misionCollection) {

    var tabla = document.getElementById("listTable");

    //Habrá tantas celdas como misiones; podemos usar un contador
    //junto con un foreach
    var i = 0;
    for (var mision of misionCollection) {

        var creditosIntroducidos = tabla.rows[i+1].cells[5].firstChild.value;

        //Si el valor de créditos introducido y el que guarda la base de datos no coinciden,
        //esta se actualiza con el nuevo valor.

        if (creditosIntroducidos != mision.creditos) {

            //Le asignamos al objeto mision correspondiente su nuevo valor de créditos
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


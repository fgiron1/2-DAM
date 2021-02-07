window.onload = assignEventListeners;

/*
 * Asigna los event listeners y carga contenido inicial
 */
function assignEventListeners() {

    //Cargamos la lista de persona al empezar
    showPersonList();

    //INSERT CONTENT LISTENERS
    document.getElementById("btnInsertar").addEventListener("click", function () { btnInsertar(); });
    document.getElementById("btnDesplegarInsertar").addEventListener("click", function () { desplegarInsert() });

    //UPDATE CONTENT LISTENERS
    document.getElementById("btnActualizar").addEventListener("click", function () { btnActualizar(); });


}

/*
 * Prototipo: function desplegarInsert()
 *
 * Muestra visualmente el formulario de inserción
 *
 */
function desplegarInsert() {

    var formularioInsertar = document.getElementById("formularioInsertar");

    //Comprobamos si el formulario ya está desplegado o no

    if (formularioInsertar.classList.contains("hidden")) {

        //Desactivamos la clase visible
        formularioInsertar.classList.toggle("visible");

        //Activamos la clase hidden
        formularioInsertar.classList.toggle("hidden");

    } else {
        //Desactivamos clase visible
        formularioInsertar.classList.toggle("visible");

        //Activamos clase hidden
        formularioInsertar.classList.toggle("hidden");

    }
}

/*
 *
 *Función callback del botón que inserta una nueva persona
 *
 * Se encarga de insertar una nueva persona en la API, usando para ello
 * los valores en cada campo del formulario de insertar y reflejando el cambio visualmente,
 * si la petición a la API es exitosa
 *
 */

function btnInsertar() {

    //Construimos la persona y llamamos al método que la inserta en la API

    //Mandamos 0 como id porque no podemos tener multiples constructores
    //Ademas, en la api, aunque la envies, no la utiliza.

    var personToInsert = new PersonDepartment(0, document.getElementById("insertFirstName").value, document.getElementById("insertLastName").value, document.getElementById("insertBirthdate").value, document.getElementById("insertPhoneNumber").value, document.getElementById("insertEmail").value, document.getElementById("insertDepartmentID").value);

    //Si se consigue actualizar, recargamos para que se refleje visualmente
    insertPerson().then((exitoso) => {
        if (exitoso) {
            showPersonList();
        }
    });

}

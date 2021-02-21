window.onload = assignEventListeners;

/*
 * Asigna los event listeners y carga contenido inicial
 */
function assignEventListeners() {

    //Cargamos la lista de persona al empezar
    showPersonList();

    //Se rellenan las listas desplegables de departamento con las posibles opciones
    rellenarDropDowns();

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

        //Activamos la clase visible
        formularioInsertar.classList.toggle("visible");

        //Desactivamos la clase hidden
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

    //Mandamos 0 como id porque no podemos tener multiples constructores en JS
    //Ademas, en la api, aunque la envies, no la utiliza.

    var personToInsert = new PersonDepartment(0, document.getElementById("insertFirstName").value, document.getElementById("insertLastName").value, document.getElementById("insertBirthdate").value, document.getElementById("insertPhoneNumber").value, document.getElementById("insertEmail").value, document.getElementById("insertDepartmentID").value);

    //Si se consigue actualizar, recargamos para que se refleje visualmente
    insertPerson(personToInsert).then((exitoso) => {
        if (exitoso) {
            showPersonList();
        }
    });

}

/*
 * Cabecera: function rellenarDropDowns()
 * 
 * Rellena las listas de selección de departamento en los formularios de actualización e inserción,
 * llamando a la API para ello.
 * 
 */
function rellenarDropDowns() {

    getDepartments().then((dptCollection) => {

        var departmentDropDownInsert = document.getElementById("insertDepartmentID");

        var departmentDropDownUpdate = document.getElementById("updateDepartmentID");

        for (var i = 0; i < dptCollection.length; i++) {

            //Dos variables por posible problemas con referencias al mismo objeto

            let department = new Option(dptCollection[i].Name, dptCollection[i].ID);
            let department2 = new Option(dptCollection[i].Name, dptCollection[i].ID);

            departmentDropDownInsert.options.add(department);
            departmentDropDownUpdate.options.add(department2);
        }

    });

}
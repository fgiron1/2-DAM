

/*
 * Cabecera: function desplegarTodo(person)
 *
 * Muestra visualmente el formulario de actualizaci�n. Los campos del formulario tienen
 * por defecto escritos los valores del objeto persona pasado por par�metros
 *
 * @param  {Object}   Person     El objeto que representa los nuevos datos de la persona a actualizar (ID incluida)
 *
 */
function desplegarTodo(person) {

    var formularioUpdate = document.getElementById("formularioUpdate");

    //Comprobamos si el formulario ya est� desplegado o no

    if (formularioUpdate.classList.contains("hidden")) {

        //Desactivamos la clase visible
        formularioUpdate.classList.toggle("visible");

        //Activamos la clase hidden
        formularioUpdate.classList.toggle("hidden");

        fillInputs(person);

    } else {
        //Desactivamos clase visible
        formularioUpdate.classList.toggle("visible");

        //Activamos clase escondido
        formularioUpdate.classList.toggle("hidden");

    }
}

//Funci�n auxiliar empleada por desplegarTodo para poner un valor por defecto
//en los inputs
function fillInputs(person) {

    document.getElementById("txtId").value = person.id
    document.getElementById("txtFirstName").value = person.FirstName;
    document.getElementById("txtLastName").value = person.LastName;
    document.getElementById("txtBirthdate").value = person.Birthdate;
    document.getElementById("txtPhoneNumber").value = person.PhoneNumber;
    document.getElementById("txtEmail").value = person.Email;
    document.getElementById("txtDepartmentID").value = person.DepartmentID;

}

/*
 *
 *Funci�n callback del bot�n que actualiza una persona con los datos introducidos
 * 
 * Se encarga de actualizar a una persona llamando a la API, usando para ello
 * los valores en cada campo del formulario y reflejando el cambio visualmente,
 * si la petici�n a la API es exitosa
 * 
 */
function btnActualizar() {

    //Construimos la persona y llamamos al m�todo que actualiza a la api

    var personaFinal = new PersonDepartment(document.getElementById("txtId").value, document.getElementById("txtFirstName").value, document.getElementById("txtLastName").value, document.getElementById("txtBirthdate").value, document.getElementById("txtPhoneNumber").value, document.getElementById("txtEmail").value, document.getElementById("txtDepartmentID").value);

    //Si se consigue actualizar, recargamos la lista para que se refleje visualmente

    updatePerson(personaFinal).then((exitoso) => {
        if (exitoso) {
            showPersonList();
        }
    });

}

window.onload = addEventListener;

function addEventListener() {

    //Se le asigna el comportamiento al botón de actualizar del formulario
    document.getElementById("btnActualizar").addEventListener("click", btnActualizar);
    showPersonList();

}
//Se encarga de desplegar el formulario de actualización de la persona
function desplegarTodo(idFila, person) {

    var formularioUpdate = document.getElementById("formularioUpdate");


    //Comprobamos si el formulario ya está desplegado o no

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

//Función auxiliar empleada por desplegarTodo
function fillInputs(person) {

    document.getElementById("txtId").value = person.id
    document.getElementById("txtFirstName").value = person.FirstName;
    document.getElementById("txtLastName").value = person.LastName;
    document.getElementById("txtBirthdate").value = person.Birthdate;
    document.getElementById("txtPhoneNumber").value = person.PhoneNumber;
    document.getElementById("txtEmail").value = person.Email;
    document.getElementById("txtDepartmentID").value = person.DepartmentID;


}

//Lógica del botón de actualizar, asignada como callback para el boton del formulario

function btnActualizar(){

    //Construimos la persona y llamamos al método
    //que actualiza a la api

    var personaFinal = new PersonDepartment(document.getElementById("txtId").value, document.getElementById("txtFirstName").value, document.getElementById("txtLastName").value, document.getElementById("txtBirthdate").value, document.getElementById("txtPhoneNumber").value, document.getElementById("txtEmail").value, document.getElementById("txtDepartmentID").value);

    updatePerson(personaFinal);

}

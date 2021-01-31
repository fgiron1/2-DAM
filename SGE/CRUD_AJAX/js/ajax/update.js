window.onload = addTransitionListeners;

function addTransitionListeners() {

    document.getElementById("btnAtras").addEventListener("click", loadListPage);

}

//Persona es la persona a actualizar
function fillInputs(person) {

    var btnActualizar = document.getElementById("btnActualizar");

    document.getElementById("inputFirstName").value = person.FirstName;
    document.getElementById("inputLastName").value = person.LastName;
    document.getElementById("inputBirthdate").value = person.Birthdate;
    document.getElementById("inputPhoneNumber").value = person.PhoneNumber;
    document.getElementById("inputEmail").value = person.Email;
    document.getElementById("inputDepartmentID").value = person.DepartmentID;

    //Añadimos al boton la funcion de actualizar persona
    btnActualizar.addEventListener("click", updatePerson(person));

}

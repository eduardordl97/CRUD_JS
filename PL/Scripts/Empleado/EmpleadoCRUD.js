/// <reference path="SubCategoriaCRUD.js" />
$(document).ready(function () {
    GetAll();


});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:1389/api/empleado',
        success: function (result) { //200 OK
            $('#tbEmpleados tbody').empty();
            $.each(result.Objects, function (i, empleado) {
                var filas =
                    '<tr>'
                       
                        + '<td class="text-center"> <button class="btn btn-warning" onclick="GetById(' + empleado.IdEmpleado + ')"><span class="glyphicon glyphicon-edit" ></span></button></td>'
                        + "<td  id='id' class='text-center hidden'>" + empleado.IdEmpleado + "</td>"
                        + "<td class='text-center'>" + empleado.Nombre + "</td>"
                        + "<td class='text-center'>" + empleado.ApellidoPaterno + "</ td>"
                        + "<td class='text-center'>" + empleado.ApellidoMaterno + "</ td>"
                        + "<td class='text-center hidden'>" + empleado.Estado.IdEstado + "</td>"
                        + "<td class='text-center'>" + empleado.Estado.Nombre + "</td>"
                        + "<td class='text-center'>" + empleado.NumeroNomina + "</td>"
                        //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                        + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.IdEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#tbEmpleados tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};


function EstadoGetAll() {
    $("#ddlEstados").empty();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:1389/api/estado',
        success: function (result) {
            $("#ddlEstados").append('<option value="'+ 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, estado) {
                $("#ddlEstados").append('<option value="'
                                           + estado.IdEstado + '">'
                                           + estado.Nombre + '</option>');
            });
        },
        error: function (result) {
        alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
}
function Guardar() {
    var empleado = {

        IdEmpleado: $('#txtIdEmpleado').val(),
        NumeroNomina: $('#txtNumeroNomina').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val(),
        Estado: {
            IdEstado: $('#ddlEstados').val()
        }

    }

    if (empleado.IdEmpleado == "") {

        Add(empleado);
    }
    else {
        Update(empleado);
    }

};
function Add(empleado) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:1389/api/empleado',
        dataType: 'json',
        data: empleado,
        success: function (result) {
            $('#modalForm').modal('hide');
            $('#myModal').modal();
           
            GetAll();
         
            
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function InitializeControls() {
    $('#txtIdEmpleado').val('');
    $('#txtNombre').val('');
    $('#txtApellidoPaterno').val('');
    $('#txtApellidoMaterno').val('');
    $('#txtNumeroNomina').val('');

    $('#ddlEstados').val(0);
    $('#modalForm').modal('show');
}
function ShowModal() {
    $('#modalForm').modal('show');
    EstadoGetAll()
    InitializeControls();
    $('#lblTitulo').text('Agregar Empleado');

}


function GetById(IdEmpleado) {
    EstadoGetAll()
    $.ajax({
        type: 'GET',
        url: 'http://localhost:1389/api/empleado/' + IdEmpleado,
        success: function (result) {
            $('#txtIdEmpleado').val(result.Object.IdEmpleado);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtApellidoPaterno').val(result.Object.ApellidoPaterno);
            $('#txtApellidoMaterno').val(result.Object.ApellidoMaterno);
            $('#txtNumeroNomina').val(result.Object.NumeroNomina);
    
            $('#ddlEstados').val(result.Object.Estado.IdEstado);
           
            $('#modalForm').modal('show');
            $('#lblTitulo').text('Modificar Empleado');


        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
}


function Update(empleado) {




    $.ajax({
        type: 'PUT',
        url: 'http://localhost:1389/api/empleado',
        datatype: 'json',
        data: empleado,
        success: function (result) {
            $('#modalForm').modal('hide');
            $('#myModal').modal();

            GetAll();
            Console(respond);
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

};



function Eliminar(IdEmpleado) {

    if (confirm("¿Estas seguro de eliminar el empleado seleccionada?")) {
        $.ajax({

            type: 'DELETE',
            url: 'http://localhost:1389/api/empleado/' + IdEmpleado,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
};





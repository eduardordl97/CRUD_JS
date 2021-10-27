using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ERiveraLennkenGroupEntities context = new DL.ERiveraLennkenGroupEntities())
                {
                    var empleados = context.EmpleadoGetAll().ToList();

                    result.Objects = new List<object>();
                    if (empleados != null)
                    {
                        foreach(var obj in empleados){

                            ML.Empleado empleado = new ML.Empleado();
                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.NumeroNomina = obj.NumeroNomina;

                            empleado.Estado = new ML.Estado();
                            empleado.Estado.IdEstado = obj.IdEstado.Value;
                            empleado.Estado.Nombre = obj.Estado;

                            result.Objects.Add(empleado);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo obtener la información";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ERiveraLennkenGroupEntities context = new DL.ERiveraLennkenGroupEntities())
                {
                    var empleadoObj = context.EmpleadoGetById(IdEmpleado).FirstOrDefault();

                    
                    if (empleadoObj != null)
                    {
                        

                        ML.Empleado empleado = new ML.Empleado();
                        empleado.IdEmpleado = empleadoObj.IdEmpleado;
                        empleado.Nombre = empleadoObj.Nombre;
                        empleado.ApellidoPaterno = empleadoObj.ApellidoPaterno;
                        empleado.ApellidoMaterno = empleadoObj.ApellidoMaterno;
                        empleado.NumeroNomina = empleadoObj.NumeroNomina;

                        empleado.Estado = new ML.Estado();
                        empleado.Estado.IdEstado = empleadoObj.IdEstado.Value;
                        empleado.Estado.Nombre = empleadoObj.Estado;

                        result.Object = empleado;                        
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo obtener la información";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ERiveraLennkenGroupEntities context = new DL.ERiveraLennkenGroupEntities())
                {
                    var resultQuery = context.EmpleadoAdd(empleado.NumeroNomina,empleado.Nombre,empleado.ApellidoPaterno,empleado.ApellidoMaterno,empleado.Estado.IdEstado);


                    if (resultQuery >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Empleado";
                    }
                }
               

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ERiveraLennkenGroupEntities context = new DL.ERiveraLennkenGroupEntities())
                {
                    var resultQuery = context.EmpleadoUpdate(empleado.IdEmpleado,empleado.NumeroNomina, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Estado.IdEstado);


                    if (resultQuery >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Empleado";
                    }
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ERiveraLennkenGroupEntities context = new DL.ERiveraLennkenGroupEntities())
                {
                    var resultQuery = context.EmpleadoDelete(IdEmpleado);


                    if (resultQuery >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al eliminar el registro en la tabla Empleado";
                    }
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}

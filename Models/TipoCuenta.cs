﻿using ManejadorDePresupuestos.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace ManejadorDePresupuestos.Models
{
    public class TipoCuenta //:IValidatableObject
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")] //esta anotacion sirve para que el campo no se envie vacio
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public int Orden { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Nombre != null && Nombre.Length > 0)
        //    {
        //        var primeraLetra = Nombre[0].ToString();

        //        if (primeraLetra != primeraLetra.ToUpper())
        //        {
        //            yield return new ValidationResult("La primera letra debe ser mayúscula", new[] { nameof(Nombre)});
        //            //si no se agrega new[] { nameof(Nombre)} indica que la validacion es a nivel de modelo
        //        }
        //    }
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexionBasedatos
{
    class Cliente
    {

        protected String nombre, apellido, genero, fecha;
        protected int edad;

        public Cliente(String nombre, String apellido, String genero, String fecha, int edad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.genero = genero;
            this.fecha = fecha;
            this.edad = edad;
            

        }

    }
}

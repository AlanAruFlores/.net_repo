using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuarios
{
    internal class Usuario
    {
        private string nombre;
        private int edad;

        public Usuario(string nombre, int edad){
            this.nombre = nombre;
            this.edad = edad;
        }

        public string Nombre
        {
            get => this.nombre;
            set => this.nombre = value;
        }


        public int Edad
        {
            get => this.edad;
            set => this.edad = value;
        }

        public override string ToString()
        {
            return "PERSONA: "+this.nombre+" | EDAD: "+this.edad;
        }
    }
}

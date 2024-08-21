// See https://aka.ms/new-console-template for more information
using RegistroUsuarios;
using  System.Collections.Generic;


Console.WriteLine(mostrarMensaje());

List<Usuario> misUsuarios = new List<Usuario>();

misUsuarios.Add(new Usuario("Pepe", 24));

foreach(Usuario user in misUsuarios){
    Console.WriteLine(user);
}

string mostrarMensaje()
{
    return "Hola Mundo";
}




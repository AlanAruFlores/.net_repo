using System.Collections;
using System.Collections.Generic;


//STACK (PILA)-->Se basa en el enfoque LIFO (Ultimo en entrar / primero en salir) 

Console.WriteLine("PILA:");
Stack<string> pila = new Stack<string>();
pila.Push("Hola");
pila.Push("Esta es mi nueva pila");
displayElements(pila);


Console.WriteLine("\n\n");

//QUEUE (COLA) --> Se basa en el enfoque FIFO (Primero en entrar / primero en salir)
Console.WriteLine("COLA:");
Queue<int> queue = new Queue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
queue.Enqueue(4);
displayElements(queue);
Console.WriteLine($"DESENCOLANDO: {queue.Dequeue()}");
displayElements(queue);
Console.WriteLine("Limpiando la queue");
queue.Clear();
displayElements(queue);


//DICTIONARY --> Tipo de estrucutra de datos que se enfoca en clave y valor. Es un hashmap
Dictionary<string, List<string>> selecciones = new Dictionary<string, List<string>>();


string[] jugadoresArgentina = { "Messi", "Julian", "Dibu" };
string[] jugadoresBrasil = { "Vinicius", "Rodrigo", "Marcelo" };

selecciones.Add("Argentina", new List<String>(jugadoresArgentina));
selecciones.Add("Brasil", new List<String>(jugadoresBrasil));

//Obtengo el valor del diccionario
List<string> value = new List<string>();
selecciones.TryGetValue("Argentina",out value);
displayElements(value);




static void displayElements(IEnumerable list)
{
    foreach(var item in list)
        Console.WriteLine(item.ToString());
}
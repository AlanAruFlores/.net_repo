

/*
    Action<type> --> se usa en caso de que el conjunto de instrucciones no queira devolver nada.
    Func<typeParam, typeReturn> --> se usa para devolver un valor, el tipo de dato a retornar se especifica en el ultimo tipo.

 */

/*
 Usamos la libreria de LINQ para realizar operaciones sobre cualquier coleccion de datos.
 */


using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

Action<string> printMessage = s => Console.WriteLine(s); 

Func<int, int> squareOfX = x => x * x;

Console.WriteLine($"Cuadrado de X: {squareOfX(5)}");

printMessage("Hola Gente desde C#");

/*
    Expression --> devuelve la expresion completa definida en la funcion lambda
 */

Expression<Func<int, int>> e = x => x * x;
Console.WriteLine(e);

/*
    Select--> sirve para devolver un nuevo array , manipulando opcionalmente los datos de una colecccion (map)
 */


int[] numbers = { 1, 2, 3, 4 };
var numbersSquared = numbers.Select(x => Math.Pow(x, 2));
Console.WriteLine(string.Join("-", numbersSquared));

/*
    Ver si la edad es mayor a 18
 */

Console.WriteLine("Verificar edad: ");

int ageToTest = 20;

Func<int, bool> verifyHisAge = (age) => age > 18;

Action<int> checkHisAge = (age) =>
{
    bool isOlder = verifyHisAge(age);

    if (isOlder)
    {
        Console.WriteLine("Tiene mas de 18 años");
    }
    else
    {
        Console.WriteLine("Tiene menos de 18 años");
    }
};

checkHisAge(ageToTest);


/*
    Realizar una sumatoria de un arreglo
 */

int[] arrayNumbers = { 1, 2, 3, 4 };

var sum = (int[] arrNumbers) =>
{
    int acum = 0;

    foreach(int n in arrNumbers)
        acum += n;

    return acum;
};

int total = sum(arrayNumbers);
Console.WriteLine($"Total {total} of {string.Join("-", arrayNumbers)}");



/*
 Obtener cantidad de numeros impares
 */

int[] array = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
int oddNumbers = array.Count(x => x % 2 == 1);
Console.WriteLine($"Odd Number's count: " + oddNumbers);


/*
 Obtener los primeros numeros menores a 6
TakeWhile --> tomas los valores dentro de una condicion hasta que no se cumpla.
 */


var firstNumbersLessThanSix = array.TakeWhile(x => x < 6);
Console.WriteLine($"Primeros numeros menores a 6: {string.Join("-", firstNumbersLessThanSix)}");



/*
    Devolver clientes que residen en Argentina
*/

List<Cliente> listClientes = new List<Cliente>();
listClientes.Add(new Cliente("Ale", "Argentina"));
listClientes.Add(new Cliente("Pedro", "Chile"));
listClientes.Add(new Cliente("Karl", "Argentina"));

var clientsFromArgentina = listClientes.Where(x => x.pais.Equals("Argentina"));


Console.WriteLine($"List of clients from Argentina: {string.Join("-", clientsFromArgentina)}");

//Console.WriteLine(listClientes);

//


/*
    OrderByDescending / OrderByAscending ordenar los elementos
 */

List<Persona> people = new List<Persona>(){
    new Persona("Pedro", 20),
    new Persona("Martin", 24),
    new Persona("Leonel", 10)
};

//Ordena ascendentemente
var agesOrderedByAscending = people.OrderBy((x) => x.edad);
//Ordenar descendentemente
var agesOrderedByDescending = people.OrderByDescending((x) => x.edad);

Console.WriteLine($"Personas ordenadas ascedentemente: {string.Join("-",agesOrderedByAscending)}");
Console.WriteLine($"Personas ordenadas descendentemente: {string.Join("-", agesOrderedByDescending)}");



struct Persona
{
    public string nombre;
    public int edad;

    public Persona(string nombre, int edad)
    {
        this.nombre = nombre;
        this.edad = edad;
    }

    public override string ToString() { 
       return nombre;
    }
}

struct Cliente
{
    public string nombre;
    public string pais;

    public Cliente(string nombre, string pais)
    {
        this.nombre = nombre;
        this.pais = pais;
    }


    public override string ToString()
    {
        return this.nombre;
    }
};





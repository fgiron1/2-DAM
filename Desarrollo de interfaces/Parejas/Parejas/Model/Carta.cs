using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parejas.Model
{
    public class Carta : IComparable<Carta>
    {
        /*

        Todas las cartas tienen un diseño consistente en rayas diagonales coloreadas.
        Necesitamos relacionar el motivo visual de la carta con la propiedad Valor del objeto en el código.
        Para ello, seguiremos este código de colores, escogido de forma arbitraria:

        Azul     -> Valor = 1
        Rojo     -> Valor = 2
        Verde    -> Valor = 3
        Amarillo -> Valor = 4
        Púrpura  -> Valor = 5
        Naranja  -> Valor = 6
        Marrón   -> Valor = 7
        Rosa     -> Valor = 8
        Negro    -> Valor = 9

        */



        //El valor de la carta será un número del 1 al 9.
        //Estos valores solo serán empleados para comparar cartas del mismo valor.
        //Más allá de eso,  los números no tienen ningún significado adicional.
        //(Podría haber sido el número directamente el color, pero implicaría acoplamiento con el diseño visual)
        //Si se quieren añadir más cartas, sencillamente hay que usar más números.

        public int Valor { get; set; }

        //La carta está dada la vuelta o no en función de su valor
        //Su setter tiene que triggerear la animación de enseñar carta
        //o de ponerla boca abajo, llamando al metodo Begin()
        //Cuando llegue la hora de implementar esto, valorar si lo puedo hacer con el converter
        //que aunque sea una solución más chustera, necesito practicarlo
        public bool Seleccionada { get; set; }

        public Carta() { }

        public Carta(int inValor, bool inSeleccionada)
        {
            Valor = inValor;
            Seleccionada = inSeleccionada;
        }



        /// <summary>
        /// Compara dos cartas, determinando si tienen el mismo valor o no.
        /// </summary>
        /// <pre>Ambas cartas deben estar boca arriba (no tiene sentido comparar cartas que no están levantadas)</pre>
        /// <param name="other">La carta a comparar</param>
        /// <returns>Devuelve 0 si tienen el mismo valor, en caso contrario, devuelve -1</returns>
        public int CompareTo(Carta other)
        {
            int comparacion;
            return (other.Valor == this.Valor) ? comparacion = 0 : comparacion = -1;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Parejas.Model;
using Parejas.Viewmodel.Utils;

namespace Parejas.Viewmodel
{
    public class TableroVM : VMBase
    {
        /*
         * 
         * Converter para bindear el timer (tipo Timer) con una variable int que exprese los segundos,
         * con décimas y centésimas (tipo float) transcurridos
         * 
         * Hay que shufflear la lista después de generarla
         * 
         * Enlace para triggerear las animaciones: https://stackoverflow.com/questions/24761135/how-to-apply-storyboard-animation-to-multiple-xaml-element
         * Enlace para manejar el timer: https://docs.microsoft.com/es-es/dotnet/api/system.timers.timer?view=net-5.0
         * 
         * 
         * --------------   PROPIEDADES   -----------
         * List<Carta> conjuntoCartas (Poner en el getter que si es null, cree una lista con 18 cartas, las 9 repetidas dos veces)
         * Carta primeraSeleccion
         * Carta segundaSeleccion
         * 
         * int parejas (El número de parejas hechas. Siempre <=9) (Después de cada jugada se comprueba si el jugador ha ganado)
         * 
         * int vidas = 5 (expresa el numero de fallos) (Después de cada jugada se c)
         * Timer temporizador (por defecto 1 min y 30 s, comienza después de la selección de la primera carta de la partida)
         *                      (ver si tickea de forma asíncrona)
         * 
         * 
         * Hay que bindear el valor de una carta a un estilo concreto (converter?)
         * 
         * --------------  COMMANDS  --------------
         * 
         * recargarCommand ->    Pregunta al usuario si está seguro. De ser así, llama a reiniciarPartida()
         * seleccionarCommand -> Bindeado a cada carta en el XAML
         *                       Si el timer está a 1:30, iniciarlo. Luego:
         *                       Si primeraSeleccion es null, la asigna a primeraSeleccion
         *                       Si segundaSeleccion es null, la asigna a segundaSeleccion.
         *                       CASO QUE NUNCA SE PODRÍA DAR: Que primeraSeleccion sea null y segundaSeleccion no.
         *                       Lo controlamos reseteandolas en ejecutarJugada()
         *                       Si ninguna son null, llamamos a ejecutarJugada()
         *                       
         * --------------  METODOS  ----------------
         * 
         * Método ejecutarJugada(): Comprueba que las cartas sean iguales en valor y asigna un punto, o no. Si no es una pareja correcta,
         *                          las vuelve a poner boca abajo y se resta una vida. Además, se comprueba si ha ganado
         *                          (parejas == 9), y si es así, felicita al ganador y se le pregunta si quiere jugar otra.
         *                          En ese caso se llama a reiniciarPartida(). Si no, se le devuelve al menú principal
         *                          
         * Método reiniciarPartida(): Pone las vidas a 5, el temporizador a 1:30 y deselecciona todas las cartas.
         */

        #region Propiedades privadas y autoimplementadas

        private List<Carta> cartasTablero;
        public Carta PrimeraSeleccion { get; set; }
        public Carta SegundaSeleccion { get; set; }
        public int Vidas { get; set; } = 5;

        public int Parejas { get; set; } = 0;
        public Timer temporizador = new Timer();

        #endregion

        #region Propiedades públicas

        public List<Carta> CartasTablero
        {
            get
            {
                if(cartasTablero == null)
                {
                    cartasTablero = new List<Carta>();

                    for (int i = 0; i < 9; i++)
                    {
                        cartasTablero.Add(new Carta(i, false));
                        cartasTablero.Add(new Carta(i, false));
                    }
                }

                return cartasTablero;

            }
            
            set
            {
                cartasTablero = value;
            }
        }

        #endregion

        #region Commands



        #endregion

    }
}

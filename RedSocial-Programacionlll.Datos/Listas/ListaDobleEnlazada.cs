﻿using System;

namespace RedSocial_Programacionlll.Datos
{
    public class ListaDobleEnlazada<T>
    {
        public Int32 Count { get; set; }
        public NodoListaEnlazada<T> Primero { get; set; }
        public NodoListaEnlazada<T> Ultimo { get; set; }

        public ListaDobleEnlazada()
        {
            Primero = null;
            Ultimo = null;
        }

        public virtual void Agregar(T valor)
        {
            Comparador c = (Comparador)valor;
           
            NodoListaEnlazada<T> nuevo = new NodoListaEnlazada<T>(c);

            if (Primero == null)
            {
                Primero = nuevo;
                Ultimo = nuevo;

                nuevo.Anterior = null;
                nuevo.Siguiente = null;
            }
            else
            {
                NodoListaEnlazada<T> aux = Primero;

                while (aux != null && c.MenorQue(aux.Dato)) //aux.Valor < valor
                {
                    aux = aux.Siguiente;
                }

                if (aux == null)
                {
                    nuevo.Anterior = Ultimo;
                    Ultimo.Siguiente = nuevo;
                    nuevo.Siguiente = null;
                    Ultimo = nuevo;
                }
                else
                {
                    if (aux.Anterior == null) Primero = nuevo;
                    else aux.Anterior.Siguiente = nuevo;

                    nuevo.Anterior = aux.Anterior;
                    aux.Anterior = nuevo;
                    nuevo.Siguiente = aux;
                }
            }

            Count++;
        }

        public void Eliminar(T valor)
        {
        }
    }
}

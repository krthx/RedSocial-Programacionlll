using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDeDatos
{
    class Lista<T>
    {
        Nodo raiz;

        class Nodo
        {
            public T val;
            public Nodo sig;
        }

        public void agregar(T val)
        {

            if (raiz == null)
            {
                raiz = new Nodo();

                raiz.val = val;
            }
            else
            {
                Nodo tmp = raiz;

                while (tmp != null)
                {
                    if (tmp.sig == null)
                    {
                        tmp.sig = new Nodo();

                        tmp.sig.val = val;
                        tmp = null;

                    }
                    else
                    {
                        tmp = tmp.sig;
                    }
                }

            }

        }

        public void insertar(Int16 index, T val)
        {
            Nodo tmp = raiz;
            Nodo anterior = null;
            Int16 controlIndex = 0;

            while (tmp != null)
            {


                if (tmp.sig == null)
                {
                    throw new Exception("El indice ingresado supera la longitud de la lista");

                }
                else
                {
                    if (controlIndex == index)
                    {
                        Nodo nuevo = new Nodo();

                        if (index.Equals(0))
                        {
                            nuevo.val = val;
                            nuevo.sig = raiz;
                        }
                        else
                        {
                            nuevo.val = val;
                            nuevo.sig = tmp;

                            anterior.sig = nuevo;

                        }

                    }
                    anterior = tmp;
                    //intervalo
                    tmp = tmp.sig;
                }

            }

        }

        public void eliminar(Int16 index)
        {
            Nodo tmp = raiz;
            Nodo anterior = null;
            Int16 controlIndex = 0;

            while (tmp != null)
            {


                if (tmp.sig == null)
                {
                    throw new Exception("El indice ingresado supera la longitud de la lista");

                }
                else
                {
                    if (controlIndex == index)
                    {


                        if (index.Equals(0))
                        {
                            raiz = raiz.sig;
                        }
                        else
                        {
                            anterior.sig = tmp.sig;

                        }

                    }
                    anterior = tmp;
                    //intervalo
                    tmp = tmp.sig;
                }

            }

        }
        public T obtener(Int16 index)
        {
            Nodo tmp = raiz;
            Int16 controlIndex = 0;


            while (tmp != null)
            {


                if (tmp.sig == null)
                {
                    throw new Exception("El indice ingresado supera la longitud de la lista");

                }
                else
                {
                    if (controlIndex == index)
                    {


                        return tmp.val;
                    }
                }
                tmp = tmp.sig;

            }

            return default(T);
        }

        public Int16 count()
        {
            Int16 size = 0;
            Nodo tmp = raiz;

            while (tmp != null)
            {
                tmp = tmp.sig;
                size++;
            }
            return size;
        }

        public void imprimir()
        {
            Int16 size = 0;
            Nodo tmp = raiz;

            while (tmp != null)
            {
                throw new Exception(size + tmp.val.ToString());
                tmp = tmp.sig;
                size++;
            }
        }
    }
}
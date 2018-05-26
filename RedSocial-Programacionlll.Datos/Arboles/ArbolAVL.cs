using log4net;
using System;

namespace RedSocial_Programacionlll.Datos
{
    public class ArbolAVL
    {
        private readonly ILog Bitacora = LogManager.GetLogger("Bitacora");

        public NodoAvl Raiz;

        public int NumeroClientes { get; set; }

        public ArbolAVL()
        {
            Raiz = null;
        }
        public NodoAvl RaizArbol()
        {
            return Raiz;
        }
        private NodoAvl RotacionIzquierdaIzquierda(NodoAvl n, NodoAvl n1)
        {
            n.Izquierdo = n1.Derecho;
            n1.Derecho = n;
            // actualización de los factores de equilibrio
            if (n1.fe == -1) // se cumple en la inserción
            {
                n.fe = 0;
                n1.fe = 0;
            }
            else
            {
                n.fe = -1;
                n1.fe = 1;
            }

            return n1;
        }


        private NodoAvl RotacionDerechaDerecha(NodoAvl n, NodoAvl n1)
        {
            n.Derecho = n1.Izquierdo;
            n1.Izquierdo = n;
            // actualización de los factores de equilibrio
            if (n1.fe == +1) // se cumple en la inserción
            {
                n.fe = 0;
                n1.fe = 0;
            }
            else
            {
                n.fe = +1;
                n1.fe = -1;
            }
            return n1;
        }


        private NodoAvl RotacionIzquierdaDerecha(NodoAvl n, NodoAvl n1)
        {
            NodoAvl n2 = (NodoAvl) n1.Derecho;

            n.Izquierdo = n2.Derecho;
            n2.Derecho = n;
            n1.Derecho = n2.Izquierdo;
            n2.Izquierdo = n1;
            // actualización de los factores de equilibrio
            if (n2.fe == +1)
                n1.fe = -1;
            else
                n1.fe = 0;

            if (n2.fe == -1)
                n.fe = 1;
            else
                n.fe = 0;

            n2.fe = 0;
            return n2;
        }


        private NodoAvl RotacionDerechaIzquierda(NodoAvl n, NodoAvl n1)
        {
            NodoAvl n2;
            n2 = (NodoAvl)n1.Izquierdo;
            n.Derecho = n2.Izquierdo;
            n2.Izquierdo = n;
            n1.Izquierdo = n2.Derecho;
            n2.Derecho = n1;
            // actualización de los factores de equilibrio
            if (n2.fe == +1)
                n.fe = -1;
            else
                n.fe = 0;

            if (n2.fe == -1)
                n1.fe = 1;
            else
                n1.fe = 0;

            n2.fe = 0;
            return n2;
        }
        
        public void Insertar(Object valor)//throws Exception
        {
            Comparador dato;
            Logical h = new Logical(false); // intercambia un valor booleano

            dato = (Comparador) valor;
            Raiz = InsertarAvl(Raiz, dato, h);
        }

        private NodoAvl InsertarAvl(NodoAvl Raiz, Comparador dt, Logical h) 
            //throws Exception
        {
            NodoAvl n1;
            if (Raiz == null)
            {
                Raiz = new NodoAvl(dt);
                h.IsLogical = true;

                NumeroClientes++;
            }
            else if (dt.MenorQue(Raiz.Dato))
            {
                NodoAvl iz = InsertarAvl((NodoAvl) Raiz.Izquierdo, dt, h);
                Raiz.Izquierdo = iz;
                // regreso por los nodos del camino de búsqueda
                if (h.IsLogical)
                {
                    // decrementa el fe por aumentar la altura de rama izquierda
                    switch (Raiz.fe)
                    {
                    case 1:
                        Raiz.fe = 0;
                        h.IsLogical = false;
                        break;
                    case 0:
                        Raiz.fe = -1;
                        break;
                    case -1: // aplicar rotación a la izquierda
                        n1 = (NodoAvl)Raiz.Izquierdo;
                        if (n1.fe == -1)
                            Raiz = RotacionIzquierdaIzquierda(Raiz, n1);
                        else
                            Raiz = RotacionIzquierdaDerecha(Raiz, n1);
                            h.IsLogical = false;
                        break;
                    }
                }   
            }
            else if (dt.MayorQue(Raiz.Dato))
            {
                NodoAvl dr;
                dr = InsertarAvl((NodoAvl)Raiz.Derecho, dt, h);
                Raiz.Derecho = dr;
                // regreso por los nodos del camino de búsqueda
                if (h.IsLogical)
                {
                // incrementa el fe por aumentar la altura de rama izquierda
                switch (Raiz.fe)
                    {
                    case 1: // aplicar rotación a la derecha
                        n1 = (NodoAvl)Raiz.Derecho;
                        if (n1.fe == +1)
                            Raiz = RotacionDerechaDerecha(Raiz, n1);
                        else
                            Raiz = RotacionDerechaIzquierda(Raiz,n1);
                            h.IsLogical = false;
                        break;
                    case 0:
                        Raiz.fe = +1;
                        break;
                    case -1:
                        Raiz.fe = 0;
                        h.IsLogical = false;
                        break;
                    }
                }
            }
            else
                throw new Exception("No puede haber claves repetidas " );

            return Raiz;
        }

        public void Eliminar (Object valor) //throws Exception
        {
            Comparador dato = (Comparador) valor;

            Logical flag = new Logical(false);
            Raiz = BorrarAvl(Raiz, dato, flag);
        }


        private NodoAvl BorrarAvl(NodoAvl r, Comparador clave, Logical cambiaAltura) //throws Exception
        {
            if (r == null)
            {
                throw new Exception (" Nodo no encontrado ");
            }
            else if (clave.MenorQue(r.Dato))
            {
                NodoAvl iz = BorrarAvl((NodoAvl)r.Izquierdo, clave, cambiaAltura);
                r.Izquierdo = iz;

                if (cambiaAltura.IsLogical)
                    r = Equilibrar1(r, cambiaAltura);
            }
            else if (clave.MayorQue(r.Dato))
            {
                NodoAvl dr = BorrarAvl((NodoAvl)r.Derecho, clave, cambiaAltura);
                r.Derecho = dr;

                if (cambiaAltura.IsLogical)
                    r = Equilibrar2(r, cambiaAltura);
            }
            else // Nodo encontrado
            {
                NodoAvl q = r; // nodo a quitar del árbol

                if (q.Izquierdo== null)
                {
                    r = (NodoAvl) q.Derecho;
                    cambiaAltura.IsLogical = true;
                }
                else if (q.Derecho == null)
                {
                    r = (NodoAvl) q.Izquierdo;
                    cambiaAltura.IsLogical = true;
                }
                else
                { // tiene rama izquierda y derecha
                    NodoAvl iz = Reemplazar(r, (NodoAvl)r.Izquierdo, cambiaAltura);
                    r.Izquierdo = iz;

                    if (cambiaAltura.IsLogical)
                        r = Equilibrar1(r, cambiaAltura);
                }

                q = null;
            }

            return r;
        }


        private NodoAvl Reemplazar(NodoAvl n, NodoAvl act, Logical cambiaAltura)
        {
            if (act.Derecho != null)
            {
                NodoAvl d = Reemplazar(n, (NodoAvl)act.Derecho, cambiaAltura);
                act.Derecho = d;

                if (cambiaAltura.IsLogical)
                    act = Equilibrar2(act, cambiaAltura);
            }
            else
            {
                n.Dato = act.Dato;
                n = act;
                act = (NodoAvl)act.Izquierdo;
                n = null;

                cambiaAltura.IsLogical = true;
            }

            return act;
        }

        private NodoAvl Equilibrar1(NodoAvl n, Logical cambiaAltura)
        {
            NodoAvl n1;
            switch (n.fe)
            {
                case -1 :
                    n.fe = 0;
                    break;
                case 0 :
                    n.fe = 1;
                    cambiaAltura.IsLogical = false;
                    break;
                case +1 : //se aplicar un tipo de rotación derecha
                    n1 = (NodoAvl)n.Derecho;

                    if (n1.fe >= 0)
                    {
                        if (n1.fe == 0) //la altura no vuelve a disminuir
                            cambiaAltura.IsLogical = false;

                        n = RotacionDerechaDerecha(n, n1);
                    }
                    else
                        n = RotacionDerechaIzquierda(n, n1);
                    break;
            }

            return n;
        } 
        
        private NodoAvl Equilibrar2(NodoAvl n, Logical cambiaAltura)
        {
            NodoAvl n1;
                
            switch (n.fe)
            {
                case -1: // Se aplica un tipo de rotación izquierda
                    n1 = (NodoAvl)n.Izquierdo;
                    if (n1.fe <= 0)
                    {
                        if (n1.fe == 0)
                            cambiaAltura.IsLogical = false;

                        n = RotacionIzquierdaIzquierda(n, n1);
                    }
                    else
                        n = RotacionIzquierdaDerecha(n,n1);

                    break;
                case 0 :
                    n.fe = -1;
                    cambiaAltura.IsLogical = false;
                    break;
                case +1 :
                    n.fe = 0;
                    break;
            }

            return n;
        }
        
        /////////////////////////////////
        /// <summary>
        /// Comprueba el estatus del árbol
        /// </summary>
        /// <returns></returns>
         bool esVacio()
         {
            return Raiz == null;
         }

        public static NodoAvl nuevoArbol(NodoAvl ramaIzqda, Object dato, NodoAvl ramaDrcha)
        {
            return new NodoAvl(dato, ramaIzqda, ramaDrcha);
        }


        //binario en preorden
        public static string Preorden(Nodo r)
        {
            if (r != null)
            {
                return r.Valor + Preorden(r.Izquierdo) + Preorden(r.Derecho);
            }

            return "";
        } 
        
        // Recorrido de un árbol binario en inorden
        public static string Inorden(Nodo r)
        {
            if (r != null)
            {
                return Inorden(r.Izquierdo) + r.Valor + Inorden(r.Derecho);
            }
            return "";
        } 
        
        // Recorrido de un árbol binario en postorden
        public static string Postorden(Nodo r)
        {
            if (r != null)
            {
                return Postorden(r.Izquierdo) + Postorden(r.Derecho) + r.Valor;
            }
            return "";
        }

        //Devuelve el número de nodos que tiene el árbol
        public static int NumNodos(Nodo Raiz)
        {
            if (Raiz == null)
                return 0;
            else
                return 1 + NumNodos(Raiz.Izquierdo) + NumNodos(Raiz.Derecho);
        }


        public Object Buscar(Comparador T)
        {
            Nodo nodo = Raiz;

            while (nodo != null)
            {
                if (T.MenorQue(nodo.Dato))
                    nodo = nodo.Izquierdo;                
                else if (T.MayorQue(nodo.Dato))
                    nodo = nodo.Derecho;
                else
                    return nodo.Dato;
            }

            return null;
        }
        
        public ListaEnlazada<Usuario> BuscarCoincidencias(ListaEnlazada<Usuario> Resultado, NodoAvl n, Comparador v)
        {
            if (n != null)
            {
                if(((Comparador)n.Dato).Contains(v))
                    Resultado.Agregar((Usuario)n.Dato);

                BuscarCoincidencias(Resultado, (NodoAvl)n.Izquierdo, v);
                BuscarCoincidencias(Resultado, (NodoAvl)n.Derecho, v);
            }

            return Resultado;
        }
    }
}

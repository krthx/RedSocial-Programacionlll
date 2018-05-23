using System;

namespace RedSocial_Programacionlll.Datos
{
    public interface Comparador
    {
        bool IgualQue(Object q);

        bool MenorQue(Object q);

        //bool MontoIgualQue(Object q);

        //bool PrioridadIgualQue(Object q);

        //bool PrioridadMenorQue(Object q);

        //bool PrioridadMayorQue(Object q);

        //bool MontoMenorQue(Object q);

        //bool MontoMayorQue(Object q);

        bool MayorQue(Object q);

        //bool IdIgualQue(Object q);

        //bool IdMenorQue(Object q);

        //bool IdMayorQue(Object q);
        bool Contains(Object q);
    }
}

using UnityEngine;
using System.Collections.Generic;
using PackagePunto2D;
using PackagePersona; // necesario aunque no usemos estudiantes, porque Utilidades lo necesita

public class UsarPuntos2D : MonoBehaviour
{
    List<Punto2D> listaP = new List<Punto2D>();

    void Start()
    {
        // Crear puntos
        Punto2D p1 = new Punto2D(12.5, 7.3);
        Punto2D p2 = new Punto2D(4.0, 18.9);
        Punto2D p3 = new Punto2D(-3.2, 9.1);

        // Agregarlos a la lista
        listaP.Add(p1);
        listaP.Add(p2);
        listaP.Add(p3);

        // Mostrar en consola
        foreach (Punto2D punto in listaP)
        {
            Debug.Log("Punto: (" + punto.X1 + ", " + punto.Y1 + ")");
        }

        // Llamar a Utilidades con lista vacía de estudiantes
        List<Estudiante> listaE = new List<Estudiante>(); // vacía
        Utilidades.GuardarPuntos(listaP);
    }
}
using UnityEngine;
using PackagePersona; 
using System.Collections.Generic;
using PackagePunto2D;
using System.IO;

public class UsarPersona : MonoBehaviour
{
    List<Estudiante> listaE= new List<Estudiante>();
    List<Punto2D> listaP = new List<Punto2D>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        // Estudiantes
        Estudiante e1 = new Estudiante("2025_1","Ing Multimedia", "Alejandra Sepulveda", "alejasepulveda@gmail.com", "cll 103");
        listaE. Add(e1);

        Estudiante e2 = new Estudiante("2025_1", "Ing Multimedia", "Mateo Lopez", "mateolopez@gmail.com", "cra 26");
        listaE.Add(e2);

        for (int i=0;i<listaE.Count;i++)
        {
            Debug.Log(listaE[i].NameP + " " + listaE[i].NameCarrera);   
        }

        // Puntos 2D
        Punto2D p1 = new Punto2D(10.5, 20.3);
        Punto2D p2 = new Punto2D(5.7, 15.9);
        listaP.Add(p1);
        listaP.Add(p2);

        // Guardar en JSON
        Utilidades.GuardarEstudiantesYPuntos(listaE, listaP);
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
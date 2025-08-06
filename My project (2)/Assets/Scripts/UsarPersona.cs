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

        // Guardar en JSON
        Utilidades.GuardarEstudiantes(listaE);
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
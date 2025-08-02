using UnityEngine;
using PackagePersona; 
using System.Collections.Generic;

public class UsarPersona : MonoBehaviour
{
    List<Estudiante> listaE= new List<Estudiante>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        Estudiante e1= new Estudiante("2025_1","Ing Multimedia", "Alejandra Sepulveda", "alejasepulveda@gmail.com", "cll 103");
    listaE. Add(e1);

        for (int i=0;i<listaE.Count;i++)
        {
            Debug.Log(listaE[i].NameP + " " + listaE[i].NameCarrera);   
        }
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}

using UnityEngine;
using PackagePersona; 
using System.Collections.Generic;
using TMPro;

public class UsarPersona : MonoBehaviour
{
    List<Estudiante> listaE= new List<Estudiante>();
    private TMP_InputField codeStudent;
    private TMP_InputField carreraStudent;
    private TMP_InputField nameStudent;
    private TMP_InputField mailStudent;
    private TMP_InputField dirStudent;
    
    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
    //    // Estudiantes
    //    Estudiante e1 = new Estudiante("2025_1","Ing Multimedia", "Alejandra Sepulveda", "alejasepulveda@gmail.com", "cll 103");
    //    listaE. Add(e1);

    //    Estudiante e2 = new Estudiante("2025_1", "Ing Multimedia", "Mateo Lopez", "mateolopez@gmail.com", "cra 26");
    //    listaE.Add(e2);

    //    for (int i=0;i<listaE.Count;i++)
    //    {
    //        Debug.Log(listaE[i].NameP + " " + listaE[i].NameCarrera);   
    //    }

    //    // Guardar en JSON
    //    Utilidades.GuardarEstudiantes(listaE);
    }

    // Update is called once per frame
    public void Update(){
        
    }

public void AddStudentList(){
    string codeStudent1 = codeStudent.text;
    string carreraStudent1 = carreraStudent.text;
    string nameStudent1 = nameStudent.text;
    string mailStudent1 = mailStudent.text;
    string dirStudent1 = dirStudent.text;

        Estudiante e1 = new Estudiante(codeStudent1, carreraStudent1, nameStudent1, mailStudent1, dirStudent1);

        listaE.Add(e1);
    }

public void ShowStudentList()
    {
        for (int i = 0; i < listaE.Count; i++)
        {
            Debug.Log(listaE[i].NameP + " " + listaE[i].NameCarrera);   
        }

        Utilidades.SaveDataStudent(listaE);
    }
}
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
using PackagePersona;
using PackagePunto2D;

public class Utilidades
{
    public static bool SaveDataStudent(List<Estudiante> listaE)
    {
        try
        {
            string jsonString = JsonUtility.ToJson(new EstudianteListWrapper { estudiantes= listaE}, true);
            string folderPath = Application.streamingAssetsPath;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, "datos.json");

             File.WriteAllText(filePath, jsonString);

            Debug.Log("Lista guardada en: " + filePath);
            return true;
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error guardando estudiantes: " + ex.Message);
        }

        return false;
    }
}

[Serializable]
public class EstudianteListWrapper
{
    public List<Estudiante> estudiantes;
}


//    private class ContenedorDatos
//    {
//        public List<Estudiante> estudiantes;
//        public List<Punto2D> puntos2D;
//    }

//    private static string rutaArchivo = Application.persistentDataPath + "/datos.json";

//    public static void GuardarEstudiantes(List<Estudiante> estudiantes)
//    {
//        ContenedorDatos datos = new ContenedorDatos();
//        datos.estudiantes = estudiantes;

//        string json = JsonUtility.ToJson(datos, true); 
//        File.WriteAllText(rutaArchivo, json);

//        Debug.Log("Datos guardados correctamente en: " + rutaArchivo);
//    }

//    public static void GuardarPuntos(List<Punto2D> puntos)
//    {
//        ContenedorDatos datos = new ContenedorDatos();
//        datos.puntos2D = puntos;

//        string json = JsonUtility.ToJson(datos, true); 
//        File.WriteAllText(rutaArchivo, json);

//        Debug.Log("Datos guardados correctamente en: " + rutaArchivo);
//    }




using PackagePersona;
using PackagePunto2D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;
public class Utilidades
{
    public static bool SaveDataStudent(List<Estudiante> listaE)
    {
        try
        {
            string jsonString = JsonUtility.ToJson(new EstudianteListWrapper { estudiantes = listaE }, true);
            string folderPath = Application.streamingAssetsPath;

            // Crear la carpeta si no existe
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, "datosEstudiante.json");

            // Escribir el archivo
            File.WriteAllText(filePath, jsonString);

            Debug.Log(" Archivo JSON guardado correctamente en: " + filePath);
            return true;
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al guardar archivo JSON: " + ex.Message);
            return false;
        }
    }

    public static bool SaveDataPuntos(List<Punto2D> listaP)
    {
        try
        {
            string jsonString = JsonUtility.ToJson(new PuntosListWrapper { puntos = listaP }, true);
            string folderPath = Application.streamingAssetsPath;

            // Crear la carpeta si no existe
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, "datosPuntos.json");

            // Escribir el archivo
            File.WriteAllText(filePath, jsonString);

            Debug.Log(" Archivo JSON guardado correctamente en: " + filePath);
            return true;
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al guardar archivo JSON: " + ex.Message);
            return false;
        }
    }
}

[Serializable]
public class EstudianteListWrapper
{

    public List<Estudiante> estudiantes;

}

[Serializable]
public class PuntosListWrapper
{

    public List<Punto2D> puntos;

}
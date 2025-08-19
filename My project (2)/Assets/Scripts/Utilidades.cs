using PackagePersona;
using PackagePunto2D;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Utilidades
{
    // Guarda una lista de estudiantes a un archivo JSON (default filename si no se especifica)
    public static bool SaveDataStudent(List<Estudiante> listaE, string fileName = "datosEstudiante.json")
    {
        try
        {
            string jsonString = JsonUtility.ToJson(new EstudianteListWrapper { estudiantes = listaE }, true);

            // Usar persistentDataPath para escritura (funciona en editor y en builds)
            string folderPath = Application.persistentDataPath;
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName);
            File.WriteAllText(filePath, jsonString);

            Debug.Log("Archivo JSON guardado correctamente en: " + filePath);
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError("Error al guardar archivo JSON: " + ex.Message);
            return false;
        }
    }

    public static bool SaveDataPuntos(List<Punto2D> listaP, string fileName = "datosPuntos.json")
    {
        try
        {
            string jsonString = JsonUtility.ToJson(new PuntosListWrapper { puntos = listaP }, true);
            string folderPath = Application.persistentDataPath;
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName);
            File.WriteAllText(filePath, jsonString);

            Debug.Log("Archivo JSON guardado correctamente en: " + filePath);
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError("Error al guardar archivo JSON: " + ex.Message);
            return false;
        }
    }
}

[Serializable]
public class EstudianteListWrapper { public List<Estudiante> estudiantes; }

[Serializable]
public class PuntosListWrapper { public List<Punto2D> puntos; }
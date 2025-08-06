using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
using PackagePersona;
using PackagePunto2D;

public class Utilidades
{
    [Serializable]
    private class ContenedorDatos
    {
        public List<Estudiante> estudiantes;
        public List<Punto2D> puntos2D;
    }

    private static string rutaArchivo = Application.persistentDataPath + "/datos.json";

    public static void GuardarEstudiantes(List<Estudiante> estudiantes)
    {
        ContenedorDatos datos = new ContenedorDatos();
        datos.estudiantes = estudiantes;

        string json = JsonUtility.ToJson(datos, true); 
        File.WriteAllText(rutaArchivo, json);

        Debug.Log("Datos guardados correctamente en: " + rutaArchivo);
    }

    public static void GuardarPuntos(List<Punto2D> puntos)
    {
        ContenedorDatos datos = new ContenedorDatos();
        datos.puntos2D = puntos;

        string json = JsonUtility.ToJson(datos, true); 
        File.WriteAllText(rutaArchivo, json);

        Debug.Log("Datos guardados correctamente en: " + rutaArchivo);
    }
}
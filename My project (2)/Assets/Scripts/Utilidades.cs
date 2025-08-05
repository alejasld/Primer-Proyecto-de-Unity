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

    public static void GuardarEstudiantesYPuntos(List<Estudiante> estudiantes, List<Punto2D> puntos)
    {
        ContenedorDatos datos = new ContenedorDatos();
        datos.estudiantes = estudiantes;
        datos.puntos2D = puntos;

        string json = JsonUtility.ToJson(datos, true); // true = bonito
        File.WriteAllText(rutaArchivo, json);

        Debug.Log("Datos guardados correctamente en: " + rutaArchivo);
    }
}
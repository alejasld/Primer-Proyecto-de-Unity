using UnityEngine;
using PackagePersona;
using System.Collections.Generic;
using TMPro;
using System.IO;
using System.Linq;

public class UsarPersona : MonoBehaviour
{
    // Lista principal
    public List<Estudiante> listaE = new List<Estudiante>();

    // Listas separadas
    public List<Estudiante> listaIngenieros = new List<Estudiante>();
    public List<Estudiante> listaNoIngenieros = new List<Estudiante>();

    // UI fields - asigna en el Inspector
    public TMP_InputField nameStudent;
    public TMP_InputField mailStudent;
    public TMP_InputField dirStudent;
    public TMP_InputField CodeStudent;
    public TMP_InputField carreraStudent;
    public TMP_InputField positionField; // campo opcional para índice

    void Start()
    {
        // Al inicio carga el archivo y separa por carrera
        loadDataEstudiantes();
        SepararIngenieria();
    }

    // 1) Leer archivo y crear lista
    public void loadDataEstudiantes()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Estudiantes.txt");
        if (!File.Exists(filePath))
        {
            Debug.LogError("El archivo no existe en: " + filePath);
            return;
        }

        try
        {
            string fileContent = File.ReadAllText(filePath);
            Debug.Log("Contenido del archivo: " + fileContent);

            using (StringReader reader = new StringReader(fileContent))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split(',');
                    if (parts.Length < 5)
                    {
                        Debug.LogWarning("Línea inválida (se esperan 5 campos): " + line);
                        continue;
                    }
                    for (int i = 0; i < 5; i++) parts[i] = parts[i].Trim();
                    Estudiante e = new Estudiante(parts[3], parts[4], parts[0], parts[1], parts[2]);
                    listaE.Add(e);
                    // Agregar también a las listas separadas para mantener estado
                    if (IsEngineer(e)) listaIngenieros.Add(e);
                    else listaNoIngenieros.Add(e);
                }
            }

            Debug.Log($"Se cargaron {listaE.Count} estudiantes.");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al leer el archivo: " + ex.Message);
        }
    }

    // Crear objeto Estudiante desde inputs de UI
    Estudiante CreateEstudianteFromInput()
    {
        string name = nameStudent != null ? nameStudent.text.Trim() : "";
        string mail = mailStudent != null ? mailStudent.text.Trim() : "";
        string dir = dirStudent != null ? dirStudent.text.Trim() : "";
        string code = CodeStudent != null ? CodeStudent.text.Trim() : "";
        string carrera = carreraStudent != null ? carreraStudent.text.Trim() : "";
        return new Estudiante(code, carrera, name, mail, dir);
    }

    // 3) Agregar en una posición particular (index desde positionField)
    public void AddStudentAtPosition()
    {
        int index = listaE.Count; // por defecto al final
        if (positionField != null && !string.IsNullOrWhiteSpace(positionField.text))
        {
            if (!int.TryParse(positionField.text, out index))
            {
                Debug.LogWarning("Índice inválido, se agregará al final.");
                index = listaE.Count;
            }
        }
        if (index < 0) index = 0;
        if (index > listaE.Count) index = listaE.Count;

        Estudiante e = CreateEstudianteFromInput();
        listaE.Insert(index, e);
        AddToCorrespondingList(e);
        Debug.Log($"Estudiante agregado en posición {index}: {e.NameP} - {e.NameCarrera}");
    }

    // 4) Agregar al inicio
    public void AddStudentToStart()
    {
        Estudiante e = CreateEstudianteFromInput();
        listaE.Insert(0, e);
        AddToCorrespondingList(e);
        Debug.Log($"Estudiante agregado al inicio: {e.NameP} - {e.NameCarrera}");
    }

    // Agregar al final (método simple)
    public void AddStudentList()
    {
        Estudiante e = CreateEstudianteFromInput();
        listaE.Add(e);
        AddToCorrespondingList(e);
        Debug.Log($"Estudiante agregado al final: {e.NameP} - {e.NameCarrera}");
    }

    // 2 & 5) Separar en ingenieros / no ingenieros (recalcula desde listaE)
    public void SepararIngenieria()
    {
        listaIngenieros = listaE.Where(x => IsEngineer(x)).ToList();
        listaNoIngenieros = listaE.Where(x => !IsEngineer(x)).ToList();
        Debug.Log($"Separación hecha. Ingenieros: {listaIngenieros.Count} | No ingenieros: {listaNoIngenieros.Count}");
    }

    // Criterio flexible: contiene 'ingenier'
    bool IsEngineer(Estudiante e)
    {
        if (e == null || string.IsNullOrWhiteSpace(e.NameCarrera)) return false;
        string c = e.NameCarrera.Trim().ToLowerInvariant();
        return c.Contains("ingenier");
    }

    void AddToCorrespondingList(Estudiante e)
    {
        if (IsEngineer(e)) listaIngenieros.Add(e);
        else listaNoIngenieros.Add(e);
    }

    // Mostrar lista completa y guardarla (por si quieres)
    public void ShowStudentList()
    {
        Debug.Log("Lista completa de estudiantes:");
        for (int i = 0; i < listaE.Count; i++)
        {
            Debug.Log($"{i}: {listaE[i].NameP} - {listaE[i].NameCarrera}");
        }
        Utilidades.SaveDataStudent(listaE, "datosEstudiante.json");
    }

    // 2) Imprimir solo ingenieros
    public void ImprimirIngenieros()
    {
        Debug.Log("----- Ingenieros -----");
        foreach (var est in listaIngenieros) Debug.Log($"{est.NameP} - {est.CodeE} - {est.NameCarrera}");
    }

    // 6) Guardar las 2 listas
    public void SaveBothLists()
    {
        bool ok1 = Utilidades.SaveDataStudent(listaIngenieros, "datosIngenieros.json");
        bool ok2 = Utilidades.SaveDataStudent(listaNoIngenieros, "datosNoIngenieros.json");
        if (ok1 && ok2) Debug.Log("Listas guardadas correctamente.");
        else Debug.LogError("Error guardando una o ambas listas.");
    }
}
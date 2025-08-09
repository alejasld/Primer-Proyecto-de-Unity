using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class MouseOverPanel : MonoBehaviour
{
    public RectTransform panelRosado;
    public Button botonGuardar;

    private Vector2 ultimaCoordenada;
    private List<CoordenadaData> listaCoordenadas = new List<CoordenadaData>();

    private void Start()
    {
        botonGuardar.onClick.AddListener(GuardarCoordenadas);

        string carpeta = Application.streamingAssetsPath;
        if (!Directory.Exists(carpeta))
        {
            Directory.CreateDirectory(carpeta);
            Debug.Log("Carpeta StreamingAssets creada en: " + carpeta);
        }
    }

    private void Update()
    {
        Vector2 localMousePos;

        if (RectTransformUtility.RectangleContainsScreenPoint(panelRosado, Input.mousePosition))
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                panelRosado,
                Input.mousePosition,
                null,
                out localMousePos);

            // Solo guarda si la posición cambió
            if (localMousePos != ultimaCoordenada)
            {
                ultimaCoordenada = localMousePos;
                listaCoordenadas.Add(new CoordenadaData
                {
                    x = ultimaCoordenada.x,
                    y = ultimaCoordenada.y
                });

                Debug.Log("Nueva coordenada registrada: " + ultimaCoordenada);
            }
        }
    }

    private void GuardarCoordenadas()
    {
        CoordenadasWrapper wrapper = new CoordenadasWrapper
        {
            coordenadas = listaCoordenadas
        };

        string json = JsonUtility.ToJson(wrapper, true);

        string ruta = Path.Combine(Application.streamingAssetsPath, "coordenadas.json");
        File.WriteAllText(ruta, json);

        Debug.Log("Coordenadas guardadas en: " + ruta);
    }
}

[System.Serializable]
public class CoordenadaData
{
    public float x;
    public float y;
}

[System.Serializable]
public class CoordenadasWrapper
{
    public List<CoordenadaData> coordenadas;
}
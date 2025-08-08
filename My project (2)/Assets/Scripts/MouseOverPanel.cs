using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MouseOverPanel : MonoBehaviour
{
    public RectTransform panelRosado;
    public Button botonGuardar;

    private Vector2 ultimaCoordenada;

    private void Start()
    {
        botonGuardar.onClick.AddListener(GuardarCoordenada);

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

            ultimaCoordenada = localMousePos;
            Debug.Log("Mouse sobre panel rosado, Pos local:" + ultimaCoordenada);
        }
    }

    private void GuardarCoordenada()
    {
        CoordenadaData data = new CoordenadaData
        {
            x = ultimaCoordenada.x,
            y = ultimaCoordenada.y
        };

        string json = JsonUtility.ToJson(data, true);

        string ruta = Path.Combine(Application.streamingAssetsPath, "coordenada.json");
        File.WriteAllText(ruta, json);

        Debug.Log("Coordenada guardada en: " + ruta);
    }
}

[System.Serializable]
public class CoordenadaData
{
    public float x;
    public float y;
}
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseOverPanel : MonoBehaviour
{
    public RectTransform panelRojo;

    private void Update()
    {
        Vector2 localMousePos;

        if (RectTransformUtility.RectangleContainsScreenPoint(panelRojo, Input.mousePosition))
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                panelRojo,
                Input.mousePosition,
                null,
                out localMousePos);

            Debug.Log(" Mouse sobre panel rojo, Pos local:" + localMousePos);

        }
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseOverPanel : MonoBehaviour
{
    public RectTransform panelRosado;

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

            Debug.Log(" Mouse sobre panel rosado, Pos local:" + localMousePos);

        }
    }
}

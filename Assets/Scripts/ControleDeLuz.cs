using UnityEngine;
using UnityEngine.EventSystems;

public class ControleDeLuz : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject luzApagada;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (luzApagada != null)
        {

            bool isActive = luzApagada.activeSelf;
            luzApagada.SetActive(!isActive);
        }

   
    }
}

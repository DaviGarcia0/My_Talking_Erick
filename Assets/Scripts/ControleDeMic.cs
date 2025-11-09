using UnityEngine;
using UnityEngine.EventSystems;

public class ControleDeMic : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject micDesativado;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (micDesativado != null)
        {
            // alterna visibilidade do ícone de mic desligado
            bool isActive = micDesativado.activeSelf;
            micDesativado.SetActive(!isActive);
        }
    }
}

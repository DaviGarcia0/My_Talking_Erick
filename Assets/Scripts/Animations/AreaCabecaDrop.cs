using UnityEngine;
using UnityEngine.EventSystems;

public class AreaCabecaDrop : MonoBehaviour, IDropHandler
{
    public PersonagemAnimacao personagem;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject objeto = eventData.pointerDrag;

        if (objeto != null)
        {
            personagem.Comer();
            objeto.SetActive(false); // 🔹 Some com o item
        }
    }
}

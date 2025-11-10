using UnityEngine;
using UnityEngine.EventSystems;

public class AreaSom : MonoBehaviour, IPointerClickHandler
{
    [Header("Sons possíveis para esta área")]
    public AudioClip[] sons; // vários sons
    [Range(0f, 1f)] public float volume = 1f;

    private AudioSource audioSource;

    void Start()
    {
        // Procura (ou cria) um AudioSource global
        audioSource = FindObjectOfType<AudioSource>();
        if (audioSource == null)
        {
            GameObject go = new GameObject("AudioManager");
            audioSource = go.AddComponent<AudioSource>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (sons.Length > 0)
        {
            int i = Random.Range(0, sons.Length); // escolhe som aleatório
            audioSource.PlayOneShot(sons[i], volume);
        }
    }
}

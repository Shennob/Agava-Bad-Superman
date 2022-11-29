using UnityEngine;

public class CloseOnTap : MonoBehaviour
{
    [SerializeField] private GameObject _panelWithControlElements;

    private void Start()
    {
        _panelWithControlElements.SetActive(false);
    }

    public void CloseSelf()
    {
        _panelWithControlElements.gameObject.SetActive(!_panelWithControlElements.gameObject.activeSelf);
    }
}

using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private UIController _uiController;

    [SerializeField]
    private string _hintText;

    private void OnTriggerEnter(Collider other)
    {
        _uiController.ShowHint(true,_hintText);
    }

    private void OnTriggerExit(Collider other)
    {
        _uiController.ShowHint(false,null);
    }
}

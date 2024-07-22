using UnityEngine;

public class ErrorTrigger : MonoBehaviour
{
    [SerializeField] private string error_name, error_description;

    private void OnTriggerEnter2D(Collider2D other) {
        GlobalManager.Instance.DisplayError(error_name, error_description);
    }
}

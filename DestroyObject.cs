using UnityEngine;


public class DestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject _objectToDestroy;

    public void DestroyObject()
    {
        Destroy(_objectToDestroy);
    }
}
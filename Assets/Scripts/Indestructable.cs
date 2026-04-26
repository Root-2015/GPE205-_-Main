using UnityEngine;

public class Indestructable : MonoBehaviour
{
        void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}

using UnityEngine;

public class BulletOwner : MonoBehaviour
{
    public Shootertank owner;


    public void DetermainOwner(Shootertank MaybeOwner) 
    {
        owner = MaybeOwner;
    }
}

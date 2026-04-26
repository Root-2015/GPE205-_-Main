using UnityEngine;

public class ScoreOnCollision : MonoBehaviour
{
    public float scoreAmount;


    void OnTriggerEnter(Collider other)
    {
        BulletOwner OtherOwner = other.gameObject.GetComponent<BulletOwner>();
        Shootertank Owner = OtherOwner.owner;
        GameObject TankOwner = Owner.gameObject;
        Health TankOwnerHealth = TankOwner.GetComponent<Health>();
        TankOwnerHealth.scoreGoal(scoreAmount);
    }
}

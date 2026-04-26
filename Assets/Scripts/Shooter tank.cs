using UnityEngine;

public class Shootertank : Shooter
{
	public GameObject bulletPrefab;
	private PawnTank pawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pawn = GetComponent<PawnTank>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Shoot()
    {
	Shoot(pawn.shootForce);
    }

    public override void Shoot(float shootForce)
    {
	//shoot the bulllet and push it forward
	GameObject bulletObject = Instantiate<GameObject>(bulletPrefab, muzzleLocation.position, muzzleLocation.rotation);
	Rigidbody rb = bulletObject.GetComponent<Rigidbody>();
	rb.AddForce(muzzleLocation.forward * pawn.shootForce);
    BulletOwner BulletSpawnOwner = bulletObject.GetComponent<BulletOwner>();
    BulletSpawnOwner.DetermainOwner(this);
    }

}

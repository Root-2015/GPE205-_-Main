using UnityEngine;

public class NoicceMaker : MonoBehaviour
{

	public float noiceVolume = 0.0f;


	public void Shoot()
	{
	noiceVolume = noiceVolume + 2;
	}

	public void Update()
	{
	if (noiceVolume > 0)
		{
		noiceVolume = noiceVolume - 1;
		}
	
	if (noiceVolume < 0) {noiceVolume = 0;}
	}

}

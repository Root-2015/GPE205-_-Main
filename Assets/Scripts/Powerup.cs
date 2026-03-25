using UnityEngine;
[System.Serializable]

public abstract class Powerup
{
    public float lifeSpan;
    public abstract void Apply(Pawn target);
    public abstract void Remove(Pawn target);
}

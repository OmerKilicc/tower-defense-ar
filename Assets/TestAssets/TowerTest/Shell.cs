using Unity.VisualScripting;
using UnityEngine;

public class Shell : WarEntity
{
    Vector3 launchPoint, targetPoint, launchVelocity;
    float age, blastRadius, damage;

    public void Initialize(
        Vector3 launchPoint, Vector3 targetPoint, Vector3 launchVelocity,
        float blastRadius, float damage
    )
    {
        this.launchPoint = launchPoint;
        this.targetPoint = targetPoint;
        this.launchVelocity = launchVelocity;
        this.blastRadius = blastRadius;
        this.damage = damage;
    }

    public override bool GameUpdate()
    {
        age += Time.deltaTime;
        Vector3 p = launchPoint + launchVelocity * age;
        p.y -= 0.5f * 9.81f * age * age;

        if (p.y <= 0f)
        {
            BoardManager.SpawnExplosion().Initialize(targetPoint, blastRadius, damage);
            Debug.LogWarning(targetPoint);
            OriginFactory.Reclaim(this);
            return false;
        }

        transform.localPosition = p;
        Vector3 d = launchVelocity;
        d.y -= 9.81f * age;
        transform.localRotation = Quaternion.LookRotation(d);
        BoardManager.SpawnExplosion().Initialize(p, 0.1f);
        return true;
    }
}
using Enemy;
using UnityEngine;

// Example of usage in Unity
public class PoolingHandler : MonoBehaviour
{
	[SerializeField] TowerMainScript bulletTowerPrefab; // Reference to the bullet tower prefab
	[SerializeField] BasicEnemy basicEnemyPrefab; // Reference to the basic enemy prefab
	[SerializeField] Bullet bulletPrefab; // Reference to the bullet prefab

	private void Start()
	{
		// Register pools for BulletTower, BasicEnemy, and Bullet
		ObjectFactory.RegisterPool<TowerMainScript>(10, bulletTowerPrefab);
		ObjectFactory.RegisterPool<BasicEnemy>(10, basicEnemyPrefab);
		ObjectFactory.RegisterPool<Bullet>(20, bulletPrefab);

		/*Examples
		 * 
		// Spawn some objects
		BulletTower tower1 = ObjectFactory.CreateObject<BulletTower>();
		BasicEnemy enemy1 = ObjectFactory.CreateObject<BasicEnemy>();
		Bullet bullet1 = ObjectFactory.CreateObject<Bullet>();

		// Return objects to the pool when done
		ObjectFactory.ReturnObject(tower1);
		ObjectFactory.ReturnObject(enemy1);
		ObjectFactory.ReturnObject(bullet1);
		*/
	}
}

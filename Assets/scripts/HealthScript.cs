using UnityEngine;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class HealthScript : MonoBehaviour
{
	/// <summary>
	/// Total hitpoints
	/// </summary>
	public int hp = 1;

	/// <summary>
	/// Enemy or player?
	/// </summary>
	public bool isEnemy = true;
	public Transform windSpread;
	private FreezeScript freeze;
	/// <summary>
	/// Inflicts damage and check if the object should be destroyed
	/// </summary>
	/// <param name="damageCount"></param>
	public void Damage(int damageCount, bool isSpread)
	{
		hp -= damageCount;

		if (hp <= 0)
		{
			// Dead!
			if (isSpread) {
				var windSpreader = Instantiate(windSpread) as Transform;
				windSpreader.position = transform.position;
			}
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage, shot.isSpreading);
				if (shot.isFreezing) {
					freeze = GetComponent<FreezeScript> ();
					if (freeze != null)
						freeze.gotShot = true;
				}
				// Destroy the shot
				Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
		// Is it the Fire Shield?
		FireShieldScript shield = otherCollider.gameObject.GetComponent<FireShieldScript>();
		if ((shield != null)&&(isEnemy)) {
			Damage (3, false);
			shield.hit = true;
		}

	}
}
using UnityEngine;

/// <summary>
/// Projectile behavior
/// </summary>
public class ShotScript : MonoBehaviour
{
	// 1 - Designer variables

	/// <summary>
	/// Damage inflicted
	/// </summary>
	public float duration = 5;
	public int damage = 1;

	/// <summary>
	/// Projectile damage player or enemies?
	/// </summary>
	public bool isEnemyShot = false;
	public bool isFreezing = false;
	public bool isSpreading = false;
	void Start()
	{
		// 2 - Limited time to live to avoid any leak
		Destroy(gameObject, duration); // 20sec
	}
}

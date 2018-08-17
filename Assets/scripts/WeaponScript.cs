using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
	//--------------------------------
	// 1 - Designer variables
	//--------------------------------

	/// <summary>
	/// Projectile prefab for shooting
	/// </summary>
	public Transform shotPrefab;
	private FreezeScript freeze;
	private PlayerScript player;
	/// <summary>
	/// Cooldown in seconds between two shots
	/// </summary>
	public float shootingRate = 0.25f;

	//--------------------------------
	// 2 - Cooldown
	//--------------------------------
	private float shootCooldown;

	// AI Stuff
    // Shoot: atira na direção do player sem rotacionar o monstro como no caso do chase
    public bool AI_shoot;
    //Utilizados caso exista n armas e deseja-se colocar uma mirando no alvo e o resto em volta disso
    public int AI_i; //Numerar armas de 1 a n neste parametro
    public int AI_n; //n total de armas no enemy
    private float portion;

	private Transform target;
	private float rotationAngle;

	void Start()
	{
		if (transform.parent != null)
			freeze = transform.parent.gameObject.GetComponent<FreezeScript>();	
		shootCooldown = 0f;


        if(AI_shoot == true){
			portion = 360/AI_n;
		}
	}

	void Update()
	{
		if (shootCooldown > 0){
			shootCooldown -= Time.deltaTime;
		}

		if(AI_shoot){
			target = GameObject.FindGameObjectWithTag("Char").transform;
			Vector2 directionToPlayer = (target.position - transform.position).normalized;
			rotationAngle = Mathf.Atan2(directionToPlayer.y,directionToPlayer.x)*Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0,0,rotationAngle+portion*AI_i);
		}

	}

	//--------------------------------
	// 3 - Shooting from another script
	//--------------------------------

	/// <summary>
	/// Create a new projectile if possible
	/// </summary>
	public void Attack(bool isEnemy){
		
		if (CanAttack){
			
			if (!isEnemy) {				
				target = GameObject.FindGameObjectWithTag("Char").transform;
				player = target.GetComponent<PlayerScript>();	
				if (GetComponent<OptionScript>() == null) {
					if (player.shotLevel >= 100) {
						if (player.shotElement == 1) {
							player.magic -= 16;
						} else if (player.shotElement == 2) {
							player.magic -= 24;
						} else if (player.shotElement == 3) {
							player.magic -= 8;
						} else if (player.shotElement == 4) {
							player.magic -= 1;
						}
					}
				}
			}
			shootCooldown = shootingRate;

			// Create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;

			// Assign position
			shotTransform.position = transform.position;

			// The is enemy property
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}

			// Make the weapon shot always towards it
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null)
			{
				move.direction = this.transform.right; // towards in 2D space is the right of the sprite
			}
		}
	}

	/// <summary>
	/// Is the weapon ready to create a new projectile?
	/// </summary>
	public bool CanAttack
	{
		get
		{
			if (freeze != null) {
				if (freeze.isFrozen) {
					return false;
				} else
					return shootCooldown <= 0f;
			} else
				return shootCooldown <= 0f;
			}
	}
}

using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MoveScript : MonoBehaviour
{
	// 1 - Designer variables

	/// <summary>
	/// Object speed
	/// </summary>
	public Vector2 speed = new Vector2(10, 10);

	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);

	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;

	/// AI Stuff
	/// Running shot = fugir de tiros
	public bool AI_running_shot;
	public Vector2 retreatDistance;
	
	public Transform shootingLinesDetectionUp;
	public Transform shootingLinesDetectionDown;
	public Transform shootingLinesDetectionLeft;
	public Transform shootingLinesDetectionRight;


	/// Chasing = perseguir o player
	public bool AI_chasing;
	public float stoppingDistance;

	private Transform target;

	void Start(){
		
		if(AI_chasing == true){
			target = GameObject.FindGameObjectWithTag("Char").transform;
		}

	}

	void Update(){

		//threats = GameObject.FindGameObjectsWithTag("PlayerShot");
		//float lowestDistance = 4;

		if(AI_running_shot == true){

			RaycastHit2D deathObserverDown = Physics2D.Raycast(shootingLinesDetectionDown.position, Vector2.down, retreatDistance.y);
			RaycastHit2D deathObserverUp = Physics2D.Raycast(shootingLinesDetectionUp.position, Vector2.up, retreatDistance.y);

 			float enemyHeight = gameObject.transform.TransformPoint(1, 1, 0).x - gameObject.transform.TransformPoint(0, 0, 0).x;

 			Vector2 leftPosition = new Vector2(shootingLinesDetectionLeft.position.x - retreatDistance.x, shootingLinesDetectionLeft.position.y);
			RaycastHit2D deathObserverLeft = Physics2D.Raycast(leftPosition, Vector2.up, enemyHeight);
			
			Vector2 rightPosition = new Vector2(shootingLinesDetectionRight.position.x, shootingLinesDetectionLeft.position.y);
			RaycastHit2D deathObserverRight = Physics2D.Raycast(rightPosition, Vector2.up, enemyHeight);

			Vector2 enemyPositionWorld = Camera.main.WorldToScreenPoint(transform.position); 	

			float topDistance = Screen.height - enemyPositionWorld.y;
			float bottomDistance = enemyPositionWorld.y;

			if(deathObserverDown.collider == true || enemyPositionWorld.y < 50){
				direction.y = 1;
			}

			if(deathObserverUp.collider == true || enemyPositionWorld.y > Screen.height-50){
				direction.y = -1;
			}

			if(deathObserverLeft.collider == true || enemyPositionWorld.x < 20){
				direction.x = 1;
				if(topDistance > bottomDistance){
					direction.y = 1;
				}else{
					direction.y = -1;
				}
			}

			if(deathObserverRight.collider == true || enemyPositionWorld.x > Screen.width-20){
				direction.x = -1;
				if(topDistance > bottomDistance){
					direction.y = 1;
				}else{
					direction.y = -1;
				}
			}

		} else if(AI_running_shot == true){



		}
		
		// 2 - Movement
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
		

	}

	void FixedUpdate()
	{
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

		// Apply movement to the rigidbody
		rigidbodyComponent.velocity = movement;
	}
}
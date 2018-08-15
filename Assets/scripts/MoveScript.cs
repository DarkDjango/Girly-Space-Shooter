using UnityEngine;
using System.Collections;

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

	/// Especial boss stuff
	public bool rotationBoss;
	public float rotationSpeed;

	/// AI Stuff
	/// Running shot = fugir de tiros
	public bool AI_running_shot;
	public Vector2 retreatDistance;
	
	public Transform shootingLinesDetectionUp;
	public Transform shootingLinesDetectionDown;
	public Transform shootingLinesDetectionLeft;
	public Transform shootingLinesDetectionRight;

	private bool noWayX = false;
	private bool noWayY = false;
	private Vector2 targetDirection;

	/// Chasing = perseguir o player
	public bool AI_chasing;

	private Transform target;
	private float rotationAngle;

	void Start(){
	}

	void Update(){

		if(AI_running_shot == true){

			float enemyHeight = gameObject.transform.TransformPoint(1, 1, 0).y - gameObject.transform.TransformPoint(0, 0, 0).y;
			float enemyWidth = gameObject.transform.TransformPoint(1, 1, 0).x - gameObject.transform.TransformPoint(0, 0, 0).x;

			Vector2 downPosition = new Vector2(shootingLinesDetectionDown.position.x, shootingLinesDetectionDown.position.y);
			RaycastHit2D deathObserverDown = Physics2D.Raycast(downPosition, Vector2.down, enemyHeight + retreatDistance.y);
			Debug.DrawLine (downPosition, new Vector2(downPosition.x, downPosition.y-enemyHeight-retreatDistance.y), Color.cyan);

			Vector2 upPosition = new Vector2(shootingLinesDetectionUp.position.x, shootingLinesDetectionUp.position.y);
			RaycastHit2D deathObserverUp = Physics2D.Raycast(upPosition, Vector2.up, enemyHeight + retreatDistance.y);
			Debug.DrawLine (upPosition, new Vector2(upPosition.x, upPosition.y+enemyHeight+retreatDistance.y),Color.blue);

 			Vector2 leftPosition = new Vector2(shootingLinesDetectionLeft.position.x, shootingLinesDetectionLeft.position.y);
			RaycastHit2D deathObserverLeft = Physics2D.Raycast(leftPosition, Vector2.left, enemyWidth + retreatDistance.x);
			Debug.DrawLine (leftPosition, new Vector2(leftPosition.x - enemyWidth - retreatDistance.x,leftPosition.y),Color.magenta);
			
			Vector2 rightPosition = new Vector2(shootingLinesDetectionRight.position.x, shootingLinesDetectionRight.position.y);
			RaycastHit2D deathObserverRight = Physics2D.Raycast(rightPosition, Vector2.right, enemyWidth + retreatDistance.x);
			Debug.DrawLine (rightPosition, new Vector2(rightPosition.x + enemyWidth + retreatDistance.x,rightPosition.y),Color.red);

			Vector2 enemyPositionWorld = Camera.main.WorldToScreenPoint(transform.position); 	

			float topDistance = Screen.height - enemyPositionWorld.y;
			float bottomDistance = enemyPositionWorld.y;

			if(deathObserverDown.collider == false && deathObserverUp.collider == false && deathObserverLeft.collider == false && deathObserverRight.collider == false){


				if(enemyPositionWorld.y < 70){
					direction.y = 1;
				}else if(enemyPositionWorld.y > Screen.height-70){
					direction.y = -1;
				}else if(enemyPositionWorld.x < 70){
					direction.x = 1;
				}else if(enemyPositionWorld.x > Screen.width-70){
					direction.x = -1;
				}

			}else{

				if (deathObserverUp.collider == true && deathObserverUp.collider.tag != "EnemyShot") {
					if(enemyPositionWorld.x <= Screen.width-50){
						direction.x = 1;
					}else{
						noWayX = true;
					}
				}
				if (deathObserverDown.collider == true && deathObserverDown.collider.tag != "EnemyShot") {
					if(enemyPositionWorld.x >= 50){
						direction.x = -1;
					}else{
						noWayX = true;
					}
				}
				if (deathObserverLeft.collider == true && deathObserverLeft.collider.tag != "EnemyShot") {
					if(enemyPositionWorld.y >= 50){
						direction.y = -1;
					}else{
						noWayY = true;
					}
					direction.y = -1;
				}
				if (deathObserverRight.collider == true && deathObserverRight.collider.tag != "EnemyShot") {
					if(enemyPositionWorld.y <= Screen.height-50){
						direction.y = 1;
					}else{
						noWayY = true;
					}
				}

			}

			
			if(noWayX && ( (deathObserverUp.collider == true && enemyPositionWorld.x < Screen.width-550) || (deathObserverDown.collider == true && enemyPositionWorld.x > 550) )){
				noWayX = false;
				//print("FOI desTRANCADO EM X ");
			}
			if(noWayY && ( (deathObserverLeft.collider == true && enemyPositionWorld.y > 350) || (deathObserverRight.collider == true && enemyPositionWorld.y < Screen.height-350) )){
				noWayY = false;
				//print("FOI desTRANCADO EM Y");
			}

			if(GameObject.FindWithTag("Char")){
				target = GameObject.FindGameObjectWithTag("Char").transform;
				targetDirection = (target.position - transform.position).normalized;	
			}
		

		} else if(AI_chasing == true){

			if(GameObject.FindWithTag("Char")){
				target = GameObject.FindGameObjectWithTag("Char").transform;

				Vector2 chasingDirection = (target.position - transform.position).normalized;
				rotationAngle = Mathf.Atan2(chasingDirection.y,chasingDirection.x)*Mathf.Rad2Deg;

				direction.x = chasingDirection.x;
				direction.y = chasingDirection.y;
				transform.rotation = Quaternion.Euler(0,0,rotationAngle+180);
			}

		}

		if(rotationBoss == true){
			float t = (Mathf.Sin (Time.time * rotationSpeed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;
			print(t);

			transform.eulerAngles = Vector3.Lerp ( new Vector3(0,0,0), new Vector3(0,0,360), t);
		}
		
		//print(noWayX);
		//print(noWayY);

		// 2 - Movement
		if(noWayX && noWayY){
			movement = new Vector2(
				speed.x * targetDirection.x,
				speed.y * targetDirection.y);
		}else if(noWayX){
			movement = new Vector2(
				speed.x * targetDirection.x,
				speed.y * direction.y);
		}else if(noWayY){
			movement = new Vector2(
				speed.x * direction.x,
				speed.y * targetDirection.y);
		}else{
			movement = new Vector2(
				speed.x * direction.x,
				speed.y * direction.y);
		}
		

	}

	void FixedUpdate(){
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

		// Apply movement to the rigidbody
		rigidbodyComponent.velocity = movement;

	}

}
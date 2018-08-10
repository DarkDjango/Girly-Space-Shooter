using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class BossScript : MonoBehaviour
{
    private bool hasSpawn, inPosition;
	public float timer = 5f;
    private MoveScript moveScript;
    private WeaponScript[] weapons;
    private Collider2D coliderComponent;
    private SpriteRenderer rendererComponent;
  //  private AudioSource audioComponent;
    private float originalDirY;

    void Awake()
    {
        // Retrieve the weapon only once
        weapons = GetComponentsInChildren<WeaponScript>();

        // Retrieve scripts to disable when not spawn
        moveScript = GetComponent<MoveScript>();

        coliderComponent = GetComponent<Collider2D>();

        rendererComponent = GetComponent<SpriteRenderer>();

//        audioComponent = GetComponent<AudioSource>();

    }

    // 1 - Disable everything
    void Start()
    {
        hasSpawn = false;

        // Disable everything
        // -- Audio
  //      audioComponent.enabled = false;
        // -- collider
        coliderComponent.enabled = false;
        // -- Moving
        moveScript.enabled = true;
        // -- Shooting
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = false;
        }

    }

    void Update()
    {
        // 2 - Check if the enemy has spawned.
        if (hasSpawn == false)
        {
            if (rendererComponent.IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
			if (timer > 0)
				timer -= Time.deltaTime;
			else
				moveScript.speed.x = 0;
            moveScript.direction = new Vector2(moveScript.direction.x, Mathf.Sin(Time.time)*originalDirY);
            // Auto-fire
            foreach (WeaponScript weapon in weapons)
            {
                if (weapon != null && weapon.enabled && weapon.CanAttack)
                {
                    weapon.Attack(true);
                }
            }

            // 4 - Out of the camera ? Destroy the game object.
            if (rendererComponent.IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
    }

    // 3 - Activate itself.
    private void Spawn()
    {
        hasSpawn = true;

        // Enable everything
        // -- Audio
    //    audioComponent.enabled = true;
        // -- Collider
        coliderComponent.enabled = true;
        // -- Moving
        moveScript.enabled = true;
        // -- Shooting
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = true;
        }

        originalDirY = moveScript.direction.y;
        moveScript.speed = new Vector2(1, 1);

    }
}
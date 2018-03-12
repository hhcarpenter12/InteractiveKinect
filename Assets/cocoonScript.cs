using UnityEngine;
using System.Collections;

public class cocoonScript : MonoBehaviour
{
	public GameObject explosion;
	//public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	//public Vector3 mouse_pos;
	//public Transform target; //Assign to the object you want to rotate
	//public Vector3 object_pos;
	//public float angle;
	public float gizmoSize = 0.75f;
	public Color gizmoColor = Color.yellow;


	private int timesHit;
	//private LevelManager levelManager;
	private bool isBreakable;


	void OnDrawGizmos() {
		Gizmos.color = gizmoColor;
		Gizmos.DrawWireSphere(transform.position, gizmoSize);

	}




	// Use this for initialization
	void Start()
	{
		

		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable)
		{
			breakableCount++;
		}

		timesHit = 0;
		//levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	// Update is called once per frame
	void Update()
	{

		var mouse = Input.mousePosition;
		var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
		var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
		var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, angle);

	}

	void OnCollisionEnter2D(Collision2D col)
	{

			//Quaternion a = startPos;
			//a.x += direction * (delta * Mathf.Sin (Time.time * speed));
			//transform.rotation = a;

	}

	void HandleHits()
	{
		//timesHit++;
		//int maxHits = hitSprites.Length + 1;
		//if (timesHit >= maxHits)
		//{
		//	breakableCount--;
			//levelManager.BrickDestoyed();
		//	PuffSmoke();
		//	Destroy(gameObject);
		//}
		//else
		//{
		//	LoadSprites();
		//}
	}

	void PuffSmoke()
	{
		// GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;




		//temp.main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;

		if (hitSprites[spriteIndex] != null)
		{
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else
		{
			Debug.LogError("Brick sprite missing");
		}
	}

	// TODO Remove this method once we can actually win!
	void SimulateWin()
	{
		//levelManager.LoadNextLevel();
	}












}

#pragma strict

var remains: GameObject;
var lighty: GameObject;

function Start()
{
 gameObject.GetComponent.<Renderer>().material.color.a = 1;
}

function Update()
{
	if(Input.GetKey(KeyCode.Space))
	{

		
		
		Instantiate(remains, transform.position, transform.rotation);
		Instantiate(lighty, transform.position, transform.rotation);
	


		Destroy(gameObject);
	}
}
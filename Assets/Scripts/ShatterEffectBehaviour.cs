using System.Collections;
using UnityEngine;
public class ShatterEffectBehaviour : MonoBehaviour
{

	private GameObject _player;
	private GameObject[] _collecters;
	private bool _isShattered = false;

	private float _posY;

	public int ChildCount;

	private void Start()
	{
		_player = GameObject.Find("Player");
		_collecters = GameObject.FindGameObjectsWithTag("collecter");
		ChildCount = transform.childCount;

		RaycastHit hit;

		if (Physics.Raycast(transform.position, -Vector3.up, out hit))
		{
			if (hit.collider.name == "ground")
			{
				_posY = hit.point.y;
			}
		}

		transform.position = new Vector3(transform.position.x, _posY + 1, transform.position.z);
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.name == "Player" && _isShattered == false)
		{
			Shatter(collider.gameObject);
		}

		foreach (GameObject collecter in _collecters)
		{
			if(collider.tag == "collecter" && _isShattered == false)
			{
				Shatter(collider.gameObject);
			}
		}

	}

	private void Shatter(GameObject player)
	{
		foreach (Transform child in transform)
		{
			var rigidbody = child.GetComponent<Rigidbody>();
			var childCollider = child.GetComponent<BoxCollider>();
			childCollider.enabled = true;
			rigidbody.useGravity = true;
			rigidbody.AddExplosionForce(1000.0f, child.transform.position, 10.0f, .8f, ForceMode.Impulse);
			_isShattered = true;
			StartCoroutine(DestroyResource(child, transform));
		}
	}

	IEnumerator DestroyResource(Transform child, Transform transform)
	{
		if (child != null)
		{
			var destroyable = child.gameObject;
			yield return new WaitForSeconds(10);
			Destroy(destroyable);
			ChildCount--;
		}
		if (ChildCount == 0f)
		{
			var destroyable = transform.gameObject;

			Destroy(destroyable);
		}
	}
}

using UnityEngine;
public class PlayerController : MonoBehaviour
{
	private GameObject _locator;
	public SelectionScript selectable;
	private GameObject _ground;

	private float _playerPosY;

	private void Start()
	{
		_ground = GameObject.Find("ground");


	}

	private void Update()
	{
		if (_locator = GameObject.FindGameObjectWithTag("locator"))
		{
			transform.LookAt(Vector3.Lerp(transform.position, _locator.transform.position, 0.1f));
			transform.position = Vector3.MoveTowards(transform.position, _locator.transform.position, 0.1f);
		}

		RaycastHit hit;

		if (Physics.Raycast(transform.position, -Vector3.up, out hit))
		{
			if (hit.collider.name == "ground")
			{
				_playerPosY = hit.point.y;
			}
		}

		transform.position = new Vector3(transform.position.x, _playerPosY + 1, transform.position.z);
	}
}



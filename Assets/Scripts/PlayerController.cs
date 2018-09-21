using UnityEngine;
public class PlayerController : MonoBehaviour
{
	private GameObject _locator;
	public SelectionScript selectable;

	private void Update()
	{
			if (_locator = GameObject.FindGameObjectWithTag("locator"))
			{
				transform.LookAt(Vector3.Lerp(transform.position, _locator.transform.position, 0.1f));
				transform.position = Vector3.MoveTowards(transform.position, _locator.transform.position, 0.1f);
			}
	}
}



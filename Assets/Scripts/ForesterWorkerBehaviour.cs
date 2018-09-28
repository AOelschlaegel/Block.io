using UnityEngine;
public class ForesterWorkerBehaviour : MonoBehaviour
{
	private GameObject _target;

	private float _posY;

	private void Update()
	{
		_target = GameObject.FindGameObjectWithTag("forestertree");
		var targetPos = new Vector3(_target.transform.position.x, _target.transform.position.y + 1, _target.transform.position.z);

		transform.LookAt(Vector3.Lerp(transform.position, targetPos, 0.1f));
		transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.1f);

		RaycastHit hit;

		if (Physics.Raycast(transform.position, -Vector3.up, out hit))
		{
			if (hit.collider.name == "ground")
			{
				_posY = hit.point.y;
			}
		}

		transform.position = new Vector3(transform.position.x, _posY + 1, transform.position.z);

		/*foreach(Transform child in _target.transform)
		{
			var target = GameObject.FindGameObjectWithTag("foresterwood");
			var targetPosRes = target.transform.position;

			transform.LookAt(Vector3.Lerp(transform.position, targetPosRes, 1));
			transform.position = Vector3.MoveTowards(transform.position, targetPosRes, 1);
		}*/
	}
}

using UnityEngine;
public class ForesterWorkerBehaviour : MonoBehaviour
{
	private GameObject _target;

	private void Update()
	{
		_target = GameObject.FindGameObjectWithTag("forestertree");
		var targetPos = _target.transform.position;

		transform.LookAt(Vector3.Lerp(transform.position, targetPos, 0.1f));
		transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.1f);

		/*foreach(Transform child in _target.transform)
		{
			var target = GameObject.FindGameObjectWithTag("foresterwood");
			var targetPosRes = target.transform.position;

			transform.LookAt(Vector3.Lerp(transform.position, targetPosRes, 1));
			transform.position = Vector3.MoveTowards(transform.position, targetPosRes, 1);
		}*/
	}
}

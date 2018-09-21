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
	}
}

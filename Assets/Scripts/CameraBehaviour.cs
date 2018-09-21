using System.Collections;
using UnityEngine;
public class CameraBehaviour : MonoBehaviour
{
	public GameObject debugPrefab;
	public GameObject pivot;
	private GameObject _locator;
	private Vector3 _locatorPos;
	private Vector3 _currentCameraPos;
	private Vector3 _defaultPos;
	private RaycastHit _oldHit;
	[SerializeField]
	private float _zoomMax = 5f;
	[SerializeField]
	private float _zoomMin = 60f;
	private float _scrollSpeed = 0.5f;

	private void Start()
	{
		_defaultPos = Camera.main.transform.position;
	}

	private void Update()
	{
		_currentCameraPos = Camera.main.transform.position;

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		#region scrolling
		if (Input.GetKey(KeyCode.LeftShift))
		{
			_scrollSpeed = 1f;
		}
		else _scrollSpeed = 0.5f;

		if (Input.GetKey(KeyCode.A))
		{
			_currentCameraPos.x += 2 * -_scrollSpeed;
		}
		if (Input.GetKey(KeyCode.D))
		{
			_currentCameraPos.x += 2 * +_scrollSpeed;
		}
		if (Input.GetKey(KeyCode.W))
		{
			_currentCameraPos.z += 2 * +_scrollSpeed;
		}
		if (Input.GetKey(KeyCode.S))
		{
			_currentCameraPos.z += 2 * -_scrollSpeed;
		}
		#endregion

		if (Physics.Raycast(ray, out hit, 10000f))
		{

			if (hit.collider.name == "ground")
			{
				#region zoom
				//Zooming

				if (Input.GetAxisRaw("Mouse ScrollWheel") != 0f)
				{
					if (Input.GetAxis("Mouse ScrollWheel") > 0f && _currentCameraPos.y != _zoomMax)
					{
						_currentCameraPos = Vector3.Lerp(_currentCameraPos, hit.point, 0.05f);
						_oldHit = hit;
					}

					if (Input.GetAxis("Mouse ScrollWheel") < 0f && _currentCameraPos.y != _zoomMin)
					{
						_currentCameraPos = Vector3.Lerp(_currentCameraPos, new Vector3(_currentCameraPos.x, 60, _currentCameraPos.z), 0.05f);
					}
				}

				if (_currentCameraPos.y <= _zoomMax)
				{
					_currentCameraPos.y = _zoomMax;
				}

				if (_currentCameraPos.y >= _zoomMin)
				{
					_currentCameraPos.y = _zoomMin;
				}

				#endregion

				#region locator
				if (Input.GetMouseButtonDown(1))
				{
					Destroy(_locator);
					_locatorPos = new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z);
					_locator = Instantiate(debugPrefab, _locatorPos, Quaternion.identity);
				}
				#endregion
			}
		}

		#region rotation //not implemented yet



		if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out hit, 10000f))
		{
			if (Input.GetMouseButtonDown(2))
			{
				if (hit.collider.name == "ground")
				{
					var pivotPoint = Instantiate(pivot, hit.point, Quaternion.identity);
					transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
				}
			}
		}
		#endregion 
		Camera.main.transform.position = _currentCameraPos;


	}
	IEnumerator DestroyLocator(GameObject locator)
	{
		yield return new WaitForSeconds(1);
		Destroy(locator);
	}
}


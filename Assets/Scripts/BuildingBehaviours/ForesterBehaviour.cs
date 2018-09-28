using System.Collections;
using UnityEngine;
public class ForesterBehaviour : MonoBehaviour
{

	public GameObject[] TreeTypes = new GameObject[3];
	private int _randomIndex;
	private Vector3 _spawnPos;
	private Vector3 _position;
	private Vector3 _size;
	public int TreeCount;
	private int _treeLimit = 10;
	private float _range = 20;
	private int _tree;

	private float _posY;

	private int _naturalTrees;

	private bool _isSpawning;

	private int _spawnSpeed = 3;

	private void Start()
	{
		_position = transform.position;
		_size = transform.localScale;

		RaycastHit hit;

		if (Physics.Raycast(transform.position, -Vector3.up, out hit))
		{
			if (hit.collider.name == "ground")
			{
				_posY = hit.point.y + transform.localScale.z/2;
			}
		}

		transform.position = new Vector3(transform.position.x, _posY + 1, transform.position.z);
	}

	private void Update()
	{
		_randomIndex = Random.Range(0, 7);
		if (TreeCount < _treeLimit)
		{
			StartCoroutine(SpawnTree());
		}
		TreeCount = transform.childCount - _naturalTrees;
	}

	private IEnumerator SpawnTree()
	{
		_isSpawning = true;
		_spawnPos = new Vector3(Random.Range(_position.x - _size.x / 2 - _range, _position.x + _size.x / 2 + _range), 0f, Random.Range(_position.z - _size.z / 2 - _range, _position.z + _size.x / 2 + _range));
		GameObject tree;
		if (_randomIndex <= 3)
		{
			_tree = 0;
		}
		else if (_randomIndex >= 3 && _randomIndex <= 5)
		{
			_tree = 1;
		}
		else if (_randomIndex >= 5 && _randomIndex <= 6)
		{
			_tree = 2;
		}
		tree = Instantiate(TreeTypes[_tree], _spawnPos, Quaternion.identity);

		tree.transform.parent = gameObject.transform;
		tree.gameObject.tag = "forestertree";

		foreach (Transform child in tree.transform)
		{
			child.tag = "foresterwood";
		}

		yield return new WaitForSeconds(_spawnSpeed);
		_isSpawning = false;
	}

	private void OnTriggerEnter(Collider collider)
	{
		if(collider.tag == "tree")
		{
			Destroy(collider.gameObject);
		}
	}

	
}

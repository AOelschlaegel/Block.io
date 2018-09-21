using UnityEngine;
public class ResourceCollectionBehaviour : MonoBehaviour
{
	private GameObject _resourceController;
	private ResourceCount _resourceCount;
	private string _resource;

	private void Start()
	{
		_resource = this.gameObject.name;
		_resourceController = GameObject.FindGameObjectWithTag("ResourceController");
		_resourceCount = _resourceController.GetComponent<ResourceCount>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player" || collision.gameObject.tag == "collecter")
		{
			_resourceCount.AddResource(_resource);
			Destroy(gameObject);
		}

	}
}

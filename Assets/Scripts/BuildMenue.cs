using UnityEngine;
public class BuildMenue : MonoBehaviour
{
	public GameObject Forester;
	public bool ForesterSpawned;

	private int wood;
	private int gold;
	private int stone;

	public int ForesterCostsWood = 140;

	private ResourceCount _resourceCount;

	private void Start()
	{
		_resourceCount = GameObject.Find("ResourceController").GetComponent<ResourceCount>();
	}

	private void Update()
	{
		wood = _resourceCount.wood;
		gold = _resourceCount.gold;
		stone = _resourceCount.stone;
	}

	public void SpawnForester()
	{
		if (ForesterSpawned == false)
		{
			if(wood >= ForesterCostsWood)
			Instantiate(Forester, Forester.transform.position, Forester.transform.rotation);
			_resourceCount.wood -= ForesterCostsWood;
		}
		ForesterSpawned = true;
	}
}

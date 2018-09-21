using UnityEngine;
using UnityEngine.UI;

public class ResourceCount : MonoBehaviour
{
	public int wood;
	public int stone;
	public int gold;

	public Text count;

	private void Update()
	{
		count.text = "  WOOD:  " + wood.ToString() + "  STONE:  " + stone.ToString() + "  GOLD:  " + gold.ToString();
	}

	public void AddResource(string resource)
	{
		if(resource == "wood")
		{
			wood++;
		}

		if (resource == "stone")
		{
			stone++;
		}

		if (resource == "gold")
		{
			gold++;
		}
	}
}



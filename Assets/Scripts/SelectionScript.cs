using UnityEngine;
public class SelectionScript : MonoBehaviour
{
	/*private float _selected = 8f;

	private Shader _selectedShader;
	private Renderer renderer;
	public bool isSelected;
	public bool canMove;

	private void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 10000f))
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (hit.collider.name == "Player")
				{
					var hitObject = hit.transform.gameObject;

					renderer = hitObject.GetComponent<Renderer>();
					_selectedShader = Shader.Find("Outlined");
					renderer.material.SetFloat("_Outline", _selected);
					isSelected = true;
				}
				else if(hit.collider.name != "Player")
				{
					renderer.material.SetFloat("_Outline", 0f);
					isSelected = false;
				}
			}
		}

		if(isSelected == true)
		{
			canMove = true;
		}
		
			

	}
	*/
}

using UnityEngine;

public class Interactable : MonoBehaviour {

	bool isFocus = false;


	public virtual void Interact ()
	{
	}

	void Update ()
	{
        if (isFocus == true)
		{
            Interact();
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			isFocus = true;
		}
	}

}
using UnityEngine;

public class FollowCamera : MonoBehaviour {

	// Distance in the x axis the player can move before the camera follows.
    public float xOffset = 0f;
    // Distance in the y axis the player can move before the camera follows.
    public float yOffset = 0f;
   
    public Transform player;


 
	private void LateUpdate() {
		transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, -10);
	}

}

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public GameObject playerObject = null;
	public GameObject carObject = null;
	public float cameraTrackingSpeed = 0.2f;
	private Vector3 lastTargetPosition = Vector3.zero;
	private Vector3 currTargetPosition = Vector3.zero;
	private float currLerpDistance = 0.0f;
	
	void Start()
	{
		AggroEnemy.IsPlayerDriving = false;
			
		// Set the initial camera positioning to prevent any weird jerking around
		Vector3 playerPos = playerObject.transform.position;
		Vector3 cameraPos = transform.position;
		Vector3 startTargPos = playerPos;
		
		// Set the Z to the same as the camera so it does not move
		startTargPos.z = cameraPos.z;
		lastTargetPosition = startTargPos;
		currTargetPosition = startTargPos;
		currLerpDistance = 1.0f;
	}
	
	void LateUpdate()
	{
		// Continue moving to the current target position
		currLerpDistance += cameraTrackingSpeed;
		transform.position = Vector3.Lerp(lastTargetPosition, currTargetPosition, currLerpDistance);

		trackPlayer();
	}
	
	void trackPlayer()
	{
		// Get and store the current camera position, and the current player position, in world coordinates.
		Vector3 currCamPos = transform.position;
		Vector3 currPlayerPos;

		currPlayerPos = AggroEnemy.IsPlayerDriving ? carObject.transform.position : playerObject.transform.position;
		
		if (currPlayerPos.x < -8000f)
			return;
		
		if(currCamPos.x == currPlayerPos.x && currCamPos.y == currPlayerPos.y)
		{
			// Positions are the same - tell the camera not to move, then abort.
			currLerpDistance = 1.0f;
			lastTargetPosition = currCamPos;
			currTargetPosition = currCamPos;
			return;
		}
		
		// Reset the travel distance for the lerp
		currLerpDistance = 0.0f;
		
		// Store the current target position so we can lerp from it
		lastTargetPosition = currCamPos;
		
		// Store the new target position
		currTargetPosition = currPlayerPos;
		
		// Change the Z position of the target to the same as the current. We don' want that to change.
		currTargetPosition.z = currCamPos.z;
	}
	
	void stopTrackingPlayer()
	{
		// Set the target positioning to the camera's current position to stop its movement in its tracks
		Vector3 currCamPos = transform.position;
		currTargetPosition = currCamPos;
		lastTargetPosition = currCamPos;
		
		// Also set the lerp progress distance to 1.0f, which will tell the lerping that it is finished.
		// Since we set the target positionins to the camera's current position, the camera will just
		// lerp to its current spot and stop there.
		currLerpDistance = 1.0f;
	}
}

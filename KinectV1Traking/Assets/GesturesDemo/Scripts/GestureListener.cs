using UnityEngine;
using System.Collections;
using System;

public class GestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
	// GUI Text to display the gesture messages.
	public GUIText GestureInfo;

	// private bool to track if progress message has been displayed
	private bool progressDisplayed;

	private bool swipeLeft;
	private bool swipeRight;

	public bool IsSwipeLeft()
	{
		if (swipeLeft)
		{
			swipeLeft = false;
			return true;
		}

		return false;
	}

	public bool IsSwipeRight()
	{
		if (swipeRight)
		{
			swipeRight = false;
			return true;
		}

		return false;
	}



	public void UserDetected(uint userId, int userIndex)
	{
		// detect these user specific gestures
		KinectManager manager = KinectManager.Instance;

		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);

		manager.DetectGesture(userId, KinectGestures.Gestures.ZoomIn);
		manager.DetectGesture(userId, KinectGestures.Gestures.ZoomOut);


		if (GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = "Swipe left, Swipe right, Zoom out or Zoom In.";
		}
	}

	public void UserLost(uint userId, int userIndex)
	{
		if (GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = string.Empty;
		}
	}

	public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture,
								  float progress, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{

		//GestureInfo.guiText.text = string.Format("{0} Progress: {1:F1}%", gesture, (progress * 100));
		if ((gesture ==  KinectGestures.Gestures.ZoomIn || gesture == KinectGestures.Gestures.ZoomOut) && progress > 0.5f)
		{
			string sGestureText = string.Format("{0} detected, zoom={1:F1}%", gesture, screenPos.z * 100);
			if (GestureInfo != null)
				GestureInfo.GetComponent<GUIText>().text = sGestureText;

			progressDisplayed = true;
		}
	}

	public bool GestureCompleted (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		string sGestureText = gesture + " detected";
		if(GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = sGestureText;
		}

		if (gesture == KinectGestures.Gestures.SwipeLeft)
			swipeLeft = true;
		else if (gesture == KinectGestures.Gestures.SwipeRight)
			swipeRight = true;


		return true;
	}

	public bool GestureCancelled (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint)
	{
		
		if(progressDisplayed)
		{
			// clear the progress info
			if(GestureInfo != null)
				GestureInfo.GetComponent<GUIText>().text = String.Empty;
			
			progressDisplayed = false;
		}
		
		return true;
	}
	
}

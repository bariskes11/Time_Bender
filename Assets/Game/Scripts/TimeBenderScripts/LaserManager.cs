using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
	#region Unity Fields
	[SerializeField]
	GameObject laserObj;
	[SerializeField]
	SineDeformer sinDeformer;
	[Header("Sin deformer values")]

	[SerializeField]
	float frequency;
	[SerializeField]
	float animationSpeed;


	[Header("-----------")]
	#endregion
	#region Fields
	FpsRayCaster fpsController;
	#endregion

	#region Unity Methods
	private void Start()
	{
		sinDeformer = this.GetComponent<SineDeformer>();
		fpsController = GameObject.FindObjectOfType<FpsRayCaster>();
	}
	private void Update()
	{
		if (fpsController.IsFocused)
		{
			this.laserObj.SetActive(true);
			sinDeformer.Frequency = frequency;
			sinDeformer.AnimationSpeed = animationSpeed;

		}
		else
		{
			this.laserObj.SetActive(false);
			sinDeformer.Frequency = 0;
			sinDeformer.AnimationSpeed =0;
		}
	}
	#endregion
}

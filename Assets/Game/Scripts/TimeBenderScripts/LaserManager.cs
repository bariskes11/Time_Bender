using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
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
	Animator anims;
	bool isDisabled;
	#endregion

	#region Unity Methods
	private void Start()
	{
		anims = this.GetComponent<Animator>();
		sinDeformer = this.GetComponent<SineDeformer>();
		fpsController = GameObject.FindObjectOfType<FpsRayCaster>();
		EventManager.OnFasterButtonPressed.AddListener(this.DisableSinMove);
		EventManager.OnSlowDownButtonPressed.AddListener(this.DisableSinMove);
		EventManager.OnGameSuccess.AddListener(this.Disablelaser);
		isDisabled = false;
	}
	private void Update()
	{
		if (this.isDisabled)
			return;
			
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

	#region Private Methods
	void DisableSinMove()
	{
		sinDeformer.Frequency = 0;
		sinDeformer.AnimationSpeed = 0;
		this.isDisabled = true;
	}
	void Disablelaser()
	{
		this.laserObj.SetActive(false);
	}
	#endregion
}

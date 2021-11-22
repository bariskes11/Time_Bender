using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BzKovSoft.ObjectSlicer.EventHandlers
{
	[DisallowMultipleComponent]
	class BzReaplyForce : MonoBehaviour, IBzObjectSlicedEvent
	{
		[SerializeField]
		float minForce;
		[SerializeField]
		float maxForce;
		public void ObjectSliced(GameObject original, GameObject resultNeg, GameObject resultPos)
        {
			// we need to wait one fram to allow destroyed component to be destroyed.
			StartCoroutine(NextFrame(original, resultNeg, resultPos));
        }

		private IEnumerator NextFrame(GameObject original, GameObject resultNeg, GameObject resultPos)
		{
			yield return null;

			var oRigid = original.GetComponent<Rigidbody>();
			var aRigid = resultNeg.GetComponent<Rigidbody>();
			var bRigid = resultPos.GetComponent<Rigidbody>();

			if (oRigid == null)
				yield break;

			//aRigid.angularDrag = 0F;
			//bRigid.angularDrag = 0F;
			//aRigid.drag = 0F;
			//bRigid.drag = 0F;
			aRigid.angularVelocity = new Vector3( UnityEngine.Random.Range(minForce, minForce), UnityEngine.Random.Range(minForce, minForce), UnityEngine.Random.Range(minForce, minForce));
			bRigid.angularVelocity = new Vector3(UnityEngine.Random.Range(minForce, minForce), UnityEngine.Random.Range(minForce, minForce), UnityEngine.Random.Range(minForce, minForce));
			aRigid.velocity = new Vector3(UnityEngine.Random.Range(minForce, minForce), UnityEngine.Random.Range(minForce, minForce), UnityEngine.Random.Range(minForce, minForce));
			bRigid.velocity = new Vector3(UnityEngine.Random.Range(minForce, minForce), UnityEngine.Random.Range(minForce, minForce), UnityEngine.Random.Range(minForce, minForce));
		}
	}
}

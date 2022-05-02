using UnityEngine;
using BzKovSoft.ObjectSlicer;
using System.Diagnostics;
using System;
using System.Collections;

namespace BzKovSoft.ObjectSlicerSamples
{
	/// <summary>
	/// Test class for demonstration purpose
	/// </summary>
	public class SampleKnifeSlicer : MonoBehaviour
	{
		
		Vector3 endpos,startpos;
		public float knifeSpeed = 0.1f;

		#pragma warning disable 0649
		[SerializeField]
		private GameObject _blade;
		#pragma warning restore 0649

		void Start()
		{
			startpos = transform.position;
			endpos = new Vector3(transform.position.x,transform.position.y - 1,transform.position.z);
			
		}
		
		void Update()
		{
			//new code : 
			if(Input.GetButtonDown("Jump"))
			{
				//move knife only in y direction
				StartCoroutine("Chop");
			} 

			//old code : 
			// if (Input.GetMouseButtonDown(0))
			// {
			// 	var knife = _blade.GetComponentInChildren<BzKnife>();
			// 	knife.BeginNewSlice();

			// 	StartCoroutine(SwingSword());
			// }
		}


		IEnumerator Chop()
		{   
			//UnityEngine.Debug.Log("endpos : " + endpos.y);
			_blade.transform.position = new Vector3(transform.position.x,endpos.y,transform.position.z);

			yield return new WaitForSeconds(knifeSpeed);
			_blade.transform.position = new Vector3(transform.position.x,startpos.y,transform.position.z);
		}
		IEnumerator SwingSword()
		{
			var transformB = _blade.transform;
			transformB.position = Camera.main.transform.position;
			transformB.rotation = Camera.main.transform.rotation;

			const float seconds = 0.5f;
			for (float f = 0f; f < seconds; f += Time.deltaTime)
			{
				float aY = (f / seconds) * 180 - 90;
				float aX = (f / seconds) * 60 - 30;
				//float aX = 0;

				var r = Quaternion.Euler(aX, -aY, 0);

				transformB.rotation = Camera.main.transform.rotation * r;
				yield return null;
			}
		}
	}
}
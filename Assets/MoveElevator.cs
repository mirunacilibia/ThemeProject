using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveElevator : MonoBehaviour
{
	public bool open;
		public Transform Player;
		private float movementSpeed = 5f;
		public Vector3 targetPosition;
		private bool canMove = false;
		void Start()
		{
			targetPosition = new Vector3(transform.position.x, transform.position.y - 3f, transform.position.z);
		}

		void OnMouseOver()
		{
			{
				if (Player)
				{
					float dist = Vector3.Distance(Player.position, transform.position);
					Debug.Log("you are near the elevator");
					if (dist < 15)
					{
						if (open == false)
						{
							if (Input.GetMouseButtonDown(0))
							{
								canMove = true;
							}
						}
					}
				}

			}

		}

		/*IEnumerator opening()
		{
			Debug.Log("you are going on the elevator");

			Debug.Log(transform.position);
			yield return new WaitForSeconds(.5f);
		}*/

		private void Update()
		{
			if (transform.position.Equals(targetPosition))
				canMove = false;
			if (canMove)
			{
				transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
			}
		}
}

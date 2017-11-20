using UnityEngine;
using System.Collections;

public class MatrixLog : MonoBehaviour {
	public Transform anotherB;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Matrix4x4 mThisA = transform.localToWorldMatrix;
		Matrix4x4 mAnotherB = anotherB.localToWorldMatrix;

		Matrix4x4 bBasedOnA = mThisA.inverse * mAnotherB;

		Matrix4x4 mThisARotation = mThisA;
		mThisARotation.SetColumn(3, new Vector4(0.0f, 0.0f, 0.0f, 1.0f));
		Matrix4x4 bBasedOnAByTranspose = mThisARotation.transpose * mAnotherB;
		Vector3 posBBasedOnPosA = (anotherB.position - transform.position) ;
		bBasedOnAByTranspose.SetColumn(3, new Vector4(posBBasedOnPosA.x, posBBasedOnPosA.y, posBBasedOnPosA.z, 1.0f));

		Debug.Log("mThisA=\n" + mThisA + "\n" + "mAnotherB=\n" + mAnotherB +
			"\n" + "bBasedOnA=\n" + bBasedOnA + "bBasedOnAByTranspose=\n" + bBasedOnAByTranspose +
			"\nposBBasedOnPosA=" + posBBasedOnPosA + "=" +  posBBasedOnPosA.magnitude +
			"\nbBasedOnA.pos=" + bBasedOnA.GetColumn(3) + "=" + bBasedOnA.GetColumn(3).magnitude +

			"\nBasedOnAByTranspose.pos=" + bBasedOnAByTranspose.GetColumn(3) + "=" + bBasedOnAByTranspose.GetColumn(3).magnitude
		);
	}
}

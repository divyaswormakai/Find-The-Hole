using UnityEngine;
using System.Collections;

//<summary>
//Ball movement controlls and simple third-person-style camera
//</summary>
public class RollerBall : MonoBehaviour {
    float xMul = 10f;
    float zMul = 10f;

    public GameObject ViewCamera = null;
	public AudioClip CoinSound = null;

	private Rigidbody mRigidBody = null;
	private AudioSource mAudioSource = null;
	private bool mFloorTouched = false;

	void Start () {
		mRigidBody = GetComponent<Rigidbody> ();
		mAudioSource = GetComponent<AudioSource> ();
	}

	void FixedUpdate () {
		if (mRigidBody != null) {
            Vector3 tilt = Input.acceleration;
            Vector3 pos = mRigidBody.transform.position;

            tilt = Quaternion.Euler(90, 0, 0) * tilt;
            //pos.x += Input.GetAxis("Horizontal") * 30 * Time.deltaTime;
            //pos.z += Input.GetAxis("Vertical") * 30 * Time.deltaTime;

            pos.x += tilt.x * xMul * Time.deltaTime;
            pos.z += tilt.z * zMul * Time.deltaTime;

            mRigidBody.transform.position = pos;
        }

        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        Vector3 poss = mRigidBody.transform.position;
        poss.x += ver * xMul * Time.deltaTime;
        poss.z+= hor * zMul * Time.deltaTime;

        mRigidBody.transform.position = poss;

    }

	void OnCollisionEnter(Collision coll){
		
	}

	void OnCollisionExit(Collision coll){
		
	}

	void OnTriggerEnter(Collider other) {
		
	}
}

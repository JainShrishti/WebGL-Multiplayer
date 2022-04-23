using UnityEngine;
using Photon.Pun;
using System.Collections;

public class NetworkPlayerController : MonoBehaviour
{
    private float vertDir;
    private float horzDir;
    public float speed = 75;

    Animator anim;
    private PhotonView photonView;
    private Camera camera;

    private void Start()
    {
        anim = GetComponent<Animator>();
        camera = FindObjectOfType<Camera>();
        photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        else
        {
            vertDir = 0;
            vertDir = Input.GetAxis("Vertical");
            if (vertDir > 0)
            {
                anim.SetFloat("Direction", 1);
                anim.SetFloat("Speed", vertDir);
            }
            else if (vertDir < 0)
            {
                anim.SetFloat("Direction", -1);
                anim.SetFloat("Speed", Mathf.Abs(vertDir));
            }
            horzDir = Input.GetAxis("Horizontal");
            var turnDir = new Vector3(0, Input.GetAxis("Horizontal"), 0);
            transform.Rotate(turnDir * speed * Time.deltaTime);
            transform.GetChild(0).gameObject.SetActive(false);
            MapPosition(camera.transform, transform);

        }
    }
    void MapPosition(Transform target, Transform rigTransform)
    {
        target.position = new Vector3(rigTransform.position.x, target.position.y, rigTransform.position.z);
        target.rotation = rigTransform.rotation;
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRippleEffect : MonoBehaviour
{
    public ParticleSystem ripple;
    public GameObject RippleCamera;
    public GameObject MainCamera;
    [SerializeField] private float VelocityXZ, VelocityY;

    private Vector3 PlayerPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        VelocityXZ = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(PlayerPos.x, 0, PlayerPos.z));
        VelocityY = Vector3.Distance(new Vector3(0, transform.position.y, 0), new Vector3(0, PlayerPos.y, 0));
        PlayerPos = transform.position;

        RippleCamera.transform.position = transform.position + Vector3.up * 10;
        Shader.SetGlobalVector("_Player", transform.position);
    }

    void CreateRipple(int Start, int End, int Delta, float Speed, float Size, float Lifetime)
    {
        Vector3 forward = ripple.transform.eulerAngles;
        forward.y = Start;
        ripple.transform.eulerAngles = forward;

        for (int i = Start; i < End; i += Delta)
        {
            ripple.Emit(transform.position + ripple.transform.forward * 0.5f, ripple.transform.forward * Speed, Size, Lifetime, Color.white);
            ripple.transform.eulerAngles += Vector3.up * Delta;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 4 && VelocityY > 0.03f)
        {
            CreateRipple(-180, 180, 3, 2, 2, 2);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 4 && VelocityXZ > 0.02f && Time.renderedFrameCount % 5 == 0)
        {
            int y = (int)transform.eulerAngles.y;
            CreateRipple(y - 100, y + 100, 3, 5.4f, 2, 1.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 4 && VelocityY > 0.03f)
        {
            CreateRipple(-180, 180, 3, 2, 2, 2);
        }
    }
}
using UnityEngine;
using System.Collections;

public class ArcadeCarScript : MonoBehaviour
{
    public float m_acceleration = 10.0f;
    public float m_maxSpeed = 30.0f;
    public float m_airResistance = 1.0f;
    public float m_friction = 5.0f;
    public float m_breakFriction = 15.0f;
    public float m_maxWheelAngle = 35.0f;
    public float m_twistSpeed = 35.0f;
    public float m_flipSpeed = 35.0f;

    public float m_controlledVelocity;
    private bool m_offGround;

    public Transform[] m_wheels = new Transform[4];
    private int m_wheelCount;
    private int m_wheelsOnGround;

    private Vector3 m_lastGroundedDir;

    private Rigidbody m_rb;
    private float m_wheelAngle;
	// Use this for initialization
	void Start ()
    {
        m_rb = GetComponent<Rigidbody>();
        Debug.Assert(m_rb, "Rigidbody component not found");
        m_offGround = false;
        m_wheelsOnGround = 0;
        m_wheelCount = m_wheels.Length;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        IsInAir();
        ApplyFriction();
        if (m_offGround && m_wheelsOnGround != 0)
        {
            ManeuverOffGround();
        }
        else if(m_wheelsOnGround == m_wheelCount)
        {
            Accelerate();
            TurnWheels();
            m_lastGroundedDir = transform.forward;
        }
        Vector3 newPosition = transform.position + m_controlledVelocity * Time.fixedDeltaTime * m_lastGroundedDir;
        m_rb.MovePosition(newPosition);
    }

    void IsInAir()
    {
        m_offGround = true;
        m_wheelsOnGround = 0;
        foreach(Transform t in m_wheels)
        {
            RaycastHit[] results;
            results = Physics.RaycastAll(t.position, -transform.up, 1.1f);
            foreach(RaycastHit col in results)
            {
                if (col.transform.gameObject.tag != "wheel")
                {
                    m_offGround = false;
                    m_wheelsOnGround += 1;
                    Debug.Log(col.transform.gameObject.name);
                    break;
                }
            }
        }
    }

    void ManeuverOffGround()
    {
        float twist = Input.GetAxis("Horizontal") * m_twistSpeed;
        float flip = Input.GetAxis("Vertical") * m_flipSpeed;
        Quaternion rot = m_rb.rotation;
        Vector3 eRot = rot.eulerAngles;
        eRot.x += flip * Time.fixedDeltaTime;
        eRot.z -= twist * Time.fixedDeltaTime;
        rot.eulerAngles = eRot;
        m_rb.MoveRotation(rot);
    }

    void ApplyFriction()
    {
        float friction = m_friction;
        if (Input.GetButton("Jump"))
        {
            friction = m_breakFriction;
        }
        if(m_offGround)
        {
            friction = m_airResistance;
        }
        if (m_controlledVelocity != 0.0f)
        {
            float directionMultiplier = m_controlledVelocity / Mathf.Abs(m_controlledVelocity); //1 if pos -1 if neg
            m_controlledVelocity -= friction * Time.fixedDeltaTime * directionMultiplier;
            if (directionMultiplier == 1 && m_controlledVelocity < 0)
            {
                m_controlledVelocity = 0;
            }
            if (directionMultiplier == -1 && m_controlledVelocity > 0)
            {
                m_controlledVelocity = 0;
            }
        }
    }

    void Accelerate()
    {
        float thrustInput = Input.GetAxis("Vertical");
        m_controlledVelocity += thrustInput * m_acceleration * Time.fixedDeltaTime;
        if (m_controlledVelocity > m_maxSpeed)
        {
            m_controlledVelocity = m_maxSpeed;
        }
        if (m_controlledVelocity < -m_maxSpeed)
        {
            m_controlledVelocity = -m_maxSpeed;
        }
    }

    void TurnWheels()
    {
        m_wheelAngle = Input.GetAxis("Horizontal") * m_maxWheelAngle;
        if (m_controlledVelocity != 0.0f)
        {
            Vector3 rotation = m_rb.rotation.eulerAngles;
            float wheelRelRot = rotation.y + m_wheelAngle;
            float rot = rotation.y;
            rot += m_controlledVelocity / (Mathf.PI * 2) *  m_wheelAngle * Time.fixedDeltaTime;    //just throw a pi in there somewhere lul
            rotation.y = rot;
            Quaternion qRot = m_rb.rotation;
            qRot.eulerAngles = rotation;
            m_rb.MoveRotation(qRot);
        }
    }
}

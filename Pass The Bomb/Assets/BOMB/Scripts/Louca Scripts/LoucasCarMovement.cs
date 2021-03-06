﻿using UnityEngine;
using System.Collections;

namespace GCSharp
{
    public class LoucasCarMovement : MonoBehaviour
    {

        public GameObject m_rewindManager;
        private Rigidbody rb;

        public float idealRPM = 500f;
        public float maxRPM = 1000f;

        public Transform centerOfGravity;

        public WheelCollider wheelFR;
        public WheelCollider wheelFL;
        public WheelCollider wheelRR;
        public WheelCollider wheelRL;

        public float turnRadius = 6f;
        public float torque = 25f;
        public float brakeTorque = 100f;

        public float rotLimit;

        public float AntiRoll = 20000.0f;

        public enum DriveMode { Front, Rear, All };
        public DriveMode driveMode = DriveMode.Rear;

        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = centerOfGravity.localPosition;
        }

        public float Speed()
        {
            return wheelRR.radius * Mathf.PI * wheelRR.rpm * 60f / 1000f;
        }

        public float Rpm()
        {
            return wheelRL.rpm;
        }

        void FixedUpdate()
        {
            if (m_rewindManager.GetComponent<RewindManager>().GetMode() == RewindManager.Mode.Record)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
                Movement();
            }
            else if (m_rewindManager.GetComponent<RewindManager>().GetMode() == RewindManager.Mode.Rewind)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }
        }

        void Movement()
        {
            float scaledTorque = -Input.GetAxis("Vertical") * torque;

            if (wheelRL.rpm < idealRPM)
            {
                scaledTorque = Mathf.Lerp(scaledTorque / 10f, scaledTorque, wheelRL.rpm / idealRPM);
            }
            else
            {
                scaledTorque = Mathf.Lerp(scaledTorque, 0, (wheelRL.rpm - idealRPM) / (maxRPM - idealRPM));
            }

            DoRollBar(wheelFR, wheelFL);
            DoRollBar(wheelRR, wheelRL);

            wheelFR.steerAngle = Input.GetAxis("Horizontal") * turnRadius;
            wheelFL.steerAngle = Input.GetAxis("Horizontal") * turnRadius;

            transform.Rotate(0.0f, wheelFL.steerAngle / rotLimit, 0.0f);

            wheelFR.motorTorque = driveMode == DriveMode.Rear ? 0 : scaledTorque;
            wheelFL.motorTorque = driveMode == DriveMode.Rear ? 0 : scaledTorque;
            wheelRR.motorTorque = driveMode == DriveMode.Front ? 0 : scaledTorque;
            wheelRL.motorTorque = driveMode == DriveMode.Front ? 0 : scaledTorque;

            if (Input.GetButton("Fire1"))
            {
                wheelFR.brakeTorque = brakeTorque;
                wheelFL.brakeTorque = brakeTorque;
                wheelRR.brakeTorque = brakeTorque;
                wheelRL.brakeTorque = brakeTorque;
            }
            else
            {
                wheelFR.brakeTorque = 0;
                wheelFL.brakeTorque = 0;
                wheelRR.brakeTorque = 0;
                wheelRL.brakeTorque = 0;
            }
        }

        void DoRollBar(WheelCollider WheelL, WheelCollider WheelR)
        {
            WheelHit hit;
            float travelL = 1.0f;
            float travelR = 1.0f;

            bool groundedL = WheelL.GetGroundHit(out hit);
            if (groundedL)
            {
                travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y - WheelL.radius) / WheelL.suspensionDistance;
            }

            bool groundedR = WheelR.GetGroundHit(out hit);
            if (groundedR)
            {
                travelR = (-WheelR.transform.InverseTransformPoint(hit.point).y - WheelR.radius) / WheelR.suspensionDistance;
            }

            float antiRollForce = (travelL - travelR) * AntiRoll;

            if (groundedL)
            {
                rb.AddForceAtPosition(WheelL.transform.up * -antiRollForce, WheelL.transform.position);
            }
            if (groundedR)
            {
                rb.AddForceAtPosition(WheelR.transform.up * antiRollForce, WheelR.transform.position);
            }
        }

        public void SetRewindManager(GameObject _rewindManager)
        {
            m_rewindManager = _rewindManager;
        }
    }
}
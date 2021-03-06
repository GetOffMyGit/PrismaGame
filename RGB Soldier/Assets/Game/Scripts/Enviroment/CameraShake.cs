﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Scripts.Enviroment
{
    /// <summary>
    /// Used when the special attack is started. Shakes the camera
    /// </summary>
    class CameraShake : MonoBehaviour
    {
        // Transform of the camera to shake. Grabs the gameObject's transform
        // if null.
        public Transform camTransform;

        // How long the object should shake for.
        public float shake = 0f;

        // Amplitude of the shake. A larger value shakes the camera harder.
        public float shakeAmount = 0.1f;
        public float decreaseFactor = 1.0f;

        Vector3 originalPos;

        void Awake()
        {
            if (camTransform == null)
            {
                camTransform = GetComponent(typeof(Transform)) as Transform;
            }
        }

        void OnEnable()
        {
            originalPos = camTransform.localPosition;
        }

        void Update()
        {
			if (GameManager.instance.isPaused ())
				return;
            if (shake > 0)
            {
                camTransform.localPosition = originalPos + UnityEngine.Random.insideUnitSphere * shakeAmount;

                shake -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shake = 0f;
                camTransform.localPosition = originalPos;
                Camera.main.GetComponent<CameraShake>().enabled = false;

            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {
    private Vector3 targetPosition;
    private float moveMagnitude = 4f;
    private const float StoppingDistance = 0.01f;

    void Update() {
        var distanceToGo = Math.Abs(Vector3.Distance(targetPosition, transform.position));
        if (distanceToGo > StoppingDistance) {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position +=  Time.deltaTime * moveMagnitude * moveDirection;
        }
        
        if (Input.GetKeyDown(KeyCode.T)) {
            Move(new Vector3(4, 0, 4));
        }
    }

    private void Move(Vector3 position) {
        this.targetPosition = position;
    }
}

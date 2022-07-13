using System;
using Unity.VisualScripting;
using UnityEngine;

public class UnitController : MonoBehaviour {
    private Vector3 targetPosition;
    private float moveMagnitude = 4f;
    private const float StoppingDistance = 0.01f;
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;

    void Update() {
        var distanceToGo = Math.Abs(Vector3.Distance(targetPosition, transform.position));
        if (distanceToGo > StoppingDistance) {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position +=  Time.deltaTime * moveMagnitude * moveDirection;
        }
        
        if (Input.GetMouseButtonDown(LeftMouseButton)) {
            Move(MouseWorld.GetPosition());
        }
    }

    private void Move(Vector3 position) {
        this.targetPosition = position;
    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;

public class UnitController : MonoBehaviour {
    [SerializeField] private Animator unitAnimator; 
    private Vector3 targetPosition;
    private float moveMagnitude = 4f;
    private const float StoppingDistance = 0.01f;
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    void Update() {
        ReadInput();
        MoveIfNecessary();
    }

    private void MoveIfNecessary() {
        var distanceToGo = Math.Abs(Vector3.Distance(targetPosition, transform.position));
        if (distanceToGo > StoppingDistance) {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += Time.deltaTime * moveMagnitude * moveDirection;
            unitAnimator.SetBool(IsWalking, true);
        } else {
            unitAnimator.SetBool(IsWalking, false);
        }
    }

    private void ReadInput() {
        if (Input.GetMouseButtonDown(LeftMouseButton)) {
            Move(MouseWorld.GetPosition());
        }
    }

    private void Move(Vector3 position) {
        this.targetPosition = position;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedIndicator : MonoBehaviour {
    [SerializeField] private UnitController unit;
    private MeshRenderer meshRenderer;

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
    }
}

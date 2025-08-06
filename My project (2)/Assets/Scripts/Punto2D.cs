using UnityEngine;
using System;
using Unity.VisualScripting;

namespace PackagePunto2D
{
    [Serializable]

    public class Punto2D
{
        [SerializeField] private double X;
        [SerializeField] private double Y;

        public Punto2D()
        {
        }

        public Punto2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X1 { get => X; set => X = value; }
        public double Y1 { get => Y; set => Y = value; }
    }
}
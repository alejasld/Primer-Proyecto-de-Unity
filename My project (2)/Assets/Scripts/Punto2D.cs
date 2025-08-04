using UnityEngine;
using System;
using Unity.VisualScripting;

namespace PackagePunto2D
{
    [Serializable]

    public class Punto2D
{
        private double X;
        private double Y;

        public Punto2D()
        {
        }

        public Punto2D(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
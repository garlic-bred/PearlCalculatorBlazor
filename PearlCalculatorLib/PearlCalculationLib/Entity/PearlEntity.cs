﻿using PearlCalculatorLib.PearlCalculationLib.World;
using System;

namespace PearlCalculatorLib.PearlCalculationLib.Entity
{
    [Serializable]
    public class PearlEntity : Entity , ICloneable
    {
        public override Space3D Size => new Space3D(0.25, 0.25, 0.25);

        public PearlEntity(Space3D momemtum, Space3D position)
        {
            this.Motion = momemtum;
            this.Position = position;
        }

        public PearlEntity(PearlEntity pearl) : this(pearl.Motion , pearl.Position) { }

        public PearlEntity()
        {
        }

        public PearlEntity WithPosition(double x , double y , double z)
        {
            this.Position = new Space3D(x , y , z);
            return this;
        }

        public PearlEntity WithVector(double x , double y , double z)
        {
            this.Motion = new Space3D(x , y , z);
            return this;
        }

        public override void Tick()
        {
            Position += Motion;
            Motion *= 0.99;
            Motion.Y -= 0.03;
        }

        public object Clone()
        {
            PearlEntity pearl = new PearlEntity
            {
                Position = this.Position,
                Motion = this.Motion
            };
            return pearl;
        }
    }
}

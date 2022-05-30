﻿using System;
using UnityEngine; // For color

namespace SystemView
{
    public class ShipWeaponProjectile
    {
        public OrbitingObjectDescriptor Descriptor;

        public SystemShip Self;
        public ShipWeapon Weapon;

        public float PosX, PosY;

        public float Slope;
        public bool NegativeDirection;

        public float DistanceTravelled;
        public float Range;

        public Color ProjectileColor;

        public float ShieldPenetration;

        public float ProjectileVelocity;

        public int Damage;

        public bool UpdatePosition(float dt)
        {
            float d = dt * ProjectileVelocity;

            if((DistanceTravelled += d) > Range)
            {
                Weapon.ProjectilesFired.Remove(this);
                return false;
            }

            if (Descriptor == null) // Linear trajectory
            {
                // (1) dy = m * dx

                // (2) dy^2 + dx^2 = d^2

                //                                              d
                // (3) (m^2 + 1) * dx^2 = d^2   =>   x = ± -----------
                //                                         √ (m^2 + 1)

                float dx = d / (float)Math.Sqrt(Slope * Slope + 1) * (NegativeDirection ? -1 : 1);

                PosX += dx;
                PosY += dx * Slope;
            }
            else // Orbital trajectory
            {
                Descriptor.RotationalPosition += dt / Descriptor.GetDistanceFromCenter() / Descriptor.GetDistanceFromCenter();

                float[] Pos = Descriptor.GetPosition();

                PosX = Pos[0];
                PosY = Pos[1];
            }

            return true;
        }

        public bool InRangeOf(SystemShip Target)
        {
            return Math.Sqrt((PosX - Target.PosX) * (PosX - Target.PosX) + (PosY - Target.PosY) * (PosY - Target.PosY)) < 0.25;
        }

        public void DoDamage(SystemShip Target)
        {
            // todo
        }
    }
}

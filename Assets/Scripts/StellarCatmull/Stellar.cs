using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Assets.Scripts.Stellar
{
    public class Stellar : MonoBehaviour
    {

        public Vector3[] Points;

        public float m_fDis;

        [SerializeField]
        Vector3[] m_vConstans;

        void Reset()
        {
            Points = new Vector3[]{
                new Vector3(0f, 0f, 0f),
                new Vector3(8f, 0f, 0f),
                new Vector3(16f, 0f, 0f),
                new Vector3(24f, 0f, 0f)
            };

            m_vConstans = new Vector3[3];

        }

        public Vector3 Interp(float t)
        {
            int index = 0;
            if (t >= 1)
            {
                t = 1;
                index = Points.Length - 4;
            }
            else
            {
                t = t * (Points.Length - 3);
                index = (int)t;
                t = t - index;
            }

            m_vConstans[0] = 3 * (StellarInterface.r * (-Points[index] + ((2 - StellarInterface.r) / StellarInterface.r) * Points[index + 1] + ((StellarInterface.r - 2) / StellarInterface.r) * Points[index + 2] + Points[index + 3]));
            m_vConstans[1] = 2 * (StellarInterface.r * (2 * Points[index] + ((StellarInterface.r - 3) / StellarInterface.r) * Points[index + 1] + ((3 - 2 * StellarInterface.r) / StellarInterface.r) * Points[index + 2] - Points[index + 3]));
            m_vConstans[2] = StellarInterface.r * (Points[index + 2] - Points[index]);

            return transform.TransformPoint(StellarInterface.Interp(Points[index], Points[index + 1], Points[index + 2], Points[index + 3], t));
        }



        public Vector3 Velocity(float t)
        {
            int index = 0;
            if (t >= 1)
            {
                t = 1;
                index = Points.Length - 4;
            }
            else
            {
                t = t * (Points.Length - 3); // t <1, 任何小于1的浮点数相乘，那么取整后，都会变成 n - 1.
                index = (int)t;
                t = t - index;
            }

          

            return transform.TransformPoint(StellarInterface.Velocity(Points[index], Points[index + 1], Points[index + 2], Points[index + 3], t)) - transform.position;
        }

        public Vector3 GetDir(float t)
        {
            return Velocity(t).normalized;
        }


        public float GetDeltaT (float t) {
               int index = 0;
            if (t >= 1)
            {
                t = 1;
                index = Points.Length - 4;
            }
            else
            {
                t = t * (Points.Length - 3); // t <1, 任何小于1的浮点数相乘，那么取整后，都会变成 n - 1.
                index = (int)t;
                t = t - index;
            }

            return m_fDis / Vector3.Magnitude (m_vConstans[0] * t * t + m_vConstans[1] * t + m_vConstans[2]);

        }

        public void AddPoint()
        {
            Vector3 pos = Points[Points.Length - 1];
            Array.Resize(ref Points, Points.Length + 3);
            pos.x += 8;
            Points[Points.Length - 3] = pos;
            pos.x += 8;
            Points[Points.Length - 2] = pos;
            pos.x += 8;
            Points[Points.Length - 1] = pos;
        }

        public void ResetPoints()
        {

            Vector3[] newpoints = new Vector3[4];

            for (int i = 0; i < 3; i++)
            {
                newpoints[i] = Points[i + 1];
            }
            Vector3 pos = Points[Points.Length - 1];
            pos.x += 8;
            newpoints[3] = pos;

            Points = newpoints;


            //Vector3 pos = Points[Points.Length - 1];
            //Array.Resize(ref Points, 4);
            //Points[Points.Length - 4] = pos;
            //pos.x += 8;
            //Points[Points.Length - 3] = pos;
            //pos.x += 8;
            //Points[Points.Length - 2] = pos;
            //pos.x += 8;
            //Points[Points.Length - 1] = pos;
        }
    }
}


//public void GizmoDraw(Vector3[] source, float t)
//{
//    Gizmos.color = Color.white;
//    Vector3 prevPt = Interp(source, 0);

//    for (int i = 1; i <= 40; i++)
//    {
//        float pm = (float)i / 40f;
//        Vector3 currPt = Interp(source, pm);
//        Gizmos.DrawLine(currPt, prevPt);
//        prevPt = currPt;
//    }

//    Gizmos.color = Color.blue;
//    Vector3 pos = Interp(source, t);
//    Gizmos.DrawLine(pos, pos + Velocity(source, t).normalized);
//}

//public Vector3[] InitializePathPoints(Transform points)
//        {
//            Vector3[] source = new Vector3[points.childCount];
//            for (int i = 0; i < source.Length; i++)
//            {
//                source[i] = points.GetChild(i).position;
//            }

//            Vector3[] outputs = new Vector3[source.Length + 2];

//            Array.Copy(source, 0, outputs, 1, source.Length);

//            outputs[0] = outputs[1] + outputs[1] - outputs[2];

//            outputs[outputs.Length - 1] = outputs[outputs.Length - 2] + outputs[outputs.Length - 2] - outputs[outputs.Length - 3];


//            m_bIsInitializePoints = true;

//            return outputs;
//        }

//public Vector3 Interp(Vector3[] source, float per) 
//{

//    int numSections = source.Length - 3;
//    int currPt = Mathf.Min(Mathf.FloorToInt(per * (float)numSections), numSections - 1);

//    float u = per * (float)numSections - (float)currPt;
//    if (currPt < 0 || currPt > source.Length)
//    {
//        return Vector3.zero;
//    }
//    Vector3 a = source[currPt];
//    Vector3 b = source[currPt + 1];
//    Vector3 c = source[currPt + 2];
//    Vector3 d = source[currPt + 3];

//    return 0.5f * (
//        (-a + 3f * b - 3f * c + d) * (u * u * u)
//        + (2f * a - 5f * b + 4f * c - d) * (u * u)
//        + (-a + c) * u
//        + 2f * b
//    );
//}

        //public  Vector3 Velocity(Vector3[] source, float t)
        //{
        //    int numSections = source.Length - 3;
        //    int currPt = Mathf.Min(Mathf.FloorToInt(t * (float)numSections), numSections - 1);
        //    float u = t * (float)numSections - (float)currPt;

        //    Vector3 a = source[currPt];
        //    Vector3 b = source[currPt + 1];
        //    Vector3 c = source[currPt + 2];
        //    Vector3 d = source[currPt + 3];

        //    return 1.5f * (-a + 3f * b - 3f * c + d) * (u * u)
        //            + (2f * a - 5f * b + 4f * c - d) * u
        //            + .5f * c - .5f * a;
        //}

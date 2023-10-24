using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotController
{

    public struct MyQuat
    {

        public float w;
        public float x;
        public float y;
        public float z;
    }

    public struct MyVec
    {

        public float x;
        public float y;
        public float z;
    }


    



    public class MyRobotController
    {

        #region public methods


        public string Hi()
        {

            string s = "hello world from my Robot Controller";
            return s;

        }


        //EX1: this function will place the robot in the initial position

        public void PutRobotStraight(out MyQuat rot0, out MyQuat rot1, out MyQuat rot2, out MyQuat rot3) {

            //todo: change this, use the function Rotate declared below
            rot0 = NullQ;
            rot0 = Rotate(rot0, GetAxis(0,1,0), 72);//72
            rot1 = Rotate(rot0, GetAxis(1, 0, 0), -12.21f);
            rot2 = Rotate(rot1, GetAxis(1, 0, 0), 81.2f);
            rot3 = Rotate(rot2, GetAxis(1, 0, 0), 40f);//35.7f
        }



        //EX2: this function will interpolate the rotations necessary to move the arm of the robot until its end effector collides with the target (called Stud_target)
        //it will return true until it has reached its destination. The main project is set up in such a way that when the function returns false, the object will be droped and fall following gravity.


        public bool PickStudAnim(out MyQuat rot0, out MyQuat rot1, out MyQuat rot2, out MyQuat rot3)
        {

            bool myCondition = false;
            //todo: add a check for your condition



            if (myCondition)
            {
                //todo: add your code here
                rot0 = NullQ;
                rot1 = NullQ;
                rot2 = NullQ;
                rot3 = NullQ;


                return true;
            }

            //todo: remove this once your code works.
            rot0 = NullQ;
            rot1 = NullQ;
            rot2 = NullQ;
            rot3 = NullQ;

            return false;
        }


        //EX3: this function will calculate the rotations necessary to move the arm of the robot until its end effector collides with the target (called Stud_target)
        //it will return true until it has reached its destination. The main project is set up in such a way that when the function returns false, the object will be droped and fall following gravity.
        //the only difference wtih exercise 2 is that rot3 has a swing and a twist, where the swing will apply to joint3 and the twist to joint4

        public bool PickStudAnimVertical(out MyQuat rot0, out MyQuat rot1, out MyQuat rot2, out MyQuat rot3)
        {

            bool myCondition = false;
            //todo: add a check for your condition



            while (myCondition)
            {
                //todo: add your code here


            }

            //todo: remove this once your code works.
            rot0 = NullQ;
            rot1 = NullQ;
            rot2 = NullQ;
            rot3 = NullQ;

            return false;
        }


        public static MyQuat GetSwing(MyQuat rot3)
        {
            //todo: change the return value for exercise 3
            return NullQ;

        }


        public static MyQuat GetTwist(MyQuat rot3)
        {
            //todo: change the return value for exercise 3
            return NullQ;

        }




        #endregion


        #region private and internal methods

        internal int TimeSinceMidnight { get { return (DateTime.Now.Hour * 3600000) + (DateTime.Now.Minute * 60000) + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; } }


        private static MyQuat NullQ
        {
            get
            {
                MyQuat a;
                a.w = 1;
                a.x = 0;
                a.y = 0;
                a.z = 0;
                return a;

            }
        }

        internal MyQuat Multiply(MyQuat q1, MyQuat q2) {

            //todo: change this so it returns a multiplication:
            MyQuat result;
            result.w = q1.w * q2.w - q1.x * q2.x - q1.y * q2.y - q1.z * q2.z;
            result.x = q1.w * q2.x + q1.x * q2.w + q1.y * q2.z - q1.z * q2.y;
            result.y = q1.w * q2.y - q1.x * q2.z + q1.y * q2.w + q1.z * q2.x;
            result.z = q1.w * q2.z + q1.x * q2.y - q1.y * q2.x + q1.z * q2.w;
            return result;
        }

        internal MyQuat Rotate(MyQuat currentRotation, MyVec axis, float angle)
        {

            //todo: change this so it takes currentRotation, and calculate a new quaternion rotated by an angle "angle" radians along the normalized axis "axis"
            MyQuat rot;
            rot = VecToQuat(axis);
            rot.w = (float)Math.Cos(AngleToRadian(angle / 2f));
            rot.x *= (float)Math.Sin(AngleToRadian(angle / 2f));
            rot.y *= (float)Math.Sin(AngleToRadian(angle / 2f));
            rot.z *= (float)Math.Sin(AngleToRadian(angle / 2f));
            return Normalize(Multiply(currentRotation, rot));
        }       

        MyQuat Conjugate(MyQuat q1)
        {
            MyQuat result;
            result.w = q1.w;
            result.x = -q1.x;
            result.y = -q1.y;
            result.z = -q1.z;

            return result;
        }

        MyQuat Normalize(MyQuat q)
        {
            float result;
            result = (float)Math.Sqrt(Math.Pow(q.w, 2) + Math.Pow(q.x, 2) + Math.Pow(q.y, 2) + Math.Pow(q.z, 2));
            MyQuat result2;
            result2.w = q.w;
            result2.x = q.x / result;
            result2.y = q.y / result;
            result2.z = q.z / result;

            return result2;
        }

        MyQuat VecToQuat(MyVec myVec)
        {
            MyQuat result;
            result.w = 0;
            result.x = myVec.x;
            result.y = myVec.y;
            result.z = myVec.z;
            return result;
        }

        float AngleToRadian(float angle)
        {
            return (float)((float)angle * Math.PI / 180);
        }

        MyVec GetAxis(float x, float y, float z)
        {
            MyVec result;
            result.x = x;
            result.y = y;
            result.z = z;
            return result;
        }

        //todo: add here all the functions needed

        #endregion






    }
}

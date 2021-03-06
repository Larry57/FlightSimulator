// --------------------------------------------------------------------------------------------------
// This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
// Version 1.3.6.20110331_01     
// 11/05/19 19:45    
// ${CustomMessageForDisclaimer}                                                                             
// --------------------------------------------------------------------------------------------------
namespace FlightSimulator
{


    using Jp.Maker1.Vsys3.Tools;
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class DrawArrangement
    {
        public DrawArrangement()
        {
            PLAN_X0 = 450.0D;
            PLAN_Y0 = 200.0D;
            S_ELEVATION_X0 = 250.0D;
            S_ELEVATION_Y0 = 200.0D;
            F_ELEVATION_X0 = 100.0D;
            F_ELEVATION_Y0 = 200.0D;
            DISP_SCALE = 15.0D;
        }

        public double PLAN_X0;
        public double PLAN_Y0;
        public double S_ELEVATION_X0;
        public double S_ELEVATION_Y0;
        public double F_ELEVATION_X0;
        public double F_ELEVATION_Y0;
        public double DISP_SCALE;

        internal int P_x(double y)
        {
            return (int)(PLAN_X0 + DISP_SCALE * y);
        }

        internal int P_y(double x)
        {
            return (int)(PLAN_Y0 - DISP_SCALE * x);
        }

        internal int Se_x(double z)
        {
            return (int)(S_ELEVATION_X0 + DISP_SCALE * z);
        }

        internal int Se_y(double x)
        {
            return (int)(S_ELEVATION_Y0 - DISP_SCALE * x);
        }

        internal int Fe_x(double z)
        {
            return (int)(F_ELEVATION_X0 + DISP_SCALE * z);
        }

        internal int Fe_y(double y)
        {
            return (int)(F_ELEVATION_Y0 - DISP_SCALE * y);
        }

        public void DrawVector(Graphics g, Vector3D p, Vector3D v, String str)
        {
            //g.DrawLine(P_x(p.y), P_y(p.x), P_x(p.y + v.y), P_y(p.x + v.x));
            //g.DrawString(str, P_x(p.y + v.y), P_y(p.x + v.x) - 4);

            //g.DrawLine(Se_x(p.z), Se_y(p.x), Se_x(p.z + v.z), Se_y(p.x + v.x));
            //g.DrawString(str, Se_x(p.z + v.z), Se_y(p.x + v.x) - 4);

            //g.DrawLine(Fe_x(p.z), Fe_y(p.y), Fe_x(p.z + v.z), Fe_y(p.y + v.y));
           // g.DrawString(str, Fe_x(p.z + v.z), Fe_y(p.y + v.y) - 4);
        }

        public void DrawAxis(Graphics g, double length)
        {
            Vector3D orig = new Vector3D(0.0D, 0.0D, 0.0D);
            Vector3D axis = new Vector3D(1.0D, 0.0D, 0.0D).SclProd(length);
            DrawVector(g, orig, axis, "x");
            axis = new Vector3D(0.0D, 1.0D, 0.0D).SclProd(length);
            DrawVector(g, orig, axis, "y");
            axis = new Vector3D(0.0D, 0.0D, 1.0D).SclProd(length);
            DrawVector(g, orig, axis, "z");
        }
    }
}
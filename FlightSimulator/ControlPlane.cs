
    using Jp.Maker1.Vsys3.Tools;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;

public class ControlPlane
{
    public ControlPlane()
    {
        type = 0;
        actuate_type = 0;
        flap_type = 0;
        baseWingBlock = new WingPlane();
        t_move = 0.0D;
        d_fv = new Vector3D();
        d_tv = new Vector3D();
    }

    public int type;
    public int actuate_type;
    public double delta_max;
    public double delta_min;
    public double lamda_h;
    public double gamma_h;
    public Vector3D hc;
    public int flap_type;
    public double cf_c;
    public double dCLmax;
    public WingPlane baseWingBlock;
    public double t_move;
    public double f_lamda1;
    public double b_lamda1;
    public double f_cmac;
    public double b_cmac;
    public double delta;
    internal double beta_f;
    internal double delta_dash;
    public double d_cl;
    public double d_cdi;
    public Vector3D d_fv;
    public Vector3D d_tv;

    public void Init()
    {
        if (type == 1)
        {
            f_lamda1 = Flap.Lamda1_t_flap(cf_c);
            b_lamda1 = Flap.Lamda1_l_flap(cf_c);
            f_cmac = Flap.Cmac_t_flap(cf_c);
            b_cmac = Flap.Cmac_l_flap(cf_c);
        }
        else if (type == 1)
        {
            f_lamda1 = Flap.Lamda1_l_flap(cf_c);
            b_lamda1 = Flap.Lamda1_t_flap(cf_c);
            f_cmac = Flap.Cmac_l_flap(cf_c);
            b_cmac = Flap.Cmac_t_flap(cf_c);
        }
        else if (type == 2)
        {
            f_lamda1 = 0.0D;
            b_lamda1 = 0.0D;
            f_cmac = 0.0D;
            b_cmac = 0.0D;
            b_cmac = Flap.Cmac_t_flap(cf_c);
        }
        else
        {
            f_lamda1 = 0.0D;
            b_lamda1 = 0.0D;
            f_cmac = 0.0D;
            b_cmac = 0.0D;
        }
    }

    public void Print()
    {
        System.Console.Out.WriteLine("���Ǘ��ʌ^: " + type);
        if (type != 0)
        {
            System.Console.Out.WriteLine("�쓮�^�C�v: " + actuate_type);
            baseWingBlock.Print();
            System.Console.Out.WriteLine("�ő�Ǌp ��max [deg]: " + MathTool.RadToDeg(delta_max));
            System.Console.Out.WriteLine("�ŏ��Ǌp ��min [deg]: " + MathTool.RadToDeg(delta_min));
            System.Console.Out.WriteLine("�ݼތ�ފp ��h [rad]: " + MathTool.RadToDeg(lamda_h));
        }
        if (type == 2)
        {
            System.Console.Out.WriteLine("�ݼޏ㔽�p ��h [rad]: " + MathTool.RadToDeg(gamma_h));
            System.Console.Out.WriteLine("�ݼގ����_ Hc  [m]: " + hc.ToStringPos());
        }
        if ((type == 1) || (type == 1))
        {
            Console.Out.WriteLine("�t���b�v�`��: " + Flap.flap_type_name[flap_type]); System.Console.Out.WriteLine("�t���b�v������: " + cf_c);
            Console.Out.WriteLine("�ő�g�͌W���̑����� ��CLmax: " + dCLmax);
            Console.Out.WriteLine("�O�i���t���b�v�̌���: " + DispFormat.DoubleFormat(f_lamda1, 3));
            Console.Out.WriteLine("��i���t���b�v�̌���: " + DispFormat.DoubleFormat(b_lamda1, 3));
            Console.Out.WriteLine("�O�i���t���b�vCmac/��: " + DispFormat.DoubleFormat(f_cmac, 3));
            Console.Out.WriteLine("��i���t���b�vCmac/��: " + DispFormat.DoubleFormat(b_cmac, 3));
        }

        if ((type != 0) && (actuate_type == 1))
        {
            Console.Out.WriteLine("�W�J/�i�[���� [s]: " + t_move);
        }
        System.Console.Out.WriteLine("---------------------------------------------");
    }

    public void Update(int flap_sw, double dt)
    {
        if ((type == 0) || (t_move < 0.0D))
            return;
        if (flap_sw == -1)
        {
            delta += (delta_max - delta_min) / t_move * dt;
            if (delta > delta_max)
                delta = delta_max;
        }
        if (flap_sw == 1)
        {
            delta -= (delta_max - delta_min) / t_move * dt;
            if (delta < delta_min)
                delta = delta_min;
        }
    }

    internal void Calc_dynamics(int lr, AirPlane ap, Vector3D dv, double k_q, double k_S)
    {
        d_fv.SetVec(0.0D, 0.0D, 0.0D);
        d_tv.SetVec(0.0D, 0.0D, 0.0D);
        if (type == 0)
            return;

        baseWingBlock.Calc_dynamics(lr, null, ap, dv, k_q, k_S);
        d_cl = baseWingBlock.cl;
        d_cdi = baseWingBlock.cdi;
        Vector3D fv_base = new Vector3D(baseWingBlock.fv);
        Vector3D tv_base = new Vector3D(baseWingBlock.tv);

        baseWingBlock.Calc_dynamics(lr, this, ap, dv, k_q, k_S);
        d_cl = (baseWingBlock.cl - d_cl);
        d_cdi = (baseWingBlock.cdi - d_cdi);
        d_fv = baseWingBlock.fv.Sub(fv_base);
        d_tv = baseWingBlock.tv.Sub(tv_base);
    }
}
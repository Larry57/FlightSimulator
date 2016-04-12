// --------------------------------------------------------------------------------------------------
// This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
// Version 1.3.6.20110331_01     
// 11/05/19 19:45    
// ${CustomMessageForDisclaimer}                                                                             
// --------------------------------------------------------------------------------------------------
namespace FlightSimulator
{

    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    public class SimulatorInterface
    {
        public SimulatorInterface()
        {
            key_ctrl = Keys.Control;
            ctrl_sw = 0;
            mode = 0;
            key_pause = Keys.Escape;
            pause_sw = 0;
            key_slow = (Keys)33;
            slow_mode = 0;
            counter = 0;
            slow_count = 20;
            key_dispDynamics = (Keys)155;
            dispDynamicsSw = 0;
            key_dispInformation = (Keys)127;
            dispInformationSw = 0;
            key_dispData = (Keys)127;
            dispDataSw = 0;
            key_record_output = (Keys)8;
            record_output_sw = 0;
            key_menu = (Keys)36;
            changePlane = 0;
            changePSetting = 0;
            key_locus_disp = (Keys)35;
            key_locus_reset = (Keys)9;
            locusMake = 1;
            locusImageMake = 1;
            roll_right = 0;
            roll_left = 1;
            pitch_up = 2;
            pitch_down = 3;
            yaw_right = 4;
            yaw_left = 5;
            move_fowerd = 6;
            move_back = 7;
            move_up = 8;
            move_down = 9;
            move_right = 10;
            move_left = 11;
            key_locus_action = new Keys[] { (Keys)226, (Keys)191, (Keys)38, (Keys)40, (Keys)39, (Keys)37, (Keys)97, (Keys)96, (Keys)104, (Keys)98, (Keys)102, (Keys)100 };
            locus_action_sw = new int[12];
            key_param_reset = (Keys)10;
            key_data_foword = (Keys)33;
            key_data_back = (Keys)34;
            param_reset_sw = 1;
            data_foword_sw = 33;
            data_back_sw = 34;
        }

        public const int SIMULATION_MODE = 0;
        public const int LOCUS_DISPLAY_MODE = 1;
        public const int MENU_MODE = 2;
        public Keys key_ctrl;
        public int ctrl_sw;

        public int mode;

        public Keys key_pause;
        public int pause_sw;

        public Keys key_slow;
        public int slow_mode;
        public int counter;
        public int slow_count;

        public Keys key_dispDynamics;
        public int dispDynamicsSw;

        public Keys key_dispInformation;
        public int dispInformationSw;

        public Keys key_dispData;
        public int dispDataSw;

        public Keys key_record_output;
        public int record_output_sw;

        public Keys key_menu;
        public int changePlane;
        public int changePSetting;

        public Keys key_locus_disp;
        public Keys key_locus_reset;
        public int locusMake;
        public int locusImageMake;

        public readonly int roll_right;
        public readonly int roll_left;
        public readonly int pitch_up;
        public readonly int pitch_down;
        public readonly int yaw_right;
        public readonly int yaw_left;
        public readonly int move_fowerd;
        public readonly int move_back;
        public readonly int move_up;
        public readonly int move_down;
        public readonly int move_right;
        public readonly int move_left;
        public Keys[] key_locus_action;

        public int[] locus_action_sw;

        public Keys key_param_reset;
        public Keys key_data_foword;
        public Keys key_data_back;
        public int param_reset_sw;
        public int data_foword_sw;
        public int data_back_sw;

        public int Check_locus_action_sw()
        {
            int ret = 0;
            for (int i = 0; i < locus_action_sw.Length; i++)
            {
                ret += locus_action_sw[i];
            }
            return ret;
        }
    }
}
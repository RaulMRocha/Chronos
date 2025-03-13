using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Modules.DownTime.Model
{
    public static class DownTime_Default
    {
        public static readonly Color ScreenColor = Color.White;
        public static readonly bool StatusLabelVisible = false;
        public static readonly string StatusLabelText = "";
        public static readonly bool ReasonLabelVisible = false;
        public static readonly bool ElapsedLabelVisible = false;
        public static readonly Color InstructionLabelColor = Color.DarkGreen;
        public static readonly string InstructionLabelText = "Ingresar el código del tiempo perdido";
        public static readonly string ActionButtonText = "Salir";
        public static readonly Color ActionButtonColor = Color.DarkGreen;
    }


    public static class DownTime_Open
    {
        public static readonly Color ScreenColor = Color.DarkRed;
        public static readonly bool StatusLabelVisible = true;
        public static readonly string StatusLabelText = "Tiempo Perdido No Atendido";
        public static readonly bool ReasonLabelVisible = true;
        public static readonly bool ElapsedLabelVisible = true;
        public static readonly Color InstructionLabelColor = Color.White;
        public static readonly string InstructionLabelText = "Ingresar credencial del depto. de soporte";
        public static readonly string ActionButtonText = "Cancelar";
        public static readonly Color ActionButtonColor = Color.Gray;
    }


    public static class DownTime_Attend
    {
        public static readonly Color ScreenColor = Color.MidnightBlue;
        public static readonly bool StatusLabelVisible = true;
        public static readonly string StatusLabelText = "Tiempo Perdido Atendido";
        public static readonly bool ReasonLabelVisible = true;
        public static readonly bool ElapsedLabelVisible = true;
        public static readonly Color InstructionLabelColor = Color.White;
        public static readonly string InstructionLabelText = "Ingresar credencial del depto. de soporte";
        public static readonly string ActionButtonText = "Cancelar";
        public static readonly Color ActionButtonColor = Color.Gray;
    }
    public static class DownTime_Close
    {
        public static readonly Color ScreenColor = Color.White;
        public static readonly bool StatusLabelVisible = false;
        public static readonly string StatusLabelText = "";
        public static readonly bool ReasonLabelVisible = false;
        public static readonly bool ElapsedLabelVisible = false;
        public static readonly Color InstructionLabelColor = Color.White;
        public static readonly string InstructionLabelText = "Ingresar el código del tiempo perdido";
        public static readonly string ActionButtonText = "Salir";
        public static readonly Color ActionButtonColor = Color.DarkGreen;
    }


}

using System.Runtime.InteropServices;

namespace Chronos.Machinery.AndonLights
{
    public class AndonLights
    {
        [DllImport("Ux64_dllc.dll")]
        public static extern void Usb_Qu_Open();
        [DllImport("Ux64_dllc.dll")]
        public static extern void Usb_Qu_Close();
        [DllImport("Ux64_dllc.dll")]
        public static unsafe extern bool Usb_Qu_write(byte Q_index, byte Q_type, byte* pQ_data);
        [DllImport("Ux64_dllc.dll")]
        public static extern int Usb_Qu_Getstate();

        private const byte _off = 0;
        private const byte _on = 1;
        private const byte _blink = 2;
        private const byte _dontCare = 100;  //  // Don't care  // Do not change before state

        public AndonLights()
        {

        }
        
        public bool IsConnected()
        {
            int i;

            i = Usb_Qu_Getstate();

            if (((i & 0x01) == 1) || ((i & 0x02) == 2) || ((i & 0x04) == 4) || ((i & 0x08) == 8))
                return true;
            else
                return false;
        }

        unsafe public bool TurnRedLightOn(bool Blink)
        {
            bool bchk = false;
            byte* bbb = stackalloc byte[6];

            bbb[0] = Blink ? _blink : _on;
            bbb[1] = _dontCare;
            bbb[2] = _dontCare;
            bbb[3] = _dontCare;
            bbb[4] = _dontCare;
            bbb[5] = _dontCare; // sound select


            bchk = Usb_Qu_write(0, 0, bbb);

            return bchk;
        }

        unsafe public bool TurnRedLightOff()
        {
            bool bchk = false;
            byte* bbb = stackalloc byte[6];

            bbb[0] = _off;
            bbb[1] = _dontCare;
            bbb[2] = _dontCare;
            bbb[3] = _dontCare;
            bbb[4] = _dontCare;
            bbb[5] = _dontCare; // sound select


            bchk = Usb_Qu_write(0, 0, bbb);

            return bchk;
        }

        unsafe public bool TurnYellowLightOn(bool Blink)
        {
            bool bchk = false;
            byte* bbb = stackalloc byte[6];

            bbb[0] = _dontCare;
            bbb[1] = Blink ? _blink : _on;
            bbb[2] = _dontCare;
            bbb[3] = _dontCare;
            bbb[4] = _dontCare;
            bbb[5] = _dontCare; // sound select


            bchk = Usb_Qu_write(0, 0, bbb);

            return bchk;
        }

        unsafe public bool TurnYellowLightOff()
        {
            bool bchk = false;
            byte* bbb = stackalloc byte[6];

            bbb[0] = _dontCare;
            bbb[1] = _off;
            bbb[2] = _dontCare;
            bbb[3] = _dontCare;
            bbb[4] = _dontCare;
            bbb[5] = _dontCare; // sound select


            bchk = Usb_Qu_write(0, 0, bbb);

            return bchk;
        }

        unsafe public bool TurnGreenLightOn(bool Blink)
        {
            bool bchk = false;
            byte* bbb = stackalloc byte[6];

            bbb[0] = _dontCare;
            bbb[1] = _dontCare;
            bbb[2] = Blink ? _blink : _on;
            bbb[3] = _dontCare;
            bbb[4] = _dontCare;
            bbb[5] = _dontCare; // sound select


            bchk = Usb_Qu_write(0, 0, bbb);

            return bchk;
        }

        unsafe public bool TurnGreenLightOff()
        {
            bool bchk = false;
            byte* bbb = stackalloc byte[6];

            bbb[0] = _dontCare;
            bbb[1] = _dontCare;
            bbb[2] = _off;
            bbb[3] = _dontCare;
            bbb[4] = _dontCare;
            bbb[5] = _dontCare; // sound select


            bchk = Usb_Qu_write(0, 0, bbb);

            return bchk;
        }

        unsafe public bool TurnBlueLightOn(bool Blink)
        {
            bool bchk = false;
            byte* bbb = stackalloc byte[6];

            bbb[0] = _dontCare;
            bbb[1] = _dontCare;
            bbb[2] = _dontCare;
            bbb[3] = Blink ? _blink : _on;
            bbb[4] = _dontCare;
            bbb[5] = _dontCare; // sound select


            bchk = Usb_Qu_write(0, 0, bbb);

            return bchk;
        }

        unsafe public bool TurnBlueLightOff()
        {
            bool bchk = false;
            byte* bbb = stackalloc byte[6];

            bbb[0] = _dontCare;
            bbb[1] = _dontCare;
            bbb[2] = _dontCare;
            bbb[3] = _off;
            bbb[4] = _dontCare;
            bbb[5] = _dontCare; // sound select


            bchk = Usb_Qu_write(0, 0, bbb);

            return bchk;
        }

        unsafe public bool SoundOn()
        {
            bool bchk = false;
            byte* bbb = stackalloc byte[6];

            bbb[0] = _dontCare;
            bbb[1] = _dontCare;
            bbb[2] = _dontCare;
            bbb[3] = _dontCare;
            bbb[4] = _dontCare;
            bbb[5] = _on; // sound select


            bchk = Usb_Qu_write(0, 0, bbb);

            return bchk;
        }

        unsafe public bool SoundOff()
        {
            bool bchk = false;
            byte* bbb = stackalloc byte[6];

            bbb[0] = _dontCare;
            bbb[1] = _dontCare;
            bbb[2] = _dontCare;
            bbb[3] = _dontCare;
            bbb[4] = _dontCare;
            bbb[5] = _off; // sound select


            bchk = Usb_Qu_write(0, 0, bbb);

            return bchk;
        }

        unsafe public void Reset()
        {
            bool bchk = false;
            byte* bbb = stackalloc byte[6];

            bbb[0] = 0;
            bbb[1] = 0;
            bbb[2] = 0;
            bbb[3] = 0;
            bbb[4] = 0;

            bbb[5] = 0; // sound select


            bchk = Usb_Qu_write(0, 0, bbb);
        }

    }
}
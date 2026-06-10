using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
namespace RAN_SAN_MOI
{
    public static  class QuanLyAmThanh
    {
        private static SoundPlayer _nhacNen;
        private static SoundPlayer _amThanhAnMoi;
        private static SoundPlayer _amThanhChet;
        private static bool _batAmThanh = true;
        public static void KhoiTao()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string bgPath = Path.Combine(baseDir, "Sounds", "background.wav");
                string eatPath = Path.Combine(baseDir, "Sounds", "eat.wav");
                string diePath = Path.Combine(baseDir, "Sounds", "die.wav");
             
                _nhacNen = new SoundPlayer(bgPath);
                _amThanhAnMoi = new SoundPlayer(eatPath);
                _amThanhChet = new SoundPlayer(diePath);


                _nhacNen.Load();
                _amThanhAnMoi.Load();
                _amThanhChet.Load();
            }
            catch { }
        }
        public static void PhatNhacNen()
        {
            if (!_batAmThanh) return;
            try
            {
                if (_nhacNen != null)
                {
                    _nhacNen.PlayLooping();
                }
            }
            catch { }
        }
        public static void DungNhacNen()
        {
            try 
            { 
              if(_nhacNen != null)
                {
                    _nhacNen.Stop();
                }
            } catch { }
        }
        public static void PhatAnMoi()
        {
            if (!_batAmThanh) return;

            try
            {
                if (_amThanhAnMoi != null)
                {
                    _amThanhAnMoi.Play();
                }
            }
            catch
            {
            }
        }

        public static void PhatChet()
        {
            if (!_batAmThanh) return;

            try
            {
                if (_amThanhChet != null)
                {
                    _amThanhChet.Play();
                }
            }
            catch
            {
            }
        }
        public static void BatTatAmThanh(bool bat)
        {
            _batAmThanh = bat;

            if (!bat)
                DungNhacNen();
            else
                PhatNhacNen();
        }

        public static void Dispose()
        {
            if (_nhacNen != null)
                _nhacNen.Dispose();

            if (_amThanhAnMoi != null)
                _amThanhAnMoi.Dispose();

            if (_amThanhChet != null)
                _amThanhChet.Dispose();
        }
    }

}

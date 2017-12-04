using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCongViec.Model
{
    public static class ModelContext
    {
        public static List<CongViec> CongViecs =
               new List<CongViec>()
                   {
                        new CongViec() { ID = 1, Ten = "Học C++", BatDau = DateTime.Now, KetThuc = DateTime.Now, TrangThai = 1 },
                        new CongViec() { ID = 2, Ten = "Học C#", BatDau = DateTime.Now, KetThuc = DateTime.Now, TrangThai = 0 }
                   };

        public static void ThemCongViec(CongViec cv)
        {
            int ID = CongViecs.Max(p => p.ID);
            ID++;
            cv.ID = ID;
            CongViecs.Add(cv);
        }

        public static void XoaCongViec(CongViec cv)
        {
            CongViecs.Remove(cv);
        }
    }
}

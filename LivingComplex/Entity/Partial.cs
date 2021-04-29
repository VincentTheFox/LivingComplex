using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingComplex.Entity
{
    partial class Tenants
    {
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName + " " + Patronymic;
            }
        }
        public int FlatNumber
        {
            get
            {
                IEnumerable<int> FlatNumberquery =
                    from Flats in CN.c.Flats
                    where Flats.idFlat == FlatID
                    select Flats.FlatNumber;
                int FlatNumber = FlatNumberquery.First();
                return FlatNumber;
            }


        }
        public int HouseNumber
        {
            get
            {
                IEnumerable<int> HouseNumberquery =
                       from Flats in CN.c.Flats
                       where Flats.idFlat == FlatID
                       select Flats.HouseNumber;
                int HouseNumber = HouseNumberquery.First();
                return HouseNumber;
            }
        }
        public string StreetName
        {
            get
            {
                IEnumerable<int> StreetNumberquery =
                    from Flats in CN.c.Flats
                    where Flats.idFlat == FlatID
                    select Flats.StreetNumber;
                int StreetNumber = StreetNumberquery.First();
                IEnumerable<string> StreetNamequery =
                    from Streets in CN.c.Streets
                    where Streets.idStreet == StreetNumber
                    select Streets.StreetName;
                string StreetName = StreetNamequery.First();
                return StreetName;
            }
        }
        public string Birthday
        {
            get
            {
                string bd = BirthdayDate.ToString();
                bd = bd.Substring(0, 10);
                return bd;
            }
        }
    }
    partial class Employers
    {
        public string EmployeeFullName
        {
            get
            {
                return LastName + " " + FirstName + " " + Patronymic;
            }
        }
        public string BirthDate
        {
            get
            {
                string bd = BirthdayDate.ToString();
                bd = bd.Substring(0, 10);
                return bd;
            }
        }
        public string WorkDate
        {
            get
            {
                string ws = WorkingStartDate.ToString();
                ws = ws.Substring(0, 10);
                return ws;
            }
        }
    }
    partial class Offers
    {
        public string CreationDate
        {
            get
            {
                string cd = CreateDate.ToString();
                cd = cd.Substring(0, 10);
                return cd;

                
            }
        }
        public string UpdationDate
        {
            get
            {
                string ud = LastUpdateDate.ToString();
                if(ud == "")
                {
                    return CreationDate;
                }
                else
                {
                    ud = ud.Substring(0, 10);
                    return ud;
                }
                
            }
        }
        
        
    }
    partial class History
    {
        public string HistoryDate
        {
            get
            {
                string hd = Date.ToString();
                hd = hd.Substring(0, 10);
                return hd;
            }
        }
    }
    partial class News
    {
        public string CreatedDate
        {
            get
            {
                string cd = NewsDate.ToString();
                cd = cd.Substring(0, 10);
                return cd;
            }
        }
    }
}

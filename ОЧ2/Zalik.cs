﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ОЧ2
{
    public class Zalik: IComparable<Zalik>
    {
        public string Subject { get; private set; }
        public string Teacher { get; private set; }
        public int Grade { get; private set; }


        public Zalik()
        {
            Subject = string.Empty;
            Teacher = string.Empty; 
            Grade = 0;
        }
           

        public Zalik(string _subject, string _teacher, int _grade) 
        {
            Grade = _grade;
            Subject = _subject;
            Teacher = _teacher;
        }

        public int CompareTo(Zalik other)
        {
            return Grade.CompareTo(other.Grade);
        }

        public static bool  operator < (Zalik lhs, Zalik rhs)
        {
            return lhs.Grade < rhs.Grade;
        }
        public static bool operator > (Zalik lhs, Zalik rhs)
        {
            return lhs.Grade > rhs.Grade;
        }

        public static bool operator == (Zalik lhs, Zalik rhs)
        {
            return lhs.Grade == rhs.Grade;
        }

        public static bool operator != (Zalik lhs, Zalik rhs)
        {
            return lhs.Grade != rhs.Grade;
        }
        public override string ToString()
        {
            if (Grade>50)
            {
                return $"{Subject} , {Teacher} , {Grade} - зараховано ";
            }
            else
            {
                return $"{Subject} , {Teacher} , {Grade} - НЕ зараховано ";
            }
        }

        public override bool Equals(Object other)
        {
            //Check for null and compare run-time types.
            if ((other==null) || !this.GetType().Equals(other.GetType())){
                return false;
            }
            else
            {
                Zalik zlk = (Zalik)other;
                return Grade == zlk.Grade;
            }
        }
    }
}

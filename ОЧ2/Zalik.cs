using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ОЧ2
{
    public class Zalik: IComparable<Zalik>, ICloneable
    {
        public int Grade { get; set; }
        public string Teacher { get; set; }
        private string subject;

        public virtual string Subject
        {
            get 
            { 
                if (Grade > 50 && Grade < 75) 
                { 
                    OnGradeSatisfactory(EventArgs.Empty); 
                }
                if (Grade > 74 && Grade < 90)
                {
                    OnGradeGood(EventArgs.Empty);
                }
                if (Grade > 89)
                {
                    OnGradePerfect(EventArgs.Empty);
                }
                return subject; 
            }
            set 
            { 
                subject = value; 
            }
        }

        public event EventHandler GradeSatisfactory;
        public event EventHandler GradeGood;
        public event EventHandler GradePerfect;

        public Zalik()
        {
            subject = string.Empty;
            Teacher = string.Empty; 
            Grade = 0;

            //SubscribeToGradeSatisfactoryEvent();
            //SubscribeToGradeGoodEvent();
            //SubscribeToGradePerfectEvent();
        }
           


        public Zalik(string _subject, string _teacher, int _grade) 
        {
            GradeSatisfactory += ThisGradeSatisfactory;
            Grade = _grade >= 100 ? 100 : _grade;
            subject = _subject;
            Teacher = _teacher;

            SubscribeToGradeSatisfactoryEvent();
            SubscribeToGradeGoodEvent();
            SubscribeToGradePerfectEvent();

        }

        public int CompareTo(Zalik other)
        {
            return Grade.CompareTo(other.Grade);
        }

        public object Clone()
        {
            Zalik clone = new Zalik(subject, "", 0);
            return clone;
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

        public static int operator + (Zalik lhs, Zalik rhs)
        {
            return lhs.Grade + rhs.Grade;
        }

        public static int operator - (Zalik lhs, Zalik rhs)
        {
            return lhs.Grade - rhs.Grade;
        }

        public override string ToString()
        {
            if (Grade >50)
            {
                return $"{subject} , {Teacher} , {Grade} - зараховано ";
            }
            else
            {
                return $"{subject} , {Teacher} , {Grade} - НЕ зараховано ";
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
        private void SubscribeToGradeSatisfactoryEvent()
        {
            GradeSatisfactory += ThisGradeSatisfactory;
        }

        protected virtual void OnGradeSatisfactory(EventArgs e)
        {
            GradeSatisfactory?.Invoke(this, e);
        }

        protected virtual void ThisGradeSatisfactory(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Дисципліну здано задовільно!");
            Console.ResetColor();
        }
        private void SubscribeToGradeGoodEvent()
        {
            GradeGood += ThisGradeGood;
        }
        protected virtual void OnGradeGood(EventArgs e)
        {
            GradeGood?.Invoke(this, e);
        }

        protected virtual void ThisGradeGood(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Дисципліну здано добре!");
            Console.ResetColor();
        }
        private void SubscribeToGradePerfectEvent()
        {
            GradePerfect += ThisGradePerfect;
        }
        protected virtual void OnGradePerfect(EventArgs e)
        {
            GradePerfect?.Invoke(this, e);
        }

        protected virtual void ThisGradePerfect(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Дисципліну здано відмінно!");
            Console.ResetColor();
        }

    }
}

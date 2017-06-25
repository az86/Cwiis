using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiis
{
    public class Item : INotifyPropertyChanged
    {
        public Item(string [] strs)
        {
            ProjectNo = strs[0];
            CheckList = strs[1];
            CheckContent = strs[2];
            JudgmentStandard = strs[3];
            JudgmentCount = strs[4];
            CheckStage1 = strs[5];
            CheckStage2 = strs[6];
            CheckStage3 = strs[7];
            Rule = strs[8];

            double tmp = 0.0;
            double.TryParse(strs[9],out tmp);
            BaseScore = tmp;

            tmp = 0.0;
            double.TryParse(strs[10], out tmp);
            Weight = tmp;

            tmp = 0.0;
            double.TryParse(strs[11], out tmp);
            RealScore = tmp;

            
            Description = strs[12];
            Grade = strs[13];

            tmp = 0.0;
            double.TryParse(strs[14], out tmp);
            Score = tmp;

            tmp = 0.0;
            double.TryParse(strs[15], out tmp);
            FullScore = tmp;
        }

        public string _projectNo;

        public string ProjectNo { get { return _projectNo; } set { _projectNo = value; CheckList = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("CheckList")); } }
        public string CheckList { get; set; }
        public string CheckContent { get; set; }
        public string JudgmentStandard { get; set; }
        public string JudgmentCount { get; set; }
        public string CheckStage1 { get; set; }
        public string CheckStage2 { get; set; }
        public string CheckStage3 { get; set; }
        public string Rule { get; set; }

        public double BaseScore
        {
            get { return _baseScore; }

            set
            {
                _baseScore = value;
                Notify("BaseScore");
                RealScore = Weight * BaseScore;
            }
        }

        private double _baseScore;

        public double Weight
        {
            get
            {
                return _weight;
            }

            set
            {
                _weight = value;
                Notify("Weight");
                RealScore = Weight * BaseScore;
            }
        }
        private double _weight;

        public double RealScore
        {
            get
            {
                return _realScore;
            }

            set
            {
                _realScore = value;
                Notify("RealScore");
                switch (Grade)
                {
                    case "A":
                        Score = RealScore;
                        break;
                    case "B":
                        Score = RealScore * 0.8;
                        break;
                    case "C":
                        Score = RealScore * 0.6;
                        break;
                    case "D":
                        Score = RealScore * 0.3;
                        break;
                    default:
                        Score = 0;
                        break;
                }
                FullScore = Grade == "NA" ? FullScore = 0 : FullScore = RealScore;

            }
        }
        private double _realScore;

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
                Notify("Description");
            }
        }

        public string Grade
        {
            get
            {
                return _grade;
            }

            set
            {
                _grade = value;
                Notify("Grade");
                switch (Grade)
                {
                    case "A":
                        Score = RealScore;
                        break;
                    case "B":
                        Score = RealScore * 0.8;
                        break;
                    case "C":
                        Score = RealScore * 0.6;
                        break;
                    case "D":
                        Score = RealScore * 0.3;
                        break;
                    default:
                        Score = 0;
                        break;
                }
                FullScore = Grade == "NA" ? FullScore = 0 : FullScore = RealScore;
            }
        }

        public double FullScore
        {
            get
            {
                return _fullScore;
            }

            set
            {
                _fullScore = value;
                Notify("FullScore");
            }
        }

        public double Score
        {
            get
            {
                return _score;
            }

            set
            {
                _score = value;
                Notify("Score");
            }
        }

        private string _description;

        private string _grade;

        private double _score;

        private double _fullScore;

        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs( name));
        }
    }
}

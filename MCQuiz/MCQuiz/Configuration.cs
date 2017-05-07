using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQuiz
{
    class Configuration
    {
        public Configuration()
        {
            this.SuccessHurdle = 90;
            this.NameOfProgram = "Sportführerschein";
        }

        public Configuration(int successHurdle, string nameOfProgram)
        {
            this.SuccessHurdle = successHurdle;
            this.NameOfProgram = nameOfProgram;
        }

        public int SuccessHurdle
        {
            get;
            set;
        }

        public string NameOfProgram
        {
            get;
            set;
        }
    }
}

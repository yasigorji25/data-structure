using System;
namespace CAB301_assignment {
    public class Movie {
        // properties
        private string title;
        private string starring;
        private string director;
        private int duration;
        private string genere;
        private string classification;
        private int releasedate;
        private int copy;
        private int borrow;

        public string Title { get => title; set => title = value; }
        public string Starring { get => starring; set => starring = value; }
        public string Director { get => director; set => director = value; }
        public int Duration { get => duration; set => duration = value; }
        public string Genere { get => genere; set => genere = value; }
        public string Classification { get => classification; set => classification = value; }
        public int Releasedate { get => releasedate; set => releasedate = value; }
        public int Copy { get => copy; set => copy = value; }
        public int Borrow { get => borrow; set => borrow = value; }

        public Movie(string title, string starring, string director, int duration, string genere,
            string classification, int releasedate, int copy, int borrow) {
            this.title = title;
            this.starring = starring;
            this.director = director;
            this.duration = duration;
            this.genere = genere;
            this.classification = classification;
            this.releasedate = releasedate;
            this.copy = copy;
            this.borrow = borrow;

        }

        public Movie(string title) {
            this.title = title;
        }

        public override string ToString() {
            return ("Title: " + title + "\n" + "Starring: " + starring + "\n" + "Director: " + director + "\n" + "Duration: " + duration + " minutes" + "\n"
                + "Genere: " + genere + "\n" + "Classification: " + classification + "\n" + "Releasedate: " + releasedate + "\n"
                + "Copies Avaiable: " + copy + "\n" + "Times Borrowed: : " + borrow + "\n");

        }
    }
}

using System;
using System.Collections.Generic;
// I used collection library just to keep record of borrowed movies for each member.
//Nothing else. I asked and they told me is ok and you won't lose mark. 
namespace CAB301_assignment {

    public class Member {

        private string firstname;
        private string lastname;
        private string adress;
        private long phonenumber;
        private int password;
        private string username;

        private List<Movie> currentBorrow = new List<Movie>();


        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Adress { get => adress; set => adress = value; }
        public int Password { get => password; set => password = value; }
        public long Phonenumber { get => phonenumber; set => phonenumber = value; }
        public string Username { get => lastname + firstname; set => username = value; }

        public List<Movie> CurrentBorrow {
            set { currentBorrow = value; }
            get { return currentBorrow; }
        }

        public Member(string firstname, string lastname, string adress, long phonenumber, int password, string username, List<Movie> currentBorrow) {
            this.firstname = firstname;
            this.lastname = lastname;
            this.adress = adress;
            this.phonenumber = phonenumber;
            this.password = password;
            this.username = username;
            this.currentBorrow = currentBorrow;

        }

        public Member() {

        }
        public static bool isMovieSame(string movieInput, Member member) {
            foreach (var movie in member.currentBorrow) {
                if (movieInput == movie.Title) {
                    Console.WriteLine("You are not allowed to borrow a same movie twice!");
                    return true;
                }

            }
            return false;
        }
        public Movie checkIfBorrowMovie(string movieName, MovieCollection movieCol, Member member) {
            Movie movie = movieCol.MovieCol.reurnMovieByTitle(movieName);
            if (movie != null && movie.Copy > 0) {
                if (member.CurrentBorrow.Count <= 10) {
                    if (isMovieSame(movieName, member)) { return null; } else {
                        movie.Copy--;
                        movie.Borrow++;
                        member.CurrentBorrow.Add(movie);
                        Console.WriteLine("you borrowed {0}", movie.Title);
                    }
                } else Console.WriteLine("You are not allowed to borrow more than 10 movies.");
                return null;

            } else {
                Console.WriteLine("This movie is not exist");
            }

            return null;
        }
        public void borrowMovie(MovieCollection movieCol, Member member) {

            Console.Write("Enter movie title: ");
            string title = Console.ReadLine();
            checkIfBorrowMovie(title, movieCol, member);

        }

        public void returnMovie(Member member) {

            Console.Write("Enter movie title: ");
            string title = Console.ReadLine();
            if (member.CurrentBorrow != null && member.CurrentBorrow.Count > 0) {
                foreach (var movie in member.CurrentBorrow) {
                    if (movie.Title == title) {

                        member.CurrentBorrow.Remove(movie);
                        movie.Copy++;

                        Console.WriteLine("you've returned, {0}", movie.Title);
                        break;
                    } else Console.WriteLine("This movie does not exist! Try again!");
                }
            } else {
                Console.WriteLine("This movie is not borrowed! Try again.");
            }
        }


        public void listHoldMoviesByMember(Member member) {
            if (member.CurrentBorrow != null && member.CurrentBorrow.Count > 0) {
                Console.WriteLine("you are currently borrowing: ");
                foreach (var movie in member.CurrentBorrow) {
                    Console.WriteLine("{0}", movie.Title);
                    Console.WriteLine();
                }
            } else Console.WriteLine("You have not borrowed any movie yet.");
        }


    }

}



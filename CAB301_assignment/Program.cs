using System;

namespace CAB301_assignment {
    class MainClass {

        public static MemberCollection memberCol = new MemberCollection();
        public static MovieCollection movie = new MovieCollection();
        public static Member member = new Member();
        public static void Main(string[] args) {
            MainMenu();
        }

        // Display main menu
        public static void MainMenu() {
            Console.WriteLine("Welcome to the community Library");
            Console.WriteLine("=============Main Menu==========");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine("==================================");
            Console.Write("Please make a selection (1-2 or 0 to exit):");


            string choice = Console.ReadLine();
            int number;
            bool result = Int32.TryParse(choice, out number);

            if (result) {

                if (number == 0) {
                    Environment.Exit(0);
                }

                if (number == 1) {
                    StaffLogin();
                }

                if (number == 2) {
                    if (memberCol.CheckIfMemberValid()) {
                        memberMenu();
                    } else Console.WriteLine("user is invalid! Try again.");
                    MainMenu();
                }


            }
        }
        public static void StaffLogin() {
            Console.Write("Enter username: ");
            string userName = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            if (userName == "staff" && password == "today123") {
                Console.WriteLine();
                StaffMenu();
            } else {
                Console.WriteLine("try again!");
                Console.WriteLine();
                MainMenu();
            }
        }
        // Display staff Menu

        public static void StaffMenu() {
            Console.WriteLine("=============Staff Menu==========");
            Console.WriteLine("1. Add a new movie DVD");
            Console.WriteLine("2. Remove a movie DVD");
            Console.WriteLine("3. Register a new member");
            Console.WriteLine("4. Find a registered member by phone number");
            Console.WriteLine("0. Return to Main Menu");
            Console.WriteLine("==================================");
            Console.Write("Please make a selection (1-4 or 0 to return to Main Menu):");

            string choice = Console.ReadLine();
            int number;
            bool result = Int32.TryParse(choice, out number);
            if (result) {
                if (number == 0) {
                    MainMenu();
                }
                if (number == 1) {
                    movie.addMovie();
                    Console.WriteLine();
                    StaffMenu();
                }

                if (number == 2) {
                    movie.deleteMovie();
                    Console.WriteLine();
                    StaffMenu();
                }
                if (number == 3) {
                    memberCol.memberRegister();
                    Console.WriteLine();
                    StaffMenu();

                }
                if (number == 4) {
                    memberCol.getPhoneNumber();
                    Console.WriteLine();
                    StaffMenu();
                }

            }
        }

        //Display Member Menu

        public static void memberMenu() {

            Console.WriteLine("=============Member Menu==========");
            Console.WriteLine("1. Display all movies");
            Console.WriteLine("2. Borrow a movie DVD");
            Console.WriteLine("3. Return a movie DVD");
            Console.WriteLine("4. List current movie DVDs");
            Console.WriteLine("5. Display top 10 most popular movies");
            Console.WriteLine("0. Return to Main Menu");
            Console.WriteLine("==================================");
            Console.Write("Please make a selection (1-5 or 0 to return to Main Menu):");

            string choice = Console.ReadLine();
            int number;
            bool result = Int32.TryParse(choice, out number);
            if (result) {
                if (number == 0) {
                    MainMenu();
                }

                if (number == 1) {
                    movie.displayMovie();
                    Console.WriteLine();
                    memberMenu();
                }

                if (number == 2) {
                    member.borrowMovie(movie, member);
                    Console.WriteLine();
                    memberMenu();
                }

                if (number == 3) {
                    member.returnMovie(member);
                    Console.WriteLine();
                    memberMenu();
                }

                if (number == 4) {
                    member.listHoldMoviesByMember(member);
                    Console.WriteLine();
                    memberMenu();
                }

                if (number == 5) {
                    movie.displayTopTenMovie();
                    Console.WriteLine();
                    memberMenu();
                }


            }
        }



    }

}
using System;
using System.ComponentModel;

namespace CAB301_assignment {

    public class MovieCollection {

        private BST movieCol = new BST();
        int movieCounter = 0;

        public BST MovieCol {
            set { movieCol = value; }
            get { return movieCol; }
        }

        enum MovieGenre {
            Drama = 1,
            Adventure,
            Family,
            Action,
            ScienceFiction,
            Comedy,
            Thriller,
            other
        }
        enum MovieClassification {
            [Description("Geeral G")]
            General = 1,
            Parental_Guidance,
            Mature,
            MatureAccomplished
        }


        //  Add movie to community library 
        public void addMovie() {

            Console.Write("Enter the movie title: ");
            string title = Console.ReadLine();

            // if they add a movie which is already exist in community library jsut ask for number of copies of that movie. 
            if (movieCol.Search(title)) {
                Movie getMovie = movieCol.reurnMovieByTitle(title);
                Console.Write("Enter the number of copies: ");
                int copy = Convert.ToInt32(Console.ReadLine());
                getMovie.Copy += copy;
                Console.WriteLine("{0} more copies are added for {1} movie.\n Total number of available for {1} movie is: {2}", copy, getMovie.Title, getMovie.Copy);
            } else {
                // if movie title is not exist in community librarty then ask all the prperties for that movie 
                Console.Write("Enter the starring actor(s): ");
                string starring = Console.ReadLine();

                Console.Write("Enter the director(s): ");
                string director = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("select the genre: ");
                Array enumValueArray = Enum.GetValues(typeof(MovieGenre));
                foreach (int enumValue in enumValueArray) {
                    Console.WriteLine(enumValue + ". " + Enum.GetName(typeof(MovieGenre), enumValue));
                }
                Console.WriteLine("Make selection(1-8): ");
                int movieValue = 0;
                int.TryParse(Console.ReadLine(), out movieValue);
                string genere = ((MovieGenre)movieValue).ToString();


                Console.WriteLine("select the Classification: ");
                Array classificationArray = Enum.GetValues(typeof(MovieClassification));
                foreach (int enumValue in classificationArray) {
                    Console.WriteLine(enumValue + ". " + Enum.GetName(typeof(MovieClassification), enumValue));
                }

                Console.WriteLine("Make selection(1-4): ");
                int classficationValue = 0;
                int.TryParse(Console.ReadLine(), out classficationValue);
                string classification = ((MovieClassification)classficationValue).ToString();


                Console.Write("Enter the movie duration: ");


                int duration = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the release date (year): ");
                int releasedate = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the number of copies: ");
                int copy = Convert.ToInt32(Console.ReadLine());
                int borrow = 0;

                var movie = new Movie(title, starring, director, duration, genere,
                classification, releasedate, copy, borrow);
                movieCol.Insert(movie);
                movieCounter++;

                Console.WriteLine();

                Console.WriteLine("{0} is added successfully to community. ", movie.Title);
            }

        }

        // Delete a movie by title 
        public void deleteMovie() {
            Console.Write("Enter the movie title: ");
            string title = Console.ReadLine();
            if (movieCol.Search(title)) {
                movieCol.Delete(title);
                Console.WriteLine("{0} deleted.", title);
                movieCounter--;
            } else {
                Console.WriteLine("no movie found");
            }
        }
        // display number of avaible movies in community libarary as well as movies with all the features 
        public void displayMovie() {
            if (movieCounter > 0) {
                Console.WriteLine("Number of movie and DVDs avaible in community library is: {0}", movieCounter);
                movieCol.InOrderTraverse();
            } else Console.WriteLine("No movie or DVD avaiable in community library.");
        }

        // Display Top 10 movies which they borrowed the most by members in decending order. 
        public void displayTopTenMovie() {
            int k = 10;
            int controlNumber = 0;
            int counter = 0;
            movieCol.PostOrderTraverse();
            Movie[] unsorted = MovieCol.Unsort;

            Movie[] currentMovie = new Movie[movieCounter];
            for (int i = 0; i < movieCounter; i++) {
                //if (unsorted[i] == null) {
                //    //Console.WriteLine("error: null");
                //    //continue;
                //}
                currentMovie[i] = unsorted[i];
            }
            //Console.WriteLine(movieCounter);
            MergeSort(currentMovie, 0, movieCounter - 1);

            if (movieCounter < k) {
                controlNumber = movieCounter;
            } else {
                controlNumber = k;
            }
            for (int i = movieCounter - 1; i >= 0; i--) {
                if (controlNumber == counter)
                    break;
                Console.WriteLine("{0} borrowed {1} times. ", currentMovie[i].Title, currentMovie[i].Borrow);
                counter++;

            }
        }

        private void copyArray(Movie[] sourceArray, int sourceIndex, Movie[] destinationArray, int destinationIndex, int length) {

            for (int i = sourceIndex; i < sourceIndex + length; i++) {
                destinationArray[destinationIndex++] = sourceArray[i];
            }

        }

        // Merge algorithm for display top 10 movies 
        private void Merge(Movie[] input, int left, int middle, int right) {
            Movie[] leftArray = new Movie[middle - left + 1];
            Movie[] rightArray = new Movie[right - middle];

            copyArray(input, left, leftArray, 0, middle - left + 1);
            copyArray(input, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++) {
                if (i == leftArray.Length) {
                    input[k] = rightArray[j];
                    j++;
                } else if (j == rightArray.Length) {
                    input[k] = leftArray[i];
                    i++;

                } else if (leftArray[i].Borrow <= rightArray[j].Borrow) {
                    input[k] = leftArray[i];
                    i++;
                } else {
                    input[k] = rightArray[j];
                    j++;
                }
            }
        }
        // mergesort for display top 10 movies 
        private void MergeSort(Movie[] input, int left, int right) {
            if (left < right) {
                int middle = (left + right) / 2;

                MergeSort(input, left, middle);
                MergeSort(input, middle + 1, right);

                Merge(input, left, middle, right);
            }
        }





    }
}

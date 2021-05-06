using System;
using System.Text.RegularExpressions;


namespace CAB301_assignment {
    class MemberCollection {
        public static Member[] colMember = new Member[10];




        public static int counter = 0;

        public MemberCollection() { }

        public static bool CheckIfUserExists(string inputName, string InputLastname) {
            for (int i = 0; i < colMember.Length; i++) {
                if (colMember[i] != null) {
                    if (inputName == colMember[i].Firstname && InputLastname == colMember[i].Lastname)
                        return true;


                    else return false;

                }
            }
            return false;
        }
        public bool CheckIfMemberValid() {
            Console.Write("Enter your Username (lastnameFisrtname): ");
            string username = Console.ReadLine();

            Console.Write("Enter your Password ");
            int password = Convert.ToInt32(Console.ReadLine());


            foreach (var member in colMember) {
                if (member != null) {
                    if (member.Username == username && member.Password == password) {
                        //LoggedinMember = member;
                        return true;
                    } else return false;
                }
            }
            return false;

        }

        public bool checkPassword(String useInputPassword) {
            bool isPassword4Digits = Regex.IsMatch(useInputPassword, @"^[0-9]{4}$");
            if (isPassword4Digits)
                return true;
            else Console.WriteLine("Password must contains only 4 digits without any letters or spaces");
            return false;
        }


        public long getPhoneNumber() {
            Console.Write("Enter member's first name: ");
            string firstname = Console.ReadLine();

            Console.Write("Enter member's last name: ");
            string lastname = Console.ReadLine();
            foreach (var member in colMember) {
                if (member != null) {
                    if (member.Firstname == firstname && member.Lastname == lastname)
                        Console.WriteLine("{0} {1}'s phone number is: {2}", firstname, lastname, member.Phonenumber);
                }
            }

            return -1; // NO SUCH USER FOUND
        }

        public void memberRegister() {

            Console.Write("Enter member's first name: ");
            string firstname = Console.ReadLine();

            Console.Write("Enter member's last name: ");
            string lastname = Console.ReadLine();

            if (CheckIfUserExists(firstname, lastname)) {
                Console.Write("{0} {1}, has already exist", firstname, lastname);
                return; // if the user exists don't register him in array!
            }

            Console.Write("Enter member's Adress: ");
            string adress = Console.ReadLine();

            Console.Write("Enter member's Phone number: ");
            var phonenumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter member's password: ");
            var password = (Console.ReadLine());
            int passwordAsInt = 0000;
            if (checkPassword(password)) {

                passwordAsInt = Convert.ToInt32(password);

            } else {

                return;
            }

            string username = lastname + firstname;
            var member = new Member(firstname, lastname, adress, phonenumber, passwordAsInt, username, null);

            colMember[counter] = member;
            counter++;
            Console.WriteLine("{0} {1} has been successfully registered!", firstname, lastname);

        }


    }


}










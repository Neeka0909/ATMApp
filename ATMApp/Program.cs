using System;

public class cardHolder
{
    private String cardNum;
    private int pin;
    private String firstName;
    private String lastName;
    private double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getfirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printSystemOptions()
        {
            Console.WriteLine("Please Choose From One Of The Following Options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdrow");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposite(cardHolder currentUser)
        {
            Console.WriteLine("How Much Mony Would You Like to Deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit + currentUser.getBalance());
            Console.WriteLine("Your Deposite is Success.  Your New Balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How Much Mony Would You Like To Withdrow: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //check users balance to user has enougf money to withdraw
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient Balance. ");
            }else
            {
                double newBalance = currentUser.getBalance() - withdrawal;
                currentUser.setBalance(newBalance);
                Console.WriteLine("You Can Withdraw Enterd value.");
            }
        }
        
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current Balance :" + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4532605522223234", 1234, "Nisal", "Vimukthi", 150.31));
        cardHolders.Add(new cardHolder("4539025327845037", 4562, "Chamal", "Vimukthi", 895.36));
        cardHolders.Add(new cardHolder("4716706180155110", 5896, "Nisal", "Vimukthi", 5236.01));
        cardHolders.Add(new cardHolder("4799513729884386", 5632, "Nisal", "Vimukthi", 451.25));
        cardHolders.Add(new cardHolder("4929380215482403", 7854, "Nisal", "Vimukthi", 896.32));

        //Program Start
        Console.WriteLine("Welcome To CliATM");
        Console.WriteLine("Please Enter Your Debit card Number : ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check enterd cardNum
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not Recognized. please TRY AGAIN."); }
            }catch
            {
                Console.WriteLine("Card not Recognized. please TRY AGAIN.");
            }
        }

        Console.WriteLine("Please Enter your Pin :");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //check enterd pinNum
                if (currentUser.getPin() == userPin ) { break; }
                else { Console.WriteLine("Incorrect Pin. please TRY AGAIN."); }
            }
            catch
            {
                Console.WriteLine("Incorrect Pin. please TRY AGAIN.");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getfirstName() + "....");
        int option = 0;
        do
        {
            printSystemOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposite(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }

        } while (option != 4);
        {
            Console.WriteLine("Thank You! Have a Nice Day ");
        }
    }


}

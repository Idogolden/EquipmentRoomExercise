using System;

// <summary>
//Todo: צרו מחלקת חריגים המטפלת במקרים בהם אין מספיק מחשבים זמינים להשאלה.
//שם המחלקה צריך להיות EquipmentUnavailableException.



    public class EquipmentUnavailableException : Exception
    {
        public int Amount { get; }
        public int Difference { get; }
        public EquipmentUnavailableException(int amount, int avilablepc, string name) : base
            (name)
        {
            Amount = amount;
            Difference = amount-avilablepc;
        }
     
    }
class EquipmentRoom
{
    private int availableComputers;

    public int AvailableComputers
    {
        get
        {
            return availableComputers;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Avilablecomputers", "Number can not be smaller then 0");
            }
            availableComputers = value;
        }
    }

    public EquipmentRoom(int amount)
    {
        AvailableComputers = amount;
    }

    public void Borrow(int amount)
    {
        if (amount > AvailableComputers) 
        {
            throw new EquipmentUnavailableException(amount,AvailableComputers,"you asked for more then you have") ;
        }
        AvailableComputers -= amount;
        Console.WriteLine($"הושאלו {amount} מחשבים בהצלחה.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        int initialComputers = 10;

        EquipmentRoom room = new EquipmentRoom(initialComputers);

        // יצירת חדר מחשבים עם מספר מחשבים שלילי:
        // לאחר מימוש הבדיקה ב-set, יש לוודא שמצב כזה מטופל כראוי.
        // TODO: יש להוסיף try-catch מתאימים סביב הקריאות שעלולות לזרוק חריגה.
         int negativeComputers = -5;
        EquipmentRoom invalidRoom = new EquipmentRoom(negativeComputers);
        try
        {
            room.Borrow(4);
            Console.WriteLine("ממשיכים בתוכנית...");

            room.Borrow(8);
        }
        catch (EquipmentUnavailableException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("Numbers of pc avilable: " + room.AvailableComputers);
    }
}

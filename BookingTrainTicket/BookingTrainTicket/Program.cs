Console.WriteLine("Main Fee: 100.00");
Console.WriteLine("December Fee: double (200.00)");
Console.WriteLine("June or July Fee: 0.25 discountt (75.00)");
Console.WriteLine("Any other month Fee: Same (100.00)");

Console.WriteLine("---------------------------------------------");

string userMonth;
Console.WriteLine("Please enter a valid month");
userMonth = Console.ReadLine();

Booking booking;


if (userMonth == "December")
{
     booking = new DecemberFee();
    
} else if (userMonth == "June" || userMonth == "July")
{
     booking = new JunJulFee();

} else 
{
     booking = new FeeKeepValue();
}

Console.WriteLine(booking.PerformFeeCalculation(booking.mainFeevalue).ToString());
Console.ReadLine();



public interface FeeCalculation
{
    double CalculateFee(double mainFeevalue);
}

public class feeDecember : FeeCalculation
{
    public double CalculateFee(double mainFeevalue)
    {
        return mainFeevalue * 2;
    }
}


public class feeJunJul : FeeCalculation
{
    public double CalculateFee(double mainFeevalue)
    {
        return mainFeevalue * 0.75;
    }
}
public class feeKeepFee : FeeCalculation
{
    public double CalculateFee(double mainFeevalue)
    {
        return mainFeevalue;
    }
}


public abstract class Booking
{
    public double mainFeevalue = 100;
    public FeeCalculation FeeCalculation { get; set; }  
    
 

    public double PerformFeeCalculation(double mainFeevalue)
    {
       return FeeCalculation.CalculateFee(mainFeevalue);
    }

}


public class DecemberFee : Booking
{
    public DecemberFee()
    {
        FeeCalculation = new feeDecember();
    }
}

public class JunJulFee : Booking
{
    public JunJulFee()
    {
        FeeCalculation = new feeJunJul();
    }
}


public class FeeKeepValue : Booking
{
    public FeeKeepValue()
    {
        FeeCalculation = new feeKeepFee();
    }
}

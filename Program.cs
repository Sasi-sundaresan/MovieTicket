using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using dotnetapp.models;

public static class ConnectionStringProvider{
   public static string ConnectionString{get;}="Server=SASI;Database=appdb;Trusted_Connection=True";

}

public class Program{
  

    public static void AddMovieTicket(MovieTicket ticket)
    {
        string query="insert into MovieTicket(CustomerName,MovieName,ShowTime,SeatNumber,Price,TicketQuantity) values(@customername,@moviename,@showtime,@seatnumber,@price,@ticketquantity)";

       using(SqlConnection connection=new SqlConnection(ConnectionStringProvider.ConnectionString))
       {
        connection.Open();
        SqlCommand insertcommand=new SqlCommand(query,connection);
        insertcommand.Parameters.AddWithValue("@customername",ticket.CustomerName);
        insertcommand.Parameters.AddWithValue("@moviename",ticket.MovieName);
        insertcommand.Parameters.AddWithValue("@showtime",ticket.ShowTime);
        insertcommand.Parameters.AddWithValue("@seatnumber",ticket.SeatNumber);
        insertcommand.Parameters.AddWithValue("@price",ticket.Price);
        insertcommand.Parameters.AddWithValue("@ticketquantity",ticket.TicketQuantity);

        int rowaffected=insertcommand.ExecuteNonQuery();
        if(rowaffected>0)
        {
            System.Console.WriteLine("inserted successfully");
        }

        
       }
    }

    public static void DisplayAllMovieTicket()
    {
        string query="select * FROM MovieTicket ";
        using(SqlConnection connection=new SqlConnection(ConnectionStringProvider.ConnectionString))
        {
            connection.Open();
            SqlCommand viewcmd=new SqlCommand(query,connection);
            SqlDataReader reader=viewcmd.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine($"TicketId: {reader["TicketID"]},CustomerName: {reader["CustomerName"]}, MovieName: {reader["MovieName"]}, ShowTime: {reader["ShowTime"]}, SeatNumber: {reader["SeatNumber"]}, TicketQuantity: {reader["TicketQuantity"]}, Price: {reader["Price"]}, TotalAmount: {reader["TotalAmount"]}");
            }
        }
    }

    public static void UpdateMovieTicket(string oldcustomername,string oldshowtime,MovieTicket updatedticket)
    {
        string query="update MovieTicket set CustomerName=@customername,MovieName=@moviename,ShowTime=@showtime,SeatNumber=@seatnumber,Price=@price,TicketQuantity=ticketquantity where CustomerName=@oldcustomername and ShowTime=@oldshowtime";

       using(SqlConnection connection=new SqlConnection(ConnectionStringProvider.ConnectionString))
       {
        connection.Open();
        SqlCommand insertcommand=new SqlCommand(query,connection);
         insertcommand.Parameters.AddWithValue("@oldcustomername",oldcustomername);
          insertcommand.Parameters.AddWithValue("@oldshowtime",oldshowtime);
        insertcommand.Parameters.AddWithValue("@customername",updatedticket.CustomerName);
        insertcommand.Parameters.AddWithValue("@moviename",updatedticket.MovieName);
        insertcommand.Parameters.AddWithValue("@showtime",updatedticket.ShowTime);
        insertcommand.Parameters.AddWithValue("@seatnumber",updatedticket.SeatNumber);
        insertcommand.Parameters.AddWithValue("@price",updatedticket.Price);
        insertcommand.Parameters.AddWithValue("@ticketquantity",updatedticket.TicketQuantity);

        int rowaffected=insertcommand.ExecuteNonQuery();
        if(rowaffected>0)
        {
            System.Console.WriteLine("update successfully");
        }
    }
    }
    
    public static void DeleteMovieTicket(string customerName,string showTime)
    {
        string query="delete from MovieTicket where CustomerName=@customername and ShowTime=@showtime";
        using(SqlConnection connection=new SqlConnection(ConnectionStringProvider.ConnectionString))
        {
            connection.Open();
            SqlCommand delcmd=new SqlCommand(query,connection);
            delcmd.Parameters.AddWithValue("@customername",customerName);
            delcmd.Parameters.AddWithValue("@showtime",showTime);

             int rowaffected=delcmd.ExecuteNonQuery();
        if(rowaffected>0)
        {
            System.Console.WriteLine("deleted successfully");
        }
            
        }
    }

    public static void SearchMovieTicketByMovieName(string movieName)
    {
        string query="select * FROM MovieTicket where MovieName=@moviename ";
        using(SqlConnection connection=new SqlConnection(ConnectionStringProvider.ConnectionString))
        {
            connection.Open();
            SqlCommand viewcmd=new SqlCommand(query,connection);
            viewcmd.Parameters.AddWithValue("@moviename",movieName);
            SqlDataReader reader=viewcmd.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine($"TicketId: {reader["TicketID"]},CustomerName: {reader["CustomerName"]}, MovieName: {reader["MovieName"]}, ShowTime: {reader["ShowTime"]}, SeatNumber: {reader["SeatNumber"]}, TicketQuantity: {reader["TicketQuantity"]}, Price: {reader["Price"]}, TotalAmount: {reader["TotalAmount"]}");
            }
        }
    }

    public static void FilterMovieTicketByShowTime(string showTime)
    {
        string query="select * FROM MovieTicket where ShowTime=@showtime ";
        using(SqlConnection connection=new SqlConnection(ConnectionStringProvider.ConnectionString))
        {
            connection.Open();
            SqlCommand viewcmd=new SqlCommand(query,connection);
            viewcmd.Parameters.AddWithValue("@showtime",showTime);
            SqlDataReader reader=viewcmd.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine($"TicketId: {reader["TicketID"]},CustomerName: {reader["CustomerName"]}, MovieName: {reader["MovieName"]}, ShowTime: {reader["ShowTime"]}, SeatNumber: {reader["SeatNumber"]}, TicketQuantity: {reader["TicketQuantity"]}, Price: {reader["Price"]}, TotalAmount: {reader["TotalAmount"]}");
            }
        }
    }

    

     static void Main(string[] args)
    {
         DisplayAllMovieTicket();
        // System.Console.WriteLine("oldname");
        // string oldcustomername=Console.ReadLine();
        // System.Console.WriteLine("oldshowtime");
        // string oldshowtime=Console.ReadLine();
        
        
        
        // System.Console.WriteLine("name");
        // string name=Console.ReadLine();

        // System.Console.WriteLine("moviename");
        // string moviename=Console.ReadLine();

        System.Console.WriteLine("showtime");
        string showtime=Console.ReadLine();

        // System.Console.WriteLine("seatnum");
        // string seatnum=Console.ReadLine();

        // System.Console.WriteLine("price");
        // decimal price=decimal.Parse(Console.ReadLine());

        // System.Console.WriteLine("quantity");
        // int quantity=int.Parse(Console.ReadLine());

        // var updatedticket=new MovieTicket(name,moviename,showtime,seatnum,price,quantity);
        // // AddMovieTicket(ticket);
        // UpdateMovieTicket(oldcustomername,oldshowtime,updatedticket);    

        // DeleteMovieTicket(name,showtime);
        // SearchMovieTicketByMovieName(moviename);

        FilterMovieTicketByShowTime(showtime);
        
    } 
    
}
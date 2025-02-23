CREATE DATABASE appdb
USE appdb
CREATE TABLE MovieTicket(
    TicketId INT IDENTITY,
    CustomerName VARCHAR(100),
    MovieName VARCHAR(100),
    ShowTime VARCHAR(100),
    SeatNumber VARCHAR(100),
    Price DECIMAL(10,2),
    TicketQuantity INT,
    TotalAmount DECIMAL(10,2)
    
)

INSERT into MovieTicket values('iswarya','kemi','morning','3',200,2,200)
-- Creating Database
CREATE DATABASE TicketBooking
USE TicketBooking


--1. Write a SQL query to insert at least 10 sample records into each table.
--Create Venue Table
CREATE TABLE Venue (
    venue_id INT PRIMARY KEY,
    venue_name VARCHAR(100),
    address VARCHAR(255))
	
	ALTER TABLE Venue 
	ADD Street VARCHAR(90),
	 City VARCHAR(50),
	 State VARCHAR(50)
	ALTER TABLE Venue DROP Column address

--Create Event Table
CREATE TABLE Event (
    event_id INT PRIMARY KEY,
    event_name VARCHAR(100),
    event_date DATE,
    event_time TIME,
    venue_id INT,
    total_seats INT,
    available_seats INT,
    ticket_price DECIMAL,
    event_type VARCHAR(10),
    booking_id INT,
    FOREIGN KEY (venue_id) REFERENCES Venue(venue_id),
    CHECK (event_type IN ('Movie', 'Sports', 'Concert')))
	ALTER TABLE Event
ADD FOREIGN KEY (booking_id) REFERENCES Booking(booking_id)

-- Create Booking Table
CREATE TABLE Booking (
    booking_id INT PRIMARY KEY,
    customer_id INT,
    event_id INT,
    num_tickets INT,
    total_cost DECIMAL(10, 2),
    booking_date DATE)

ALTER TABLE Booking
ADD FOREIGN KEY (customer_id) REFERENCES Customer(customer_id),
    FOREIGN KEY (event_id) REFERENCES Event(event_id)

--Create Customer Table
CREATE TABLE Customer (
    customer_id INT PRIMARY KEY,
    customer_name VARCHAR(100),
    email VARCHAR(100),
    phone_number BIGINT,
    booking_id INT,
    FOREIGN KEY (booking_id) REFERENCES Booking(booking_id))

	-- Insert values into Venue
INSERT INTO Venue (venue_id, venue_name, Street, City, State)
VALUES
    (1, 'Wankhede Stadium', 'Churchgate', 'Mumbai', 'Maharashtra'),
    (2, 'Jawaharlal Nehru Stadium', 'Lodhi Road','Delhi', 'Delhi'),
    (3, 'Shanmukhananda Hall', 'Sion', 'Mumbai', 'Maharashtra'),
    (4, 'MGR Film City', 'Taramani', 'Chennai', 'Tamil Nadu'),
    (5, 'Pragati Maidan', 'Mathura Road', 'New Delhi', 'Delhi')
INSERT INTO Venue (venue_id, venue_name, Street, City, State)
VALUES
	(6, 'Eden Gardens', 'xyz','Kolkata', 'West Bengal'),
    (7, 'Mysuru Palace', 'dhimmapa','Mysuru', 'Karnataka'),
    (8, 'Bangalore Palace', 'mg road','Bangalore', 'Karnataka'),
    (9, 'Salt Lake Stadium', 'Salt Lake City', 'Kolkata', 'West Bengal'),
    (10, 'Indira Gandhi Stadium', 'abc','Vijayawada', 'Andhra Pradesh');

-- Insert values into Event
INSERT INTO Event (event_id, event_name, event_date, event_time, venue_id, total_seats, available_seats, ticket_price, event_type, booking_id)
VALUES
    (1, 'IPL Final', '2024-05-28', '18:00', 1, 33000, 25000, 1500.00, 'Sports', NULL),
    (2, 'Republic Day Parade', '2024-01-26', '10:00', 2, 50000, 45000, 0.00, 'Sports', NULL), 
    (3, 'A.R. Rahman Concert', '2024-02-10', '19:00', 3, 3000, 2700, 2000.00, 'Concert', NULL),
    (4, 'Tamil Movie Premiere', '2024-03-15', '20:30', 4, 1000, 900, 500.00, 'Movie', NULL),
    (5, 'Trade Fair', '2024-11-14', '10:00', 5, 20000, 18000, 300.00, 'Concert', NULL)
INSERT INTO Event (event_id, event_name, event_date, event_time, venue_id, total_seats, available_seats, ticket_price, event_type, booking_id)
VALUES
	(6, 'World Cup 2024', '2024-06-20', '17:00', 6, 60000, 50000, 2000.00, 'Sports', NULL),
    (7, 'Rock Concert India', '2024-07-10', '22:00', 7, 3000, 2000, 1800.00, 'Concert', NULL),
    (8, 'Football Championship', '2024-08-12', '15:00', 8, 20000, 15000, 1200.00, 'Sports', NULL),
    (9, 'Classical Music Night', '2024-09-05', '19:30', 9, 5000, 4500, 1500.00, 'Concert', NULL),
    (10, 'Fashion Show', '2024-10-10', '18:30', 10, 7000, 6000, 800.00, 'Concert', NULL)
	INSERT INTO Event (event_id, event_name, event_date, event_time, venue_id, total_seats, available_seats, ticket_price, event_type, booking_id)
VALUES
	(11, 'Fashion Show Concert', '2024-10-12', '20:30', 10, 7000, 6000, 800.00, 'Concert', NULL)

-- Insert values into Customer
INSERT INTO Customer (customer_id, customer_name, email, phone_number, booking_id)
VALUES
    (1, 'Rajesh Kumar', 'rajesh.kumar@example.com', 9876543210, NULL),
    (2, 'Priya Iyer', 'priya.iyer@example.com', 9123456789, NULL),
    (3, 'Vikas Sharma', 'vikas.sharma@example.com', 9988776655, NULL),
    (4, 'Anita Desai', 'anita.desai@example.com', 9871234567, NULL),
    (5, 'Rahul Bose', 'rahul.bose@example.com', 9123451234, NULL)
INSERT INTO Customer (customer_id, customer_name, email, phone_number, booking_id)
VALUES
	(6, 'John Doe', 'john.doe@example.com', 9786345123, NULL),
    (7, 'Sneha Kapoor', 'sneha.kapoor@example.com', 9101234567, NULL),
    (8, 'Ravi Sharma', 'ravi.sharma@example.com', 9123456780, NULL),
    (9, 'Deepa Rani', 'deepa.rani@example.com', 9898765432, NULL),
    (10, 'Maya Patel', 'maya.patel@example.com', 9765432000, NULL)

-- Insert values into Booking
INSERT INTO Booking (booking_id, customer_id, event_id, num_tickets, total_cost, booking_date)
VALUES
    (1, 1, 1, 4, 6000.00, '2024-05-15'),
    (2, 2, 3, 2, 4000.00, '2024-01-28'),
    (3, 3, 4, 5, 2500.00, '2024-03-10'),
    (4, 4, 5, 10, 3000.00, '2024-10-25'),
    (5, 5, 2, 3, 0.00, '2024-01-20')
INSERT INTO Booking (booking_id, customer_id, event_id, num_tickets, total_cost, booking_date)
VALUES
	(6, 6, 6, 2, 4000.00, '2024-06-18'),
    (7, 7, 7, 1, 1800.00, '2024-07-15'),
    (8, 8, 8, 3, 3600.00, '2024-08-10'),
    (9, 9, 9, 6, 9000.00, '2024-09-20'),
    (10, 10, 10, 5, 4000.00, '2024-10-05')

	SELECT * FROM Booking

--2. Write a SQL query to list all Events.
	SELECT * FROM Event

--3. Write a SQL query to select events with available tickets.
SELECT event_name, available_seats FROM Event
WHERE available_seats > 0

--4. Write a SQL query to select events name partial match with ‘cup’.
SELECT event_name FROM Event
WHERE event_name Like '%Cup%'

--5. Write a SQL query to select events with ticket price range is between 1000 to 2500.SELECT event_name, ticket_price FROM Event
WHERE ticket_price BETWEEN 1000 AND 2500

select * from Event
--6. Write a SQL query to retrieve events with dates falling within a specific range.SELECT event_name, event_date FROM Event
WHERE event_date BETWEEN '2024-09-01' AND '2024-12-31'

--7. Write a SQL query to retrieve events with available tickets that also have "Concert" in their name.
SELECT event_name, available_seats FROM Event
WHERE available_seats>0 AND event_name LIKE '%Concert%'

--8. Write a SQL query to retrieve users in batches of 5, starting from the 6th user
SELECT * FROM Customer
ORDER BY customer_id
OFFSET 5 ROWS 
FETCH NEXT 5 ROWS ONLY


select * from Booking
--9. Write a SQL query to retrieve bookings details contains booked no of ticket more than 4.
SELECT * FROM Booking 
WHERE num_tickets>4

select * from Customer
--10. Write a SQL query to retrieve customer information whose phone number end with ‘000’
SELECT * FROM Customer
WHERE phone_number LIKE '%000';

select * from Event
--11. Write a SQL query to retrieve the events in order whose seat capacity more than 15000.
SELECT event_name, total_seats FROM Event 
WHERE total_seats>15000

--12. Write a SQL query to select events name not start with ‘x’, ‘y’, ‘z’SELECT event_name FROM Event
WHERE event_name NOT LIKE 'x%' AND event_name NOT LIKE 'y%' AND event_name NOT LIKE 'z%';


select * from Booking
select * from Customer
select * from Venue
select * from Event
--TASK 3
--1. Write a SQL query to List Events and Their Average Ticket Prices.
SELECT event_name, AVG(ticket_price) AS avg_ticket_price FROM Event
GROUP BY event_name;

--2. Write a SQL query to Calculate the Total Revenue Generated by Events.
SELECT event_id, SUM(total_cost) AS total_revenue FROM Booking
GROUP BY event_id;
SELECT SUM(total_cost) as tot_rev FROM BOOKING

--3. Write a SQL query to find the event with the highest ticket sales.
SELECT top 1 event_id, num_tickets FROM BOOKING
ORDER BY num_tickets desc

--4. Write a SQL query to Calculate the Total Number of Tickets Sold for Each Event.
SELECT event_id, SUM(num_tickets) AS total_tickets_sold FROM Booking
GROUP BY event_id;

--5. Write a SQL query to Find Events with No Ticket Sales.
SELECT event_id, num_tickets FROM BOOKING
WHERE num_tickets=0

--6. Write a SQL query to Find the User Who Has Booked the Most Tickets.
SELECT top 1 customer_id, SUM(num_tickets) AS total_tickets FROM Booking
GROUP BY customer_id
ORDER BY total_tickets DESC

--7. Write a SQL query to List Events and the total number of tickets sold for each month.
SELECT MONTH(booking_date) AS month, Event.event_name, SUM(Booking.num_tickets) AS total_tickets_sold
FROM Booking
JOIN Event ON Booking.event_id = Event.event_id
GROUP BY MONTH(booking_date), Event.event_name
ORDER BY MONTH(booking_date)

--8. Write a SQL query to calculate the average Ticket Price for Events in Each Venue.
SELECT Venue.venue_name, AVG(Event.ticket_price) AS avg_ticket_price
FROM Event
JOIN Venue ON Event.venue_id = Venue.venue_id
GROUP BY Venue.venue_name

--9. Write a SQL query to calculate the total Number of Tickets Sold for Each Event Type.
SELECT event_type, SUM(num_tickets) AS total_tickets_sold
FROM Booking
JOIN Event ON Booking.event_id = Event.event_id
GROUP BY event_type

--10. Write a SQL query to calculate the total Revenue Generated by Events in Each Year
SELECT YEAR(event_date) AS event_year, SUM(total_cost) AS total_revenue
FROM Booking
JOIN Event ON Booking.event_id = Event.event_id
GROUP BY YEAR(event_date)

--12. Write a SQL query to calculate the Total Revenue Generated by Events for Each User.
SELECT customer_name, SUM(total_cost) AS total_revenue
FROM Booking
JOIN Customer ON Booking.customer_id = Customer.customer_id
GROUP BY customer_name

--13. Write a SQL query to calculate the Average Ticket Price for Events in Each Category and Venue.
SELECT event_type, Venue.venue_name, AVG(ticket_price) AS avg_ticket_price
FROM Event
JOIN Venue ON Event.venue_id = Venue.venue_id
GROUP BY event_type, Venue.venue_name

--14. Write a SQL query to list Users and the Total Number of Tickets They've Purchased in the Last 30 Days
SELECT customer_name, SUM(num_tickets) AS total_tickets
FROM Booking
JOIN Customer ON Booking.customer_id = Customer.customer_id
WHERE booking_date >= DATEADD(DAY, -30, GETDATE())
GROUP BY customer_name

--Task-4

--1. Calculate the Average Ticket Price for Events in Each Venue Using a Subquery.
	   SELECT venue_name, 
       (SELECT AVG(ticket_price) FROM Event e 
	   WHERE e.venue_id = v.venue_id) AS avg_ticket_price 
	   FROM Venue v

 --2. Find Events with More Than 50% of Tickets Sold using subquery.
SELECT event_name 
FROM Event e
WHERE (SELECT SUM(num_tickets) FROM Booking b 
WHERE b.event_id = e.event_id) > 0.5 * e.total_seats

--3. Calculate the Total Number of Tickets Sold for Each Event.
SELECT event_name,
(SELECT COALESCE(SUM(num_tickets), 0) FROM Booking b 
WHERE b.event_id = e.event_id) AS total_tickets_sold
FROM Event e

select * from booking
--4. Find Users Who Have Not Booked Any Tickets Using a NOT EXISTS Subquery.
SELECT customer_name
FROM Customer c
WHERE NOT EXISTS (SELECT 1 FROM Booking b WHERE b.customer_id = c.customer_id)

--5. List Events with No Ticket Sales Using a NOT IN Subquery.
SELECT event_name
FROM Event e
WHERE e.event_id NOT IN (SELECT event_id FROM Booking)

--6. Calculate the Total Number of Tickets Sold for Each Event Type Using a Subquery in the FROM Clause.
SELECT event_type, SUM(total_tickets_sold) AS total_tickets
FROM (SELECT event_type, COALESCE(SUM(b.num_tickets), 0) AS total_tickets_sold
    FROM Event e
    LEFT JOIN Booking b ON e.event_id = b.event_id
    GROUP BY e.event_id, e.event_type) AS subquery
GROUP BY event_type

--7. Find Events with Ticket Prices Higher Than the Average Ticket Price Using a Subquery in the WHERE Clause.
SELECT event_name, ticket_price
FROM Event
WHERE ticket_price > (SELECT AVG(ticket_price) FROM Event)

--8. Calculate the Total Revenue Generated by Events for Each User Using a Correlated Subquery.
SELECT customer_name,
(SELECT COALESCE(SUM(total_cost), 0) FROM Booking b 
WHERE b.customer_id = c.customer_id) AS total_revenue
FROM Customer c

--9. List Users Who Have Booked Tickets for Events in a Given Venue Using a Subquery in the WHERE Clause.
SELECT DISTINCT customer_name
FROM Customer c
WHERE c.customer_id IN (
    SELECT b.customer_id
    FROM Booking b
    JOIN Event e ON b.event_id = e.event_id
    WHERE e.venue_id = 3)


--10. Calculate the Total Number of Tickets Sold for Each Event Category Using a Subquery with GROUP BY.
SELECT e.event_type,
COALESCE(SUM(b.num_tickets), 0) AS total_tickets_sold
FROM Event e
LEFT JOIN Booking b ON e.event_id = b.event_id
GROUP BY e.event_type


--11. Find Users Who Have Booked Tickets for Events in each Month Using a Subquery with DATE_FORMAT.
SELECT DISTINCT customer_name,
FORMAT(b.booking_date, 'yyyy-MM') AS booking_month
FROM Customer c
JOIN Booking b ON c.customer_id = b.customer_id


12. Calculate the Average Ticket Price for Events in Each Venue Using a Subquer
SELECT venue_name, (SELECT AVG(ticket_price) 
FROM Event e 
WHERE e.venue_id = v.venue_id) AS avg_ticket_price
FROM Venue v

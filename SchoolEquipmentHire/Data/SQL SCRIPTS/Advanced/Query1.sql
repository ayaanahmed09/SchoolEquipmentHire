SELECT Status, COUNT(*) AS TotalBookings
FROM Booking
GROUP BY Status;
